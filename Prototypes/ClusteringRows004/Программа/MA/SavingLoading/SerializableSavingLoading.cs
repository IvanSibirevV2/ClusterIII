using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using СlusterNameSpace;

namespace SavingLoadingNameSpace
{
    public class SLSerializableService
    {
        /// <summary>
        /// Запись в файл
        /// </summary>
        /// <param name="MyCluster">Записываемые данные</param>
        /// <param name="spath">Путь к файлу</param>
        public void StreamSaver(Cluster MyCluster, string spath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(spath, FileMode.Create);
            formatter.Serialize(fileStream, MyCluster);
            fileStream.Close();
        }
        /// <summary>
        /// Загрузка из файла
        /// </summary>
        /// <param name="spath">Путь к файлу</param>
        /// <returns>Загруженные данные</returns>
        public Cluster StreamLoader(string spath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(spath, FileMode.Open);
            Cluster MyCluster = (Cluster)formatter.Deserialize(fileStream);           
            fileStream.Close();
            return MyCluster;
        }        
    }
}