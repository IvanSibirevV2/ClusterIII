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

namespace MA
{
    public partial class NewFormCHInf : Form
    {
        /// <summary>
        /// Поддержка изменения размеров формы
        /// </summary>
        public FormSupport MyFormSupport = new FormSupport();

        /// <summary>
        /// Наши данные
        /// </summary>        
        public Cluster MyLocalCluster = new Cluster();

        public List<Group> InfGroup = new List<Group>();
        public Boolean flag = false;

        public NewFormCHInf(Cluster MyCluster)
        {
            InitializeComponent();

            NewFormCHInf_SizeChanged(null, null);

            //Заносим данные
            MyLocalCluster = MyCluster;
            //Заносим данные на экранную форму.
            this.checkedListBox1.Items.Clear(); 
            this.checkedListBox2.Items.Clear();
            int i = 0;
            foreach(Group MyGroup in MyLocalCluster.CGroupList)
            {
                this.checkedListBox1.Items.Add(MyGroup.Name);
                checkedListBox1.SetItemChecked(i, true);
                InfGroup.Add(new Group());
                InfGroup[i].Name = "true";
                int j=0;
                foreach(Param MyParam in MyGroup.GParamList)
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

        private void NewFormCHInf_SizeChanged(object sender, EventArgs e)
        {
            //System.Windows.Forms.Control MyControl = new System.Windows.Forms.Control();
            MyFormSupport.SizeChanged(this, this.menuStrip1, this.groupBox1, new System.Windows.Forms.Control(), this.checkedListBox1, this.checkedListBox2);
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
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = false;
            this.checkedListBox2.Items.Clear();            
            int i = 0;
            foreach (Param MyParam in MyLocalCluster.CGroupList[checkedListBox1.SelectedIndex].GParamList)
            {
                this.checkedListBox2.Items.Add(MyParam.Name);
                if (InfGroup[checkedListBox1.SelectedIndex].GParamList[i].Name=="true")
                {
                    this.checkedListBox2.SetItemChecked(i, true);
                }
                i++;
            }
            flag = true;

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (flag)
            {

                if (this.InfGroup[this.checkedListBox1.SelectedIndex].Name == "true") 
                {
                    this.InfGroup[this.checkedListBox1.SelectedIndex].Name = "false";
                }
                else
                {
                    this.InfGroup[this.checkedListBox1.SelectedIndex].Name = "true";
                }
                ;
                
                
            }
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (flag)
                if (this.checkedListBox2.SelectedIndex>=0)
            if (this.InfGroup[this.checkedListBox1.SelectedIndex].GParamList[this.checkedListBox2.SelectedIndex].Name == "true")
            {
                this.InfGroup[this.checkedListBox1.SelectedIndex].GParamList[this.checkedListBox2.SelectedIndex].Name = "false";
            }
            else
            {
                this.InfGroup[this.checkedListBox1.SelectedIndex].GParamList[this.checkedListBox2.SelectedIndex].Name = "true";
            }
            ;

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MyLocalCluster
            //int kj=0;
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
                
                ;
                if (this.InfGroup[i].Name == "false")//Так и должно быть
                {
                    this.MyLocalCluster.CGroupList.RemoveAt(i - ki);
                    foreach (Cluster MyLocalSuperCluster in MyLocalCluster.SCluster)
                    {
                        MyLocalSuperCluster.CGroupList.RemoveAt(i - ki);                        
                    }
                    ki++;
                }
                ;

            }
            ;
            this.DialogResult = DialogResult.OK;
        }

        private void NewFormCHInf_Load(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
