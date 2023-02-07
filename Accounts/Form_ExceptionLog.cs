namespace Accounts
{
    public partial class Form_ExceptionLog : System.Windows.Forms.Form
    {
        public Form_ExceptionLog()
        {
            InitializeComponent();
            Icon = Properties.Resources.icon_programm;
            TxtLog.Text = Properties.Settings.Default.ExceptionLog;
        }
    }
}