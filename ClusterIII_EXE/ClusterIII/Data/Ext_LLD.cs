using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ClusterIII.Data.Ext_LLS;

namespace ClusterIII.Data
{
    public static class Ext_LLD
    {
        public static List<List<System.Double>> WriteThis(this List<List<double>> _LLD, uint i = 3u)
        {
            _LLD.Select(a=>System.String.Join("|",a.Select(b=>b.ToString().GetStringtAs(i:i)).ToList())).ToList().ForEach(a=>a.WriteLine());
            return _LLD.ToList();
        }
        /// <summary>Медленное среднеарифметическое по столбцу LLD за вычетом пропущеных значений</summary>
        public static System.Double Get_Average(this List<List<double>> _LLD,int _j=1, ListPoint _IgnorListPoint = null)
        {
            int _count = 0;
            System.Double _Summ = 0;
            for (int i=0;i<_LLD.Count;i++)
            {
                System.Boolean _flag = true;
                if (_IgnorListPoint != null)if (_IgnorListPoint.Where(a => a[0] == i).Where(a => a[1] == _j).ToList().Count != 0)
                    _flag = false;
                if(_flag){_Summ += _LLD[i][_j];_count++;}
            }
            _Summ = _Summ / _count;
            return 0;
        }
        
    }
}
