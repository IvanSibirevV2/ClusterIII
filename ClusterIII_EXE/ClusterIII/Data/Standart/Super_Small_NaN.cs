using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Data.Standart
{
    public class Super_Small_NaN : LLSData
    {
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 2, _day: 3, _hour: 13, _minute: 07, _second: 0, _millisecond: 0, _StrComment: "Тест ClusterIII.Data.Standart.Super_Small_NaN.Test()")]
        public static System.Boolean Test() => new Super_Small_NaN().WriteThis(4).DataTest_All();
        public Super_Small_NaN()=>this.p_LLS.Set(a => a.Clear())
            .Set_Add(new List<string>() { "А00",  "П1",   "П2",   "П3",   "П4",   "П5"})
            .Set_Add(new List<string>() { "А01",  "1",    "1",    "1",    "1",    "1" })
            .Set_Add(new List<string>() { "А02",  "1",    "1",    "0",    "0",    "1" })
            .Set_Add(new List<string>() { "А03",  "1",    "1",    "0",    "0",    "0" })
            .Set_Add(new List<string>() { "А04",  "1",    "1",    "0",    "0",    "0" })
            .Set_Add(new List<string>() { "А05",  "1",    "1",    "0",    "1",    "1" })
            .Set_Add(new List<string>() { "А06",  "0",    "0",    "0",    "0",    "0" })
            .Set_Add(new List<string>() { "А07",  "1",    "0",    "0",    "1",    "1" })
            .Set_Add(new List<string>() { "А08",  "1",    "1",    "0",    "0",    "1" })
            .Set_Add(new List<string>() { "А09",  "1",    "1",    "1",    "1",    "1" })
            .Set_Add(new List<string>() { "А10",  "1",    "0",    "0",    "1",    "1" })
            .Set_Add(new List<string>() { "А11",  "0",    "0",    "NaN",  "0",    "0" })
        ;
    }
}