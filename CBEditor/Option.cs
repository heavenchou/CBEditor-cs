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

        private void btSetFont_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            SaveToSetting();
            Close();
        }

        void SaveToSetting()
        {
            Setting.FontStyle = fontDialog.Font;
        }
    }
}
