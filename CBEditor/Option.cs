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
            rbMouseLeft.Checked = Setting.ContinueButtonIsLeft;
            rbMouseRight.Checked = !rbMouseLeft.Checked;

            btSetForeColor.BackColor = Setting.ForeColor;
            btSetBackColor.BackColor = Setting.BackColor;
            fontDialog.Font = Setting.Font;

            lbSingleList.Items.Clear();
            foreach(var item in Setting.SingleList) {
                lbSingleList.Items.Add(item);
            }

            lbContinueList.Items.Clear();
            foreach(var item in Setting.ContinueList) {
                lbContinueList.Items.Add(item);
            }
        }

        void SaveToSetting()
        {
            // 持續性按鈕是左鍵嗎？
            Setting.ContinueButtonIsLeft = rbMouseLeft.Checked;

            Setting.ForeColor = btSetForeColor.BackColor;
            Setting.BackColor = btSetBackColor.BackColor;
            Setting.Font = fontDialog.Font;

            // 儲存單次標點
            Setting.SingleList.Clear();
            foreach(var item in lbSingleList.Items) {
                Setting.SingleList.Add(item.ToString());
            }
            // 儲存連續標點
            Setting.ContinueList.Clear();
            foreach(var item in lbContinueList.Items) {
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
        private void btSingleAdd_Click(object sender, EventArgs e)
        {
            if(tbSingleStart.Text != "") {
                string s = tbSingleStart.Text;
                if(tbSingleEnd.Text != "") {
                    s += " ... " + tbSingleEnd.Text;
                }
                lbSingleList.Items.Add(s);
            }
        }

        // 連續標點新增一筆

        private void btContinueAdd_Click(object sender, EventArgs e)
        {
            if(tbContinueStart.Text != "") {
                string s = tbContinueStart.Text;
                if(tbContinueEnd.Text != "") {
                    s += " ... " + tbContinueEnd.Text;
                }
                lbContinueList.Items.Add(s);
            }
        }

        // 刪除一筆
        private void btSingleDel_Click(object sender, EventArgs e)
        {
            int index = lbSingleList.SelectedIndex;
            if(index != -1) {
                lbSingleList.Items.RemoveAt(index);
                if(lbSingleList.Items.Count > 0) {
                    if(index < lbSingleList.Items.Count) {
                        lbSingleList.SelectedIndex = index;
                    } else {
                        lbSingleList.SelectedIndex = index - 1;
                    }
                }
            }
        }
        private void btContinueDel_Click(object sender, EventArgs e)
        {
            int index = lbContinueList.SelectedIndex;
            if(index != -1) {
                lbContinueList.Items.RemoveAt(index);
                if(lbContinueList.Items.Count > 0) {
                    if(index < lbContinueList.Items.Count) {
                        lbContinueList.SelectedIndex = index;
                    } else {
                        lbContinueList.SelectedIndex = index - 1;
                    }
                }
            }
        }

        // 上移一筆
        private void btSingleUp_Click(object sender, EventArgs e)
        {
            int index = lbSingleList.SelectedIndex;
            if(index > 0) {
                var item = lbSingleList.Items[index];
                lbSingleList.Items[index] = lbSingleList.Items[index - 1];
                lbSingleList.Items[index-1] = item;
                lbSingleList.SelectedIndex = index - 1;
            }
        }
        private void btContinueUp_Click(object sender, EventArgs e)
        {
            int index = lbContinueList.SelectedIndex;
            if(index > 0) {
                var item = lbContinueList.Items[index];
                lbContinueList.Items[index] = lbContinueList.Items[index - 1];
                lbContinueList.Items[index - 1] = item;
                lbContinueList.SelectedIndex = index - 1;
            }

        }

        // 下移一筆
        private void btSingleDown_Click(object sender, EventArgs e)
        {
            int index = lbSingleList.SelectedIndex;
            if(index != -1 && index != lbSingleList.Items.Count - 1) {
                var item = lbSingleList.Items[index];
                lbSingleList.Items[index] = lbSingleList.Items[index + 1];
                lbSingleList.Items[index + 1] = item;
                lbSingleList.SelectedIndex = index + 1;
            }
        }

        private void btContinueDown_Click(object sender, EventArgs e)
        {
            int index = lbContinueList.SelectedIndex;
            if(index != -1 && index != lbContinueList.Items.Count - 1) {
                var item = lbContinueList.Items[index];
                lbContinueList.Items[index] = lbContinueList.Items[index + 1];
                lbContinueList.Items[index + 1] = item;
                lbContinueList.SelectedIndex = index + 1;
            }
        }

    }
}
