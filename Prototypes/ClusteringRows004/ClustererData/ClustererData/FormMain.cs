using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClustererData
{
    public partial class FormMain : Form
    {
        public Cluster GlobalCluster = new Cluster();

        public FormMain()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
            FormSupport.SizeChanged.MasterSlave2(this,this.menuStrip1, this.dataGridView1, 5,5);             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1_SizeChanged(null, null);
            
        }

        private void импортДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        //FormMatrixValuesImport
            FormMatrixValuesImport MyForm1 = new FormMatrixValuesImport();
            //this     
            MyForm1.Owner = this;
            MyForm1.ShowDialog();
            if (MyForm1.DialogResult == DialogResult.OK)
            {
                GlobalCluster.SetClusterDataTable(MyForm1.textBox1.Text);
                this.dataGridView1.DataSource=GlobalCluster.ClusterDataTable;
            }
            this.Text = Convert.ToString(GlobalCluster.count);
        }


    }
}
