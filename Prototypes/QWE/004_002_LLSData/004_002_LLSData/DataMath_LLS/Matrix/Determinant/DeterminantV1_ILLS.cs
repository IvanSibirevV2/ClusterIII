using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Math.Matrix
{
    /// <summary>Dictionary_Determinant_Point</summary>
    public class DeterminantV1_ILLS : DeterminantV0_ILLS, IDeterminant_ILLS
    {
        //Класс обладает двойной структурой
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////Закрытая часть класса////////////
        //На это было тогда угрохано не мало времени, зато быстродействие просто шикарное//
        //////////////////////////!Работает оно только в одном потоке, но оно того стоит!//
        /// <summary>Dictionary_Determinant_Point</summary>
        public class DDPoint
        {
            private IList<IList<string>> p_ILLS = new List<IList<string>>();
            private bool p_flage = false;
            private Double p_Determinant = 0;
            ///////////////////////////////////        
            public Double Get_p_Determinant() { return this.p_Determinant; }
            public IList<IList<string>> Get_p_ILLS() { return this.p_ILLS.Get_InterfaseCopy(); }
            ///////////////////////////////////
            public DDPoint(IList<IList<string>> _p_ILLS, Double _p_Dictionary)
            {
                this.p_ILLS = _p_ILLS.Get_InterfaseCopy();
                this.p_Determinant = _p_Dictionary;
            }
        }
        private IList<IList<DDPoint>> p_ILLDDP = new List<IList<DDPoint>>();

        private bool Get_Counterpose(IList<IList<string>> _ILLS)
        {
            int iCount = _ILLS.Count;
            while (this.p_ILLDDP.Count <= iCount)
                this.p_ILLDDP.Add(new List<DDPoint>());

            bool flag = false;
            foreach (DDPoint _DDPoint in this.p_ILLDDP[iCount - 1])
                if (_DDPoint.Get_p_ILLS().Get_Counterpose(_ILLS))
                    flag = true;
            return flag;
        }
        private DDPoint Get_DDPoint(IList<IList<string>> _ILLS)
        {
            int iCount = _ILLS.Count;
            while (this.p_ILLDDP.Count < iCount)
                this.p_ILLDDP.Add(new List<DDPoint>());

            DDPoint _DDPoint = new DDPoint(_ILLS, -200);
            foreach (DDPoint _LDDPoint in this.p_ILLDDP[iCount - 1])
                if (_LDDPoint.Get_p_ILLS().Get_Counterpose(_ILLS))
                    _DDPoint = _LDDPoint;
            return _DDPoint;
        }
        private double Get_Determinant(IList<IList<string>> _ILLS)
        {
            bool isExist = this.Get_Counterpose(_ILLS);
            ;
            if (!isExist)
            {
                #region РасчетОпределителяМатриц
                IList<IList<string>> _ILLS_this = _ILLS.Get_InterfaseCopy();

                if ((_ILLS_this.Count == 2) && (_ILLS_this[0].Count == 2))
                {
                    this.p_ILLDDP[_ILLS.Count - 1].Add(new DDPoint(_ILLS.Get_InterfaseCopy(), Convert.ToDouble(_ILLS_this[1][1])));
                    return Convert.ToDouble(_ILLS_this[1][1]);
                }
                double rez = 0;

                for (int i = 1; i < _ILLS_this.Count; i++)
                {

                    double q = System.Math.Pow(-1, i + 1);
                    double w = Convert.ToDouble(_ILLS_this[i][1]);
                    double e = this.Get_Determinant(
                        	(new Minor_ILLS())
								.Set_p_ILLS(_ILLS_this.Get_InterfaseCopy())
								.Set_p_i(i).Set_p_j(1)
								.DO()
								.Get_Resalt().Get_InterfaseCopy()
                        );
                    rez += q * w * e;
                }
                #endregion

                this.p_ILLDDP[_ILLS.Count - 1].Add(new DDPoint(_ILLS.Get_InterfaseCopy(), rez));
                ;
                isExist = this.Get_Counterpose(_ILLS);
            }
            isExist = this.Get_Counterpose(_ILLS);
            if (isExist)
            {
                return this.Get_DDPoint(_ILLS).Get_p_Determinant();
            }
            return 404;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //Открытая часть  часть класса, сделана для совместимости с новым интерфейсом IDeterminant//
        //для поддержки императивного и функционального стиля и асинхронности//
        //В ОТЛИЧАЕ ОТ DeterminantV0 у DeterminantV1 асинхронность есть,
        //по этому пришлось бы при наследовании переопределять каждую мелочь
        //По этому было проще воткнуть весь код заново
        //По этому его пытаться упростить не надо, Что называется "Не трогать"
        ///////////////////////////////////////////////////////////////////////////////////////////////////////        
        private System.Threading.Tasks.Task<double> _TaskWorker = System.Threading.Tasks.Task<double>.Run(() => { return (double)0; });
        ///////////////////////////////////////////////////////////////////////////////////////////////////////        
        ////////////////////////////////////////////////////////
        public override IDeterminant_ILLS Do()
        {
			/*
            this.p_IProgressTime.Set_Start();
            {
                this._TaskWorker.GetAwaiter();
                List<List<string>> _ILLS = this.p_LLS.Get_Copy();
                _TaskWorker = System.Threading.Tasks.Task<double>.Run(() => {
                    return this.Get_Determinant(_ILLS); });
                //this.Get_Determinant(_ILLS);
            }
            this.p_IProgressTime.Set_Stop();
            this.p_IProgressTime.p_CalcIsLocked = true;
             * */
            this.p_IProgressTime.Set_Start();
            {
                if (this.p_NeedDataTest)
                {
                    if (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_()) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!this.p_ILLS.Get_CopyAsLS().LLS_DataTest_())", (new StackTracer()).Get_STSS());
                    if (!(this.p_ILLS.Count() == this.p_ILLS[0].Count())) throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nВходные данные не прошли валидацию (!(this.p_ILLS.Count() == this.p_ILLS[0].Count()))", (new StackTracer()).Get_STSS());
                }
				this.p_Resalt = this.Get_Determinant(this.p_ILLS.Get_InterfaseCopy());
                
                
            }
            this.p_IProgressTime.Set_Stop();
            return this;
            return this;
        }
        ////////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
            IDeterminant_ILLS _IDeterminant = (new Component.Math.Matrix.DeterminantV1_ILLS()).Set_p_NeedDataTest(true);
            #region Штатный тест
            {
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Штатный тест");
                _IDeterminant.Get_InterfaceCopy()
                    .Set((IDeterminant_ILLS _this) => { _this.p_ILLS.writeThis(5); }).Do();
                Console.WriteLine("Determinant=" + Convert.ToString(_IDeterminant.Get_Resalt()));
            }
            #endregion
            #region Не штатный тест
            {
                #region Не штатный тест №1
                try
                {
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не Штатный тест");
                    _IDeterminant.Get_InterfaceCopy()
                        .Set_p_ILLS(
                            ((new List<string>[] {
                                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                                ,(new string[] {"А2",	"1",	"1",	"6",	"4",	"1"	}).ToList<string>()	
                                ,(new string[] {"А3",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                                ,(new string[] {"А4",	"1",	"1",	"2",	"2",	"3"	}).ToList<string>()	
                                ,(new string[] {"А5",	"1",	"8",	"0",	"1",	"1"	}).ToList<string>()	
                            }).ToList<List<string>>()).Get_CopyAsILS()
                        ).Do();
                }
                catch (ArgumentException e)
                { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
                #endregion
                #region Не штатный тест №2

                try
                {
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не Штатный тест");
                    _IDeterminant.Get_InterfaceCopy()
                        .Set_p_ILLS(
                            ((new List<string>[] {
                                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                                ,(new string[] {"А2",	"1",	"1",	"6",	"4",	"1"	}).ToList<string>()	
                                ,(new string[] {"А4",	"1",	"1",	"2",	"2",	"3"	}).ToList<string>()	
                                ,(new string[] {"А5",	"1",	"8",	"0",	"1",	"1"	}).ToList<string>()	
                            }).ToList<List<string>>()).Get_CopyAsILS()
                        ).Do();
                }
                catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
                #endregion
                #region Не штатный тест №3

                try
                {
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не Штатный тест");
                    _IDeterminant.Get_InterfaceCopy()
                        .Set_p_ILLS(
                            ((new List<string>[] {
                                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                                ,(new string[] {"А2",	"1",	"1",	"6",	"4",	"1"	}).ToList<string>()	
                                ,(new string[] {"А3",	"1",	"0",	"0",	"0"	}).ToList<string>()	
                                ,(new string[] {"А4",	"1",	"1",	"2",	"2",	"3"	}).ToList<string>()	
                                ,(new string[] {"А5",	"1",	"8",	"0",	"1",	"1"	}).ToList<string>()	
                            }).ToList<List<string>>()).Get_CopyAsILS()
                        ).Do();
                }
                catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
                #endregion
                #region Не штатный тест №4
                try
                {
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Component.Math.Matrix.Determinant.DeterminantV0 Class");
                    (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkBlue)).WriteLine("Не Штатный тест");
                    _IDeterminant.Get_InterfaceCopy()
                        .Set_p_ILLS(
                            ((new List<string>[] {
                                (new string[] {"Data_Super_Small;",	"П1",	"П2",	"П3",	"П4",	"П5"}).ToList<string>()
                                ,(new string[] {"А1",	"1",	"1",	"1",	"1",	"1" }).ToList<string>()	
                                ,(new string[] {"А2",	"1",	"1",	"6",	"4",	"1"	}).ToList<string>()	
                                ,(new string[] {"А4",	"1",	"1",	"2",	"2",	"3"	}).ToList<string>()	
                                ,(new string[] {"А5",	"1",	"8",	"0",	"1",	"1"	}).ToList<string>()	
                            }).ToList<List<string>>()).Get_CopyAsILS()
                        ).Do();
                }
                catch (ArgumentException e) { (new Consoller_Shabloner()).WriteLine("Эксепшен словлен").Set_ColorS(ConsoleColor.Red, ConsoleColor.Cyan).WriteLine("///////////////////////////////////////////////").Set_StandartSettings().WriteLine(e.Message); }
                #endregion
            }
            #endregion
        }
    }
}
