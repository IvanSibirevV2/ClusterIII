using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//////////////////////////////////////////////////
using Component;

namespace Component.LLSDataSource
{
    /// <summary>LLSDataSource_SystemWindowsFormsClipboardVersion</summary>
    public partial class LLSDataSource_SWFClipboardV : Form, ILLSDataSource
    {
        public IList<IList<IList<string>>> p__ILLLS = new List<IList<IList<string>>>();
        public IList<IList<IList<string>>> p_ILLLS
        {
            get { return this.p__ILLLS; }
            set { this.p__ILLLS = value; }
        }
        public int p__checked_ILLLS_index = -1;
        public int p_checked_ILLLS_index
        {
            get { return this.p__checked_ILLLS_index; }
            private set { this.p__checked_ILLLS_index = value; }
        }
        ////////////////////////////////////////////////////////////////////////
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
        public LLSDataSource_SWFClipboardV()
        {
            InitializeComponent();
            #region Данные, добавляемые по умолчанию
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS());
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Small().Get_CopyAsILS());
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Normal().Get_CopyAsILS());
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Big().Get_CopyAsILS());
            this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Super_Big().Get_CopyAsILS());
            this.Set_p_ILLS_DefaultClipboard(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS());
            #endregion
            #region 
            int _LastFormHeight = this.Height;
            int _LastFormWidth = this.Width;
            this.SizeChanged += new System.EventHandler((object sender, EventArgs e) => {
                /*
                int _DeltoFormHeight =  this.Height - _LastFormHeight;
                int _DeltoFormWidth =  this.Width - _LastFormWidth;
                this.dataGridView1.Height += _DeltoFormHeight;
                this.dataGridView1.Width += _DeltoFormWidth;
                */
                int thisMinWidth = 350; int thisMinHeight = 75;
                if ((this.Width < thisMinWidth) || (this.Height < thisMinHeight))
                    this.Size = new System.Drawing.Size(thisMinWidth, thisMinHeight);
                this.dataGridView1.Left = 7;
                if (this.dataGridView1.Columns.Count >= 1)
                    this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                if (this.dataGridView1.Columns.Count >= 2)
                    for (int i = 1; i < this.dataGridView1.Columns.Count; i++)
                        this.dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Size = new System.Drawing.Size(this.Width - 30, this.Height - 74);
            });
            #endregion

        }
        public ILLSDataSource Do()
        {
            //УСТАНОВИТЬ В БУФЕР СТАНДАРТНЫЕ ДАННЫЕ
            System.Windows.Forms.Clipboard.SetText((this.p_ILLS_DefaultClipboard.Get_CopyAsLS().Get_ListListStringToInputData()));

            //скидывание предварительных данных в форму
            
            //foreach(IList<IList<string>> _ILLS in this.p_ILLLS)
            this.toolStripComboBox1.Items.Clear();
            for (int i = 0; i < this.p_ILLLS.Count; i++)
                this.toolStripComboBox1.Items.Add(new Component.SPExtractor(this.p_ILLLS[i][0][0]).Get_Param("Name"));
            if(this.toolStripComboBox1.Items.Count==0)
            {
                this.p_ILLLS.Clear();
                this.toolStripComboBox1.Items.Clear();
                this.p_ILLLS.Add(Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS());
                this.toolStripComboBox1.Items.Add(new Component.SPExtractor(this.p_ILLLS[0][0][0]).Get_Param("Name"));
            }
            this.toolStripComboBox1.SelectedIndex = 0;
            this.p_checked_ILLLS_index = 0;
            //////////////////////////////////////////////////////////////////////////
            while (this.ShowDialog() != System.Windows.Forms.DialogResult.OK) ;
            //скидывание конечных данных из форму
            this.p_checked_ILLLS_index = this.toolStripComboBox1.SelectedIndex;
            //////////////////////////////////////////////////////////////////////////
            return this;
        }
        ////////////////////////////////////////////////////////////////////////
        public IList<IList<string>> Get_Resalt()
        {
            if (this.p_ILLLS.Count != 0)
            {
                if (this.p__checked_ILLLS_index == -1)
                    this.Do();
                return this.p_ILLLS[this.p__checked_ILLLS_index];
            }
            return Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS();
        }
        public static void Test_Choice()
        {
            ILLSDataSource _ILLSDataSource = new LLSDataSource_SWFClipboardV();
            _ILLSDataSource.Do().Get_Resalt().Get_CopyAsLS().writeThis(5);
        }
        /// <summary>Преобразование входных текстовых данных в таблицы _ InputData_Convert_ToListListString</summary>
        /*
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
         * */
        /*private static string ListListStringToInputData(List<List<string>> LLS)
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
        */
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {this.DialogResult = System.Windows.Forms.DialogResult.OK;}

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable MyDataTable = this.Converter(this.p_ILLLS[this.toolStripComboBox1.SelectedIndex].Get_CopyAsLS());
            this.dataGridView1.DataSource = MyDataTable;
        }
        private DataTable Converter(List<List<string>> LLS)
        {
            DataTable res = new DataTable();
            for (int j = 0; j < LLS[0].Count(); j++)
                res.Columns.Add(LLS[0][j], typeof(string));
            for (int i = 1; i < LLS.Count; i++)
                res.Rows.Add(LLS[i].Get_Copy().ToArray());
            return res;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Clipboard.ContainsText())
            {this.TextAdder_AsLLS(System.Windows.Forms.Clipboard.GetText());}
            else { System.Windows.Forms.MessageBox.Show("Текста в буфере нет"); }
        }
        private void TextAdder_AsLLS(string _Str) 
        {
            Console.WriteLine("Текст получен \n"+ _Str);
            List<List<string>> _lls = _Str.Get_InputDataToListListString();
            if ((new Component.DataTest_LLS.DataTest_LLS(_lls))
                    .Set_p_NeedShowMessageBox(false)
                    .Set_p_NeedShowConsole(false)
                    .GetResalt().p_Resalt
            )
            {
                this.p_ILLLS.Add(_lls.Get_CopyAsILS());
                this.toolStripComboBox1.Items.Add((new Component.SPExtractor(this.p_ILLLS[this.p_ILLLS.Count - 1][0][0])).Get_Param("Name"));
                this.toolStripComboBox1.SelectedIndex = this.toolStripComboBox1.Items.Count - 1;
                this.p_checked_ILLLS_index = this.toolStripComboBox1.SelectedIndex;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fromTxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog _openFileDialog = new System.Windows.Forms.OpenFileDialog(); ;
            if (_openFileDialog.ShowDialog() != DialogResult.OK)return;
            foreach (var _fileName in _openFileDialog.FileNames)if (System.IO.File.Exists(_fileName))
            {

                int counter = 0;
                string res = "";
                string line;

                System.Console.WriteLine("Читаем из файла");
                System.IO.StreamReader file = new System.IO.StreamReader(_fileName);
                while ((line = file.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                    res += line;
                    counter++;
                }
                if (counter != 0)
                { this.TextAdder_AsLLS(res); }
                else 
                { System.Windows.Forms.MessageBox.Show("Текста в буфере нет"); }
                

                file.Close();


                //Проверить файл на существование....

            }
        }

        private void fomClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int _WGSSJBKNJKLDFKJL = this.p_checked_ILLLS_index;
            this.p_checked_ILLLS_index = this.p_ILLLS.Count();
            if (this.p_checked_ILLLS_index == this.p_ILLLS.Count)
            #region {...}
            {
                if (System.Windows.Forms.Clipboard.ContainsText())
                {
                    Console.WriteLine("Текст в буфере есть \n"
                        + System.Windows.Forms.Clipboard.GetText());
                    List<List<string>> _lls = System.Windows.Forms.Clipboard.GetText().Get_InputDataToListListString();
                    if ((new Component.DataTest_LLS.DataTest_LLS(_lls))
                            .Set_p_NeedShowMessageBox(false)
                            .Set_p_NeedShowConsole(false)
                            .GetResalt().p_Resalt
                    )
                    {
                        this.p_ILLLS.Add(_lls.Get_CopyAsILS());
                        this.toolStripComboBox1.Items.Add((new Component.SPExtractor(this.p_ILLLS[this.p_ILLLS.Count - 1][0][0])).Get_Param("Name"));
                        this.toolStripComboBox1.SelectedIndex = this.toolStripComboBox1.Items.Count - 1;
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
                        this.p_checked_ILLLS_index = _WGSSJBKNJKLDFKJL;
                    }
                }
                else { System.Windows.Forms.MessageBox.Show("Текста в буфере нет"); }
            }
            #endregion
        }

        private void LLSDataSource_SWFClipboardV_Load(object sender, EventArgs e)
        {

        }

    }
}
