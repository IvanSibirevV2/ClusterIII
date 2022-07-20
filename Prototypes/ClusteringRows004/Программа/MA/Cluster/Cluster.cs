using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Diagnostics;
using System.Collections.Specialized;

//using MyComdponentModel;


namespace СlusterNameSpace
{
    /// <summary>
    /// Класс - парамет
    /// </summary>          
    [Serializable]    
    public class Param
    {
        /// <summary>
        /// Название группы
        /// </summary>
        private string TName = "NoName";
        /// <summary>
        /// Название кластера
        /// </summary>
        [DisplayName("Имя")]
        [Description("Название параметра.(Param)")]
        [Category("Параметр(Param)")]
        public string Name
        {
            get { return TName; }
            set { TName = value; }
            
        }
        private double TP = new double();
        /// <summary>
        /// Название параметра
        /// </summary>
        [DisplayName("Сам параметр")]
        [Description("Название параметра.(Param)")]
        [Category("Группа параметров(Group)")]
        public double P
        {
            get { return TP; }
            set { TP = value; }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="LocalP">Объект</param>
        /// <param name="LocalName">Название параметра</param>
        public Param(string LocalName, double LocalP)
        {
            this.Name = LocalName;
            this.P = LocalP;
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Param()
        {            
        }
    }
    /// <summary>
    /// Класс - Группа
    /// </summary>   
    [Serializable]    
    public class Group
    {
        /// <summary>
        /// Название группы
        /// </summary>
        private string TName = "NoName";        
        /// <summary>
        /// Название кластера
        /// </summary>
        [DisplayName("Имя")]
        [Description("Название группы.(Name)")]
        [Category("Группа параметров(Group)")]     
        public string Name
        {
            get { return TName; }
            set { TName = value; }
        }
        /// <summary>
        /// Список параметров
        /// </summary>   
        public List<Param> TGroopParamList = new List<Param>();
        /// <summary>
        /// Список параметров
        /// </summary>     
        [DisplayName("Коллекция параметров")]
        [Description("Коллекция параметров.(Name)")]
        [Category("Группа параметров(Group)")]     
        public List<Param> GParamList
        {
            get { return TGroopParamList; }
            set { TGroopParamList = value; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>        
        public Group()
        {            
        }
    }
    /// <summary>
    /// Этот метод груперует два подкластера в один
    /// </summary>     
    [Serializable]
    public class Cluster 
    {
        /// <summary>
        /// Истиное имя кластера.
        /// </summary>
        private string TName = "NoName"; 
        /// <summary>
        /// Название кластера
        /// </summary>
        [DisplayName("Имя")]
        [Description("Название кластера.(Name)")]
        [Category("Кластер(Cluster)")]
        public string Name 
        {
            get { return TName; }
            set { TName = value; }

        }
        /// <summary>
        /// Центр кластера.
        /// </summary>   
        private List<Group> TClusterCenter = new List<Group>();
        /// <summary>
        /// Центр кластера
        /// </summary>                        
        [DisplayName("Группы")]
        [Description("Группы.(ClusterCenter)")]
        [Category("Кластер(Cluster)")]
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        public List<Group> CGroupList
        {
            get { return TClusterCenter; }
            set { TClusterCenter = value; }
        }
        /// <summary>
        /// Список подкластеров
        /// </summary>                
        public List<Cluster> TStructureCluster = new List<Cluster>();
        /// <summary>
        /// Список подкластеров
        /// </summary>        
        [DisplayName("Содержимое кластер")]
        [Description("Содержимое кластера.(StructureCluster)")]
        [Category("Кластер(Cluster)")]        
        public List<Cluster> SCluster
        {
            get { return TStructureCluster; }
            set { TStructureCluster = value; }
        }
        /// <summary>
        /// Конструктор
        /// </summary>        
        public Cluster()
        {
        }
        /// <summary>
        /// Пересчёт центра кластера
        /// </summary>        
/*        
        public void RecalculationClusterCenter()
        {
            if (this.SCluster.Count() == 0)
            {
            }
            else 
            {
                //Обнуляем
                foreach (Group MyGroop in this.CGroupList)
                    foreach (Param MyParam in MyGroop.GParamList)                        
                        MyParam.P = 0;                
                //List<Cluster> GetInCluster()
                

                int i = 0;
                foreach(Cluster MyCluster in this.SCluster)
                {
                    MyCluster.RecalculationClusterCenter();
                    //MyCluster.StandartCenterReloader();
                    //В подкластерах вызываем этуже процедуру
                    int j = 0;
                    foreach (Group MyGroop in MyCluster.CGroupList)
                    {
                        int k = 0;
                        foreach (Param MyParam in MyGroop.GParamList)
                        {
                            this.CGroupList[j].GParamList[k].P = this.CGroupList[j].GParamList[k].P + MyParam.P;
                            k++;
                        }
                        j++;
                    }
                    i++;
                }


                foreach (Group MyGroop in this.CGroupList)                                    
                    foreach (Param MyParam in MyGroop.GParamList)
                        MyParam.P = MyParam.P / this.SCluster.Count();
                                
            }
        }
 * */
          
        /// <summary>
        /// Данный метод клонирует центр кластера и внедряетего в кластеры нижнего иерархического уровня. Попутно затирая все данные, приравнивая их к 0.
        /// </summary>        
        public void FaceClone()
        {
            foreach (Cluster MyCluster in this.SCluster)
            {                
                //MyCluster.CGroupList//= CGroupList;
                MyCluster.CGroupList.Clear();
                for (int i = 0; i < this.CGroupList.Count; i++)
                {
                    MyCluster.CGroupList.Add(new Group());
                    MyCluster.CGroupList[i].Name = this.CGroupList[i].Name;
                    MyCluster.CGroupList[i].GParamList.Clear();
                    for (int j = 0; j < this.CGroupList[i].GParamList.Count; j++)
                    {
                        MyCluster.CGroupList[i].GParamList.Add(new Param());
                        MyCluster.CGroupList[i].GParamList[j].Name = this.CGroupList[i].GParamList[j].Name;
//                        MyCluster.CGroupList[i].GParamList[i].P = this.CGroupList[i].GParamList[i].P;
                    }
                }
                foreach (Group MyGroop in MyCluster.CGroupList)
                {
                    foreach (Param MyParam in MyGroop.GParamList)
                    {
                        MyParam.P = 0;
                    }
                }
            }            
        }
        /// <summary>
        /// Этот медод осуществляет пересчет центра если есть по чему пересчитывать. ,tp
        /// </summary>
        private void StandartCenterReloader()
        {
            List<Group> MyLocalCenter = new List<Group>();
            if (this.SCluster.Count != 0)
            {
                //обнуляем значения
                foreach (Group MyGroup in this.CGroupList)
                    foreach (Param MyParam in MyGroup.GParamList)
                        MyParam.P=0;                    
                foreach(Cluster MyCluster in this.SCluster)
                {
                    //MyCluster.StandartCenterReloader();

                    int i = 0;
                    this.CGroupList.Clear();
                    foreach (Group MyGroup in MyCluster.CGroupList)
                    {
                        int j = 0;
                        this.CGroupList.Add(new Group());
                        this.CGroupList[i].Name = MyGroup.Name;
                        foreach (Param MyParam in MyGroup.GParamList)
                        {
                            this.CGroupList[i].GParamList.Add(new Param());
                            this.CGroupList[i].GParamList[j].Name = MyParam.Name;
                            this.CGroupList[i].GParamList[j].P =this.CGroupList[i].GParamList[j].P+ MyParam.P;
                            j++;
                        }
                        i++;
                    }
                }
                foreach (Group MyGroup in this.CGroupList)
                    foreach (Param MyParam in MyGroup.GParamList)
                        MyParam.P = MyParam.P / this.SCluster.Count();                    
            }
        }
        /// <summary>
        /// Этот медод добавления подкластера какбы незабыть переназвать.
        /// </summary>
        private void Add(Cluster MyCluster)
        {
            this.SCluster.Add(MyCluster);
            StandartCenterReloader();
        }
        /// <summary>
        /// Этот медод удаления подкластера какбы незабыть переназвать.
        /// </summary>
        private void RemoveAt(int i)
        {
            if ((i >= 0) && (i < this.SCluster.Count))
                this.SCluster.RemoveAt(i);
            StandartCenterReloader();
        }
        /// <summary>
        /// Этот метод груперует два подкластера в один
        /// </summary>
        public void Grouping(int i, int j, string NewName)
        {
            if (
                (this.SCluster.Count >= 2) &&
                (i >= 0) &&
                (j >= 0) &&
                (i != j) &&
                (i < this.SCluster.Count) &&
                (j < this.SCluster.Count)
                )
            {
                Cluster MyLocalClusterR = new Cluster();
                MyLocalClusterR.Name = NewName;
                //MyLocalClusterR.SCluster.Clear();               
                MyLocalClusterR.Add(this.SCluster[i]);
                MyLocalClusterR.Add(this.SCluster[j]);
                MyLocalClusterR.StandartCenterReloader();
                Add(MyLocalClusterR);
                if (i < j)
                {
                    RemoveAt(i);
                    RemoveAt(j - 1);
                }
                else
                {
                    RemoveAt(j);
                    RemoveAt(i - 1);
                }
            }
            foreach(Cluster MycLuStEr in this.SCluster)
            {
                
                for (int I = 0; I < MycLuStEr.SCluster.Count();I++ )
                {
                    if (MycLuStEr.SCluster[I].SCluster.Count() != 0)
                    {
                        MycLuStEr.SCluster.AddRange(MycLuStEr.SCluster[I].GetInCluster().ToArray());
                        MycLuStEr.RemoveAt(I);
                        I--;
                    }

                }
            }
            StandartCenterReloader();
        }

        /// <summary>
        /// Этот метод 1предназначен для избегания приравнивания ссылок. Мда Каряво сказано.
        ///Но этот метод позволяет работать с программой долго и стабильно.
        /// </summary>
        public Cluster Copy()
        {
            Cluster RezCluster = new Cluster();
            RezCluster.Name = this.Name;
            int i=0;
            foreach(Group MyLocalGroup in this.CGroupList)
            {
                RezCluster.CGroupList.Add(new Group());
                RezCluster.CGroupList[i].Name=MyLocalGroup.Name;
                int j = 0;
                foreach(Param MyLocalParam in MyLocalGroup.GParamList)
                {
                    RezCluster.CGroupList[i].GParamList.Add(new Param());
                    RezCluster.CGroupList[i].GParamList[j].Name = MyLocalParam.Name;
                    RezCluster.CGroupList[i].GParamList[j].P = MyLocalParam.P;
                    j++;
                }
                i++;
            }
            i = 0;
            foreach (Cluster MyLocalCluster in this.SCluster) 
            {
                RezCluster.SCluster.Add(MyLocalCluster.Copy());
                i++;
            }
            return RezCluster;            
        }
        /// <summary>
        /// Данный метод берёт все подкластеры данного метода.
        /// </summary>
        public List<Cluster> GetInCluster()
        {
            //Cluster MyCluster = new Cluster();
            List<Cluster> rezSCluster = new List<Cluster>();
            if (this.SCluster.Count == 0) 
            {
                rezSCluster.Add(this);
            }
            else
            foreach (Cluster MyLocalCluster in this.SCluster)
            {                
                rezSCluster.AddRange(MyLocalCluster.GetInCluster());
            }
            return rezSCluster;
        }
    }
}