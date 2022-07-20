using System.Windows.Forms;

namespace ClustererData
{
    /// <summary>
    /// Класс поддержки функционала формы
    /// </summary>
    public static class FormSupport
    {
        /// <summary>
        /// Класс изменения размеров
        /// </summary>
        public static class SizeChanged
        {
            /// <summary>
            /// Лень присваивать параметры много раз, по этому пишу этот метод.
            /// </summary>            
            private static Control SetThis(Control LocalControl, int Top, int Left, int Height, int Width)
            {
                LocalControl.Top=Top;
                LocalControl.Left=Left;
                LocalControl.Height = Height;
                LocalControl.Width = Width;
                return LocalControl;
            }

            /// <summary>
            /// Метод, что описывает изменение размеров окон.
            /// </summary>
            /// <param name="MasterControl">Управляющий элемент внешнего окна.</param>
            /// <param name="SlaveControl">Управляющий элемент вложенного, внутреннего окна</param>
            /// <param name="HShift">HeightShift - Вертикальный сдвиг, отступ</param>
            /// <param name="WShift">WidthShift - Вертикальный сдвиг, отступ</param>
            public static void MasterSlave1(Control MasterControl, Control SlaveControl, int HShift, int WShift)
            {
                //Ручная доводка до совершенства
                int Top = HShift;
                int Left = WShift;
                int Height = MasterControl.Height - HShift * 2;
                int Width = MasterControl.Width - 2 * WShift;
                //MasterControl
                //MasterControl.ToString
                if (MasterControl.Name == "FormMain")
                {
                    
                    Height = Height - 36;
                    Width = Width - 14;
                }
                else 
                SetThis(SlaveControl, Top, Left, Height, Width);
            }

            /// <summary>
            /// Метод, что описывает изменение размеров окон.
            /// </summary>
            /// <param name="MasterControl">Управляющий элемент внешнего окна.</param>
            /// <param name="SlaveControl">Управляющий элемент вложенного, внутреннего окна1</param>            
            /// <param name="SlaveControl2">Управляющий элемент вложенного, внутреннего окна2</param>
            /// <param name="HShift">HeightShift - Вертикальный сдвиг, отступ</param>
            /// <param name="WShift">WidthShift - Вертикальный сдвиг, отступ</param>
            public static void MasterSlave2(Control MasterControl, Control SlaveControl1, Control SlaveControl2, int HShift, int WShift)
            {
                //Ручная доводка до совершенства
                int Top = HShift;
                int Left = WShift;
                int Height = MasterControl.Height - HShift * 2;
                int Width = MasterControl.Width - 2 * WShift;
                if (MasterControl.Name == "FormMain")
                {
                    Height = Height - 36;
                    Width = Width - 14;
                }
                SetThis(SlaveControl1, Top, Left, SlaveControl1.Height, Width);
                SetThis(SlaveControl2, SlaveControl1.Height + HShift, Left, Height - SlaveControl1.Height-HShift, Width);
            }
        }
    }    
}