using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    /// <summary>Класс предоставляет конвертацию для Stopwatch</summary>
    public static class ExtStopwatch_v2
    {
        public static long Get_Watch_Hours_AsLong(this System.Diagnostics.Stopwatch _watch)
        { return (long)_watch.Elapsed.Hours; }
        public static long Get_Watch_Minutes_AsLong(this System.Diagnostics.Stopwatch _watch)
        { return (long)(_watch.Get_Watch_Hours_AsLong() * 60 + _watch.Elapsed.Minutes); }
        public static long Get_Watch_Seconds_AsLong(this System.Diagnostics.Stopwatch _watch)
        { return (long)(_watch.Get_Watch_Minutes_AsLong() * 60 + _watch.Elapsed.Seconds); }
        public static long Get_Watch_Milliseconds_AsLong(this System.Diagnostics.Stopwatch _watch)
        { return (long)(_watch.Get_Watch_Seconds_AsLong() * 60 + _watch.Elapsed.Milliseconds); }
        //////////////////////////////////////////////////////////////////////////////////////
        public static double Get_Watch_Milliseconds_Asdouble(this System.Diagnostics.Stopwatch _watch)
        { return (double)(_watch.Get_Watch_Milliseconds_AsLong()); }
        public static double Get_Watch_Seconds_Asdouble(this System.Diagnostics.Stopwatch _watch)
        { return (double)(_watch.Get_Watch_Milliseconds_Asdouble() / 60); }
        public static double Get_Watch_Minutes_Asdouble(this System.Diagnostics.Stopwatch _watch)
        { return (double)(_watch.Get_Watch_Seconds_Asdouble() / 60); }
        public static double Get_Watch_Hours_Asdouble(this System.Diagnostics.Stopwatch _watch)
        { return (double)(_watch.Get_Watch_Minutes_Asdouble() / 60); }
        //////////////////////////////////////////////////////////////////////////////////////
        public static string Get_WatchString_M(this System.Diagnostics.Stopwatch _watch)
        {
            string time = "";
            time += "Hou<" + _watch.Elapsed.Hours + ">;";
            time += "Min<" + _watch.Elapsed.Minutes + ">;";
            time += "Sec<" + _watch.Elapsed.Seconds + ">;";
            time += "Mil<" + _watch.Elapsed.Milliseconds + ">;";
            return time;
        }
        public static string Get_WatchString(this System.Diagnostics.Stopwatch _watch)
        {
            string time = "";
            time += "." + _watch.Elapsed.Hours;
            time += "." + _watch.Elapsed.Minutes;
            time += "." + _watch.Elapsed.Seconds;
            time += "." + _watch.Elapsed.Milliseconds;
            return time;
        }
        //////////////////////////////////////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());

            System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
            _watch.Start();
            System.Threading.Thread.Sleep(2000);
            _watch.Stop();
            _watch.Ext_WriteThis("TestTime");
            Console.WriteLine(Convert.ToString(_watch.Get_Watch_Milliseconds_AsLong()));
            Console.WriteLine(Convert.ToString(_watch.Get_Watch_Seconds_AsLong()));
            Console.WriteLine(Convert.ToString(_watch.Get_Watch_Minutes_AsLong()));
            Console.WriteLine(Convert.ToString(_watch.Get_Watch_Hours_AsLong()));
            Console.WriteLine("//////////////////////////////////////////////////////////////");
            Console.WriteLine(Convert.ToString(_watch.Get_Watch_Milliseconds_Asdouble()));
            Console.WriteLine(Convert.ToString(_watch.Get_Watch_Seconds_Asdouble()));
            Console.WriteLine(Convert.ToString(_watch.Get_Watch_Minutes_Asdouble()));
            Console.WriteLine(Convert.ToString(_watch.Get_Watch_Hours_Asdouble()));

            Console.Read();
        }
    }
}