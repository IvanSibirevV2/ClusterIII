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
using Views;

namespace MA
{
    public partial class FormResult : Form
    {
        public FormSupport MyFormSupport = new FormSupport();
        public Cluster MySCluster = new Cluster();
        public Cluster MyEClusterr= new Cluster();

        //public ClusterView View = new ClusterView();    
        
        public void MySuperWriter()
        {
            BindingSource MyBindingSource = new BindingSource();
            MyBindingSource.DataSource = ViewConvert.ClusterToDataTableV1(this.MyEClusterr.Copy(), this.MySCluster.Copy());
            this.dataGridView1.DataSource = MyBindingSource;

            BindingSource MyBindingSource1 = new BindingSource();
            MyBindingSource1.DataSource = ViewConvert.ClusterToDataTableV2(this.MyEClusterr.Copy());
            this.dataGridView2.DataSource = MyBindingSource1;
            //ClusterToDataTableV2(Cluster MyCluster)
        }
        
        public FormResult()
        {
            InitializeComponent();
        }
        public FormResult(Cluster LocalSCluster, Cluster LocalECluster)
        {
            this.MyEClusterr = LocalECluster;
            this.MySCluster = LocalSCluster;
            InitializeComponent();            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Form1_SizeChanged(null,null);
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(ViewConvert.ClusterTreeNode(MyEClusterr));
            MySuperWriter();

        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.MyFormSupport.SizeChanged(this, new System.Windows.Forms.Control(), this.tabControl1, this.treeView1/*dataGridView1*/,new System.Windows.Forms.Control(),new System.Windows.Forms.Control());
            this.dataGridView1.Top = this.treeView1.Top;
            this.dataGridView1.Left = this.treeView1.Left;
            this.dataGridView1.Height = this.treeView1.Height;
            this.dataGridView1.Width = this.treeView1.Width;
            this.dataGridView2.Top = this.treeView1.Top;
            this.dataGridView2.Left = this.treeView1.Left;
            this.dataGridView2.Height = this.treeView1.Height;
            this.dataGridView2.Width = this.treeView1.Width;
        }

    }
}
