
namespace CBEditor
{
    partial class OptionForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpNormal = new System.Windows.Forms.TabPage();
            this.cbRememberLastPos = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbBackupTime = new System.Windows.Forms.NumericUpDown();
            this.cbAutoBackup = new System.Windows.Forms.CheckBox();
            this.cbCursorKeepLast3Line = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbButtonFontSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbMouseRight = new System.Windows.Forms.RadioButton();
            this.rbMouseLeft = new System.Windows.Forms.RadioButton();
            this.btSetForeColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btSetBackColor = new System.Windows.Forms.Button();
            this.btSetFont = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tpButton = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btRight2Down = new System.Windows.Forms.Button();
            this.lbRightList = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRightEnd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRightStart = new System.Windows.Forms.TextBox();
            this.btContinueDown = new System.Windows.Forms.Button();
            this.btContinueUp = new System.Windows.Forms.Button();
            this.btContinueDel = new System.Windows.Forms.Button();
            this.btContinueAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btDown2Right = new System.Windows.Forms.Button();
            this.lbDownList = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDownStart = new System.Windows.Forms.TextBox();
            this.tbDownEnd = new System.Windows.Forms.TextBox();
            this.btSingleDown = new System.Windows.Forms.Button();
            this.btSingleUp = new System.Windows.Forms.Button();
            this.btSingleDel = new System.Windows.Forms.Button();
            this.btSingleAdd = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btLeft2Down = new System.Windows.Forms.Button();
            this.lbLeftList = new System.Windows.Forms.ListBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.tbLeftEnd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbLeftStart = new System.Windows.Forms.TextBox();
            this.btLeftDown = new System.Windows.Forms.Button();
            this.btLeftUp = new System.Windows.Forms.Button();
            this.btLeftDel = new System.Windows.Forms.Button();
            this.btLeftAdd = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btLeft2Right = new System.Windows.Forms.Button();
            this.btRight2Left = new System.Windows.Forms.Button();
            this.btDown2Left = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tpNormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBackupTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbButtonFontSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tpButton.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpNormal);
            this.tabControl.Controls.Add(this.tpButton);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(893, 451);
            this.tabControl.TabIndex = 0;
            // 
            // tpNormal
            // 
            this.tpNormal.Controls.Add(this.cbRememberLastPos);
            this.tpNormal.Controls.Add(this.label13);
            this.tpNormal.Controls.Add(this.label11);
            this.tpNormal.Controls.Add(this.tbBackupTime);
            this.tpNormal.Controls.Add(this.cbAutoBackup);
            this.tpNormal.Controls.Add(this.cbCursorKeepLast3Line);
            this.tpNormal.Controls.Add(this.label10);
            this.tpNormal.Controls.Add(this.tbButtonFontSize);
            this.tpNormal.Controls.Add(this.groupBox1);
            this.tpNormal.Controls.Add(this.btSetForeColor);
            this.tpNormal.Controls.Add(this.label2);
            this.tpNormal.Controls.Add(this.btSetBackColor);
            this.tpNormal.Controls.Add(this.btSetFont);
            this.tpNormal.Controls.Add(this.label1);
            this.tpNormal.Location = new System.Drawing.Point(4, 34);
            this.tpNormal.Name = "tpNormal";
            this.tpNormal.Padding = new System.Windows.Forms.Padding(3);
            this.tpNormal.Size = new System.Drawing.Size(879, 413);
            this.tpNormal.TabIndex = 0;
            this.tpNormal.Text = "一般";
            this.tpNormal.UseVisualStyleBackColor = true;
            // 
            // cbRememberLastPos
            // 
            this.cbRememberLastPos.AutoSize = true;
            this.cbRememberLastPos.Checked = true;
            this.cbRememberLastPos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRememberLastPos.Location = new System.Drawing.Point(310, 258);
            this.cbRememberLastPos.Name = "cbRememberLastPos";
            this.cbRememberLastPos.Size = new System.Drawing.Size(234, 29);
            this.cbRememberLastPos.TabIndex = 15;
            this.cbRememberLastPos.Text = "記憶檔案最後開啟位置";
            this.cbRememberLastPos.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(333, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 25);
            this.label13.TabIndex = 14;
            this.label13.Text = "每";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(433, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 25);
            this.label11.TabIndex = 12;
            this.label11.Text = "分鐘自動備份";
            // 
            // tbBackupTime
            // 
            this.tbBackupTime.Location = new System.Drawing.Point(371, 208);
            this.tbBackupTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbBackupTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbBackupTime.Name = "tbBackupTime";
            this.tbBackupTime.Size = new System.Drawing.Size(56, 34);
            this.tbBackupTime.TabIndex = 11;
            this.tbBackupTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // cbAutoBackup
            // 
            this.cbAutoBackup.AutoSize = true;
            this.cbAutoBackup.Checked = true;
            this.cbAutoBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoBackup.Location = new System.Drawing.Point(310, 210);
            this.cbAutoBackup.Name = "cbAutoBackup";
            this.cbAutoBackup.Size = new System.Drawing.Size(18, 17);
            this.cbAutoBackup.TabIndex = 10;
            this.cbAutoBackup.UseVisualStyleBackColor = true;
            // 
            // cbCursorKeepLast3Line
            // 
            this.cbCursorKeepLast3Line.AutoSize = true;
            this.cbCursorKeepLast3Line.Checked = true;
            this.cbCursorKeepLast3Line.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCursorKeepLast3Line.Location = new System.Drawing.Point(310, 164);
            this.cbCursorKeepLast3Line.Name = "cbCursorKeepLast3Line";
            this.cbCursorKeepLast3Line.Size = new System.Drawing.Size(234, 29);
            this.cbCursorKeepLast3Line.TabIndex = 9;
            this.cbCursorKeepLast3Line.Text = "游標保持在最後第三行";
            this.cbCursorKeepLast3Line.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(305, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "標點按鈕文字大小";
            // 
            // tbButtonFontSize
            // 
            this.tbButtonFontSize.Location = new System.Drawing.Point(310, 91);
            this.tbButtonFontSize.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.tbButtonFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.tbButtonFontSize.Name = "tbButtonFontSize";
            this.tbButtonFontSize.Size = new System.Drawing.Size(120, 34);
            this.tbButtonFontSize.TabIndex = 7;
            this.tbButtonFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.rbMouseRight);
            this.groupBox1.Controls.Add(this.rbMouseLeft);
            this.groupBox1.Location = new System.Drawing.Point(20, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 211);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "持續性標點";
            this.groupBox1.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(11, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(232, 89);
            this.label9.TabIndex = 2;
            this.label9.Text = "請選擇持續性標點是左鍵或右鍵，另一鍵則是單次標點。";
            // 
            // rbMouseRight
            // 
            this.rbMouseRight.AutoSize = true;
            this.rbMouseRight.Location = new System.Drawing.Point(13, 69);
            this.rbMouseRight.Name = "rbMouseRight";
            this.rbMouseRight.Size = new System.Drawing.Size(113, 29);
            this.rbMouseRight.TabIndex = 1;
            this.rbMouseRight.Text = "滑鼠右鍵";
            this.rbMouseRight.UseVisualStyleBackColor = true;
            // 
            // rbMouseLeft
            // 
            this.rbMouseLeft.AutoSize = true;
            this.rbMouseLeft.Checked = true;
            this.rbMouseLeft.Location = new System.Drawing.Point(13, 34);
            this.rbMouseLeft.Name = "rbMouseLeft";
            this.rbMouseLeft.Size = new System.Drawing.Size(113, 29);
            this.rbMouseLeft.TabIndex = 0;
            this.rbMouseLeft.TabStop = true;
            this.rbMouseLeft.Text = "滑鼠左鍵";
            this.rbMouseLeft.UseVisualStyleBackColor = true;
            // 
            // btSetForeColor
            // 
            this.btSetForeColor.BackColor = System.Drawing.Color.Black;
            this.btSetForeColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSetForeColor.Location = new System.Drawing.Point(129, 46);
            this.btSetForeColor.Name = "btSetForeColor";
            this.btSetForeColor.Size = new System.Drawing.Size(118, 40);
            this.btSetForeColor.TabIndex = 5;
            this.btSetForeColor.UseVisualStyleBackColor = false;
            this.btSetForeColor.Click += new System.EventHandler(this.btSetForeColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "前景色";
            // 
            // btSetBackColor
            // 
            this.btSetBackColor.BackColor = System.Drawing.Color.White;
            this.btSetBackColor.Location = new System.Drawing.Point(129, 92);
            this.btSetBackColor.Name = "btSetBackColor";
            this.btSetBackColor.Size = new System.Drawing.Size(118, 40);
            this.btSetBackColor.TabIndex = 3;
            this.btSetBackColor.UseVisualStyleBackColor = false;
            this.btSetBackColor.Click += new System.EventHandler(this.btSetBackColor_Click);
            // 
            // btSetFont
            // 
            this.btSetFont.Location = new System.Drawing.Point(56, 164);
            this.btSetFont.Name = "btSetFont";
            this.btSetFont.Size = new System.Drawing.Size(118, 40);
            this.btSetFont.TabIndex = 2;
            this.btSetFont.Text = "設定字型";
            this.btSetFont.UseVisualStyleBackColor = true;
            this.btSetFont.Click += new System.EventHandler(this.btSetFont_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "背景色";
            // 
            // tpButton
            // 
            this.tpButton.Controls.Add(this.panel2);
            this.tpButton.Controls.Add(this.panel1);
            this.tpButton.Controls.Add(this.panel6);
            this.tpButton.Location = new System.Drawing.Point(4, 34);
            this.tpButton.Name = "tpButton";
            this.tpButton.Padding = new System.Windows.Forms.Padding(3);
            this.tpButton.Size = new System.Drawing.Size(885, 413);
            this.tpButton.TabIndex = 1;
            this.tpButton.Text = "按鍵";
            this.tpButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btRight2Left);
            this.panel2.Controls.Add(this.btRight2Down);
            this.panel2.Controls.Add(this.lbRightList);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.btContinueDown);
            this.panel2.Controls.Add(this.btContinueUp);
            this.panel2.Controls.Add(this.btContinueDel);
            this.panel2.Controls.Add(this.btContinueAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(591, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 407);
            this.panel2.TabIndex = 1;
            // 
            // btRight2Down
            // 
            this.btRight2Down.Location = new System.Drawing.Point(193, 329);
            this.btRight2Down.Name = "btRight2Down";
            this.btRight2Down.Size = new System.Drawing.Size(88, 33);
            this.btRight2Down.TabIndex = 13;
            this.btRight2Down.Text = "←下";
            this.btRight2Down.UseVisualStyleBackColor = true;
            this.btRight2Down.Click += new System.EventHandler(this.btRight2Down_Click);
            // 
            // lbRightList
            // 
            this.lbRightList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbRightList.FormattingEnabled = true;
            this.lbRightList.ItemHeight = 25;
            this.lbRightList.Location = new System.Drawing.Point(0, 90);
            this.lbRightList.Name = "lbRightList";
            this.lbRightList.Size = new System.Drawing.Size(187, 313);
            this.lbRightList.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.tbRightEnd);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.tbRightStart);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(287, 90);
            this.panel5.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "右側標點工具列";
            // 
            // tbRightEnd
            // 
            this.tbRightEnd.Location = new System.Drawing.Point(193, 45);
            this.tbRightEnd.Name = "tbRightEnd";
            this.tbRightEnd.Size = new System.Drawing.Size(67, 34);
            this.tbRightEnd.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "起始";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "結束";
            // 
            // tbRightStart
            // 
            this.tbRightStart.Location = new System.Drawing.Point(62, 45);
            this.tbRightStart.Name = "tbRightStart";
            this.tbRightStart.Size = new System.Drawing.Size(67, 34);
            this.tbRightStart.TabIndex = 3;
            // 
            // btContinueDown
            // 
            this.btContinueDown.Location = new System.Drawing.Point(193, 236);
            this.btContinueDown.Name = "btContinueDown";
            this.btContinueDown.Size = new System.Drawing.Size(88, 33);
            this.btContinueDown.TabIndex = 8;
            this.btContinueDown.Text = "下移↓";
            this.btContinueDown.UseVisualStyleBackColor = true;
            this.btContinueDown.Click += new System.EventHandler(this.btRightDown_Click);
            // 
            // btContinueUp
            // 
            this.btContinueUp.Location = new System.Drawing.Point(193, 197);
            this.btContinueUp.Name = "btContinueUp";
            this.btContinueUp.Size = new System.Drawing.Size(88, 33);
            this.btContinueUp.TabIndex = 7;
            this.btContinueUp.Text = "上移↑";
            this.btContinueUp.UseVisualStyleBackColor = true;
            this.btContinueUp.Click += new System.EventHandler(this.btRightUp_Click);
            // 
            // btContinueDel
            // 
            this.btContinueDel.Location = new System.Drawing.Point(193, 139);
            this.btContinueDel.Name = "btContinueDel";
            this.btContinueDel.Size = new System.Drawing.Size(88, 33);
            this.btContinueDel.TabIndex = 6;
            this.btContinueDel.Text = "刪除";
            this.btContinueDel.UseVisualStyleBackColor = true;
            this.btContinueDel.Click += new System.EventHandler(this.btRightDel_Click);
            // 
            // btContinueAdd
            // 
            this.btContinueAdd.BackColor = System.Drawing.Color.Transparent;
            this.btContinueAdd.Location = new System.Drawing.Point(193, 96);
            this.btContinueAdd.Name = "btContinueAdd";
            this.btContinueAdd.Size = new System.Drawing.Size(88, 33);
            this.btContinueAdd.TabIndex = 5;
            this.btContinueAdd.Text = "新增";
            this.btContinueAdd.UseVisualStyleBackColor = false;
            this.btContinueAdd.Click += new System.EventHandler(this.btRightAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btDown2Left);
            this.panel1.Controls.Add(this.btDown2Right);
            this.panel1.Controls.Add(this.lbDownList);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btSingleDown);
            this.panel1.Controls.Add(this.btSingleUp);
            this.panel1.Controls.Add(this.btSingleDel);
            this.panel1.Controls.Add(this.btSingleAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(296, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 407);
            this.panel1.TabIndex = 0;
            // 
            // btDown2Right
            // 
            this.btDown2Right.Location = new System.Drawing.Point(193, 329);
            this.btDown2Right.Name = "btDown2Right";
            this.btDown2Right.Size = new System.Drawing.Size(88, 33);
            this.btDown2Right.TabIndex = 11;
            this.btDown2Right.Text = "右→";
            this.btDown2Right.UseVisualStyleBackColor = true;
            this.btDown2Right.Click += new System.EventHandler(this.btDown2Right_Click);
            // 
            // lbDownList
            // 
            this.lbDownList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbDownList.FormattingEnabled = true;
            this.lbDownList.ItemHeight = 25;
            this.lbDownList.Location = new System.Drawing.Point(0, 90);
            this.lbDownList.Name = "lbDownList";
            this.lbDownList.Size = new System.Drawing.Size(187, 313);
            this.lbDownList.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.tbDownStart);
            this.panel4.Controls.Add(this.tbDownEnd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(291, 90);
            this.panel4.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "下方標點工具列";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "起始";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "結束";
            // 
            // tbDownStart
            // 
            this.tbDownStart.Location = new System.Drawing.Point(63, 45);
            this.tbDownStart.Name = "tbDownStart";
            this.tbDownStart.Size = new System.Drawing.Size(67, 34);
            this.tbDownStart.TabIndex = 3;
            // 
            // tbDownEnd
            // 
            this.tbDownEnd.Location = new System.Drawing.Point(193, 45);
            this.tbDownEnd.Name = "tbDownEnd";
            this.tbDownEnd.Size = new System.Drawing.Size(63, 34);
            this.tbDownEnd.TabIndex = 4;
            // 
            // btSingleDown
            // 
            this.btSingleDown.Location = new System.Drawing.Point(193, 233);
            this.btSingleDown.Name = "btSingleDown";
            this.btSingleDown.Size = new System.Drawing.Size(88, 33);
            this.btSingleDown.TabIndex = 8;
            this.btSingleDown.Text = "下移↓";
            this.btSingleDown.UseVisualStyleBackColor = true;
            this.btSingleDown.Click += new System.EventHandler(this.btDownDown_Click);
            // 
            // btSingleUp
            // 
            this.btSingleUp.Location = new System.Drawing.Point(193, 194);
            this.btSingleUp.Name = "btSingleUp";
            this.btSingleUp.Size = new System.Drawing.Size(88, 33);
            this.btSingleUp.TabIndex = 7;
            this.btSingleUp.Text = "上移↑";
            this.btSingleUp.UseVisualStyleBackColor = true;
            this.btSingleUp.Click += new System.EventHandler(this.btDownUp_Click);
            // 
            // btSingleDel
            // 
            this.btSingleDel.BackColor = System.Drawing.Color.Transparent;
            this.btSingleDel.Location = new System.Drawing.Point(193, 136);
            this.btSingleDel.Name = "btSingleDel";
            this.btSingleDel.Size = new System.Drawing.Size(88, 33);
            this.btSingleDel.TabIndex = 6;
            this.btSingleDel.Text = "刪除";
            this.btSingleDel.UseVisualStyleBackColor = false;
            this.btSingleDel.Click += new System.EventHandler(this.btDownDel_Click);
            // 
            // btSingleAdd
            // 
            this.btSingleAdd.Location = new System.Drawing.Point(193, 96);
            this.btSingleAdd.Name = "btSingleAdd";
            this.btSingleAdd.Size = new System.Drawing.Size(88, 33);
            this.btSingleAdd.TabIndex = 5;
            this.btSingleAdd.Text = "新增";
            this.btSingleAdd.UseVisualStyleBackColor = true;
            this.btSingleAdd.Click += new System.EventHandler(this.btDownAdd_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.btLeft2Right);
            this.panel6.Controls.Add(this.btLeft2Down);
            this.panel6.Controls.Add(this.lbLeftList);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.btLeftDown);
            this.panel6.Controls.Add(this.btLeftUp);
            this.panel6.Controls.Add(this.btLeftDel);
            this.panel6.Controls.Add(this.btLeftAdd);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(293, 407);
            this.panel6.TabIndex = 2;
            // 
            // btLeft2Down
            // 
            this.btLeft2Down.Location = new System.Drawing.Point(193, 329);
            this.btLeft2Down.Name = "btLeft2Down";
            this.btLeft2Down.Size = new System.Drawing.Size(88, 33);
            this.btLeft2Down.TabIndex = 13;
            this.btLeft2Down.Text = "下→";
            this.btLeft2Down.UseVisualStyleBackColor = true;
            this.btLeft2Down.Click += new System.EventHandler(this.btLeft2Down_Click);
            // 
            // lbLeftList
            // 
            this.lbLeftList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbLeftList.FormattingEnabled = true;
            this.lbLeftList.ItemHeight = 25;
            this.lbLeftList.Location = new System.Drawing.Point(0, 90);
            this.lbLeftList.Name = "lbLeftList";
            this.lbLeftList.Size = new System.Drawing.Size(187, 313);
            this.lbLeftList.TabIndex = 9;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.tbLeftEnd);
            this.panel7.Controls.Add(this.label14);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.tbLeftStart);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(289, 90);
            this.panel7.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 25);
            this.label12.TabIndex = 0;
            this.label12.Text = "左側標點工具列";
            // 
            // tbLeftEnd
            // 
            this.tbLeftEnd.Location = new System.Drawing.Point(193, 45);
            this.tbLeftEnd.Name = "tbLeftEnd";
            this.tbLeftEnd.Size = new System.Drawing.Size(67, 34);
            this.tbLeftEnd.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 25);
            this.label14.TabIndex = 1;
            this.label14.Text = "起始";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(135, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 25);
            this.label15.TabIndex = 10;
            this.label15.Text = "結束";
            // 
            // tbLeftStart
            // 
            this.tbLeftStart.Location = new System.Drawing.Point(62, 45);
            this.tbLeftStart.Name = "tbLeftStart";
            this.tbLeftStart.Size = new System.Drawing.Size(67, 34);
            this.tbLeftStart.TabIndex = 3;
            // 
            // btLeftDown
            // 
            this.btLeftDown.Location = new System.Drawing.Point(193, 236);
            this.btLeftDown.Name = "btLeftDown";
            this.btLeftDown.Size = new System.Drawing.Size(88, 33);
            this.btLeftDown.TabIndex = 8;
            this.btLeftDown.Text = "下移↓";
            this.btLeftDown.UseVisualStyleBackColor = true;
            this.btLeftDown.Click += new System.EventHandler(this.btLeftDown_Click);
            // 
            // btLeftUp
            // 
            this.btLeftUp.Location = new System.Drawing.Point(193, 194);
            this.btLeftUp.Name = "btLeftUp";
            this.btLeftUp.Size = new System.Drawing.Size(88, 33);
            this.btLeftUp.TabIndex = 7;
            this.btLeftUp.Text = "上移↑";
            this.btLeftUp.UseVisualStyleBackColor = true;
            this.btLeftUp.Click += new System.EventHandler(this.btLeftUp_Click);
            // 
            // btLeftDel
            // 
            this.btLeftDel.Location = new System.Drawing.Point(193, 139);
            this.btLeftDel.Name = "btLeftDel";
            this.btLeftDel.Size = new System.Drawing.Size(88, 33);
            this.btLeftDel.TabIndex = 6;
            this.btLeftDel.Text = "刪除";
            this.btLeftDel.UseVisualStyleBackColor = true;
            this.btLeftDel.Click += new System.EventHandler(this.btLeftDel_Click);
            // 
            // btLeftAdd
            // 
            this.btLeftAdd.BackColor = System.Drawing.Color.Transparent;
            this.btLeftAdd.Location = new System.Drawing.Point(193, 96);
            this.btLeftAdd.Name = "btLeftAdd";
            this.btLeftAdd.Size = new System.Drawing.Size(88, 33);
            this.btLeftAdd.TabIndex = 5;
            this.btLeftAdd.Text = "新增";
            this.btLeftAdd.UseVisualStyleBackColor = false;
            this.btLeftAdd.Click += new System.EventHandler(this.btLeftAdd_Click);
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(662, 7);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(98, 40);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "確定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(777, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(98, 40);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btOK);
            this.panel3.Controls.Add(this.btCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 451);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(893, 54);
            this.panel3.TabIndex = 3;
            // 
            // btLeft2Right
            // 
            this.btLeft2Right.Location = new System.Drawing.Point(193, 290);
            this.btLeft2Right.Name = "btLeft2Right";
            this.btLeft2Right.Size = new System.Drawing.Size(88, 33);
            this.btLeft2Right.TabIndex = 14;
            this.btLeft2Right.Text = "右→→";
            this.btLeft2Right.UseVisualStyleBackColor = true;
            this.btLeft2Right.Click += new System.EventHandler(this.btLeft2Right_Click);
            // 
            // btRight2Left
            // 
            this.btRight2Left.Location = new System.Drawing.Point(193, 290);
            this.btRight2Left.Name = "btRight2Left";
            this.btRight2Left.Size = new System.Drawing.Size(88, 33);
            this.btRight2Left.TabIndex = 15;
            this.btRight2Left.Text = "←←左";
            this.btRight2Left.UseVisualStyleBackColor = true;
            this.btRight2Left.Click += new System.EventHandler(this.btRight2Left_Click);
            // 
            // btDown2Left
            // 
            this.btDown2Left.Location = new System.Drawing.Point(193, 290);
            this.btDown2Left.Name = "btDown2Left";
            this.btDown2Left.Size = new System.Drawing.Size(88, 33);
            this.btDown2Left.TabIndex = 12;
            this.btDown2Left.Text = "←左";
            this.btDown2Left.UseVisualStyleBackColor = true;
            this.btDown2Left.Click += new System.EventHandler(this.btDown2Left_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 505);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OptionForm";
            this.Text = "選項";
            this.tabControl.ResumeLayout(false);
            this.tpNormal.ResumeLayout(false);
            this.tpNormal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBackupTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbButtonFontSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpButton.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpNormal;
        private System.Windows.Forms.Button btSetFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpButton;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button btSetBackColor;
        private System.Windows.Forms.Button btSetForeColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSingleDown;
        private System.Windows.Forms.Button btSingleUp;
        private System.Windows.Forms.Button btSingleDel;
        private System.Windows.Forms.Button btSingleAdd;
        private System.Windows.Forms.TextBox tbDownEnd;
        private System.Windows.Forms.TextBox tbDownStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbDownList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lbRightList;
        private System.Windows.Forms.Button btContinueDown;
        private System.Windows.Forms.Button btContinueUp;
        private System.Windows.Forms.Button btContinueDel;
        private System.Windows.Forms.Button btContinueAdd;
        private System.Windows.Forms.TextBox tbRightStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRightEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbMouseRight;
        private System.Windows.Forms.RadioButton rbMouseLeft;
        private System.Windows.Forms.Button btRight2Down;
        private System.Windows.Forms.Button btDown2Right;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown tbButtonFontSize;
        private System.Windows.Forms.CheckBox cbAutoBackup;
        private System.Windows.Forms.CheckBox cbCursorKeepLast3Line;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown tbBackupTime;
        private System.Windows.Forms.CheckBox cbRememberLastPos;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btLeft2Down;
        private System.Windows.Forms.ListBox lbLeftList;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbLeftEnd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbLeftStart;
        private System.Windows.Forms.Button btLeftDown;
        private System.Windows.Forms.Button btLeftUp;
        private System.Windows.Forms.Button btLeftDel;
        private System.Windows.Forms.Button btLeftAdd;
        private System.Windows.Forms.Button btRight2Left;
        private System.Windows.Forms.Button btDown2Left;
        private System.Windows.Forms.Button btLeft2Right;
    }
}