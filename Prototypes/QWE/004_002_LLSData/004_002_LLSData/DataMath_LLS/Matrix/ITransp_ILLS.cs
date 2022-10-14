using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Math.Matrix
{
    public interface ITransp_ILLS
    {
        //Main////////////////////////////////////////////////////
        IList<IList<string>> p_ILLS { get; set; }
        bool p_NeedDataTest { get; set; }
        IList<IList<string>> p_Resalt { get; set; }
        //Dop/////////////////////////////////////////////////////
        IProgressTime p_IProgressTime { get; set; }
        //////////////////////////////////////////////////////////
        ITransp_ILLS Set(Action<ITransp_ILLS> x);
        ITransp_ILLS Set_p_ILLS(IList<IList<string>> _p_ILLS);
        ITransp_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest);
        //////////////////////////////////////////////////////////
        ITransp_ILLS DO();
        IList<IList<string>> Get_Resalt();
        //////////////////////////////////////////////////////////
        ITransp_ILLS Get_InterfaceCopy();
        ITransp_ILLS Get_InterfaceNewCreateInstance();
    }
    public class Transp_ILLS : ITransp_ILLS
    {
        //Main////////////////////////////////////////////////////
        public IList<IList<string>> p_ILLS { get; set; }
        public bool p_NeedDataTest { get; set; }
        public IList<IList<string>> p_Resalt { get; set; }
        //Dop/////////////////////////////////////////////////////        
        public IProgressTime p_IProgressTime { get; set; }
        //////////////////////////////////////////////////////////
        public ITransp_ILLS Init() 
        {
            return this
                //Main//
                .Set_p_ILLS(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS())
                .Set_p_NeedDataTest(false)
                .Set((ITransp_ILLS _this) => 
                {
                    _this.p_Resalt = _this.p_ILLS.Get_InterfaseCopy();
                    //Dop//
                    _this.p_IProgressTime = new ProgressTime();
                })
            ;
        }
        public Transp_ILLS(){this.Init();}
        //////////////////////////////////////////////////////////
        public ITransp_ILLS Set(Action<ITransp_ILLS> x) { x(this); return this; }
        public ITransp_ILLS Set_p_ILLS(IList<IList<string>> _p_ILLS) { this.p_ILLS=_p_ILLS; return this; }
        public ITransp_ILLS Set_p_NeedDataTest(bool _p_NeedDataTest) { this.p_NeedDataTest = _p_NeedDataTest; return this; }
        //////////////////////////////////////////////////////////
        public ITransp_ILLS DO()
        {
            this.p_IProgressTime.Set_Start();
            {
                if(this.p_NeedDataTest)if (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());
                this.p_Resalt = new List<IList<string>>();
                for (int i = 0; i < this.p_ILLS[0].Count; i++)
                {
                    IList<string> q = new List<string>();
                    for (int j = 0; j < this.p_ILLS.Count; j++)q.Add(this.p_ILLS[j][i]);
                    this.p_Resalt.Add(q);
                }
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public IList<IList<string>> Get_Resalt()
        {
            if (!this.p_IProgressTime.p_CalcIsLocked) this.DO();
            return this.p_Resalt;
        }
        //////////////////////////////////////////////////////////
        public ITransp_ILLS Get_InterfaceCopy()
        {
            return ((ITransp_ILLS)Activator.CreateInstance(this.GetType()))
                //Main//
                .Set_p_ILLS(this.p_ILLS.Get_InterfaseCopy())
                .Set_p_NeedDataTest(this.p_NeedDataTest)
                .Set((ITransp_ILLS _this) =>
                {
                    _this.p_Resalt = this.p_Resalt.Get_InterfaseCopy();
                    //Dop//
                    _this.p_IProgressTime = this.p_IProgressTime.Get_InterfaceCopy();
                })
            ;
        }
        public ITransp_ILLS Get_InterfaceNewCreateInstance() { return ((ITransp_ILLS)Activator.CreateInstance(this.GetType())); }
        //////////////////////////////////////////////////////////////////////////////////
        public static void Test()
        {            
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            Console.WriteLine("Component.Math.Matrix.LLS_TranspExtension.Transpose(this List<List<string>> _LLS, bool NameCheck)");
            ITransp_ILLS _ITransp_ILLS = new Transp_ILLS();
            _ITransp_ILLS.Set_p_NeedDataTest(true).Get_InterfaceCopy()
                .Set_p_ILLS
                ((new List<string>[] {
                    (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()
                    ,(new string[] {"А2",	"1",	"1",	"0"}).ToList<string>()
                    ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()
                }).ToList<List<string>>().Get_CopyAsILS())
                .DO().Get_Resalt().writeThis(5);

            try
            {
                _ITransp_ILLS.Get_InterfaceCopy()
                    .Set_p_ILLS
                    ((new List<string>[] {
                        (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3"}).ToList<string>()
                        ,(new string[] {"А1",	"1",	"1",	"1"}).ToList<string>()
                        ,(new string[] {"А2",	"1",	"0"}).ToList<string>()
                        ,(new string[] {"А3",	"1",	"1",	"0"}).ToList<string>()
                    }).ToList<List<string>>().Get_CopyAsILS())
                    .DO().Get_Resalt().writeThis(5);
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
        }
    }
    public static class LLS_TranspExtension
    {
        /// <summary>Транспонировние матриц</summary>
        public static List<List<string>> Transpose(this List<List<string>> _LLS) { return (new Transp_ILLS()).Set_p_ILLS(_LLS.Get_CopyAsILS()).Get_Resalt().Get_CopyAsLS(); }
        public static IList<IList<string>> Transpose(this IList<IList<string>> _ILLS){return (new Transp_ILLS()).Set_p_ILLS(_ILLS).DO().Get_Resalt(); }
    }
}