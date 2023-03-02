using ClusterIII.Data.Standart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Data
{
    /// <summary>
    /// Класс шаблон для хранения данных в p_LLS и сопутствующих данных
    /// </summary>
    public class LLSData
    {
        public List<List<System.String>> p_LLS = new List<List<string>>();
        public LLSData Set(LLSData _this = null, List<List<string>> _LLS = null)
        {
            if (_this != null) this.Set(_this: null, _LLS: _this.p_LLS.Get_Copy());
            if (_LLS != null) this.p_LLS = _LLS;
            return this;
        }
        public LLSData() { }
        /// <summary> Проверяем одинаковое ли кол-во элементов в строке</summary><returns></returns>
        public System.Boolean DataTest_1() => (this.p_LLS.Select(x => x.Count()).Average() == this.p_LLS.First().Count());
        /// <summary>Проверка на столбцы>2 и строки>2</summary>
        public System.Boolean DataTest_2() => (this.p_LLS.Count() > 2 && this.p_LLS.Where(x => x.Count > 2).Select(x => x).Count() == this.p_LLS.Count() && this.p_LLS.Count() > 2);
        /// <summary>Проверка на конвертацию в double или ==NaN</summary>
        public System.Boolean DataTest_3() => new System.Double().Get(qwer =>
            this.p_LLS
                .AsParallel()
                .Where((a, i) => i != 0)
                .Select(a => a
                    .AsParallel()
                    .Where((b, i) => i != 0)
                    .Select(b =>System.Double.TryParse(b, out qwer) || (b == "NaN"))
                    .Aggregate((s, d) => s && d)
                )
                .Aggregate((s, d) => s && d)
        );
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Boolean DataTest_All() =>
            this.DataTest_1().Set(a =>a.ToString().Add("-Проверяем одинаковое ли кол-во элементов в строке").WriteLine())
            && this.DataTest_2().Set(a => a.ToString().Add("-Проверка на столбцы>2 и строки>2").WriteLine())
            && this.DataTest_3().Set(a => a.ToString().Add("-Проверка на конвертацию в double или ==NaN").WriteLine())
        ;
        /// <summary>Выводит на экран строковую таблицу.</summary> <returns></returns>
        public LLSData WriteThis(uint i=4)
        {this.p_LLS.Select(a => a.Select(b => b.ToString().GetStringtAs(i).Add("|").Write()).ToList().Set(b => "".WriteLine())).ToList();return this;}
        
    }

    public static class Ext_LLS 
    {
        public static List<System.String> Get_Copy(this List<System.String> _this)=>_this.Select(a=>a).ToList();
        public static List<List<System.String>> Get_Copy(this List<List<System.String>> _this) => _this.Select(a => a.Get_Copy()).ToList();
        public static List<List<List<System.String>>> Get_Copy(this List<List<List<System.String>>> _this) => _this.Select(a => a.Get_Copy()).ToList();
    }
}
