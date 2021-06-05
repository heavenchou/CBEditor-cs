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
        string ProgramName = "CBEditor";
        public MainForm()
        {
            SetupLanguage = Properties.Settings.Default.Language;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(SetupLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(SetupLanguage);
            InitializeComponent();
            NewRichText();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = SetupLanguage;
            Properties.Settings.Default.Save();
        }

        private void NewRichText()
        {
            childForm = new MDIForm();
            // Set the Parent Form of the Child window.
            childForm.MdiParent = this;
            childForm.main = this;
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // 只是為了讓子視窗正確卡在它的位置
            Width += 1;
            Width -= 1;
        }
    }
}
