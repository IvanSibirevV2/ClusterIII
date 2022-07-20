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
    public partial class FormCHInf : Form
    {
        /// <summary>
        /// Поддержка изменения размеров формы
        /// </summary>
        public FormSupport MyFormSupport = new FormSupport();

        /// <summary>
        /// Наши данные
        /// </summary>        
        public Cluster MyLocalCluster = new Cluster();

        public FormCHInf(Cluster MyCluster)
        {
            InitializeComponent();

            FormCHInf_SizeChanged(null, null);            
            //Заносим данные
            MyLocalCluster = MyCluster;
            
            //Заносим данные на экранную форму.
            this.checkedListBox1.Items.Clear();
            int i=0;
            foreach (Group MyGroup in MyLocalCluster.CGroupList)
            {
                this.checkedListBox1.Items.Add(MyGroup.Name);
                checkedListBox1.SetItemChecked(i, true);
                i++;
            }
            ///this.checkedListBox1.CheckedItems.a
        }

        private void FormCHInf_SizeChanged(object sender, EventArgs e)
        {
            MyFormSupport.SizeChanged(this, this.menuStrip1, this.groupBox1, this.checkedListBox1, new System.Windows.Forms.Control(), new System.Windows.Forms.Control());
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

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //перебераем все элементы checkedListBox1
            for (int i = 0; i < this.checkedListBox1.Items.Count;i++ )            
                //перебераем все выделенные элементы checkedListBox1
                for (int j = 0; j < this.checkedListBox1.CheckedItems.Count; j++)            
                    if (this.checkedListBox1.Items[i] == this.checkedListBox1.CheckedItems[j]) 
                        this.MyLocalCluster.CGroupList[i].Name = "Checked";                        

            //Теперь попытаемся удалить лишнее
            foreach(Cluster MySuperLocalCluster in this.MyLocalCluster.SCluster)
            {
                // Сколько всего удалено
                int k = 0;
                for (int i = 0; i < this.MyLocalCluster.CGroupList.Count;i++ )
                {
                    if (this.MyLocalCluster.CGroupList[i].Name != "Checked") 
                    {
                        MySuperLocalCluster.CGroupList.RemoveAt(i - k);
                        k++;
                    }
                }
            }            
            this.DialogResult = DialogResult.OK;
        }

        private void FormCHInf_Load(object sender, EventArgs e)
        {

        }
   
    }
}
