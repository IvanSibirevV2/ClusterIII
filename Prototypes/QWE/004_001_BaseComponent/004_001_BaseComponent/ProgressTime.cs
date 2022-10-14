using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    public interface IProgressTime
    {
        IProgressTime Set(Action<IProgressTime> x);
        //////////////////////////////////////////////////////////////////////////////////////////////////
        //decimal - жирное и дробное +-28E, так что юзаем и не заморачиваемся
        /// <summary>Прошедшее Количество вычислительных тактов (для выбранного алгоритма) (от 0 и до THIS.p_Progress_max )</summary>
        decimal p_Progress_now { get; set; } IProgressTime Set_p_Progress_now(decimal _p_Progress_now);
        /// <summary>Максимально возможное Количество тактов вычислений(для выбранного алгоритма)</summary>
        decimal p_Progress_max { get; set; } IProgressTime Set_p_Progress_max(decimal _p_Progress_max);
        int p_Progress_Last { get; set; }
        int p_Progress_Now_Percents { get; }
        /// <summary>Для вывода процента готовности. Лямбда для листинга</summary>
        Action<int> p_Progress_Action { get; set; } IProgressTime Set_p_Progress_Action(Action<int> _p_Progress_Action);
        IProgressTime Set_p_Progress_Action_AsConsole();
        /// <summary>Для измерения времени вычислений</summary>
        System.Diagnostics.Stopwatch p_Watch { get; set; } IProgressTime Set_p_Watch(System.Diagnostics.Stopwatch _p_Watch);
        /// <summary>Фиксирует состояние обслуживаемых вычислений (false/true - готов к вычислениям/вычислил и жду когда заберут результат )</summary>
        bool p_CalcIsLocked { get; set; } IProgressTime Set_p_CalcIsLocked(bool _p_CalcIsLocked);
        bool p_WorkOffLine { get; set; } IProgressTime Set_p_WorkOffLine(bool _p_WorkOffLine);
        /////////////////////////////////////////////////////
        IProgressTime Set_Start();
        IProgressTime Set_ProgressNext();
        IProgressTime Set_Stop();
        IProgressTime Set_Reset();
        /////////////////////////////////////////////////////
        IProgressTime Get_InterfaceCopy();
        IProgressTime Get_InterfaceNewCreateInstance();
    }
    public class ProgressTime : IProgressTime
    {
        public IProgressTime Set(Action<IProgressTime> x) { x(this); return this; }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        //decimal - жирное и дробное +-28E, так что используем и не заморачиваемся
        /// <summary>Прошедшее Количество вычислительных тактов (для выбранного алгоритма) (от 0 и до THIS.p_Progress_max )</summary>
        public decimal p_Progress_now { get; set; }public IProgressTime Set_p_Progress_now(decimal _p_Progress_now) { this.p_Progress_now = _p_Progress_now; return this; }
        /// <summary>Максимально возможное Количество тактов вычислений(для выбранного алгоритма)</summary>
        public decimal p_Progress_max { get; set; }public IProgressTime Set_p_Progress_max(decimal _p_Progress_max) { this.p_Progress_max = _p_Progress_max; return this; }
        public int p_Progress_Last { get; set; }
        public int p_Progress_Now_Percents { get { if (this.p_Progress_max == 0) this.p_Progress_max = 1; return (int)(100 * this.p_Progress_now / this.p_Progress_max); } }
        /// <summary>Для вывода процента готовности. Лямбда для листинга</summary>
        public Action<int> p_Progress_Action { get; set; } public IProgressTime Set_p_Progress_Action(Action<int> _p_Progress_Action) { this.p_Progress_Action = _p_Progress_Action; return this; }
        public IProgressTime Set_p_Progress_Action_AsConsole()
        {
            bool _FirstRun = true;
            return this
                .Set_p_Progress_Action(
                    (int i) =>
                    {
                        if (_FirstRun) (new Component.StackTracer()).Get_STSS(2).Set_WriteLine();
                        if (!_FirstRun) Console.CursorTop--;                        
                        Console.WriteLine("<"+Convert.ToString(i) + "%>          ");
                        _FirstRun = false;
                        
                    }
                )
            ;
        }

        /// <summary>Для измерения времени вычислений</summary>
        public System.Diagnostics.Stopwatch p_Watch { get; set; }public IProgressTime Set_p_Watch(System.Diagnostics.Stopwatch _p_Watch) { this.p_Watch = _p_Watch; return this; }
        /// <summary>Фиксирует состояние обслуживаемых вычислений (false/true - готов к вычислениям/вычислил и жду когда заберут результат )</summary>
        public bool p_CalcIsLocked { get; set; }public IProgressTime Set_p_CalcIsLocked(bool _p_CalcIsLocked) { this.p_CalcIsLocked = _p_CalcIsLocked; return this; }
        public bool p_WorkOffLine { get; set; }public IProgressTime Set_p_WorkOffLine(bool _p_WorkOffLine) { this.p_WorkOffLine = _p_WorkOffLine; return this; }

        public IProgressTime Init()
        {
            this.p_Progress_now = 0;
            this.p_Progress_max = 100;
            this.p_Progress_Last = 0;
            this.p_Progress_Action = (int x) => { ; };
            //this.Set_p_Progress_Action_AsConsole();
            this.p_Watch = new System.Diagnostics.Stopwatch();
            this.p_CalcIsLocked = false;
            this.p_WorkOffLine = true;
            return this;
        }
        public ProgressTime() { this.Init(); }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        public IProgressTime Set_Start(){return this.Set_Reset().Set((IProgressTime _this) => {if(!this.p_WorkOffLine)_this.p_Watch.Start(); });}
        public IProgressTime Set_ProgressNext()
        {
            if (!this.p_WorkOffLine)
            {
                this.p_Progress_now++;
                int _Local_Progress_Now = this.p_Progress_Now_Percents;
                if (this.p_Progress_Last != _Local_Progress_Now)
                {
                    this.p_Progress_Last = _Local_Progress_Now;
                    this.p_Progress_Action(this.p_Progress_Last);
                }
                if (_Local_Progress_Now >= 100)
                {
                    this.p_Progress_now = this.p_Progress_max;
                    _Local_Progress_Now = 100;
                }
            }
            return this;
        }
        public IProgressTime Set_Stop(){return this.Set((IProgressTime _this) => { if (!this.p_WorkOffLine) _this.p_Watch.Stop(); }).Set_p_CalcIsLocked(true);}
        public IProgressTime Set_Reset()
        {
            return this.Set_Stop()
                .Set((IProgressTime _this) => { _this.p_Watch.Stop(); })
                .Set_p_Watch(new System.Diagnostics.Stopwatch())
                .Set_p_CalcIsLocked(false)
                .Set_p_Progress_now(new Decimal(0))
            ;
        }
        //////////////////////////////////////////
        public IProgressTime Get_InterfaceCopy()
        {
            return ((IProgressTime)Activator.CreateInstance(this.GetType()))
                .Set_p_Progress_max(this.p_Progress_max)
                .Set_p_Progress_now(this.p_Progress_now)
                .Set_p_Progress_Action(this.p_Progress_Action)
                .Set((IProgressTime _this) => 
                {
                    _this.p_CalcIsLocked = this.p_CalcIsLocked;
                })
                .Set_p_WorkOffLine(this.p_WorkOffLine)
            ;
        }
        public IProgressTime Get_InterfaceNewCreateInstance() { return ((IProgressTime)Activator.CreateInstance(this.GetType())); }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());

            IProgressTime _IProgressTime = (new ProgressTime()).Set_p_Progress_Action((int i) => { Console.WriteLine("TestProgressTime:=" + Convert.ToString(i)); });
            if (true)
            {
                _IProgressTime.Set_p_Progress_max(6);
            }
            else
            {
                _IProgressTime.Set_p_Progress_max(7);
            }
            _IProgressTime
                .Set_Start()
                .Set_ProgressNext()
                .Set_ProgressNext()
                .Set_ProgressNext()
                .Set((IProgressTime _this) => { System.Threading.Thread.Sleep(1111); })
                .Set_ProgressNext()
                .Set_ProgressNext()
                .Set_ProgressNext()//Всё дальше _IProgressTime.p_Watch прибовляться не должен
                .Set((IProgressTime _this) => { System.Threading.Thread.Sleep(1111); })
                .Set_ProgressNext()
                .Set_Start()
                ;
            //Console.WriteLine(Convert.ToString());
            Console.WriteLine("_IProgressTime.p_Progress_max=" + Convert.ToString(_IProgressTime.p_Progress_max));
            Console.WriteLine("_IProgressTime.p_Progress_now=" + Convert.ToString(_IProgressTime.p_Progress_now));
            //Console.WriteLine("_IProgressTime.Get_WatchString=" + _IProgressTime.p_Watch.Get_WatchString());
        }
    }
}