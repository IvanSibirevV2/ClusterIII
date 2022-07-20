using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusterIII.Model;
using ClusterIII.Converts;

namespace ClusterIII.ClusterMethods
{
    public static  class CHclass
    {
        /// <summary>
        /// Метод - Метрика, расстояние между двумя кластерами. Евклидовое расстояние.
        /// </summary>
        /// <param name="A">Кластер А</param>
        /// <param name="B">Кластер В</param>
        /// <returns>Расстояние между двумя кластерами</returns>
        public static double Distance(Cluster A, Cluster B)
        {
            double rez=0;
            int i = 0;
            foreach(Group MyGpoup in A.CGroupList)
            {
                int j = 0;
                foreach (Param MyParam in MyGpoup.GParamList)
                {
                    rez = rez + Math.Pow((A.CGroupList[i].GParamList[j].P - B.CGroupList[i].GParamList[j].P),2);
                     j = 0;
                }
                i++;
            }            
            return Math.Sqrt(rez);      
        }
        /// <summary>
        /// Центроидный метод.( метод взвешенных групп)
        /// </summary>        
        /// <param name="MyCluster">Обрабатываемые данные</param>
        /// <param name="FinCount">Кнечное количество кластеров</param>
        /// <returns>Результат обработки</returns>
        public static Cluster WeighedGroups(Cluster MyCluster, int FinCount)
        {
            double min = 999999999;
            int jj = 0, ii = 0, counter = 0;
            Cluster MyLocalCluster = new Cluster();
            MyLocalCluster = ClusterConvertTo.NormCluster(MyCluster);
            while ((MyLocalCluster.SCluster.Count >= 2) && (MyLocalCluster.SCluster.Count > FinCount))
            {
                min = 99999999;
                jj = -1;
                ii = -1;
                for (int i = 0; i < MyLocalCluster.SCluster.Count; i++)
                    for (int j = 0; j < MyLocalCluster.SCluster.Count; j++)
                    {
                        if ((i != j) && (min >= Distance(MyLocalCluster.SCluster[i], MyLocalCluster.SCluster[j])))
                        {
                            min = Distance(MyLocalCluster.SCluster[i], MyLocalCluster.SCluster[j]);
                            ii = i;
                            jj = j;
                        }
                    }
                MyLocalCluster.Grouping(ii, jj, "CHName№" + Convert.ToString(counter));
                counter++;
            }
            return MyLocalCluster;
        }
    }
}