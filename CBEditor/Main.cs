using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBEditor
{
    public partial class MainForm : Form
    {
        string SetupLanguage;
        MDIForm childForm;
        OptionForm optionForm = new OptionForm();
        string ProgramName = "CBEditor";
        List<Button> SingleButtonList = new List<Button>();
        List<Button> ContinueButtonList = new List<Button>();
        public string sContinueSign = "";
        public MainForm()
        {
            SetupLanguage = Properties.Settings.Default.Language;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(SetupLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(SetupLanguage);
            InitializeComponent();
            NewRichText();
            optionForm.mainForm = this;
            Setting.LoadFromFile();     // 讀取設定
            ChangeSetting();            // 變更設定
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = SetupLanguage;
            Properties.Settings.Default.Save();

            Setting.MainFormLeft = Left;
            Setting.MainFormTop = Top;
            Setting.MainFormWidht = Width;
            Setting.MainFormHeight = Height;
            Setting.MainLeftPanelWidth = panelLeft.Height;
            Setting.MainRightPanelWidth = panelRight.Width;

            Setting.SaveToFile();
        }

        private void NewRichText()
        {
            childForm = new MDIForm();
            // Set the Parent Form of the Child window.
            childForm.MdiParent = this;
            childForm.mainForm = this;
            childForm.MaximizeBox = false;
            childForm.MinimizeBox = false;
            childForm.ControlBox = false;
            childForm.WindowState = FormWindowState.Maximized;
            // Display the new form.
            childForm.Show();
        }

        private void 復原UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childForm.RichTextUndo();
        }

        private void 取消復原RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childForm.RichTextRedo();
        }

        private void 開啟OToolStripButton_Click(object sender, EventArgs e)
        {
            childForm.OpenFile();
        }

        private void 儲存SToolStripButton_Click(object sender, EventArgs e)
        {
            childForm.SaveFile();
        }

        private void 新增NToolStripButton_Click(object sender, EventArgs e)
        {
            childForm.OpenNewFile();
        }

        private void 新增NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childForm.OpenNewFile();
        }

        private void 開啟OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childForm.OpenFile();
        }

        private void 儲存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childForm.SaveFile();
        }

        private void 另存新檔AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childForm.SaveAsFile();
        }

        private void 剪下UToolStripButton_Click(object sender, EventArgs e)
        {
            childForm.RichTextCut();
        }

        private void 複製CToolStripButton_Click(object sender, EventArgs e)
        {
            childForm.RichTextCopy();
        }

        private void 貼上PToolStripButton_Click(object sender, EventArgs e)
        {
            childForm.RichTextPaste();
        }

        private void 剪下TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            剪下UToolStripButton_Click(sender, e);
        }

        private void 複製CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            複製CToolStripButton_Click(sender, e);
        }

        private void 貼上PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            貼上PToolStripButton_Click(sender, e);
        }

        private void 全選AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tbFindText.Focused) {
                tbFindText.SelectAll();
            } else {
                childForm.RichTextSelectAll();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // 只是為了讓子視窗正確卡在它的位置
            Width += 1;
            Width -= 1;
        }

        private void 選項OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionForm.LoadFromSetting();
            DialogResult result = optionForm.ShowDialog();
            if(result == DialogResult.OK) {
                ChangeSetting();
            }

        }

        // 更新設定內容
        public void ChangeSetting()
        {
            if(Setting.MainFormLeft != -1) {
                Left = Setting.MainFormLeft;
            }
            if(Setting.MainFormTop != -1) {
                Top = Setting.MainFormTop;
            }
            if(Setting.MainFormWidht != 0) {
                Width = Setting.MainFormWidht;
            }
            if(Setting.MainFormHeight != 0) {
                Height = Setting.MainFormHeight;
            }
            if(Setting.MainLeftPanelWidth != 0) {
                panelLeft.Height = Setting.MainLeftPanelWidth;
            }
            if(Setting.MainRightPanelWidth != 0) {
                panelRight.Width = Setting.MainRightPanelWidth;
            }

            LoadSingleButton();         // 載入單次的按鈕
            LoadContinueButton();       // 載入連續的按鈕
            
            childForm.ChangeSetting();
        }

        // 載入單次的按鈕
        void LoadSingleButton()
        {
            foreach(var button in SingleButtonList) {
                button.Dispose();
            }
            SingleButtonList.Clear();
            //for(int i = Setting.SingleList.Count; i > 0; i--) {
            for(int i = 0; i < Setting.SingleList.Count; i++) {
                Button button = new Button();
                button.Text = Setting.SingleList[i];
                button.Parent = panelLeft;
                button.Dock = DockStyle.Right;
                button.AutoSize = true;
                button.Click += CheckButtonClick;
                //button.MouseDown += CheckButtonClick;
                SingleButtonList.Add(button);
            }
        }

        // 載入連續的按鈕
        void LoadContinueButton()
        {
            foreach(var button in ContinueButtonList) {
                button.Dispose();
            }
            ContinueButtonList.Clear();
            for(int i = Setting.ContinueList.Count; i > 0; i--) {
                Button button = new Button();
                button.Text = Setting.ContinueList[i - 1];
                button.Parent = panelRight;
                button.Dock = DockStyle.Top;
                button.AutoSize = true;
                button.Click += CheckButtonClick;
                //button.MouseDown += CheckButtonClick;
                ContinueButtonList.Add(button);
            }

            // 第一個一定是 none 的按鈕，取消連續用的
            /*
            Button button9 = new Button();
            button9.Text = "取消連續";
            button9.Parent = panelRight;
            button9.Dock = DockStyle.Top;
            button9.AutoSize = true;
            button9.Click += ContinueButtonClick;
            ContinueButtonList.Add(button9);
            */
        }

        private void CheckButtonClick(object sender, EventArgs e)
        {
            if((ModifierKeys & Keys.Control) == Keys.Control) {
                SingleButtonClick(sender, e);
            } else {
                ContinueButtonClick(sender, e);
            }
        }
        private void CheckButtonClick2(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) {
                if(Setting.ContinueButtonIsLeft) {
                    ContinueButtonClick(sender, e);
                } else {
                    SingleButtonClick(sender, e);
                }
            } else {
                if(Setting.ContinueButtonIsLeft) {
                    SingleButtonClick(sender, e);
                } else {
                    ContinueButtonClick(sender, e);
                }
            }
        }

        private void SingleButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string sStart = button.Text;
            string sEnd = "";

            int iPos = sStart.IndexOf(" ... ");
            if(iPos >= 0) {
                sEnd = sStart.Substring(iPos + 5);
                sStart = sStart.Substring(0, iPos);
            }

            childForm.RichText.SelectedText = sStart + childForm.RichText.SelectedText + sEnd;
        }
        private void ContinueButtonClick(object sender, EventArgs e)
        {
            UnColorAllButton(); // 取消所有 Button 背景色

            Button button = (Button)sender;
            
            if(sContinueSign == button.Text) {
                // 按原來的按鈕, 所以取消
                lbContinueSignText.Text = "連續標點：";
                sContinueSign = "";
            } else {
                lbContinueSignText.Text = "連續標點：" + button.Text;
                sContinueSign = button.Text;
                button.BackColor = Color.Yellow;
            }
        }
        private void UnColorAllButton()
        {
            foreach(Button button in ContinueButtonList) {
                button.BackColor = Color.Transparent;
            }
            foreach(Button button in SingleButtonList) {
                button.BackColor = Color.Transparent;
            }
        }

        private void 結束XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 搜尋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbFindText.Focus();
            tbFindText.SelectAll();
        }

        // 找下一筆
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(tbFindText.Text == "") {
                MessageBox.Show("請輸入搜尋字串", "CBEditor");
                tbFindText.Focus();
                return;
            }
            int selectStart = childForm.RichText.SelectionStart + childForm.RichText.SelectedText.Length;

            int iPos = childForm.RichText.Find(tbFindText.Text, selectStart, RichTextBoxFinds.None);

            if(iPos == -1) {
                if(selectStart == 0) {
                    MessageBox.Show("找不到符合的字串", "真的找不到");
                } else {
                    DialogResult res = MessageBox.Show("找不到符合的字串，要從文件開頭尋找嗎？", "尋找下一個", MessageBoxButtons.YesNo);
                    if(res == DialogResult.Yes) {
                        childForm.RichText.SelectionStart = 0;
                        childForm.RichText.SelectionLength = 0;
                        toolStripButton1_Click(this, e);
                    }
                }
            }
        }
        // 找上一筆
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(tbFindText.Text == "") {
                MessageBox.Show("請輸入搜尋字串", "CBEditor");
                tbFindText.Focus();
                return;
            }
            int selectStart = childForm.RichText.SelectionStart; // + childForm.RichText.SelectedText.Length;

            int iPos = childForm.RichText.Find(tbFindText.Text, 0, selectStart, RichTextBoxFinds.Reverse);

            if(iPos == -1) {
                if(selectStart == 0) {
                    MessageBox.Show("找不到符合的字串","真的找不到");
                } else {
                    DialogResult res = MessageBox.Show("找不到符合的字串，要從文件結尾尋找嗎？", "尋找下一個", MessageBoxButtons.YesNo);
                    if(res == DialogResult.Yes) {
                        childForm.RichText.SelectionStart = 0;
                        childForm.RichText.SelectionLength = 0;
                        toolStripButton2_Click(this, e);
                    }
                }
            }
        }

        private void tbFindText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) {
                childForm.RichText.Focus();
                toolStripButton1_Click(this, e);
            }
        }

        private void 尋找下一筆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childForm.RichText.Focus();
            toolStripButton1_Click(this, e);
        }

        private void 尋找上一筆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childForm.RichText.Focus();
            toolStripButton2_Click(this, e);
        }

        private void 關於AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ver = typeof(MainForm).Assembly.GetName().Version.ToString();

            // 在標題加入版本號前二位，即後面的 .0.0 不要了。
            ver = "v" + ver.Replace(".0.0", "");
            MessageBox.Show("CBETA 標點編輯程式 " + ver, "CBEditor");
        }

        private void 按鈕說明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        private void 說明LToolStripButton_Click(object sender, EventArgs e)
        {
            按鈕說明ToolStripMenuItem_Click( sender,  e);
        }

        private void tsbUndo_Click(object sender, EventArgs e)
        {
            childForm.RichTextUndo();
        }

        private void tsbRedo_Click(object sender, EventArgs e)
        {
            childForm.RichTextRedo();
        }
    }
}
