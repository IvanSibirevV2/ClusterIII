using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.LLSDataSource
{
    public static class Ext_InputData_SV_ListListString
    {
        public static string Get_ListListStringToInputData(this List<List<string>> LLS)
        {return ListListStringToInputData(LLS);}
        public static List<List<string>> Get_InputDataToListListString(this string str)
        {return InputDataToListListString(str);}
        /// <summary>
        /// Преобразование входных текстовых данных в таблицы _ InputData_Convert_ToListListString
        /// дЛЯ ПРЕОБРАЗОВАНИЯ В ТЕКСТ И ОБРАТНО
        /// </summary>
        public static List<List<string>> InputDataToListListString(string str)
        {
            List<List<string>> ListListString_Table = new List<List<string>>();
            int IMax = str.Split((char)10).Count() - 1-1;
            int JMax = str.Split((char)10)[0].Split((char)9).Count() - 1-1;
            for (int i = 0; i < IMax; i++)
            {
                ;
                List<string> kiss = new List<string>();
                for (int j = 0; j < JMax; j++)
                    kiss.Add(str.Split((char)10)[i].Split((char)9)[j]);
                ListListString_Table.Add(kiss);
            }
            return ListListString_Table;
        }
        public static string ListListStringToInputData(List<List<string>> LLS)
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
