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
        static public int FontSize = 20;
        static public Font FontStyle = new Font("", 10);


        static public void SaveToFile()
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\CBEditor.ini";


        }
        static public void LoadFromFile()
        {

        }


    }

}
