using System.Windows.Forms;

namespace TextParser
{

    /// <summary>
    /// Класс, облегчающий загрузку - сохранение.
    /// </summary>
    public static class FileDialog
    {
        /// <summary>
        /// Метод возвращает путь к загружаемому файлу
        /// </summary>
        /// <param name="TypeFile">Тип файла, его расширение.</param>
        /// <returns></returns>
        public static string SaveString(string TypeFile)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = TypeFile + " files|*." + TypeFile;
            if (fileDialog.ShowDialog() != DialogResult.OK) { }
            return fileDialog.FileName;            
        }

        /// <summary>
        /// Метод возвращает путь к месту сохранения файлу
        /// </summary>        
        /// <param name="TypeFile">Тип файла, его расширение.</param>
        /// <returns></returns>
        public static string LoadString(string TypeFile)
        {            
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = TypeFile + " files|*." + TypeFile;
            if (fileDialog.ShowDialog() != DialogResult.OK) { }
            return fileDialog.FileName;        
        }
        


    }
}
