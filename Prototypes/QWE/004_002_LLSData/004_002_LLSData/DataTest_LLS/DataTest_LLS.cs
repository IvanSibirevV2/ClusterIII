using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////
using Component;

namespace Component.DataTest_LLS
{
    public interface IDataTest_LLS
    {
        List<List<string>> p_LLS { get; set; }
        bool p_NeedShowConsole { get; set; }
        bool p_NeedShowMessageBox { get; set; }
        bool p_NeedTest { get; set; }
        IProgressTime p_IProgressTime { get; set; }
        DataTest_LLS.Resalt p_Resalt { get; set; }
        //////////////////////////////////////////////////////////////////
        IDataTest_LLS Set(Action<IDataTest_LLS> x);
        IDataTest_LLS Set_p_LLS(List<List<string>> _p_LLS);
        IDataTest_LLS Set_p_NeedShowConsole(bool _p_NeedShowConsole);
        IDataTest_LLS Set_p_NeedShowMessageBox(bool _p_NeedShowMessageBox);
        IDataTest_LLS Set_p_NeedTest(bool _p_NeedTest);
        IDataTest_LLS Set_p_IProgressTime(IProgressTime _p_IProgressTime);
        DataTest_LLS.Resalt GetResalt();
        IDataTest_LLS Do();
        //////////////////////////////////////////////////////////////////
        IDataTest_LLS Get_InterfaceNewCreateInstance();
        IDataTest_LLS Get_InterfaceCopy();
    }
    public class DataTest_LLS : IDataTest_LLS
    {
        public List<List<string>> p_LLS { get; set; }
        public bool p_NeedShowConsole { get; set; }
        public bool p_NeedShowMessageBox { get; set; }
        public bool p_NeedTest { get; set; }
        public IProgressTime p_IProgressTime { get; set; }
        public class Resalt { public bool p_Resalt = true; }
        public DataTest_LLS.Resalt p_Resalt { get; set; }
        private IDataTest_LLS Init()
        {
            this
                .Set_p_LLS(Component.LLSDataSource.Standart_Small.Data_Super_Small())
                .Set_p_IProgressTime(new ProgressTime())
                .Set_p_NeedShowConsole(true)
                .Set_p_NeedShowMessageBox(false)
                .Set_p_NeedTest(true)
                .p_Resalt = new Resalt()
                ;
            return this;
        }
        public DataTest_LLS(){this.Init();}
        public DataTest_LLS(List<List<string>> _p_LLS) { this.Init().Set_p_LLS(_p_LLS); }
        //////////////////////////////////////////////////////////////////
        public IDataTest_LLS Set(Action<IDataTest_LLS> x) { x(this); return this; }
        public IDataTest_LLS Set_p_LLS(List<List<string>> _p_LLS) { this.p_LLS = _p_LLS; return this; }
        public IDataTest_LLS Set_p_NeedShowConsole(bool _p_NeedShowConsole) { this.p_NeedShowConsole = _p_NeedShowConsole; return this; }
        public IDataTest_LLS Set_p_NeedShowMessageBox(bool _p_NeedShowMessageBox) { this.p_NeedShowMessageBox = _p_NeedShowMessageBox; return this; }
        public IDataTest_LLS Set_p_NeedTest(bool _p_NeedTest) { this.p_NeedTest = _p_NeedTest; return this; }
        public IDataTest_LLS Set_p_IProgressTime(IProgressTime _p_IProgressTime) { this.p_IProgressTime = _p_IProgressTime; return this; }
        public DataTest_LLS.Resalt GetResalt() { if (!this.p_IProgressTime.p_CalcIsLocked) this.Do(); return this.p_Resalt; }
        public virtual IDataTest_LLS Do()
        {
            this.p_IProgressTime.Set_Start();
            {
                this.p_Resalt.p_Resalt =
                  (new Component.DataTest_LLS.DataTest_LLS_Count()).Set_p_LLS(this.p_LLS.Get_Copy()).Set_p_NeedShowConsole(this.p_NeedShowConsole).Set_p_NeedShowMessageBox(this.p_NeedShowMessageBox).Do().GetResalt().p_Resalt
                  && (new Component.DataTest_LLS.DataTest_LLS_Double()).Set_p_LLS(this.p_LLS.Get_Copy()).Set_p_NeedShowConsole(this.p_NeedShowConsole).Set_p_NeedShowMessageBox(this.p_NeedShowMessageBox).Do().GetResalt().p_Resalt
                  && (new Component.DataTest_LLS.DataTest_LLS_RowNames()).Set_p_LLS(this.p_LLS.Get_Copy()).Set_p_NeedShowConsole(this.p_NeedShowConsole).Set_p_NeedShowMessageBox(this.p_NeedShowMessageBox).Do().GetResalt().p_Resalt
                  && (new Component.DataTest_LLS.DataTest_LLS_ColumnsNames()).Set_p_LLS(this.p_LLS.Get_Copy()).Set_p_NeedShowConsole(this.p_NeedShowConsole).Set_p_NeedShowMessageBox(this.p_NeedShowMessageBox).Do().GetResalt().p_Resalt
                ;
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        //////////////////////////////////////////////////////////////////
        public IDataTest_LLS Get_InterfaceNewCreateInstance() { return ((IDataTest_LLS)Activator.CreateInstance(this.GetType())); }
        public IDataTest_LLS Get_InterfaceCopy()
        {
            return ((IDataTest_LLS)Activator.CreateInstance(this.GetType()))
                .Set_p_LLS(this.p_LLS.Get_Copy())
            ;
        }
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS())
            ;
            IDataTest_LLS _ILLS_DataTest = new DataTest_LLS();
            
            //_ILLS_DataTest.Get_InterfaceNewCreateInstance();
            #region Component.DataTest_LLS.LLS_DataTest_Count.Test();
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.DataTest_LLS.LLS_DataTest_Count.Test();");
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance().Do();
                /////////////////////////////////////////
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("ВнеШтатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance().Set_p_LLS(new List<List<string>>()).Do();
                /////////////////////////////////////////
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("ВнеШтатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance()
                    .Set_p_LLS(
                        (new List<string>[] {
                            (new string[] {}).ToList<string>()
                            ,(new string[] {}).ToList<string>()
                            ,(new string[] {}).ToList<string>()
                        }).ToList<List<string>>()
                    )
                    .Do();
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("ВнеШтатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance()
                    .Set_p_LLS(
                        (new List<string>[] {
                        (new string[] {"Name=Data_Super_Small;",    "П1",   "П2",   "П3",   "П4",   "П5"}).ToList<string>()
                        ,(new string[] {"А1",   "1",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А2",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А3",   "1",    "1",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А4",   "1",    "1",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А5",   "1",    "1",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А6",   "0",    "0",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А7",   "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А8",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А9",   "1",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А10",  "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        }).ToList<List<string>>()
                    )
                    .Do();
                //
            }
            #endregion
            #region Component.DataTest_LLS.LLS_DataTest_Double.Test();
            
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.DataTest_LLS.LLS_DataTest_Double.Test();");
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance().Do();
                /////////////////////////////////////////
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест с дырками");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance()
                    .Set_p_LLS(
                        (new List<string>[] {
                        (new string[] {"Name=Data_Super_Small;",    "П1",   "П2",   "П3",   "П4",   "П5"}).ToList<string>()
                        ,(new string[] {"А1",   "NaN",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А2",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А3",   "1",    "1",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А4",   "1",    "1",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А5",   "1",    "1",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А6",   "0",    "0",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А7",   "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А8",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А9",   "1",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А10",  "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        }).ToList<List<string>>()
                    )
                    .Do();
                /////////////////////////////////////////
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест на разделитель дробной части <.>");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance()
                    .Set_p_LLS(
                        (new List<string>[] {
                        (new string[] {"Name=Data_Super_Small;",    "П1",   "П2",   "П3",   "П4",   "П5"}).ToList<string>()
                        ,(new string[] {"А1",   "1.8",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А2",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А3",   "1",    "1",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А4",   "1",    "1",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А5",   "1",    "1",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А6",   "0",    "0",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А7",   "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А8",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А9",   "1",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А10",  "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        }).ToList<List<string>>()
                    )
                    .Do();
                /////////////////////////////////////////
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест на разделитель дробной части <,>");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance()
                    .Set_p_LLS(
                        (new List<string>[] {
                        (new string[] {"Name=Data_Super_Small;",    "П1",   "П2",   "П3",   "П4",   "П5"}).ToList<string>()
                        ,(new string[] {"А1",   "1,8",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А2",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А3",   "1",    "1",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А4",   "1",    "1",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А5",   "1",    "1",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А6",   "0",    "0",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А7",   "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А8",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А9",   "1",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А10",  "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        }).ToList<List<string>>()
                    )
                    .Do();
                /////////////////////////////////////////
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("ВнеШтатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance()
                    .Set_p_LLS(
                        (new List<string>[] {
                        (new string[] {"Name=Data_Super_Small;",    "П1",   "П2",   "П3",   "П4",   "П5"}).ToList<string>()
                        ,(new string[] {"А1",   "цмвйор",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А2",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А3",   "1",    "1",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А4",   "1",    "1",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А5",   "1",    "1",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А6",   "0",    "0",    "0",    "0",    "0" }).ToList<string>()
                        ,(new string[] {"А7",   "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А8",   "1",    "1",    "0",    "0",    "1" }).ToList<string>()
                        ,(new string[] {"А9",   "1",    "1",    "1",    "1",    "1" }).ToList<string>()
                        ,(new string[] {"А10",  "1",    "0",    "0",    "1",    "1" }).ToList<string>()
                        }).ToList<List<string>>()
                    )
                    .Do();
            }
            #endregion
            #region Component.DataTest_LLS.LLS_DataTest_RowNames.Test();
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.DataTest_LLS.LLS_DataTest_RowNames.Test();");
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance().Do();
                /////////////////////////////////////////
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("ВнеШтатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance()
                    .Set_p_LLS(
                        (new List<string>[] {
                        (new string [] {"LLS","П1","П2"}).ToList<string>()
                        ,(new string [] {"A1","1","2"}).ToList<string>()
                        ,(new string [] {"A1","3","2"}).ToList<string>()
                        }).ToList<List<string>>()
                    ).Do();
            }
            #endregion
            #region Component.DataTest_LLS.LLS_DataTest_ColumnsNames.Test();
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.DataTest_LLS.LLS_DataTest_ColumnsNames.Test();");
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance().Do();
                /////////////////////////////////////////
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("ВнеШтатный тест");
                _ILLS_DataTest.Get_InterfaceNewCreateInstance()
                    .Set_p_LLS(
                        (new List<string>[] {
                        (new string [] {"LLS","П1","П1"}).ToList<string>()
                        ,(new string [] {"A1","1","2"}).ToList<string>()
                        ,(new string [] {"A2","3","2"}).ToList<string>()
                        }).ToList<List<string>>()
                    ).Do();
            }
            #endregion
            
        }
    }
}