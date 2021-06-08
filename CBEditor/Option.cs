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


        public void LoadFromSetting()
        {
            btSetForeColor.BackColor = Setting.ForeColor;
            btSetBackColor.BackColor = Setting.BackColor;
            fontDialog.Font = Setting.Font;
        }

        void SaveToSetting()
        {
            Setting.ForeColor = btSetForeColor.BackColor;
            Setting.BackColor = btSetBackColor.BackColor;
            Setting.Font = fontDialog.Font;
            Setting.SaveToFile();
        }


    }
}
