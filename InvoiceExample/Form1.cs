using Invoice.SDK.Rest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace InvoiceExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RestClient Rest = null;
        TerminalInfo Terminal;
        PaymentInfo Payment;

        private void Form1_Load(object sender, EventArgs e)
        {
            Rest = new RestClient(txtMerchantId.Text, txtApiKey.Text);
            Rest.Print = Console.WriteLine;

            //при загрузке плагина необходимо найти терминал или создать новый
            if (Terminal.id == null)
            {
                Terminal = Rest.GetTerminal(new GET_TERMINAL()
                {
                    alias = "1:1" //уникальный id в пределах вашей учетной записи. Например НомерМагазина:НомерКассы
                });

                if (Terminal.id == null)
                {
                    Terminal = Rest.CreateTerminal(new CREATE_TERMINAL()
                    {
                        alias = "1:1", //уникальный id в пределах вашей учетной записи. Например НомерМагазина:НомерКассы
                        name = "Название магазина",
                        description = "Касса #1",
                        type = TERMINAL_TYPE.dynamical,
                        defaultPrice = 0,
                    });
                }
            }
            linkLabel1.Text = Terminal.link;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            CREATE_PAYMENT request = new CREATE_PAYMENT()
            {
                order = new ORDER()
                {
                    amount = 1000m,
                    description = "Заказ #123",
                    id = Guid.NewGuid().ToString()
                },
                receipt = new List<ITEM>()
                {
                    new ITEM()
                    {
                        name = "Суп",
                        price = 5m,
                        quantity = 2,
                        resultPrice = 10m,
                        discount = "0"
                    },
                    new ITEM()
                    {
                        name = "Кефир",
                        price = 1000m,
                        quantity = 1,
                        resultPrice = 990m,
                        discount = "10"
                    }
                },
                settings = new SETTINGS()
                {
                    terminal_id = Terminal.id
                },
                custom_parameters = new Dictionary<string, Newtonsoft.Json.Linq.JToken>()
                {
                    //{ "параметр1" , "asd" },
                    //{ "параметр2" , 55 },
                    //{ "параметр3" , true }
                }
            };

            Payment = Rest.CreatePayment(request);

            if (Payment.error != null || Payment.status == PAYMENT_STATE.error)
                MessageBox.Show(Payment.description, "ERROR");
            else
                MessageBox.Show("платеж создан");
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            Payment = Rest.GetPayment(new GET_PAYMENT() { id = Payment.id });
            if (Payment.status == PAYMENT_STATE.error)
                MessageBox.Show("error");

            if (Payment.status == PAYMENT_STATE.successful)
                MessageBox.Show("done");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Rest.ClosePayment(new CLOSE_PAYMENT() { id = Payment.id });
            Payment = new PaymentInfo();

            MessageBox.Show("платеж отменен");
        }

        private void BtnRefund_Click(object sender, EventArgs e)
        {
            RefundInfo refund = Rest.CreateRefund(new CREATE_REFUND()
            {
                id = Payment.id,
                receipt = new List<ITEM>()
                {
                    new ITEM()
                    {
                        name = "Суп",
                        price = 5m,
                        quantity = 2,
                        resultPrice = 10m,
                        discount = "0"
                    },
                    new ITEM()
                    {
                        name = "Кефир",
                        price = 10m,
                        quantity = 1,
                        resultPrice = 10m,
                        discount = "0"
                    }
                },
                refund = new REFUND_INFO()
                {
                    amount = 20m,
                    reason = "В супе нашли муху. Вернули все"
                }
            });

            if (!string.IsNullOrEmpty(refund.error))
            {
                MessageBox.Show(refund.description, "Ошибка возврата #" + refund.error);
                return;
            }

            MessageBox.Show("Возврат прошел успешно!");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Rest = new RestClient(txtMerchantId.Text, txtApiKey.Text);
            Rest.Print = Console.WriteLine;
            Terminal = new TerminalInfo();

            if (Terminal.id == null)
            {
                Terminal = Rest.GetTerminal(new GET_TERMINAL()
                {
                    alias = "1:1" //уникальный id в пределах вашей учетной записи. Например НомерМагазина:НомерКассы
                });

                if (Terminal.id == null)
                {
                    Terminal = Rest.CreateTerminal(new CREATE_TERMINAL()
                    {
                        alias = "1:1", //уникальный id в пределах вашей учетной записи. Например НомерМагазина:НомерКассы
                        name = "Название магазина",
                        description = "Касса #1",
                        type = TERMINAL_TYPE.dynamical,
                        defaultPrice = 0,
                    });
                }
            }
            linkLabel1.Text = Terminal.link;
        }
    }
}
