using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Data
{
    public static class Ext_LLS_Data_SuperSmallNaN
    {
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 3, _day: 6, _hour: 9, _minute: 26, _second: 0, _millisecond: 0, _StrComment: "Тест ClusterIII.Data.Ext_LLS_Data_SuperSmallNaN.Test();")]
        public static System.Boolean Test() => new List<List<System.String>>().Set__Data_SuperSmallNaN().WriteThis(4).DataTest_All();
        public static List<List<System.String>> Set__Data_SuperSmallNaN(this List<List<System.String>> _this) =>
            _this.Set_Clear()
            .Set_Add(new List<string>() { "А00", "П1", "П2", "П3", "П4", "П5" })
            .Set_Add(new List<string>() { "А01", "1", "1", "1", "1", "1" })
            .Set_Add(new List<string>() { "А02", "1", "1", "0", "0", "1" })
            .Set_Add(new List<string>() { "А03", "1", "1", "0", "0", "0" })
            .Set_Add(new List<string>() { "А04", "1", "1", "0", "0", "0" })
            .Set_Add(new List<string>() { "А05", "1", "NaN", "0", "1", "1" })
            .Set_Add(new List<string>() { "А06", "0", "0", "0", "0", "0" })
            .Set_Add(new List<string>() { "А07", "1", "0", "0", "1", "1" })
            .Set_Add(new List<string>() { "А08", "1", "1", "0", "0", "1" })
            .Set_Add(new List<string>() { "А09", "1", "1", "1", "1", "1" })
            .Set_Add(new List<string>() { "А10", "1", "0", "0", "1", "1" })
            .Set_Add(new List<string>() { "А11", "0", "0", "NaN", "0", "0" })
        ;
    }
}
