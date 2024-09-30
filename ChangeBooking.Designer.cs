namespace Phumla_System
{
    partial class ChangeBooking
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblBookingID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCheckOutDate = new System.Windows.Forms.Label();
            this.lblRequestDetails = new System.Windows.Forms.Label();
            this.lblCheckInDate = new System.Windows.Forms.Label();
            this.txtBookingID = new System.Windows.Forms.TextBox();
            this.dtpCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.lblRoomID = new System.Windows.Forms.Label();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.txtRequestDetails = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbNumGuests = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label1.Location = new System.Drawing.Point(289, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit Booking";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnCancel.Location = new System.Drawing.Point(40, 430);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 29);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.Location = new System.Drawing.Point(589, 428);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 30);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Update Booking";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(147, 281);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 18);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Status";
            // 
            // lblBookingID
            // 
            this.lblBookingID.AutoSize = true;
            this.lblBookingID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingID.Location = new System.Drawing.Point(118, 91);
            this.lblBookingID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(81, 18);
            this.lblBookingID.TabIndex = 4;
            this.lblBookingID.Text = "Booking ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "No. of Guests";
            // 
            // lblCheckOutDate
            // 
            this.lblCheckOutDate.AutoSize = true;
            this.lblCheckOutDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOutDate.Location = new System.Drawing.Point(90, 245);
            this.lblCheckOutDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckOutDate.Name = "lblCheckOutDate";
            this.lblCheckOutDate.Size = new System.Drawing.Size(109, 18);
            this.lblCheckOutDate.TabIndex = 8;
            this.lblCheckOutDate.Text = "Check-out date";
            // 
            // lblRequestDetails
            // 
            this.lblRequestDetails.AutoSize = true;
            this.lblRequestDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestDetails.Location = new System.Drawing.Point(90, 320);
            this.lblRequestDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRequestDetails.Name = "lblRequestDetails";
            this.lblRequestDetails.Size = new System.Drawing.Size(112, 18);
            this.lblRequestDetails.TabIndex = 9;
            this.lblRequestDetails.Text = "Request Details";
            // 
            // lblCheckInDate
            // 
            this.lblCheckInDate.AutoSize = true;
            this.lblCheckInDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInDate.Location = new System.Drawing.Point(98, 210);
            this.lblCheckInDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckInDate.Name = "lblCheckInDate";
            this.lblCheckInDate.Size = new System.Drawing.Size(99, 18);
            this.lblCheckInDate.TabIndex = 10;
            this.lblCheckInDate.Text = "Check-in date";
            // 
            // txtBookingID
            // 
            this.txtBookingID.Location = new System.Drawing.Point(215, 92);
            this.txtBookingID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBookingID.Name = "txtBookingID";
            this.txtBookingID.Size = new System.Drawing.Size(230, 20);
            this.txtBookingID.TabIndex = 11;
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.Location = new System.Drawing.Point(215, 208);
            this.dtpCheckInDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(230, 20);
            this.dtpCheckInDate.TabIndex = 18;
            this.dtpCheckInDate.Value = new System.DateTime(2024, 12, 13, 23, 22, 0, 0);
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.Location = new System.Drawing.Point(215, 245);
            this.dtpCheckOutDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(230, 20);
            this.dtpCheckOutDate.TabIndex = 19;
            this.dtpCheckOutDate.Value = new System.DateTime(2024, 12, 18, 23, 22, 0, 0);
            // 
            // lblRoomID
            // 
            this.lblRoomID.AutoSize = true;
            this.lblRoomID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomID.Location = new System.Drawing.Point(131, 168);
            this.lblRoomID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomID.Name = "lblRoomID";
            this.lblRoomID.Size = new System.Drawing.Size(68, 18);
            this.lblRoomID.TabIndex = 7;
            this.lblRoomID.Text = "Room ID";
            // 
            // txtRoomID
            // 
            this.txtRoomID.Location = new System.Drawing.Point(215, 168);
            this.txtRoomID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(230, 20);
            this.txtRoomID.TabIndex = 12;
            // 
            // txtRequestDetails
            // 
            this.txtRequestDetails.Location = new System.Drawing.Point(215, 320);
            this.txtRequestDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRequestDetails.Multiline = true;
            this.txtRequestDetails.Name = "txtRequestDetails";
            this.txtRequestDetails.Size = new System.Drawing.Size(230, 51);
            this.txtRequestDetails.TabIndex = 13;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Confirmed",
            "Pending",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(215, 278);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(230, 21);
            this.cmbStatus.TabIndex = 22;
            // 
            // cmbNumGuests
            // 
            this.cmbNumGuests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumGuests.FormattingEnabled = true;
            this.cmbNumGuests.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbNumGuests.Location = new System.Drawing.Point(215, 124);
            this.cmbNumGuests.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbNumGuests.Name = "cmbNumGuests";
            this.cmbNumGuests.Size = new System.Drawing.Size(230, 21);
            this.cmbNumGuests.TabIndex = 23;
            this.cmbNumGuests.SelectedIndexChanged += new System.EventHandler(this.cmbNumGuests_SelectedIndexChanged);
            // 
            // ChangeBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 487);
            this.Controls.Add(this.cmbNumGuests);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpCheckOutDate);
            this.Controls.Add(this.dtpCheckInDate);
            this.Controls.Add(this.txtRequestDetails);
            this.Controls.Add(this.txtRoomID);
            this.Controls.Add(this.txtBookingID);
            this.Controls.Add(this.lblCheckInDate);
            this.Controls.Add(this.lblRequestDetails);
            this.Controls.Add(this.lblCheckOutDate);
            this.Controls.Add(this.lblRoomID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBookingID);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChangeBooking";
            this.Text = "ChangeBooking";
            this.Load += new System.EventHandler(this.ChangeBooking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblBookingID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCheckOutDate;
        private System.Windows.Forms.Label lblRequestDetails;
        private System.Windows.Forms.Label lblCheckInDate;
        private System.Windows.Forms.TextBox txtBookingID;
        private System.Windows.Forms.DateTimePicker dtpCheckInDate;
        private System.Windows.Forms.DateTimePicker dtpCheckOutDate;
        private System.Windows.Forms.Label lblRoomID;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.TextBox txtRequestDetails;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbNumGuests; // ComboBox for guests
    }
}
