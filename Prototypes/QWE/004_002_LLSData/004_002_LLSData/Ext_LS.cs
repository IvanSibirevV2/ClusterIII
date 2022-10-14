using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    /// <summary>Extension_LS</summary>
    public static class Ext_LS
    {
        #region LS.Get_Copy()
            public static List<string> Get_Copy(this List<string> _Ext_this_LS)
            {
                List<string> rez = new List<string>();
                for (int i = 0; i < _Ext_this_LS.Count(); i++)rez.Add((string)_Ext_this_LS[i].Clone());
                return rez;
            }
            public static List<List<string>> Get_Copy(this List<List<string>> _Ext_this_LLS)
            {
                List<List<string>> rez = new List<List<string>>();
                for (int i = 0; i < _Ext_this_LLS.Count(); i++)rez.Add(_Ext_this_LLS[i].Get_Copy());
                return rez;
            }
            public static List<List<List<string>>> Get_Copy(this List<List<List<string>>> _Ext_this_LLLS)
            {
                List<List<List<string>>> rez = new List<List<List<string>>>();
                for (int i = 0; i < _Ext_this_LLLS.Count(); i++)rez.Add(_Ext_this_LLLS[i].Get_Copy());
                return rez;
            }
            public static void LS_Get_Copy_Test()
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
        #region LS.writeThis()
            /// <summary>СтандартныйВыводНаэкран. Выводим LS на экран, в консоль</summary><param name="q">ДопустимоеКол-воСимволовНаЯйчейку</param>
            public static List<string> writeThis(this List<string> _Ext_LS, int q)
            {
                for (int i = 0; i < _Ext_LS.Count(); i++)Console.Write(_Ext_LS[i].SLimiter(q) + " ");
                Console.Write("\n");return _Ext_LS;
            }
            /// <summary>СтандартныйВыводНаэкран. Выводим LLS на экран, в консоль</summary><param name="q">ДопустимоеКол-воСимволовНаЯйчейку</param>
            public static List<List<string>> writeThis(this List<List<string>> _Ext_LLS, int q)
            {
                for (int i = 0; i < _Ext_LLS.Count(); i++)
                {
                    for (int j = 0; j < _Ext_LLS[i].Count(); j++)
                    {
                        string str = _Ext_LLS[i][j].SLimiter(q);
                        if ((i == 0) && (j == 0))
                        {(new Consoller_Shabloner()).Set_ColorS(ConsoleColor.Yellow, ConsoleColor.DarkRed).Write(str + " ");}
                        else if (i == 0)
                        {(new Consoller_Shabloner()).Set_ColorS(ConsoleColor.Cyan, ConsoleColor.DarkYellow).Write(str + " ");}
                        else if (j == 0)
                        {(new Consoller_Shabloner()).Set_ColorS(ConsoleColor.Cyan, ConsoleColor.DarkYellow).Write(str + " ");}
                        else if ((i > 0) && (j > 0) && (_Ext_LLS[i][j] == "NaN"))
                        {//Тяжёлый случай...Этот "перефирийный" код и так работает.
                            string qwd = "NaN";string qwa = "";
                            if (qwd.Length > q)for (int h = 0; i < q; h++)qwa = qwa + qwd[h];
                            if (qwd.Length < q)while (qwd.Length < q)qwd = " " + qwd;
                            (new Consoller_Shabloner()).Set_p_ForegroundColor(ConsoleColor.Red).Write(qwd + " ");
                        }
                        else if ((i > 0) && (j > 0))
                        {(new Consoller_Shabloner()).Write(str + " ");}
                    }
                    Console.Write("\n");
                }
                return _Ext_LLS;
            }
            /// <summary>СтандартныйВыводНаэкран
            /// Выводим LLLS на экран, в консоль</summary>
            /// <param name="q">ДопустимоеКол-воСимволовНаЯйчейку</param>
            public static List<List<List<string>>> writeThis(this List<List<List<string>>> _LLLS, int q)
            {
                foreach (List<List<string>> _LLS in _LLLS)
                    _LLS.writeThis(q);
                Console.Write("\n\n");
                return _LLLS;
            }
            public static void LS_writeThis_Test()
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
                Component.LLSDataSource.Standart_Small.Data_Super_Small().writeThis(5);
            }
        #endregion
            //////////////////////////////////////////////////////////////////////
        #region LS.Get_CopyAsILS()
            public static IList<string> Get_CopyAsILS(this List<string> _Ext_this_LS)
            {
                IList<string> rez = new List<string>();
                for (int i = 0; i < _Ext_this_LS.Count(); i++)rez.Add((string)_Ext_this_LS[i].Clone());
                return rez;
            }
            public static IList<IList<string>> Get_CopyAsILS(this List<List<string>> _Ext_this_LLS)
            {
                IList<IList<string>> rez = new List<IList<string>>();
                for (int i = 0; i < _Ext_this_LLS.Count(); i++)rez.Add(_Ext_this_LLS[i].Get_CopyAsILS());
                return rez;
            }
            public static IList<IList<IList<string>>> Get_CopyAsILS(this List<List<List<string>>> _Ext_this_LLLS)
            {
                IList<IList<IList<string>>> rez = new List<IList<IList<string>>>();
                for (int i = 0; i < _Ext_this_LLLS.Count(); i++)rez.Add(_Ext_this_LLLS[i].Get_CopyAsILS());
                return rez;
            }
            public static void LS_Get_CopyAsILS_Test()
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
            /// <summary>Возвращает истину если не отличий между двумя текстовыми строками</summary>
            public static bool Get_Counterpose(this string _Extension_this_S, string _S)
            {
                if (_Extension_this_S.Length != _S.Length)return false;
                for (int i = 0; i < _Extension_this_S.Length; i++)if (_Extension_this_S[i] != _S[i])return false;
                return true;
            }
            /// <summary>Возвращает истину если не отличий между двумя List<string></summary>
            public static bool Get_Counterpose(this List<string> _Extension_this_LS, List<string> _LS)
            {
                if (_Extension_this_LS.Count != _LS.Count)return false;
                for (int i = 0; i < _Extension_this_LS.Count; i++)if (!_Extension_this_LS[i].Get_Counterpose(_LS[i]))return false;
                return true;
            }
            /// <summary>Возвращает истину если не отличий между двумя List<List<string>></summary>
            public static bool Get_Counterpose(this List<List<string>> _Extension_this_LLS, List<List<string>> _LLS)
            {
                if (_Extension_this_LLS.Count != _LLS.Count)return false;
                for (int i = 0; i < _Extension_this_LLS.Count; i++)if (!_Extension_this_LLS[i].Get_Counterpose(_LLS[i]))return false;
                return true;
            }
            /// <summary>Возвращает истину если не отличий между двумя List<List<string>></summary>
            public static bool Get_Counterpose(this List<List<List<string>>> _Extension_this_LLLS, List<List<List<string>>> _LLLS)
            {
                if (_Extension_this_LLLS.Count != _LLLS.Count)return false;
                for (int i = 0; i < _Extension_this_LLLS.Count; i++)if (!_Extension_this_LLLS[i].Get_Counterpose(_LLLS[i]))return false;
                return true;
            }
        #endregion
        //////////////////////////////////////////////////////////////////////
        #region LS.Get_AsLLLS/Get_AsLLS
            /// <summary> ConvertListListListString_To_ListListString</summary>
            public static List<List<string>> Get_AsLLS(this List<List<List<string>>> _Extension_this_LLLS){return _Extension_this_LLLS.Get_AsLLS(false);}
            public static List<List<string>> Get_AsLLS(this List<List<List<string>>> _Extension_this_LLLS,bool _NeedDataTest)
            {//Мы не требуем того чтобю у  _Extension_this_LLL вектора параметро вбыли одинаковой длинны на случай если вдруг придётся обрабатывать и их
                //Это требовать будем средствами (!_this_ILLLS.Get_AsLLS()LLS_DataTest()) на вышестоящем иерархическом уровне, иначе будет рекурсивное зацикливание
                if (_NeedDataTest)foreach (List<List<string>> _Extension_this_LLS in _Extension_this_LLLS)
                    if (!_Extension_this_LLS.LLS_DataTest_())
                        throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!_Extension_this_LLS.LLS_DataTest())", (new StackTracer()).Get_STSS());
                ///////////////////////
                List<List<string>> rez = new List<List<string>>();
                rez.Add(_Extension_this_LLLS[0][0].Get_Copy());
                foreach (List<List<string>> _LLS in _Extension_this_LLLS)
                    for (int i = 1; i < _LLS.Count; i++)
                        rez.Add(_LLS[i].Get_Copy());
                return rez;
            }
            /// <summary> ConvertListListString_To_ListListListString</summary>
            public static List<List<List<string>>> Get_AsLLLS(this List<List<string>> _Extension_this_LLS){return _Extension_this_LLS.Get_AsLLLS(false);}
            public static List<List<List<string>>> Get_AsLLLS(this List<List<string>> _Extension_this_LLS,bool _NeedDataTest)
            {
                if (_NeedDataTest)if (!_Extension_this_LLS.LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!_Extension_this_LLS.LLS_DataTest())", (new StackTracer()).Get_STSS());
                ///////////////////////
                List<List<string>> LLS = _Extension_this_LLS.Get_Copy();
                List<List<List<string>>> rez = new List<List<List<string>>>();
                for (int i = 1; i < LLS.Count(); i++)
                {
                    List<List<string>> L_LLS = new List<List<string>>();
                    L_LLS.Add(LLS[0].Get_Copy());//Title
                    L_LLS.Add(LLS[i].Get_Copy());//Content
                    L_LLS[0][0] = "C" + Convert.ToString(i);
                    rez.Add(L_LLS);
                }
                return rez;
            }
        #endregion
        /////////////////////////////////////////////////////////////////////
        
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS()).WriteLine("");
            Component.Ext_LS.LS_Get_Copy_Test();
            Component.Ext_LS.LS_writeThis_Test();
            Component.Ext_LS.LS_Get_CopyAsILS_Test();
        }
    }
}
