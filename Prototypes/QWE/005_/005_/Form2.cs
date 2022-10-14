using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
////////////////////////////////////////////////////////
using Component.SQL_Manager;
using System.Data.SqlClient;

namespace Component
{
    public interface IDataForm
    {
        IDataForm Set(Action<IDataForm> x);
        ////////////////////////////////////////////////////////////////////////////////////////
        Component.SQL_Manager.ISQL_M p_ISQL_M { get; set; } IDataForm Set_p_ISQL_M(Component.SQL_Manager.ISQL_M _p_ISQL_M);
        ////////////////////////////////////////////////////////////////////////////////////////
        IDataForm ShowDialog_();
    }
    public partial class Form2 : Form, IDataForm
    {
        public IDataForm Set(Action<IDataForm> x) { x(this); return this; }
        ////////////////////////////////////////////////////////////////////////////////////////
        public Component.SQL_Manager.ISQL_M p_ISQL_M { get; set; }public IDataForm Set_p_ISQL_M(Component.SQL_Manager.ISQL_M _p_ISQL_M) { this.p_ISQL_M = _p_ISQL_M; return this; }
        ////////////////////////////////////////////////////////////////////////////////////////
        public IDataForm ShowDialog_(){this.ShowDialog();return this;}
        ////////////////////////////////////////////////////////////////////////////////////////
        public Form2()
        {
            this.InitializeComponent();
            this.Set_p_ISQL_M(new Component.SQL_Manager.SQL_M());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //this.Form2_SizeChanged(null, null);
            this.Width_Last = this.Width;
            this.Height_Last = this.Height;
            //////////////////////////////////////////////////////////////////////////////////////////////
            IList<IList<string>> _ILLS = this.p_ISQL_M.Get_InterfaceCopy()//Получаем список таблиц базы данных, указанной в контексте //this.p_ISQL_M.p_IConnectStrGenerator.p_Initial_Catalog
                .Set_p_SQL_String("SELECT TABLE_NAME AS [name] FROM INFORMATION_SCHEMA.TABLES WHERE table_type='BASE TABLE'")
                .Do().Get_Resalt().p_ILLS;
            IList<string> _ILS = new List<string>();//Конвертируем список таблиц базы данных
            for (int i = 1; i < _ILLS.Count; i++) _ILS.Add(_ILLS[i][0]);
            _ILS.writeThis(10);
            foreach(string _s in _ILS)this.toolStripComboBox1.Items.Add(_s);//Запихиваем список таблиц базы данных в выпадающее меню
            this.toolStripComboBox1.SelectedIndex = 0;
            
        }
        private int Width_Last = 0; private int Height_Last = 0;
        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            int sign = 0-1;int Width_Delto = this.Width + sign* this.Width_Last;int Height_Delto = this.Height + sign* this.Height_Last;
            this.dataGridView1.Height += Height_Delto;
            this.dataGridView1.Width += Width_Delto;
            this.Width_Last = this.Width;this.Height_Last = this.Height;
        }
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table = new DataTable();
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IList<IList<string>> _ILLS = this.p_ISQL_M.Get_InterfaceCopy()//Получаем выбранную таблицу
                .Set_p_SQL_String("SELECT * FROM "+this.toolStripComboBox1.Text)
                .Do()
                .Get_Resalt()
                .p_ILLS
                .writeThis(10)
                ;

            string _str_Names = _ILLS[0][0];
            for (int j = 1; j < _ILLS[0].Count; j++)_str_Names += ","+_ILLS[0][j];
            string _str_SelectCommand = " SELECT " + _str_Names + " FROM " + this.toolStripComboBox1.Text;

                //https://docs.microsoft.com/ru-ru/dotnet/api/system.data.sqlclient.sqldataadapter.updatecommand?view=netcore-2.1
                adapter.SelectCommand = new SqlCommand(_str_SelectCommand, new SqlConnection(this.p_ISQL_M.p_IConnectStrGenerator.Get_InterfaceCopy().Do().Get_Resalt()));
                //https://metanit.com/sharp/adonet/3.3.php
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                table = new DataTable();
                this.dataGridView1.DataSource = table;
                adapter.Fill(table);

        }
        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("----" + adapter.Update(table).ToString());
            toolStripComboBox1_SelectedIndexChanged(null, null);
        }
    }
}
