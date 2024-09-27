namespace Phumla_System.Forms
{
    partial class BookingTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstBookings = new System.Windows.Forms.ListBox();
            this.dtpRequestDate = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtRequestDetails = new System.Windows.Forms.TextBox();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.txtRequestType = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.txtBookingID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstBookings
            // 
            this.lstBookings.FormattingEnabled = true;
            this.lstBookings.ItemHeight = 20;
            this.lstBookings.Location = new System.Drawing.Point(450, 31);
            this.lstBookings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstBookings.Name = "lstBookings";
            this.lstBookings.Size = new System.Drawing.Size(718, 604);
            this.lstBookings.TabIndex = 12;
            this.lstBookings.SelectedIndexChanged += new System.EventHandler(this.lstBookings_SelectedIndexChanged);
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.Location = new System.Drawing.Point(30, 400);
            this.dtpRequestDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Size = new System.Drawing.Size(298, 26);
            this.dtpRequestDate.TabIndex = 8;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Confirmed",
            "Cancelled",
            "Completed"});
            this.cmbStatus.Location = new System.Drawing.Point(30, 262);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 28);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // txtRequestDetails
            // 
            this.txtRequestDetails.Location = new System.Drawing.Point(30, 354);
            this.txtRequestDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRequestDetails.Name = "txtRequestDetails";
            this.txtRequestDetails.Size = new System.Drawing.Size(148, 26);
            this.txtRequestDetails.TabIndex = 7;
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Location = new System.Drawing.Point(30, 169);
            this.dtpCheckIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(298, 26);
            this.dtpCheckIn.TabIndex = 3;
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Location = new System.Drawing.Point(30, 215);
            this.dtpCheckOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(298, 26);
            this.dtpCheckOut.TabIndex = 4;
            // 
            // txtRequestType
            // 
            this.txtRequestType.Location = new System.Drawing.Point(30, 308);
            this.txtRequestType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRequestType.Name = "txtRequestType";
            this.txtRequestType.Size = new System.Drawing.Size(148, 26);
            this.txtRequestType.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(270, 446);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 35);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(150, 446);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 35);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(30, 446);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtRoomID
            // 
            this.txtRoomID.Location = new System.Drawing.Point(30, 123);
            this.txtRoomID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(148, 26);
            this.txtRoomID.TabIndex = 2;
            // 
            // txtCustID
            // 
            this.txtCustID.Location = new System.Drawing.Point(30, 77);
            this.txtCustID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.Size = new System.Drawing.Size(148, 26);
            this.txtCustID.TabIndex = 1;
            // 
            // txtBookingID
            // 
            this.txtBookingID.Location = new System.Drawing.Point(30, 31);
            this.txtBookingID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBookingID.Name = "txtBookingID";
            this.txtBookingID.Size = new System.Drawing.Size(148, 26);
            this.txtBookingID.TabIndex = 0;
            this.txtBookingID.TextChanged += new System.EventHandler(this.txtBookingID_TextChanged);
            // 
            // BookingTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.lstBookings);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpRequestDate);
            this.Controls.Add(this.txtRequestDetails);
            this.Controls.Add(this.txtRequestType);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.dtpCheckOut);
            this.Controls.Add(this.dtpCheckIn);
            this.Controls.Add(this.txtRoomID);
            this.Controls.Add(this.txtCustID);
            this.Controls.Add(this.txtBookingID);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BookingTestForm";
            this.Text = "Booking Test Form";
            this.Load += new System.EventHandler(this.BookingTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBookings;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtRequestDetails;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.TextBox txtRequestType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.TextBox txtCustID;
        private System.Windows.Forms.TextBox txtBookingID;
    }
}