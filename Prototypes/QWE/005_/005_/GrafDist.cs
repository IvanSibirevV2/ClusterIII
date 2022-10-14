using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.SQL_Manager
{
    public interface IGrafDist
    {
        IGrafDist Set(Action<IGrafDist> x);
        /////////////////////////////////////////////////////////////////////////////////////////
        int p_id_A { get; set; } IGrafDist Set_p_id_A(int _p_id_A);
        int p_id_B { get; set; } IGrafDist Set_p_id_B(int _p_id_B);
        IGrafDist Set_p_id_A_B(int _p_id_A, int _p_id_B);
        ISQL_M p_ISQL_M { get; set; } IGrafDist Set_p_ISQL_M(ISQL_M _p_ISQL_M);
        IList<string> p_ILS_FairList { get; set; } IGrafDist Set_p_ILS_FairList(IList<string> _p_ILS_FairList);
        /////////////////////////////////////////////////////////////////////////////////////////
        IList<string> p_Resalt { get; set; }
        int p_Dist { get; set; }
        Component.IProgressTime p_ProgressTime { get; set; }
        /////////////////////////////////////////////////////////////////////////////////////////
        IGrafDist Do();
        int Get_Resalt();
        /////////////////////////////////////////////////////////////////////////////////////////
        IGrafDist Get_InterfaceNewCreateInstance();
        IGrafDist Get_InterfaceCopy();
    }
    public class GrafDist : IGrafDist
    {
        public IGrafDist Set(Action<IGrafDist> x) { x(this); return this; }
        /////////////////////////////////////////////////////////////////////////////////////////
        public int p_id_A { get; set; }public IGrafDist Set_p_id_A(int _p_id_A) { this.p_id_A = _p_id_A; return this; }
        public int p_id_B { get; set; }public IGrafDist Set_p_id_B(int _p_id_B) { this.p_id_B = _p_id_B; return this; }
        public IGrafDist Set_p_id_A_B(int _p_id_A, int _p_id_B) { return this.Set_p_id_A(_p_id_A).Set_p_id_B(_p_id_B); }
        public ISQL_M p_ISQL_M { get; set; }public IGrafDist Set_p_ISQL_M(ISQL_M _p_ISQL_M) { this.p_ISQL_M = _p_ISQL_M; return this; }
        public IList<string> p_ILS_FairList { get; set; }public IGrafDist Set_p_ILS_FairList(IList<string> _p_ILS_FairList) { this.p_ILS_FairList = _p_ILS_FairList; return this; }
        /////////////////////////////////////////////////////////////////////////////////////////
        public IList<string> p_Resalt { get; set; }

        public int p_Dist { get; set; }
        public Component.IProgressTime p_ProgressTime { get; set; }
        public IGrafDist Init()
        {
            return this.Set_p_id_A_B(4, 1)
                .Set_p_ISQL_M(null)
                .Set((IGrafDist _this) =>
                {
                    _this.p_ProgressTime = new Component.ProgressTime();
                    _this.p_Resalt = new List<string>();
                    _this.p_ILS_FairList = new List<string>();
                })
            ;
        }
        public GrafDist() { this.Init(); }
        /////////////////////////////////////////////////////////////////////////////////////////
        public IGrafDist Do()
        {
            ;
            this.p_ProgressTime.Set_Start();
            {
                IList<IList<string>> _ILLS = this.p_ISQL_M.Get_InterfaceCopy()
                        .Set_p_SQL_String("select TradeNode_id_1, TradeNode_id_2 ,cost from EdgeOfGraph where TradeNode_id_1=" + this.p_id_A.ToString() + ";")
                        .Do().Get_Resalt().p_ILLS;
                foreach (string _str in this.p_Resalt) if (this.p_id_A == Convert.ToInt32(_str))
                {
                    ;
                    this.p_Resalt.Add(this.p_id_B.ToString());
                    this.p_Dist = 9999;
                    this.p_ProgressTime.Set_Stop();
                    return this;
                }
                this.p_Resalt.Add(this.p_id_A.ToString());
                //this.p_Resalt.writeThis(5);

                IList<IGrafDist> __IGrafDist = new List<IGrafDist>();
                IList<string> _ILS = new List<string>();
                for (int i = 1; i < _ILLS.Count; i++)
                {
                    ;
                    if (Convert.ToInt32(_ILLS[i][1]) == this.p_id_B)
                    {
                        ;
                        this.p_Resalt.Add(this.p_id_B.ToString());
                        this.p_Dist += Convert.ToInt32(_ILLS[i][2]);
                        this.p_ProgressTime.Set_Stop();
                        //this.p_Dist
                        //this.p_Resalt.writeThis(5);
                        return this;
                    }
                    this.p_ILS_FairList.Add(_ILLS[i][0]);
                    __IGrafDist.Add(this.Get_InterfaceNewCreateInstance()
                        .Set_p_ISQL_M(this.p_ISQL_M.Get_InterfaceCopy())
                        .Set((IGrafDist _this) => { _this.p_Resalt = this.p_Resalt.Get_InterfaseCopy(); _this.p_Dist = Convert.ToInt32(_ILLS[i][2]); })
                        .Set_p_id_A_B(Convert.ToInt32(_ILLS[i][1]), this.p_id_B).Do());                    
                    _ILS.Add(__IGrafDist[__IGrafDist.Count-1].p_Dist.ToString());
                }
                int min = 55555;
                for (int i = 0; i < __IGrafDist.Count; i++)min = System.Math.Min(min, Convert.ToInt32(_ILS[i]));
                for (int i = 0; i < __IGrafDist.Count; i++)
                    if (min == Convert.ToInt32(_ILS[i]))
                    {
                        this.p_Dist += min;
                        this.p_Resalt = __IGrafDist[i].p_Resalt;
                    }
            }
            this.p_ProgressTime.Set_Stop();
            return this;
        }
        public int Get_Resalt() { if (!this.p_ProgressTime.p_CalcIsLocked) this.Do(); return this.p_Dist; }
        /////////////////////////////////////////////////////////////////////////////////////////
        public IGrafDist Get_InterfaceNewCreateInstance() { return ((IGrafDist)Activator.CreateInstance(this.GetType())); }
        public IGrafDist Get_InterfaceCopy()
        {
            return ((IGrafDist)Activator.CreateInstance(this.GetType()))
                /*
                .Set_p_id_A_B(4, 1)
                .Set_p_ISQL_M(this.p_ISQL_M.Get_InterfaceCopy())
                .Set((IGrafDist _this) =>
                {
                    _this.p_ProgressTime = this.p_ProgressTime.Get_InterfaceCopy();
                    _this.p_Resalt = this.p_Resalt.Get_InterfaseCopy();
                    _this.p_Dist =this.p_Dist;
                    _this.p_ILS_FairList = this.p_ILS_FairList.Get_InterfaseCopy();
                })
                 * */
            ;
        }
    }
}
