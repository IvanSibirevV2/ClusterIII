using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Math.Matrix
{
    public interface IDeterminant_ILLS
    {
        //Main/////////////////////////////////////////////////////////////////////////
        IList<IList<string>> p_ILLS { get; set; }
        bool p_NeedDataTest { get; set; }
        double p_Resalt { get; set; }
        //Dop/////////////////////////////////////////////////////////////////////////
        IProgressTime p_IProgressTime { get; set; }
        ////////////////////////////////////////////////////////
        IDeterminant_ILLS Set(Action<IDeterminant_ILLS> x);
        IDeterminant_ILLS Set_p_ILLS(IList<IList<string>> _p_ILLS);
        IDeterminant_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest);
        ////////////////////////////////////////////////////////
        IDeterminant_ILLS Do();
        double Get_Resalt();
        ////////////////////////////////////////////////////////
        IDeterminant_ILLS Get_InterfaceCopy();
        IDeterminant_ILLS Get_InterfaceNewCreateInstance();
    }
    public class DeterminantV0_ILLS : IDeterminant_ILLS
    {
        //Main/////////////////////////////////////////////////////////////////////////
        public IList<IList<string>> p_ILLS { get; set; }
        public bool p_NeedDataTest { get; set; }
        public double p_Resalt{get; set;}
        //Dop/////////////////////////////////////////////////////////////////////////
        public IProgressTime p_IProgressTime { get; set; }
        
        private IDeterminant_ILLS Init()
        {
            return this
            //Main//
                .Set_p_ILLS(
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"6",	"4",	"1"	}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                        ,(new string[] {"А4",	"1",	"1",	"2",	"2",	"3"	}).ToList<string>()	
                        ,(new string[] {"А5",	"1",	"8",	"0",	"1",	"1"	}).ToList<string>()	
                    }).ToList<List<string>>()).Get_CopyAsILS()
                )
                .Set_p_NeedDataTest(false)
                .Set((IDeterminant_ILLS _this)=>
                {
                    _this.p_Resalt = 0;
                    //Dop//
                    _this.p_IProgressTime = new ProgressTime();
                })
            ;
        }
        public DeterminantV0_ILLS(){this.Init();}
        ////////////////////////////////////////////////////////
        public IDeterminant_ILLS Set(Action<IDeterminant_ILLS> x) { x(this); return this; }
        public IDeterminant_ILLS Set_p_ILLS(IList<IList<string>> _p_ILLS) { this.p_ILLS = _p_ILLS; return this; }
        public IDeterminant_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest) { this.p_NeedDataTest = _p_NeedDataTest; return this; }
        ////////////////////////////////////////////////////////
        public virtual IDeterminant_ILLS Do()
        {
            this.p_IProgressTime.Set_Start();
            {
                if(this.p_NeedDataTest)
                {
                    if (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_())throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());
                    if (!(this.p_ILLS.Count() == this.p_ILLS[0].Count()))throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!(this.p_ILLS.Count() == this.p_ILLS[0].Count()))", (new StackTracer()).Get_STSS());
                }
                if ((this.p_ILLS.Count == 2) && (this.p_ILLS[0].Count == 2))
                { this.p_Resalt = Convert.ToDouble(this.p_ILLS[1][1]); return this; }
                double rez = 0;
                for (int i = 1; i < this.p_ILLS.Count; i++)
                {
                    double q = System.Math.Pow(-1, i + 1);
                    double w = Convert.ToDouble(this.p_ILLS[i][1]);
                    double e = this.Get_InterfaceNewCreateInstance().Set_p_NeedDataTest(false)//Отключаем рекурсивные дата тесты чтобы не тратитьь время
                        .Set_p_ILLS(
							(new Minor_ILLS())
								.Set_p_ILLS(this.p_ILLS.Get_InterfaseCopy())
								.Set_p_i(i).Set_p_j(1)
								.DO()
								.Get_Resalt().Get_InterfaseCopy()
                        ).Do().Get_Resalt();
                    rez += q * w * e;
                }
                this.p_Resalt = rez;
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public double Get_Resalt(){if (!this.p_IProgressTime.p_CalcIsLocked) this.Do();return this.p_Resalt;}
        ////////////////////////////////////////////////////////
        public IDeterminant_ILLS Get_InterfaceCopy()
        {
            //return null;
            return this
                //Main//
                .Set_p_ILLS(this.p_ILLS.Get_InterfaseCopy())
                .Set_p_NeedDataTest(this.p_NeedDataTest)
                .Set((IDeterminant_ILLS _this) =>
                {
                    _this.p_Resalt = this.p_Resalt;
                    //Dop//
                    _this.p_IProgressTime = new ProgressTime();
                })
            ;
        }
        public IDeterminant_ILLS Get_InterfaceNewCreateInstance() { return ((IDeterminant_ILLS)Activator.CreateInstance(this.GetType())); }
        ////////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            IDeterminant_ILLS _IDeterminant = (new Component.Math.Matrix.DeterminantV0_ILLS()).Set_p_NeedDataTest(true);
            #region Штатный тест
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест");
                _IDeterminant.Get_InterfaceCopy()
                    .Set((IDeterminant_ILLS _this) => { _this.p_ILLS.writeThis(5); }).Do();
                Console.WriteLine("Determinant=" + Convert.ToString(_IDeterminant.Get_Resalt()));
            }
            #endregion
            #region Не штатный тест
            {
                #region Не штатный тест №1
                try
                {
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не Штатный тест");
                    _IDeterminant.Get_InterfaceCopy()
                        .Set_p_ILLS(
                            ((new List<string>[] {
                                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                                ,(new string[] {"А2",	"1",	"1",	"6",	"4",	"1"	}).ToList<string>()	
                                ,(new string[] {"А3",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                                ,(new string[] {"А4",	"1",	"1",	"2",	"2",	"3"	}).ToList<string>()	
                                ,(new string[] {"А5",	"1",	"8",	"0",	"1",	"1"	}).ToList<string>()	
                            }).ToList<List<string>>()).Get_CopyAsILS()
                        ).Do();
                }
                catch (ArgumentException e) 
                {(new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
                #endregion
                #region Не штатный тест №2
                
                try
                {
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не Штатный тест");
                    _IDeterminant.Get_InterfaceCopy()
                        .Set_p_ILLS(
                            ((new List<string>[] {
                                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                                ,(new string[] {"А2",	"1",	"1",	"6",	"4",	"1"	}).ToList<string>()	
                                ,(new string[] {"А4",	"1",	"1",	"2",	"2",	"3"	}).ToList<string>()	
                                ,(new string[] {"А5",	"1",	"8",	"0",	"1",	"1"	}).ToList<string>()	
                            }).ToList<List<string>>()).Get_CopyAsILS()
                        ).Do();            
                }
                catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }                 
                #endregion
                #region Не штатный тест №3
                
                try
                {
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не Штатный тест");
                    _IDeterminant.Get_InterfaceCopy()
                        .Set_p_ILLS(
                            ((new List<string>[] {
                                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                                ,(new string[] {"А2",	"1",	"1",	"6",	"4",	"1"	}).ToList<string>()	
                                ,(new string[] {"А3",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                                ,(new string[] {"А4",	"1",	"1",	"2",	"2",	"3"	}).ToList<string>()	
                                ,(new string[] {"А5",	"1",	"8",	"0",	"1",	"1"	}).ToList<string>()	
                            }).ToList<List<string>>()).Get_CopyAsILS()
                        ).Do();
                }
                catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
                #endregion
                #region Не штатный тест №4                
                try
                {
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не Штатный тест");
                    _IDeterminant.Get_InterfaceCopy()
                        .Set_p_ILLS(
                            ((new List<string>[] {
                                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                                ,(new string[] {"А2",	"1",	"1",	"6",	"4",	"1"	}).ToList<string>()	
                                ,(new string[] {"А4",	"1",	"1",	"2",	"2",	"3"	}).ToList<string>()	
                                ,(new string[] {"А5",	"1",	"8",	"0",	"1",	"1"	}).ToList<string>()	
                            }).ToList<List<string>>()).Get_CopyAsILS()
                        ).Do();
                }
                catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
                #endregion
            }
            #endregion
        }
    }
}

