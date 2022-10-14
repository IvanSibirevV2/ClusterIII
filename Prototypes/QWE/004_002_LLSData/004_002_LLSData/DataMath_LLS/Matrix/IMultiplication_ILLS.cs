using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Math.Matrix
{
    public interface IMultiplication_ILLS
    {
        //Main//////////////////////////////////////////////
        IList<IList<string>> p_A_ILLS { get; set; }
        IList<IList<string>> p_B_ILLS { get; set; }
        bool p_NeedDataTest { get; set; }
        IList<IList<string>> p_Resalt { get; set; }
        //Dop//////////////////////////////////////////////
        IProgressTime p_IProgressTime { get; set; }
        /////////////////////////////////////////////////////////
        IMultiplication_ILLS Set(Action<IMultiplication_ILLS> x);
        IMultiplication_ILLS Set_p_A_ILLS(IList<IList<string>> _p_A_ILLS);
        IMultiplication_ILLS Set_p_B_ILLS(IList<IList<string>> _p_B_ILLS);
        IMultiplication_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest);
        /////////////////////////////////////////////////////////
        IMultiplication_ILLS DO();
        IList<IList<string>> Get_Resalt();
        /////////////////////////////////////////////////////////
        IMultiplication_ILLS Get_InterfaceCopy();
        IMultiplication_ILLS Get_InterfaceNewCreateInstance();
    }
    /// <summary>
    /// Умножение матриц.
    /// A - lxm; B - mxn; C - lxn
    /// c_ij= summ(r=1..m;a_i_r*b_r_j)
    /// </summary>
    public class Multiplication_ILLS:IMultiplication_ILLS
    {
        //Main//////////////////////////////////////////////
        public IList<IList<string>> p_A_ILLS { get; set; }
        public IList<IList<string>> p_B_ILLS { get; set; }
        public bool p_NeedDataTest { get; set; }
        public IList<IList<string>> p_Resalt { get; set; }
        //Dop//////////////////////////////////////////////
        public IProgressTime p_IProgressTime { get; set; }
        /////////////////////////////////////////////////////////
        public IMultiplication_ILLS Init()
        {
            return this
                //Main//
                .Set_p_A_ILLS(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS())
                .Set_p_B_ILLS(Component.LLSDataSource.Standart.Data_Super_Small().Transpose().Get_CopyAsILS())
                .Set_p_NeedDataTest(false)
                .Set((IMultiplication_ILLS _this) => 
                {
                    _this.p_Resalt = this.p_A_ILLS.Get_InterfaseCopy();
                    //Dop//
                    _this.p_IProgressTime = new ProgressTime();                    
                })
            ;
        }
        public Multiplication_ILLS() { this.Init(); }
        /////////////////////////////////////////////////////////
        public IMultiplication_ILLS Set(Action<IMultiplication_ILLS> x) { x(this); return this; }
        public IMultiplication_ILLS Set_p_A_ILLS(IList<IList<string>> _p_A_ILLS) { this.p_A_ILLS=_p_A_ILLS; return this; }
        public IMultiplication_ILLS Set_p_B_ILLS(IList<IList<string>> _p_B_ILLS) { this.p_B_ILLS = _p_B_ILLS; return this; }
        public IMultiplication_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest) { this.p_NeedDataTest = _p_NeedDataTest; return this; }
        /////////////////////////////////////////////////////////
        public IMultiplication_ILLS DO()
        {
            this.p_IProgressTime.Set_Start();
            {
                if (this.p_NeedDataTest)
                {
                    if (!this.p_A_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!(new DataSourceTestClass (!this.p_A_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());
                    if (!this.p_B_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!(new DataSourceTestClass(_LLS.Get_Copy())).Get_Resalt())", (new StackTracer()).Get_STSS());
                    if (!(this.p_A_ILLS[0].Count == this.p_B_ILLS.Count)) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!(this.p_A_ILLS[0].Count == this.p_B_ILLS.Count))", (new StackTracer()).Get_STSS());
                    if (!(this.p_A_ILLS.Count == this.p_B_ILLS[0].Count)) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!(this.p_A_ILLS.Count == this.p_B_ILLS[0].Count))", (new StackTracer()).Get_STSS());                    
                }
                this.p_Resalt = new List<IList<string>>();this.p_Resalt.Add(this.p_B_ILLS[0].Get_InterfaseCopy());
                for (int i = 1; i < this.p_A_ILLS.Count; i++)
                {
                    List<string> qwe = (new string[] { this.p_A_ILLS[i][0] }).ToList<string>();
                    for (int j = 1; j < this.p_B_ILLS[0].Count; j++)
                    {
                        double c_ij = 0;
                        for (int r = 1; r < this.p_B_ILLS.Count; r++)
                            c_ij += Convert.ToDouble(this.p_A_ILLS[i][r]) * Convert.ToDouble(this.p_B_ILLS[r][j]);
                        qwe.Add(Convert.ToString(c_ij));
                    }
                    this.p_Resalt.Add(qwe);
                }
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public IList<IList<string>> Get_Resalt()
        {
            if(! this.p_IProgressTime.p_CalcIsLocked)this.DO();
            return this.p_Resalt;
        }
        //////////////////////////////////////////////////////////////////////////////////
        public IMultiplication_ILLS Get_InterfaceCopy()
        {
            return ((IMultiplication_ILLS)Activator.CreateInstance(this.GetType()))
                //Main//
                .Set_p_A_ILLS(this.p_A_ILLS.Get_InterfaseCopy())
                .Set_p_B_ILLS(this.p_B_ILLS.Get_InterfaseCopy())
                .Set_p_NeedDataTest(this.p_NeedDataTest)
                .Set((IMultiplication_ILLS _this) =>
                {
                    _this.p_Resalt = this.p_A_ILLS.Get_InterfaseCopy();
                    //Dop//
                    _this.p_IProgressTime = this.p_IProgressTime.Get_InterfaceCopy();
                })
            ;
        }
        public IMultiplication_ILLS Get_InterfaceNewCreateInstance() { return ((IMultiplication_ILLS)Activator.CreateInstance(this.GetType())); }
        //////////////////////////////////////////////////////////////////////////////////        
        public static void Text()
        {            
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            Console.WriteLine("Component.Math.Matrix.LLS_MultiplicationExtension.Multiplication(this List<List<string>> _LLLS_this, List<List<string>> _LLLS)");

            IMultiplication_ILLS _IMultiplication_ILLS = new Multiplication_ILLS();


            #region Штатный тест
            {
                _IMultiplication_ILLS.Set_p_NeedDataTest(true).Get_InterfaceCopy()
                    .Set_p_A_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_B_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            #endregion

            #region Вне штатный тест
            #region Вне штатный тест №1
            try
            {
                _IMultiplication_ILLS.Get_InterfaceCopy()
                    .Set_p_A_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_B_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                            ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                            ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А3",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                        }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Вне штатный тест №2
            try
            {
                _IMultiplication_ILLS.Get_InterfaceCopy()
                    .Set_p_A_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_B_ILLS
                        ((new List<string>[] {
                            (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                            ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                            ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                        }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Вне штатный тест №3
            try
            {
                _IMultiplication_ILLS.Get_InterfaceCopy()
                    .Set_p_A_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_B_ILLS
                        ((new List<string>[] {
                            (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                            ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                            ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                            //,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                        }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Вне штатный тест №4
            try
            {
                _IMultiplication_ILLS.Get_InterfaceCopy()
                    .Set_p_A_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                        //,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_B_ILLS
                        ((new List<string>[] {
                            (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                            ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                            ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                            ,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                        }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #endregion
        }
    }
    public static class LLS_MultiplicationExtension
    {
        /// <summary>
        /// Умножение матриц.
        /// A - lxm; B - mxn; C - lxn
        /// c_ij= summ(r=1..m;a_i_r*b_r_j)
        /// </summary>
        public static List<List<string>> Multiplication(this List<List<string>> _LLS_this, List<List<string>> _LLS)
        {
            return (new Multiplication_ILLS())
                .Set_p_A_ILLS(_LLS_this.Get_CopyAsILS())
                .Set_p_B_ILLS(_LLS.Get_CopyAsILS())
                .Set_p_NeedDataTest(false)
                .DO()
                .Get_Resalt()
                .Get_CopyAsLS()
                ;
        }
        public static IList<IList<string>> Multiplication(this IList<IList<string>> _ILLS_this, IList<IList<string>> _ILLS)
        {
            return (new Multiplication_ILLS())
                .Set_p_A_ILLS(_ILLS_this)
                .Set_p_B_ILLS(_ILLS)
                .Set_p_NeedDataTest(false)
                .DO().Get_Resalt()
                ;
        }
        public static void TextMultiplication()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());
            Console.WriteLine("Component.Math.Matrix.LLS_MultiplicationExtension.Multiplication(this List<List<string>> _LLLS_this, List<List<string>> _LLLS)");

            #region Штатный тест
            ((new List<string>[] {
                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                
            }).ToList<List<string>>())
            .Multiplication(
                ((new List<string>[] {
                    (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                    ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                    ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                    ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                    ,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                
                }).ToList<List<string>>())
            ).writeThis(5);
            #endregion

            #region Вне штатный тест
            #region Вне штатный тест №1
            try
            {

                ((new List<string>[] {
                    (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                    ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                
                }).ToList<List<string>>())
                .Multiplication(
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                
                    }).ToList<List<string>>())
                ).writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Вне штатный тест №2
            try
            {

                ((new List<string>[] {
                    (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                    ,(new string[] {"А2",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                
                }).ToList<List<string>>())
                .Multiplication(
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                
                    }).ToList<List<string>>())
                ).writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Вне штатный тест №3
            try
            {

                ((new List<string>[] {
                    (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                    ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                
                }).ToList<List<string>>())
                .Multiplication(
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                        //,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                
                    }).ToList<List<string>>())
                ).writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Вне штатный тест №4
            try
            {

                ((new List<string>[] {
                    (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                    //,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                
                }).ToList<List<string>>())
                .Multiplication(
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А4",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А5",	"1",	"0",	"0"}).ToList<string>()
                
                    }).ToList<List<string>>())
                ).writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #endregion
        }
    }
}