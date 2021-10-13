using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBEditor
{
    static public class Setting
    {
        // 主視窗畫面
        static public int MainFormLeft;
        static public int MainFormTop;
        static public int MainFormWidht;
        static public int MainFormHeight;
        static public int MainLeftPanelWidth;
        static public int MainRightPanelWidth;

        // 持續性按鈕是左鍵或右鍵
        //static public bool ContinueButtonIsLeft;    // 暫時不用了

        static public int ButtonFontSize;    // 按鈕文字的大小
        static public bool CursorKeepLast3Line; // 游標保持在倒數第三行
        static public bool AutoBackup;          // 自動備份
        static public int BackupTime;           // 自動備份時間

        static public Font Font = new Font("", 10);
        static public Color BackColor = Color.White;
        static public Color ForeColor = Color.Black;
        static public List<string> SingleList = new List<string>();
        static public List<string> ContinueList = new List<string>();

        static public void SaveToFile()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\CBEditor.ini";
            IniFile iniFile = new IniFile(file);

            string Section = "Main";

            iniFile.WriteInteger(Section, "MainFormLeft", MainFormLeft);
            iniFile.WriteInteger(Section, "MainFormTop", MainFormTop);
            iniFile.WriteInteger(Section, "MainFormWidth", MainFormWidht);
            iniFile.WriteInteger(Section, "MainFormHeight", MainFormHeight);
            iniFile.WriteInteger(Section, "MainLeftPanelWidth", MainLeftPanelWidth);
            iniFile.WriteInteger(Section, "MainRightPanelWidth", MainRightPanelWidth);

            Section = "Option";

            // 持續性按鈕是左鍵嗎？
            //iniFile.WriteBool(Section, "CountinueButtonIsLeft", ContinueButtonIsLeft);

            // 按鈕文字的大小
            iniFile.WriteInteger(Section, "ButtonFontSize", ButtonFontSize);

            // 游標保持在倒數第三行
            iniFile.WriteBool(Section, "CursorKeepLast3Line", CursorKeepLast3Line);

            // 自動備份
            iniFile.WriteBool(Section, "AutoBackup", AutoBackup);
            // 備份時間
            iniFile.WriteInteger(Section, "BackupTime", BackupTime);


            // 前/背景色
            iniFile.WriteInteger(Section, "ForeColor", ForeColor.ToArgb());
            iniFile.WriteInteger(Section, "BackColor", BackColor.ToArgb());

            // 字型
            iniFile.WriteFloat(Section, "FontSize", Font.Size);
            iniFile.WriteString(Section, "FontName", Font.Name);
            iniFile.WriteBool(Section, "FontBold", Font.Bold);
            iniFile.WriteBool(Section, "FontItalic", Font.Italic);
            iniFile.WriteBool(Section, "FontUnderline", Font.Underline);
            iniFile.WriteBool(Section, "FontStrikeout", Font.Strikeout);

            // 單次按鈕
            iniFile.WriteInteger(Section, "SingleButtonCount", SingleList.Count);
            for(int i = 0; i < SingleList.Count; i++) {
                string fieldName = "SingleButton" + i.ToString();
                iniFile.WriteString(Section, fieldName, SingleList[i]);
            }
            // 連續按鈕
            iniFile.WriteInteger(Section, "ContinueButtonCount", ContinueList.Count);
            for(int i = 0; i < ContinueList.Count; i++) {
                string fieldName = "ContinueButton" + i.ToString();
                iniFile.WriteString(Section, fieldName, ContinueList[i]);
            }
        }
        static public void LoadFromFile()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\CBEditor.ini";
            IniFile iniFile = new IniFile(file);

            string Section = "Main";

            MainFormLeft = iniFile.ReadInteger(Section, "MainFormLeft", -1);
            MainFormTop = iniFile.ReadInteger(Section, "MainFormTop", -1);
            MainFormWidht = iniFile.ReadInteger(Section, "MainFormWidth", 0);
            MainFormHeight = iniFile.ReadInteger(Section, "MainFormHeight", 0);
            MainLeftPanelWidth = iniFile.ReadInteger(Section, "MainLeftPanelWidth", 0);
            MainRightPanelWidth = iniFile.ReadInteger(Section, "MainRightPanelWidth", 0);

            Section = "Option";

            // 持續性按鈕是左鍵嗎？
            //ContinueButtonIsLeft = iniFile.ReadBool(Section, "CountinueButtonIsLeft", true);

            // 按鈕文字的大小
            ButtonFontSize = iniFile.ReadInteger(Section, "ButtonFontSize", 10);


            // 游標保持在倒數第三行
            CursorKeepLast3Line = iniFile.ReadBool(Section, "CursorKeepLast3Line", true);

            // 自動備份
            AutoBackup = iniFile.ReadBool(Section, "AutoBackup", true);
            // 備份時間
            BackupTime = iniFile.ReadInteger(Section, "BackupTime", 5);

            // 前/背景色
            int iColor = iniFile.ReadInteger(Section, "ForeColor", Color.Black.ToArgb());
            ForeColor = Color.FromArgb(iColor);
            iColor = iniFile.ReadInteger(Section, "BackColor", Color.White.ToArgb());
            BackColor = Color.FromArgb(iColor);

            // 字型
            float fontSize = iniFile.ReadFloat(Section, "FontSize", 12.0F);
            string fontName = iniFile.ReadString(Section, "FontName", "微軟正黑體");
            bool fontBold = iniFile.ReadBool(Section, "FontBold", false);

            bool fontItalic = iniFile.ReadBool(Section, "FontItalic", false);
            bool fontUnderline = iniFile.ReadBool(Section, "FontUnderline", false);
            bool fontStrikeout = iniFile.ReadBool(Section, "FontStrikeout", false);

            FontStyle fontStyle = FontStyle.Regular;
            if(fontBold) { fontStyle |= FontStyle.Bold; }
            if(fontItalic) { fontStyle |= FontStyle.Italic; }
            if(fontUnderline) { fontStyle |= FontStyle.Underline; }
            if(fontStrikeout) { fontStyle |= FontStyle.Strikeout; }

            // 像正黑體有淡色，會無法正常處理，所以要靠 Properties.Settings.Default.Font 來儲存
            if(!fontName.EndsWith("Light")) {
                Font = new Font(fontName, fontSize, fontStyle);
            } else {
                Font = Properties.Settings.Default.Font;
            }

            // 單次按鈕
            int singleButtonCount = iniFile.ReadInteger(Section, "SingleButtonCount", 0);
            SingleList.Clear();
            for(int i = 0; i < singleButtonCount; i++) {
                string fieldName = "SingleButton" + i.ToString();
                string sItem = iniFile.ReadString(Section, fieldName, "");
                SingleList.Add(sItem);
            }
            // 連續按鈕
            int continueButtonCount = iniFile.ReadInteger(Section, "ContinueButtonCount", 0);
            ContinueList.Clear();
            for(int i = 0; i < continueButtonCount; i++) {
                string fieldName = "ContinueButton" + i.ToString();
                string sItem = iniFile.ReadString(Section, fieldName, "");
                ContinueList.Add(sItem);
            }
        }
    }
}
