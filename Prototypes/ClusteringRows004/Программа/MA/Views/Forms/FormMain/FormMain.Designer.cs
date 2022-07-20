namespace MA
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.импортМатрицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клонироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кластеризацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fCMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.центройдныйМетодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.инструментыToolStripMenuItem,
            this.кластеризацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15, 6, 0, 6);
            this.menuStrip1.Size = new System.Drawing.Size(1167, 31);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 19);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.ToolTipText = "Этот элемент меню позволяет загрузить данные из уже существующего файла.";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.ToolTipText = "Этот элемент меню позволяет сохранить данные в файл, при необхдимости - в новый.";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // инструментыToolStripMenuItem
            // 
            this.инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox2,
            this.toolStripSeparator1,
            this.импортМатрицыToolStripMenuItem,
            this.клонироватьToolStripMenuItem});
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(95, 19);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Items.AddRange(new object[] {
            "Дерево",
            "Меню свойств",
            "Таблица"});
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox2.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox2_SelectedIndexChanged);
            this.toolStripComboBox2.Click += new System.EventHandler(this.toolStripComboBox2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // импортМатрицыToolStripMenuItem
            // 
            this.импортМатрицыToolStripMenuItem.Name = "импортМатрицыToolStripMenuItem";
            this.импортМатрицыToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.импортМатрицыToolStripMenuItem.Text = "Импорт матрицы значений";
            this.импортМатрицыToolStripMenuItem.Click += new System.EventHandler(this.импортМатрицыToolStripMenuItem_Click);
            // 
            // клонироватьToolStripMenuItem
            // 
            this.клонироватьToolStripMenuItem.Name = "клонироватьToolStripMenuItem";
            this.клонироватьToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.клонироватьToolStripMenuItem.Text = "Клонировать";
            this.клонироватьToolStripMenuItem.Click += new System.EventHandler(this.клонироватьToolStripMenuItem_Click);
            // 
            // кластеризацияToolStripMenuItem
            // 
            this.кластеризацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fCMToolStripMenuItem,
            this.центройдныйМетодToolStripMenuItem});
            this.кластеризацияToolStripMenuItem.Name = "кластеризацияToolStripMenuItem";
            this.кластеризацияToolStripMenuItem.Size = new System.Drawing.Size(101, 19);
            this.кластеризацияToolStripMenuItem.Text = "Кластеризация";
            // 
            // fCMToolStripMenuItem
            // 
            this.fCMToolStripMenuItem.Name = "fCMToolStripMenuItem";
            this.fCMToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.fCMToolStripMenuItem.Text = "FCM";
            this.fCMToolStripMenuItem.Click += new System.EventHandler(this.fCMToolStripMenuItem_Click);
            // 
            // центройдныйМетодToolStripMenuItem
            // 
            this.центройдныйМетодToolStripMenuItem.Name = "центройдныйМетодToolStripMenuItem";
            this.центройдныйМетодToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.центройдныйМетодToolStripMenuItem.Text = "Центройдный метод";
            this.центройдныйМетодToolStripMenuItem.Click += new System.EventHandler(this.центройдныйМетодToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.propertyGrid1);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(24, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox1.Size = new System.Drawing.Size(282, 137);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(176, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(85, 96);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(96, 26);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(74, 96);
            this.propertyGrid1.TabIndex = 1;
            this.propertyGrid1.Visible = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(14, 26);
            this.treeView1.Margin = new System.Windows.Forms.Padding(7);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(72, 96);
            this.treeView1.TabIndex = 0;
            this.treeView1.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 417);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_ClientSizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem клонироватьToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem кластеризацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fCMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem центройдныйМетодToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem импортМатрицыToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

