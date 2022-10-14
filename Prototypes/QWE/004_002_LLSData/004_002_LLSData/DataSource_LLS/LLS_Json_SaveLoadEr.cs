using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////////////////////////
using Component.Json;

namespace Component.LLSDataSource
{
    public class LLS_Json_SaveLoadEr :LLS_TxT_SaveLoadEr, ILLS_TxT_SaveLoadEr
    {
        public LLS_Json_SaveLoadEr(): base (){}
        ///////////////////////////////////////////////////////////////
        public override ILLS_TxT_SaveLoadEr SaveToFile(string _p_FilePath)
        {
            using (System.IO.StreamWriter sw= new System.IO.StreamWriter(_p_FilePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(
                    this.p_LLS.Get_CopyAsILS().Get_AS_Json_String()
                );
                sw.Close();
            }
            return this;
        }
        public override ILLS_TxT_SaveLoadEr LoadFromFile(string _p_FilePath)
        {
            List<List<string>> _lls_Resalt = new List<List<string>>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(_p_FilePath, System.Text.Encoding.Default))
            {
                string _Json_String = "";
                string line="";
                while ((line = sr.ReadLine()) != null)
                    _Json_String =_Json_String + line;
                this.p_LLS = _Json_String.Get_AS_Json_ILLS().Get_CopyAsLS();
            }
            
            if (!this.p_LLS.LLS_DataTest_())
                throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию", (new StackTracer()).Get_STSS());
            return this;
        }
        public static void Text()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());            
        }
    }
}
