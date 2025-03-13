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
        List<Button> DownButtonList = new List<Button>();
        List<Button> RightButtonList = new List<Button>();
        List<Button> LeftButtonList = new List<Button>();
        public string sContinueSign = "";
        public MainForm()
        {
            SetupLanguage = Properties.Settings.Default.Language;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(SetupLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(SetupLanguage);
            InitializeComponent();
            NewRichText();
            optionForm.mainForm = this;
            Setting.FirstLoad();        // 讀取設定
            Setting.LoadFromFile();     // 讀取設定
            ChangeWindows();
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
            Setting.MainDownPanelHeight = panelDown.Height;
            Setting.MainRightPanelWidth = panelRight.Width;
            Setting.MainLeftPanelWidth = panelLeft.Width;

            Setting.LastSave();
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

        // 更新設定內容
        public void ChangeSetting()
        { 
            LoadDownButton();        // 載入下方（單次）的按鈕
            LoadRightButton();       // 載入右方連續的按鈕
            LoadLeftButton();        // 載入左方連續的按鈕

            childForm.ChangeSetting();
        }

        // 變更視窗畫面
        public void ChangeWindows()
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
            if(Setting.MainDownPanelHeight != 0) {
                panelDown.Height = Setting.MainDownPanelHeight;
            }
            if(Setting.MainRightPanelWidth != 0) {
                panelRight.Width = Setting.MainRightPanelWidth;
            }
            if (Setting.MainLeftPanelWidth != 0) {
                panelLeft.Width = Setting.MainLeftPanelWidth;
            }
        }

        // 載入下方（單次）的按鈕
        void LoadDownButton()
        {
            foreach(var button in DownButtonList) {
                button.Dispose();
            }
            DownButtonList.Clear();
            //for(int i = Setting.DownList.Count; i > 0; i--) {
            for(int i = 0; i < Setting.DownList.Count; i++) {
                Button button = new Button();
                button.Text = Setting.DownList[i];
                button.Parent = panelDown;
                button.Dock = DockStyle.Right;
                //button.AutoSize = true;
                button.Font = new System.Drawing.Font(button.Font.Name, Setting.ButtonFontSize);
                button.Width = TextRenderer.MeasureText(button.Text, button.Font).Width + 10;
                //button.Click += CheckButtonClick;
                //button.MouseDown += CheckButtonClick;

                if (Setting.DownIsSingle) {
                    button.Click += SingleButtonClick;
                } else {
                    button.Click += CheckButtonClick;
                }
                DownButtonList.Add(button);
            }
        }

        // 載入右方（連續）的按鈕
        void LoadRightButton()
        {
            foreach(var button in RightButtonList) {
                button.Dispose();
            }
            RightButtonList.Clear();
            for(int i = Setting.RightList.Count; i > 0; i--) {
                Button button = new Button();
                button.Text = Setting.RightList[i - 1];
                button.Parent = panelRight;
                button.Dock = DockStyle.Top;
                button.AutoSize = true;
                button.Font = new System.Drawing.Font(button.Font.Name, Setting.ButtonFontSize);
                //button.Click += CheckButtonClick;

                if (Setting.RightIsSingle) {
                    button.Click += SingleButtonClick;
                } else {
                    button.Click += CheckButtonClick;
                }

                //button.MouseDown += CheckButtonClick;
                RightButtonList.Add(button);
            }
        }

        // 載入左方（連續）的按鈕
        void LoadLeftButton()
        {
            foreach (var button in LeftButtonList) {
                button.Dispose();
            }
            LeftButtonList.Clear();
            for (int i = Setting.LeftList.Count; i > 0; i--) {
                Button button = new Button();
                button.Text = Setting.LeftList[i - 1];
                button.Parent = panelLeft;
                button.Dock = DockStyle.Top;
                button.AutoSize = true;
                button.Font = new System.Drawing.Font(button.Font.Name, Setting.ButtonFontSize);
                //button.Click += CheckButtonClick;
                //button.Click += SingleButtonClick;  // 左方按鈕只能單次
                if(Setting.LeftIsSingle) {
                    button.Click += SingleButtonClick;
                } else {
                    button.Click += CheckButtonClick;
                }

                //button.MouseDown += CheckButtonClick;
                LeftButtonList.Add(button);
            }
        }

        // 檢查有沒有按下 Ctrl，以判斷要執行哪個功能
        private void CheckButtonClick(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control) {
                SingleButtonClick(sender, e);
            } else {
                ContinueButtonClick(sender, e);
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

            // 如果有按下 alt , 則是用取代模式, 所選的文字都被取代.
            // 如果沒有選, 則是第一個字被取代
            // ps. 後來改成若有選擇文字, 沒有文字被取代
            if(((ModifierKeys & Keys.Alt) == Keys.Alt) || (sStart == "del" && sEnd == "")) {
                if(childForm.RichText.SelectionLength == 0) {
                    childForm.RichText.SelectionLength = 1;
                    childForm.RichText.SelectedText = "";
                }
            }

            if(sStart == "del" && sEnd == "") {
                sStart = "";
            }

            childForm.RichText.SelectedText = sStart + childForm.RichText.SelectedText + sEnd;
            childForm.RichText.Focus();
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
            childForm.RichText.Focus();
        }
        private void UnColorAllButton()
        {
            foreach(Button button in RightButtonList) {
                button.BackColor = Color.Transparent;
            }
            foreach(Button button in DownButtonList) {
                button.BackColor = Color.Transparent;
            }
            foreach(Button button in LeftButtonList) {
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

        private void 工具TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionForm.LoadFromSetting();
            DialogResult result = optionForm.ShowDialog();
            if(result == DialogResult.OK) {
                ChangeSetting();
            }
        }

        private void 關閉toolStripMenuItem_Click(object sender, EventArgs e)
        {
            childForm.OpenNewFile();
        }

        private void 關閉ToolStripButton_Click(object sender, EventArgs e)
        {
            childForm.OpenNewFile();
        }
    }
}
