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
        bool IsTextChanged = false;     // 文字有沒有更改過
        string FileName = "";           // 檔名
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
                } else if(result == DialogResult.Cancel) {
                    // 不關閉
                    return false;
                } else if(result == DialogResult.Yes) {
                    // 要存檔
                    if(!SaveFile()) {
                        return false;
                    }
                }
            }
            return true;
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
                    FileName = openFileDialog.FileName;
                    OpenFileUtf8(FileName);
                }
            }
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
            RichText.Font = Setting.Font;
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
                    }
                    RichText.SelectedText = "";
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
            newP.Y -= diffY;
            SendMessage(RichText.Handle, EM_SETSCROLLPOS, 0, ref newP);
        }
    }
}
