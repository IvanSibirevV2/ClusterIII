using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "004_001_BaseComponent";
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            //Оглавление: Содержимое ядра / Стендовые тесты компонента
            /////////////////////////////////////////////////////////////////////////////////
            //Component.Consoller_Shabloner.Test();
            //Component.ProgressTime.Test();
            //Component.StackTracer.Test();
            //Component.ExtStopwatch_v2.Test();
            /////////////////////////////////////////////////////////////////////////////////
            //Component.UltimateChoicer.ObjectReader.Test();
            //Component.UltimateChoicer.ObjectReader_WinForm.Test();
            /////////////////////////////////////////////////////////////////////////////////
            //Component.UltimateChoicer.Choicer.Test();
            //Component.UltimateChoicer.Choice_WinForm.Test();

            /////////////////////////////////////////////////////////////////////////////////
            //Component.Example.Test();
            Console.WriteLine("Работа программы завершена успешно");
            Console.Read();
        }
    }
}