using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.UltimateChoicer
{
    public static class Ext_IListIUltimateChoice
    {
        public static IList<IUltimateChoice> Get_InterfaceCopy(this IList<IUltimateChoice> _this_ExtILIUC)
        {
            IList<IUltimateChoice> _ILIUC = new List<IUltimateChoice>();
            foreach (IUltimateChoice _IUltimateChoice in _this_ExtILIUC)
                _ILIUC.Add(_IUltimateChoice.Get_InterfaceCopy());
            return _ILIUC;
        }
    }
    public interface IUltimateChoice
    {
        Action<IUltimateChoice> p_Action { get; set; }
        bool p_IfChoiceIsOk{get;set;}
        string p_ChoiceName{get;set;}
        /// <summary>Характеризует, будет ли пункт меню использоваться в интерфейсе пользовательского выбора/// </summary>
        bool p_Usable { get; set; }
        bool p_PostRepeater { get; set; }
        IProgressTime p_IProgressTime { get; set; }
        Action<IUltimateChoice> p_Updater { get; set; }
        IChoicer p_ObjectSender { get; set; }
        //object p_Resalt_object { get; set; }
        //////////////////////////////////////////////////////////////////////
        IUltimateChoice Set(Action<IUltimateChoice> x);
        IUltimateChoice Set_p_Action(Action<IUltimateChoice> _p_Action);
        /// <summary>Вроде пока что нигде не используется, но бывает иногда полезным</summary>
        IUltimateChoice Set_p_IfChoiceIsOk(bool _p_IfChoiceIsOk);
        IUltimateChoice Set_p_ChoiceName(string _p_Choice);
        /// <summary>Характеризует, будет ли пункт меню использоваться в интерфейсе пользовательского выбора/// </summary>
        IUltimateChoice Set_p_Usable(bool _p_Usable);
        IUltimateChoice Set_p_PostRepeater(bool _p_PostRepeater);
        IUltimateChoice Set_p_IProgressTime(IProgressTime _p_IProgressTime);
        IUltimateChoice Set_p_Updater(Action<IUltimateChoice> _p_Updater);
        //////////////////////////////////////////////////////////////////////
        IUltimateChoice Do();
        /// <summary>Возвращаем пустой результат исполнения выбранного сценария чисто для стайла и порядка</summary>
        void Get_Resalt();
        //object Get_Resalt();
        //////////////////////////////////////////////////////////////////////
        IUltimateChoice Get_InterfaceCopy();
        IUltimateChoice Get_InterfaseNewCreateInstance();
    }
    public class UltimateChoice : IUltimateChoice
    {
        public Action<IUltimateChoice> p_Action { get; set; }
        public bool p_IfChoiceIsOk { get; set; }
        public string p_ChoiceName { get; set; }
        /// <summary>Характеризует, будет ли пункт меню использоваться в интерфейсе пользовательского выбора/// </summary>
        public bool p_Usable { get; set; }
        /// <summary>В качестве результата выполнения пользовательского выбора возвращается булевый ответ для к меню:
        /// false - повторно меню выбора не запускать
        /// True - повторно меню пользовательского выбора запускать, так как скорее всего это был пункт настроек параметра </summary>
        public bool p_PostRepeater { get; set; }
        public IProgressTime p_IProgressTime { get; set; }
        public Action<IUltimateChoice> p_Updater { get; set; }
        public IChoicer p_ObjectSender { get; set; }
        //public object p_Resalt_object { get; set; }
        //////////////////////////////////////////////////////////////////////
        public IUltimateChoice Init() 
        {
            this.p_Action = (IUltimateChoice _this) => { ; };
            this.p_IfChoiceIsOk = true;
            this.p_ChoiceName = "UltimateChoice";
            this.p_Usable = true;
            this.p_PostRepeater = true;
            this.p_IProgressTime = new ProgressTime();
            this.p_Updater = (IUltimateChoice _this) => { ;};
            this.p_ObjectSender = null;
            //this.p_Resalt_object=new object();
            return this;
        }
        public UltimateChoice(){this.Init();}
        //////////////////////////////////////////////////////////////////////
        public IUltimateChoice Set(Action<IUltimateChoice> x) { x(this); return this; }
        public IUltimateChoice Set_p_Action(Action<IUltimateChoice> _p_Action) { this.p_Action = _p_Action; return this; }
        /// <summary>Вроде пока что нигде не используется, но бывает иногда полезным</summary>
        public IUltimateChoice Set_p_IfChoiceIsOk(bool _p_IfChoiceIsOk) { this.p_IfChoiceIsOk = _p_IfChoiceIsOk; return this; }
        public IUltimateChoice Set_p_ChoiceName(string _p_Choice) { this.p_ChoiceName = _p_Choice; return this; }
        /// <summary>Характеризует, будет ли пункт меню использоваться в интерфейсе пользовательского выбора/// </summary>
        public IUltimateChoice Set_p_Usable(bool _p_Usable) { this.p_Usable = _p_Usable; return this; }
        public IUltimateChoice Set_p_PostRepeater(bool _p_PostRepeater) { this.p_PostRepeater = _p_PostRepeater; return this; }
        public IUltimateChoice Set_p_IProgressTime(IProgressTime _p_IProgressTime) { this.p_IProgressTime = _p_IProgressTime; return this; }
        public IUltimateChoice Set_p_Updater(Action<IUltimateChoice> _p_Updater) { this.p_Updater = _p_Updater; this.p_Updater(this); return this; }
        //////////////////////////////////////////////////////////////////////
        public IUltimateChoice Do()
        {
            this.p_IProgressTime.Set_Start();
            this.p_Action(this);
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public void Get_Resalt() { if (!this.p_IProgressTime.p_CalcIsLocked)this.Do();}
        //public object Get_Resalt() { if (!this.p_IProgressTime.p_CalcIsLocked)this.Do(); return this.p_Resalt_object; }
        //////////////////////////////////////////////////////////////////////
        public IUltimateChoice Get_InterfaceCopy()
        {
            return ((IUltimateChoice)Activator.CreateInstance(this.GetType()))
                .Set_p_IProgressTime(this.p_IProgressTime.Get_InterfaceCopy())
                .Set_p_IfChoiceIsOk(this.p_IfChoiceIsOk)
                .Set_p_ChoiceName(this.p_ChoiceName)
                .Set_p_Action(this.p_Action)
                .Set_p_Usable(this.p_Usable)
                .Set_p_PostRepeater(this.p_PostRepeater)
                .Set((IUltimateChoice _this) => 
                {
                    _this.p_Updater = this.p_Updater;
                    //_this.p_Resalt_object = this.p_Resalt_object;
                    _this.p_ObjectSender = this.p_ObjectSender;
                })
                ;
        }
        public IUltimateChoice Get_InterfaseNewCreateInstance(){return ((IUltimateChoice)Activator.CreateInstance(this.GetType()));}
    }
}