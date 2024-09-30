namespace Phumla_System
{
    partial class LogIn
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.signInButton = new System.Windows.Forms.Button();
            this.forgotPassword = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.enterPassword = new System.Windows.Forms.TextBox();
            this.enterEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orchid;
            this.label1.Location = new System.Drawing.Point(57, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Phumla Kamnandi";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.signInButton);
            this.groupBox1.Controls.Add(this.forgotPassword);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.enterPassword);
            this.groupBox1.Controls.Add(this.enterEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(93, 93);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(357, 202);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Admin Log-In";
            // 
            // signInButton
            // 
            this.signInButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.signInButton.Location = new System.Drawing.Point(166, 168);
            this.signInButton.Margin = new System.Windows.Forms.Padding(2);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(74, 30);
            this.signInButton.TabIndex = 6;
            this.signInButton.Text = "Sign in";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // forgotPassword
            // 
            this.forgotPassword.AutoSize = true;
            this.forgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotPassword.Location = new System.Drawing.Point(163, 135);
            this.forgotPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forgotPassword.Name = "forgotPassword";
            this.forgotPassword.Size = new System.Drawing.Size(106, 15);
            this.forgotPassword.TabIndex = 5;
            this.forgotPassword.TabStop = true;
            this.forgotPassword.Text = "Forgot Password?";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(166, 116);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Remember Me";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // enterPassword
            // 
            this.enterPassword.Location = new System.Drawing.Point(158, 81);
            this.enterPassword.Margin = new System.Windows.Forms.Padding(2);
            this.enterPassword.Name = "enterPassword";
            this.enterPassword.Size = new System.Drawing.Size(175, 24);
            this.enterPassword.TabIndex = 3;
            // 
            // enterEmail
            // 
            this.enterEmail.Location = new System.Drawing.Point(158, 44);
            this.enterEmail.Margin = new System.Windows.Forms.Padding(2);
            this.enterEmail.Name = "enterEmail";
            this.enterEmail.Size = new System.Drawing.Size(175, 24);
            this.enterEmail.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email";
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(575, 343);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.LinkLabel forgotPassword;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox enterPassword;
        private System.Windows.Forms.TextBox enterEmail;
    }
}