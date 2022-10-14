using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////////////////////////////////////////////////
using System.Xml;
using System.Web.Script.Serialization;//++System.Web.Extensions

namespace Component
{
    /// <summary>Extension_ILS</summary>
    public static class Ext_ILS
    {
        #region ILS.Get_InterfaseCopy()
            public static IList<string> Get_InterfaseCopy(this IList<string> _Ext_this_ILS)
            {
                IList<string> rez = new List<string>();
                for (int i = 0; i < _Ext_this_ILS.Count(); i++) rez.Add((string)_Ext_this_ILS[i].Clone());
                return rez;
            }
            public static IList<IList<string>> Get_InterfaseCopy(this IList<IList<string>> _Ext_this_ILLS)
            {
                IList<IList<string>> rez = new List<IList<string>>();
                for (int i = 0; i < _Ext_this_ILLS.Count(); i++)rez.Add(_Ext_this_ILLS[i].Get_InterfaseCopy());
                return rez;
            }
            public static IList<IList<IList<string>>> Get_InterfaseCopy(this IList<IList<IList<string>>> _Ext_this_ILLLS)
            {
                IList<IList<IList<string>>> rez = new List<IList<IList<string>>>();
                for (int i = 0; i < _Ext_this_ILLLS.Count(); i++)rez.Add(_Ext_this_ILLLS[i].Get_InterfaseCopy());
                return rez;
            }
            public static void ILS_Get_InterfaseCopy_Test()
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                    .WriteLine((new Component.StackTracer()).Get_STSS());
                Console.WriteLine("Ru:");
                Console.WriteLine("Тест не реализован");
                Console.WriteLine("Реализация теста пока не требуется");
                Console.WriteLine("Тестить сдесь нечего");
                Console.WriteLine("En:");
                Console.WriteLine("Test not implemented");
                Console.WriteLine("Test implementation is not required yet");
                Console.WriteLine("There is nothing to test here");
            }
        #endregion
        //////////////////////////////////////////////////////////////////////
        #region ILS.writeThis()
            /// <summary>СтандартныйВыводНаэкран. Выводим LS на экран, в консоль</summary><param name="q">ДопустимоеКол-воСимволовНаЯйчейку</param>
            public static IList<string> writeThis(this IList<string> _Ext_ILS, int q)
            {
                for (int i = 0; i < _Ext_ILS.Count(); i++) Console.Write(_Ext_ILS[i].SLimiter(q) + " ");
                Console.Write("\n");
                return _Ext_ILS;
            }
            /// <summary>СтандартныйВыводНаэкран. Выводим LLS на экран, в консоль</summary><param name="q">ДопустимоеКол-воСимволовНаЯйчейку</param>
            public static IList<IList<string>> writeThis(this IList<IList<string>> _Ext_ILLS, int q)
            {
                for (int i = 0; i < _Ext_ILLS.Count(); i++)
                {
                    for (int j = 0; j < _Ext_ILLS[i].Count(); j++)
                    {
                        string str = _Ext_ILLS[i][j].SLimiter(q);
                        if ((i == 0) && (j == 0))
                        {(new Consoller_Shabloner()).Set_ColorS(ConsoleColor.Yellow, ConsoleColor.DarkRed).Write(str + " ");}
                        else if (i == 0)
                        {(new Consoller_Shabloner()).Set_ColorS(ConsoleColor.Cyan, ConsoleColor.DarkYellow).Write(str + " ");}
                        else if (j == 0)
                        {(new Consoller_Shabloner()).Set_ColorS(ConsoleColor.Cyan, ConsoleColor.DarkYellow).Write(str + " ");}
                        else if ((i > 0) && (j > 0) && (_Ext_ILLS[i][j] == "NaN"))
                        {//Тяжёлый случай...Этот "перефирийный" код и так работает.
                            string qwd = "NaN";
                            string qwa = "";
                            if (qwd.Length > q)for (int h = 0; i < q; h++)qwa = qwa + qwd[h];
                            if (qwd.Length < q)while (qwd.Length < q)qwd = " " + qwd;
                            (new Consoller_Shabloner()).Set_p_ForegroundColor(ConsoleColor.Red).Write(qwd + " ");
                        }
                        else if ((i > 0) && (j > 0))
                        {(new Consoller_Shabloner()).Write(str + " ");}
                    }
                    Console.Write("\n");
                }
                return _Ext_ILLS;
            }
            /// <summary>СтандартныйВыводНаэкран. Выводим LLLS на экран, в консоль</summary><param name="q">ДопустимоеКол-воСимволовНаЯйчейку</param>
            public static IList<IList<IList<string>>> writeThis(this IList<IList<IList<string>>> _ILLLS, int q)
            {
                foreach (IList<IList<string>> _ILLS in _ILLLS)_ILLS.writeThis(q);
                Console.Write("\n\n");
                return _ILLLS;
            }
            public static void ILS_writeThis_Test()
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
                Component.LLSDataSource.Standart_Small.Data_Super_Small().Get_CopyAsILS().writeThis(5);
            }
        #endregion
        //////////////////////////////////////////////////////////////////////
        #region ILS.Get_CopyAsLS()
            public static List<string> Get_CopyAsLS(this IList<string> _Ext_this_ILS)
            {
                List<string> rez = new List<string>();
                for (int i = 0; i < _Ext_this_ILS.Count(); i++)rez.Add((string)_Ext_this_ILS[i].Clone());
                return rez;
            }
            public static List<List<string>> Get_CopyAsLS(this IList<IList<string>> _Ext_this_ILLS)
            {
                List<List<string>> rez = new List<List<string>>();
                for (int i = 0; i < _Ext_this_ILLS.Count(); i++)rez.Add(_Ext_this_ILLS[i].Get_CopyAsLS());
                return rez;
            }
            public static List<List<List<string>>> Get_CopyAsLS(this IList<IList<IList<string>>> _Ext_this_ILLLS)
            {
                List<List<List<string>>> rez = new List<List<List<string>>>();
                for (int i = 0; i < _Ext_this_ILLLS.Count(); i++)rez.Add(_Ext_this_ILLLS[i].Get_CopyAsLS());
                return rez;
            }
            public static void IL_Get_CopyAsLS_Test()
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
                Console.WriteLine("Ru:");
                Console.WriteLine("Тест не реализован");
                Console.WriteLine("Реализация теста пока не требуется");
                Console.WriteLine("Тестить сдесь нечего");
                Console.WriteLine("En:");
                Console.WriteLine("Test not implemented");
                Console.WriteLine("Test implementation is not required yet");
                Console.WriteLine("There is nothing to test here");
            }
        #endregion
        //////////////////////////////////////////////////////////////////////
        #region Get_Counterpose
            /// <summary>Возвращает истину если не отличий между двумя List<string></summary>
            public static bool Get_Counterpose(this IList<string> _this_ILS, IList<string> _ILS)
            {
                if (_this_ILS.Count != _ILS.Count) return false;
                for (int i = 0; i < _this_ILS.Count; i++) if (!_this_ILS[i].Get_Counterpose(_ILS[i])) return false;
                return true;
            }
            /// <summary>Возвращает истину если не отличий между двумя List<List<string>></summary>
            public static bool Get_Counterpose(this IList<IList<string>> _this_ILLS, IList<IList<string>> _ILLS)
            {
                if (_this_ILLS.Count != _ILLS.Count) return false;
                for (int i = 0; i < _this_ILLS.Count; i++) if (!_this_ILLS[i].Get_Counterpose(_ILLS[i])) return false;
                return true;
            }
            /// <summary>Возвращает истину если не отличий между двумя List<List<string>></summary>
            public static bool Get_Counterpose(this IList<IList<IList<string>>> _this_ILLLS, IList<IList<IList<string>>> _ILLLS)
            {
                if (_this_ILLLS.Count != _ILLLS.Count) return false;
                for (int i = 0; i < _this_ILLLS.Count; i++) if (!_this_ILLLS[i].Get_Counterpose(_ILLLS[i])) return false;
                return true;
            }
        #endregion
        /////////////////////////////////////////////////////////////////////
        #region ILS.Get_AsILLLS/Get_AsILLS
        /// <summary> ConvertIListIListIListString_To_IListIListString</summary>
        public static IList<IList<string>> Get_AsILLS(this IList<IList<IList<string>>> _Extension_this_ILLLS) { return _Extension_this_ILLLS.Get_AsILLS(false); }
        public static IList<IList<string>> Get_AsILLS(this IList<IList<IList<string>>> _Extension_this_ILLLS, bool _NeedDataTest)
        {//Мы не требуем того чтобю у  _Extension_this_LLL вектора параметро вбыли одинаковой длинны на случай если вдруг придётся обрабатывать и их
         //Это требовать будем средствами (!_this_ILLLS.Get_AsLLS()LLS_DataTest()) на вышестоящем иерархическом уровне, иначе будет рекурсивное зацикливание
            if (_NeedDataTest) foreach (IList<IList<string>> _Extension_this_ILLS in _Extension_this_ILLLS)
                    if (!_Extension_this_ILLS.Get_CopyAsLS().LLS_DataTest_())
                        throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!_Extension_this_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());
            ///////////////////////
            IList<IList<string>> rez = new List<IList<string>>();
            rez.Add(_Extension_this_ILLLS[0][0].Get_InterfaseCopy());
            foreach (IList<IList<string>> _ILLS in _Extension_this_ILLLS)
                for (int i = 1; i < _ILLS.Count; i++)
                    rez.Add(_ILLS[i].Get_InterfaseCopy());
            return rez;
        }
        /// <summary> ConvertIListIListString_To_IListIListIListString</summary>
        public static IList<IList<IList<string>>> Get_AsILLLS(this IList<IList<string>> _Extension_this_ILLS) { return _Extension_this_ILLS.Get_AsILLLS(false); }
        public static IList<IList<IList<string>>> Get_AsILLLS(this IList<IList<string>> _Extension_this_ILLS, bool _NeedDataTest)
        {
            if (_NeedDataTest) if (!_Extension_this_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!_Extension_this_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());
            ///////////////////////
            IList<IList<string>> ILLS = _Extension_this_ILLS.Get_InterfaseCopy();
            IList<IList<IList<string>>> rez = new List<IList<IList<string>>>();
            for (int i = 1; i < ILLS.Count(); i++)
            {
                IList<IList<string>> L_ILLS = new List<IList<string>>();
                L_ILLS.Add(ILLS[0].Get_InterfaseCopy());//Title
                L_ILLS.Add(ILLS[i].Get_InterfaseCopy());//Content
                L_ILLS[0][0] = "C" + Convert.ToString(i);
                rez.Add(L_ILLS);
            }
            return rez;
        }
        #endregion
        /////////////////////////////////////////////////////////////////////
        public static IList<IList<string>> Get_GroupCluster(this IList<IList<IList<string>>> _this_ILLLS_Ext, int _i, int _j)
        {
            IList<IList<string>> _ILLS_GroupCluster = _this_ILLLS_Ext[System.Math.Max(_i, _j)].Get_InterfaseCopy();
            IList<IList<string>> _ILLS_newAdder_Min = _this_ILLLS_Ext[System.Math.Min(_i, _j)].Get_InterfaseCopy();
            for (int i = 1; i < _ILLS_newAdder_Min.Count; i++)
                _ILLS_GroupCluster.Add(_ILLS_newAdder_Min[i].Get_InterfaseCopy());
            return _ILLS_GroupCluster;
        }
        /////////////////////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS()).WriteLine("");
            Component.Ext_ILS.ILS_Get_InterfaseCopy_Test();
            Component.Ext_ILS.ILS_writeThis_Test();
            Component.Ext_ILS.IL_Get_CopyAsLS_Test();
        }
    }
}
namespace Component.Json
{
    /// <summary>Extension_ILS</summary>
    public static class Ext_ILS_1
    {
        /////////////////////////////////////////////////////////////////////
        public static string Get_AS_Json_String(this IList<IList<string>> _this_ILLS_Ext)
        {return (new JavaScriptSerializer()).Serialize(_this_ILLS_Ext);}
        public static IList<IList<string>> Get_AS_Json_ILLS(this string _this_S_Ext)
        { return (IList<IList<string>>)(new JavaScriptSerializer()).Deserialize<IList<IList<string>>>(_this_S_Ext); }
        /////////////////////////////////////////////////////////////////////
    }
}