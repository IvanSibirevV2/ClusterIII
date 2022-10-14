using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////////////////////////////////////////////
using Component;
using Component.UltimateChoicer;
using Component.LLSDataSource.Script;
//Component.LLSDataSource.Script.Consoler.GenRandCluData_Script.Do()
/////////////////////////////////////////////////////////

namespace Component.DataSource_LLS.Script
{

    public class Saver_LLS : Choicer, IChoicer
    {
        ////////////////////////////////////////////////////
        public IChoicer Init(List<List<string>> _lls)
        {
            return this.Set_p_Title("Нужно ли сохранить")
                .Set_p_IListIUC((new IUltimateChoice[] {
                    (new UltimateChoice()).Set_p_ChoiceName("Да, сохранить в отдельный *.TXT")
                    .Set_p_Action((IUltimateChoice _this)=>{
                        //(new Component.LLSDataSource.LLS_TxT_SaveLoadEr())
                          (new Component.LLSDataSource.LLS_Json_SaveLoadEr())
                            .Set_p_LLS(_lls.Get_Copy())
                            .Set_p_FileName(
                                _this.p_ObjectSender.p_IObjectReader.Get_InterfaceCopy().Set_p_ParamName("Введите имя файла (без пути и расширения, только имя)").Do().Get_Resalt()
                            )
                            .SaveToFile()
                        ;
                    })                    
                    ,(new UltimateChoice()).Set_p_ChoiceName("Да, сохранить в отдельный *.xlsx (Excel)")
                    .Set_p_Action((IUltimateChoice _this)=>{
                        (new MyMicroEXCEL())
                            .Set_p_FileName(
                                _this.p_ObjectSender.p_IObjectReader.Get_InterfaceCopy().Set_p_ParamName("Введите имя файла (без пути и расширения, только имя)").Do().Get_Resalt()
                            )
                            .Set_p_NeedToSave(true)
                            .add(1, _lls.Get_Copy()).Show()
                        ;                        
                    })
                    ,(new UltimateChoice()).Set_p_ChoiceName("Нет, просто вывести на экран в отдельном, без сохранения (Excel)")
                    .Set_p_Action((IUltimateChoice _this)=>{
                        ;
                        (new MyMicroEXCEL()).Set_p_NeedToSave(false).add(1, _lls.Get_Copy()).Show();
                    })
                    ,(new UltimateChoice()).Set_p_ChoiceName("Нет").Set_p_Action((IUltimateChoice _this)=>{;}).Set_p_PostRepeater(false)
                }).ToList<IUltimateChoice>())
                ;
        }
        public Saver_LLS(List<List<string>> _lls){this.Init(_lls);}
        ////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            List<List<string>> _lls=
            ((List<List<string>>)
                (new Get_FromOllSourseByChoicer_LLS())
                    .Do().Get_Resalt()
            ).writeThis(5);

            (new Saver_LLS(_lls.Get_Copy())).Do().Get_Resalt();
            
            //.writeThis(5);
        }
    }
    public static class ext_
    {
        public static void GET_Saver_LLS(this IList<IList<string>> _ILLS)
        {
            (new Component.DataSource_LLS.Script.Saver_LLS(_ILLS.Get_CopyAsLS())).Do().Get_Resalt();
        }
    }
}
