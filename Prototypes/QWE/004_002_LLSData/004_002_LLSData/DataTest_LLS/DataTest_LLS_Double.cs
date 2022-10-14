using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.DataTest_LLS
{
    public class DataTest_LLS_Double : DataTest_LLS, IDataTest_LLS
    {
        public override IDataTest_LLS Do()
        {
            this.p_IProgressTime.Set_Start();
            {
                bool rez = true;
                string str = "";
                for (int i = 1; i < p_LLS.Count; i++)
                    for (int j = 1; j < p_LLS[i].Count; j++)
                    {
                        try
                        {
                            double qwe = Convert.ToDouble(p_LLS[i][j]);
                            rez = rez && true;
                        }
                        catch
                        {
                            rez = rez && false;
                            str = "Component.DataTest_LLS";
                            str += "\n .LLS_DataTest_Double";
                            str += "\n  Ошибка - немогу перевести в тип Double";
                            str += "\n  p_LLS[" + Convert.ToString(i) + "][" + Convert.ToString(j) + "]=<" + p_LLS[i][j] + ">";
                            break;
                        }
                    }
                if (this.p_NeedShowConsole) Console.WriteLine("LLS_DataTest_Double = " + Convert.ToString(rez));
                if (!rez)
                {
                    if (this.p_NeedShowConsole) Console.WriteLine(str);
                    if (this.p_NeedShowMessageBox)
                        System.Windows.Forms.MessageBox.Show(str
                            , "Error!!!"
                            , System.Windows.Forms.MessageBoxButtons.OK
                            , System.Windows.Forms.MessageBoxIcon.Error
                        );
                }
                this.p_Resalt.p_Resalt = rez;
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS())
            ;
            IDataTest_LLS _ILLS_DataTest = new DataTest_LLS_Double();
            //_ILLS_DataTest.Get_InterfaceNewCreateInstance();
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
    }
}