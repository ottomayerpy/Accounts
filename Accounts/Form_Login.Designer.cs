namespace Accounts
{
    partial class Form_Login
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
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.CheckBoxPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TxtPass
            // 
            this.TxtPass.Location = new System.Drawing.Point(2, 2);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(211, 20);
            this.TxtPass.TabIndex = 0;
            this.TxtPass.UseSystemPasswordChar = true;
            this.TxtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPass_KeyDown);
            // 
            // CheckBoxPass
            // 
            this.CheckBoxPass.AutoSize = true;
            this.CheckBoxPass.Location = new System.Drawing.Point(219, 5);
            this.CheckBoxPass.Name = "CheckBoxPass";
            this.CheckBoxPass.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxPass.TabIndex = 1;
            this.CheckBoxPass.UseVisualStyleBackColor = true;
            this.CheckBoxPass.CheckedChanged += new System.EventHandler(this.CheckBoxPass_CheckedChanged);
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(235, 24);
            this.Controls.Add(this.CheckBoxPass);
            this.Controls.Add(this.TxtPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.CheckBox CheckBoxPass;
    }
}