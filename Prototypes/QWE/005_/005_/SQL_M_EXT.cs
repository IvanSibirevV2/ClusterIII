using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////////////////////////////////
using Component;
using Component.SQL_Manager;

namespace Component.SQL_Manager
{
    public static class SQL_M_Extension
    {
        /// <summary>Проверка существования базы данных</summary>
        public static bool Get_IsDB_Exists(this ISQL_M _this, string _str_DB_name)
        {
            bool _flagan= false;
            foreach (IList<string> _ILS in _this.Get_InterfaceCopy().Set_p_SQL_String("select name from sys.databases").Do().Get_Resalt().p_ILLS)if (_ILS[0] == _str_DB_name) _flagan = true;
            return _flagan;
        }
        /// <summary>Проверка существования таблици в базе данных, прописанной в контексте</summary>
        public static bool Get_IsTable_Exists(this ISQL_M _this, string _str_Table_name)
        {
            bool _flagan = false;
            foreach (IList<string> _ILS in _this.Get_InterfaceCopy().Set_p_SQL_String("select name from sys.sysobjects").Do().Get_Resalt().p_ILLS)
                if (_ILS[0] == _str_Table_name) _flagan = true;
            return _flagan;
        }
        /// <summary>Проверка существования базы данных+Создание если её нет</summary>
        public static ISQL_M Set_CheckExist_DB(this ISQL_M _this, string _str_DB_name)
        {
            if (!_this.Get_IsDB_Exists(_str_DB_name)) 
                _this.Get_InterfaceCopy().Set_p_SQL_String("CREATE DATABASE "+_str_DB_name+";").Do().Get_Resalt();//Создание базы данных
            return _this.Set((ISQL_M _this_2) => { _this_2.p_IConnectStrGenerator.Set_p_Initial_Catalog(_str_DB_name); })//переключение контекста работы на целевую базу данных
            ;
        }
    }
}
