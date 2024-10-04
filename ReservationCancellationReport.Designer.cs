namespace Phumla_System
{
    partial class ReservationCancellationReport
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
            this.dataGridViewCancellations = new System.Windows.Forms.DataGridView();
            this.lblTotalCancellations = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCancellations)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label1.Location = new System.Drawing.Point(254, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(650, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reservation Cancellation Report";
            // 
            // dataGridViewCancellations
            // 
            this.dataGridViewCancellations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCancellations.Location = new System.Drawing.Point(21, 103);
            this.dataGridViewCancellations.Name = "dataGridViewCancellations";
            this.dataGridViewCancellations.RowHeadersWidth = 62;
            this.dataGridViewCancellations.RowTemplate.Height = 28;
            this.dataGridViewCancellations.Size = new System.Drawing.Size(1140, 472);
            this.dataGridViewCancellations.TabIndex = 2;
            // 
            // lblTotalCancellations
            // 
            this.lblTotalCancellations.AutoSize = true;
            this.lblTotalCancellations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCancellations.Location = new System.Drawing.Point(27, 621);
            this.lblTotalCancellations.Name = "lblTotalCancellations";
            this.lblTotalCancellations.Size = new System.Drawing.Size(0, 37);
            this.lblTotalCancellations.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnRefresh.Location = new System.Drawing.Point(974, 755);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(151, 37);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // ReservationCancellationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 804);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTotalCancellations);
            this.Controls.Add(this.dataGridViewCancellations);
            this.Controls.Add(this.label1);
            this.Name = "ReservationCancellationReport";
            this.Text = "ReservationCancellationReport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCancellations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCancellations;
        private System.Windows.Forms.Label lblTotalCancellations;
        private System.Windows.Forms.Button btnRefresh;
    }
}