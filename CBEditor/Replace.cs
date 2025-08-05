using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBEditor
{
    public partial class ReplaceForm : Form
    {
        public MainForm mainForm;

        public ReplaceForm()
        {
            InitializeComponent();
        }

        private void ReplaceForm_Load(object sender, EventArgs e)
        {
            // 如果主視窗有選取的文字，則預設填入搜尋框
            if (mainForm != null && mainForm.childForm != null)
            {
                string selectedText = mainForm.childForm.RichText.SelectedText;
                if (!string.IsNullOrEmpty(selectedText) && !selectedText.Contains("\n"))
                {
                    tbFindText.Text = selectedText;
                }
            }
            tbFindText.Focus();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            Replace();
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            ReplaceAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindNext()
        {
            if (string.IsNullOrEmpty(tbFindText.Text))
            {
                MessageBox.Show("請輸入搜尋字串", "CBEditor");
                tbFindText.Focus();
                return;
            }

            if (mainForm?.childForm?.RichText == null) return;

            RichTextBox richText = mainForm.childForm.RichText;
            int selectStart = richText.SelectionStart + richText.SelectedText.Length;

            RichTextBoxFinds findOptions = RichTextBoxFinds.None;
            if (cbMatchCase.Checked)
                findOptions |= RichTextBoxFinds.MatchCase;
            if (cbWholeWord.Checked)
                findOptions |= RichTextBoxFinds.WholeWord;

            int iPos = richText.Find(tbFindText.Text, selectStart, findOptions);

            if (iPos == -1)
            {
                if (selectStart == 0)
                {
                    MessageBox.Show("找不到符合的字串", "搜尋結果");
                }
                else
                {
                    DialogResult res = MessageBox.Show("找不到符合的字串，要從文件開頭尋找嗎？", "搜尋結果", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        richText.SelectionStart = 0;
                        richText.SelectionLength = 0;
                        FindNext();
                    }
                }
            }
            else
            {
                richText.Focus();
            }
        }

        private void Replace()
        {
            if (string.IsNullOrEmpty(tbFindText.Text))
            {
                MessageBox.Show("請輸入搜尋字串", "CBEditor");
                tbFindText.Focus();
                return;
            }

            if (mainForm?.childForm?.RichText == null) return;

            RichTextBox richText = mainForm.childForm.RichText;

            // 如果目前選取的文字符合搜尋條件，則取代
            if (IsCurrentSelectionMatch())
            {
                richText.SelectedText = tbReplaceText.Text;
            }

            // 尋找下一個
            FindNext();
        }

        private void ReplaceAll()
        {
            if (string.IsNullOrEmpty(tbFindText.Text))
            {
                MessageBox.Show("請輸入搜尋字串", "CBEditor");
                tbFindText.Focus();
                return;
            }

            if (mainForm?.childForm?.RichText == null) return;

            RichTextBox richText = mainForm.childForm.RichText;
            int replaceCount = 0;
            int startPos = 0;

            RichTextBoxFinds findOptions = RichTextBoxFinds.None;
            if (cbMatchCase.Checked)
                findOptions |= RichTextBoxFinds.MatchCase;
            if (cbWholeWord.Checked)
                findOptions |= RichTextBoxFinds.WholeWord;

            richText.SelectionStart = 0;
            richText.SelectionLength = 0;

            while (true)
            {
                int iPos = richText.Find(tbFindText.Text, startPos, findOptions);
                if (iPos == -1) break;

                richText.SelectionStart = iPos;
                richText.SelectionLength = tbFindText.Text.Length;
                richText.SelectedText = tbReplaceText.Text;
                
                startPos = iPos + tbReplaceText.Text.Length;
                replaceCount++;
            }

            MessageBox.Show($"已取代 {replaceCount} 個項目", "取代完成");
        }

        private bool IsCurrentSelectionMatch()
        {
            if (mainForm?.childForm?.RichText == null) return false;

            RichTextBox richText = mainForm.childForm.RichText;
            string selectedText = richText.SelectedText;

            if (string.IsNullOrEmpty(selectedText)) return false;

            string findText = tbFindText.Text;

            if (cbMatchCase.Checked)
            {
                return selectedText == findText;
            }
            else
            {
                return string.Equals(selectedText, findText, StringComparison.OrdinalIgnoreCase);
            }
        }

        private void tbFindText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindNext();
            }
        }

        private void tbReplaceText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindNext();
            }
        }
    }
}