namespace InvoiceExample
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefund = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtMerchantId = new System.Windows.Forms.TextBox();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.btnAuthorization = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(12, 35);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 0;
            this.btnPay.Text = "Оплатить";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.BtnPay_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(183, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnRefund
            // 
            this.btnRefund.Location = new System.Drawing.Point(268, 35);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(75, 23);
            this.btnRefund.TabIndex = 2;
            this.btnRefund.Text = "Вернуть";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.BtnRefund_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(13, 65);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(97, 35);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Проверить";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // txtMerchantId
            // 
            this.txtMerchantId.Location = new System.Drawing.Point(13, 9);
            this.txtMerchantId.Name = "txtMerchantId";
            this.txtMerchantId.Size = new System.Drawing.Size(37, 20);
            this.txtMerchantId.TabIndex = 5;
            this.txtMerchantId.Text = "c24360cfac0a0c40c518405f6bc68cb0";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(56, 9);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(193, 20);
            this.txtApiKey.TabIndex = 6;
            this.txtApiKey.Text = "1526fec01b5d11f4df4f2160627ce351";
            // 
            // btnAuthorization
            // 
            this.btnAuthorization.Location = new System.Drawing.Point(256, 7);
            this.btnAuthorization.Name = "btnAuthorization";
            this.btnAuthorization.Size = new System.Drawing.Size(87, 23);
            this.btnAuthorization.TabIndex = 7;
            this.btnAuthorization.Text = "Авторизация";
            this.btnAuthorization.UseVisualStyleBackColor = true;
            this.btnAuthorization.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 88);
            this.Controls.Add(this.btnAuthorization);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.txtMerchantId);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnRefund);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtMerchantId;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Button btnAuthorization;
    }
}

