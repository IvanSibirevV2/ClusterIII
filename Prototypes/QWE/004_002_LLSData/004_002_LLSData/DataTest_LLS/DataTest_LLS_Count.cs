using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.DataTest_LLS
{
    public class DataTest_LLS_Count : DataTest_LLS, IDataTest_LLS
    {
        public override IDataTest_LLS Do()
        {
            this.p_IProgressTime.Set_Start();
            {
                bool rez = true;
                rez = rez && (p_LLS.Count() > 1) && (p_LLS[0].Count() > 1);
                bool _falagan = true;
                int e = 0;
                foreach (List<string> _LS in p_LLS)
                {
                    rez = rez && (_LS.Count == p_LLS[0].Count());
                    if (!rez){;_falagan = false;break;}
                    if (_falagan) e++;
                }
                string str = "Component.DataTest_LLS \n .LLS_DataTest_Count";
                if (_falagan)
                {
                    str += "\n  Ошибка - размерности входных данных";
                    str += "\n " + Convert.ToString((p_LLS.Count())) + " x ";
                    try { str += Convert.ToString((p_LLS[0].Count())); } catch { str += "0"; }
                }
                else if(p_LLS.Count>0)
                {
                    str += "\n  Ошибка - размерности входных данных";
                    str += "\n  Строка "+Convert.ToString(e)+ " размерности "+ Convert.ToString(p_LLS[e].Count()) + " не соответствует размерности " + Convert.ToString(p_LLS[0].Count())+ " шапки таблици";
                }
                if (this.p_NeedShowConsole)
                {
                    ("LLS_DataTest_Count = " + Convert.ToString(rez)).Set_WriteLine();
                    if (!rez)
                        Console.WriteLine(str);
                }
                if (!rez)
                    if (this.p_NeedShowMessageBox)
                        System.Windows.Forms.MessageBox.Show(str
                            , "Error!!!"
                            , System.Windows.Forms.MessageBoxButtons.OK
                            , System.Windows.Forms.MessageBoxIcon.Error
                        );
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
            IDataTest_LLS _ILLS_DataTest = new DataTest_LLS_Count();
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
            /////////////////////////////////////////
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
    }
}