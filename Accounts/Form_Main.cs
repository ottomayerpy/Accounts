using System;
using System.IO;
using System.Data;
using Accounts.Properties;
using System.Windows.Forms;
using System.ComponentModel;

namespace Accounts
{
    public partial class Form_Main : Form
    {
        bool EditRowTable = false; // Проверка изменений в таблице
        string globalargs; // Имя открытого файла не через программу
        bool EditMode = false; // Указывает включено ли редактирование таблицы

        public Form_Main(string[] args)
        {
            InitializeComponent();
            
            Icon = Resources.icon_programm;

            foreach (string a in args)
                globalargs = a;

            switch (globalargs)
            {
                case null:
                    globalargs = Settings.Default.AutoLoadFileName;
                    break;
                case "-reset":
                    Settings.Default.SortDirection = null;
                    Settings.Default.AutoLoadFileName = null;
                    Settings.Default.SortTable = "Не выбрано";
                    Settings.Default.CBProtLogin = true;
                    Settings.Default.CBPassLoad = true;
                    Settings.Default.CBProtDesc = false;
                    Settings.Default.CBProtPass = true;
                    Settings.Default.CBProtSite = false;
                    Settings.Default.CBNewPass = true;
                    return;
            }

            if (globalargs != null && globalargs != "")
                OpenFileVoid(true, true);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            switch (Settings.Default.SortTable)
            {
                case "Сайт":
                    if (Settings.Default.SortDirection == "По возрастанию")
                        Grid.Sort(Grid.Columns[0], ListSortDirection.Ascending);
                    else
                        Grid.Sort(Grid.Columns[0], ListSortDirection.Descending);
                    break;
                case "Описание":
                    if (Settings.Default.SortDirection == "По возрастанию")
                        Grid.Sort(Grid.Columns[1], ListSortDirection.Ascending);
                    else
                        Grid.Sort(Grid.Columns[1], ListSortDirection.Descending);
                    break;
                case "Логин":
                    if (Settings.Default.SortDirection == "По возрастанию")
                        Grid.Sort(Grid.Columns[2], ListSortDirection.Ascending);
                    else
                        Grid.Sort(Grid.Columns[2], ListSortDirection.Descending);
                    break;
                case "Пароль":
                    if (Settings.Default.SortDirection == "По возрастанию")
                        Grid.Sort(Grid.Columns[3], ListSortDirection.Ascending);
                    else
                        Grid.Sort(Grid.Columns[3], ListSortDirection.Descending);
                    break;
                default:
                    break;
            }
        }

        public void DataGridRefresh()
        {
            Grid.Refresh();
        }

        private string Rand()
        {
            Random rand = new Random();
            char[,] a = new char[10, 10];
            string TempName = null;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    a[i, j] = (char)rand.Next(0x61, 0x7A);
                    TempName += a[i, j];
                }
            return TempName + ".tabl";
        }

        private byte MessageSave()
        { // 0 - None     1 - Yes     2 - No     3 - Cancel
            if (EditRowTable)
                switch (CustomMessageBox.Show("Хотите сохранить изменения перед выходом?", "Обнаружены изменения в таблице", CustomMessageBox.eDialogButtons.YesNoCancel, Resources.dialogQuestion, "None"))
                {
                    case DialogResult.Yes:
                        if (TxtPathFile.Text == "" || TxtPathFile.Text == null)
                            SaveFileVoid();
                        else
                            SaveFileVoid(true);
                        return 1;
                    case DialogResult.No:
                        return 2;
                    case DialogResult.Cancel:
                        return 3;
                    default:
                        return 0;
                }
            else
                return 0;
        }

