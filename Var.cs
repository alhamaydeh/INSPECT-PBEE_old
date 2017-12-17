using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
namespace SampleWizard
{
    class Var
    {
       public static String pp = Application.StartupPath.ToString();
       public static String Load_file = null;
       public static bool Dont_del = false;
       public static String path_desk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

       public static int story_num = 0;
    }
}
