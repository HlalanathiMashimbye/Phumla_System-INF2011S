﻿namespace Phumla_System.Forms
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
            this.txtBookingID = new System.Windows.Forms.TextBox();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtRequestType = new System.Windows.Forms.TextBox();
            this.txtRequestDetails = new System.Windows.Forms.TextBox();
            this.dtpRequestDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstBookings = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtBookingID
            // 
            this.txtBookingID.Location = new System.Drawing.Point(20, 20);
            this.txtBookingID.Name = "txtBookingID";
            this.txtBookingID.Size = new System.Drawing.Size(100, 20);
            this.txtBookingID.TabIndex = 0;
            // 
            // txtCustID
            // 
            this.txtCustID.Location = new System.Drawing.Point(20, 50);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.Size = new System.Drawing.Size(100, 20);
            this.txtCustID.TabIndex = 1;
            // 
            // txtRoomID
            // 
            this.txtRoomID.Location = new System.Drawing.Point(20, 80);
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(100, 20);
            this.txtRoomID.TabIndex = 2;
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Location = new System.Drawing.Point(20, 110);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(200, 20);
            this.dtpCheckIn.TabIndex = 3;
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Location = new System.Drawing.Point(20, 140);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(200, 20);
            this.dtpCheckOut.TabIndex = 4;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] { "Confirmed", "Cancelled", "Completed" });
            this.cmbStatus.Location = new System.Drawing.Point(20, 170);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 5;
            // 
            // txtRequestType
            // 
            this.txtRequestType.Location = new System.Drawing.Point(20, 200);
            this.txtRequestType.Name = "txtRequestType";
            this.txtRequestType.Size = new System.Drawing.Size(100, 20);
            this.txtRequestType.TabIndex = 6;
            // 
            // txtRequestDetails
            // 
            this.txtRequestDetails.Location = new System.Drawing.Point(20, 230);
            this.txtRequestDetails.Name = "txtRequestDetails";
            this.txtRequestDetails.Size = new System.Drawing.Size(100, 20);
            this.txtRequestDetails.TabIndex = 7;
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.Location = new System.Drawing.Point(20, 260);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Size = new System.Drawing.Size(200, 20);
            this.dtpRequestDate.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 290);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(100, 290);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(180, 290);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstBookings
            // 
            this.lstBookings.FormattingEnabled = true;
            this.lstBookings.Location = new System.Drawing.Point(300, 20);
            this.lstBookings.Name = "lstBookings";
            this.lstBookings.Size = new System.Drawing.Size(480, 400);
            this.lstBookings.TabIndex = 12;
            // 
            // BookingTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "BookingTestForm";
            this.Text = "Booking Test Form";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtBookingID;
        private System.Windows.Forms.TextBox txtCustID;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtRequestType;
        private System.Windows.Forms.TextBox txtRequestDetails;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstBookings;
    }
}