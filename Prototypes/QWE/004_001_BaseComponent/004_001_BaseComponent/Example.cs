using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    public interface IExample
    {
        string p_ExampleParam { get; set; }
        IProgressTime p_IProgressTime { get; set; }
        Example.Resalt p_Resalt { get; set; }
        ////////////////////////////////////////////////////////////////
        IExample Set(Action<IExample> x);
        IExample Set_p_ExampleParam(string _p_ExampleParam);
        IExample Set_p_IProgressTime(IProgressTime _p_IProgressTime);
        ////////////////////////////////////////////////////////////////
        IExample Do();
        Example.Resalt Get_Resalt();
        ////////////////////////////////////////////////////////////////
        IExample Get_InterfaceCopy();
        IExample Get_InterfaceNewCreateInstance();
    }
    public class Example : IExample
    {
        public string p_ExampleParam { get; set; }
        public IProgressTime p_IProgressTime { get; set; }
        public Resalt p_Resalt { get; set; }
        public class Resalt
        {
            public string p_str = "";
        }
        public Example()
        {
            this.Set_p_IProgressTime(new ProgressTime()).p_Resalt = new Resalt();
        }
        //////////////////////////////////////////////////////////////////////////////////////
        public IExample Set(Action<IExample> x) { x(this); return this; }
        public IExample Set_p_ExampleParam(string _p_ExampleParam) { this.p_ExampleParam = _p_ExampleParam; return this; }
        public IExample Set_p_IProgressTime(IProgressTime _p_IProgressTime) { this.p_IProgressTime = _p_IProgressTime; return this; }
        //////////////////////////////////////////////////////////////////////////////////////
        public IExample Do()
        {
            this.p_IProgressTime.Set_Start();
            {this.p_Resalt.p_str = "CalcFin"; }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public Resalt Get_Resalt() { if (!this.p_IProgressTime.p_CalcIsLocked) this.Do(); return this.p_Resalt; }
        public IExample Get_InterfaceCopy()
        {
            return ((IExample)Activator.CreateInstance(this.GetType()))
                .Set_p_ExampleParam(this.p_ExampleParam)
                .Set((IExample _this) => { _this.p_Resalt = this.p_Resalt; })
            ;
        }
        public IExample Get_InterfaceNewCreateInstance() { return ((IExample)Activator.CreateInstance(this.GetType())); }
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());

            IExample _IExample = new Example();
            _IExample.p_ExampleParam = "123";
            _IExample.Do();

            string STR = _IExample.p_Resalt.p_str;
            Console.WriteLine(STR);

            string STR2 = (new Example())
                .Set_p_ExampleParam("123")
                .Do().Get_Resalt().p_str;
            Console.WriteLine(STR2);
        }
    }
}