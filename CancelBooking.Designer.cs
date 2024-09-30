using System.Drawing;
using System.Windows.Forms;
using System;

namespace Phumla_System
{
    public partial class CancelBooking : Form
    {
        private DataGridView dataGridViewBookings;
        private Button btnCancelBooking;
        private TextBox txtPassword;
        private TextBox txtEmail;   // Added email TextBox
        private Label lblPassword;
        private Label lblEmail;     // Added email Label

        private void InitializeComponent()
        {
            this.dataGridViewBookings = new DataGridView();
            this.btnCancelBooking = new Button();
            this.txtPassword = new TextBox();
            this.txtEmail = new TextBox();  // Initialize email TextBox
            this.lblPassword = new Label();
            this.lblEmail = new Label();    // Initialize email Label

            this.SuspendLayout();

            // dataGridViewBookings
            this.dataGridViewBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBookings.Location = new Point(12, 12);
            this.dataGridViewBookings.Name = "dataGridViewBookings";
            this.dataGridViewBookings.Size = new Size(776, 300);
            this.dataGridViewBookings.TabIndex = 0;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(12, 320);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(35, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new Point(74, 317);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(200, 20);
            this.txtEmail.TabIndex = 5;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(12, 350);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(56, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";

            // txtPassword
            this.txtPassword.Location = new Point(74, 347);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';  // Mask the password input
            this.txtPassword.Size = new Size(200, 20);
            this.txtPassword.TabIndex = 2;

            // btnCancelBooking
            this.btnCancelBooking.Location = new Point(12, 380);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new Size(776, 23);
            this.btnCancelBooking.TabIndex = 3;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new EventHandler(this.btnCancelBooking_Click);

            // CancelBooking Form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.lblEmail);  // Add email Label to form
            this.Controls.Add(this.txtEmail);  // Add email TextBox to form
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.dataGridViewBookings);
            this.Name = "CancelBooking";
            this.Text = "Cancel Booking";
            this.Load += new EventHandler(this.CancelBooking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
