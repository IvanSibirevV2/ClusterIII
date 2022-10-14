using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClusterIII.Model
{
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
        /// Название группы
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
        /// <param name="LocatName">Название группы</param>
        /// <param name="LocalGParamList">Список параметров</param>
        public Group(string LocatName, List<Param> LocalGParamList)
        {
            this.Name = LocatName;
            this.GParamList = LocalGParamList;
        }
        
        /// <summary>
        /// Конструктор
        /// </summary>        
        public Group()
        {
        }

        /// <summary>
        /// Метод создания копий класса
        /// </summary>
        public Group FaceClone()
        {
            List<Param> LocalGParamList = new List<Param>();
            LocalGParamList.Clear();
            foreach (Param LocalParam in TGroopParamList)             
                LocalGParamList.Add(LocalParam.FaceClone());            
            return new Group(TName, LocalGParamList);
        }

       
    }
}
