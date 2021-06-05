
namespace CBEditor
{
    partial class MDIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RichText = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // RichText
            // 
            this.RichText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichText.Location = new System.Drawing.Point(0, 0);
            this.RichText.Name = "RichText";
            this.RichText.Size = new System.Drawing.Size(591, 450);
            this.RichText.TabIndex = 0;
            this.RichText.Text = "";
            this.RichText.TextChanged += new System.EventHandler(this.RichText_TextChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "文字檔案(*.txt)|*.txt|所有檔案 (*.*)|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "文字檔案(*.txt)|*.txt|所有檔案 (*.*)|*.*";
            // 
            // MDIForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(591, 450);
            this.ControlBox = false;
            this.Controls.Add(this.RichText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MDIForm";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichText;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}