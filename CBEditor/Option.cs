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

            cbLeftSingle.Checked = Setting.LeftIsSingle;
            cbRightSingle.Checked = Setting.RightIsSingle;
            cbDownSingle.Checked = Setting.DownIsSingle;

            lbDownList.Items.Clear();
            foreach(var item in Setting.DownList) {
                lbDownList.Items.Add(item);
            }

            lbLeftList.Items.Clear();
            foreach (var item in Setting.LeftList) {
                lbLeftList.Items.Add(item);
            }

            lbRightList.Items.Clear();
            foreach(var item in Setting.RightList) {
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

            // 儲存左方（連續）標點
            Setting.LeftList.Clear();
            foreach (var item in lbLeftList.Items) {
                Setting.LeftList.Add(item.ToString());
            }
            // 儲存下方（單次）標點
            Setting.DownList.Clear();
            foreach(var item in lbDownList.Items) {
                Setting.DownList.Add(item.ToString());
            }
            // 儲存右方（連續）標點
            Setting.RightList.Clear();
            foreach(var item in lbRightList.Items) {
                Setting.RightList.Add(item.ToString());
            }

            Setting.LeftIsSingle = cbLeftSingle.Checked;
            Setting.RightIsSingle = cbRightSingle.Checked;
            Setting.DownIsSingle = cbDownSingle.Checked;

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

        // 左方 panel 標點新增一筆

        private void btLeftAdd_Click(object sender, EventArgs e)
        {
            if (tbLeftStart.Text != "") {
                string s = tbLeftStart.Text;
                if (tbLeftEnd.Text != "") {
                    s += " ... " + tbLeftEnd.Text;
                }
                lbLeftList.Items.Add(s);
            }
        }

        // 單次標點新增一筆
        private void btDownAdd_Click(object sender, EventArgs e)
        {
            if(tbDownStart.Text != "") {
                string s = tbDownStart.Text;
                if(tbDownEnd.Text != "") {
                    s += " ... " + tbDownEnd.Text;
                }
                lbDownList.Items.Add(s);
            }
        }

        // 連續標點新增一筆

        private void btRightAdd_Click(object sender, EventArgs e)
        {
            if(tbRightStart.Text != "") {
                string s = tbRightStart.Text;
                if(tbRightEnd.Text != "") {
                    s += " ... " + tbRightEnd.Text;
                }
                lbRightList.Items.Add(s);
            }
        }


        // 刪除一筆

        private void btLeftDel_Click(object sender, EventArgs e)
        {
            int index = lbLeftList.SelectedIndex;
            if (index != -1) {
                lbLeftList.Items.RemoveAt(index);
                if (lbLeftList.Items.Count > 0) {
                    if (index < lbLeftList.Items.Count) {
                        lbLeftList.SelectedIndex = index;
                    } else {
                        lbLeftList.SelectedIndex = index - 1;
                    }
                }
            }
        }

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


        private void btLeftUp_Click(object sender, EventArgs e)
        {
            int index = lbLeftList.SelectedIndex;
            if (index > 0) {
                var item = lbLeftList.Items[index];
                lbLeftList.Items[index] = lbLeftList.Items[index - 1];
                lbLeftList.Items[index - 1] = item;
                lbLeftList.SelectedIndex = index - 1;
            }
        }

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

        private void btLeftDown_Click(object sender, EventArgs e)
        {
            int index = lbLeftList.SelectedIndex;
            if (index != -1 && index != lbLeftList.Items.Count - 1) {
                var item = lbLeftList.Items[index];
                lbLeftList.Items[index] = lbLeftList.Items[index + 1];
                lbLeftList.Items[index + 1] = item;
                lbLeftList.SelectedIndex = index + 1;
            }
        }

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

        // 移到其它 Panel
        // 左方 panel 移到下方 Panel
        private void btLeft2Down_Click(object sender, EventArgs e)
        {
            int index = lbLeftList.SelectedIndex;
            if (index != -1) {
                string s = lbLeftList.Items[index].ToString();
                lbDownList.Items.Add(s);
                btLeftDel_Click(sender, e);
            }
        }
        // 右方 panel 移到下方 Panel
        private void btRight2Down_Click(object sender, EventArgs e)
        {
            int index = lbRightList.SelectedIndex;
            if (index != -1) {
                string s = lbRightList.Items[index].ToString();
                lbDownList.Items.Add(s);
                btRightDel_Click(sender, e);
            }
        }
        // 下方 panel 移到左方 Panel
        private void btDown2Left_Click(object sender, EventArgs e)
        {
            int index = lbDownList.SelectedIndex;
            if (index != -1) {
                string s = lbDownList.Items[index].ToString();
                lbLeftList.Items.Add(s);
                btDownDel_Click(sender, e);
            }
        }
        // 下方 panel 移到右方 Panel
        private void btDown2Right_Click(object sender, EventArgs e)
        {
            int index = lbDownList.SelectedIndex;
            if(index != -1) {
                string s = lbDownList.Items[index].ToString();
                lbRightList.Items.Add(s);
                btDownDel_Click(sender, e);
            }
        }
        // 左方 panel 移到右方 Panel
        private void btLeft2Right_Click(object sender, EventArgs e)
        {
            int index = lbLeftList.SelectedIndex;
            if (index != -1) {
                string s = lbLeftList.Items[index].ToString();
                lbRightList.Items.Add(s);
                btLeftDel_Click(sender, e);
            }
        }
        // 右方 panel 移到左方 Panel
        private void btRight2Left_Click(object sender, EventArgs e)
        {
            int index = lbRightList.SelectedIndex;
            if (index != -1) {
                string s = lbRightList.Items[index].ToString();
                lbLeftList.Items.Add(s);
                btRightDel_Click(sender, e);
            }
        }
    }
}
