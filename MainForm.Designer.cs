namespace Phumla_System
{
    partial class MainForm
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
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage roomTabPage;
        private System.Windows.Forms.TabPage customerTabPage;
        private System.Windows.Forms.TabPage bookingTabPage;
        private System.Windows.Forms.DataGridView roomDataGridView;
        private System.Windows.Forms.DataGridView customerDataGridView;
        private System.Windows.Forms.DataGridView bookingDataGridView;
        private System.Windows.Forms.TextBox roomIdTextBox;
        private System.Windows.Forms.TextBox roomNumberTextBox;
        private System.Windows.Forms.TextBox roomTypeTextBox;
        private System.Windows.Forms.TextBox roomPriceTextBox;
        private System.Windows.Forms.Button addRoomButton;
        private System.Windows.Forms.Button updateRoomButton;
        private System.Windows.Forms.Button deleteRoomButton;
        private System.Windows.Forms.TextBox customerIdTextBox;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.TextBox customerContactTextBox;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.TextBox bookingIdTextBox;
        private System.Windows.Forms.TextBox bookingCustomerIdTextBox;
        private System.Windows.Forms.TextBox bookingRoomIdTextBox;
        private System.Windows.Forms.TextBox bookingCheckInDateTextBox;
        private System.Windows.Forms.TextBox bookingCheckOutDateTextBox;
        private System.Windows.Forms.Button addBookingButton;
        private System.Windows.Forms.Button updateBookingButton;
        private System.Windows.Forms.Button deleteBookingButton;
    }
}
