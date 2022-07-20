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

namespace MA
{
    public partial class FormMatrixValuesImport : Form
    {
        //Убрал. Будут проблемы вернуть....
        //public Boolean Flag=true;
        /// <summary>
        /// Поддержка изменения размеров формы
        /// </summary>
        public FormSupport MyFormSupport = new FormSupport();

        public FormMatrixValuesImport()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form2_SizeChanged(null, null);
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            MyFormSupport.SizeChanged(this, this.menuStrip1, this.groupBox1, this.textBox1, new System.Windows.Forms.Control(), new System.Windows.Forms.Control());
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Flag = false;
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
