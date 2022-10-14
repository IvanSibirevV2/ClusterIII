using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//////////////////////////////////////////////////////////////////////
using Component;
using Component.GeneraterRandomValue;
//System.GeneraterRandomInputData.GenCluInpData_Rand
namespace Component.GeneraterRandomInputData
{
    public interface IGenCluInpData_Rand
    {
        ////////////////////////////////////////////////////////////////////
        int p_K{get;set;}
        /// <summary>Количество генерируемых объектов</summary>
        int p_N { get; set; }
        /// <summary>Количество генерируемых параметров</summary>
        int p_P{get;set;}
        /// <summary>Максимальное значение генерируемых параметров</summary>
        double p_MaxValue{get;set;}
        /// <summary>Минимальное значение генерируемых параметров</summary>
        double p_MinValue{get;set;}
        /// <summary>Компонент для подтыкакия экзотических генераторов случайных чисел</summary>
        IGeneraterRandomValue p_GeneraterRandomValue{get;set;}
        ////////////////////////////////////////////////////////////////////
        IGenCluInpData_Rand Set(Action<IGenCluInpData_Rand> x);
        /// <summary>Количество генерируемых объектов</summary>
        IGenCluInpData_Rand Set_p_N(int _p_N);
        /// <summary>Количество генерируемых параметров</summary>
        IGenCluInpData_Rand Set_p_P(int _p_P);
        IGenCluInpData_Rand Set_p_K(int _p_K);
        /// <summary>Максимальное значение генерируемых параметров</summary>
        IGenCluInpData_Rand Set_p_MaxValue(double _p_MaxValue);
        /// <summary>Минимальное значение генерируемых параметров</summary>
        IGenCluInpData_Rand Set_p_MinValue(double _p_MinValue);
        /// <summary>Компонент для подтыкакия экзотических генераторов случайных чисел</summary>
        IGenCluInpData_Rand Set_p_GeneraterRandomValue(IGeneraterRandomValue _p_GeneraterRandomValue);
        ////////////////////////////////////////////////////////////////////
        List<List<string>> Next();
    }
    public class GenCluInpData_Rand : IGenCluInpData_Rand
    {
        /// <summary>Количество генерируемых кластеров (Не входит в стандартный интерфейс, передаётся с конструктором)</summary>
        // В этом компоненте почти не используется, используется судя по всему в другом компоненте под этот же интерфейс
        public int p_K{get;set;}
        /// <summary>Количество генерируемых объектов</summary>
        public int p_N{get;set;}
        /// <summary>Количество генерируемых параметров</summary>
        public int p_P{get;set;}
        /// <summary>Максимальное значение генерируемых параметров</summary>
        public double p_MaxValue{get;set;}
        /// <summary>Минимальное значение генерируемых параметров</summary>
        public double p_MinValue{get;set;}         
        /// <summary>Компонент для подтыкакия экзотических генераторов случайных чисел</summary>        
        public IGeneraterRandomValue p_GeneraterRandomValue{get;set;}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IGenCluInpData_Rand Init() 
        {
            return this.Set_p_K(2).Set_p_N(10).Set_p_P(2).Set_p_MaxValue(1000).Set_p_MinValue(0)
                .Set_p_GeneraterRandomValue(new Component.GeneraterRandomValue.GeneraterRandomValue())
            ;
        }
        public GenCluInpData_Rand() { this.Init(); }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IGenCluInpData_Rand Set(Action<IGenCluInpData_Rand> x) { x(this); return this; }
        public IGenCluInpData_Rand Set_p_N(int _p_N) { this.p_N = _p_N; return this; }
        public IGenCluInpData_Rand Set_p_P(int _p_P) { this.p_P = _p_P; return this; }
        /// <summary>Количество генерируемых кластеров (Не входит в стандартный интерфейс, передаётся с конструктором)</summary>
        public IGenCluInpData_Rand Set_p_K(int _p_K) { this.p_K = _p_K; return this; }
        public IGenCluInpData_Rand Set_p_MaxValue(double _p_MaxValue) { this.p_MaxValue = _p_MaxValue; return this; }
        public IGenCluInpData_Rand Set_p_MinValue(double _p_MinValue) { this.p_MinValue = _p_MinValue; return this; }
        public IGenCluInpData_Rand Set_p_GeneraterRandomValue(IGeneraterRandomValue _p_GeneraterRandomValue) { this.p_GeneraterRandomValue = _p_GeneraterRandomValue; return this; }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public virtual List<List<string>> Next()
        {
            p_GeneraterRandomValue = p_GeneraterRandomValue.Get_InterfaseCopy();
            int N = p_N; int P = p_P; double MinValue = p_MaxValue;
            List<List<string>> LLLS = new List<List<string>>();
            {//Формируем шапку
                List<string> LLS = (new string[] { 
                    #region (new SPExtractor())....p_StringParam
                    (new SPExtractor())//Генерируем Для ячейки названия
                        .Set_Param("Name","Gen"+ DateTime.Now )
                        .Set_Param("CountObjects",Convert.ToString(N) )
                        .Set_Param("CountParams",Convert.ToString(P) )
                        .Set_Param("IGeneraterRandomValue", this.p_GeneraterRandomValue.GetType().Name )
                        .p_String
                    #endregion
                }).ToList<string>();

                for (int i = 0; i < P; i++)
                    LLS.Add("P" + Convert.ToString(i));
                LLLS.Add(LLS);
            }
            for (int j = 0; j < N; j++)//Формируем сами данные
            {
                List<string> LLS = (new string[] { "N" + Convert.ToString(j) }).ToList<string>();
                for (int i = 0; i < P; i++)
                    LLS.Add(Convert.ToString(p_GeneraterRandomValue.NextDouble() * (this.p_MaxValue - this.p_MinValue)));
                LLLS.Add(LLS);
            }
            return LLLS;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static void Test_GenCluInpData_Rand() 
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            IGenCluInpData_Rand _IGenCluInpData_Rand = new GenCluInpData_Rand();
            _IGenCluInpData_Rand.Next().writeThis(5);
            
        }
    }
}