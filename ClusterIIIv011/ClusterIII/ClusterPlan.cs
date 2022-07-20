using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClusterIII.Model;
using ClusterIII.View;

namespace ClusterIII
{
    public partial class ClusterPlan : Form
    {
        /// <summary>
        /// Наши данные
        /// </summary>        
        public Cluster MyLocalCluster = new Cluster();

        public List<Group> InfGroup = new List<Group>();
        public Boolean flag = false;

        public ClusterPlan(Cluster MyCluster)
        {
            InitializeComponent();

            //Заносим данные
            MyLocalCluster = MyCluster;
            //Заносим данные на экранную форму.
            this.checkedListBox1.Items.Clear();
            this.checkedListBox2.Items.Clear();
            int i = 0;
            foreach (Group MyGroup in MyLocalCluster.CGroupList)
            {
                this.checkedListBox1.Items.Add(MyGroup.Name);
                checkedListBox1.SetItemChecked(i, true);
                InfGroup.Add(new Group());
                InfGroup[i].Name = "true";
                int j = 0;
                foreach (Param MyParam in MyGroup.GParamList)
                {
                    InfGroup[i].GParamList.Add(new Param());
                    InfGroup[i].GParamList[j].Name = "true";
                    j++;
                }
                i++;

            }
            //...
            flag = true;
        }
        
        private void ClusterPlan_Load(object sender, EventArgs e)
        {
            ClusterPlan_SizeChanged(null, null);
            toolStripTextBox1_TextChanged(null, null);
            /*
            #region Это заглушка
                #warning 002 Это заглушка.(ClusterPlan.Подтвердить)
                подтвердитьToolStripMenuItem_Click(null, null);
            #endregion
             * */
        }

        private void ClusterPlan_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave2(this, this.menuStrip1, this.groupBox1, 5, 5, 5, 5);
        }

        private void groupBox1_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave3(this.groupBox1, this.checkedListBox1, this.checkedListBox2, 25, 5, 5, 5);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (char ch in toolStripTextBox1.Text)
            {
                if (ch != '0')
                    if (ch != '1')
                        if (ch != '2')
                            if (ch != '3')
                                if (ch != '4')
                                    if (ch != '5')
                                        if (ch != '6')
                                            if (ch != '7')
                                                if (ch != '8')
                                                    if (ch != '9')
                                                    {
                                                        toolStripTextBox1.Text = "2";
                                                    }
            }
            if (toolStripTextBox1.Text.Length == 0) toolStripTextBox1.Text = "2";
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = false;
            this.checkedListBox2.Items.Clear();
            int i = 0;
            foreach (Param MyParam in MyLocalCluster.CGroupList[checkedListBox1.SelectedIndex].GParamList)
            {
                this.checkedListBox2.Items.Add(MyParam.Name);
                if (InfGroup[checkedListBox1.SelectedIndex].GParamList[i].Name == "true")
                {
                    this.checkedListBox2.SetItemChecked(i, true);
                }
                i++;
            }
            flag = true;

        }

        private void подтвердитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MyLocalCluster            
            ;
            int ki = 0;
            for (int i = 0; i < this.InfGroup.Count; i++)
            {
                //удаляем лишние параметры
                int kj = 0;
                for (int j = 0; j < this.InfGroup[i].GParamList.Count; j++) //Так и должно быть
                {
                    if (this.InfGroup[i].GParamList[j].Name == "false") //Так и должно быть
                    {
                        MyLocalCluster.CGroupList[i - ki].GParamList.RemoveAt(j - kj);
                        foreach (Cluster MyLocalSuperCluster in MyLocalCluster.SCluster)
                        {
                            MyLocalSuperCluster.CGroupList[i - ki].GParamList.RemoveAt(j - kj);
                        }
                        kj++;
                    }
                }
                if (this.InfGroup[i].Name == "false")//Так и должно быть
                {
                    this.MyLocalCluster.CGroupList.RemoveAt(i - ki);
                    foreach (Cluster MyLocalSuperCluster in MyLocalCluster.SCluster)
                    {
                        MyLocalSuperCluster.CGroupList.RemoveAt(i - ki);
                    }
                    ki++;
                }                
            }            
            this.DialogResult = DialogResult.OK;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
