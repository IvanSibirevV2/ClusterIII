using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////////////////////////////////////////
using Component.SQL_Manager;

namespace Component.TransportAlgorithm
{
    public interface ITransportAlgorithm
    {
        ITransportAlgorithm Set(Action<ITransportAlgorithm> x);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ISQL_M p_ISQL_M { get; set; } ITransportAlgorithm Set_p_ISQL_M(ISQL_M _p_ISQL_M);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
    public class TransportAlgorithm_1 : ITransportAlgorithm
    {
        public ITransportAlgorithm Set(Action<ITransportAlgorithm> x) { x(this); return this; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ISQL_M p_ISQL_M { get; set; } public ITransportAlgorithm Set_p_ISQL_M(ISQL_M _p_ISQL_M) { this.p_ISQL_M = _p_ISQL_M; return this; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ITransportAlgorithm Init()
        {
            return this
                .Set_p_ISQL_M(
                new Component.SQL_Manager.SQL_M()
                )
                ;
        }
        public TransportAlgorithm_1() { this.Init(); }


    }
    ///////////////////////////
    
    public static class Alg_1
    {
        public static bool Alg_1_DO(this ISQL_M _this)
        {
            //bool _flagan_Shapko = false;
            bool _flagan = false;
            //Получение колличества грузов на в узлах графа
            IList<IList<string>> _ILL_u = _this.Get_InterfaceCopy()
                .Set_p_SQL_String("select RouteList.TradeNode_id_2 as TradeNode_id, sum(RouteList.reset) as reset from RouteList GROUP BY RouteList.TradeNode_id_2")
                .Do().Get_Resalt().p_ILLS;
            _ILL_u[0][0] = "Грузы";
            _ILL_u.writeThis(8);
            ;
            //Таблица расстояний
            IList<IList<string>> _ILL_Dist = _ILL_u.Get_InterfaseCopy();
            foreach (IList<string> _ILS in _ILL_Dist) while (_ILS.Count != 1) _ILS.RemoveAt(1);
            for (int i = 1; i < _ILL_Dist.Count; i++) _ILL_Dist[0].Add(_ILL_Dist[i][0]);
            for (int i = 1; i < _ILL_Dist.Count; i++) for (int j = 1; j < _ILL_Dist[0].Count; j++) _ILL_Dist[i].Add("0");
            for (int i = 1; i < _ILL_Dist.Count; i++)
                for (int j = 1; j < _ILL_Dist[0].Count; j++) if (i != j)
                    {
                        //Console.WriteLine("<" + i.ToString() + ";" + j.ToString() + ">");
                        _ILL_Dist[i][j] = (new GrafDist()).Set_p_ISQL_M(_this.Get_InterfaceCopy())
                            .Set_p_id_A_B(Convert.ToInt32(_ILL_Dist[i][0]), Convert.ToInt32(_ILL_Dist[0][j]))
                            .Do().p_Dist.ToString();
                    }
            _ILL_Dist[0][0] = "Расстояния";
            _ILL_Dist.writeThis(5);
            ;
            //Таблица отношений груза к расстоянию от склада
            IList<IList<string>> _ILL_I = _ILL_u.Get_InterfaseCopy();
            for (int i = 2; i < _ILL_I.Count; i++)
            //for (int j = 1; j < _ILL_I[0].Count; j++) if (i != j)
            {
                Console.Write(_ILL_u[i][0] + "<" + _ILL_u[i][1] + ">");
                //Console.Write(_ILL_u[j][0] + "<" + _ILL_u[j][1] + ">");
                //Console.WriteLine("<" + Convert.ToString(Convert.ToInt32(_ILL_u[i][1]) + Convert.ToInt32(_ILL_u[j][1])) + ">");
                //_ILL_I[i][j] = Convert.ToString((int)((Convert.ToInt32(_ILL_u[i][1]) - Convert.ToInt32(_ILL_u[j][1])) / Convert.ToInt32(_ILL_Dist[i][j])));
                _ILL_I[i][1] = Convert.ToString((double)100 * ((0 - Convert.ToInt32(_ILL_u[i][1])) / (double)Convert.ToInt32(_ILL_Dist[i][1])));
            }
            ;
            _ILL_I[1][1] = "0";
            _ILL_I.writeThis(10);
            ;

            //Нахождение самой не загруженной машины
            int _Min_Price_CarList_id = -1;

            IList<IList<string>> _ILL_Cars_AccumulatedPrice = _this.Get_InterfaceCopy()
            .Set_p_SQL_String("select RouteList.CarList_id, SUM(EdgeOfGraph.cost) from RouteList join EdgeOfGraph on EdgeOfGraph.TradeNode_id_2=RouteList.TradeNode_id_2 and EdgeOfGraph.TradeNode_id_1=RouteList.TradeNode_id_1 GROUP BY RouteList.CarList_id")
            .Do().Get_Resalt().p_ILLS;
            for (int i = 1; i < _ILL_Cars_AccumulatedPrice.Count; i++) if (_ILL_Cars_AccumulatedPrice[i][0] == "0") { _ILL_Cars_AccumulatedPrice.RemoveAt(i); break; }
            _ILL_Cars_AccumulatedPrice.writeThis(8);

            Convert.ToInt32(_ILL_Cars_AccumulatedPrice[1][0]);
            int _Min_Price_CarList_ = Convert.ToInt32(_ILL_Cars_AccumulatedPrice[1][1]);
            for (int i = 1; i < _ILL_Cars_AccumulatedPrice.Count; i++) _Min_Price_CarList_ = System.Math.Min(_Min_Price_CarList_, Convert.ToInt32(_ILL_Cars_AccumulatedPrice[i][1]));
            for (int i = 1; i < _ILL_Cars_AccumulatedPrice.Count; i++) if (_Min_Price_CarList_ == Convert.ToInt32(_ILL_Cars_AccumulatedPrice[i][1])) _Min_Price_CarList_id = Convert.ToInt32(_ILL_Cars_AccumulatedPrice[i][0]);

            Console.WriteLine("_Min_Price_CarList_id=" + _Min_Price_CarList_id.ToString());
            //расчет наиболле нуждающегося места доставки
            // MAX по Таблице отношений груза к расстоянию от склада
            int _MAX_i = 0;
            {
                double _MAX_I = Convert.ToDouble(_ILL_I[2][1]);
                for (int i = 2; i < _ILL_I.Count; i++) _MAX_I = System.Math.Max(_MAX_I, Convert.ToDouble(_ILL_I[i][1]));
                for (int i = 2; i < _ILL_I.Count; i++) if (_MAX_I == Convert.ToDouble(_ILL_I[i][1])) _MAX_i = Convert.ToInt32(_ILL_I[i][0]);
                Console.WriteLine("_MAX_i=" + _MAX_i.ToString());
                Console.WriteLine("_MAX_I=" + _MAX_I.ToString());
                Console.WriteLine("_ILL_u[_MAX_i][1]=" + _ILL_u[_MAX_i + 1][1].ToString());

            }
            IList<string> _ILS_mARSH = (new GrafDist()).Set_p_ISQL_M(_this.Get_InterfaceCopy()).Set_p_id_A_B(0, _MAX_i).Do().p_Resalt.writeThis(5);
            int _Car_maxLoadCapacity = Convert.ToInt32(_this.Get_InterfaceCopy().Set_p_SQL_String("select CarList.maxLoadCapacity from CarList where CarList.id=" + _Min_Price_CarList_id.ToString()).Do().Get_Resalt().p_ILLS[1][0]);
            Console.WriteLine("_Car_maxLoadCapacity=" + _Car_maxLoadCapacity.ToString());
            int _Car_Take = 0;
            int q = Convert.ToInt32(_ILL_u[_MAX_i + 1][1]);
            _Car_Take = System.Math.Min(System.Math.Abs(q), _Car_maxLoadCapacity);
            ;
            Console.WriteLine("_Car_Take=" + _Car_Take.ToString());

            _this.Get_InterfaceCopy().Set_p_SQL_String(//Взяли груз
                @"INSERT INTO [QWE].[dbo].[RouteList] ([TradeNode_id_1],[TradeNode_id_2],[CarList_id],[reset]) VALUES (0,0," + _Min_Price_CarList_id.ToString() + "," + (0 - _Car_Take).ToString() + ")").Do().Get_Resalt();
            if (_Car_Take != 0)
            {
                _flagan = true;
                Console.WriteLine("Можно выезжать");

                for (int i = 1; i < _ILS_mARSH.Count; i++)
                    _this.Get_InterfaceCopy().Set_p_SQL_String(//Везём по проложенному маршруту (кратчайший путь)
                        @"INSERT INTO [QWE].[dbo].[RouteList] ([TradeNode_id_1],[TradeNode_id_2],[CarList_id],[reset]) VALUES (" + _ILS_mARSH[i - 1] + "," + _ILS_mARSH[i] + "," + _Min_Price_CarList_id.ToString() + ", 0)").Do().Get_Resalt();

                _this.Get_InterfaceCopy().Set_p_SQL_String(//Сбрасываем весь груз в пункте назначения
                        @"INSERT INTO [QWE].[dbo].[RouteList] ([TradeNode_id_1],[TradeNode_id_2],[CarList_id],[reset]) VALUES (" + _ILS_mARSH[_ILS_mARSH.Count - 1] + "," + _ILS_mARSH[_ILS_mARSH.Count - 1] + "," + _Min_Price_CarList_id.ToString() + ", " + (_Car_Take).ToString() + ")").Do().Get_Resalt();

                for (int i = _ILS_mARSH.Count - 1; i > 0; i--)
                    _this.Get_InterfaceCopy().Set_p_SQL_String(//Возвращаемся на нашу базу за новыми ...=)
                        @"INSERT INTO [QWE].[dbo].[RouteList] ([TradeNode_id_1],[TradeNode_id_2],[CarList_id],[reset]) VALUES (" + _ILS_mARSH[i] + "," + _ILS_mARSH[i - 1] + "," + _Min_Price_CarList_id.ToString() + ", 0)").Do().Get_Resalt();
            }


            _this.Get_InterfaceCopy()
                .Set_p_SQL_String("select RouteList.TradeNode_id_2 as TradeNode_id, sum(RouteList.reset) as reset from RouteList GROUP BY RouteList.TradeNode_id_2")
                .Do().Get_Resalt().p_ILLS.writeThis(8);

            //Console.Read();

            return _flagan;
        }
    }
}
