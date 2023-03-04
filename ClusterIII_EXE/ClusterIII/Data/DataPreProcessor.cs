using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterIII.Data
{
    /// <summary>
    /// Data Preprocessing
    /// LLSData==>конвертирование==>нормирование==>Восстановление==>LLDData
    ///        =>заполнение нулями=>заполнение СрАрифм=>Восстановлено=>
    ///        ============>список для восстановления==========>
    /// </summary>
    public class DataPreProcessor
    {

        public LLSData p_LLSData = new LLSData();
        public LLDData p_LLDData = new LLDData();
        /// <summary> Промежуточная переменная только для результатов конвертирования this.p_LLSData=>this.p_LLDDataStep1;this.p_LLSData=>this.p_LNaNT Пропуски=>заполнение нулями</summary>
        public LLDData p_LLDDataStep1 = new LLDData();
        /// <summary> NaN_Target - Координаты пропуска</summary>
        public class NaNT
        {
            public int p_X = -1;
            public int p_Y = -1;
            public NaNT Set(NaNT _this, System.Nullable<int> _X = null, System.Nullable<int> _Y = null)
            {
                if (_this != null) this.Set(_this: null, _X: _this.p_X, _Y: this.p_Y);
                if (_X != null) this.p_X = _X.Value;
                if (_Y != null) this.p_Y = _Y.Value;
                return this;
            }
        }
        public List<NaNT> p_LNaNT = new List<NaNT>();
        public DataPreProcessor Set_Step1() { return this; }
        /// <summary> Промежуточная переменная только для результатов нормирования this.p_LLDDataStep1=>this.p_LLDDataStep2; Пропуски=>заполнение средним арифметическим </summary>
        public LLDData p_LLDDataStep2 = new LLDData();
        public DataPreProcessor Set_Step2() { return this; }
        /// <summary> Промежуточная переменная только для результатов восстановления пронусков;</summary>
        public LLDData p_LLDDataStep3 = new LLDData();
        public DataPreProcessor Set_Step3() { return this; }
        public DataPreProcessor() { }
    }
}