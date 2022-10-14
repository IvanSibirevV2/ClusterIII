using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    public static class Extension_String_SLimiter
    {
        /// <summary>опробовано ... работает</summary>
        public static string SLimiter(this string _str, int q)
        {
            string rez = "";
            Func<double, int> Integer_Length = (double x) => { return Convert.ToString((int)x).Length; };
            Func<double, int> Double_Length = (double x) => { return Convert.ToString((double)x - (int)x).Length - 2; };
            Func<double, string> Integer_String = (double x) => { return Convert.ToString((int)x); };
            Func<double, string> Double_String = (double x) => { string _rez = ""; string x_string = Convert.ToString(x); for (int i = Integer_Length(x) + 1; i < x_string.Length; i++)_rez += x_string[i]; return _rez; };
            Func<double, int, string> SLimiter_q = (double x, int _q) =>
            {
                string _rez = "";
                int e = Integer_Length(x);
                foreach (char ch in Integer_String(x) + Double_String(x))
                {
                    if (_rez.Length < _q - Convert.ToString(e).Length - 1)
                    { _rez += ch; e--; }
                    else { break; }
                }
                ;
                while (_rez[0] == '0')
                {
                    string sdgjhksfdkj = "";
                    //foreach (char w in res)
                    for (int h = 1; h < _rez.Length; h++)
                        sdgjhksfdkj += _rez[h];
                    _rez = sdgjhksfdkj;
                }
                e += _rez.Length;
                bool AddE_ = true;
                string gfgssss = "";
                int IfNotAddE_ = 0;
                for (int i = 0; i < _rez.Length + IfNotAddE_; i++)
                {

                    if (e == 0)
                    {
                        gfgssss += ".";
                        AddE_ = false;
                        IfNotAddE_ = 1;
                    }
                    gfgssss += _rez[i];

                    e--;
                }
                _rez = gfgssss;
                if (AddE_)
                {
                    _rez += "E" + Convert.ToString(e);
                }
                return _rez;
            };

            bool isDouble = true;
            try { double d = Convert.ToDouble(_str); isDouble = true; }
            catch { isDouble = false; }
            if (isDouble)
            {
                string wqe = _str;
                _str = Convert.ToString((int)Convert.ToDouble(wqe));
                if (Double_String(Convert.ToDouble(wqe)).Length != 0)
                {
                    _str += "." + Double_String(Convert.ToDouble(wqe));
                };
            }

            if (_str.Length > q)
            {
                rez = "";
                //Если строка не число
                for (int i = 0; i < _str.Length; i++)
                {
                    rez = rez + _str[i];
                    if (rez.Length == q) { break; }
                }
            }
            else
                if (_str.Length == q)
                {
                    rez = _str;
                }
                else
                    if (_str.Length < q)
                    {
                        rez = _str;
                        while (rez.Length != q)
                            rez = " " + rez;
                    }
            return rez;
        }
    }
}