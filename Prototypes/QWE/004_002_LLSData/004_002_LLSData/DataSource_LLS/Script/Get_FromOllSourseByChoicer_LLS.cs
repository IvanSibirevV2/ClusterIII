using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////////////////////////////////////////////
using Component;
using Component.UltimateChoicer;
//Component.LLSDataSource.Script.Consoler.GenRandCluData_Script.Do()
/////////////////////////////////////////////////////////
namespace Component.DataSource_LLS.Script
{
    public class Get_FromOllSourseByChoicer_LLS : Choicer, IChoicer
    {
        ////////////////////////////////////////////////////
        public IChoicer Init()
        {
            return this
                .Set_p_PostRepeaterMode(false)
                .Set_p_Title("Выберете входные данные или способ их получения")
                .Set_p_IListIUC((new IUltimateChoice[] {
                    /////////////////////////////////////////////////////////////////////////////////////////
                    #region Сценарии получения данных из стандартного источника по умолчанию
                    //Сценарии получения данных из стандартного источника по умолчанию
                    (new UltimateChoice()).Set_p_ChoiceName("Standart.Data_Super_Small").Set_p_Action((IUltimateChoice _this)=> { _this.p_ObjectSender.p_Resalt_object = Component.LLSDataSource.Standart.Data_Super_Small(); })
                    ,(new UltimateChoice()).Set_p_ChoiceName("Standart.Data_Small").Set_p_Action((IUltimateChoice _this)=> { _this.p_ObjectSender.p_Resalt_object = Component.LLSDataSource.Standart.Data_Small(); })
                    ,(new UltimateChoice()).Set_p_ChoiceName("Standart.Data_Normal").Set_p_Action((IUltimateChoice _this)=> { _this.p_ObjectSender.p_Resalt_object = Component.LLSDataSource.Standart.Data_Normal();})
                    ,(new UltimateChoice()).Set_p_ChoiceName("Standart.Data_Big").Set_p_Action((IUltimateChoice _this)=> { _this.p_ObjectSender.p_Resalt_object = Component.LLSDataSource.Standart.Data_Big();})
                    ,(new UltimateChoice()).Set_p_ChoiceName("Standart.Data_Super_Big").Set_p_Action((IUltimateChoice _this)=> { _this.p_ObjectSender.p_Resalt_object = Component.LLSDataSource.Standart.Data_Super_Big(); })
                    #endregion
                    /////////////////////////////////////////////////////////////////////////////////////////
                    #region Сценарии получения данных из стандартного-расширеного источника по умолчанию
                    //Сценарии получения данных из стандартного-расширеного источника по умолчанию
                    ,(new UltimateChoice()).Set_p_ChoiceName("Experimental._001.Data_LLS1").Set_p_Action((IUltimateChoice _this)=> { _this.p_ObjectSender.p_Resalt_object = Component.LLSDataSource.Experimental._001.Data_LLS1();})
                    ,(new UltimateChoice()).Set_p_ChoiceName("Experimental._001.Data_LLS2").Set_p_Action((IUltimateChoice _this)=> { _this.p_ObjectSender.p_Resalt_object = Component.LLSDataSource.Experimental._001.Data_LLS2(); })
                    ,(new UltimateChoice()).Set_p_ChoiceName("Experimental._001.Data_LLS3").Set_p_Action((IUltimateChoice _this)=> { _this.p_ObjectSender.p_Resalt_object = Component.LLSDataSource.Experimental._001.Data_LLS3();})
                    #endregion
                    /////////////////////////////////////////////////////////////////////////////////////////
                    #region Дополнительные возможности
                    //Дополнительные возможности
                    ,(new UltimateChoice()).Set_p_ChoiceName("Получить таблицу данных из буфера обмена")
                        .Set_p_Action((IUltimateChoice _this)=>
                        {_this.p_ObjectSender.p_Resalt_object = Component.LLSDataSource.Script.Clipboard.Script_Get_LLS_From_Clipboard_ConsoleVersion(_this.p_ObjectSender.Get_InterfaseNewCreateInstance());})
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ,(new UltimateChoice()).Set_p_ChoiceName("Получить таблицу данных из текстового файла")
                        .Set_p_Action((IUltimateChoice _this)=> 
                        {
                            _this.p_ObjectSender.p_Resalt_object =

                                Component.LLSDataSource.Script.LoaderLLS_From_Json.LoaderLLS_From_Json_WinForm();
                                //Component.LLSDataSource.Script.LoaderLLS_From_TxT.LoaderLLS_From_TxT_WinForm();
                        })
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ,(new UltimateChoice()).Set_p_ChoiceName("Генерация случайных данны разбитых на кластеры")
                        .Set_p_Action((IUltimateChoice _this)=>
                        {
                            _this.p_ObjectSender.p_Resalt_object = 
                                ((Component.GeneraterRandomInputData.IGenCluInpData_Rand)
                                    (new Component.LLSDataSource.Script.Script_IChoicer__IGenCluInpData_Rand())
                                    .Set_Style(_this.p_ObjectSender).Do().Get_Resalt()
                                ).Next();
                            ;
                        })
                    #endregion
                    /////////////////////////////////////////////////////////////////////////////////////////            
                }).ToList<IUltimateChoice>())
            ;
        }
        public Get_FromOllSourseByChoicer_LLS(): base()
        {this.Init();}
        ////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            ((List<List<string>>)
                (new Get_FromOllSourseByChoicer_LLS())
                    .Do().Get_Resalt()
            ).writeThis(5);
        }
    }
}
