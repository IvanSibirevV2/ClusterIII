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
    public partial class FormMatrixValuesImport : Form
    {
        public FormMatrixValuesImport()
        {
            InitializeComponent();
        }

        private void FormMatrixValuesImport_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave2(this, this.menuStrip1, this.textBox1, 10, 10);             

        }

        private void подтвердитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FormMatrixValuesImport_Load(object sender, EventArgs e)
        {
            FormMatrixValuesImport_SizeChanged(null, null);
        }
    }
}
