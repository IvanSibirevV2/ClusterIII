using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////////////////////////////////////////////////////////////////////////////
using Component;
using Component.SQL_Manager;
using Component.DataSource_LLS.Script;

namespace Component
{
    static class Program
    {
        //Включаем режим поддержки многопоточности для Win Form
        [MTAThread]
        static void Main(string[] args)
        {
            Console.Title = "004_003_Clustering";
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            
            Component.DB_Creator.Do()
                .Set((ISQL_M _this) =>
                {
                    /*
                    IList<IList<string>> _ILLS = _this.Get_InterfaceCopy()
                        //.Set((ISQL_M _this_2) => { _this_2.p_IConnectStrGenerator.Set_p_Initial_Catalog("sys"); })
                        //.Set((ISQL_M _this_2) => { _this_2.p_IConnectStrGenerator.Set_p_Initial_Catalog("master"); })
                        //.Set((ISQL_M _this_2) => { _this_2.p_IConnectStrGenerator.Set_p_Initial_Catalog("QWE"); })
                        //.Set_p_SQL_String("select name from sys.sysobjects")
                        //.Set_p_SQL_String("select name from QWE.sysobjects")
                        .Set_p_SQL_String("SELECT TABLE_NAME AS [name] FROM INFORMATION_SCHEMA.TABLES WHERE table_type='BASE TABLE'")
                        .Do().Get_Resalt()
                        //.GET_Saver_LLS();
//                        .writeThis(10)
                        ;
                    IList<string> _ILS = new List<string>();
                    for (int i = 1; i < _ILLS.Count; i++)_ILS.Add(_ILLS[i][0]);
                    _ILS.writeThis(10);
                    */
                    (new Component.Form2())
                        .Set_p_ISQL_M(_this.Get_InterfaceCopy())
                        .ShowDialog_();
                })
                ;

            
            /////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Все ок!");
            Console.Read();
        }
    }
}