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
    public partial class OptionForm : Form
    {
        public MainForm mainForm;
        public OptionForm()
        {
            InitializeComponent();
        }

        public void LoadFromSetting()
        {
            // 持續性按鈕是左鍵嗎？
            //rbMouseLeft.Checked = Setting.ContinueButtonIsLeft;
            rbMouseRight.Checked = !rbMouseLeft.Checked;

            // 按鈕文字的大小
            tbButtonFontSize.Value = Setting.ButtonFontSize;

            // 游標保持在倒數第三行
            cbCursorKeepLast3Line.Checked = Setting.CursorKeepLast3Line;

            // 自動備份
            cbAutoBackup.Checked = Setting.AutoBackup;

            // 備份時間
            tbBackupTime.Value = Setting.BackupTime;

            // 記憶檔案最後開啟位置
            cbRememberLastPos.Checked = Setting.RememberLastPos;

            btSetForeColor.BackColor = Setting.ForeColor;
            btSetBackColor.BackColor = Setting.BackColor;
            fontDialog.Font = Setting.Font;

            lbDownList.Items.Clear();
            foreach(var item in Setting.SingleList) {
                lbDownList.Items.Add(item);
            }

            lbRightList.Items.Clear();
            foreach(var item in Setting.ContinueList) {
                lbRightList.Items.Add(item);
            }
        }

        void SaveToSetting()
        {
            // 持續性按鈕是左鍵嗎？
            //Setting.ContinueButtonIsLeft = rbMouseLeft.Checked;

            // 按鈕文字的大小
            Setting.ButtonFontSize = (int) tbButtonFontSize.Value;

            // 游標保持在倒數第三行
            Setting.CursorKeepLast3Line = cbCursorKeepLast3Line.Checked;

            // 自動備份
            Setting.AutoBackup = cbAutoBackup.Checked;
            // 備份時間
            Setting.BackupTime = (int) tbBackupTime.Value;
            // 記憶檔案最後開啟位置
            Setting.RememberLastPos = cbRememberLastPos.Checked;

            Setting.ForeColor = btSetForeColor.BackColor;
            Setting.BackColor = btSetBackColor.BackColor;
            Setting.Font = fontDialog.Font;

            // 儲存單次標點
            Setting.SingleList.Clear();
            foreach(var item in lbDownList.Items) {
                Setting.SingleList.Add(item.ToString());
            }
            // 儲存連續標點
            Setting.ContinueList.Clear();
            foreach(var item in lbRightList.Items) {
                Setting.ContinueList.Add(item.ToString());
            }

            Setting.SaveToFile();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            SaveToSetting();
            Close();
        }

        private void btSetFont_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
        }

        private void btSetForeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btSetForeColor.BackColor;
            DialogResult result = colorDialog.ShowDialog();
            if(result == DialogResult.OK) {
                btSetForeColor.BackColor = colorDialog.Color;
            }
        }
        private void btSetBackColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = btSetBackColor.BackColor;
            DialogResult result = colorDialog.ShowDialog();
            if(result == DialogResult.OK) {
                btSetBackColor.BackColor = colorDialog.Color;
            }
        }

        // 單次標點新增一筆
        private void btDownAdd_Click(object sender, EventArgs e)
        {
            if(tbDownStart.Text != "") {
                string s = tbDownStart.Text;
                if(tbSingleEnd.Text != "") {
                    s += " ... " + tbSingleEnd.Text;
                }
                lbDownList.Items.Add(s);
            }
        }

        // 連續標點新增一筆

        private void btRightAdd_Click(object sender, EventArgs e)
        {
            if(tbRightStart.Text != "") {
                string s = tbRightStart.Text;
                if(tbContinueEnd.Text != "") {
                    s += " ... " + tbContinueEnd.Text;
                }
                lbRightList.Items.Add(s);
            }
        }

        // 刪除一筆
        private void btDownDel_Click(object sender, EventArgs e)
        {
            int index = lbDownList.SelectedIndex;
            if(index != -1) {
                lbDownList.Items.RemoveAt(index);
                if(lbDownList.Items.Count > 0) {
                    if(index < lbDownList.Items.Count) {
                        lbDownList.SelectedIndex = index;
                    } else {
                        lbDownList.SelectedIndex = index - 1;
                    }
                }
            }
        }
        private void btRightDel_Click(object sender, EventArgs e)
        {
            int index = lbRightList.SelectedIndex;
            if(index != -1) {
                lbRightList.Items.RemoveAt(index);
                if(lbRightList.Items.Count > 0) {
                    if(index < lbRightList.Items.Count) {
                        lbRightList.SelectedIndex = index;
                    } else {
                        lbRightList.SelectedIndex = index - 1;
                    }
                }
            }
        }

        // 上移一筆
        private void btDownUp_Click(object sender, EventArgs e)
        {
            int index = lbDownList.SelectedIndex;
            if(index > 0) {
                var item = lbDownList.Items[index];
                lbDownList.Items[index] = lbDownList.Items[index - 1];
                lbDownList.Items[index-1] = item;
                lbDownList.SelectedIndex = index - 1;
            }
        }
        private void btRightUp_Click(object sender, EventArgs e)
        {
            int index = lbRightList.SelectedIndex;
            if(index > 0) {
                var item = lbRightList.Items[index];
                lbRightList.Items[index] = lbRightList.Items[index - 1];
                lbRightList.Items[index - 1] = item;
                lbRightList.SelectedIndex = index - 1;
            }

        }

        // 下移一筆
        private void btDownDown_Click(object sender, EventArgs e)
        {
            int index = lbDownList.SelectedIndex;
            if(index != -1 && index != lbDownList.Items.Count - 1) {
                var item = lbDownList.Items[index];
                lbDownList.Items[index] = lbDownList.Items[index + 1];
                lbDownList.Items[index + 1] = item;
                lbDownList.SelectedIndex = index + 1;
            }
        }

        private void btRightDown_Click(object sender, EventArgs e)
        {
            int index = lbRightList.SelectedIndex;
            if(index != -1 && index != lbRightList.Items.Count - 1) {
                var item = lbRightList.Items[index];
                lbRightList.Items[index] = lbRightList.Items[index + 1];
                lbRightList.Items[index + 1] = item;
                lbRightList.SelectedIndex = index + 1;
            }
        }

        private void btDown2Right_Click(object sender, EventArgs e)
        {
            int index = lbDownList.SelectedIndex;
            if(index != -1) {
                string s = lbDownList.Items[index].ToString();
                lbRightList.Items.Add(s);
                btDownDel_Click(sender, e);
            }
        }

        private void btRight2Down_Click(object sender, EventArgs e)
        {
            int index = lbRightList.SelectedIndex;
            if(index != -1) {
                string s = lbRightList.Items[index].ToString();
                lbDownList.Items.Add(s);
                btRightDel_Click(sender, e);
            }
        }
    }
}
