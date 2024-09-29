namespace Phumla_System
{
    partial class BookingSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.custIDTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.bookingInfoListBox = new System.Windows.Forms.ListBox(); // Use ListBox or DataGridView for displaying info
            this.SuspendLayout();

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Customer ID to Search:";

            // 
            // custIDTextBox
            // 
            this.custIDTextBox.Location = new System.Drawing.Point(220, 20);
            this.custIDTextBox.Name = "custIDTextBox";
            this.custIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.custIDTextBox.TabIndex = 1;

            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(440, 20);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 30);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);

            // 
            // bookingInfoListBox
            // 
            this.bookingInfoListBox.FormattingEnabled = true;
            this.bookingInfoListBox.ItemHeight = 20;
            this.bookingInfoListBox.Location = new System.Drawing.Point(20, 70);
            this.bookingInfoListBox.Name = "bookingInfoListBox";
            this.bookingInfoListBox.Size = new System.Drawing.Size(500, 200);
            this.bookingInfoListBox.TabIndex = 3;

            // 
            // BookingSearch
            // 
            this.ClientSize = new System.Drawing.Size(550, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.custIDTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.bookingInfoListBox);
            this.Name = "BookingSearch";
            this.Text = "Booking Search";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox custIDTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox bookingInfoListBox; // Use ListBox or DataGridView for displaying info
    }
}
