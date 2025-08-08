using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CBEditor
{
    public partial class MDIForm : Form
    {
        // RichEdit 設定
        const int EM_SETOPTIONS = 0x044D;      // WM_USER + 77
        const int ECOOP_AND = 0x0003;
        const int ECO_AUTOWORDSELECTION = 0x00000001;

        bool IsTextChanged = false;     // 文字有沒有更改過
        string FileName = "";           // 檔名
        string BackupFileName = "";     // 備份檔名
        public MainForm mainForm;

        const int WM_USER = 0x400;
        const int EM_GETSCROLLPOS = WM_USER + 221;
        const int EM_SETSCROLLPOS = WM_USER + 222;

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Point lParam);

        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        public MDIForm()
        {
            InitializeComponent();
            SendMessage(
                RichText.Handle,
                EM_SETOPTIONS,
                (IntPtr)ECOOP_AND,
                (IntPtr)(~ECO_AUTOWORDSELECTION)
            );
        }
        public void RichTextUndo()
        {
            RichText.Undo();
        }
        public void RichTextRedo()
        {
            RichText.Redo();
        }

        private void RichText_TextChanged(object sender, EventArgs e)
        {
            IsTextChanged = true;
            ChangeTitle();
        }

        private void MDIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 先判斷檔案有沒有修改
            if(!FileClose()) {
                e.Cancel = true;
            }
        }

        bool FileClose()
        {
            // 先判斷檔案有沒有修改
            if(IsTextChanged) {
                // 詢問是否存檔
                DialogResult result = MessageBox.Show("是否儲存檔案？", "CBEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result == DialogResult.No) {
                    // 不存檔
                    RemoveBackupFile();
                    SetFileLastPos(FileName, -1);
                } else if(result == DialogResult.Cancel) {
                    // 不關閉
                    return false;
                } else if(result == DialogResult.Yes) {
                    // 要存檔
                    if(!SaveFile()) {
                        return false;
                    }
                    SetFileLastPos(FileName, RichText.SelectionStart);
                }
            } else {
                SetFileLastPos(FileName, RichText.SelectionStart);
            }

            return true;
        }


        public void SetFileLastPos(string sFile, int iPos)
        {
            if(sFile == "") {
                return;
            }

            int index = Setting.OpenFileName.FindIndex(x => x == sFile);
            if(index != -1) {
                if(iPos == -1) {
                    iPos = Setting.OpenFilePos[index];
                }
                Setting.OpenFileName.RemoveAt(index);
                Setting.OpenFilePos.RemoveAt(index);
            } else {
                if(iPos == -1) {
                    iPos = 0;
                }
            }

            Setting.OpenFileName.Insert(0, sFile);
            Setting.OpenFilePos.Insert(0, iPos);
        }


        public bool SaveFile()
        {
            // 先判斷檔案有沒有修改
            if(IsTextChanged) {
                if(FileName != "") {
                    SaveFileUtf8(FileName);
                } else {
                    if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                        FileName = saveFileDialog.FileName;
                        SaveFileUtf8(FileName);
                    } else {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool SaveAsFile()
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                // 若有舊的備份也要刪掉
                RemoveBackupFile();
                FileName = saveFileDialog.FileName;
                SaveFileUtf8(FileName);
            } else {
                return false;
            }
            return true;
        }

        void SaveFileUtf8(string filename)
        {
            StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8);
            sw.Write(RichText.Text);
            sw.Close();
            IsTextChanged = false;
            ChangeTitle();
            RemoveBackupFile();
        }

        void OpenFileUtf8(string filename)
        {
            StreamReader sr = new StreamReader(filename, Encoding.UTF8);
            RichText.Text = sr.ReadToEnd();
            sr.Close();
            IsTextChanged = false;
            ChangeTitle();
        }

        // 開啟檔案
        public void OpenFile()
        {
            if(FileClose()) {
                DialogResult resutlt = openFileDialog.ShowDialog();
                if(resutlt == DialogResult.OK) {
                    timerBackup.Enabled = false;
                    FileName = openFileDialog.FileName;
                    OpenFileUtf8(FileName);
                    if(FindBackupFile()) {
                        // 發現有備份的檔案
                        MessageBox.Show("發現此檔案有備份檔 " + BackupFileName + "。如果備份檔較新，可將備份檔案取代本檔。按下確定後會自動關閉本程式。");
                        mainForm.Close();
                    }
                    if(Setting.AutoBackup) {
                        timerBackup.Enabled = true;
                    }
                    // 檢查是否有記錄最後結束位置
                    if(Setting.RememberLastPos) {
                        int iPos = GetFileLastPos(FileName);    // 取得檔案最後位置
                        RichText.SelectionStart = iPos;
                    }
                }
            }
        }

        // 取得檔案最後位置
        public int GetFileLastPos(string file)
        {
            int index = Setting.OpenFileName.FindIndex(x => x == file);
            if(index != -1) {
                int iPos = Setting.OpenFilePos[index];
                return iPos;
            }
            return 0;
        }

        public bool FindBackupFile()
        {
            SetBackupFileName();
            if(File.Exists(BackupFileName)) {
                return true;
            }
            return false;
        }

        public void OpenNewFile()
        {
            if(FileClose()) {
                RichText.Clear();
                IsTextChanged = false;
                FileName = "";
                ChangeTitle();
            }
        }

        public void ChangeTitle()
        {
            string title = "";
            if(FileName == "") {
                title = "未命名";
            } else {
                title = FileName;
            }

            if(IsTextChanged) {
                title += " *";
            }

            Text = title;
        }

        public void ChangeSetting()
        {
            RichText.ForeColor = Setting.ForeColor;
            RichText.BackColor = Setting.BackColor;
            if(RichText.Font != Setting.Font) {
                RichText.Font = Setting.Font;
            }
            timerBackup.Interval = Setting.BackupTime * 60000;
        }

        private void RichText_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) {
                //RichText.SelectedText = mainForm.sContinueSign + RichText.SelectedText;
            }
        }

        private void RichText_MouseUp(object sender, MouseEventArgs e)
        {
            if((ModifierKeys & Keys.Control) == Keys.Control) {
            //if(ModifierKeys == Keys.Control) {
                return;
            }

            if(e.Button == MouseButtons.Left && mainForm.sContinueSign != "") {

                string sStart = mainForm.sContinueSign;
                string sEnd = "";

                int iPos = sStart.IndexOf(" ... ");
                if(iPos >= 0) {
                    sEnd = sStart.Substring(iPos + 5);
                    sStart = sStart.Substring(0, iPos);
                }

                // 如果有按下 alt , 則是用取代模式, 所選的文字都被取代.
                // 如果沒有選, 則是第一個字被取代
                if(((ModifierKeys & Keys.Alt) == Keys.Alt) || (sStart == "del" && sEnd == "")) {
                    if(RichText.SelectionLength == 0) {
                        RichText.SelectionLength = 1;
                        RichText.SelectedText = "";
                    }
                }

                if(sStart == "del" && sEnd == "") {
                    sStart = "";
                }

                RichText.SelectedText = sStart + RichText.SelectedText + sEnd;
            }
        }

        public void RichTextCut()
        {
            RichText.Cut();
        }

        public void RichTextCopy()
        {
            RichText.Copy();
        }

        public void RichTextPaste()
        {
            RichText.Paste();
        }

        public void RichTextSelectAll()
        {
            RichText.SelectAll();
        }

        private void 全選ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichText.SelectAll();
        }

        private void 剪下ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichText.Cut();
        }

        private void 複製ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichText.Copy();
        }

        private void 貼上ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichText.Paste();
        }

        private void RichText_SelectionChanged(object sender, EventArgs e)
        {
            // 游標保持在倒數第三行
            if(!Setting.CursorKeepLast3Line) {
                return;
            }

            // 第一行座標
            Point p1 = RichText.GetPositionFromCharIndex(0);
            int index = RichText.GetFirstCharIndexFromLine(1);
            Point p2 = RichText.GetPositionFromCharIndex(index);
            int lineHeight = p2.Y - p1.Y;       // 行高
            if(lineHeight < 0) return;

            int currentIndex = RichText.GetFirstCharIndexOfCurrentLine();
            Point currentPos = RichText.GetPositionFromCharIndex(currentIndex);

            int buttomY = currentPos.Y + lineHeight * 3;
            int diffY = RichText.Height - buttomY;

            Point newP = new Point(0, 0);

            SendMessage(RichText.Handle, EM_GETSCROLLPOS, 0, ref newP);
            if(diffY < 0) {
                newP.Y -= diffY;
                SendMessage(RichText.Handle, EM_SETSCROLLPOS, 0, ref newP);
            }
        }

        // 自動備份
        private void timerBackup_Tick(object sender, EventArgs e)
        {
            if(Setting.AutoBackup == false || IsTextChanged == false) {
                return;
            }
            SetBackupFileName();
            if(BackupFileName == "") {
                return;
            }

            StreamWriter sw = new StreamWriter(BackupFileName, false, Encoding.UTF8);
            sw.Write(RichText.Text);
            sw.Close();
        }

        void SetBackupFileName()
        {
            if(FileName != "") {
                BackupFileName = FileName + ".~cbe_backup";
            }
        }

        void RemoveBackupFile()
        {
            SetBackupFileName();
            if(BackupFileName != "") {
                File.Delete(BackupFileName);
            }
        }
    }
}
