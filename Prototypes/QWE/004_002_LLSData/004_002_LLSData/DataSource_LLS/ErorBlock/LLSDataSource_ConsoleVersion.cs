using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////////////////////////

//LLSDataSource_System_Windows_FormsVersion
namespace Component.LLSDataSource
{
    public interface ILLSDataSource
    {
        IList<IList<IList<string>>> p_ILLLS { get; set; }
        int p_checked_ILLLS_index{get;}
        ////////////////////////////////////////////////////////////////////////
        ILLSDataSource Set(Action x);
        ILLSDataSource Set_p_LLLS(IList<IList<IList<string>>> _p_LLLS);
        ILLSDataSource Do();
        IList<IList<string>> Get_Resalt();
    }
    /// <summary>Класс получения из буфера обмена массива обрабатываемых данны</summary>
    public class LLSDataSource_ConsoleClipboardV:ILLSDataSource
    {
        public IList<IList<IList<string>>> p__ILLLS = new List<IList<IList<string>>>();
        public IList<IList<IList<string>>> p_ILLLS
        {
            get {return this.p__ILLLS;}
            set {this.p__ILLLS = value;}
        }
        public int p__checked_ILLLS_index=-1;
        public int p_checked_ILLLS_index
        {
            get { return this.p__checked_ILLLS_index; }
            private set { this.p__checked_ILLLS_index = value; }
        }
        /// <summary>Дефолтные данные для загрузки из буфера обмена</summary>
        private IList<IList<string>> p_ILLS_DefaultClipboard = new List<IList<string>>();
        ////////////////////////////////////////////////////////////////////////
        public ILLSDataSource Set(Action x) { x(); return this; }
        public ILLSDataSource Set_p_LLLS(IList<IList<IList<string>>> _p_LLLS) { this.p_ILLLS = _p_LLLS; return this; }
        /// <summary>
        /// Дефолтные данные для загрузки из буфера обмена
        /// Разрешено запускать только после создания экземпляра класса
        /// После установки любого переметра работа будет вестись только через интерфейс
        /// Другие реализации интерфейса (другие классы) могут обладать другим подобным функционалом
        /// </summary>
        public ILLSDataSource Set_p_ILLS_DefaultClipboard(IList<IList<string>> _p_ILLS_DefaultClipboard) { this.p_ILLS_DefaultClipboard = _p_ILLS_DefaultClipboard; return this; }
        ////////////////////////////////////////////////////////////////////////
        public LLSDataSource_ConsoleClipboardV()
        {
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS());
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Small().Get_CopyAsILS());
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Normal().Get_CopyAsILS());
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Big().Get_CopyAsILS());
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Super_Big().Get_CopyAsILS());
            this.Set_p_ILLS_DefaultClipboard(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS());
        }
        public ILLSDataSource Do()
        {
            Func<string, object> MyConsolReadL = (string OperationName) =>
            {
                Console.Write(OperationName);
                object rez = Console.ReadLine();
                System.Threading.Tasks.Task.Delay(2000000);
                return rez;
            };
            //-----------------------------------------------------------------------------------------------------------------------
            this.p_checked_ILLLS_index = -1;
            while ((this.p_checked_ILLLS_index < 0)
                || (this.p_checked_ILLLS_index > this.p_ILLLS.Count-1))
            {
                System.Windows.Forms.Clipboard.SetText(ListListStringToInputData(
                    this.p_ILLS_DefaultClipboard.Get_CopyAsLS()
                    ));
                Console.WriteLine("Выбор набора временных рядов:");
                for (int i = 0; i < this.p_ILLLS.Count;i++ )
                    Console.WriteLine(Convert.ToString(i) + " - "+Convert.ToString((new Component.SPExtractor(this.p_ILLLS[i][0][0])).Get_Param("Name")));
                Console.WriteLine(Convert.ToString(this.p_ILLLS.Count) + " - Забрать таблицу данных из буфера обмена.\n"
                    + " Если сейчас скопировать из офисных таблиц (Ctrl+c;) и выберать этот вариант,\n то скопированное будет использовано");
                this.p_checked_ILLLS_index = Convert.ToInt16(MyConsolReadL(" = "));
                if (this.p_checked_ILLLS_index == this.p_ILLLS.Count)
                #region {...}
                {
                    if (System.Windows.Forms.Clipboard.ContainsText())
                    {
                        Console.WriteLine("Текст в буфере есть \n" 
                            + System.Windows.Forms.Clipboard.GetText());
                        List<List<string>> _lls = InputDataToListListString(
                            System.Windows.Forms.Clipboard.GetText());
                        if ((new Component.DataTest_LLS.DataTest_LLS(_lls))
                                .Set_p_NeedShowMessageBox(false)
                                .Set_p_NeedShowConsole(false)
                                .GetResalt().p_Resalt
                        )
                        {
                            this.p_ILLLS.Add(_lls.Get_CopyAsILS());
                            Console.WriteLine("Данные прошли тесты на целостность и добавлены");
                        }
                        else
                        {
                            Console.WriteLine("Данные не прошли тесты на целостность.");
                            Console.WriteLine("Вывожу список результатов тестов");
                            (new Component.DataTest_LLS.DataTest_LLS(_lls))
                                .Set_p_NeedShowMessageBox(false)
                                .Set_p_NeedShowConsole(true)
                                .Do();
                        }
                    }
                    else { System.Windows.Forms.MessageBox.Show("Текста в буфере нет"); }
                }
                #endregion
            }
            Console.WriteLine("Выбор принят");
            return this;
        }
        public IList<IList<string>> Get_Resalt()
        {
            if (this.p_ILLLS.Count != 0)
            {
                if (this.p__checked_ILLLS_index == -1)
                    this.Do();
                /////////////////////////////////////////////////////////////////////
                if (!this.p_ILLLS[this.p__checked_ILLLS_index].Get_CopyAsLS().LLS_DataTest_())
                    throw new ArgumentException((new StackTracer()).Get_STSS()+"\n Попытка получить некорректные данные","Eror-");
                //this.p_ILLLS[this.p__checked_ILLLS_index]
                return this.p_ILLLS[this.p__checked_ILLLS_index];
            }
            return Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS();
        }
        public static void Test_Choice()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());

            ILLSDataSource _ILLSDataSource = new LLSDataSource_ConsoleClipboardV();
            _ILLSDataSource.Do().Get_Resalt().Get_CopyAsLS().writeThis(5);
        }

        /// <summary>Преобразование входных текстовых данных в таблицы _ InputData_Convert_ToListListString</summary>
        private static List<List<string>> InputDataToListListString(string str)
        {
            List<List<string>> ListListString_Table = new List<List<string>>();
            int IMax = str.Split((char)10).Count() - 1;
            int JMax = str.Split((char)10)[0].Split((char)9).Count() - 1;
            for (int i = 0; i < IMax; i++)
            {
                List<string> kiss = new List<string>();
                for (int j = 0; j < JMax; j++)
                    kiss.Add(str.Split((char)10)[i].Split((char)9)[j]);
                ListListString_Table.Add(kiss);
            }
            return ListListString_Table;
        }
        private static string ListListStringToInputData(List<List<string>> LLS)
        {
            string stolb = "";
            for (int i = 0; i < LLS.Count(); i++)
            {
                string strok = "";
                for (int j = 0; j < LLS[i].Count(); j++) strok = strok + LLS[i][j] + (char)9;
                stolb = stolb + strok + (char)13 + (char)10;
            }
            return stolb;
        }
    }
}
