using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////////////////////////////////
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Component.Serialization
{
    [Serializable]
    public class Serializator
    {
        private object p_object = new object();
        public Serializator() { }
        public Serializator(object _p_object) { this.p_object = _p_object; }
        public Serializator Set(object _p_object) { this.p_object = _p_object; return this; }
        public object Get_p_object() { return this.p_object; }
    }
    public static class SerializableSavingLoadingV3
    {
        /// <summary>Запись в файл</summary><param name="MyCluster">Записываемые данные</param><param name="spath">Путь к файлу</param>
        public static void StreamSaver(Serializator MyCluster)
        {
            string spath = SaveFileDialogString();
            StreamSaver(MyCluster, spath);
        }
        public static void StreamSaver(Serializator MyCluster, string spath)
        {
            if (spath != "000")
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(spath, FileMode.Create);
                formatter.Serialize(fileStream, MyCluster);
                fileStream.Close();
            }
        }
        /// <summary>Загрузка из файла</summary><param name="spath">Путь к файлу</param><returns>Загруженные данные</returns>
        public static Serializator StreamLoader()
        {
            string spath = OpenFileDialogString();
            if (spath == "000")
                return new Serializator();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(spath, FileMode.Open);
            Serializator MyCluster = ((Serializator)formatter.Deserialize(fileStream));
            fileStream.Close();
            return MyCluster;
        }
        public static string OpenFileDialogString()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Filter = "XML files|*.SOF";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return "000";
            return fileDialog.FileName;
        }
        public static string SaveFileDialogString()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.FileName = "NoName";
            fileDialog.Filter = "XML files|*.SOF|*.SOFBin";
            //fileDialog.Filter = "*.SOFBin";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return "000";
            return fileDialog.FileName;
        }
    }
}