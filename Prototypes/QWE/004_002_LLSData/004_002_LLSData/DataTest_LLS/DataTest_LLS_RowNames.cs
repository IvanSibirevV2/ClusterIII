using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.DataTest_LLS
{
    public class DataTest_LLS_RowNames : DataTest_LLS, IDataTest_LLS
    {
        public override IDataTest_LLS Do()
        {
            this.p_IProgressTime.Set_Start();
            {
                bool rez = true;
                string str = "";
                for (int i = 1; i < p_LLS.Count; i++)
                    for (int j = 1; j < p_LLS.Count; j++)
                        if (i != j)
                            if (p_LLS[i][0] == p_LLS[j][0])
                            {
                                rez = false;
                                if (!rez)
                                {
                                    str = "Component.DataTest_LLS";
                                    str += "\n .LLS_DataTest_RowNames";
                                    str += "\n  Ошибка - совпадающие названия строк данных";
                                    str += "\n  p_LLS[" + Convert.ToString(i) + "][0]=p_LLS[" + Convert.ToString(j) + "][0]=<" + p_LLS[i][0] + ">";
                                    break;
                                }
                            }
                if (this.p_NeedShowConsole)
                    Console.WriteLine("LLS_TEST_integrity_RowNames= " + Convert.ToString(rez));
                if (!rez)
                {
                    if (this.p_NeedShowConsole)
                        Console.WriteLine(str);
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
            IDataTest_LLS _ILLS_DataTest = new DataTest_LLS_RowNames();
            //_ILLS_DataTest.Get_InterfaceNewCreateInstance();
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
    }
}