using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.SQL_Manager
{
    public interface IConnectStrGenerator
    {
        IConnectStrGenerator Set(Action<IConnectStrGenerator> x);
        //Main////////////////////////////////////////////////////////////////////////////////////////
        string p_Data_Source { get; set; } IConnectStrGenerator Set_p_Data_Source(string _p_Data_Source);
        string p_Initial_Catalog { get; set; } IConnectStrGenerator Set_p_Initial_Catalog(string _Initial_Catalog);
        bool p_Integrated_Security { get; set; } IConnectStrGenerator Set_p_Integrated_Security(bool _Integrated_Security);
        //Dop////////////////////////////////////////////////////////////////////////////////////////
        Component.IProgressTime p_IProgressTime { get; set; }
        string p_Resalt { get; set; }
        //////////////////////////////////////////////////////////////////////////////////////////
        IConnectStrGenerator Do();
        string Get_Resalt();
        //////////////////////////////////////////////////////////////////////////////////////////
        IConnectStrGenerator Get_InterfaceNewCreateInstance();
        IConnectStrGenerator Get_InterfaceCopy();
    }

    public class ConnectStrGenerator : IConnectStrGenerator
    {
        public IConnectStrGenerator Set(Action<IConnectStrGenerator> x) { x(this); return this; }
        //Main////////////////////////////////////////////////////////////////////////////////////////
        public string p_Data_Source { get; set; }public IConnectStrGenerator Set_p_Data_Source(string _p_Data_Source) { this.p_Data_Source = _p_Data_Source; return this; }
        public string p_Initial_Catalog { get; set; }public IConnectStrGenerator Set_p_Initial_Catalog(string _Initial_Catalog) { this.p_Initial_Catalog = _Initial_Catalog; return this; }
        public bool p_Integrated_Security { get; set; }public IConnectStrGenerator Set_p_Integrated_Security(bool _Integrated_Security) { this.p_Integrated_Security = _Integrated_Security; return this; }
        //Dop////////////////////////////////////////////////////////////////////////////////////////
        public Component.IProgressTime p_IProgressTime { get; set; }// new Component.ProgressTime()
        public string p_Resalt { get; set; }
        public IConnectStrGenerator Init()
        {
            return this
                .Set_p_Data_Source(@"SIB_NOUT-ПК\SQLEPRESS_2008_1")
                .Set_p_Initial_Catalog(@"master")
                .Set_p_Integrated_Security(true)
                //Main//
                .Set((IConnectStrGenerator _this) =>
                {
                    //Dop//
                    _this.p_IProgressTime = new Component.ProgressTime();
                    _this.p_Resalt = @"Data Source=SIB_NOUT-ПК\SQLEPRESS_2008_1;Initial Catalog=master;Integrated Security=True";
                })
            ;
        }
        public ConnectStrGenerator() { this.Init(); }
        //////////////////////////////////////////////////////////////////////////////////////////
        public IConnectStrGenerator Do()
        {
            this.p_IProgressTime.Set_Start();
            {
                this.p_Resalt = "";
                this.p_Resalt += @"Data Source=" + this.p_Data_Source;
                this.p_Resalt += ";" + @"Initial Catalog=" + this.p_Initial_Catalog;
                this.p_Resalt += ";" + @"Integrated Security=" + this.p_Integrated_Security.ToString();
            }
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public string Get_Resalt() { if (!this.p_IProgressTime.p_CalcIsLocked) this.Do(); return this.p_Resalt; }
        //////////////////////////////////////////////////////////////////////////////////////////
        public IConnectStrGenerator Get_InterfaceNewCreateInstance() { return ((IConnectStrGenerator)Activator.CreateInstance(this.GetType())); }
        public IConnectStrGenerator Get_InterfaceCopy()
        {
            return ((IConnectStrGenerator)Activator.CreateInstance(this.GetType()))
                .Set_p_Data_Source(this.p_Data_Source)
                .Set_p_Initial_Catalog(this.p_Initial_Catalog)
                .Set_p_Integrated_Security(this.p_Integrated_Security)
                .Set((IConnectStrGenerator _this) =>
                {
                    _this.p_IProgressTime = this.p_IProgressTime.Get_InterfaceCopy();
                    _this.p_Resalt = this.p_Resalt;
                })
            ;
        }
    }
}
