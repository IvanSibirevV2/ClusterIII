using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClustererData
{
    public class CH
    {
        public void WeighedGroups(Cluster MyCluster, int FinCount)
        {
            double min = 999999999;
            int jj = 0, ii = 0, counter = 0;
            /*
            Cluster MyLocalCluster = new Cluster();
            MyLocalCluster = MyCluster;


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
             * */
            //return ;
        }
    }
}