        private void OpenFileVoid(bool FastOpenFile = false, bool CloseApp = false)
        {
            try
            {
                string path = null;

                DataSet ds = new DataSet();
                bool CryptFile = false; // true - Зашифрован; false - Не зашифрован

                if (!FastOpenFile)
                {
                    OpenFileDialog load = new OpenFileDialog
                    {
                        Filter = @"TABL (*.tabl)|*.tabl",
                        RestoreDirectory = true
                    };

                    if (load.ShowDialog() == DialogResult.OK)
                        ClearTabelVoid();
                    else
                        return;

                    eNum.FileName = load.FileName;
                }
                else
                    eNum.FileName = globalargs;
                
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
                {
                    Form_Login form = new Form_Login();
                    form.ShowDialog();

                    if (!form.EnableLoad)
                    {
                        TxtPathFile.Text = null;
                        if (CloseApp)
                            Environment.Exit(0);
                        return;
                    }

                    CryptFile = true;
                }

                if (CryptFile)
                {
                    path = Path.GetTempPath() + Rand();
                    File.WriteAllText(path, Encryption.DecryptStringAES(File.ReadAllText(eNum.FileName), eNum.Password));
                    ds.ReadXml(path);
                }
                else
                    ds.ReadXml(eNum.FileName);

                foreach (DataRow item in ds.Tables["account"].Rows)
                {
                    int n = Grid.Rows.Add();
                    Grid.Rows[n].Cells[0].Value = item["website"];
                    Grid.Rows[n].Cells[1].Value = item["description"];
                    Grid.Rows[n].Cells[2].Value = item["login"];
                    Grid.Rows[n].Cells[3].Value = item["password"];
                }

                if (CryptFile)
                    File.Delete(path);

                TxtPathFile.Text = eNum.FileName;
                EditRowTable = false;
            }
            catch (Exception ex)
            {
                eNum.FileName = null;
                TxtPathFile.Text = null;

                if (ex.ToString().Contains("System.Xml.XmlException"))
                    CustomMessageBox.Show("Файл поврежден", "Ошибка", CustomMessageBox.eDialogButtons.OK, Resources.dialogError, "Error");
                else
                {
                    Settings.Default.ExceptionLog += "     " + DateTime.Now.ToString() + "\n     Неудачная попытка открыть файл: \n" + ex.ToString() + "\n\n\n\n";
                    CustomMessageBox.Show("Смотрите подробности в ExceptionLog", "Критическая ошибка", CustomMessageBox.eDialogButtons.OK, Resources.dialogError, "Error");
                }
            }
        }

        private void SaveFileVoid(bool FastSaveFile = false)
        {
            try
            {
                bool CryptFile = false;
                string file = null;
                bool ChangeEdit = false;

                if (TxtPathFile.Text != "" || TxtPathFile.Text == null)
                {
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
                        CryptFile = true;
                }

                if (EditMode)
                {
                    ChangeEditMode();
                    ChangeEdit = true;
                }

                DataSet ds = new DataSet();
                DataTable dt = new DataTable { TableName = "account" };
                dt.Columns.Add("website");
                dt.Columns.Add("description");
                dt.Columns.Add("login");
                dt.Columns.Add("password");
                ds.Tables.Add(dt);

                foreach (DataGridViewRow r in Grid.Rows)
                {
                    DataRow row = ds.Tables["account"].NewRow();
                    row["website"] = r.Cells[0].Value;
                    row["description"] = r.Cells[1].Value;
                    row["login"] = r.Cells[2].Value;
                    row["password"] = r.Cells[3].Value;
                    ds.Tables["account"].Rows.Add(row);
                }

                if (FastSaveFile)
                {
                    file = eNum.FileName;
                    ds.WriteXml(eNum.FileName);
                }

                if (!FastSaveFile)
                {
                    CryptFile = false;
                    SaveFileDialog save = new SaveFileDialog
                    {
                        Filter = @"TABL (*.tabl)|*.tabl|XML (*.xml)|*.xml",
                        RestoreDirectory = true
                    };

                    if (save.ShowDialog() != DialogResult.OK)
                        return;

                    file = save.FileName;
                    ds.WriteXml(file);
                }

                if (CryptFile)
                    File.WriteAllText(file, Encryption.EncryptStringAES(File.ReadAllText(file), eNum.Password));

                EditRowTable = false;

                if (ChangeEdit)
                    ChangeEditMode();

                CustomMessageBox.Show("Файл успешно сохранен", "Выполнено", CustomMessageBox.eDialogButtons.OK, Resources.dialogSuccess, "None");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Путь не может быть неопределенным") || ex.Message.Contains("Пустое имя пути не допускается"))
                    CustomMessageBox.Show("Путь не может быть пустым!\nИспользуйте функцию \"Сохранить как...\"", "Ошибка", CustomMessageBox.eDialogButtons.OK, Resources.dialogWarning, "Info");
                else
                {
                    Settings.Default.ExceptionLog += "     " + DateTime.Now.ToString() + "\n     Неудачная попытка сохранить файл: \n" + ex.ToString() + "\n\n\n\n";
                    CustomMessageBox.Show("Смотрите подробности в ExceptionLog", "Критическая ошибка", CustomMessageBox.eDialogButtons.OK, Resources.dialogError, "Error");
                }
            }
        }

