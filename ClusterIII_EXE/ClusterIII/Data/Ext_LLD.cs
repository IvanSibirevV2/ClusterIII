using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Data
{
    public static class Ext_LLD
    {
        public static List<List<System.Double>> WriteThis(this List<List<double>> _LLD, uint i = 3u)
        {
            _LLD.Select(a=>System.String.Join("|",a.Select(b=>b.ToString().GetStringtAs(i:i)).ToList())).ToList().ForEach(a=>a.WriteLine());
            return _LLD.ToList();
        }
        public static List<List<List<System.Double>>> WriteThis(this List<List<List<double>>> _LLLD, uint i = 3u)
        {
            foreach (var QWE in _LLLD)
            {
                "Cluster".WriteLine();
                QWE.WriteThis(i);
            }
            "".WriteLine();
            return _LLLD;
        }
        /// <summary>Медленное среднеарифметическое по столбцу LLD за вычетом пропущеных значений</summary>
        public static System.Double Get_Average(this List<List<double>> _LLD,int _j=1, Ext_LLS.ListPoint _IgnorListPoint = null)
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
        public static List<System.Double> Get_Copy(this List<System.Double> _LD)
        { 
            List<System.Double> _LD_ = new List<System.Double>();
            foreach(System.Double var in _LD)
                _LD_.Add(var);
            return _LD_;
        }
        public static List<List<System.Double>> Get_Copy(this List<List<System.Double>> _LLD)
        {
            List<List<double>> _LLD_ = new List<List<double>>();
            foreach(List<double> _LD_ in _LLD) 
                _LLD_.Add(_LD_.Get_Copy());
            return _LLD_;
        }
        public static List<List<List<System.Double>>> Get_Copy(this List<List<List<System.Double>>> _LLLD)
        {
            List<List<List<double>>> _LLLD_ = new List<List<List<double>>>();
            foreach (List<List<double>> _LLD_ in _LLLD) 
                _LLLD_.Add(_LLD_.Get_Copy());
            return _LLLD_;
        }
        
    }
}
