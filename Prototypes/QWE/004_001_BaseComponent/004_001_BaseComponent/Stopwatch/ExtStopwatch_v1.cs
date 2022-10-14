using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Component
{
    /// <summary>ExtensionXrenZnaet</summary>
    public static class ExtStopwatch_v1
    {
        public static void Ext_WriteThis(this System.Diagnostics.Stopwatch _Stopwatch, string str)
        {
            Console.Write(str);
            (new Consoller_Shabloner())
                .Set_ColorS(ConsoleColor.Cyan, ConsoleColor.Black)
                .Write(Convert.ToString(_Stopwatch.Elapsed.Hours));
            Console.Write("_");
            (new Consoller_Shabloner())
                .Set_ColorS(ConsoleColor.Red, ConsoleColor.Black)
                .Write(Convert.ToString(_Stopwatch.Elapsed.Minutes));
            Console.Write("_");
            (new Consoller_Shabloner())
                .Set_ColorS(ConsoleColor.Green, ConsoleColor.Black)
                .Write(Convert.ToString(_Stopwatch.Elapsed.Seconds));
            Console.Write("_");
            (new Consoller_Shabloner())
                .Set_ColorS(ConsoleColor.Magenta, ConsoleColor.Black)
                .WriteLine(Convert.ToString(_Stopwatch.Elapsed.Milliseconds));

            if(false)sadf(str + Convert.ToString(_Stopwatch.Elapsed.Hours) + "_" + Convert.ToString(_Stopwatch.Elapsed.Minutes) + "_" + Convert.ToString(_Stopwatch.Elapsed.Seconds) + "_" + Convert.ToString(_Stopwatch.Elapsed.Milliseconds));
        }

        static void sadf(string rst)
        {
            string fileName = "Log.txt";
            StreamWriter sw = new StreamWriter(File.Open(fileName, FileMode.Append));
            sw.WriteLine(rst);
            sw.Close();
        }
    }
}