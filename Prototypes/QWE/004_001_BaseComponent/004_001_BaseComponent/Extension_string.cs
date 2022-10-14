using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    public static class Ext_string
    {
        public static string Set(this string _this_str_Ext, Func<string, string> x){return x(_this_str_Ext);}
        public static string Set(this string _this_str_Ext, Action x) { x(); return _this_str_Ext; }
        public static string Set_Write(this string _this_str_Ext) { Console.Write(_this_str_Ext); return _this_str_Ext; }
        public static string Set_WriteLine(this string _this_str_Ext) { Console.WriteLine(_this_str_Ext); return _this_str_Ext; }
    }
}