using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////////////////////

namespace Component
{
    public interface IMyMicroEXCEL
    {
        List<List<string>> p_EX { get; set; }
        IProgressTime p_ProgressTime { get; set; }
        //////////////////////////////////////////////////////////////////////////////////////////
        string p_PathForWorkDir { get; set; }
        string p_FileName { get; set; }
        bool p_NeedToSave { get; set; }
        //////////////////////////////////////////////////////////////////////////////////////////
        IMyMicroEXCEL Set(Action<IMyMicroEXCEL> x);
        IMyMicroEXCEL Set_p_PathForWorkDir(string _p_PathForWorkDir);
        IMyMicroEXCEL Set_p_FileName(string _p_FileName);
        IMyMicroEXCEL Set_p_NeedToSave(bool _p_NeedToSave);
        //////////////////////////////////////////////////////////////////////////////////////////
        IMyMicroEXCEL Set_NextRow();
        IMyMicroEXCEL add(int _LocalShiftRow, int _LocalColumn, string _RecordText);
        IMyMicroEXCEL add(int _LocalColumn, string _RecordText);
        IMyMicroEXCEL add(int i, List<string> _LS);
        IMyMicroEXCEL add(int i, List<List<string>> _LLS);
        //void SaveToFile();
        IMyMicroEXCEL Show();
    }
    public class MyMicroEXCEL : IMyMicroEXCEL
    {
        //////////////////////////////////////////////////////////////////////////////////////////
        private System.Threading.Tasks.Task<bool> p_Work = System.Threading.Tasks.Task<bool>.Run(() => { return true; });
        private string p__PathForWorkDir = System.IO.Directory.GetCurrentDirectory();
        public string p_PathForWorkDir{get { this.p_Work.GetAwaiter(); return this.p__PathForWorkDir; }set { this.p_Work.GetAwaiter(); this.p__PathForWorkDir = value; }}
        private string p__FileName = "MyMicroEXCEL";
        public string p_FileName{get { this.p_Work.GetAwaiter(); return this.p__FileName; }set { this.p_Work.GetAwaiter(); this.p__FileName = value; }}
        private bool p__NeedToSave = false;
        public bool p_NeedToSave{get { this.p_Work.GetAwaiter(); return this.p__NeedToSave; }set { this.p_Work.GetAwaiter(); this.p__NeedToSave = value; }}
        private int p_ShiftRow = 1;
        private List<List<string>> p__EX = new List<List<string>>();
        public List<List<string>> p_EX{get { return this.p__EX; }set { this.p__EX = value; }}
        private IProgressTime p__ProgressTime = new ProgressTime();
        public IProgressTime p_ProgressTime { get { return this.p__ProgressTime; } set { this.p__ProgressTime = value; } }
        //////////////////////////////////////////////////////////////////////////////////////////
        public IMyMicroEXCEL Set(Action<IMyMicroEXCEL> x) { x(this); return this; }
        public IMyMicroEXCEL Set_p_PathForWorkDir(string _p_PathForWorkDir) { this.p_PathForWorkDir = _p_PathForWorkDir; return this; }
        public IMyMicroEXCEL Set_p_FileName(string _p_FileName) { this.p_FileName = _p_FileName; return this; }
        public IMyMicroEXCEL Set_p_NeedToSave(bool _p_NeedToSave) { this.p_NeedToSave = _p_NeedToSave; return this; }
        //////////////////////////////////////////////////////////////////////////////////////////
        public IMyMicroEXCEL Set_NextRow() { this.p_ShiftRow++; return this; }
        public IMyMicroEXCEL add(int _LocalShiftRow, int _LocalColumn, string _RecordText)
        {
            List<string> _LS = new List<string>();
            _LS.Add(Convert.ToString(_LocalShiftRow + this.p_ShiftRow));
            _LS.Add(Convert.ToString(_LocalColumn));
            _LS.Add(_RecordText);
            this.p_EX.Add(_LS);
            return this;
        }
        public IMyMicroEXCEL add(int _LocalColumn, string _RecordText) { this.add(0, _LocalColumn, _RecordText); return this; }
        public IMyMicroEXCEL add(int i, List<string> _LS) { for (int j = 0; j < _LS.Count; j++) this.add(0, i + j, _LS[j]); return this.Set_NextRow(); }
        public IMyMicroEXCEL add(int i, List<List<string>> _LLS) { foreach (List<string> _LS in _LLS) add(i, _LS); return this.Set_NextRow(); }

        private void SaveToFile()
        {
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            ObjExcel.SheetsInNewWorkbook = 1;
            ObjExcel.Workbooks.Add(Type.Missing);
            //Книга
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
            int counter = 0;
            ;
            this.p_ProgressTime
                .Set_p_Progress_now(0)
                .Set_p_Progress_max(p_EX.Count)
                .Set_Start();
            foreach (List<string> qwe in p_EX)
            {
                //Console.WriteLine(Convert.ToString(counter) + "/" + Convert.ToString(p_EX.Count));

                ObjWorkSheet.Cells[Convert.ToInt16(qwe[0]) + 1, Convert.ToInt16(qwe[1]) + 1] = Convert.ToString(qwe[2]);
                counter++;
                this.p_ProgressTime.Set_ProgressNext();
            }
            this.p_ProgressTime.Set_Stop();

            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
            if (p_NeedToSave)
            {
                string WorkDailPath = this.p_PathForWorkDir + "\\" + this.p_FileName + ".xls";
                if (System.IO.File.Exists(WorkDailPath)) System.IO.File.Delete(WorkDailPath);
                ObjWorkBook.SaveAs(WorkDailPath);//"C:\\Шаблон_Изменен.xls"
                //Ex.Add((new string[] { Convert.ToString(ii), Convert.ToString(1 + u), Convert.ToString(LS[0][u]) }).ToList());
                //{ List<string> q = new List<string>(); q.Add(Convert.ToString(1)); q.Add(Convert.ToString(j + 1)); q.Add(Convert.ToString(j)); Ex.Add(q); }
            }
        }
        public IMyMicroEXCEL Show()
        {
            this.p_Work.GetAwaiter();
            this.SaveToFile();
            //this.p_Work = System.Threading.Tasks.Task<bool>.Run(() => { this.SaveToFile(); return true; });
            return this;
        }
        public static void Text()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());

            IMyMicroEXCEL _IMyMicroEXCEL = new MyMicroEXCEL();
            _IMyMicroEXCEL.p_ProgressTime.Set_p_Progress_Action((int i) => { Console.WriteLine(Convert.ToString(i)); });
            _IMyMicroEXCEL
                .add(5, "пРИВЕТ МИР").Set_NextRow()
                .add(4, "пРИВЕТ МИР").Set_NextRow()
                .add(3, "пРИВЕТ МИР").Set_NextRow()
                .add(2, "пРИВЕТ МИР").Set_NextRow()
                .Show()
                ;
        }
    }
}