        private void ClearTabelVoid()
        {
            if (Grid.Rows.Count > 0)
            {
                eNum.FileName = null;
                TxtPathFile.Text = null;
                Grid.Rows.Clear();
                EditRowTable = false;
            }
        }

        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            if (MessageSave() != 3)
                OpenFileVoid();
        }

        private void MenuFileClose_Click(object sender, EventArgs e)
        {
            if (MessageSave() != 3)
                ClearTabelVoid();
        }

        private void MenuFileSave_Click(object sender, EventArgs e)
        {
            SaveFileVoid(true);
        }

        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileVoid();
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            new Form_Settings().ShowDialog();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageSave() == 3)
                e.Cancel = true;
            else
                Settings.Default.Save();
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Settings.Default.CBProtSite)
                if (e.ColumnIndex == 0 && e.Value != null)
                {
                    Grid.Rows[e.RowIndex].Tag = e.Value;
                    e.Value = new string('\u25CF', e.Value.ToString().Length);
                }

            if (Settings.Default.CBProtDesc)
                if (e.ColumnIndex == 1 && e.Value != null)
                {
                    Grid.Rows[e.RowIndex].Tag = e.Value;
                    e.Value = new string('\u25CF', e.Value.ToString().Length);
                }

            if (Settings.Default.CBProtLogin)
                if (e.ColumnIndex == 2 && e.Value != null)
                {
                    Grid.Rows[e.RowIndex].Tag = e.Value;
                    e.Value = new string('\u25CF', e.Value.ToString().Length);
                }

            if (Settings.Default.CBProtPass)
                if (e.ColumnIndex == 3 && e.Value != null)
                {
                    Grid.Rows[e.RowIndex].Tag = e.Value;
                    e.Value = new string('\u25CF', e.Value.ToString().Length);
                }
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control && !EditMode)
                Grid.CellFormatting -= new DataGridViewCellFormattingEventHandler(Grid_CellFormatting);
        }

        private void Form_Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control && !EditMode)
                Grid.CellFormatting += new DataGridViewCellFormattingEventHandler(Grid_CellFormatting);
        }

        private void Grid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!EditMode && Grid.Rows.Count > 0)
            {
                Grid.CellFormatting -= new DataGridViewCellFormattingEventHandler(Grid_CellFormatting);
                Clipboard.SetDataObject(Grid.GetClipboardContent());
                Grid.CellFormatting += new DataGridViewCellFormattingEventHandler(Grid_CellFormatting);
            }
        }

        private void ChangeEditMode()
        {
            if (EditMode)
            {
                EditMode = false;
                Grid.AllowUserToAddRows = false;
                Grid.AllowUserToDeleteRows = false;
                Grid.ReadOnly = true;
                MenuEditing.Image = Resources.Edit;
            }
            else
            {
                EditMode = true;
                Grid.AllowUserToAddRows = true;
                Grid.AllowUserToDeleteRows = true;
                Grid.ReadOnly = false;
                MenuEditing.Image = Resources.EditTrue;
            }
        }

        private void MenuEditing_Click(object sender, EventArgs e)
        {
            ChangeEditMode();
            EditRowTable = true;
        }

        private void MenuFile_DropDownOpening(object sender, EventArgs e)
        {
            if (TxtPathFile.Text == null || TxtPathFile.Text == "")
            {
                MenuFileClose.Enabled = false;
                MenuFileSave.Enabled = false;
            }
            else
            {
                MenuFileClose.Enabled = true;
                MenuFileSave.Enabled = true;
            }

            MenuFileSaveAs.Enabled = Grid.Rows.Count > 0 ? true : false;
        }
    }
}