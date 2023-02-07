using System;
using System.Windows.Forms;

namespace Accounts
{
    internal partial class FormMessageBox : Form
    {
        internal FormMessageBox()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon_programm;
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}