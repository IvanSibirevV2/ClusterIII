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



namespace ClusterIII.Model
{
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
        /// <param name="LocalName">Название кластера</param>
        /// <param name="LocalCGroupList">Центр кластера</param>
        /// <param name="LocalSCluster">Список подкластеров</param>
        public Cluster(string LocalName, List<Group> LocalCGroupList, List<Cluster> LocalSCluster)
        {
            this.Name = LocalName;
            this.CGroupList = LocalCGroupList;
            this.SCluster = LocalSCluster;            
        }    
        /// <summary>
        /// Конструктор
        /// </summary>        
        public Cluster()
        {
        }

        /// <summary>
        /// Метод создания копий класса
        /// </summary>        
        public Cluster FaceClone()
        {
            List<Group> LocalCGroupList = new List<Group>();
            LocalCGroupList.Clear();
            foreach(Group LocalGroupin in CGroupList)
                LocalCGroupList.Add(LocalGroupin.FaceClone());

            List<Cluster> LocalSCluster= new List<Cluster>();
            LocalSCluster.Clear();
            foreach (Cluster LocalCluster in SCluster)
            {
                Cluster LlCluster = new Cluster();
                LlCluster.Name = LocalCluster.Name;
                LlCluster.CGroupList.AddRange(LocalCluster.CGroupList.ToArray());
                LlCluster.SCluster.AddRange(LocalCluster.SCluster.ToArray());
                LocalSCluster.Add(LlCluster.FaceClone());
            }
            return new Cluster(TName, LocalCGroupList, LocalSCluster);            
        }

        /// <summary>
        /// Метод создания копий класса, за исключением SCluster (он затирается), своего рода централизованная смена стиля 
        /// </summary>        
        public Cluster SameFaceClone()
        {
            foreach (Cluster MyCluster in this.SCluster)
            {         
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
            return this.FaceClone() /*new Cluster(TName, LocalCGroupList, LocalSCluster)*/;
        }

        /// <summary>
        /// Этот медод осуществляет пересчет центра если есть по чему пересчитывать.
        /// </summary>
        public void StandartCenterReloader()
        {
            //Обнуляем параметры в кластере
            foreach (Group LocalGroup in this.CGroupList)
                foreach (Param LocalParam in LocalGroup.GParamList)
                    LocalParam.P = 0;
            //Суммируем параметры в подкластере кластере
            foreach (Cluster LocalCluster in this.SCluster)
            {
                int i = 0;
                foreach (Group MyGroup in LocalCluster.CGroupList)
                {
                    int j=0;
                    this.CGroupList.Add(new Group());//
                    this.CGroupList[i].Name = MyGroup.Name;//
                    foreach (Param MyParam in MyGroup.GParamList)
                    {
                        this.CGroupList[i].GParamList.Add(new Param());//
                        this.CGroupList[i].GParamList[j].Name = MyParam.Name;//
                        this.CGroupList[i].GParamList[j].P = this.CGroupList[i].GParamList[j].P + MyParam.P;
                        j++;
                    }
                    i++;
                }
            }
            //Получаем среднеорифметическое
            foreach (Group MyGroup in this.CGroupList)
                foreach (Param MyParam in MyGroup.GParamList)
                    MyParam.P = MyParam.P / this.SCluster.Count(); 
        }
        /// <summary>
        /// Этот медод добавления подкластера.
        /// </summary>
        private void Add(Cluster MyCluster)
        {
            this.SCluster.Add(MyCluster);
            //this.StandartCenterReloader();
        }
        /// <summary>
        /// Этот медод удаления подкластера
        /// </summary>
        private void RemoveAt(int i)
        {
            if ((i >= 0) && (i < this.SCluster.Count))
                this.SCluster.RemoveAt(i);
            //StandartCenterReloader();
        }

        /// <summary>
        /// Данный метод берёт все подкластеры данного кластера.
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
            foreach (Cluster MycLuStEr in this.SCluster)
            {

                for (int I = 0; I < MycLuStEr.SCluster.Count(); I++)
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
            int i = 0;
            foreach (Group MyLocalGroup in this.CGroupList)
            {
                RezCluster.CGroupList.Add(new Group());
                RezCluster.CGroupList[i].Name = MyLocalGroup.Name;
                int j = 0;
                foreach (Param MyLocalParam in MyLocalGroup.GParamList)
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
    }
}
