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
            if (_this != null) this.Set(_this: null,_LLS:_this.p_LLS.Get_Copy());
            if (_LLS != null) this.p_LLS = _LLS;
            return this;
        }
        public LLSData() { }
    }
    public static class Ext_LLS 
    {
        public static List<System.String> Get_Copy(this List<System.String> _this)=>_this.Select(a=>a).ToList();
        public static List<List<System.String>> Get_Copy(this List<List<System.String>> _this) => _this.Select(a => a.Get_Copy()).ToList();
        public static List<List<List<System.String>>> Get_Copy(this List<List<List<System.String>>> _this) => _this.Select(a => a.Get_Copy()).ToList();
    }
}
