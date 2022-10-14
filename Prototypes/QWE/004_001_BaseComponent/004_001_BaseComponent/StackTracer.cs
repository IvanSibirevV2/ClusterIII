using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    public interface IStackTracer
    {
        List<string> p_LS { get; }
        string p_str_StackTrace { get; }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Get_StackTraceStringSourse</summary>
        string Get_STSS();
        string Get_STSS(int ByStepBackShift);
        List<string> Get_StackTracerAsListString();
        IStackTracer writeThis();
        /////////////////////////////////////////////////////////////////////////////////////////////////
    }
    /// <summary>
    /// Использовать вот так!!!
    /// (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
    ///        .WriteLine((new Component.StackTracer()).writeThis().Get_STSS());
    /// </summary>
    public class StackTracer : IStackTracer
    {
        private string p__str_StackTrace = Environment.StackTrace;
        public string p_str_StackTrace { get { return this.p__str_StackTrace; } }
        private List<string> p__LS = Environment.StackTrace.Split('\n').ToList<string>();
        public List<string> p_LS { get { return this.p__LS; } }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public StackTracer()
        {
            this.p__str_StackTrace = Environment.StackTrace;
            this.p__LS = this.p__str_StackTrace.Split('\n').ToList<string>();
        }
        public string Get_STSS()
        {
            if (this.p__LS.Count > 3)
                return this.p__LS[3].Split('в')[1];
            return "Eror - Environment.StackTrace";
        }
        public string Get_STSS(int ByStepBackShift)
        {
            if (this.p__LS.Count > 3 + ByStepBackShift)
                return this.p__LS[3 + ByStepBackShift].Split('в')[1];
            return "Eror - Environment.StackTrace";
        }
        public List<string> Get_StackTracerAsListString()
        {
            List<string> _lls = new List<string>();
            if (this.p__LS.Count > 3)
                for (int i = 3; i < this.p__LS.Count; i++)
                    _lls.Add(this.p__LS[i].Split('в')[1]);
            return _lls;
        }
        public IStackTracer writeThis()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            //Console.WriteLine("--------------------------------------------------------------");
            foreach (string _str in this.Get_StackTracerAsListString())
                Console.WriteLine(_str);
            return this;
        }
        public static void Test()
        {
            Console.WriteLine("Component.StackTracer Class");
            IStackTracer _IStackTracer = new StackTracer();
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine(_IStackTracer.Get_STSS())
                .WriteLine((new StackTracer()).Get_STSS())
                ;
        }
    }
}