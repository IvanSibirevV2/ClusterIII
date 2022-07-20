using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormSupportNameSpace;
using СlusterNameSpace;
using FCMNameSpace;

using Views;

namespace MA
{
    public partial class FormFCM : Form
    {
        /// <summary>
        /// Поддержка изменения размеров формы
        /// </summary>
        public FormSupport MyFormSupport = new FormSupport();

        /// <summary>
        /// Обрабатываемый кластер
        /// </summary>
        Cluster MyCluster = new Cluster();
        /// <summary>
        /// Исходный кластер
        /// </summary>
        Cluster MySuperCluster = new Cluster();

        /// <summary>
        /// Этот метод наглядно раскрашивает нашу таблицу
        /// </summary>
        private void MyDataGridViewColor()
        {
            
            MyColors Palette = new MyColors();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < this.dataGridView1.Rows[i].Cells.Count; j++)
                {

                    try
                    {
                        if (Convert.ToDouble(this.dataGridView1.Rows[i].Cells[j].Value) == 0)
                        {
                            this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Palette.MyForeGround.Center;//Color.FromArgb(255, 255, 0, 0);
                        }
                        else
                        {
                            this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Palette.MyBackGround.Cluster;//Color.FromArgb(255, 0, 255, 0);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            
        }


        public FormFCM(int N, Cluster MyLocalCluster, Cluster MySuperLocalCluster)
        {
            InitializeComponent();

            MyCluster = MyLocalCluster;
            MySuperCluster = MySuperLocalCluster;
            
             //FCMClass.FCMQ(N, MyCluster.Copy(), MySuperLocalCluster);

            BindingSource MyBindingSource1 = new BindingSource();
            FCMClass MyFCMClass = new FCMClass();
            MyBindingSource1.DataSource = MyFCMClass.FCM(20, 1.6, MyCluster.Copy(), MySuperLocalCluster);
            this.dataGridView1.DataSource = MyBindingSource1;

            FormFCM_SizeChanged(null, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
//            this.dataGridView1
        }

        private void FormFCM_SizeChanged(object sender, EventArgs e)
        {
            this.MyFormSupport.SizeChanged(this, new System.Windows.Forms.Control(), this.tabControl1, this.treeView1/*dataGridView1*/, new System.Windows.Forms.Control(), new System.Windows.Forms.Control());
            this.dataGridView1.Top = this.treeView1.Top;
            this.dataGridView1.Left = this.treeView1.Left;
            this.dataGridView1.Height = this.treeView1.Height;
            this.dataGridView1.Width = this.treeView1.Width;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void FormFCM_Load(object sender, EventArgs e)
        {

        }
    }
}
