using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////////////////////////////////////////////
using Component;
using Component.UltimateChoicer;
/////////////////////////////////////////////////////////
namespace Component.LLSDataSource.Script
{
    public static class Clipboard
    {
        public static void TestScript() 
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            Clipboard.Script_Get_LLS_From_Clipboard_ConsoleVersion(new Component.UltimateChoicer.Choicer());
            Clipboard.Script_Get_LLS_From_Clipboard_ConsoleVersion(new Component.UltimateChoicer.Choice_WinForm()); 
        }
        /// <summary>Получение таблици из офисного пакета через буфер обмена</summary>
        public static List<List<string>> Script_Get_LLS_From_Clipboard_ConsoleVersion(IChoicer _IChoicer_Bool)
        {
            return Script_Get_LLS_From_Clipboard_ConsoleVersion(_IChoicer_Bool, Component.LLSDataSource.Standart.Data_Super_Small()); 
        }
        public static List<List<string>> Script_Get_LLS_From_Clipboard_ConsoleVersion(IChoicer _IChoicer_Bool, List<List<string>> _LLS_DefaultClipboard)
        {
            List<List<string>> _LLS_RESALT = Component.LLSDataSource.Standart.Data_Super_Small();
            Console.WriteLine("Копировать таблицу данных из офисного приложения нужно вместе с шапкой названий столбцов и строк");
            Console.WriteLine("Заранее убедитесь что нет повторяющихся названий строк и столбцов");
            Console.WriteLine("Например вот так");
            _LLS_RESALT.writeThis(5);
            
            bool _flagan = true;
            //зациклить , пока внешний булевый параметр не подтверлит получение данных
            while (_flagan)
            {
                System.Windows.Forms.Clipboard.SetText(Component.LLSDataSource.Ext_InputData_SV_ListListString.ListListStringToInputData(_LLS_DefaultClipboard.Get_Copy()));//Занести стандартные данные в Clipboard_WinForm
                
                _IChoicer_Bool.Get_InterfaseNewCreateInstance()
                    .Set_p_PostRepeaterMode(false)
                    .Set_p_Title("Скопируйте таблицу данных из офисного приложения в буфер обмена и подтвердите дейтсвие")
                    .Set_p_IListIUC((new IUltimateChoice[] { 
                        (new UltimateChoice()).Set_p_ChoiceName("Да, я скопировал таблицу данных в буфер обмена").Set_p_Action((IUltimateChoice _this)=>{;}).Set_p_PostRepeater(false)}).ToList<IUltimateChoice>())
                .Do().Get_Resalt();

                if (System.Windows.Forms.Clipboard.ContainsText())
                {
                    Console.WriteLine("Текст в буфере есть");//+"\n"+ System.Windows.Forms.Clipboard_WinForm.GetText());
                    List<List<string>> _lls = Component.LLSDataSource.Ext_InputData_SV_ListListString.InputDataToListListString(System.Windows.Forms.Clipboard.GetText());
                    if ((new Component.DataTest_LLS.DataTest_LLS(_lls)).Set_p_NeedShowMessageBox(false).Set_p_NeedShowConsole(false).GetResalt().p_Resalt)
                    {
                        _LLS_RESALT.Clear();_LLS_RESALT = _lls.Get_Copy();
                        Console.WriteLine("Данные прошли тесты на целостность и добавлены");
                        _flagan = false;
                    }
                    else
                    {
                        Console.WriteLine("Данные не прошли тесты на целостность.");Console.WriteLine("Вывожу список результатов тестов");
                        (new Component.DataTest_LLS.DataTest_LLS(_lls)).Set_p_NeedShowMessageBox(false).Set_p_NeedShowConsole(true).Do();
                    }
                }
                else { System.Windows.Forms.MessageBox.Show("Текста в буфере нет"); }
                //иначе повторить
            }
            return _LLS_RESALT;
        }
    }
}