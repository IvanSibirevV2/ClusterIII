using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////////////////////////////////////////////////////////////////////////////
using Component;
using Component.Math;
using Component.UltimateChoicer;
/////////////////////////////////////////////////////////////////////////////////////////
using Component.LLSDataSource.Script;
using Component.DataSource_LLS.Script;
//Component.LLSDataSource.Script.Consoler.GenRandCluData_Script.Do()
/////////////////////////////////////////////////////////
namespace _004_002_LLSData
{
    class Program
    {
        [STAThread]
        //[MTAThread]
        static void Main(string[] args)
        {
            Console.Title = "004_002_LLSData";
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            //Оглавление: Содержимое ядра / Стендовые тесты компонента
            /////////////////////////////////////////////////////////////////////////////////////////
            //Component.Ext_LS.Test();
            //Component.Ext_ILS.Test()
            //////////////////////////////////////////////////////////////////////////////////////////
            //Component.MyMicroEXCEL.Text();
            //////////////////////////////////////////////////////////////////////////////////////////
            //Component.DataTest_LLS.DataTest_LLS_Count.Test();
            //Component.DataTest_LLS.DataTest_LLS_Double.Test();
            //Component.DataTest_LLS.DataTest_LLS_RowNames.Test();
            //Component.DataTest_LLS.DataTest_LLS_ColumnsNames.Test();
            //Component.DataTest_LLS.DataTest_LLS.Test();
            /////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////DataMath_LLS//////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            //Component.Math.DistEuclidean_ILS.Test();
            //Component.Math.Barycenter_ILLS.Test();
            //Component.Math.BarycenterBrief_ILLS.Test();
            //Component.Math.ClusterProperties_ILLS.Test();
            /////////////////////////////////////////////////////////
            //Component.Math.Matrix.Minor_ILLS.Text();
            //Component.Math.Matrix.Transp_ILLS.Test();
            //Component.Math.Matrix.Multiplication_ILLS.Text();
            //Component.Math.Matrix.Sum_ILLS.Test();

            //Component.Math.Matrix.DeterminantV0_ILLS.Test();
            //Component.Math.Matrix.DeterminantV1_ILLS.Test();
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////DataSource_LLS//////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            //Console.WriteLine("Привет Мир");
            //Component.LLSDataSource.Standart.Test_Data_Super_Small();
            //Component.LLSDataSource.Standart.Test_Data_Super_Small_NaN();
            //Component.LLSDataSource.Standart.Test_Data_Super_Small_Clu3();
            //Component.LLSDataSource.Standart.Test_Data_Small();
            //Component.LLSDataSource.Standart.Test_Data_Normal();
            //Component.LLSDataSource.Standart.Test_Data_Big();
            //Component.LLSDataSource.Standart.Test_Data_Super_Big();
            //Component.LLSDataSource.Standart.Test_OLL_Standart_Data_();
            ///////////////////////////////////////////////////////////////
            //Component.LLSDataSource.Experimental._001.Test_Data_LLS1();
            //Component.LLSDataSource.Experimental._001.Test_Data_LLS2();
            //Component.LLSDataSource.Experimental._001.Test_Data_LLS3();
            //Component.LLSDataSource.Experimental._001.Test_OLL_Experimental_001_Data_();
            ////////////////////////////////////////////////////////////////
            //Component.GeneraterRandomInputData.GenCluInpData_Rand.Test_GenCluInpData_Rand();
            //Component.GeneraterRandomInputData.GenClusInpData_DivForRandClu.Test_GenClusInpData_ForRandClu();
            ///////////////////////////////////////////////////////////////
            //Сomponent.LLSDataSource.Script.Clipboard.TestScript();
            //Component.LLSDataSource.Script.LoaderLLS_From_TxT.Test_LoaderLLS_From_TxT();
            //Component.LLSDataSource.Script.Script_IChoicer__IGenCluInpData_Rand.Test();
            //Component.DataSource_LLS.Script.Get_FromOllSourseByChoicer_LLS.Test();
            ////////////////////////////////////////////////////////////////           
            //Component.DataSource_LLS.Script.Saver_LLS.Test();
            ////////////////////////////////////////////////////////////////
            
            if (true)
            {
                
                List<List<string>> _lls =
                    ((List<List<string>>)
                        (new Component.DataSource_LLS.Script.Get_FromOllSourseByChoicer_LLS())
                            .Do().Get_Resalt()
                    ).writeThis(5);

                (new Saver_LLS(_lls.Get_Copy())).Do().Get_Resalt();                
            }
            
            ////////////////////////////////////////////////////////////////
            Console.Read();
        }
    }
}
