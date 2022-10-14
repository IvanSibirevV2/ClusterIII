using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
//#pragma warning disable
        public class ConteinerDateTime
//#pragma warning restore
    {
        private System.DateTime p_DateTime = new DateTime();
        //////////////////////////////////////////////////////////
        public ConteinerDateTime Set() { return this; }
        public ConteinerDateTime Set_p_DateTime(System.DateTime _p_DateTime) { this.p_DateTime = _p_DateTime; return this; }
        //////////////////////////////////////////////////////////
        public ConteinerDateTime Get() { return this; }
        public System.DateTime Get_p_DateTime() { return this.p_DateTime; }
        //////////////////////////////////////////////////////////
        public static bool operator !=(ConteinerDateTime _left, ConteinerDateTime _right)
        {
            Func<int, int, bool> _FVP = (int x, int y) => { return (x != y); };
            if (_FVP(_left.Get_p_DateTime().Year, _right.Get_p_DateTime().Year)) return true;
            if (_FVP(_left.Get_p_DateTime().Month, _right.Get_p_DateTime().Month)) return true;
            if (_FVP(_left.Get_p_DateTime().Day, _right.Get_p_DateTime().Day)) return true;
            if (_FVP(_left.Get_p_DateTime().Hour, _right.Get_p_DateTime().Hour)) return true;
            if (_FVP(_left.Get_p_DateTime().Minute, _right.Get_p_DateTime().Minute)) return true;
            if (_FVP(_left.Get_p_DateTime().Second, _right.Get_p_DateTime().Second)) return true;
            if (_FVP(_left.Get_p_DateTime().Millisecond, _right.Get_p_DateTime().Millisecond)) return true;
            return false;
        }
        public static bool operator ==(ConteinerDateTime _left, ConteinerDateTime _right)
        {
            Func<int, int, bool> _FVP = (int x, int y) => { return (x != y); };
            if (_FVP(_left.Get_p_DateTime().Year, _right.Get_p_DateTime().Year)) return !true;
            if (_FVP(_left.Get_p_DateTime().Month, _right.Get_p_DateTime().Month)) return !true;
            if (_FVP(_left.Get_p_DateTime().Day, _right.Get_p_DateTime().Day)) return !true;
            if (_FVP(_left.Get_p_DateTime().Hour, _right.Get_p_DateTime().Hour)) return !true;
            if (_FVP(_left.Get_p_DateTime().Minute, _right.Get_p_DateTime().Minute)) return !true;
            if (_FVP(_left.Get_p_DateTime().Second, _right.Get_p_DateTime().Second)) return !true;
            if (_FVP(_left.Get_p_DateTime().Millisecond, _right.Get_p_DateTime().Millisecond)) return !true;
            return true;
        }
        public static bool operator <(ConteinerDateTime _left, ConteinerDateTime _right)
        {
            Func<int, int, bool> _FVP = (int x, int y) => { return (x >= y); };
            if (_FVP(_left.Get_p_DateTime().Year, _right.Get_p_DateTime().Year)) return !true;
            if (_FVP(_left.Get_p_DateTime().Month, _right.Get_p_DateTime().Month)) return !true;
            if (_FVP(_left.Get_p_DateTime().Day, _right.Get_p_DateTime().Day)) return !true;
            if (_FVP(_left.Get_p_DateTime().Hour, _right.Get_p_DateTime().Hour)) return !true;
            if (_FVP(_left.Get_p_DateTime().Minute, _right.Get_p_DateTime().Minute)) return !true;
            if (_FVP(_left.Get_p_DateTime().Second, _right.Get_p_DateTime().Second)) return !true;
            if (_FVP(_left.Get_p_DateTime().Millisecond, _right.Get_p_DateTime().Millisecond)) return !true;
            return true;
        }
        public static bool operator >(ConteinerDateTime _left, ConteinerDateTime _right)
        {
            Func<int, int, bool> _FVP = (int x, int y) => { return (x <= y); };
            if (_FVP(_left.Get_p_DateTime().Year, _right.Get_p_DateTime().Year)) return !true;
            if (_FVP(_left.Get_p_DateTime().Month, _right.Get_p_DateTime().Month)) return !true;
            if (_FVP(_left.Get_p_DateTime().Day, _right.Get_p_DateTime().Day)) return !true;
            if (_FVP(_left.Get_p_DateTime().Hour, _right.Get_p_DateTime().Hour)) return !true;
            if (_FVP(_left.Get_p_DateTime().Minute, _right.Get_p_DateTime().Minute)) return !true;
            if (_FVP(_left.Get_p_DateTime().Second, _right.Get_p_DateTime().Second)) return !true;
            if (_FVP(_left.Get_p_DateTime().Millisecond, _right.Get_p_DateTime().Millisecond)) return !true;
            return true;
        }
        public static bool operator <=(ConteinerDateTime _left, ConteinerDateTime _right)
        {
            return ((_left < _right) || (_left == _right));
        }
        public static bool operator >=(ConteinerDateTime _left, ConteinerDateTime _right)
        {
            return ((_left < _right) || (_left == _right));
        }
        public static ConteinerDateTime operator +(ConteinerDateTime _left, ConteinerDateTime _right)
        {
            System.DateTime __left = _left.Get_p_DateTime();
            System.DateTime __right = _right.Get_p_DateTime();
            System.DateTime __resalt = _right.Get_p_DateTime();

            return (new ConteinerDateTime()).Set_p_DateTime(__resalt);
        }
        /*
        public static bool operator <=(Digit _left, Digit _right) { return _left.Get_p_IDigit().Get_p_Value() <= _right.Get_p_IDigit().Get_p_Value(); }
        public static bool operator >=(Digit _left, Digit _right) { return _left.Get_p_IDigit().Get_p_Value() >= _right.Get_p_IDigit().Get_p_Value(); }
        */
    } 
}
