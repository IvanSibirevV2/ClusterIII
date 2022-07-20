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
using SavingLoadingNameSpace;
using Views;
using FCMNameSpace;
using CH;
namespace MA
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Переменная - флаг. Исправление данных в таблице
        /// </summary>
        public Boolean MySuperWriterFlag = true;

        /// <summary>
        /// Поддержка изменения размеров формы
        /// </summary>
        public FormSupport MyFormSupport = new FormSupport();

        //public ClusterView View = new ClusterView();        
        /// <summary>
        /// Поддержка охранения и загрузки данных
        /// </summary>
        public SLSerializableService SavingLoadingServise = new SLSerializableService();

        /// <summary>
        /// Ниши данные
        /// </summary>
        public Cluster MyCluster = new Cluster();

        /// <summary>
        /// Переменная пути к файлу
        /// </summary>
        public String FileName = "";
        /// <summary>
        /// незнаю зачем, но нужно.
        /// </summary>
        public TreeNode MyListTreeNode = new TreeNode();

        /// <summary>
        /// Подключение источника данных для таблици
        /// </summary>
        BindingSource MyBindingSource = new BindingSource();

        /// <summary>
        /// Этот метод наглядно раскрашивает нашу таблицу
        /// </summary>
        private void MyDataGridViewColor()
        {
            MySuperWriterFlag = false;   
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
            MySuperWriterFlag = true;
        }

        /// <summary>
        /// Метод перезаписи данных на форме
        /// </summary>
        private void MySuperWriter()
        {            
            MySuperWriterFlag = false;            

            MyBindingSource.DataSource = ViewConvert.ClusterToDataTableV0(this.MyCluster);
            this.MyDataGridViewColor();

            this.propertyGrid1.SelectedObject = MyCluster;
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(ViewConvert.ClusterTreeNode(MyCluster));
            MySuperWriterFlag = true;
        }

        /// <summary>
        /// Метод чтения данных с формы. В частности таблици.
        /// </summary>
        private void MySuperReader()
        {
            int i=0;
            foreach (DataGridViewRow MyDataGridViewRow in this.dataGridView1.Rows)
            {
                //this.MyCluster.SCluster[i].Name = Convert.ToString(this.dataGridView1.Rows[i].Cells[0].Value);
                if (Convert.ToString(this.dataGridView1.Rows[i].Cells[0].Value)!="")
                {
                    int j = 1;
                    foreach (Group MyGroup in this.MyCluster.SCluster[i].CGroupList)
                    {
                        foreach (Param MyParam in MyGroup.GParamList)
                        {
                            MyParam.P = Convert.ToDouble(MyDataGridViewRow.Cells[j].Value);
                            j++;
                        }
                    }
                    i++;
                }                
            }
        }

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public FormMain()
        {            
            InitializeComponent();
        }

        /// <summary>
        /// Метод загрузки формы
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;//Запрещаем добавлять строки
            this.dataGridView1.DataSource = MyBindingSource;
            //treeView1.Nodes.Add(MyClusterView.ClusterTreeNode(MyCluster));            
            this.toolStripComboBox2.SelectedIndex = 0;
            FormMain_ClientSizeChanged(null, null);
            this.MySuperWriter();
            this.dataGridView1.DefaultCellStyle.WrapMode =DataGridViewTriState.True;
        }

        /// <summary>
        /// Метод, курирующий геометрию формы
        /// </summary>        
        private void FormMain_ClientSizeChanged(object sender, EventArgs e)
        {
            MyFormSupport.SizeChanged(this, this.menuStrip1, this.groupBox1, this.treeView1, new System.Windows.Forms.Control(), new System.Windows.Forms.Control());
            this.propertyGrid1.Size= this.treeView1.Size;
            this.propertyGrid1.Top = this.treeView1.Top;
            this.propertyGrid1.Left = this.treeView1.Left;
            //dataGridView1_CellContentClick
            this.dataGridView1.Size = this.treeView1.Size;
            this.dataGridView1.Top = this.treeView1.Top;
            this.dataGridView1.Left = this.treeView1.Left;
        }

        /// <summary>
        /// Метод, привязанный к кнопке загрзки.
        /// </summary>
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML files|*.SOF";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            FileName = fileDialog.FileName;
            MyCluster = SavingLoadingServise.StreamLoader(fileDialog.FileName);
            
            //treeView1.Nodes.Clear();
            //ClusterСalсulations.ClusterCenterReloading(MyCluster);
            //treeView1.Nodes.Add(View.ClusterTreeNode(MyCluster));
            groupBox1.Text = FileName;
            //this.propertyGrid1.SelectedObject = MyCluster;

            MyCluster.Name = "Данные";
            this.MySuperWriter();            
        }

        /// <summary>
        /// Метод, привязанный к кнопке сохранить как.
        /// </summary>
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MySuperReader();
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "XML files|*.SOF";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            //SavingLoadingServise.SavingClusterToXml(MyCluster, fileDialog.FileName);
            //MyCluster.RecalculationClusterCenter();
            SavingLoadingServise.StreamSaver(this.MyCluster, fileDialog.FileName);
            //this.MySuperWriter();
            //treeView1.Nodes.Clear();
            //treeView1.Nodes.Add(View.ClusterTreeNode(MyCluster));
            /*filename = fileDialog.FileName;
            SaveProject();
             * */
            //dataGridView1.Columns.add
        }

        /// <summary>
        /// Метод, привязанный к кнопке загрзка меню.
        /// </summary>
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //MySuperReader();
            this.treeView1.Visible = false;
            this.propertyGrid1.Visible = false;
            this.dataGridView1.Visible = false;
            this.клонироватьToolStripMenuItem.Visible = false;
            this.импортМатрицыToolStripMenuItem.Visible = false;
            if (toolStripComboBox2.SelectedIndex == 0) 
            { 
                this.treeView1.Visible = true; 
                this.treeView1.Nodes.Clear(); 
                this.treeView1.Nodes.Add(ViewConvert.ClusterTreeNode(MyCluster));                
            }
            if (toolStripComboBox2.SelectedIndex == 1)
            { 
                this.propertyGrid1.Visible = true;
                this.клонироватьToolStripMenuItem.Visible = true;
            }
            if (toolStripComboBox2.SelectedIndex == 2)
            {
                this.dataGridView1.Visible = true;
                this.импортМатрицыToolStripMenuItem.Visible = true;
                //this.MyDataGridView1Write(this.MyCluster);
                
            }
            this.MySuperWriter();
        }
        
        /// <summary>
        /// Метод, привязанный к кнопке клонировать.
        /// </summary>
        private void клонироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MyCluster.FaceClone();
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add(ViewConvert.ClusterTreeNode(MyCluster));
            this.MySuperWriter();
        }        

        /// <summary>
        /// Метод, привязанный к кнопке запуска FCM.
        /// </summary>
        private void fCMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Вызаваем форму запроса параметров кластеризации
            NewFormCHInf MyCHForm = new NewFormCHInf(this.MyCluster.Copy());
            MyCHForm.Text = "FCM метод";
            MyCHForm.ShowDialog();
            if (MyCHForm.DialogResult == DialogResult.OK)
            {
                CHclass MyCH = new CHclass();
                //Форма результата
                //FormResult MyForm1 = new FormResult(MyCHForm.MyLocalCluster.Copy(), MyCH.WeighedGroups(MyCHForm.MyLocalCluster.Copy(), Convert.ToInt16(MyCHForm.toolStripTextBox1.Text)));
                FormFCM MyForm1 = new FormFCM(Convert.ToInt32(MyCHForm.toolStripTextBox1.Text), MyCH.WeighedGroups(MyCHForm.MyLocalCluster.Copy(), Convert.ToInt16(MyCHForm.toolStripTextBox1.Text)).Copy(), this.MyCluster.Copy());
                MyCHForm.Close();
                MyForm1.ShowDialog();
                //MyForm1.ShowDialog();
                
            }            
        }

        /// <summary>
        /// Метод, поддерживающий изменение данных.
        /// </summary>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (MySuperWriterFlag)
            this.MySuperReader();
            this.MyDataGridViewColor();
        }

        /// <summary>
        /// Метод, поддерживающий центройдный метод.
        /// </summary>
        private void центройдныйМетодToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            //Вызаваем форму запроса параметров кластеризации
            NewFormCHInf MyCHForm = new NewFormCHInf(this.MyCluster.Copy());
            MyCHForm.Text = "Центроидный метод";
            MyCHForm.ShowDialog();
            if (MyCHForm.DialogResult == DialogResult.OK)
            {
                CHclass MyCH = new CHclass();
                FormResult MyForm1 = new FormResult(MyCHForm.MyLocalCluster.Copy(), MyCH.WeighedGroups(MyCHForm.MyLocalCluster.Copy(), Convert.ToInt16(MyCHForm.toolStripTextBox1.Text)));
                MyCHForm.Close();
                MyForm1.ShowDialog();
            }            
        }

       

        private void импортМатрицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormMatrixValuesImport
            FormMatrixValuesImport MyForm1 = new FormMatrixValuesImport();
            //this     
            MyForm1.Owner = this;
            MyForm1.ShowDialog();
            if(MyForm1.DialogResult == DialogResult.OK)
            {
                MySuperWriterFlag = false;
                List<string> MyInf= new List<string>();
                MyInf.AddRange(MyForm1.textBox1.Text.Split('\n').ToList());
                //Проверяем кол-во предпияти
                if ((this.dataGridView1.Rows.Count == MyInf.Count-1) && (MyInf.Count >= 1))
                {
                    List<string> MyInInfTest = new List<string>();
                    MyInInfTest.AddRange(MyInf[0].Split('\t'));
                    //проверяем кол-во параметров
                    if (this.dataGridView1.Columns.Count-1 == MyInInfTest.Count)
                    {
                        //Перебираем предпиятия
                        for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
                        {
                            //Перебираем параметры
                            for (int j = 1; j < this.dataGridView1.Columns.Count; j++)
                            {
                                this.dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(0);                                
                                try
                                {
                                    this.dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(MyInf[i].Split('\t')[j - 1]);
                                }
                                catch
                                {
                                    this.dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(0);
                                }
                            }
                        }
                    }
                    else
                    {                        
                        MessageBox.Show("Несоответствие размеров (Параметры):" + Convert.ToString(this.dataGridView1.Columns.Count-1) + "!=" + Convert.ToString(MyInInfTest.Count), "Error!!!");
                    }
                }
                else 
                {
                    MessageBox.Show("Несоответствие размеров (Предприятий):" + Convert.ToString(this.dataGridView1.Rows.Count) + "!=" + Convert.ToString(MyInf.Count-1), "Error!!!");
                }
                //MyInf.AddRange(MyForm1.textBox1.);
                MyForm1.Close();
                MySuperWriterFlag = true;
                //dataGridView1_CellValueChanged(null, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.MyDataGridViewColor();
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
