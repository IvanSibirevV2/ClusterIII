using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextParser
{
    public partial class Form1 : Form
    {
        public int i=-1;
        List<string> ListString = new List<string>();

        public System.Windows.Forms.ListControl ListControl1;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Form1_SizeChanged(null, null);
            this.Top = 0;
            this.Left = 0;

            
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ListString.Clear();            
            //Чтение из файла в массив и присвоение постеднего в listBox1
            ListString.AddRange(System.IO.File.ReadAllLines(FileDialog.LoadString("TXT")));
            listBox1.Items.AddRange(ListString.ToArray());
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FileDialog.LoadString("TXT");

        }

        /// <summary>
        /// Изменение размеров формы.
        /// </summary>        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave2(this, this.menuStrip1, this.tabControl1,1,1);
        }       

        /// <summary>
        /// Изменение размеров вкладки2
        /// </summary>        
        private void tabPage2_SizeChanged(object sender, EventArgs e)
        {
            //FormSupport.SizeChanged.MasterSlave1(this.tabPage2, this.listView1, 1, 1);
        }

        /// <summary>
        /// Изменение размеров вкладки1
        /// </summary>        
        private void tabPage1_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave1(this.tabPage1, this.listBox1, 1, 1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listView1.Items.Clear();
            //Image
            //listView1.Items.Add("2", "1", 1);
            
             
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            this.Text = Convert.ToString(i+1);            
            this.textBox1.Text = this.ListString[i].Split(';')[0];
            this.textBox2.Text = this.ListString[i].Split(';')[1]; ;
            this.textBox3.Text = this.ListString[i].Split(';')[2]; ;
            this.textBox4.Text = Convert.ToString(this.ListString[i].Split(';').Count() - 3);
            //listBox1.Items[i]="0";
            

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i=0;
            this.Text = Convert.ToString(i + 1);
            this.textBox1.Text =  this.ListString[i].Split(';')[0];
            this.textBox2.Text =  this.ListString[i].Split(';')[1]; ;
            this.textBox3.Text =  this.ListString[i].Split(';')[2]; ;
            this.textBox4.Text =  Convert.ToString(this.ListString[i].Split(';').Count() - 3);
        }
        
    }
}
