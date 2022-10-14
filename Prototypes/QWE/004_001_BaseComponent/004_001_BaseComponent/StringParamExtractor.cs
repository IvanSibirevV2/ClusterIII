using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    public interface ISPExtractor
    {
        string p_String{get;set;}
        /////////////////////////////////////////////////////////
        ISPExtractor Set(Action<ISPExtractor> x);
        ISPExtractor Set_p_String(string _p_String);
        ISPExtractor Set_Param(string _ParamName, string _ParamValue);
        /////////////////////////////////////////////////////////
        string Get_Param(string _ParamName);
        /////////////////////////////////////////////////////////
        ISPExtractor Get_InterfaceCopy();
        ISPExtractor Get_InterfaceNewCreateInstance();
    }
    /// <summary>StringParamExtractor</summary>
    public class SPExtractor : ISPExtractor
    {
        /////////////////////////////////////////////////////////
        public string p_String {get;set;}
        public ISPExtractor Init() {return this.Set_p_String(""); }
        public SPExtractor() { this.Init(); }
        public SPExtractor(string _p_String) { this.Init().Set_p_String(_p_String); }
        public SPExtractor(string _ParamName, string _ParamValue) { this.Init().Set_Param(_ParamName,_ParamValue); }

        /////////////////////////////////////////////////////////
        public ISPExtractor Set(Action<ISPExtractor> x) { x(this); return this; }//!!!
        public ISPExtractor Set_p_String(string _p_String) { this.p_String = _p_String; return this; }
        public ISPExtractor Set_Param(string _ParamName, string _ParamValue)
        {
            List<string> _ParamList = this.p_String.Split(';').ToList<string>();
            bool _flag1_break = false;
            for (int i = 0; i < _ParamList.Count; i++)
            {
                List<string> _LS = _ParamList[i].Split('=').ToList<string>();
                if (_LS.Count == 2) if (_LS[0] == _ParamName)
                    {
                        _LS[1] = _ParamValue;
                        _ParamList[i] = _LS[0] + "=" + _LS[1];
                        _flag1_break = true;
                        break;
                    }
            }
            if (!_flag1_break)_ParamList.Add(_ParamName + "=" + _ParamValue);
            string _res = "";
            foreach (string _str in _ParamList)
                if (_str.Length!=0)_res += _str + ";";
            this.Set_p_String(_res);
            return this;
        }
        /////////////////////////////////////////////////////////
        public string Get_Param(string _ParamName)
        {
            string _resValue = "NoParam";
            List<string> _LS = this.p_String.Split(';').ToList<string>();
            if (_LS.Count == 0) return _resValue;
            foreach (string _str in _LS)
            {
                List<string> __LS = _str.Split('=').ToList<string>();
                if (__LS.Count == 2) if (__LS[0] == _ParamName) return __LS[1];
            }
            return _resValue;
        }
        public static void TestGet_Param()
        {
            ISPExtractor _ISPExtractor = new SPExtractor();
            _ISPExtractor
                .Set_Param("Name", "VarLord")
                .Set_Param("HP", "90")
                .Set_Param("GP", "30")
                //.Set_p_StringParam("Name=VarLord;HP=90;GP=30")
                ;
            Console.WriteLine("Name=" + _ISPExtractor.Get_Param("Name"));
            Console.WriteLine(" HP=" + _ISPExtractor.Get_Param("HP"));
            Console.WriteLine(" HPQ=" + _ISPExtractor.Get_Param("HPQ"));
            Console.Read();
        }
        /////////////////////////////////////////////////////////
        public ISPExtractor Get_InterfaceCopy(){return ((ISPExtractor)Activator.CreateInstance(this.GetType())).Set_p_String(this.p_String);}
        public ISPExtractor Get_InterfaceNewCreateInstance(){return ((ISPExtractor)Activator.CreateInstance(this.GetType())).Set_p_String(this.p_String);}
    }
}