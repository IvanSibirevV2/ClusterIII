using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////////////////////////////////////////////
using Component;
using Component.UltimateChoicer;
using System.Windows.Forms;

namespace Component.LLSDataSource.Script
{
    public static class LoaderLLS_From_TxT
    {
        public static void Test_LoaderLLS_From_TxT()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            LoaderLLS_From_TxT_WinForm().writeThis(5);
        }
        public static List<List<string>> LoaderLLS_From_TxT_WinForm()
        {
            List<List<string>> _LLS_RESALT = new List<List<string>>();
            bool _flagan_ = true;
            while(_flagan_){
                bool _flagan = true;
                System.Windows.Forms.OpenFileDialog _openFileDialog = new System.Windows.Forms.OpenFileDialog();
                if (_openFileDialog.ShowDialog() != DialogResult.OK) { _flagan = true; } else { _flagan = false; }
                if (!_flagan) foreach (var _fileName in _openFileDialog.FileNames) if (System.IO.File.Exists(_fileName))
                        {
                            _LLS_RESALT = (new LLS_TxT_SaveLoadEr()).LoadFromFile(_fileName).p_LLS;
                            //_LLS_RESALT = LoaderLLS_From_TxT_Console(_fileName);
                        }
                if (_LLS_RESALT.LLS_DataTest_())
                    _flagan_ = !_flagan_;
                
            }
            return _LLS_RESALT;
        }
    }
}