using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////////
using Component;

namespace Component.Math
{
    public interface IBarycenter_ILLS
    {
        //Main//////////////////////////////////////////////////////
        IList<IList<string>> p_ILLS { get; set; }
        bool p_NeedDataTest { get; set; }
        IList<IList<string>> p_Resalt { get; set; }
        //Dop//////////////////////////////////////////////////////
        IProgressTime p_IProgressTime { get; set; }
        ////////////////////////////////////////////////////////////////////
        IBarycenter_ILLS Set(Action<IBarycenter_ILLS> x);
        IBarycenter_ILLS Set_p_ILLS(IList<IList<string>> _p_ILLS);
        IBarycenter_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest);
        ////////////////////////////////////////////////////////////////////
        IBarycenter_ILLS DO();
        IList<IList<string>> Get_Resalt();
        ////////////////////////////////////////////////////////////////////
        IBarycenter_ILLS Get_InterfaceCopy();
        IBarycenter_ILLS Get_InterfaceNewCreateInstance();
    }
    public class Barycenter_ILLS : IBarycenter_ILLS
    { 
        //Main//////////////////////////////////////////////////////
        public IList<IList<string>> p_ILLS { get; set; }
        public bool p_NeedDataTest { get; set; }
        public IList<IList<string>> p_Resalt { get; set; }
        //Dop//////////////////////////////////////////////////////
        public IProgressTime p_IProgressTime { get; set; }
        public IBarycenter_ILLS Init() 
        {
            return this
                //Main//
                .Set_p_ILLS(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS())
                .Set_p_NeedDataTest(false)
                .Set((IBarycenter_ILLS _this) => 
                {
                    _this.p_Resalt = this.p_ILLS.Get_InterfaseCopy();
                    //Dop//
                    _this.p_IProgressTime = new ProgressTime();
                })
            ;
        }
        public Barycenter_ILLS() { this.Init(); }
        ////////////////////////////////////////////////////////////////////
        public IBarycenter_ILLS Set(Action<IBarycenter_ILLS> x){x(this); return this;}
        public IBarycenter_ILLS Set_p_ILLS(IList<IList<string>> _p_ILLS) {this.p_ILLS=_p_ILLS; return this; }
        public IBarycenter_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest) { this.p_NeedDataTest= _p_NeedDataTest; return this; }
        ////////////////////////////////////////////////////////////////////
        public virtual IBarycenter_ILLS DO()
        {
            this.p_IProgressTime.Set_Start();
            {
                ;
                if(this.p_NeedDataTest)
                {
                    if (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());
                }
                ;
                this.p_Resalt = new List<IList<string>>();
                this.p_Resalt.Add(this.p_ILLS[0].Get_InterfaseCopy());
                this.p_Resalt.Add(
                    (new BarycenterBrief_ILLS())
                        .Set_p_ILLS(this.p_ILLS.Get_InterfaseCopy())
                        .Set_p_NeedDataTest(this.p_NeedDataTest)
                        .DO()
                        .Get_Resalt()[0]
                );
                ;
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public IList<IList<string>> Get_Resalt(){if (!this.p_IProgressTime.p_CalcIsLocked) this.DO();return this.p_Resalt;}
        ////////////////////////////////////////////////////////////////////
        public virtual IBarycenter_ILLS Get_InterfaceCopy()
        {
            ;
            return ((IBarycenter_ILLS)Activator.CreateInstance(this.GetType()))
                //Main//
                .Set_p_ILLS(this.p_ILLS.Get_InterfaseCopy())
                .Set_p_NeedDataTest(this.p_NeedDataTest)
                .Set((IBarycenter_ILLS _this) =>
                {
                    _this.p_Resalt = this.p_Resalt.Get_InterfaseCopy();
                    //Dop//
                    _this.p_IProgressTime = this.p_IProgressTime.Get_InterfaceCopy();
                })
            ;
        }
        public IBarycenter_ILLS Get_InterfaceNewCreateInstance() { return ((IBarycenter_ILLS)Activator.CreateInstance(this.GetType())); }
        ////////////////////////////////////////////////////////////////////
        public static void Test()
        {            
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            IBarycenter_ILLS _IBarycenter_ILLS = (new Barycenter_ILLS()).Set_p_NeedDataTest(true);
            _IBarycenter_ILLS.Get_InterfaceCopy().DO()
                .Set((IBarycenter_ILLS _this) => { _this.p_ILLS.writeThis(5);})
                .Get_Resalt().writeThis(5);
            #region Не Штатный тест
            try
            {
                _IBarycenter_ILLS.Get_InterfaceCopy()
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
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
        }
    }
    public class BarycenterBrief_ILLS :Barycenter_ILLS, IBarycenter_ILLS
    {
        public override IBarycenter_ILLS DO()
        {
            this.p_IProgressTime.Set_Start();
            {
                if (this.p_NeedDataTest)
                {
                    if (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());
                }

                List<double> LD = new List<double>();
                for (int j = 0; j < this.p_ILLS[0].Count; j++) LD.Add(0);
                for (int i = 1; i < this.p_ILLS.Count; i++)
                    for (int j = 1; j < this.p_ILLS[i].Count; j++)
                        LD[j] += Convert.ToDouble(this.p_ILLS[i][j]);
                IList<string> _ILSRes = new List<string>();
                _ILSRes.Add(this.p_ILLS[0][0] + "Barycenter");

                for (int j = 1; j < this.p_ILLS[0].Count; j++)
                {
                    LD[j] = LD[j] / (this.p_ILLS.Count - 1);
                    _ILSRes.Add(Convert.ToString(LD[j])); 
                }
                this.p_Resalt = new List<IList<string>>();
                this.p_Resalt.Add(_ILSRes.Get_InterfaseCopy());
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            IBarycenter_ILLS _IBarycenter_ILLS = (new BarycenterBrief_ILLS()).Set_p_NeedDataTest(true);
            _IBarycenter_ILLS.Get_InterfaceCopy().DO()
                .Set((IBarycenter_ILLS _this) => { _this.p_ILLS.writeThis(5); })
                .Get_Resalt().writeThis(5);
            #region Не Штатный тест
            try
            {
                _IBarycenter_ILLS.Get_InterfaceCopy()
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
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
        }
    }
    public static class EXT_BarycenterBrief_ILLS
    {
        public static IList<string> Get_BarycenterBrief(this IList<IList<string>> _ILLS)
        { return (new BarycenterBrief_ILLS()).Set_p_ILLS(_ILLS).DO().Get_Resalt()[0]; }
        public static IList<IList<string>> Get_Barycenter(this IList<IList<string>> _ILLS)
        { return (new Barycenter_ILLS()).Set_p_ILLS(_ILLS).DO().Get_Resalt(); }
    }

}