using System;
using System.IO;
using Accounts.Properties;
using System.Windows.Forms;

namespace Accounts
{
    public partial class Form_Login : Form
    {
        public bool EnableLoad = false;

        public Form_Login()
        {
            InitializeComponent();
            Icon = Resources.icon_programm;
            CheckBoxPass.Checked = Settings.Default.CBPassLoad;
            TxtPass.UseSystemPasswordChar = CheckBoxPass.Checked;
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                try
                {
                    Encryption.DecryptStringAES(File.ReadAllText(eNum.FileName), TxtPass.Text);
                    eNum.Password = TxtPass.Text;
                    EnableLoad = true;
                    Close();
                }
                catch
                {
                    CustomMessageBox.Show("Введен неверный пароль, повторите попытку", "Ошибка", CustomMessageBox.eDialogButtons.OK, Resources.dialogWarning, "Info");
                    TxtPass.Text = null;
                }
        }

        private void CheckBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            TxtPass.Focus();

            if (CheckBoxPass.Checked)
            {
                TxtPass.UseSystemPasswordChar = true;
                Settings.Default.CBPassLoad = true;
            }
            else
            {
                TxtPass.UseSystemPasswordChar = false;
                Settings.Default.CBPassLoad = false;
            }

            Settings.Default.Save();
        }
    }
}