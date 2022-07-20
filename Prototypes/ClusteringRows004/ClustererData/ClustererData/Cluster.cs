using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClustererData
{
    public class Cluster
    {
        public System.Data.DataTable ClusterDataTable = new System.Data.DataTable("ClusterDataTable");
        public int count = 0;

        /*
        public System.Data.DataRow GetRow(int i)
        {
            return this.ClusterDataTable.Rows[i];
        }

        public String GetPoint(int i, int j)
        {
            return Convert.ToString(this.ClusterDataTable.Rows[i].ItemArray[j]);
        }
         * */

        public void SetClusterDataTable(string text)
        {            
            Worker LocalWorker = new Worker();
            List<string> Rows = LocalWorker.GetRow(text);
            List<string> Words = LocalWorker.GetWord(Rows[0]);
            #region Пишем Названия параметров                
                foreach (string MyWordsString in Words)
                {                
                    ClusterDataTable.Columns.Add(new System.Data.DataColumn(MyWordsString, typeof(string)));                
                }
                ClusterDataTable.Columns.Add(new System.Data.DataColumn("Кластер", typeof(string)));                
            #endregion


                
            #region Пишем Объекты и их параметры

                bool flag = false;                           
                //foreach (string MyRolsString in Rows)
                for (int i = 0; i < Rows.Count()-1; i++)
                {                    
                    if (flag)
                    {
                        ClusterDataTable.Rows.Add(LocalWorker.GetWord(Rows[i]).ToArray());
                        ClusterDataTable.Rows[i].ItemArray[ClusterDataTable.Columns.Count()]=Convert.ToString( 0);
                        count++;                        
                    }
                    else 
                    {
                        flag = true;
                    }
                }
            #endregion
        }
    }
}
