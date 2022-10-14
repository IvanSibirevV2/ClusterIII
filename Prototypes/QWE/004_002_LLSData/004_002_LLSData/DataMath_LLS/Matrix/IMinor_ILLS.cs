using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Math.Matrix
{
    public interface IMinor_ILLS
    {
        IList<IList<string>> p_ILLS { get; set; }
        int p_i { get; set; }
        int p_j { get; set; }
        IList<IList<string>> p_Resalt { get; set; }
        bool p_NeedDataTest { get; set; }
        IProgressTime p_IProgressTime {get; set;}
        /////////////////////////////////////////////////////////
        IMinor_ILLS Set(Action<IMinor_ILLS> x);
        IMinor_ILLS Set_p_ILLS(IList<IList<string>> _p_ILLS);
        IMinor_ILLS Set_p_i(int _p_i);
        IMinor_ILLS Set_p_j(int _p_j);
        IMinor_ILLS Set_p_ij(int _p_i, int _p_j);
        IMinor_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest);
        /////////////////////////////////////////////////////////
        IMinor_ILLS DO();
        IList<IList<string>> Get_Resalt();
        /////////////////////////////////////////////////////////
        IMinor_ILLS Get_InterfaceCopy();
        IMinor_ILLS Get_InterfaceNewCreateInstance();
        /////////////////////////////////////////////////////////
    }
    public class Minor_ILLS : IMinor_ILLS
    {
        public IList<IList<string>> p_ILLS { get; set; }
        public int p_i { get; set; }
        public int p_j { get; set; }
        public IList<IList<string>> p_Resalt {get; set;}
        public bool p_NeedDataTest { get; set; }
        public IProgressTime p_IProgressTime {get; set;}
        /////////////////////////////////////////////////////////
        public IMinor_ILLS Init()
        {
            return this
                .Set_p_ILLS(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS())
                .Set_p_i(1).Set_p_j(1).Set_p_NeedDataTest(false)
                .Set((IMinor_ILLS _this)=>
                {
                    _this.p_IProgressTime = new ProgressTime();
                    _this.p_Resalt = _this.p_ILLS.Get_InterfaseCopy();
                })
            ;
        }
        public Minor_ILLS() { this.Init(); }
        /////////////////////////////////////////////////////////
        public IMinor_ILLS Set(Action<IMinor_ILLS> x) { x(this); return this; }
        public IMinor_ILLS Set_p_ILLS(IList<IList<string>> _p_ILLS) { this.p_ILLS = _p_ILLS; return this; }
        public IMinor_ILLS Set_p_i(int _p_i) { this.p_i = _p_i; return this; }
        public IMinor_ILLS Set_p_j(int _p_j) { this.p_j = _p_j; return this; }
        public IMinor_ILLS Set_p_ij(int _p_i,int _p_j) { return this.Set_p_i(_p_i).Set_p_j(_p_j); }
        public IMinor_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest) { this.p_NeedDataTest = _p_NeedDataTest; return this; }
        /////////////////////////////////////////////////////////
        public IMinor_ILLS DO()
        {
            this.p_IProgressTime.Set_Start();
            {
                if (this.p_NeedDataTest)
                {
                    if (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_(this.p_NeedDataTest)) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_(this.p_NeedDataTest))", (new StackTracer()).Get_STSS());
                    if (this.p_i < 1) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (this.p_i < 1)", (new StackTracer()).Get_STSS());
                    if (this.p_j < 1) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (this.p_j < 1)", (new StackTracer()).Get_STSS());
                    if (this.p_i > this.p_ILLS.Count() - 1) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (this.p_i > this.p_ILLS.Count() - 1)", (new StackTracer()).Get_STSS());
                    if (this.p_j > this.p_ILLS[this.p_i].Count() - 1) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (this.p_j > this.p_ILLS[this.p_i].Count() - 1)", (new StackTracer()).Get_STSS());
                    if (this.p_ILLS[this.p_i].Count() < 3) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (this.p_ILLS[this.p_i].Count() < 3)", (new StackTracer()).Get_STSS());
                    if (this.p_ILLS.Count() < 3) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (this.p_ILLS.Count() < 3)", (new StackTracer()).Get_STSS());
                }
                this.p_Resalt = this.p_ILLS.Get_InterfaseCopy();
                this.p_Resalt.RemoveAt(this.p_i);
                foreach (IList<string> _ILS in this.p_Resalt)_ILS.RemoveAt(this.p_j);
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public IList<IList<string>> Get_Resalt()
        {
            if (!this.p_IProgressTime.p_CalcIsLocked) this.DO();
            return this.p_Resalt;
        }
        //////////////////////////////////////////////////////////////////////////////////
        public IMinor_ILLS Get_InterfaceCopy()
        {
            return ((IMinor_ILLS)Activator.CreateInstance(this.GetType()))
                .Set_p_ILLS(this.p_ILLS.Get_InterfaseCopy())
                .Set_p_i(this.p_i)
                .Set_p_j(this.p_j)
                .Set_p_NeedDataTest(this.p_NeedDataTest)
                .Set((IMinor_ILLS _this) => 
                {
                    ;
                    _this.p_Resalt=this.p_Resalt.Get_InterfaseCopy();
                    _this.p_IProgressTime = this.p_IProgressTime.Get_InterfaceCopy();
                })
            ;
        }
        public IMinor_ILLS Get_InterfaceNewCreateInstance() { return ((IMinor_ILLS)Activator.CreateInstance(this.GetType())); }
        //////////////////////////////////////////////////////////////////////////////////
        public static void Text()
        {

            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            IMinor_ILLS _IMinor_ILLS = new Minor_ILLS();
            Console.WriteLine("Component.Math.Matrix.LLS_MinorExtension.Minor(this List<List<string>> _LLS_this, int i, int j)");
            #region Штатные тесты
            ;
            _IMinor_ILLS.Set_p_NeedDataTest(true).Get_InterfaceCopy()
                //.Set((IMinor_ILLS _this) => { _this.p_ILLS.writeThis(5); })
                .Set_p_ij(3, 5).DO().Get_Resalt().writeThis(5);
            #endregion
            
            #region НеШтатные тесты
            #region НеШтатные тесты #1
            if (true)
            //Тест устарел и не сработает, так как будет пойман методом List<List<string>> _this_LLS_.Get_CopyAsILS()
            try
            {
                _IMinor_ILLS.Get_InterfaceCopy()
                    .Set_p_ILLS
                    ((new List<string>[] {
                    (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                    ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                    ,(new string[] {"А4",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                    ,(new string[] {"А5",	"1",		"0",	"1",	"1"	}).ToList<string>()	
                    ,(new string[] {"А6",	"0",	"0",	"0",	"0",	"0"	}).ToList<string>()	
                    ,(new string[] {"А7",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                    ,(new string[] {"А8",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А9",	"1",	"1",	"1",	"1",	"1"	}).ToList<string>()	
                    ,(new string[] {"А10",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_ij(3, 2).DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region НеШтатные тесты #2
            if(true)
            try
            {
                _IMinor_ILLS.Get_InterfaceCopy().Set_p_ij(-1, 2).DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region НеШтатные тесты #3
            if(true)
            try
            {
                {
                    _IMinor_ILLS.Get_InterfaceCopy()
                        .Set_p_ILLS
                        ((new List<string>[] {
                            (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                            ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                        }).ToList<List<string>>().Get_CopyAsILS())
                        .Set_p_ij(1, 2).DO().Get_Resalt().writeThis(5);
                }
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region НеШтатные тесты #4
            if(true)
            try
            {
                _IMinor_ILLS.Get_InterfaceCopy()
                    .Set_p_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                        ,(new string[] {"А4",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                        ,(new string[] {"А5",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                        ,(new string[] {"А6",	"0",	"0",	"0",	"0",	"0"	}).ToList<string>()	
                        ,(new string[] {"А7",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                        ,(new string[] {"А8",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                        ,(new string[] {"А9",	"1",	"1",	"1",	"1",	"1"	}).ToList<string>()	
                        ,(new string[] {"А10",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_ij(3, -1).DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region НеШтатные тесты #5
            if(true)
            try
            {
                _IMinor_ILLS.Get_InterfaceCopy()
                    .Set_p_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1"}).ToList<string>()
                        ,(new string[] {"А1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1"}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_ij(1, 1).DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #endregion
        }
            
    }
    public static class LLS_MinorExtension
    {
        /// <summary>Удаляет одну строку и столбец. Входные дапнные предварительно копируются (создание объекта-копии)</summary>
        public static List<List<string>> Minor(this List<List<string>> _LLS_this, int i, int j){return _LLS_this.Minor(i, j, false);}
        public static List<List<string>> Minor(this List<List<string>> _LLS_this, int i, int j,bool _NeedDataTest)
        {
            return (new Minor_ILLS())
                .Set_p_ILLS(_LLS_this.Get_CopyAsILS())
                .Set_p_i(i)
                .Set_p_j(j)
                .Set_p_NeedDataTest(_NeedDataTest)
                .DO()
                .Get_Resalt()
                .Get_CopyAsLS()
                ;
        }
    }
}
