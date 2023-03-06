using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Data
{
    public static class Ext_LLS
    {
        public static List<List<string>> WriteThis(this List<List<String>> _this,uint i = 4)
        {
            _this
                .AsParallel().Select(a => System.String.Join("|", a.AsParallel().Select(b=>b.ToString().GetStringtAs(i)).ToList())).ToList()
                .ForEach(a => a.WriteLine() )
                ;
            return _this; 
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List<System.String> Get_Copy(this List<System.String> _this) => _this.Select(a => a).ToList();
        public static List<List<System.String>> Get_Copy(this List<List<System.String>> _this) => _this.Select(a => a.Get_Copy()).ToList();
        public static List<List<List<System.String>>> Get_Copy(this List<List<List<System.String>>> _this) => _this.Select(a => a.Get_Copy()).ToList();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Проверяем одинаковое ли кол-во элементов в строке</summary><returns></returns>
        public static System.Boolean DataTest_1(this List<List<System.String>> _this,System.Boolean _IsConsole=false) =>
            (_this.Select(x => x.Count()).Average() == _this.First().Count())
            .SetIf(_Bool: _IsConsole, _f1: a =>a.ToString().Add("-Проверяем одинаковое ли кол-во элементов в строке").WriteLine())        
        ;
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 3, _day: 6, _hour: 11, _minute: 1, _second: 0, _millisecond: 0, _StrComment: "Тест;")]
        public static System.Boolean Test_DataTest_1()
        {
            new List<List<System.String>>().Set__Data_SuperSmall().WriteThis().DataTest_1(_IsConsole:true);
            return true;
        }
        /// <summary>Проверка на столбцы>2 и строки>2</summary>
        public static System.Boolean DataTest_2(this List<List<System.String>> _this, System.Boolean _IsConsole = false) =>
            (_this.Count() > 2 && _this.Where(x => x.Count > 2).Select(x => x).Count() == _this.Count() && _this.Count() > 2)
            .SetIf(_Bool: _IsConsole, _f1: a => a.ToString().Add("-Проверка на столбцы>2 и строки>2").WriteLine())
        ;
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 3, _day: 6, _hour: 11, _minute: 0, _second: 0, _millisecond: 0, _StrComment: "Тест;")]
        public static System.Boolean Test_DataTest_2()
        {
            new List<List<System.String>>().Set__Data_SuperSmall().WriteThis().DataTest_2(_IsConsole: true);
            return true;
        }
        /// <summary>Проверка на конвертацию в double или ==NaN</summary>
        public static System.Boolean DataTest_3(this List<List<System.String>> _this, System.Boolean _IsConsole = false) => new System.Double().Get(qwer =>
            _this
                .AsParallel()
                .Where((a, i) => i != 0)
                .Select(a => a
                    .AsParallel()
                    .Where((b, i) => i != 0)
                    .Select(b => System.Double.TryParse(b, out qwer) || (b == "NaN"))
                    .Aggregate((s, d) => s && d)
                )
                .Aggregate((s, d) => s && d)
            .SetIf(_Bool: _IsConsole, _f1: a => a.ToString().Add("-Проверка на конвертацию в double или ==NaN").WriteLine())
        );
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 3, _day: 6, _hour: 10, _minute: 58, _second: 57, _millisecond: 0, _StrComment: "Тест;")]
        public static System.Boolean Test_DataTest_3()
        {
            new List<List<System.String>>().Set__Data_SuperSmall().WriteThis().DataTest_3(_IsConsole: true);
            return true;
        }
        public static System.Boolean DataTest_All(this List<List<System.String>> _this, System.Boolean _IsConsole = false) => 
            _this.DataTest_1(_IsConsole: _IsConsole) && _this.DataTest_2(_IsConsole: _IsConsole) && _this.DataTest_3(_IsConsole: _IsConsole);
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 3, _day: 6, _hour: 10, _minute: 59, _second:56, _millisecond: 0, _StrComment: "Тест;")]
        public static System.Boolean Test_DataTest_All() 
        {
            new  List<List<System.String>>().Set__Data_SuperSmall().WriteThis().DataTest_All(_IsConsole: true);
            return true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class PointXY
        {
            public int I=0;
            public int J=0;
            public PointXY() { }
            public PointXY(int i, int j) {  this.I = i; this.J = j; }
            public System.Object ToAnonimys() { return new { I = this.I, J = this.J }; }
        }
        public static List<PointXY> GetNaNList(this List<List<System.String>> _this) 
        {
            
            List<PointXY> _LPointXY = new List<PointXY>();
            for (int i = 1; i < _this.Count; i++)
                for (int j = 1; j < _this[0].Count; j++)
                    if (_this[i][j] == "NaN") _LPointXY.Add(new PointXY(i, j));
            return _LPointXY;
        }
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 3, _day: 6, _hour: 11, _minute: 34, _second: 0, _millisecond: 0, _StrComment: "Тест;")]
        public static System.Boolean Test_1() 
        {
            new List<List<System.String>>().Set__Data_SuperSmallNaN().WriteThis().GetNaNList().ForEach(a=>a.ToAnonimys().ToString().WriteLine());
            return true;
        }
        public static List<List<System.String>> Get_LLS_NanToZero(this List<List<System.String>> _this) 
        {
            for (int i = 0; i < _this.Count; i++)
                for (int j = 0; j < _this[0].Count; j++)
                    if (_this[i][j] == "NaN") _this[i][j] = "0";
            return _this;
        }
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 3, _day: 6, _hour: 12, _minute: 24, _second: 0, _millisecond: 0, _StrComment: "Тест;")]
        public static System.Boolean Test_2()
        {
            new List<List<System.String>>().Set__Data_SuperSmallNaN().WriteThis().Get_LLS_NanToZero().WriteThis();
            return true;
        }
        //Сделать генирацию неповторяющегося id
        public static List<List<double>> Get_As_LLD(this List<List<System.String>> _this) 
        {
            if (!_this.DataTest_All()) throw new System.Exception("Eror: 2023:03:06::12:41 LLS DATA Eror");
            List<List<double>> _LLD = new List<List<double>>();
            for (int i = 1; i < _this.Count; i++)
            {
                List<System.Double> _LD = new List<double>().Set_Add(i);
                for (int j = 1; j < _this[0].Count; j++)
                    _LD.Add(System.Double.Parse(_this[i][j]));
                _LLD.Add(_LD);
            }
            return _LLD;
        }
    }
}