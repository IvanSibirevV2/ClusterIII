using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//////////////////////////////////////////////////////////////////////
using Component;
using Component.GeneraterRandomValue;
using Component.Math;
////////////////////////////////////////////////////////////////////
//Component.GeneraterRandomInputData.GenClusInpData_DivForRandClu.Test_GenClusInpData_ForRandClu()
namespace Component.GeneraterRandomInputData
{
    public class GenClusInpData_DivForRandClu :GenCluInpData_Rand, IGenCluInpData_Rand
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IGenCluInpData_Rand Init() 
        {
            return this.Set_p_K(2).Set_p_N(10).Set_p_P(2).Set_p_MaxValue(1000).Set_p_MinValue(0)
                .Set_p_GeneraterRandomValue(new Component.GeneraterRandomValue.GeneraterRandomValue())
            ;
        }
        public GenClusInpData_DivForRandClu() { this.Init(); }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public new List<List<string>> Next()
        {
            p_GeneraterRandomValue = p_GeneraterRandomValue.Get_InterfaseCopy();
            int N = this.p_N; int P = this.p_P; int K = this.p_K; double MaxValue = this.p_MaxValue; double MinValue = this.p_MinValue;
            ////////////////////////////////////
            //Генерируем список точек -центров кластеров
            List<List<string>> LLS_ClusterCenter;
            {
                Component.GeneraterRandomInputData.GenCluInpData_Rand qwe = new Component.GeneraterRandomInputData.GenCluInpData_Rand();
                qwe.Set_p_P(P); qwe.Set_p_N(K+1); qwe.Set_p_MinValue(MinValue); qwe.Set_p_MaxValue(MaxValue); LLS_ClusterCenter = qwe.Next();
                //LLS_ClusterCenter = ;
                //GenCluInpData_Rand
            }    
                //Randomer(K, P, MaxValue, MinValue);
            //Список конечных точек
            List<List<string>> LLS = new List<List<string>>(); 
            LLS.Add(LLS_ClusterCenter[0].Get_Copy());//Копируем шапку

            Random ChoosCluster = new Random();
            Random rnd1 = new Random();

            for (int j = 0; j < N; j++)//Формируем сами данные
            {
                //Формируем точку
                int k = ChoosCluster.Next(1, LLS_ClusterCenter.Count - 1);//там LLS_ClusterCenter[0] - шапка таблицы
                //LLS_ClusterCenter[k]
                //ищем минимум расстояния от этого центра кластера кластера до остальных
                double min_dist = System.Math.Pow(10, 10);
                for (int q = 1; q < LLS_ClusterCenter.Count; q++)
                    if(k!=q)
                        min_dist =System.Math.Min(
                            min_dist
                            ,
                            (new Component.Math.DistEuclidean_ILS())
                                .Set_p_A_ILS(LLS_ClusterCenter[k].Get_CopyAsILS())
                                .Set_p_B_ILS(LLS_ClusterCenter[q].Get_CopyAsILS())
                                .DO()
                                .Get_Resalt()
                        );
                //положим радиус кластера как 1/3 от min_dist
                double Max_R = min_dist / 3;
                //Теперь пишем генерируем точку в шаре
                bool flag = true;
                while (flag)
                {
                    List<string> LS = (new string[] { "N" + Convert.ToString(j) }).ToList<string>();
                    
                    for (int i = 1; i < LLS_ClusterCenter[k].Count; i++)
                    {
                        double _CluCenter = Convert.ToDouble(LLS_ClusterCenter[k][i]);
                        double _lsAddI = rnd1.NextDouble() *2* Max_R - Max_R + _CluCenter;
                        while (!((this.p_MinValue <= _lsAddI) && (_lsAddI <= this.p_MaxValue))) _lsAddI = rnd1.NextDouble() * 2 * Max_R - Max_R + _CluCenter;
                        LS.Add(Convert.ToString(_lsAddI));
                    }
                    double SDAGJLASDBJKL = (new Component.Math.DistEuclidean_ILS())
                        .Set_p_A_ILS(LS.Get_CopyAsILS())
                        .Set_p_B_ILS(LLS_ClusterCenter[k].Get_CopyAsILS())
                        .DO().Get_Resalt()
                    ;
                    if (SDAGJLASDBJKL <= Max_R)
                    {//И добавляем если они принадлежат выбранному радиусу
                        flag = false;
                        LLS.Add(LS);
                    }
                    
                }
            }
            LLS[0][0] = (new SPExtractor())
                .Set_Param("Name", "Gen" + DateTime.Now)
                .Set_Param("CountObjects", Convert.ToString(N))
                .Set_Param("CountParams", Convert.ToString(P))
                .Set_Param("IGeneraterRandomValue", this.p_GeneraterRandomValue.GetType().Name)
                .p_String;
            return LLS;
        }
        public static void Test_GenClusInpData_ForRandClu()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            
             IGenCluInpData_Rand _IGenCluInpData_Rand = (new GenClusInpData_DivForRandClu()).Set_p_K(3);
            _IGenCluInpData_Rand.Next().writeThis(5);
             
        }
    }
}