namespace Phumla_System.Presentation
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bookingsDatabaseDataSet = new Phumla_System.BookingsDatabaseDataSet();
            this.bookingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookingTableAdapter = new Phumla_System.BookingsDatabaseDataSetTableAdapters.BookingTableAdapter();
            this.tableAdapterManager = new Phumla_System.BookingsDatabaseDataSetTableAdapters.TableAdapterManager();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.customerSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewCustomerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewBookingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.occupancyLevelReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationCancellationReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingBindingSource)).BeginInit();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip.Location = new System.Drawing.Point(0, 433);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(787, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(67, 16);
            // 
            // bookingsDatabaseDataSet
            // 
            this.bookingsDatabaseDataSet.DataSetName = "BookingsDatabaseDataSet";
            this.bookingsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookingBindingSource
            // 
            this.bookingBindingSource.DataMember = "Booking";
            this.bookingBindingSource.DataSource = this.bookingsDatabaseDataSet;
            // 
            // bookingTableAdapter
            // 
            this.bookingTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BookingSystemTableAdapter = null;
            this.tableAdapterManager.BookingTableAdapter = this.bookingTableAdapter;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.HotelTableAdapter = null;
            this.tableAdapterManager.PaymentTableAdapter = null;
            this.tableAdapterManager.ReceptionistTableAdapter = null;
            this.tableAdapterManager.ReportsTableAdapter = null;
            this.tableAdapterManager.RoomTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Phumla_System.BookingsDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Thistle;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerSearchToolStripMenuItem,
            this.createNewCustomerToolStripMenuItem1,
            this.newBookingToolStripMenuItem,
            this.createNewBookingToolStripMenuItem1,
            this.modifyBookingToolStripMenuItem,
            this.notificationsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip2.Size = new System.Drawing.Size(787, 26);
            this.menuStrip2.TabIndex = 7;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // customerSearchToolStripMenuItem
            // 
            this.customerSearchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerSearchToolStripMenuItem.Name = "customerSearchToolStripMenuItem";
            this.customerSearchToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.customerSearchToolStripMenuItem.Text = "Customer List";
            this.customerSearchToolStripMenuItem.Click += new System.EventHandler(this.customerSearchToolStripMenuItem_Click);
            // 
            // createNewCustomerToolStripMenuItem1
            // 
            this.createNewCustomerToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewCustomerToolStripMenuItem1.Name = "createNewCustomerToolStripMenuItem1";
            this.createNewCustomerToolStripMenuItem1.Size = new System.Drawing.Size(169, 24);
            this.createNewCustomerToolStripMenuItem1.Text = "Create New Customer";
            this.createNewCustomerToolStripMenuItem1.Click += new System.EventHandler(this.createNewCustomerToolStripMenuItem1_Click);
            // 
            // newBookingToolStripMenuItem
            // 
            this.newBookingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBookingToolStripMenuItem.Name = "newBookingToolStripMenuItem";
            this.newBookingToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.newBookingToolStripMenuItem.Text = "Booking Search";
            this.newBookingToolStripMenuItem.Click += new System.EventHandler(this.newBookingToolStripMenuItem_Click);
            // 
            // createNewBookingToolStripMenuItem1
            // 
            this.createNewBookingToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewBookingToolStripMenuItem1.Name = "createNewBookingToolStripMenuItem1";
            this.createNewBookingToolStripMenuItem1.Size = new System.Drawing.Size(161, 24);
            this.createNewBookingToolStripMenuItem1.Text = "Create New Booking";
            this.createNewBookingToolStripMenuItem1.Click += new System.EventHandler(this.createNewBookingToolStripMenuItem1_Click);
            // 
            // modifyBookingToolStripMenuItem
            // 
            this.modifyBookingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeBookingToolStripMenuItem,
            this.cancelBookingToolStripMenuItem});
            this.modifyBookingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBookingToolStripMenuItem.Name = "modifyBookingToolStripMenuItem";
            this.modifyBookingToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.modifyBookingToolStripMenuItem.Text = "Modify Booking";
            // 
            // changeBookingToolStripMenuItem
            // 
            this.changeBookingToolStripMenuItem.Name = "changeBookingToolStripMenuItem";
            this.changeBookingToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.changeBookingToolStripMenuItem.Text = "Change Booking";
            this.changeBookingToolStripMenuItem.Click += new System.EventHandler(this.changeBookingToolStripMenuItem_Click);
            // 
            // cancelBookingToolStripMenuItem
            // 
            this.cancelBookingToolStripMenuItem.Name = "cancelBookingToolStripMenuItem";
            this.cancelBookingToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.cancelBookingToolStripMenuItem.Text = "Cancel Booking";
            this.cancelBookingToolStripMenuItem.Click += new System.EventHandler(this.cancelBookingToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.occupancyLevelReportToolStripMenuItem,
            this.reservationCancellationReportToolStripMenuItem});
            this.notificationsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.notificationsToolStripMenuItem.Text = "Get Reports";
            this.notificationsToolStripMenuItem.Click += new System.EventHandler(this.notificationsToolStripMenuItem_Click);
            // 
            // occupancyLevelReportToolStripMenuItem
            // 
            this.occupancyLevelReportToolStripMenuItem.Name = "occupancyLevelReportToolStripMenuItem";
            this.occupancyLevelReportToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.occupancyLevelReportToolStripMenuItem.Text = "Occupancy Level Report";
            this.occupancyLevelReportToolStripMenuItem.Click += new System.EventHandler(this.occupancyLevelReportToolStripMenuItem_Click);
            // 
            // reservationCancellationReportToolStripMenuItem
            // 
            this.reservationCancellationReportToolStripMenuItem.Name = "reservationCancellationReportToolStripMenuItem";
            this.reservationCancellationReportToolStripMenuItem.Size = new System.Drawing.Size(297, 24);
            this.reservationCancellationReportToolStripMenuItem.Text = "Reservation Cancellation Report";
            this.reservationCancellationReportToolStripMenuItem.Click += new System.EventHandler(this.reservationCancellationReportToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(787, 407);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(787, 455);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MDIParent1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingBindingSource)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private BookingsDatabaseDataSet bookingsDatabaseDataSet;
        private System.Windows.Forms.BindingSource bookingBindingSource;
        private BookingsDatabaseDataSetTableAdapters.BookingTableAdapter bookingTableAdapter;
        private BookingsDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem customerSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelBookingToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem occupancyLevelReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewCustomerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reservationCancellationReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewBookingToolStripMenuItem1;
    }
}



