using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Math
{
    public interface IDistance_ILS
    {
        //Main///////////////////////////////////////////////////////
        IList<string> p_A_ILS { get; set; }
        IList<string> p_B_ILS { get; set; }
        bool p_NeedDataTest { get; set; }
        double p_Resalt { get; set; }
        //DopMain///////////////////////////////////////////////////////
        IProgressTime p_IProgressTime { get; set; }
        /////////////////////////////////////////////////////////////////
        IDistance_ILS Set(Action<IDistance_ILS> x);
        IDistance_ILS Set_p_A_ILS(IList<string> _p_A_ILS);
        IDistance_ILS Set_p_B_ILS(IList<string> _p_B_ILS);
        IDistance_ILS Set_p_NeedDataTest(bool _p_NeedDataTest);
        ///////////////////////////////////////////////
        IDistance_ILS DO();
        double Get_Resalt();
        ///////////////////////////////////////////////
        IDistance_ILS Get_InterfaceCopy();
        IDistance_ILS Get_InterfaseNewCreateInstance();
    }
    /// <summary>Класс, предназначеный для расчёта Евклидова расстояния</summary>
    public class DistEuclidean_ILS : IDistance_ILS
    {
        //Main///////////////////////////////////////////////////////
        public IList<string> p_A_ILS { get; set; }
        public IList<string> p_B_ILS { get; set; }
        public bool p_NeedDataTest { get; set; }
        public double p_Resalt { get; set; }
        //DopMain///////////////////////////////////////////////////////
        public IProgressTime p_IProgressTime { get; set; }
        public IDistance_ILS Init()
        {
            return this
                //Main///////////////////////////////////////////////////////
                .Set_p_A_ILS((new string[] { "_default_p_A_ILS", "0" }).ToList<string>())
                .Set_p_B_ILS((new string[] { "_default_p_B_ILS", "5" }).ToList<string>())
                .Set_p_NeedDataTest(false)
                .Set((IDistance_ILS _this) => 
                {
                    _this.p_Resalt = -1;
                    //DopMain///////////////////////////////////////////////////////
                    _this.p_IProgressTime = new ProgressTime();
                })
            ;
        }
        public DistEuclidean_ILS() { this.Init(); }
        /////////////////////////////////////////////////////////////////
        public IDistance_ILS Set(Action<IDistance_ILS> x) { x(this); return this; }
        public IDistance_ILS Set_p_A_ILS(IList<string> _p_A_ILS) { this.p_A_ILS = _p_A_ILS; return this; }
        public IDistance_ILS Set_p_B_ILS(IList<string> _p_B_ILS) { this.p_B_ILS = _p_B_ILS; return this; }
        public IDistance_ILS Set_p_NeedDataTest(bool _p_NeedDataTest) { this.p_NeedDataTest = _p_NeedDataTest; return this; }        
        /////////////////////////////////////////////////////////////////
        public IDistance_ILS DO()
        {
            this.p_IProgressTime.Set_Start();
            {
                if (this.p_NeedDataTest)
                {
                    if (!this.p_A_ILS.Get_CopyAsLS().LSDataTest()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию \n (!this.p_A_ILS.Get_CopyAsLS().LSDataTest()) \n", (new StackTracer()).Get_STSS());
                    if (!this.p_B_ILS.Get_CopyAsLS().LSDataTest()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию \n (!this.p_B_ILS.Get_CopyAsLS().LSDataTest()) \n", (new StackTracer()).Get_STSS());
                    if (this.p_A_ILS.Count != this.p_B_ILS.Count) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию \nПолучены входные данные разной размерности \n (this.p_A_ILS.Count != this.p_B_ILS.Count) \n", (new StackTracer()).Get_STSS());
                    if (this.p_A_ILS.Count < 2) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию\nНет параметров для нахождения растояния \n (this.p_A_ILS.Count < 2) \n", (new StackTracer()).Get_STSS());
                    if (this.p_B_ILS.Count < 2) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию\nНет параметров для нахождения растояния \n (this.p_B_ILS.Count < 2) \n", (new StackTracer()).Get_STSS());
                }
                //Этот кусок замароченого програмного кода унаследован от предыдущей версии проекта
                //и сознательно не переписывался (не минимизировался) на случай необходимости отлова ошибок
                double res = 0;
                int A = this.p_A_ILS.Count();
                int B = this.p_B_ILS.Count();                
                for (int i = 1; ((i < B) && (i < A)); i++)
                    if ((B == this.p_B_ILS.Count) && (A == this.p_A_ILS.Count()))
                    {
                        double local_res = Convert.ToDouble(this.p_A_ILS[i]) - Convert.ToDouble(this.p_B_ILS[i]);
                        res += local_res * local_res;
                    }
                p_Resalt=System.Math.Sqrt(res);
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public double Get_Resalt(){if (!this.p_IProgressTime.p_CalcIsLocked) this.DO(); return this.p_Resalt;}
        /////////////////////////////////////////////////////////////////
        public IDistance_ILS Get_InterfaceCopy()
        {
            return ((IDistance_ILS)Activator.CreateInstance(this.GetType()))
                //Main///////////////////////////////////////////////////////
                .Set_p_A_ILS(this.p_A_ILS.Get_InterfaseCopy())
                .Set_p_B_ILS(this.p_B_ILS.Get_InterfaseCopy())
                .Set_p_NeedDataTest(this.p_NeedDataTest)
                .Set((IDistance_ILS _this) => 
                {
                    _this.p_Resalt = this.p_Resalt;
                    //DopMain///////////////////////////////////////////////////////
                    _this.p_IProgressTime = this.p_IProgressTime.Get_InterfaceCopy();
                })
            ;
        }
        public IDistance_ILS Get_InterfaseNewCreateInstance() { return ((IDistance_ILS)Activator.CreateInstance(this.GetType())); }
        /////////////////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            IDistance_ILS _IDistance_ILS = (new DistEuclidean_ILS()).Set_p_NeedDataTest(true);
            #region Штатный тест
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест");
                _IDistance_ILS.Get_InterfaceCopy()
                     .Set_p_A_ILS((new string[] { "_p_LS_A", "0", "2" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                     .Set_p_B_ILS((new string[] { "_p_LS_B", "0", "2" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                .DO().Get_Resalt().ToString().Set_Write(); " - Евклидово расстояние \n\n".Set_WriteLine();
            }
            #endregion
            #region Не Штатный тест
            #region Штатный тест №1
            try
            {//Ловим исключение 
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не штатный тест");
                _IDistance_ILS.Get_InterfaceCopy()
                    .Set_p_A_ILS((new string[] { "_p_LS_A" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                    .Set_p_B_ILS((new string[] { "_p_LS_B", "0", "2" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                .DO().Get_Resalt().ToString().Set_Write(); " - Евклидово расстояние \n\n".Set_WriteLine();
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Штатный тест №2
            try
            {//Ловим исключение 
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не штатный тест");
                _IDistance_ILS.Get_InterfaceCopy()
                    .Set_p_A_ILS((new string[] { "_p_LS_A", "0", "2" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                    .Set_p_B_ILS((new string[] { "_p_LS_B" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                .DO().Get_Resalt().ToString().Set_Write(); " - Евклидово расстояние \n\n".Set_WriteLine();
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Штатный тест №3
            try
            {//Ловим исключение 
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не штатный тест");
                _IDistance_ILS.Get_InterfaceCopy()
                    .Set_p_A_ILS((new string[] { "_p_LS_A", "0", "2" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                    .Set_p_B_ILS((new string[] { "_p_LS_B", "0" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                .DO().Get_Resalt().ToString().Set_Write(); " - Евклидово расстояние \n\n".Set_WriteLine();
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Штатный тест №4
            try
            {//Ловим исключение
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не штатный тест");
                _IDistance_ILS.Get_InterfaceCopy()
                    .Set_p_A_ILS((new string[] { "_p_LS_A"}).ToList<string>().Get_CopyAsILS().writeThis(5))
                    .Set_p_B_ILS((new string[] { "_p_LS_B", "0" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                .DO().Get_Resalt().ToString().Set_Write(); " - Евклидово расстояние \n\n".Set_WriteLine();
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #region Штатный тест №5
            try
            {//Ловим исключение
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не штатный тест");
                _IDistance_ILS.Get_InterfaceCopy()
                    .Set_p_A_ILS((new string[] { "_p_LS_A" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                    .Set_p_B_ILS((new string[] { "_p_LS_B", "0" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                .DO().Get_Resalt().ToString().Set_Write(); " - Евклидово расстояние \n\n".Set_WriteLine();
            }
            catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
            #endregion
            #endregion
        }
        public static void Test_Performance(int _repeat)
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            IDistance_ILS _IDistance_ILS = (new DistEuclidean_ILS()).Set_p_NeedDataTest(true)
                .Set_p_A_ILS((new string[] { "_p_LS_A", "0", "2", "0", "2", "0", "2", "0", "2", "0", "2" }).ToList<string>().Get_CopyAsILS().writeThis(5))
                .Set_p_B_ILS((new string[] { "_p_LS_B", "0", "2", "0", "2", "0", "2", "0", "2", "0", "2" }).ToList<string>().Get_CopyAsILS().writeThis(5))
            ;
            #region Штатный тест
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест производительности");
                (new ProgressTime()).Set((IProgressTime _this) =>
                {
                    _this.Set_Start();
                    for (int i = 0; i < _repeat; i++)_IDistance_ILS.Get_InterfaceCopy().DO();
                    _this.Set_Stop().p_Watch.Get_WatchString_M().Set_WriteLine();
                })
                ;
                (new ProgressTime()).Set((IProgressTime _this) =>
                {
                    _IDistance_ILS.Set_p_NeedDataTest(false);
                    _this.Set_Start();
                    for (int i = 0; i < _repeat; i++) _IDistance_ILS.Get_InterfaceCopy().DO();
                    _this.Set_Stop().p_Watch.Get_WatchString_M().Set_WriteLine();
                })
                ;
            }
            #endregion
        }
    }
}
