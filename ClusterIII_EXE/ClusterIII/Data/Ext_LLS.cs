using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Data
{
    public static class Ext_LLS
    {
        public static List<List<string>> WriteThis(this List<List<String>> _this,uint i = 4)
        {
            _this
                .AsParallel().Select(a => System.String.Join("|", a.AsParallel().Select(b=>b.ToString().GetStringtAs(i)).ToList())).ToList()
                .ForEach(a => a.WriteLine() )
                ;
            return _this; 
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static List<System.String> Get_Copy(this List<System.String> _this) => _this.Select(a => a).ToList();
        public static List<List<System.String>> Get_Copy(this List<List<System.String>> _this) => _this.Select(a => a.Get_Copy()).ToList();
        public static List<List<List<System.String>>> Get_Copy(this List<List<List<System.String>>> _this) => _this.Select(a => a.Get_Copy()).ToList();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Проверяем одинаковое ли кол-во элементов в строке</summary><returns></returns>
        public static System.Boolean DataTest_1(this List<List<System.String>> _this) =>
            (_this.Select(x => x.Count()).Average() == _this.First().Count())
            .Set(a => a.ToString().Add("-Проверяем одинаковое ли кол-во элементов в строке").WriteLine())
        ;
        /// <summary>Проверка на столбцы>2 и строки>2</summary>
        public static System.Boolean DataTest_2(this List<List<System.String>> _this) =>
            (_this.Count() > 2 && _this.Where(x => x.Count > 2).Select(x => x).Count() == _this.Count() && _this.Count() > 2)
            .Set(a => a.ToString().Add("-Проверка на столбцы>2 и строки>2").WriteLine())
        ;
        /// <summary>Проверка на конвертацию в double или ==NaN</summary>
        public static System.Boolean DataTest_3(this List<List<System.String>> _this) => new System.Double().Get(qwer =>
            _this
                .AsParallel()
                .Where((a, i) => i != 0)
                .Select(a => a
                    .AsParallel()
                    .Where((b, i) => i != 0)
                    .Select(b => System.Double.TryParse(b, out qwer) || (b == "NaN"))
                    .Aggregate((s, d) => s && d)
                )
                .Aggregate((s, d) => s && d)
            .Set(a => a.ToString().Add("-Проверка на конвертацию в double или ==NaN").WriteLine())
        );
        /// <sum     mary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static System.Boolean DataTest_All(this List<List<System.String>> _this) => _this.DataTest_1() && _this.DataTest_2() && _this.DataTest_3();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
