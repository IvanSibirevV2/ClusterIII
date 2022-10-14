using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//////////////////////////////////////////////////////
using Component;

namespace Component.UltimateChoicer
{
    public interface IObjectReader
    {
        string p_OperationName{get;set;}
        string p_ParamName{ get; set; }
        string p_StartValue { get; set; }
        string p_Resalt { get; set; }
        IProgressTime p_IProgressTime { get; set; }
        /////////////////////////////////////////////////////
        IObjectReader Set(Action<IObjectReader> x);
        IObjectReader Set_p_OperationName(string _p_OperationName);
        IObjectReader Set_p_ParamName(string _p_ParamName);
        IObjectReader Set_p_StartValue(string _p_StartValue);
        IObjectReader Set_p_IProgressTime(IProgressTime _p_IProgressTime);
        /////////////////////////////////////////////////////
        IObjectReader Do();
        string Get_Resalt();
        IObjectReader Get_InterfaceCopy();
        IObjectReader Get_InterfaseNewCreateInstance();
    }
    public class ObjectReader : IObjectReader
    {
        private string p__OperationName = "=";
        public string p_OperationName{get { return this.p__OperationName; }set { this.p__OperationName=value; }}
        private string p__ParamName = "ParamName_ObjectReader";
        public string p_ParamName{get { return this.p__ParamName; }set { this.p__ParamName = value; }}
        private string p__StartValue = "";
        public string p_StartValue{get { return this.p__StartValue; }set { this.p__StartValue = value; }}
        private string p__Resalt = Convert.ToString(new object());
        public string p_Resalt{get { return this.p__Resalt; }set { this.p__Resalt = value; }}
        private bool p__CalculationIsLocked = false;
        public bool p_CalculationIsLocked{get { return this.p__CalculationIsLocked; }set { this.p__CalculationIsLocked = value; }}
        private IProgressTime p__IProgressTime = new ProgressTime();
        public IProgressTime p_IProgressTime { get { return this.p__IProgressTime; } set { this.p__IProgressTime = value; } }
        /////////////////////////////////////////////////////
        public IObjectReader Set(Action<IObjectReader> x) { x(this); return this; }
        public IObjectReader Set_p_OperationName(string _p_OperationName) { this.p_OperationName = _p_OperationName; return this; }
        public IObjectReader Set_p_ParamName(string _p_ParamName) { this.p_ParamName = _p_ParamName; return this; }
        public IObjectReader Set_p_StartValue(string _p_StartValue) { this.p_StartValue = _p_StartValue; return this; }
        public IObjectReader Set_p_IProgressTime(IProgressTime _p_IProgressTime) { this.p_IProgressTime = _p_IProgressTime; return this; }
        /////////////////////////////////////////////////////
        public IObjectReader Do()
        {
            this.p_IProgressTime.Set_Start();

            Console.Write(this.p_ParamName);
            Console.Write(this.p_OperationName);
            string rez = Console.ReadLine();
            System.Threading.Tasks.Task.Delay(2000000);
            this.p_Resalt = rez;
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public string Get_Resalt() 
        {
            if (!this.p_IProgressTime.p_CalcIsLocked) this.Do();
            return this.p_Resalt;
        }
        public IObjectReader Get_InterfaceCopy()
        {
            return ((IObjectReader)Activator.CreateInstance(this.GetType()))
                .Set_p_OperationName(this.p_OperationName)
                .Set_p_ParamName(this.p_ParamName)
                .Set_p_IProgressTime(this.p_IProgressTime.Get_InterfaceCopy())
                .Set((IObjectReader _this) => {_this.p_Resalt=this.p_Resalt;})
            ;
        }
        public IObjectReader Get_InterfaseNewCreateInstance(){return ((IObjectReader)Activator.CreateInstance(this.GetType()));}
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());
            Console.WriteLine("Получаем значение = " +
                (new ObjectReader())
                    .Set_p_OperationName("=")
                    .Set_p_ParamName("Text")
                    .Do()
                    .Get_Resalt()
            )
            ;
        }
    }
}