using System;
using System.IO;
using Accounts.Properties;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Accounts
{
    public partial class Form_Settings : Form
    {
        bool[] DataGridRefresh = new bool[4];
        string temp;

        public Form_Settings()
        {
            InitializeComponent();

            Icon = Resources.icon_programm;

            CheckBoxProtSite.Checked = Settings.Default.CBProtSite;
            CheckBoxProtDesc.Checked = Settings.Default.CBProtDesc;
            CheckBoxProtLogin.Checked = Settings.Default.CBProtLogin;
            CheckBoxProtPass.Checked = Settings.Default.CBProtPass;
            CheckBoxProtectPassword.Checked = Settings.Default.CBNewPass;
            ComboBoxLoadSortTable.Text = Settings.Default.SortTable;
            ComboBoxLoadSortDirection.Text = Settings.Default.SortDirection;
            TxtPathAutoLoad.Text = Settings.Default.AutoLoadFileName;

            DataGridRefresh[0] = Settings.Default.CBProtSite;
            DataGridRefresh[1] = Settings.Default.CBProtDesc;
            DataGridRefresh[2] = Settings.Default.CBProtLogin;
            DataGridRefresh[3] = Settings.Default.CBProtPass;

            try
            {
                GroupBoxChangePassword.Enabled = true;

                // Проверка на зашифрованность файла
                bool[] CryptEN = { false, false, false, false, false };

                foreach (string line in File.ReadLines(eNum.FileName))
                {
                    if (line.Contains("<NewDataSet>"))
                        CryptEN[0] = true;
                    if (line.Contains("<account>"))
                        CryptEN[1] = true;
                    if (line.Contains("<description>"))
                        CryptEN[2] = true;
                    if (line.Contains("<login>"))
                        CryptEN[3] = true;
                    if (line.Contains("<password>"))
                        CryptEN[4] = true;
                }

                if (!CryptEN[0] && !CryptEN[1] && !CryptEN[2] && !CryptEN[3] && !CryptEN[4])
                    ButtonChangePassword.Text = "Изменить";
                else
                    ButtonChangePassword.Text = "Создать";
            }
            catch
            {
                GroupBoxChangePassword.Enabled = false;
            }

            if (ButtonChangePassword.Text == "Создать")
                ButtonReset.Enabled = false;
        }

        private void ButtonChangePass_Click(object sender, EventArgs e)
        { // Кнопка - Создать/Изменить пароль
            CheckBoxProtSite.Focus();
            try
            {
                if (TxtPassword.Text != "")
                {
                    if (ButtonChangePassword.Text == "Создать")
                    {
                        string text = Encryption.EncryptStringAES(File.ReadAllText(eNum.FileName), TxtPassword.Text);
                        eNum.Password = TxtPassword.Text;
                        File.WriteAllText(eNum.FileName, text);
                        ButtonChangePassword.Text = "Изменить";
                        ButtonReset.Enabled = true;
                        TxtPassword.Text = null;
                        CustomMessageBox.Show("Файл зашифрован, пароль установлен", "Выполнено", CustomMessageBox.eDialogButtons.OK, Resources.dialogSuccess, "None");
                    }
                    else
                    {
                        string text1 = Encryption.DecryptStringAES(File.ReadAllText(eNum.FileName), eNum.Password);
                        File.WriteAllText(eNum.FileName, text1);
                        eNum.Password = TxtPassword.Text;
                        string text = Encryption.EncryptStringAES(File.ReadAllText(eNum.FileName), TxtPassword.Text);
                        File.WriteAllText(eNum.FileName, text);
                        TxtPassword.Text = null;
                        CustomMessageBox.Show("Пароль изменен", "Выполнено", CustomMessageBox.eDialogButtons.OK, Resources.dialogSuccess, "None");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ButtonChangePassword.Text == "Создать")
                    Settings.Default.ExceptionLog += "     " + DateTime.Now.ToString() + "\n     Неудачная попытка создать пароль: \n" + ex.ToString() + "\n\n\n\n";
                else
                {
                    Settings.Default.ExceptionLog += "     " + DateTime.Now.ToString() + "\n     Неудачная попытка изменить пароль: \n" + ex.ToString() + "\n\n\n\n";
                    CustomMessageBox.Show("Смотрите подробности в ExceptionLog \n\n   Программа будет перезапущена...", "Критическая ошибка", CustomMessageBox.eDialogButtons.OK, Resources.dialogRestart, "Error");
                    Application.Restart();
                }
            }
        }

        private void CheckBoxProtectPass_CheckedChanged(object sender, EventArgs e)
        { // Вкл/Выкл использования точек вместо символов
            if (CheckBoxProtectPassword.Checked)
            {
                TxtPassword.UseSystemPasswordChar = true;
                Settings.Default.CBNewPass = true;
            }
            else
            {
                TxtPassword.UseSystemPasswordChar = false;
                Settings.Default.CBNewPass = false;
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        { // Сбросить пароль
            CheckBoxProtSite.Focus();

            try
            {
                TxtPassword.Text = null;
                string text = Encryption.DecryptStringAES(File.ReadAllText(eNum.FileName), eNum.Password);
                File.WriteAllText(eNum.FileName, text);
                ButtonChangePassword.Text = "Создать";
                ButtonReset.Enabled = false;
                CustomMessageBox.Show("Пароль сброшен", "Выполнено", CustomMessageBox.eDialogButtons.OK, Resources.dialogSuccess, "None");
            }
            catch (Exception ex)
            {
                Settings.Default.ExceptionLog += "     " + DateTime.Now.ToString() + "\n     Неудачная попытка сбросить пароль: \n" + ex.ToString() + "\n\n\n\n";
                CustomMessageBox.Show("Смотрите подробности в ExceptionLog \n\n   Программа будет перезапущена...", "Критическая ошибка", CustomMessageBox.eDialogButtons.OK, Resources.dialogRestart, "Error");
                Application.Restart();
            }
        }

        private void ComboBoxLoadSortTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.SortTable = ComboBoxLoadSortTable.Text;

            if (ComboBoxLoadSortTable.Text == "Не выбрано")
            {
                ComboBoxLoadSortDirection.Enabled = false;
                ComboBoxLoadSortDirection.Text = null;
            }
            else
            {
                ComboBoxLoadSortDirection.Enabled = true;
                if (temp == "Не выбрано")
                    ComboBoxLoadSortDirection.SelectedIndex = 0;
            }

            temp = ComboBoxLoadSortTable.Text;
        }

        private void ComboBoxLoadSortDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.SortDirection = ComboBoxLoadSortDirection.Text;
        }

        private void CheckBoxProtSite_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxProtSite.Checked)
                Settings.Default.CBProtSite = true;
            else
                Settings.Default.CBProtSite = false;
        }

        private void CheckBoxProtDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxProtDesc.Checked)
                Settings.Default.CBProtDesc = true;
            else
                Settings.Default.CBProtDesc = false;
        }

        private void CheckBoxProtLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxProtLogin.Checked)
                Settings.Default.CBProtLogin = true;
            else
                Settings.Default.CBProtLogin = false;
        }

        private void CheckBoxProtPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxProtPass.Checked)
                Settings.Default.CBProtPass = true;
            else
                Settings.Default.CBProtPass = false;
        }

        private void Form_Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool[] DataGridRefresh1 = new bool[4];
            DataGridRefresh1[0] = Settings.Default.CBProtSite;
            DataGridRefresh1[1] = Settings.Default.CBProtDesc;
            DataGridRefresh1[2] = Settings.Default.CBProtLogin;
            DataGridRefresh1[3] = Settings.Default.CBProtPass;

            string a = null;
            string b = null;

            foreach (bool q in DataGridRefresh)
                a += q.ToString();
            foreach (bool w in DataGridRefresh1)
                b += w.ToString();

            if (a != b)
            {
                Form_Main frm1 = (Form_Main)Application.OpenForms[0];
                frm1.DataGridRefresh();
            }

            if ((TxtPathAutoLoad.Text == "" || TxtPathAutoLoad.Text == null) && (Settings.Default.AutoLoadFileName != null || Settings.Default.AutoLoadFileName != ""))
                Settings.Default.AutoLoadFileName = null;

            Settings.Default.Save();
        }

        private string FileDialog(string filter)
        {
            CheckBoxProtSite.Focus();

            OpenFileDialog load = new OpenFileDialog
            {
                Filter = filter,
                RestoreDirectory = true
            };

            if (load.ShowDialog() == DialogResult.OK)
                return load.FileName;
            return null;
        }

        private void ButtonSetPath_Click(object sender, EventArgs e)
        {
            TxtPathAutoLoad.Text = FileDialog("TABL (*.tabl)|*.tabl");
            Settings.Default.AutoLoadFileName = TxtPathAutoLoad.Text;
        }

        private void ButtonExceptionLog_Click(object sender, EventArgs e)
        {
            CheckBoxProtSite.Focus();
            new Form_ExceptionLog().ShowDialog();
        }

        private void ButtonClearLog_Click(object sender, EventArgs e)
        {
            Settings.Default.ExceptionLog = null;
        }

        private void ButtonRegStart_Click(object sender, EventArgs e)
        {
            if (RButtonRegInstall.Checked)
            {
                // Создаем ключи в реестре для нового типа файлов .tabl
                RegistryKey classes_key = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true);

                RegistryKey ext_key = classes_key.CreateSubKey(".tabl", RegistryKeyPermissionCheck.ReadWriteSubTree);
                ext_key.SetValue(null, "tabl_file");

                RegistryKey file_key = classes_key.CreateSubKey(ext_key.GetValue(null).ToString(), RegistryKeyPermissionCheck.ReadWriteSubTree);
                file_key.SetValue(null, "Table file Accounts");

                RegistryKey icon_key = file_key.CreateSubKey("DefaultIcon", RegistryKeyPermissionCheck.ReadWriteSubTree);
                icon_key.SetValue(null, string.Format("\"{0}\",0", TxtRegPathIcon.Text));

                RegistryKey run_key = file_key.CreateSubKey(@"Shell\Open\Command", RegistryKeyPermissionCheck.ReadWriteSubTree);
                run_key.SetValue(null, string.Format("{0} %1", Environment.CurrentDirectory + "\\Accounts.exe"));

                CustomMessageBox.Show("Новые ветки реестра успешно добавлены", "Выполнено", CustomMessageBox.eDialogButtons.OK, Resources.dialogSuccess, "None");
            }
            else if (RButtonRegDelete.Checked)
            {
                if (Registry.ClassesRoot.OpenSubKey(".tabl") != null)
                    Registry.ClassesRoot.DeleteSubKeyTree(".tabl");

                if (Registry.ClassesRoot.OpenSubKey("tabl_file") != null)
                    Registry.ClassesRoot.DeleteSubKeyTree("tabl_file");

                CustomMessageBox.Show("Ветки реестра успешно удалены", "Выполнено", CustomMessageBox.eDialogButtons.OK, Resources.dialogSuccess, "None");
            }
        }

        private void RButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RButtonRegInstall.Checked)
            {
                RButtonRegDelete.Checked = false;
                TxtRegPathIcon.Enabled = true;
                ButtonRegSetPath.Enabled = true;
                ButtonRegStart.Enabled = true;
            }
            else if (RButtonRegDelete.Checked)
            {
                RButtonRegInstall.Checked = false;
                TxtRegPathIcon.Enabled = false;
                ButtonRegSetPath.Enabled = false;
                ButtonRegStart.Enabled = true;
            }
        }

        private void ButtonRegSetPath_Click(object sender, EventArgs e)
        {
            TxtRegPathIcon.Text = FileDialog("Icon (*.ico)|*.ico");
        }
    }
}