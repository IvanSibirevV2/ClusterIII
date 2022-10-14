using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.DataTest_LLS
{
    public class DataTest_LLS_ColumnsNames : DataTest_LLS, IDataTest_LLS
    {
        public override IDataTest_LLS Do()
        {
            this.p_IProgressTime.Set_Start();
            {
                List<List<string>> _LLS = p_LLS.Get_Copy();
                bool rez = true;
                int _i = 0;
                int _j = 0;
                for (int i = 1; i < p_LLS[0].Count; i++)
                    for (int j = 1; j < p_LLS[0].Count; j++)
                        if (i != j)
                            if (p_LLS[0][i] == p_LLS[0][j])
                            {
                                rez = false;
                                _i = i;
                                _j = j;
                            }
                string str = "Component.DataSourceTestClass";
                str += "\n .LLS_TEST_integrity_ColumnsNames";
                str += "\n  Ошибка - совпадающие названия столбцов данных";
                str += "\n  p_LLS[0][" + Convert.ToString(_i) + "]=p_LLS[0][" + Convert.ToString(_j) + "]=<" + p_LLS[0][_i] + ">";
                if (this.p_NeedShowConsole)
                    Console.WriteLine("LLS_TEST_integrity_ColumnsNames= " + Convert.ToString(rez));
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

            IDataTest_LLS _ILLS_DataTest = new DataTest_LLS_ColumnsNames();
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
    }
}