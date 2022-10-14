using System;
using System.ComponentModel;

namespace ClusterIII.Model
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

        /// <summary>
        /// Метод создания копий класса
        /// </summary>
        public Param FaceClone()
        {
            return new Param(TName, TP);
        }

        
    }
}
