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
        static public Font Font = new Font("", 10);
        static public Color BackColor = Color.White;
        static public Color ForeColor = Color.Black;

        static public void SaveToFile()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\CBEditor.ini";
            IniFile iniFile = new IniFile(file);

            string Section = "Option";

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

        }
        static public void LoadFromFile()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\CBEditor.ini";
            IniFile iniFile = new IniFile(file);

            string Section = "Option";

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
        }
    }
}
