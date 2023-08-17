using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Сlustering
{
    public class Сentroid
    {
        private List<List<System.Double>> LLD = new List<List<double>>();
        private int p__N = 2;
        public int p_N { get { return this.p__N; } set { this.p__N = value; } }
        public Сentroid() { }
        public Сentroid Set(Сentroid _this=null) 
        {

            return this;
        }
    }
}
