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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelBooking));
            this.dataGridViewBookings = new System.Windows.Forms.DataGridView();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBookings
            // 
            this.dataGridViewBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBookings.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewBookings.Name = "dataGridViewBookings";
            this.dataGridViewBookings.RowHeadersWidth = 62;
            this.dataGridViewBookings.Size = new System.Drawing.Size(776, 300);
            this.dataGridViewBookings.TabIndex = 0;
            this.dataGridViewBookings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBookings_CellContentClick);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnCancelBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBooking.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnCancelBooking.Location = new System.Drawing.Point(12, 380);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(776, 28);
            this.btnCancelBooking.TabIndex = 3;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(101, 350);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(101, 322);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(12, 350);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 20);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(12, 320);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 20);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // CancelBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.dataGridViewBookings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CancelBooking";
            this.Text = "Cancel Booking";
            this.Load += new System.EventHandler(this.CancelBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
