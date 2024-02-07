using Invoice.SDK.Rest;

namespace Invoice.Example
{
    internal class Programm
    {
        static void Main()
        {
            RestClient rest = null;
            TerminalInfo terminal = new TerminalInfo();
            PaymentInfo payment = new PaymentInfo();
            var merchantID = "c24360cfac0a0c40c518405f6bc68cb0";
            var apiKey = "1526fec01b5d11f4df4f2160627ce351";

            rest = new RestClient(merchantID, apiKey);
            rest.Print = Console.WriteLine;

            if (terminal.id == null)
            {
                terminal = rest.GetTerminal(new GET_TERMINAL()
                {
                    alias = "1:1"
                });

                if (terminal.id == null)
                {
                    terminal = rest.CreateTerminal(new CREATE_TERMINAL()
                    {
                        alias = "1:1", //уникальный id в пределах вашей учетной записи. Например НомерМагазина:НомерКассы
                        name = "Название магазина",
                        description = "Касса #1",
                        type = TERMINAL_TYPE.dynamical,
                        defaultPrice = 0,
                    });
                }

                Console.WriteLine(terminal.link);
            }

            CREATE_PAYMENT create_request = new CREATE_PAYMENT()
            {
                order = new ORDER()
                {
                    amount = 1000.0,
                    description = "ORDER#123",
                    id = Guid.NewGuid().ToString()
                },
                receipt = new List<RECEIPT>()
                {
                    new RECEIPT()
                    {
                        name = "Суп",
                        price = 50,
                        quantity = 2,
                        resultPrice = 10,
                        discount = "0"
                    },
                    new RECEIPT()
                    {
                        name = "Кефир",
                        price = 1000,
                        quantity = 1,
                        resultPrice = 990,
                        discount = "10"
                    }
                },
                settings = new SETTINGS()
                {
                    terminal_id = terminal.id
                },
                trtype = (int)RT_TYPE.payment,
                phone = "89999999999",
                custom_parameters = new Dictionary<string, Newtonsoft.Json.Linq.JToken>()
                {
                    { "param1" , "asd" },
                    { "param2" , 55 },
                    { "param3" , true }
                }
            };
            payment = rest.CreatePayment(create_request);
            if (payment.status == PAYMENT_STATE.error)
                Console.WriteLine(payment.status_description, "ERROR");
            else
                Console.WriteLine("PAYMENT CREATED");
            if (payment.status == PAYMENT_STATE.successful)
                Console.WriteLine("PAYMENT DONE");

            CLOSE_PAYMENT close_request = new CLOSE_PAYMENT()
            {
                id = payment.id,
            };

            payment = rest.ClosePayment(close_request);
            if (payment.status == PAYMENT_STATE.error)
                Console.WriteLine(payment.status_description, "ERROR");
            else
                Console.WriteLine("PAYMENT CLOSED");



            Console.ReadLine();
        }
    }
}
