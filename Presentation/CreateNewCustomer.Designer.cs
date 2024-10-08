using System;

namespace Phumla_System
{
    partial class CreateNewCustomer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Surname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Telephone = new System.Windows.Forms.TextBox();
            this.EmailAddress = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.CustomerID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Balance = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.crtBookingTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Surname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Telephone);
            this.groupBox1.Controls.Add(this.EmailAddress);
            this.groupBox1.Controls.Add(this.Address);
            this.groupBox1.Controls.Add(this.CustomerName);
            this.groupBox1.Controls.Add(this.CustomerID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.phone);
            this.groupBox1.Controls.Add(this.email);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Status);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Balance);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(40, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1041, 538);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Surname
            // 
            this.Surname.Location = new System.Drawing.Point(338, 105);
            this.Surname.Multiline = true;
            this.Surname.Name = "Surname";
            this.Surname.Size = new System.Drawing.Size(670, 26);
            this.Surname.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(42, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Surname";
            // 
            // Telephone
            // 
            this.Telephone.Location = new System.Drawing.Point(338, 305);
            this.Telephone.Name = "Telephone";
            this.Telephone.Size = new System.Drawing.Size(670, 26);
            this.Telephone.TabIndex = 7;
            // 
            // EmailAddress
            // 
            this.EmailAddress.Location = new System.Drawing.Point(338, 240);
            this.EmailAddress.Multiline = true;
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Size = new System.Drawing.Size(670, 26);
            this.EmailAddress.TabIndex = 6;
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(338, 172);
            this.Address.Multiline = true;
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(670, 26);
            this.Address.TabIndex = 5;
            // 
            // CustomerName
            // 
            this.CustomerName.Location = new System.Drawing.Point(338, 62);
            this.CustomerName.Multiline = true;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(670, 26);
            this.CustomerName.TabIndex = 10;
            // 
            // CustomerID
            // 
            this.CustomerID.Location = new System.Drawing.Point(338, 18);
            this.CustomerID.Multiline = true;
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Size = new System.Drawing.Size(670, 26);
            this.CustomerID.TabIndex = 4;
            this.CustomerID.TextChanged += new System.EventHandler(this.CustomerID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(42, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Customer ID(SA ID)";
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.phone.Location = new System.Drawing.Point(45, 297);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(204, 32);
            this.phone.TabIndex = 3;
            this.phone.Text = "Phone Number";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.email.Location = new System.Drawing.Point(45, 232);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(197, 32);
            this.email.TabIndex = 2;
            this.email.Text = "Email Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(42, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Home Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(42, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Customer Name";
            // 
            // Status
            // 
            this.Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Status.FormattingEnabled = true;
            this.Status.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.Status.Location = new System.Drawing.Point(338, 369);
            this.Status.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(670, 28);
            this.Status.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(42, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "Status";
            // 
            // Balance
            // 
            this.Balance.DecimalPlaces = 2;
            this.Balance.Location = new System.Drawing.Point(338, 431);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(672, 26);
            this.Balance.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label7.Location = new System.Drawing.Point(42, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 32);
            this.label7.TabIndex = 13;
            this.label7.Text = "Balance";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.confirmButton.Location = new System.Drawing.Point(441, 726);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(165, 54);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // crtBookingTitle
            // 
            this.crtBookingTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crtBookingTitle.AutoSize = true;
            this.crtBookingTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crtBookingTitle.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.crtBookingTitle.Location = new System.Drawing.Point(369, 68);
            this.crtBookingTitle.Name = "crtBookingTitle";
            this.crtBookingTitle.Size = new System.Drawing.Size(468, 46);
            this.crtBookingTitle.TabIndex = 3;
            this.crtBookingTitle.Text = "Create a New Customer";
            // 
            // CreateNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 858);
            this.Controls.Add(this.crtBookingTitle);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateNewCustomer";
            this.Text = "Create New Customer";
            this.Load += new System.EventHandler(this.CreateNewCustomer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Surname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Telephone;
        private System.Windows.Forms.TextBox EmailAddress;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox CustomerName;
        private System.Windows.Forms.TextBox CustomerID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Balance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button confirmButton;

        private void CreateNewCustomer_Load(object sender, EventArgs e)
        {
            // Add any initialization code here
        }

        private System.Windows.Forms.Label crtBookingTitle;
    }
}
