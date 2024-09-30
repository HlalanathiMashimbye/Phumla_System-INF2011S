namespace Phumla_System
{
    partial class CreateBookingForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.customerSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.occupancyLevelReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crtBookingTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.checkOutDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.checkInDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.requirementsTextBox = new System.Windows.Forms.TextBox();
            this.noOfGuestsTextBox = new System.Windows.Forms.TextBox();
            this.noOfRooms = new System.Windows.Forms.TextBox();
            this.custIDTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.checkInLabel = new System.Windows.Forms.Label();
            this.requirementsLabel = new System.Windows.Forms.Label();
            this.checkOutLabel = new System.Windows.Forms.Label();
            this.noOfGuestsLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.custIDLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.checkAvailButton = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 38);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1134, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Thistle;
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerSearchToolStripMenuItem,
            this.newBookingToolStripMenuItem,
            this.modifyBookingToolStripMenuItem,
            this.notificationsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1134, 38);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // customerSearchToolStripMenuItem
            // 
            this.customerSearchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem,
            this.createNewCustomerToolStripMenuItem});
            this.customerSearchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerSearchToolStripMenuItem.Name = "customerSearchToolStripMenuItem";
            this.customerSearchToolStripMenuItem.Size = new System.Drawing.Size(197, 34);
            this.customerSearchToolStripMenuItem.Text = "Customer Search";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(335, 38);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // createNewCustomerToolStripMenuItem
            // 
            this.createNewCustomerToolStripMenuItem.Name = "createNewCustomerToolStripMenuItem";
            this.createNewCustomerToolStripMenuItem.Size = new System.Drawing.Size(335, 38);
            this.createNewCustomerToolStripMenuItem.Text = "Create New Customer";
            this.createNewCustomerToolStripMenuItem.Click += new System.EventHandler(this.createNewCustomerToolStripMenuItem_Click);
            // 
            // newBookingToolStripMenuItem
            // 
            this.newBookingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBookingToolStripMenuItem.Name = "newBookingToolStripMenuItem";
            this.newBookingToolStripMenuItem.Size = new System.Drawing.Size(184, 34);
            this.newBookingToolStripMenuItem.Text = "Booking Search";
            this.newBookingToolStripMenuItem.Click += new System.EventHandler(this.newBookingToolStripMenuItem_Click);
            // 
            // modifyBookingToolStripMenuItem
            // 
            this.modifyBookingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeBookingToolStripMenuItem,
            this.cancelBookingToolStripMenuItem});
            this.modifyBookingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBookingToolStripMenuItem.Name = "modifyBookingToolStripMenuItem";
            this.modifyBookingToolStripMenuItem.Size = new System.Drawing.Size(189, 34);
            this.modifyBookingToolStripMenuItem.Text = "Modify Booking";
            // 
            // changeBookingToolStripMenuItem
            // 
            this.changeBookingToolStripMenuItem.Name = "changeBookingToolStripMenuItem";
            this.changeBookingToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.changeBookingToolStripMenuItem.Text = "Change Booking";
            this.changeBookingToolStripMenuItem.Click += new System.EventHandler(this.changeBookingToolStripMenuItem_Click);
            // 
            // cancelBookingToolStripMenuItem
            // 
            this.cancelBookingToolStripMenuItem.Name = "cancelBookingToolStripMenuItem";
            this.cancelBookingToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.cancelBookingToolStripMenuItem.Text = "Cancel Booking";
            this.cancelBookingToolStripMenuItem.Click += new System.EventHandler(this.cancelBookingToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.occupancyLevelReportToolStripMenuItem});
            this.notificationsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(147, 34);
            this.notificationsToolStripMenuItem.Text = "Get Reports";
            this.notificationsToolStripMenuItem.Click += new System.EventHandler(this.notificationsToolStripMenuItem_Click);
            // 
            // occupancyLevelReportToolStripMenuItem
            // 
            this.occupancyLevelReportToolStripMenuItem.Name = "occupancyLevelReportToolStripMenuItem";
            this.occupancyLevelReportToolStripMenuItem.Size = new System.Drawing.Size(356, 38);
            this.occupancyLevelReportToolStripMenuItem.Text = "Occupancy Level Report";
            this.occupancyLevelReportToolStripMenuItem.Click += new System.EventHandler(this.occupancyLevelReportToolStripMenuItem_Click);
            // 
            // crtBookingTitle
            // 
            this.crtBookingTitle.AutoSize = true;
            this.crtBookingTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crtBookingTitle.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.crtBookingTitle.Location = new System.Drawing.Point(362, 78);
            this.crtBookingTitle.Name = "crtBookingTitle";
            this.crtBookingTitle.Size = new System.Drawing.Size(440, 46);
            this.crtBookingTitle.TabIndex = 2;
            this.crtBookingTitle.Text = "Create a New Booking";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Reservation Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.surnameTextBox);
            this.groupBox1.Controls.Add(this.surnameLabel);
            this.groupBox1.Controls.Add(this.checkOutDateTimePicker);
            this.groupBox1.Controls.Add(this.checkInDateTimePicker);
            this.groupBox1.Controls.Add(this.requirementsTextBox);
            this.groupBox1.Controls.Add(this.noOfGuestsTextBox);
            this.groupBox1.Controls.Add(this.noOfRooms);
            this.groupBox1.Controls.Add(this.custIDTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.checkInLabel);
            this.groupBox1.Controls.Add(this.requirementsLabel);
            this.groupBox1.Controls.Add(this.checkOutLabel);
            this.groupBox1.Controls.Add(this.noOfGuestsLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.custIDLabel);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(56, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1026, 492);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(286, 146);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(343, 26);
            this.surnameTextBox.TabIndex = 21;
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameLabel.Location = new System.Drawing.Point(28, 145);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(101, 26);
            this.surnameLabel.TabIndex = 20;
            this.surnameLabel.Text = "Surname";
            // 
            // checkOutDateTimePicker
            // 
            this.checkOutDateTimePicker.Location = new System.Drawing.Point(286, 409);
            this.checkOutDateTimePicker.Name = "checkOutDateTimePicker";
            this.checkOutDateTimePicker.Size = new System.Drawing.Size(343, 26);
            this.checkOutDateTimePicker.TabIndex = 19;
            this.checkOutDateTimePicker.Value = new System.DateTime(2024, 12, 18, 23, 22, 0, 0);
            // 
            // checkInDateTimePicker
            // 
            this.checkInDateTimePicker.Location = new System.Drawing.Point(286, 369);
            this.checkInDateTimePicker.Name = "checkInDateTimePicker";
            this.checkInDateTimePicker.Size = new System.Drawing.Size(343, 26);
            this.checkInDateTimePicker.TabIndex = 18;
            this.checkInDateTimePicker.Value = new System.DateTime(2024, 12, 13, 23, 22, 0, 0);
            // 
            // requirementsTextBox
            // 
            this.requirementsTextBox.Location = new System.Drawing.Point(292, 463);
            this.requirementsTextBox.Name = "requirementsTextBox";
            this.requirementsTextBox.Size = new System.Drawing.Size(338, 26);
            this.requirementsTextBox.TabIndex = 17;
            // 
            // noOfGuestsTextBox
            // 
            this.noOfGuestsTextBox.Location = new System.Drawing.Point(286, 312);
            this.noOfGuestsTextBox.Name = "noOfGuestsTextBox";
            this.noOfGuestsTextBox.Size = new System.Drawing.Size(343, 26);
            this.noOfGuestsTextBox.TabIndex = 16;
            // 
            // noOfRooms
            // 
            this.noOfRooms.Location = new System.Drawing.Point(286, 252);
            this.noOfRooms.Name = "noOfRooms";
            this.noOfRooms.Size = new System.Drawing.Size(343, 26);
            this.noOfRooms.TabIndex = 13;
            // 
            // custIDTextBox
            // 
            this.custIDTextBox.Location = new System.Drawing.Point(286, 195);
            this.custIDTextBox.Name = "custIDTextBox";
            this.custIDTextBox.Size = new System.Drawing.Size(343, 26);
            this.custIDTextBox.TabIndex = 12;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(286, 98);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(343, 26);
            this.nameTextBox.TabIndex = 11;
            // 
            // checkInLabel
            // 
            this.checkInLabel.AutoSize = true;
            this.checkInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkInLabel.Location = new System.Drawing.Point(28, 369);
            this.checkInLabel.Name = "checkInLabel";
            this.checkInLabel.Size = new System.Drawing.Size(146, 26);
            this.checkInLabel.TabIndex = 10;
            this.checkInLabel.Text = "Check-in date";
            // 
            // requirementsLabel
            // 
            this.requirementsLabel.AutoSize = true;
            this.requirementsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requirementsLabel.Location = new System.Drawing.Point(28, 463);
            this.requirementsLabel.Name = "requirementsLabel";
            this.requirementsLabel.Size = new System.Drawing.Size(226, 26);
            this.requirementsLabel.TabIndex = 9;
            this.requirementsLabel.Text = "Special Requirements";
            // 
            // checkOutLabel
            // 
            this.checkOutLabel.AutoSize = true;
            this.checkOutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOutLabel.Location = new System.Drawing.Point(28, 409);
            this.checkOutLabel.Name = "checkOutLabel";
            this.checkOutLabel.Size = new System.Drawing.Size(159, 26);
            this.checkOutLabel.TabIndex = 8;
            this.checkOutLabel.Text = "Check-out date";
            // 
            // noOfGuestsLabel
            // 
            this.noOfGuestsLabel.AutoSize = true;
            this.noOfGuestsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfGuestsLabel.Location = new System.Drawing.Point(28, 312);
            this.noOfGuestsLabel.Name = "noOfGuestsLabel";
            this.noOfGuestsLabel.Size = new System.Drawing.Size(145, 26);
            this.noOfGuestsLabel.TabIndex = 7;
            this.noOfGuestsLabel.Text = "No. of Guests";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "No. of Rooms";
            // 
            // custIDLabel
            // 
            this.custIDLabel.AutoSize = true;
            this.custIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custIDLabel.Location = new System.Drawing.Point(28, 194);
            this.custIDLabel.Name = "custIDLabel";
            this.custIDLabel.Size = new System.Drawing.Size(135, 26);
            this.custIDLabel.TabIndex = 5;
            this.custIDLabel.Text = "Customer ID";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(28, 97);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(71, 26);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.exitButton.Location = new System.Drawing.Point(767, 630);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(79, 40);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            // 
            // checkAvailButton
            // 
            this.checkAvailButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.checkAvailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAvailButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.checkAvailButton.Location = new System.Drawing.Point(903, 630);
            this.checkAvailButton.Name = "checkAvailButton";
            this.checkAvailButton.Size = new System.Drawing.Size(219, 39);
            this.checkAvailButton.TabIndex = 6;
            this.checkAvailButton.Text = "Check Availability";
            this.checkAvailButton.UseVisualStyleBackColor = false;
            // 
            // CreateBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1134, 682);
            this.Controls.Add(this.checkAvailButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crtBookingTitle);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CreateBookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateBookingForm";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem customerSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.Label crtBookingTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label checkInLabel;
        private System.Windows.Forms.Label requirementsLabel;
        private System.Windows.Forms.Label checkOutLabel;
        private System.Windows.Forms.Label noOfGuestsLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label custIDLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.DateTimePicker checkInDateTimePicker;
        private System.Windows.Forms.TextBox requirementsTextBox;
        private System.Windows.Forms.TextBox noOfGuestsTextBox;
        private System.Windows.Forms.TextBox noOfRooms;
        private System.Windows.Forms.TextBox custIDTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DateTimePicker checkOutDateTimePicker;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button checkAvailButton;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem occupancyLevelReportToolStripMenuItem;
    }
}