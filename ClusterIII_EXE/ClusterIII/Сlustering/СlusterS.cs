using ClusterIII.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusterIII.Data;

namespace ClusterIII.Сlustering
{
    public partial class СlusterS
    {
        private List<List<List<System.Double>>> p_LLLD = null;
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        private List<List<System.Double>> p_Sourse_LLD = null;
        public СlusterS Set_LLD(List<List<System.Double>> _LLD)
        {
            this.p_Sourse_LLD = _LLD.Get_Copy();
            this.p_LLLD= new List<List<List<double>>>();
            this.p_Sourse_LLD.ForEach(a =>this.p_LLLD.Add(new List<List<double>>().Set_Add(a.Get_Copy())));
            return this;
        }
        /// <summary>Тест размещения LLD в LLLD в специфическом контейнере.</summary>
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 8, _day: 19, _hour: 11, _minute: 17, _second: 0, _millisecond: 0, _StrComment: "")]
        public static System.Boolean Test() 
        {
            СlusterS _СlusterS = new СlusterS();
            _СlusterS.Set_LLD(new List<List<string>>().Set__Data_SuperSmall().Get_As_LLD());
            _СlusterS.p_LLLD__WriteThis();
            _СlusterS.p_Sourse_LLD__WriteThis();
            //Консольный вывод на экран
            return true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public СlusterS p_LLLD__WriteThis(){ ".p_LLLD".WriteLine(); this.p_LLLD.WriteThis();return this;}
        public СlusterS p_Sourse_LLD__WriteThis() { ".p_Sourse_LLD".WriteLine(); this.p_Sourse_LLD.WriteThis(); return this; }
        public СlusterS WriteThis()
        {
            "...СlusterS.WriteThis()".WriteLine();
            this.p_LLLD__WriteThis();
            this.p_Sourse_LLD__WriteThis();
            "".WriteLine();
            return this;
        }
        /// <summary>Тест размещения LLD в LLLD в специфическом контейнере.</summary>
        [System.Diagnostics.TestLastMethod(_year: 2023, _month: 8, _day: 19, _hour: 10, _minute: 59, _second: 0, _millisecond: 0, _StrComment: "")]
        public static System.Boolean Test_WriteThis()
        {
            СlusterS _СlusterS = new СlusterS();
            _СlusterS.Set_LLD(new List<List<string>>().Set__Data_SuperSmall().Get_As_LLD());
            _СlusterS.WriteThis();
            //Консольный вывод на экран
            return true;
        }
    }
}