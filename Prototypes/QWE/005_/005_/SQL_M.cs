using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////////////
using System.Data.SqlClient;

namespace Component.SQL_Manager
{
    public interface ISQL_M
    {
        ISQL_M Set(Action<ISQL_M> x);
        //Main///////////////////////////////////////////////////////////////
        string p_SQL_String { get; set; } ISQL_M Set_p_SQL_String(string _p_SQL_String);
        Component.SQL_Manager.IConnectStrGenerator p_IConnectStrGenerator { get; set; } ISQL_M Set_p_IConnectStrGenerator(Component.SQL_Manager.IConnectStrGenerator _p_IConnectStrGenerator);
        //Dop///////////////////////////////////////////////////////////////
        Component.SQL_Manager.SQL_M.Resalt p_Resalt { get; set; }
        Component.IProgressTime p__IProgressTime { get; set; }        

        System.Data.SqlClient.SqlConnection p__SqlConnection { get; set; }
        System.Data.SqlClient.SqlCommand p__SqlCommand { get; set; }
        System.Data.SqlClient.SqlDataReader p__SqlDataReader { get; set; }
        ////////////////////////////////////////////////////////////////
        ISQL_M Do();
        Component.SQL_Manager.SQL_M.Resalt Get_Resalt();
        ////////////////////////////////////////////////////////////////
        ISQL_M Get_InterfaceNewCreateInstance();
        ISQL_M Get_InterfaceCopy();
    }
    public class SQL_M : ISQL_M
    {
        public ISQL_M Set(Action<ISQL_M> x) { x(this); return this; }
        //Main///////////////////////////////////////////////////////////////
        public string p_SQL_String { get; set; }public ISQL_M Set_p_SQL_String(string _p_SQL_String) { this.p_SQL_String = _p_SQL_String; return this; }
        public Component.SQL_Manager.IConnectStrGenerator p_IConnectStrGenerator { get; set; }public ISQL_M Set_p_IConnectStrGenerator(Component.SQL_Manager.IConnectStrGenerator _p_IConnectStrGenerator) { this.p_IConnectStrGenerator = _p_IConnectStrGenerator; return this; }
        //Dop///////////////////////////////////////////////////////////////
        public Component.SQL_Manager.SQL_M.Resalt p_Resalt { get; set; }
        public Component.IProgressTime p__IProgressTime { get; set; }        

        public System.Data.SqlClient.SqlConnection p__SqlConnection { get; set; }
        public System.Data.SqlClient.SqlCommand p__SqlCommand { get; set; }
        public System.Data.SqlClient.SqlDataReader p__SqlDataReader { get; set; }

        public class Resalt 
        {
            public IList<IList<string>> p_ILLS = Component.LLSDataSource.Standart.Data_Super_Small().Get_CopyAsILS();
            public System.Data.DataTable p_DataTable = new System.Data.DataTable();
        }

        public ISQL_M Init()
        {
            return this
                //Main//
                .Set_p_IConnectStrGenerator((new Component.SQL_Manager.ConnectStrGenerator())
                    .Set_p_Data_Source(@"SIB_NOUT-ПК\SQLEPRESS_2008_1")
                    .Set_p_Initial_Catalog(@"master")
                    .Set_p_Integrated_Security(true)
                ).Set_p_SQL_String("select * from sys.databases")
                .Set((ISQL_M _this) =>
                {
                    //Dop//
                    _this.p__IProgressTime = new Component.ProgressTime();
                    _this.p_Resalt =new Component.SQL_Manager.SQL_M.Resalt();

                    _this.p__SqlConnection = new System.Data.SqlClient.SqlConnection();
                    _this.p__SqlCommand = new System.Data.SqlClient.SqlCommand();
                    _this.p__SqlDataReader = null;
//                    _this.p__SqlDataAdapter = new SqlDataAdapter();
                })
            ;
        }
        public SQL_M() { this.Init(); }
        /////////////////////////////////////////////////////////////////
        /*
        public ISQL_M Update()
        {
            //this.p_Resalt.p_DataTable = new System.Data.DataTable();
            this.p__SqlDataAdapter.Update(this.p_Resalt.p_DataTable);
        }
        */
        public ISQL_M Do()
        {
            this.p__IProgressTime.Set_Start();
            {
                bool _flagan_Shapko = true;
                this.p_Resalt.p_ILLS.Clear();

                this.p__SqlConnection.ConnectionString = this.p_IConnectStrGenerator.Get_InterfaceCopy().Do().Get_Resalt();
                this.p__SqlConnection.Open();
                this.p__SqlCommand.Connection = this.p__SqlConnection;
                this.p__SqlCommand.CommandText = this.p_SQL_String;
                {
                    this.p__SqlDataReader = this.p__SqlCommand.ExecuteReader();//Чтение в таблицу
                    this.p_Resalt.p_DataTable = new System.Data.DataTable();
                    this.p_Resalt.p_DataTable.Load(this.p__SqlDataReader);
                }
                {
                    this.p__SqlDataReader = this.p__SqlCommand.ExecuteReader();//Чтение в список
                    while (this.p__SqlDataReader.Read())
                    {
                        IList<string> _ILS = new List<string>();
                        IList<string> _ILS_Shapko = new List<string>();
                        IList<object> _ILO = new List<object>();
                        for (int i = 0; i < this.p__SqlDataReader.FieldCount; i++)
                        {
                            object QWE = this.p__SqlDataReader.GetValue(i);
                            _ILO.Add(this.p__SqlDataReader.GetValue(i));
                            if (_flagan_Shapko) _ILS_Shapko.Add(this.p__SqlDataReader.GetName(i));
                        }
                        foreach (object _obj in _ILO) _ILS.Add(_obj.ToString());
                        if (_flagan_Shapko) this.p_Resalt.p_ILLS.Add(_ILS_Shapko);
                        _flagan_Shapko = false;
                        this.p_Resalt.p_ILLS.Add(_ILS);
                    }
                }
                this.p__SqlConnection.Close();
            }
            this.p__IProgressTime.Set_Stop();
            return this;
        }
        public Component.SQL_Manager.SQL_M.Resalt Get_Resalt() { if (!this.p__IProgressTime.p_CalcIsLocked) this.Do(); return this.p_Resalt; }
        /////////////////////////////////////////////////////////////////
        public ISQL_M Get_InterfaceNewCreateInstance() { return ((ISQL_M)Activator.CreateInstance(this.GetType())); }
        public ISQL_M Get_InterfaceCopy()
        {
            return ((ISQL_M)Activator.CreateInstance(this.GetType()))
                .Set_p_SQL_String(this.p_SQL_String)
                .Set_p_IConnectStrGenerator(this.p_IConnectStrGenerator.Get_InterfaceCopy())
                .Set((ISQL_M _this) =>
                {
                    _this.p__IProgressTime = this.p__IProgressTime.Get_InterfaceCopy();
                    //Пока что обойдемся без глубокого копирования классов для промежуточного вычисления
                    _this.p_Resalt = this.p_Resalt;
                })
            ;
        }
        /////////////////////////////////////////////////////////////////
    }
}