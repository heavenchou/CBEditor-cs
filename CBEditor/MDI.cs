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

namespace CBEditor
{
    public partial class MDIForm : Form
    {
        bool IsTextChanged = false;     // 文字有沒有更改過
        string FileName = "";           // 檔名
        public MainForm mainForm;

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
    }
}
