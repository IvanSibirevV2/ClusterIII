using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////////////
using Component;

namespace Component.UltimateChoicer
{
    public static class Ext_IChoicer
    {
        public static IChoicer Set_Style(this IChoicer _this_Ext_IChoicer, IChoicer _New_IChoicer)
        {
            ;
            IChoicer _IChoicer = _New_IChoicer.Get_InterfaseNewCreateInstance()
                .Set_p_IProgressTime(_this_Ext_IChoicer.p_IProgressTime.Get_InterfaceCopy())
                .Set_p_IObjectReader(_this_Ext_IChoicer.p_IObjectReader.Get_InterfaceCopy())
                .Set_p_PostRepeaterMode(_this_Ext_IChoicer.p_PostRepeaterMode)
                .Set_p_Title(_this_Ext_IChoicer.p_Title)
                .Set_p_IListIUC(_this_Ext_IChoicer.p_IListIUC.Get_InterfaceCopy())
                .Set((IChoicer _this) => 
                {
                    _this.p_Resalt_UltimateChoice = _this_Ext_IChoicer.p_Resalt_UltimateChoice.Get_InterfaceCopy();
                    //_this_Ext_IChoicer = _this;
                })
            ;
            return _IChoicer;
        }
    }
    public interface IChoicer
    {
        IList<IUltimateChoice> p_IListIUC{get;set;}
        string p_Title{get;set;}
        IObjectReader p_IObjectReader{get;set;}
        bool p_PostRepeaterMode { get; set; }
        IProgressTime p_IProgressTime { get; set; }
        IUltimateChoice p_Resalt_UltimateChoice { get; set; }
        object p_Resalt_object { get; set; }
        //////////////////////////////////////////////////////////
        IChoicer Set(Action<IChoicer> x);
        IChoicer Set_p_IListIUC(IList<IUltimateChoice> _p_IListIUC);
        IChoicer Set_p_Title(string _p_Title);
        IChoicer Set_p_IObjectReader(IObjectReader _p_IObjectReader);
        IChoicer Set_p_PostRepeaterMode(bool _p_PostRepeaterMode);
        IChoicer Set_p_IProgressTime(IProgressTime _p_IProgressTime);
        //////////////////////////////////////////////////////////
        /// <summary>Запускаем инструмент совершения пользовательского выбора</summary>
        IChoicer Do();
        IChoicer Updater();
        /// <summary>Возвращаем выбранный сценарий</summary>
        object Get_Resalt();
        IChoicer Get_InterfaseCopy();
        /// <summary> Создаёт новый интерфейс, содердаший объект такого же типа как исходный (без копирования) </summary>
        IChoicer Get_InterfaseNewCreateInstance();
    }
    public class Choicer : IChoicer
    {
        public IList<IUltimateChoice> p_IListIUC { get; set; }        
        public string p_Title { get; set; }
        public IObjectReader p_IObjectReader { get; set; }
        /// <summary>Включить ли мод повторяемости пользоваетльского выбора меню.</summary>
        public bool p_PostRepeaterMode { get; set; }
        public IProgressTime p_IProgressTime { get; set; }
        public IUltimateChoice p_Resalt_UltimateChoice { get; set; }
        public object p_Resalt_object { get; set; }
        //////////////////////////////////////////////////////////
        public IChoicer Init()
        {
            this.p_IListIUC = new List<IUltimateChoice>();
            this.p_Title = "Choicer";
            this.p_IObjectReader = new ObjectReader();
            this.p_PostRepeaterMode = true;
            this.p_IProgressTime = new ProgressTime();
            this.p_Resalt_UltimateChoice = new UltimateChoice();
            this.p_Resalt_object=new object();
            return this;
        }
        public Choicer() { this.Init(); }
        //////////////////////////////////////////////////////////
        public IChoicer Set(Action<IChoicer> x) { x(this); return this; }
        public IChoicer Set_p_IListIUC(IList<IUltimateChoice> _p_IListIUC) { this.p_IListIUC = _p_IListIUC; return this; }
        public IChoicer Set_p_Title(string _p_Title) { this.p_Title = _p_Title; return this; }
        public IChoicer Set_p_IObjectReader(IObjectReader _p_IObjectReader) { this.p_IObjectReader = _p_IObjectReader; return this; }
        public IChoicer Set_p_PostRepeaterMode(bool _p_PostRepeaterMode) { this.p_PostRepeaterMode = _p_PostRepeaterMode; return this; }
        public IChoicer Set_p_IProgressTime(IProgressTime _p_IProgressTime) { this.p_IProgressTime = _p_IProgressTime; return this; }
        //////////////////////////////////////////////////////////
        /// <summary>Запускаем инструмент совершения пользовательского выбора</summary>
        public IChoicer Do() 
        {
            this.p_IProgressTime.Set_Start();
            do
            {
                int _p_IdChoice = -1;
                ;
                this.Updater();
                IList<IUltimateChoice> _p_IListIUC = this.p_IListIUC.Get_InterfaceCopy();
                for (int i = _p_IListIUC.Count - 1; i > -1; i--)
                    if (!_p_IListIUC[i].p_Usable) _p_IListIUC.RemoveAt(i);                        

                while ((_p_IdChoice < 0)|| (_p_IdChoice > _p_IListIUC.Count - 1))
                {
                    Console.WriteLine(this.p_Title);
                    for (int i = 0; i < _p_IListIUC.Count; i++)
                        Console.WriteLine(Convert.ToString(i) + " - " + _p_IListIUC[i].p_ChoiceName);
                
                    string str = this.p_IObjectReader.Get_InterfaceCopy().Set_p_OperationName("=").Set_p_ParamName("Ваш Выбор").Do().Get_Resalt();
                    int qwe = -1;try{qwe = Convert.ToInt16(str);}catch{qwe = -1;}
                    _p_IdChoice = qwe;
                }

                if ((_p_IdChoice >= _p_IListIUC.Count) || (_p_IdChoice <= -1))
                {//Проверка на выбранность индекса и генерацция исключения если что
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
                    throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nЩас индека за пределами будет", (new StackTracer()).Get_STSS());
                }
                this.p_Resalt_UltimateChoice = _p_IListIUC[_p_IdChoice].Get_InterfaceCopy();
                this.p_Resalt_UltimateChoice.Do().Get_Resalt();
                this.Updater();                
            }while(this.p_Resalt_UltimateChoice.p_PostRepeater && this.p_PostRepeaterMode);

            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public IChoicer Updater()
        {
            foreach (IUltimateChoice _IUltimateChoice in this.p_IListIUC)
            {
                _IUltimateChoice.p_Updater(_IUltimateChoice);//Обновление всех пунктов меню
                _IUltimateChoice.p_ObjectSender = this.Set((IChoicer _this) => { ;});
            }
            return this;
        }
        //////////////////////////////////////////////////////////

        public object Get_Resalt()
        {
            if (!this.p_IProgressTime.p_CalcIsLocked) this.Do();
            return this.p_Resalt_object;
        }
        public IChoicer Get_InterfaseCopy()
        {
            return ((IChoicer)Activator.CreateInstance(this.GetType()))
                .Set_p_IProgressTime(this.p_IProgressTime.Get_InterfaceCopy())
                .Set_p_IObjectReader(this.p_IObjectReader.Get_InterfaceCopy())
                .Set_p_PostRepeaterMode(this.p_PostRepeaterMode)
                .Set_p_Title(this.p_Title)      
                .Set_p_IListIUC(this.p_IListIUC.Get_InterfaceCopy())
                .Set((IChoicer _this) => 
                {
                    _this.p_Resalt_UltimateChoice = this.p_Resalt_UltimateChoice.Get_InterfaceCopy();
                })
                ;
        }
        /// <summary> Создаёт новый интерфейс, содердаший объект такого же типа как исходный (без копирования) </summary>
        public IChoicer Get_InterfaseNewCreateInstance() { return ((IChoicer)Activator.CreateInstance(this.GetType())); }
        //////////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());
            string _str = "";
            (new Choicer())
                //.Set_p_PostRepeaterMode(false)
                .Set_p_Title("Тестовый выбор между да, нет и сомневаюсь")
                .Set_p_IListIUC((new IUltimateChoice[] {
                    (new UltimateChoice()).Set_p_ChoiceName("нет").Set_p_Action((IUltimateChoice _this)=>{_str ="нет";Console.WriteLine("_str ="+_str);})
                    ,(new UltimateChoice()).Set_p_ChoiceName("сомневаюсь").Set_p_Action((IUltimateChoice _this)=>{_str ="сомневаюсь";Console.WriteLine("_str ="+_str);})
                    ,(new UltimateChoice()).Set_p_ChoiceName("да").Set_p_Action((IUltimateChoice _this)=>{_str ="да";Console.WriteLine("_str ="+_str);})
                    ,(new UltimateChoice()).Set_p_ChoiceName("Пора завязывать с меню").Set_p_Action((IUltimateChoice _this)=>{_str ="Пора завязывать с меню";Console.WriteLine("_str ="+_str);}).Set_p_PostRepeater(false)
                }).ToList<IUltimateChoice>())
                .Do().Get_Resalt()
                ;

            Console.WriteLine(_str);
        }
    }
}