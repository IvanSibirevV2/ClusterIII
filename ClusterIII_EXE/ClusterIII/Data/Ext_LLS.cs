using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Data
{
    public static class Ext_LLS_GetLLD
    {
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 03, _day: 17, _hour: 16, _minute: 51, _second: 0)]
        public static System.Boolean Test_Get_As_LLD()
        {
            "Привет мир".WriteLine();
            List<List<System.String>> _LLStr=new List<List<System.String>>().Set__Data_SuperSmallNaN()
                .WriteThis()
            ;
            List<List<System.Double>> _LLD = new List<List<double>>();
            {//Создание таблицы LLD с нулями
                for (int i = 1; i < _LLStr.Count; i++)
                {
                    List<System.Double> _LD = new List<double>();
                    _LD.Add((System.Double)i);
                    for (int j = 1; j < _LLStr[i].Count; j++)
                    {
                        _LD.Add(0);
                    }
                    _LLD.Add(_LD);
                }
            }
            {//Наполнение таблицы числами если удастся c пост заполнением средними арифметическими пропусков.
                for (int j = 1; j < _LLStr[0].Count; j++)
                {
                    System.Int32 Counter_not_Nan = 0;
                    System.Double SummJParap = 0;
                    List<System.Action> ListPostAct = new List<Action>(); ;
                    for (int i = 1; i < _LLStr.Count; i++)
                    {
                        System.Double _D = 0;
                        if (System.Double.TryParse(_LLStr[i][j], out _D))
                        {
                            if (_D != System.Double.NaN)
                            {
                                _LLD[i - 1][j] = _D;Counter_not_Nan++;SummJParap += _D;}
                        }
                        else 
                        {
                            int i_local = i-1;
                            int j_local = j;
                            ListPostAct.Add(() =>_LLD[i_local][j_local] = SummJParap);
                        }
                    }
                    SummJParap = SummJParap /Counter_not_Nan;
                    ListPostAct.ForEach(a => a());
                }
            }
            _LLD.WriteThis();
            return true;
        }

    }
    public static class Ext_LLS
    {
        /// <summary>Вывод в консоль в текстовой форме</summary>
        public static List<List<string>> WriteThis(this List<List<String>> _this,uint i = 4)
        {
            _this
                .AsParallel().Select(a => System.String.Join("|", a.AsParallel().Select(b=>b.ToString().GetStringtAs(i)).ToList())).ToList()
                .ForEach(a => a.WriteLine() )
                ;
            return _this; 
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Глубокое родное нативное копирование</summary>
        public static List<System.String> Get_Copy(this List<System.String> _this) => _this.Select(a => a).ToList();
        /// <summary> Глубокое родное нативное копирование</summary>м
        public static List<List<System.String>> Get_Copy(this List<List<System.String>> _this) => _this.Select(a => a.Get_Copy()).ToList();
        /// <summary> Глубокое родное нативное копирование</summary>
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
        /// <summary> Запук всех тестов, челых трех </summary>
        public static System.Boolean DataTest_All(this List<List<System.String>> _this, System.Boolean _IsConsole = false) => 
            _this.DataTest_1(_IsConsole: _IsConsole) && _this.DataTest_2(_IsConsole: _IsConsole) && _this.DataTest_3(_IsConsole: _IsConsole);
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 3, _day: 6, _hour: 10, _minute: 59, _second:56, _millisecond: 0, _StrComment: "Тест;")]
        public static System.Boolean Test_DataTest_All() 
        {
            new  List<List<System.String>>().Set__Data_SuperSmall().WriteThis().DataTest_All(_IsConsole: true);
            return true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class ListPoint : List<List<double>>
        {
            public ListPoint() { }
            public ListPoint Set_Add(List<double> _LD){ this.Add(_LD); return this;}
            public ListPoint AddPoint(int i,int j) { return this.Set_Add(new List<double>().Set_Add(i).Set_Add(j));}
            public ListPoint WriteThis() { this.Select(a => System.String.Join("|", a)).ToList().ForEach(a => a.WriteLine()); return this;}
        }
        /// <summary>Получение списка пропусков</summary>
        public static ListPoint GetNaNList(this List<List<System.String>> _this) 
        {

            ListPoint _LPointXY = new ListPoint();
            for (int i = 1; i < _this.Count; i++)
                for (int j = 1; j < _this[0].Count; j++)
                    if (_this[i][j] == "NaN") _LPointXY.AddPoint(i, j);
            return _LPointXY;
        }
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 3, _day: 6, _hour: 11, _minute: 34, _second: 0, _millisecond: 0, _StrComment: "Тест;")]
        public static System.Boolean Test_1() 
        {
            new List<List<System.String>>().Set__Data_SuperSmallNaN().WriteThis().GetNaNList().WriteThis();
            return true;
        }
        /// <summary>Замена всех пропусков нулями</summary>
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
        /// <summary>Получение в виде списка списка чисел</summary>
        public static List<List<double>> Get_As_LLD(this List<List<System.String>> _this) 
        {
            if (!_this.DataTest_All()) throw new System.Exception("Eror: 2023:03:06::12:41 LLS DATA Eror");
            List<List<double>> _LLD = new List<List<double>>();
            for (int i = 1; i < _this.Count; i++)
            {
                List<System.Double> _LD = new List<double>().Set_Add(i);
                for (int j = 1; j < _this[0].Count; j++)
                {
                    System.Double q = 0;
                    System.Double.TryParse(_this[i][j], out q);
                    _LD.Add(q);
                }
               _LLD.Add(_LD);
            }
            //Переписать алгоритм
            //Шаг первый Создать LLD нужной размерности, где все не число
            //Заполнить первый столбец порядковым номером
            //Заполнить по столбцу всеми числовыми элементами попутно считая среднее арифметическое
            //Заполнить по столбцу все пропуски средним арифметическим
            //Пройти 2 теста

            //Таким образом получим что
            //Дергаем LLD и уже можем считать со среднеми арифметическими дырками
            //Получим Дефолтный уровень предобработки

            // В будующем отрефакторить все пееудоляв
            // Останется приватная функция с нанами и флаг на востанк
            return _LLD;
        }
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 03, _day: 11, _hour: 23, _minute: 48, _second: 0)]
        public static System.Boolean Test_Get_As_LLD()
        {
            new List<List<System.String>>()
                .Set__Data_SuperSmall()
                .WriteThis()
                .Get_As_LLD()
                .WriteThis();
            ;
            return true;
        }
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 03, _day: 11, _hour: 23, _minute: 49, _second: 0)]
        public static System.Boolean Test_Get_As_LLD_1()
        {
            new List<List<System.String>>()
                .Set__Data_SuperSmallNaN()
                .WriteThis()
                .Get_As_LLD()
                .WriteThis();
            ;
            return true;
        }
    }
}