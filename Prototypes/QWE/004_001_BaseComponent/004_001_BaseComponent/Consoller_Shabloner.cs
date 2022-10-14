using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////
using System.Drawing;

namespace Component
{
    public interface IConsoller_Shabloner
    {
        ConsoleColor p_ForegroundColor{get;set;}
        ConsoleColor p_BackgroundColor{get;set;}
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        IConsoller_Shabloner Set(Action<IConsoller_Shabloner> x);
        IConsoller_Shabloner Set_p_ForegroundColor(ConsoleColor _p_ForegroundColor);
        IConsoller_Shabloner Set_p_BackgroundColor(ConsoleColor _p_BackgroundColor);
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        IConsoller_Shabloner Set_StandartSettings();
        IConsoller_Shabloner Set_ColorS(ConsoleColor _ForegroundColor, ConsoleColor _BackgroundColor);
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        IConsoller_Shabloner Write(string str);
        IConsoller_Shabloner WriteLine(string str);
        ////////////////////////////////////////
        IConsoller_Shabloner Get_InterfaceCopy();
        IConsoller_Shabloner Get_InterfaceNewCreateInstance();
        ////////////////////////////////////////
        IConsoller_Shabloner BrowseView(bool NeedWait);
    }
    /// <summary>Компонент для цветной визуализации текста в консоли с#</summary>
    public class Consoller_Shabloner : IConsoller_Shabloner
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private ConsoleColor p__ForegroundColor = ConsoleColor.Gray;
        public ConsoleColor p_ForegroundColor{get { return this.p__ForegroundColor; }set { this.p__ForegroundColor = value; }}
        private ConsoleColor p__BackgroundColor = ConsoleColor.Black;
        public ConsoleColor p_BackgroundColor{get { return this.p__BackgroundColor; }set { this.p__BackgroundColor = value; }}
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IConsoller_Shabloner Set(Action<IConsoller_Shabloner> x) { x(this); return this; }
        public IConsoller_Shabloner Set_p_ForegroundColor(ConsoleColor _p_ForegroundColor){ this.p_ForegroundColor = _p_ForegroundColor; return this; }
        public IConsoller_Shabloner Set_p_BackgroundColor(ConsoleColor _p_BackgroundColor) { this.p_BackgroundColor = _p_BackgroundColor; return this; }
        public IConsoller_Shabloner Set_StandartSettings() { return this.Set_ColorS(ConsoleColor.Gray, ConsoleColor.Black); }
        public IConsoller_Shabloner Set_ColorS(ConsoleColor _ForegroundColor, ConsoleColor _BackgroundColor)
        {return this.Set_p_ForegroundColor(_ForegroundColor).Set_p_BackgroundColor(_BackgroundColor);}
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Consoller_Shabloner() { }
        public Consoller_Shabloner(ConsoleColor _ForegroundColor, ConsoleColor _BackgroundColor) { this.Set_ColorS(_ForegroundColor, _BackgroundColor); }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IConsoller_Shabloner Write(string str)
        {
            Console.ForegroundColor = this.p_ForegroundColor;Console.BackgroundColor = this.p_BackgroundColor;
            Console.Write(str);
            {Console.ForegroundColor = ConsoleColor.Gray;Console.BackgroundColor = ConsoleColor.Black;}
            return this;
        }
        public IConsoller_Shabloner WriteLine(string str) { this.Write(str); Console.Write("\n"); return this; }

        public IConsoller_Shabloner BrowseView(bool NeedWait)
        {
            Consoller_Shabloner CW = new Consoller_Shabloner();
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            foreach (ConsoleColor backgroundColor in colors)
            {
                foreach (ConsoleColor foregroundColor in colors)
                {
                    string str = foregroundColor.ToString() + " " + backgroundColor.ToString();
                    (new Consoller_Shabloner()).Set_ColorS(foregroundColor, backgroundColor).WriteLine(str);
                    (new Consoller_Shabloner()).WriteLine(str);
                }
                Console.WriteLine();Console.WriteLine();
                if (NeedWait) Console.Read();
            }
            return this;
        }
        ////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());
            IConsoller_Shabloner _qwe = (new Component.Consoller_Shabloner())
                .BrowseView(true)
                ;
            Console.Read();
        }
        ////////////////////////////////////////
        public IConsoller_Shabloner Get_InterfaceCopy()
        {
            return ((IConsoller_Shabloner)Activator.CreateInstance(this.GetType()))
                .Set_p_BackgroundColor(this.p_BackgroundColor)
                .Set_p_ForegroundColor(this.p_ForegroundColor)
            ;
        }
        public IConsoller_Shabloner Get_InterfaceNewCreateInstance(){return ((IConsoller_Shabloner)Activator.CreateInstance(this.GetType()));}
    }
}