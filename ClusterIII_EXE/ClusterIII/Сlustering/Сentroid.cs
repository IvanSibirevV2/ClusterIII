using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusterIII.Data;

namespace ClusterIII.Сlustering
{
    public class Сentroid
    {
        private List<List<System.Double>> p__LLD = new List<List<double>>();
        private int p__N = 2;
        public Сentroid() { }
        public Сentroid Set(
            Сentroid _this=null
            , System.Nullable<int> _N = null
            , List<List<System.Double>> _LLD = null
            ) 
        {
            if (_this != null) this.Set(_this: null,_N:_this.p__N,_LLD:_this.p__LLD);
            if(_N!=null)this.p__N = _N.Value;
            if(_LLD!=null) this.p__LLD= _LLD.Get_Copy();
            return this;
        }
        public System.Boolean p__LockEr = false;
        public Сentroid Do() 
        {
            {
                
            }
            this.p__LockEr = true;
            return this;
        }
        public System.Boolean Get_Resalt() 
        {
            if (!this.p__LockEr) this.Do();
            return this.p__LockEr;
        }
        /// <summary>ClusterIII.Сlustering.Сentroid.Test();</summary>
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 8, _day: 18, _hour: 9, _minute: 44, _second: 0, _millisecond: 0, _StrComment: "Тест ClusterIII.Сlustering.Сentroid.Test();")]
        public static System.Boolean Test() 
        {
            System.Boolean testBooleanResalt = true;

            return testBooleanResalt;
        }
    }
}
