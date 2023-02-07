using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Accounts
{
    public static class CustomMessageBox
    {
        public static DialogResult Show(string Text, string Title, eDialogButtons Buttons, Image Image, string Sound)
        {
            FormMessageBox message = new FormMessageBox
            {
                Text = Title
            };

            message.PicImage.Image = Image;
            message.LabelText.Text = Text;

            switch (Sound)
            {
                case "Error":
                    SystemSounds.Hand.Play();
                    break;
                case "Info":
                    SystemSounds.Exclamation.Play();
                    break;
                default:
                    break;
            }

            switch (Buttons)
            {
                case eDialogButtons.OK:
                    message.ButtonYes.Visible = false;
                    message.ButtonNo.Visible = false;
                    message.ButtonCancel.Visible = false;
                    message.ButtonOK.Location = message.ButtonCancel.Location;
                    break;
                case eDialogButtons.OKCancel:
                    message.ButtonYes.Visible = false;
                    message.ButtonNo.Visible = false;
                    break;
                case eDialogButtons.YesNo:
                    message.ButtonOK.Visible = false;
                    message.ButtonCancel.Visible = false;
                    message.ButtonYes.Location = message.ButtonOK.Location;
                    message.ButtonNo.Location = message.ButtonCancel.Location;
                    break;
                case eDialogButtons.YesNoCancel:
                    message.ButtonOK.Visible = false;
                    break;
                case eDialogButtons.ContinueCancel:
                    message.ButtonOK.Text = "Продолжить";
                    message.LabelText.Location = new Point(69, 25);
                    message.ButtonYes.Visible = false;
                    message.ButtonNo.Visible = false;
                    break;
            }

            if (message.LabelText.Height > 64)
                message.Height = (message.LabelText.Top + message.LabelText.Height) + 88;

            return message.ShowDialog();
        }

        public enum eDialogButtons
        {
            OK,
            OKCancel,
            YesNo,
            YesNoCancel,
            ContinueCancel
        }
    }
}