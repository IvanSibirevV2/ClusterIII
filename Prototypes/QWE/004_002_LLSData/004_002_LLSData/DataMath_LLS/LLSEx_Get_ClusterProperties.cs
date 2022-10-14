using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////////////////////////////////

namespace Component.Math
{
    public interface IClusterProperties_ILLS : IBarycenter_ILLS
    {
        //IClusterProperties_ILLS.Main/////////////////////////////////////////////////////////////////////////////////
        bool p_NeedDisp { get; set; }
        bool p_NeedMax { get; set; }
        bool p_NeedMin { get; set; }
        bool p_NeedRazm { get; set; }
        bool p_NeedCluCe { get; set; }
        //IClusterProperties_ILLS.Dop/////////////////////////////////////////////////////////////////////////////////
        IClusterProperties_ILLS Set_(Action<IClusterProperties_ILLS> x);
        IClusterProperties_ILLS Set_p_NeedDisp(bool _p_NeedDisp);
        IClusterProperties_ILLS Set_p_NeedMax(bool _p_NeedMax);
        IClusterProperties_ILLS Set_p_NeedMin(bool _p_NeedMin);
        IClusterProperties_ILLS Set_p_NeedRazm(bool _p_NeedRazm);
        IClusterProperties_ILLS Set_p_NeedCluCe(bool _p_NeedCluCe);
        ///////////////////////////////////////////////////////////////////////////////////
    }
    public class ClusterProperties_ILLS : Barycenter_ILLS, IBarycenter_ILLS, IClusterProperties_ILLS
    {
        //IClusterProperties_ILLS.Main/////////////////////////////////////////////////////////////////////////////////
        public bool p_NeedDisp { get; set; }
        public bool p_NeedMax { get; set; }
        public bool p_NeedMin { get; set; }
        public bool p_NeedRazm { get; set; }
        public bool p_NeedCluCe { get; set; }
        //IClusterProperties_ILLS.Dop/////////////////////////////////////////////////////////////////////////////////
        public IClusterProperties_ILLS Init()
        {
            return this
                //IClusterProperties_ILLS.Main//
                .Set_p_NeedDisp(true)
                .Set_p_NeedMax(true)
                .Set_p_NeedMin(true)
                .Set_p_NeedRazm(true)
                .Set_p_NeedCluCe(true)
            ;
        }
        public ClusterProperties_ILLS():base(){this.Init();}
        //////////////////////////////////////////////////////////////////////////////
        public IClusterProperties_ILLS Set_(Action<IClusterProperties_ILLS> x) { x(this); return this; }
        public IClusterProperties_ILLS Set_p_NeedDisp(bool _p_NeedDisp) { this.p_NeedDisp=_p_NeedDisp; return this; }
        public IClusterProperties_ILLS Set_p_NeedMax(bool _p_NeedMax) { this.p_NeedMax = _p_NeedMax; return this; }
        public IClusterProperties_ILLS Set_p_NeedMin(bool _p_NeedMin) { this.p_NeedMin = _p_NeedMin; return this; }
        public IClusterProperties_ILLS Set_p_NeedRazm(bool _p_NeedRazm) { this.p_NeedRazm = _p_NeedRazm; return this; }
        public IClusterProperties_ILLS Set_p_NeedCluCe(bool _p_NeedCluCe) { this.p_NeedCluCe = _p_NeedCluCe; return this; }
        //////////////////////////////////////////////////////////////////////////////
        public override IBarycenter_ILLS DO()
        {
            this.p_IProgressTime.Set_Start();
            {
                if (this.p_NeedDataTest)if (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());

                IList<IList<string>> rez = new List<IList<string>>();
                Func<string, int> SetPozition = (string str) =>
                {
                    //rez.Add(COPY.LS(L_LLS[0]));
                    rez.Add(this.p_ILLS[0].Get_InterfaseCopy());
                    for (int j = 1; j < rez[rez.Count - 1].Count(); j++)
                        rez[rez.Count - 1][j] = "0";
                    rez[rez.Count - 1][0] = str;
                    return rez.Count - 1;
                };
                rez.Add(this.p_ILLS[0].Get_InterfaseCopy());
                int Disp = -1; if (this.p_NeedDisp) Disp = SetPozition("Disp");
                int Max = -1; if (this.p_NeedMax) Max = SetPozition("Max");
                int Min = -1; if (this.p_NeedMin) Min = SetPozition("Min");
                int Razm = -1; if (this.p_NeedRazm) Razm = SetPozition("Razm");
                int CluCe = -1; if (this.p_NeedCluCe) CluCe = SetPozition("CluCe");
                IList<IList<string>> clusterCenter = (new Barycenter_ILLS())
                    .Set_p_ILLS(this.p_ILLS.Get_InterfaseCopy())
                    .DO().Get_Resalt().Get_InterfaseCopy()
                ;
                for (int j = 1; j < this.p_ILLS[0].Count(); j++)
                {
                    double _Disp = 0;
                    double _Max = Convert.ToDouble(this.p_ILLS[1][j]);
                    double _Min = _Max;
                    double _CluCe = 0;
                    for (int i = 1; i < this.p_ILLS.Count(); i++)
                    {
                        _Disp += System.Math.Pow(Convert.ToDouble(this.p_ILLS[i][j]), 2);
                        _CluCe += Convert.ToDouble(this.p_ILLS[i][j]);
                        _Max = System.Math.Max(_Max, Convert.ToDouble(this.p_ILLS[i][j]));
                        _Min = System.Math.Min(_Min, Convert.ToDouble(this.p_ILLS[i][j]));
                    }
                    _Disp = System.Math.Sqrt(_Disp / (this.p_ILLS.Count() - 1) - System.Math.Pow(Convert.ToDouble(clusterCenter[1][j]), 2));
                    _CluCe = _CluCe / (this.p_ILLS.Count() - 1);

                    if (this.p_NeedDisp) rez[Disp][j] = Convert.ToString(_Disp);
                    if (this.p_NeedMax) rez[Max][j] = Convert.ToString(_Max);
                    if (this.p_NeedMin) rez[Min][j] = Convert.ToString(_Min);
                    if (this.p_NeedRazm) rez[Razm][j] = Convert.ToString(_Max - _Min);
                    if (this.p_NeedCluCe) rez[CluCe][j] = Convert.ToString(_CluCe);
                }
                this.p_Resalt=rez;
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public override IBarycenter_ILLS Get_InterfaceCopy()
        {
            return((IBarycenter_ILLS)
                ((IClusterProperties_ILLS)Activator.CreateInstance(this.GetType()))
                //IClusterProperties_ILLS.Main//
                .Set_p_NeedDisp(true)
                .Set_p_NeedMax(true)
                .Set_p_NeedMin(true)
                .Set_p_NeedRazm(true)
                .Set_p_NeedCluCe(true)
                )
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
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test()
        {
            
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            Console.WriteLine("Component.Math.LLSEx_Get_ClusterProperties.Get_ClusterProperties(this List<List<string>> L_LLS, bool __Disp, bool __Max, bool __Min, bool __Razm, bool __CluCe)");
            IBarycenter_ILLS _IBarycenter_ILLS = ((IBarycenter_ILLS)(new ClusterProperties_ILLS())).Set_p_NeedDataTest(true);
            #region Штатный тест
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест");
            _IBarycenter_ILLS.Get_InterfaceCopy()
                .Set_p_ILLS
                ((new List<string>[] {
                    (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                    ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                    ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                    ,(new string[] {"А4",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                    ,(new string[] {"А5",	"1",	"1",	"0",	"1",	"1"	}).ToList<string>()	
                    ,(new string[] {"А6",	"0",	"0",	"0",	"0",	"0"	}).ToList<string>()	
                    ,(new string[] {"А7",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                    ,(new string[] {"А8",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                    ,(new string[] {"А9",	"1",	"1",	"1",	"1",	"1"	}).ToList<string>()	
                    ,(new string[] {"А10",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                }).ToList<List<string>>().Get_CopyAsILS())
                .DO().Get_Resalt().writeThis(5);
            #endregion
            #region НеШтатный тест
            try
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("ВнеШтатный тест");
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
            catch (ArgumentException e)
            {
                (new Consoller_Shabloner())
                    .WriteLine("Эксепшен словлен")
                    .Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan)
                    .WriteLine("///////////////////////////////////////////////")
                    .Set_StandartSettings()
                    .WriteLine(e.Message);
            }
            #endregion
        }
    }

    public static class LLSEx_Get_ClusterProperties
    {
        //return ClusterProperties(L_LLS, true, false, false, false, true);
        public static List<List<string>> Get_ClusterProperties(this List<List<string>> L_LLS, bool _p_NeedDisp, bool _p_NeedMax, bool _p_NeedMin, bool _p_NeedRazm,bool _p_NeedCluCe)
        {
            return 
                ((IBarycenter_ILLS)
                (new ClusterProperties_ILLS())
                    .Set_p_NeedDisp(_p_NeedDisp)
                    .Set_p_NeedMax(_p_NeedMax)
                    .Set_p_NeedMin(_p_NeedMin)
                    .Set_p_NeedRazm(_p_NeedRazm)
                    .Set_p_NeedCluCe(_p_NeedCluCe)
                )
                    .Set_p_ILLS(L_LLS.Get_CopyAsILS())
                    .DO()
                    .Get_Resalt().Get_CopyAsLS()
            ;
        }
        public static void TestGet_ClusterProperties()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());
            Console.WriteLine("Component.Math.LLSEx_Get_ClusterProperties.Get_ClusterProperties(this List<List<string>> L_LLS, bool __Disp, bool __Max, bool __Min, bool __Razm, bool __CluCe)");
            #region Штатный тест
            ((new List<string>[] {
                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                ,(new string[] {"А2",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                ,(new string[] {"А3",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                ,(new string[] {"А4",	"1",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                ,(new string[] {"А5",	"1",	"1",	"0",	"1",	"1"	}).ToList<string>()	
                ,(new string[] {"А6",	"0",	"0",	"0",	"0",	"0"	}).ToList<string>()	
                ,(new string[] {"А7",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
                ,(new string[] {"А8",	"1",	"1",	"0",	"0",	"1"	}).ToList<string>()	
                ,(new string[] {"А9",	"1",	"1",	"1",	"1",	"1"	}).ToList<string>()	
                ,(new string[] {"А10",	"1",	"0",	"0",	"1",	"1"	}).ToList<string>()	
            }).ToList<List<string>>())
            .Get_ClusterProperties( true, true, true, true, true).writeThis(5);
            #endregion
            #region НеШтатный тест
            try
            {
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
                }).ToList<List<string>>())
                .Get_ClusterProperties(true, true, true, true, true).writeThis(5);
            }
            catch (ArgumentException e) 
            {
                (new Consoller_Shabloner())
                    .WriteLine("Эксепшен словлен")
                    .Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan)
                    .WriteLine("///////////////////////////////////////////////")
                    .Set_StandartSettings()
                    .WriteLine(e.Message); 
            }
            #endregion
        }
    }
}