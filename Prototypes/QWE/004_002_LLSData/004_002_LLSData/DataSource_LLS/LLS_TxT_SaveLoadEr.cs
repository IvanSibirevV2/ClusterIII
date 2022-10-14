using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.LLSDataSource
{
    public interface ILLS_TxT_SaveLoadEr
    {
        List<List<string>> p_LLS{get;set;}
        string p_FilePath{get;set;}
        string p_FileName{ get; set; }
        /////////////////////////////////////////////////
        ILLS_TxT_SaveLoadEr Set(Action<ILLS_TxT_SaveLoadEr> x);
        ILLS_TxT_SaveLoadEr Set_p_LLS(List<List<string>> _p_LLS);
        ILLS_TxT_SaveLoadEr Set_p_FilePath(string _p_FilePath);
        ILLS_TxT_SaveLoadEr Set_p_FileName(string _p_FileName);
        ILLS_TxT_SaveLoadEr SaveToFile();
        ILLS_TxT_SaveLoadEr SaveToFile(string _p_FilePath);
        ILLS_TxT_SaveLoadEr LoadFromFile();
        ILLS_TxT_SaveLoadEr LoadFromFile(string _p_FilePath);
    }
    public class LLS_TxT_SaveLoadEr : ILLS_TxT_SaveLoadEr
    {
        public ILLS_TxT_SaveLoadEr Set(Action<ILLS_TxT_SaveLoadEr> x) { x(this); return this; }
        /////////////////////////////////////////////////
        public List<List<string>> p_LLS{ get; set; }
        public string p_FilePath{ get; set; }
        public string p_FileName{ get; set; }
        public LLS_TxT_SaveLoadEr()
        {
            this
                .Set_p_LLS(Component.LLSDataSource.Standart.Data_Super_Small())
                .Set_p_FilePath(System.IO.Directory.GetCurrentDirectory())
                .Set_p_FileName("TxT")
            ;
        }        
        
        public ILLS_TxT_SaveLoadEr Set_p_LLS(List<List<string>> _p_LLS) { this.p_LLS = _p_LLS; return this; }
        public ILLS_TxT_SaveLoadEr Set_p_FilePath(string _p_FilePath) { this.p_FilePath = _p_FilePath; return this; }
        public ILLS_TxT_SaveLoadEr Set_p_FileName(string _p_FileName) { this.p_FileName = _p_FileName; return this; }
        /////////////////////////////////////////////////
        public ILLS_TxT_SaveLoadEr SaveToFile()
        {
            SaveToFile(this.p_FilePath + "\\" + this.p_FileName + ".txt");
            return this;
        }
        public virtual ILLS_TxT_SaveLoadEr SaveToFile(string _p_FilePath)
        {
            using (System.IO.StreamWriter sw= new System.IO.StreamWriter(_p_FilePath, false, System.Text.Encoding.Default))
            {
                foreach (List<string> _ls in this.p_LLS)
                {
                    string _str = _ls[0];
                    for (int i = 1; i < _ls.Count; i++)
                        _str = _str + '~' + _ls[i];
                    sw.WriteLine(_str);
                }
            }
            return this;
        }
        public ILLS_TxT_SaveLoadEr LoadFromFile()
        {
            LoadFromFile(this.p_FilePath + "\\" + this.p_FileName + ".txt");
            return this;
        }
        public virtual ILLS_TxT_SaveLoadEr LoadFromFile(string _p_FilePath)
        {
            List<List<string>> _lls_Resalt = new List<List<string>>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(_p_FilePath, System.Text.Encoding.Default))
            {
                string line="";
                while ((line = sr.ReadLine()) != null)
                    _lls_Resalt.Add(line.Split('~').ToList<string>());

            }
            this.p_LLS = _lls_Resalt.Get_Copy();
            if (!this.p_LLS.LLS_DataTest_())
                throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию", (new StackTracer()).Get_STSS());
            return this;
        }

        public static void Text()
        {
            //Component.LLSDataSource.LLS_TxT_SaveLoadEr.Text()
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            //Component.LLSDataSource.LLS_TxT_SaveLoadEr
        }
    }
}