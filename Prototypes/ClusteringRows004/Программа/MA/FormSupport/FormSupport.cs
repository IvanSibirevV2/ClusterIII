using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormSupportNameSpace
{
    /// <summary>
    /// Класс поддержки функционала формы
    /// </summary>
    public class FormSupport
    {
        private Boolean Flag = true;
        /// <summary>
        /// Данный метод призван поддерживать адекватную геометрию формы и её содержимого
        /// </summary>
        /// <param name="FormControl">Сюда передаётся упраление формой</param>
        /// <param name="MenuStripControl"> Сюда передаётся управление панелью меню формы</param>
        /// <param name="GroupBoxControl">Сюда передаётся управление контейнером</param>
        /// <param name="InGroupBoxControl">Сюда передаётся управление содержимым контеинера</param>
        public void SizeChanged(
                                System.Windows.Forms.Control FormControl,
                                System.Windows.Forms.Control MenuStripControl, 
                                System.Windows.Forms.Control GroupBoxControl, 
                                System.Windows.Forms.Control InGroupBoxControl,

                                System.Windows.Forms.Control InGroupBoxControlPart1From2,
                                System.Windows.Forms.Control InGroupBoxControlPart2From2
                                )
        {
            if (Flag)
            {
                FormControl.Width = 325;
                FormControl.Height = 375;
                GroupBoxControl.Top = MenuStripControl.Top + MenuStripControl.Height;
                InGroupBoxControl.Top = GroupBoxControl.Top + 15;
                InGroupBoxControlPart1From2.Top = InGroupBoxControl.Top;
                InGroupBoxControlPart2From2.Top = InGroupBoxControl.Top;
                GroupBoxControl.Left = 5;
                InGroupBoxControl.Left = GroupBoxControl.Left + 5;

                InGroupBoxControlPart1From2.Left = GroupBoxControl.Left + 5;
                InGroupBoxControlPart2From2.Left = (GroupBoxControl.Width - InGroupBoxControl.Left * 2) / 2 + 1 * InGroupBoxControlPart1From2.Left;
                InGroupBoxControlPart1From2.Width = Convert.ToInt32(GroupBoxControl.Width / 2 - InGroupBoxControlPart1From2.Left * 1.5);
                InGroupBoxControlPart2From2.Width = Convert.ToInt32(GroupBoxControl.Width / 2 - InGroupBoxControlPart1From2.Left * 1.5);

                Flag = false;
            }
            if ((FormControl.Height >= 375) && (FormControl.Width >= 325))
            {
                GroupBoxControl.Width = FormControl.Width - GroupBoxControl.Left - 20;
                InGroupBoxControl.Width = GroupBoxControl.Size .Width - (InGroupBoxControl.Left - GroupBoxControl.Left) - 25;
                GroupBoxControl.Height = FormControl.Height - GroupBoxControl.Top - 45;
                InGroupBoxControl.Height = GroupBoxControl.Height - (InGroupBoxControl.Top - GroupBoxControl.Top) - 50;

                InGroupBoxControlPart1From2.Height = GroupBoxControl.Height - (InGroupBoxControlPart1From2.Top - GroupBoxControl.Top) - 50;
                InGroupBoxControlPart2From2.Height = GroupBoxControl.Height - (InGroupBoxControlPart2From2.Top - GroupBoxControl.Top) - 50;

                InGroupBoxControlPart2From2.Left = (GroupBoxControl.Width - InGroupBoxControl.Left * 2) / 2 + 1 * InGroupBoxControl.Left;
                InGroupBoxControlPart1From2.Width = Convert.ToInt32(GroupBoxControl.Width / 2 - InGroupBoxControlPart1From2.Left * 1.5);
                InGroupBoxControlPart2From2.Width = Convert.ToInt32(GroupBoxControl.Width / 2 - InGroupBoxControlPart1From2.Left * 1.5);
            }
            else
            {
                FormControl.Height = 375;
                FormControl.Width = 325;
            }            
        }
    }    
}