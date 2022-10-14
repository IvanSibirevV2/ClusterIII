using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Math.Matrix
{
    public interface ISum_ILLS
    {
        //Main///////////////////////////////////////////////////////
        IList<IList<string>> p_A_ILLS { get; set; }
        IList<IList<string>> p_B_ILLS { get; set; }
        bool p_NeedDataTest { get; set; }
        IList<IList<string>> p_Resalt { get; set; }
        //Dop///////////////////////////////////////////////////////
        IProgressTime p_IProgressTime { get; set; }
        /////////////////////////////////////////////////////////
        ISum_ILLS Set(Action<ISum_ILLS> x);
        ISum_ILLS Set_p_A_ILLS(IList<IList<string>> _p_A_ILLS);
        ISum_ILLS Set_p_B_ILLS(IList<IList<string>> _p_B_ILLS);
        ISum_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest);
        /////////////////////////////////////////////////////////
        ISum_ILLS DO();
        IList<IList<string>> Get_Resalt();
        /////////////////////////////////////////////////////////
        ISum_ILLS Get_InterfaceCopy();
        IMinor_ILLS Get_InterfaceNewCreateInstance();
    }
    public class Sum_ILLS : ISum_ILLS
    {
        //Main///////////////////////////////////////////////////////
        public IList<IList<string>> p_A_ILLS { get; set; }
        public IList<IList<string>> p_B_ILLS { get; set; }
        public bool p_NeedDataTest { get; set; }
        public IList<IList<string>> p_Resalt { get; set; }
        //Dop///////////////////////////////////////////////////////
        public IProgressTime p_IProgressTime { get; set; }
        public ISum_ILLS Init()
        {
            return this
                //Main//
                .Set_p_A_ILLS(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS())
                .Set_p_B_ILLS(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS())
                .Set_p_NeedDataTest(false)
                .Set((ISum_ILLS _this)=>
                {
                    _this.p_Resalt = _this.p_A_ILLS.Get_InterfaseCopy();
                    //Dop//
                    _this.p_IProgressTime=new ProgressTime();
                })
                ;
        }
        public Sum_ILLS() { this.Init(); }
        /////////////////////////////////////////////////////////
        public ISum_ILLS Set(Action<ISum_ILLS> x) { x(this); return this; }
        public ISum_ILLS Set_p_A_ILLS(IList<IList<string>> _p_A_ILLS) { this.p_A_ILLS = _p_A_ILLS; return this; }
        public ISum_ILLS Set_p_B_ILLS(IList<IList<string>> _p_B_ILLS) { this.p_B_ILLS=_p_B_ILLS; return this; }
        public ISum_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest) { this.p_NeedDataTest = _p_NeedDataTest; return this; }
        /////////////////////////////////////////////////////////
        public ISum_ILLS DO()
        {
            this.p_IProgressTime.Set_Start();
            {
                if(this.p_NeedDataTest)
                {
                    if (!this.p_A_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!(new DataSourceTestClass (!this.p_A_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());
                    if (!this.p_B_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!(new DataSourceTestClass(_LLS.Get_Copy())).Get_Resalt())", (new StackTracer()).Get_STSS());
                    if (this.p_A_ILLS.Count() != this.p_B_ILLS.Count()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!(new DataSourceTestClass (this.p_A_ILLS.Count() != this.p_B_ILLS.Count())", (new StackTracer()).Get_STSS());
                    if (this.p_A_ILLS[0].Count() != this.p_B_ILLS[0].Count()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (this.p_A_ILLS[0].Count() != this.p_B_ILLS[0].Count())", (new StackTracer()).Get_STSS());
                }
                this.p_Resalt = this.p_A_ILLS.Get_InterfaseCopy();
                for (int i = 1; i < this.p_A_ILLS.Count; i++)
                    for (int j = 1; j < this.p_A_ILLS[i].Count; j++)
                        this.p_Resalt[i][j] = Convert.ToString(Convert.ToDouble(this.p_A_ILLS[i][j]) + Convert.ToDouble(this.p_B_ILLS[i][j]));
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public IList<IList<string>> Get_Resalt(){if (!this.p_IProgressTime.p_CalcIsLocked) this.DO();return this.p_Resalt;}
        //////////////////////////////////////////////////////////////////////////////////
        public ISum_ILLS Get_InterfaceCopy()
        {
            return ((ISum_ILLS)Activator.CreateInstance(this.GetType()))
                //Main//
                .Set_p_A_ILLS(this.p_A_ILLS.Get_InterfaseCopy())
                .Set_p_B_ILLS(this.p_B_ILLS.Get_InterfaseCopy())
                .Set_p_NeedDataTest(this.p_NeedDataTest)
                .Set((ISum_ILLS _this) =>
                {
                    _this.p_Resalt = this.p_Resalt.Get_InterfaseCopy();
                    //Dop//
                    _this.p_IProgressTime = this.p_IProgressTime.Get_InterfaceCopy();
                })
            ;
        }
        public IMinor_ILLS Get_InterfaceNewCreateInstance() { return ((IMinor_ILLS)Activator.CreateInstance(this.GetType())); }
        //////////////////////////////////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            Console.WriteLine("Component.Math.Matrix.public static class LLS_SumExtension.Sum(this List<List<string>> _LLS_this, List<List<string>> _LLS)");
            ISum_ILLS _ISum_ILLS = new Sum_ILLS();
            #region Штатный тест
            _ISum_ILLS.Set_p_NeedDataTest(true).Get_InterfaceCopy()
                .Set_p_A_ILLS
                ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                }).ToList<List<string>>().Get_CopyAsILS())
                .Set_p_B_ILLS
                ((new List<string>[] {
                    (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                    ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                    ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                }).ToList<List<string>>().Get_CopyAsILS())
                .DO().Get_Resalt().writeThis(5);
            #endregion
            #region Не штатный тест
            #region Не штатный тест №1
            try
            {
                _ISum_ILLS.Get_InterfaceCopy()
                    .Set_p_A_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_B_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Не штатный тест №2
            try
            {
                _ISum_ILLS.Get_InterfaceCopy()
                    .Set_p_A_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_B_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Не штатный тест №3
            try
            {
                _ISum_ILLS.Get_InterfaceCopy()
                    .Set_p_A_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_B_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Не штатный тест №4
            try
            {
                _ISum_ILLS.Get_InterfaceCopy()
                    .Set_p_A_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1"}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .Set_p_B_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()	
                        ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()	
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()	
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #endregion
        }

    }

    public static class LLS_SumExtension
    {
        public static List<List<string>> Sum(this List<List<string>> _LLS_this, List<List<string>> _LLS)
        {
            return (new Sum_ILLS())
                .Set_p_A_ILLS(_LLS_this.Get_CopyAsILS())
                .Set_p_B_ILLS(_LLS.Get_CopyAsILS())
                .DO()
                .Get_Resalt()
                .Get_CopyAsLS()
                ;
        }
        public static IList<IList<string>> Sum(this IList<IList<string>> _ILLS_this, IList<IList<string>> _ILLS)
        {
            return (new Sum_ILLS())
                .Set_p_A_ILLS(_ILLS_this)
                .Set_p_B_ILLS(_ILLS)
                .DO().Get_Resalt()
            ;
        }
    }
}