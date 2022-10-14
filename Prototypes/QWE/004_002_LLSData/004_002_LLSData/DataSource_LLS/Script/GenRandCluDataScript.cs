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
namespace Component.LLSDataSource.Script
{
    public class Script_IChoicer__IGenCluInpData_Rand : Choicer, IChoicer
    {
        public Component.GeneraterRandomInputData.IGenCluInpData_Rand _IGenCluInpData_Rand_Data = (new Component.GeneraterRandomInputData.GenClusInpData_DivForRandClu());
        public Component.GeneraterRandomInputData.IGenCluInpData_Rand _IGenCluInpData_Rand_Resalt = (new Component.GeneraterRandomInputData.GenClusInpData_DivForRandClu());
        //////////////////////////
        public IChoicer Init() 
        {
            return this
                .Set_p_Title("Меню ввода параметрв Генерации входных данных")
                .Set_p_IListIUC((new IUltimateChoice[] { 
                    (new UltimateChoice()).Set_p_ChoiceName("Пункт меню: Количество генерируемых кластеров.")
                    #region ...;
                    //////////////////////////////////////////
                        .Set_p_Updater((IUltimateChoice _this) =>
                        {
                            _this.Set_p_ChoiceName("<" + Convert.ToString(_IGenCluInpData_Rand_Data.p_K) + "> - Количество генерируемых кластеров. Изменить?")
                                .Set_p_Usable(
                                (_IGenCluInpData_Rand_Resalt.GetType().Name == (new Component.GeneraterRandomInputData.GenClusInpData_DivForRandClu()).GetType().Name)
                            );
                        })
                        .Set_p_Action((IUltimateChoice _this)=>
                        {
                            bool _flagan_ = true;
                            while (_flagan_)
                            {
                                string _str = _this.p_ObjectSender.p_IObjectReader.Get_InterfaceCopy().Set_p_ParamName("Введите Количество генерируемых кластеров")
                                    .Set_p_StartValue(Convert.ToString(_IGenCluInpData_Rand_Data.p_K)).Do().Get_Resalt();
                                try
                                {
                                    int q = Convert.ToInt16(_str);
                                    if (q >= 2) { _flagan_ = false; _IGenCluInpData_Rand_Data.p_K = q; }
                                }catch { }
                            }
                        })
                    //////////////////////////////////////////
                    #endregion
                    ,(new UltimateChoice()).Set_p_ChoiceName("Пункт меню: Количество генерируемых объектов.")
                    #region ...;
                    ///////////////////////////////////////////////
                        .Set_p_Updater((IUltimateChoice _this) => 
                        {_this.Set_p_ChoiceName("<" + Convert.ToString(_IGenCluInpData_Rand_Data.p_N) + "> - количество генерируемых объектов. Изменить?");})
                        .Set_p_Action((IUltimateChoice _this)=>
                        {
                            bool _flagan_ = true;
                            while (_flagan_)
                            {
                                string _str = _this.p_ObjectSender.p_IObjectReader.Get_InterfaceCopy().Set_p_ParamName("Введите Количество генерируемых объектов")
                                    .Set_p_StartValue(Convert.ToString(_IGenCluInpData_Rand_Data.p_N)).Do().Get_Resalt();
                                try
                                {
                                    int q = Convert.ToInt16(_str);
                                    if (q >= 2) { _flagan_ = false; _IGenCluInpData_Rand_Data.p_N = q; }
                                }
                                catch { }
                            }
                        })
                    ///////////////////////////////////////////////
                    #endregion
                    ,(new UltimateChoice()).Set_p_ChoiceName("Пункт меню: Количество генерируемых параметров.")
                    #region ...;
                    //////////////////////////////////////
                        .Set_p_Updater((IUltimateChoice _this) => 
                        {_this.Set_p_ChoiceName("<" + Convert.ToString(_IGenCluInpData_Rand_Data.p_P) + "> - количество генерируемых параметров. Изменить?");})
                        .Set_p_Action((IUltimateChoice _this)=>
                        {
                            bool _flagan_ = true;
                            while (_flagan_)
                            {
                                string _str = _this.p_ObjectSender.p_IObjectReader.Get_InterfaceCopy().Set_p_ParamName("Введите Количество генерируемых параметров")
                                    .Set_p_StartValue(Convert.ToString(_IGenCluInpData_Rand_Data.p_P)).Do().Get_Resalt();
                                try
                                {
                                    int q = Convert.ToInt16(_str);
                                    if (q >= 2) { _flagan_ = false; _IGenCluInpData_Rand_Data.p_P = q; }
                                }
                                catch { }
                            }
                        })
                    //////////////////////////////////////
                    #endregion
                    ,(new UltimateChoice()).Set_p_ChoiceName("Пункт меню: Максимально возможная генерируемая величина.")
                    #region ...;
                    ///////////////////////////////////////////////////////////////////////
                        .Set_p_Updater((IUltimateChoice _this) => 
                        {_this.Set_p_ChoiceName("<" + Convert.ToString(_IGenCluInpData_Rand_Data.p_MaxValue) + "> - максимально возможная генерируемая величина. Изменить?");})
                        .Set_p_Action((IUltimateChoice _this)=>
                        {
                            bool _flagan_ = true;
                            while (_flagan_)
                            {
                                string _str = _this.p_ObjectSender.p_IObjectReader.Get_InterfaceCopy().Set_p_ParamName("Введите максимально возможную генерируемую величину")
                                    .Set_p_StartValue(Convert.ToString(_IGenCluInpData_Rand_Data.p_MaxValue)).Do().Get_Resalt();
                                try
                                {
                                    double q = Convert.ToDouble(_str);
                                    _flagan_ = false;
                                    _IGenCluInpData_Rand_Data.p_MaxValue = q;
                                }
                                catch { }
                            }
                        })
                    ///////////////////////////////////////////////////////////////////////
                    #endregion
                    ,(new UltimateChoice()).Set_p_ChoiceName("Пункт меню: Минимально возможная генерируемая величина.")
                    #region ...;
                    /////////////////////////////////////////////////////////////
                        .Set_p_Updater((IUltimateChoice _this) => 
                        {_this.Set_p_ChoiceName("<" + Convert.ToString(_IGenCluInpData_Rand_Data.p_MinValue) + "> - минимально возможная генерируемая величина. Изменить?");})
                        .Set_p_Action((IUltimateChoice _this)=>
                        {
                            bool _flagan_ = true;
                            while (_flagan_)
                            {
                                string _str = _this.p_ObjectSender.p_IObjectReader.Get_InterfaceCopy().Set_p_ParamName("Введите минимально возможную генерируемую величину")
                                    .Set_p_StartValue(Convert.ToString(_IGenCluInpData_Rand_Data.p_MinValue)).Do().Get_Resalt();
                                try
                                {
                                    double q = Convert.ToDouble(_str);
                                    _flagan_ = false;
                                    _IGenCluInpData_Rand_Data.p_MinValue = q;
                                }
                                catch { }
                            }
                        })
                    /////////////////////////////////////////////////////////////
                    #endregion
                    ,(new UltimateChoice()).Set_p_ChoiceName("Пункт меню: Метод генерации входных данных ")
                    #region ...;
                    ///////////////////////////////////////////////////////  
                        .Set_p_Updater((IUltimateChoice _this) => 
                        {_this.Set_p_ChoiceName("<" + _IGenCluInpData_Rand_Resalt.GetType().Name + "> - метод генерации входных данных. Изменить?");})
                        
                        .Set_p_Action((IUltimateChoice _this)=>
                        {
                            _this.p_ObjectSender.Get_InterfaseNewCreateInstance()
                                .Set_p_PostRepeaterMode(false)
                                .Set_p_Title("Выберете метод геренации входных данных")
                                .Set_p_IListIUC((new IUltimateChoice[]
                                {
                                    (new UltimateChoice()).Set_p_ChoiceName("<" + (new Component.GeneraterRandomInputData.GenCluInpData_Rand()).GetType().Name + "> - генерация случайных даных")
                                        .Set_p_Action((IUltimateChoice __this)=>{_IGenCluInpData_Rand_Resalt = (new Component.GeneraterRandomInputData.GenCluInpData_Rand());})
                                    ,(new UltimateChoice()).Set_p_ChoiceName("<" + (new Component.GeneraterRandomInputData.GenClusInpData_DivForRandClu()).GetType().Name + "> - генерация случайных даных, явно разделённых на кластеры")
                                        .Set_p_Action((IUltimateChoice __this)=>{_IGenCluInpData_Rand_Resalt = (new Component.GeneraterRandomInputData.GenClusInpData_DivForRandClu());})
                                }).ToList<IUltimateChoice>())
                                .Do().Get_Resalt();
                        })
                    ///////////////////////////////////////////////////////
                    #endregion
                    ,(new Component.UltimateChoicer.UltimateChoice()).Set_p_ChoiceName("Подтвердить и сгенерировать").Set_p_PostRepeater(false)
                    .Set_p_Action((IUltimateChoice _this)=>
                    {
                        _this.p_ObjectSender.Updater().p_Resalt_object=
                            _IGenCluInpData_Rand_Resalt
                            .Set_p_GeneraterRandomValue(_IGenCluInpData_Rand_Data.p_GeneraterRandomValue.Get_InterfaseCopy())
                            .Set_p_K(_IGenCluInpData_Rand_Data.p_K)
                            .Set_p_MaxValue(_IGenCluInpData_Rand_Data.p_MaxValue)
                            .Set_p_MinValue(_IGenCluInpData_Rand_Data.p_MinValue)
                            .Set_p_N(_IGenCluInpData_Rand_Data.p_N)
                            .Set_p_P(_IGenCluInpData_Rand_Data.p_P)
                        ;
                    })
                }).ToList<IUltimateChoice>())
            ;
                
        }
        public Script_IChoicer__IGenCluInpData_Rand(): base() 
        {this.Init();}
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            (
                (Component.GeneraterRandomInputData.IGenCluInpData_Rand)
                    (new Script_IChoicer__IGenCluInpData_Rand())
                        //.Set_Style(new Choicer())
                        //.Set_Style(new Choice_WinForm())
                        .Do().Get_Resalt()
            ).Next().writeThis(5);
        }
    }
}