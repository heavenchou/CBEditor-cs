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
        static public int MainDownPanelHeight;
        static public int MainRightPanelWidth;
        static public int MainLeftPanelWidth;

        // 持續性按鈕是左鍵或右鍵
        //static public bool ContinueButtonIsLeft;    // 暫時不用了

        static public int ButtonFontSize = 10;          // 按鈕文字的大小
        static public bool CursorKeepLast3Line = true;  // 游標保持在倒數第三行
        static public bool AutoBackup = true;           // 自動備份
        static public int BackupTime = 5;               // 自動備份時間
        static public bool RememberLastPos = true;      // 記憶檔案最後開啟位置

        static public Font Font = new Font("", 10);
        static public Color BackColor = Color.White;
        static public Color ForeColor = Color.Black;
        static public List<string> LeftList = new List<string>();
        static public List<string> RightList = new List<string>();
        static public List<string> DownList = new List<string>();

        static public bool LeftIsSingle = false;    // 記錄左方按鈕是連續還是單次
        static public bool RightIsSingle = false;   // 記錄右方按鈕是連續還是單次
        static public bool DownIsSingle = false;     // 記錄下方按鈕是連續還是單次

        static public List<string> OpenFileName = new List<string>();   // 曾經開啟過的檔名
        static public List<int> OpenFilePos = new List<int>();          // 曾經開啟過的檔案最後編輯位置

        static public void SaveToFile()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\CBEditor.ini";
            IniFile iniFile = new IniFile(file);

            string Section = "Option";

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
            // 記憶檔案最後開啟位置
            iniFile.WriteBool(Section, "RememberLastPos", RememberLastPos);

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

            iniFile.WriteBool(Section, "LeftIsSingle", LeftIsSingle);
            iniFile.WriteBool(Section, "RightIsSingle", RightIsSingle);
            iniFile.WriteBool(Section, "DownIsSingle", DownIsSingle);

            // 左方（連續）按鈕
            iniFile.WriteInteger(Section, "LeftButtonCount", LeftList.Count);
            for (int i = 0; i < LeftList.Count; i++) {
                string fieldName = "LeftButton" + i.ToString();
                iniFile.WriteString(Section, fieldName, LeftList[i]);
            }
            // 下方（單次）按鈕
            iniFile.WriteInteger(Section, "SingleButtonCount", DownList.Count);
            for(int i = 0; i < DownList.Count; i++) {
                string fieldName = "SingleButton" + i.ToString();
                iniFile.WriteString(Section, fieldName, DownList[i]);
            }
            // 右方（連續）按鈕
            iniFile.WriteInteger(Section, "ContinueButtonCount", RightList.Count);
            for(int i = 0; i < RightList.Count; i++) {
                string fieldName = "ContinueButton" + i.ToString();
                iniFile.WriteString(Section, fieldName, RightList[i]);
            }
        }

        static public void LastSave()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\CBEditor.ini";
            IniFile iniFile = new IniFile(file);

            string Section = "Main";

            iniFile.WriteInteger(Section, "MainFormLeft", MainFormLeft);
            iniFile.WriteInteger(Section, "MainFormTop", MainFormTop);
            iniFile.WriteInteger(Section, "MainFormWidth", MainFormWidht);
            iniFile.WriteInteger(Section, "MainFormHeight", MainFormHeight);
            iniFile.WriteInteger(Section, "MainDownPanelHeight", MainDownPanelHeight);
            iniFile.WriteInteger(Section, "MainRightPanelWidth", MainRightPanelWidth);
            iniFile.WriteInteger(Section, "MainLeftPanelWidth", MainLeftPanelWidth);

            Section = "File";

            // 開啟過的檔案及最後位置
            int iOpenFileCount = OpenFileName.Count;
            if(iOpenFileCount > 20) {
                iOpenFileCount = 20;
            }
            iniFile.WriteInteger(Section, "OpenFileCount", iOpenFileCount);
            for(int i = 0; i < iOpenFileCount; i++) {
                string fieldName = "OpenFileName" + i.ToString();
                iniFile.WriteString(Section, fieldName, OpenFileName[i]);
            }
            for(int i = 0; i < iOpenFileCount; i++) {
                string fieldName = "OpenFilePos" + i.ToString();
                iniFile.WriteInteger(Section, fieldName, OpenFilePos[i]);
            }
        }

        static public void FirstLoad()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\CBEditor.ini";
            IniFile iniFile = new IniFile(file);

            string Section = "Main";

            MainFormLeft = iniFile.ReadInteger(Section, "MainFormLeft", -1);
            MainFormTop = iniFile.ReadInteger(Section, "MainFormTop", -1);
            MainFormWidht = iniFile.ReadInteger(Section, "MainFormWidth", 0);
            MainFormHeight = iniFile.ReadInteger(Section, "MainFormHeight", 0);
            MainDownPanelHeight = iniFile.ReadInteger(Section, "MainDownPanelHeight", 0);
            MainRightPanelWidth = iniFile.ReadInteger(Section, "MainRightPanelWidth", 0);
            MainLeftPanelWidth = iniFile.ReadInteger(Section, "MainLeftPanelWidth", 0);

            Section = "File";

            // 開啟過的檔案及最後位置
            int iOpenFileCount = iniFile.ReadInteger(Section, "OpenFileCount", 0);
            OpenFileName.Clear();
            for(int i = 0; i < iOpenFileCount; i++) {
                string fieldName = "OpenFileName" + i.ToString();
                string sItem = iniFile.ReadString(Section, fieldName, "");
                OpenFileName.Add(sItem);
            }
            OpenFilePos.Clear();
            for(int i = 0; i < iOpenFileCount; i++) {
                string fieldName = "OpenFilePos" + i.ToString();
                int iItem = iniFile.ReadInteger(Section, fieldName, 0);
                OpenFilePos.Add(iItem);
            }
        }

        static public void LoadFromFile()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\CBEditor.ini";
            IniFile iniFile = new IniFile(file);

            string Section = "Option";

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
            // 記憶檔案最後開啟位置
            RememberLastPos = iniFile.ReadBool(Section, "RememberLastPos", true);

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

            LeftIsSingle = iniFile.ReadBool(Section, "LeftIsSingle", LeftIsSingle);
            RightIsSingle = iniFile.ReadBool(Section, "RightIsSingle", RightIsSingle);
            DownIsSingle = iniFile.ReadBool(Section, "DownIsSingle", DownIsSingle);

            // 下方（單次）按鈕
            int singleButtonCount = iniFile.ReadInteger(Section, "SingleButtonCount", 0);
            DownList.Clear();
            for(int i = 0; i < singleButtonCount; i++) {
                string fieldName = "SingleButton" + i.ToString();
                string sItem = iniFile.ReadString(Section, fieldName, "");
                DownList.Add(sItem);
            }
            // 右方（連續）按鈕
            int continueButtonCount = iniFile.ReadInteger(Section, "ContinueButtonCount", 0);
            RightList.Clear();
            for(int i = 0; i < continueButtonCount; i++) {
                string fieldName = "ContinueButton" + i.ToString();
                string sItem = iniFile.ReadString(Section, fieldName, "");
                RightList.Add(sItem);
            }
            // 左方（連續）按鈕
            int leftButtonCount = iniFile.ReadInteger(Section, "LeftButtonCount", 0);
            LeftList.Clear();
            for (int i = 0; i < leftButtonCount; i++) {
                string fieldName = "LeftButton" + i.ToString();
                string sItem = iniFile.ReadString(Section, fieldName, "");
                LeftList.Add(sItem);
            }
        }
    }
}
