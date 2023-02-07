namespace Accounts
{
    partial class Form_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.GroupBoxAutoLoad = new System.Windows.Forms.GroupBox();
            this.TxtPathAutoLoad = new System.Windows.Forms.TextBox();
            this.ButtonSetPath = new System.Windows.Forms.Button();
            this.ButtonOpenLog = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ComboBoxLoadSortDirection = new System.Windows.Forms.ComboBox();
            this.ComboBoxLoadSortTable = new System.Windows.Forms.ComboBox();
            this.GroupBoxTextProtection = new System.Windows.Forms.GroupBox();
            this.CheckBoxProtPass = new System.Windows.Forms.CheckBox();
            this.CheckBoxProtDesc = new System.Windows.Forms.CheckBox();
            this.CheckBoxProtLogin = new System.Windows.Forms.CheckBox();
            this.CheckBoxProtSite = new System.Windows.Forms.CheckBox();
            this.GroupBoxChangePassword = new System.Windows.Forms.GroupBox();
            this.ButtonChangePassword = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.CheckBoxProtectPassword = new System.Windows.Forms.CheckBox();
            this.ButtonClearLog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RButtonRegInstall = new System.Windows.Forms.RadioButton();
            this.RButtonRegDelete = new System.Windows.Forms.RadioButton();
            this.ButtonRegStart = new System.Windows.Forms.Button();
            this.ButtonRegSetPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtRegPathIcon = new System.Windows.Forms.TextBox();
            this.GroupBoxAutoLoad.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GroupBoxTextProtection.SuspendLayout();
            this.GroupBoxChangePassword.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxAutoLoad
            // 
            this.GroupBoxAutoLoad.Controls.Add(this.TxtPathAutoLoad);
            this.GroupBoxAutoLoad.Controls.Add(this.ButtonSetPath);
            this.GroupBoxAutoLoad.Location = new System.Drawing.Point(276, 74);
            this.GroupBoxAutoLoad.Name = "GroupBoxAutoLoad";
            this.GroupBoxAutoLoad.Size = new System.Drawing.Size(267, 52);
            this.GroupBoxAutoLoad.TabIndex = 3;
            this.GroupBoxAutoLoad.TabStop = false;
            this.GroupBoxAutoLoad.Text = "Автозагрузка таблицы";
            // 
            // TxtPathAutoLoad
            // 
            this.TxtPathAutoLoad.Location = new System.Drawing.Point(6, 23);
            this.TxtPathAutoLoad.Name = "TxtPathAutoLoad";
            this.TxtPathAutoLoad.Size = new System.Drawing.Size(222, 20);
            this.TxtPathAutoLoad.TabIndex = 17;
            // 
            // ButtonSetPath
            // 
            this.ButtonSetPath.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSetPath.Image")));
            this.ButtonSetPath.Location = new System.Drawing.Point(234, 22);
            this.ButtonSetPath.Name = "ButtonSetPath";
            this.ButtonSetPath.Size = new System.Drawing.Size(27, 22);
            this.ButtonSetPath.TabIndex = 18;
            this.ButtonSetPath.UseVisualStyleBackColor = true;
            this.ButtonSetPath.Click += new System.EventHandler(this.ButtonSetPath_Click);
            // 
            // ButtonOpenLog
            // 
            this.ButtonOpenLog.Location = new System.Drawing.Point(438, 138);
            this.ButtonOpenLog.Name = "ButtonOpenLog";
            this.ButtonOpenLog.Size = new System.Drawing.Size(105, 23);
            this.ButtonOpenLog.TabIndex = 23;
            this.ButtonOpenLog.Text = "Открыть лог";
            this.ButtonOpenLog.UseVisualStyleBackColor = true;
            this.ButtonOpenLog.Click += new System.EventHandler(this.ButtonExceptionLog_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ComboBoxLoadSortDirection);
            this.groupBox3.Controls.Add(this.ComboBoxLoadSortTable);
            this.groupBox3.Location = new System.Drawing.Point(276, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Сортировка";
            // 
            // ComboBoxLoadSortDirection
            // 
            this.ComboBoxLoadSortDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxLoadSortDirection.FormattingEnabled = true;
            this.ComboBoxLoadSortDirection.Items.AddRange(new object[] {
            "По возрастанию",
            "По убыванию"});
            this.ComboBoxLoadSortDirection.Location = new System.Drawing.Point(6, 37);
            this.ComboBoxLoadSortDirection.Name = "ComboBoxLoadSortDirection";
            this.ComboBoxLoadSortDirection.Size = new System.Drawing.Size(255, 21);
            this.ComboBoxLoadSortDirection.TabIndex = 16;
            this.ComboBoxLoadSortDirection.Tag = "Этот параметр сортирует таблицу по возрастанию или убыванию.";
            this.ComboBoxLoadSortDirection.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLoadSortDirection_SelectedIndexChanged);
            // 
            // ComboBoxLoadSortTable
            // 
            this.ComboBoxLoadSortTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxLoadSortTable.FormattingEnabled = true;
            this.ComboBoxLoadSortTable.Items.AddRange(new object[] {
            "Сайт",
            "Описание",
            "Логин",
            "Пароль",
            "Не выбрано"});
            this.ComboBoxLoadSortTable.Location = new System.Drawing.Point(6, 14);
            this.ComboBoxLoadSortTable.Name = "ComboBoxLoadSortTable";
            this.ComboBoxLoadSortTable.Size = new System.Drawing.Size(255, 21);
            this.ComboBoxLoadSortTable.TabIndex = 15;
            this.ComboBoxLoadSortTable.Tag = "Этот параметр сортирует таблицу по одному из выбранных вариантов.";
            this.ComboBoxLoadSortTable.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLoadSortTable_SelectedIndexChanged);
            // 
            // GroupBoxTextProtection
            // 
            this.GroupBoxTextProtection.Controls.Add(this.CheckBoxProtPass);
            this.GroupBoxTextProtection.Controls.Add(this.CheckBoxProtDesc);
            this.GroupBoxTextProtection.Controls.Add(this.CheckBoxProtLogin);
            this.GroupBoxTextProtection.Controls.Add(this.CheckBoxProtSite);
            this.GroupBoxTextProtection.Location = new System.Drawing.Point(276, 132);
            this.GroupBoxTextProtection.Name = "GroupBoxTextProtection";
            this.GroupBoxTextProtection.Size = new System.Drawing.Size(158, 61);
            this.GroupBoxTextProtection.TabIndex = 4;
            this.GroupBoxTextProtection.TabStop = false;
            this.GroupBoxTextProtection.Text = "Защита текста";
            // 
            // CheckBoxProtPass
            // 
            this.CheckBoxProtPass.AutoSize = true;
            this.CheckBoxProtPass.Location = new System.Drawing.Point(90, 41);
            this.CheckBoxProtPass.Name = "CheckBoxProtPass";
            this.CheckBoxProtPass.Size = new System.Drawing.Size(64, 17);
            this.CheckBoxProtPass.TabIndex = 22;
            this.CheckBoxProtPass.Text = "Пароль";
            this.CheckBoxProtPass.UseVisualStyleBackColor = true;
            this.CheckBoxProtPass.CheckedChanged += new System.EventHandler(this.CheckBoxProtPass_CheckedChanged);
            // 
            // CheckBoxProtDesc
            // 
            this.CheckBoxProtDesc.AutoSize = true;
            this.CheckBoxProtDesc.Location = new System.Drawing.Point(8, 41);
            this.CheckBoxProtDesc.Name = "CheckBoxProtDesc";
            this.CheckBoxProtDesc.Size = new System.Drawing.Size(76, 17);
            this.CheckBoxProtDesc.TabIndex = 20;
            this.CheckBoxProtDesc.Text = "Описание";
            this.CheckBoxProtDesc.UseVisualStyleBackColor = true;
            this.CheckBoxProtDesc.CheckedChanged += new System.EventHandler(this.CheckBoxProtDesc_CheckedChanged);
            // 
            // CheckBoxProtLogin
            // 
            this.CheckBoxProtLogin.AutoSize = true;
            this.CheckBoxProtLogin.Location = new System.Drawing.Point(90, 19);
            this.CheckBoxProtLogin.Name = "CheckBoxProtLogin";
            this.CheckBoxProtLogin.Size = new System.Drawing.Size(57, 17);
            this.CheckBoxProtLogin.TabIndex = 21;
            this.CheckBoxProtLogin.Text = "Логин";
            this.CheckBoxProtLogin.UseVisualStyleBackColor = true;
            this.CheckBoxProtLogin.CheckedChanged += new System.EventHandler(this.CheckBoxProtLogin_CheckedChanged);
            // 
            // CheckBoxProtSite
            // 
            this.CheckBoxProtSite.AutoSize = true;
            this.CheckBoxProtSite.Location = new System.Drawing.Point(8, 19);
            this.CheckBoxProtSite.Name = "CheckBoxProtSite";
            this.CheckBoxProtSite.Size = new System.Drawing.Size(50, 17);
            this.CheckBoxProtSite.TabIndex = 19;
            this.CheckBoxProtSite.Text = "Сайт";
            this.CheckBoxProtSite.UseVisualStyleBackColor = true;
            this.CheckBoxProtSite.CheckedChanged += new System.EventHandler(this.CheckBoxProtSite_CheckedChanged);
            // 
            // GroupBoxChangePassword
            // 
            this.GroupBoxChangePassword.Controls.Add(this.ButtonChangePassword);
            this.GroupBoxChangePassword.Controls.Add(this.ButtonReset);
            this.GroupBoxChangePassword.Controls.Add(this.TxtPassword);
            this.GroupBoxChangePassword.Controls.Add(this.CheckBoxProtectPassword);
            this.GroupBoxChangePassword.Location = new System.Drawing.Point(3, 3);
            this.GroupBoxChangePassword.Name = "GroupBoxChangePassword";
            this.GroupBoxChangePassword.Size = new System.Drawing.Size(267, 79);
            this.GroupBoxChangePassword.TabIndex = 0;
            this.GroupBoxChangePassword.TabStop = false;
            this.GroupBoxChangePassword.Text = "Шифрование файла. Создание пароля.";
            // 
            // ButtonChangePassword
            // 
            this.ButtonChangePassword.Location = new System.Drawing.Point(69, 45);
            this.ButtonChangePassword.Name = "ButtonChangePassword";
            this.ButtonChangePassword.Size = new System.Drawing.Size(192, 28);
            this.ButtonChangePassword.TabIndex = 7;
            this.ButtonChangePassword.Tag = "";
            this.ButtonChangePassword.Text = "Создать/Изменить";
            this.ButtonChangePassword.UseVisualStyleBackColor = true;
            this.ButtonChangePassword.Click += new System.EventHandler(this.ButtonChangePass_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(3, 48);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(60, 23);
            this.ButtonReset.TabIndex = 8;
            this.ButtonReset.Text = "Сброс";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(6, 19);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(255, 20);
            this.TxtPassword.TabIndex = 6;
            this.TxtPassword.Tag = "";
            // 
            // CheckBoxProtectPassword
            // 
            this.CheckBoxProtectPassword.AutoSize = true;
            this.CheckBoxProtectPassword.Location = new System.Drawing.Point(210, 0);
            this.CheckBoxProtectPassword.Name = "CheckBoxProtectPassword";
            this.CheckBoxProtectPassword.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxProtectPassword.TabIndex = 9;
            this.CheckBoxProtectPassword.Tag = "";
            this.CheckBoxProtectPassword.UseVisualStyleBackColor = true;
            this.CheckBoxProtectPassword.CheckedChanged += new System.EventHandler(this.CheckBoxProtectPass_CheckedChanged);
            // 
            // ButtonClearLog
            // 
            this.ButtonClearLog.Location = new System.Drawing.Point(438, 167);
            this.ButtonClearLog.Name = "ButtonClearLog";
            this.ButtonClearLog.Size = new System.Drawing.Size(105, 23);
            this.ButtonClearLog.TabIndex = 24;
            this.ButtonClearLog.Text = "Очистить лог";
            this.ButtonClearLog.UseVisualStyleBackColor = true;
            this.ButtonClearLog.Click += new System.EventHandler(this.ButtonClearLog_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RButtonRegInstall);
            this.groupBox1.Controls.Add(this.RButtonRegDelete);
            this.groupBox1.Controls.Add(this.ButtonRegStart);
            this.groupBox1.Controls.Add(this.ButtonRegSetPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtRegPathIcon);
            this.groupBox1.Location = new System.Drawing.Point(3, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Регистрация расширения и ассоциаций";
            // 
            // RButtonRegInstall
            // 
            this.RButtonRegInstall.AutoSize = true;
            this.RButtonRegInstall.Location = new System.Drawing.Point(6, 62);
            this.RButtonRegInstall.Name = "RButtonRegInstall";
            this.RButtonRegInstall.Size = new System.Drawing.Size(139, 17);
            this.RButtonRegInstall.TabIndex = 12;
            this.RButtonRegInstall.TabStop = true;
            this.RButtonRegInstall.Text = "Установить/Обновить";
            this.RButtonRegInstall.UseVisualStyleBackColor = true;
            this.RButtonRegInstall.CheckedChanged += new System.EventHandler(this.RButton_CheckedChanged);
            // 
            // RButtonRegDelete
            // 
            this.RButtonRegDelete.AutoSize = true;
            this.RButtonRegDelete.Location = new System.Drawing.Point(6, 82);
            this.RButtonRegDelete.Name = "RButtonRegDelete";
            this.RButtonRegDelete.Size = new System.Drawing.Size(68, 17);
            this.RButtonRegDelete.TabIndex = 13;
            this.RButtonRegDelete.TabStop = true;
            this.RButtonRegDelete.Text = "Удалить";
            this.RButtonRegDelete.UseVisualStyleBackColor = true;
            this.RButtonRegDelete.CheckedChanged += new System.EventHandler(this.RButton_CheckedChanged);
            // 
            // ButtonRegStart
            // 
            this.ButtonRegStart.Enabled = false;
            this.ButtonRegStart.Location = new System.Drawing.Point(186, 76);
            this.ButtonRegStart.Name = "ButtonRegStart";
            this.ButtonRegStart.Size = new System.Drawing.Size(75, 23);
            this.ButtonRegStart.TabIndex = 14;
            this.ButtonRegStart.Text = "Выполнить";
            this.ButtonRegStart.UseVisualStyleBackColor = true;
            this.ButtonRegStart.Click += new System.EventHandler(this.ButtonRegStart_Click);
            // 
            // ButtonRegSetPath
            // 
            this.ButtonRegSetPath.Enabled = false;
            this.ButtonRegSetPath.Image = ((System.Drawing.Image)(resources.GetObject("ButtonRegSetPath.Image")));
            this.ButtonRegSetPath.Location = new System.Drawing.Point(234, 31);
            this.ButtonRegSetPath.Name = "ButtonRegSetPath";
            this.ButtonRegSetPath.Size = new System.Drawing.Size(27, 22);
            this.ButtonRegSetPath.TabIndex = 11;
            this.ButtonRegSetPath.UseVisualStyleBackColor = true;
            this.ButtonRegSetPath.Click += new System.EventHandler(this.ButtonRegSetPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Путь к иконке для файлов расширения (.tabl):";
            // 
            // TxtRegPathIcon
            // 
            this.TxtRegPathIcon.Enabled = false;
            this.TxtRegPathIcon.Location = new System.Drawing.Point(6, 32);
            this.TxtRegPathIcon.Name = "TxtRegPathIcon";
            this.TxtRegPathIcon.Size = new System.Drawing.Size(222, 20);
            this.TxtRegPathIcon.TabIndex = 10;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(547, 195);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonClearLog);
            this.Controls.Add(this.GroupBoxAutoLoad);
            this.Controls.Add(this.ButtonOpenLog);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GroupBoxTextProtection);
            this.Controls.Add(this.GroupBoxChangePassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Settings_FormClosing);
            this.GroupBoxAutoLoad.ResumeLayout(false);
            this.GroupBoxAutoLoad.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.GroupBoxTextProtection.ResumeLayout(false);
            this.GroupBoxTextProtection.PerformLayout();
            this.GroupBoxChangePassword.ResumeLayout(false);
            this.GroupBoxChangePassword.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxAutoLoad;
        private System.Windows.Forms.TextBox TxtPathAutoLoad;
        private System.Windows.Forms.Button ButtonSetPath;
        private System.Windows.Forms.Button ButtonOpenLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ComboBoxLoadSortDirection;
        private System.Windows.Forms.ComboBox ComboBoxLoadSortTable;
        private System.Windows.Forms.GroupBox GroupBoxTextProtection;
        private System.Windows.Forms.CheckBox CheckBoxProtPass;
        private System.Windows.Forms.CheckBox CheckBoxProtDesc;
        private System.Windows.Forms.CheckBox CheckBoxProtLogin;
        private System.Windows.Forms.CheckBox CheckBoxProtSite;
        private System.Windows.Forms.GroupBox GroupBoxChangePassword;
        private System.Windows.Forms.Button ButtonChangePassword;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.CheckBox CheckBoxProtectPassword;
        private System.Windows.Forms.Button ButtonClearLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RButtonRegInstall;
        private System.Windows.Forms.RadioButton RButtonRegDelete;
        private System.Windows.Forms.Button ButtonRegStart;
        private System.Windows.Forms.Button ButtonRegSetPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtRegPathIcon;
    }
}