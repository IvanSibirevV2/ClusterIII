using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Data.Standart
{
    public class Super_Small: LLSData
    {
        public Super_Small()=>this.p_LLS.Set(a => a.Clear())

            .Set_Add(new List<string>() { "А00",    "П1",   "П2",   "П3",   "П4",   "П5"})
            .Set_Add(new List<string>() { "А01",    "1",    "1",    "1",    "1",    "1" })
            .Set_Add(new List<string>() { "А02",    "1",    "1",    "0",    "0",    "1" })
            .Set_Add(new List<string>() { "А03",    "1",    "1",    "0",    "0",    "0" })
            .Set_Add(new List<string>() { "А04",    "1",    "1",    "0",    "0",    "0" })
            .Set_Add(new List<string>() { "А05",    "1",    "1",    "0",    "1",    "1" })
            .Set_Add(new List<string>() { "А06",    "0",    "0",    "0",    "0",    "0" })
            .Set_Add(new List<string>() { "А07",    "1",    "0",    "0",    "1",    "1" })
            .Set_Add(new List<string>() { "А08",    "1",    "1",    "0",    "0",    "1" })
            .Set_Add(new List<string>() { "А09",    "1",    "1",    "1",    "1",    "1" })
            .Set_Add(new List<string>() { "А10",    "1",    "0",    "0",    "1",    "1" })
        ;
        /// <summary>ClusterIII.Data.Standart.Super_Small.Test() </summary>
        public static System.Boolean Test() 
        {
            var _this=new ClusterIII.Data.Standart.Super_Small();
            /*
            qwe.p_LLS
                .Set(q =>q.ForEach(a => { a.ForEach(b => (b + ";").Write()); "".WriteLine(); }))
                .set
            ;
            (qwe.p_LLS.Select(x => x.Count()).Average() % 1 == 0 ? true : false).ToString().WriteLine();
            

            //Console.WriteLine(Super_Small.?"true":"false");
            */
            return true
                &&(_this.p_LLS.Select(x => x.Count()).Average() % (int)_this.p_LLS.Select(x => x.Count()).Average() == 0).Set(b=>b.ToString().WriteLine())
                //Првоерка на > 2
                && (_this.p_LLS.Count() >2 && _this.p_LLS.Where(x=>x.Count>2).Select(x=>x).Count()== _this.p_LLS.Count() ).Set(b => b.ToString().WriteLine())
                //
                .SetIf(_fBool: a => a, _f1: a => {
                    //_this.p_LLS.ForEach()
                })


            ;
        }
    }
}
