using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Component.UltimateChoicer
{ 
    public partial class Choice_WinForm : Form, IChoicer
    {
        public IList<IUltimateChoice> p_IListIUC { get; set; }
        public string p_Title { get; set; }
        public IObjectReader p_IObjectReader { get; set; }
        public bool p_PostRepeaterMode { get; set; }
        public IProgressTime p_IProgressTime { get; set; }
        public IUltimateChoice p_Resalt_UltimateChoice { get; set; }
        public object p_Resalt_object { get; set; }
        //////////////////////////////////////////////////////////
        public IChoicer Init()
        {
            this.p_IListIUC = new List<IUltimateChoice>();
            this.p_Title = "Choicer";
            this.p_IObjectReader = new ObjectReader_WinForm();
            this.p_PostRepeaterMode = true;
            this.p_IProgressTime = new ProgressTime();
            this.p_Resalt_UltimateChoice = new UltimateChoice();
            this.p_Resalt_object = new object();
            return this;
        }
        public Choice_WinForm()
        {
            this.Init();
            #region WinForm
            InitializeComponent();
            this.listBox1.Left = 5;
            this.listBox1.Top = 5;
            this.button1.Left = 5;
            this.button1.Top = 5;
            #region ширина и высота
            int _LastFormHeight = this.Height;
            int _LastFormWidth = this.Width;
            Action<object, EventArgs> qwe = (object sender, EventArgs e) =>
            {
                int thisMinWidth = 75; int thisMinHeight = 75;
                if ((this.Width < thisMinWidth) || (this.Height < thisMinHeight))
                    this.Size = new System.Drawing.Size(thisMinWidth, thisMinHeight);

                this.listBox1.Size = new System.Drawing.Size(this.Width - 30, this.Height - 74);
                this.button1.Top = this.Height - 74;
            };
            this.SizeChanged += new System.EventHandler(qwe);
            qwe(null, null);
            #endregion
            #endregion
        }
        //////////////////////////////////////////////////////////
        public IChoicer Set(Action<IChoicer> x) { x(this); return this; }
        public IChoicer Set_p_IListIUC(IList<IUltimateChoice> _p_IListIUC) { this.p_IListIUC = _p_IListIUC; return this; }
        public IChoicer Set_p_Title(string _p_Title) { this.p_Title = _p_Title; return this; }
        public IChoicer Set_p_IObjectReader(IObjectReader _p_IObjectReader) { this.p_IObjectReader = _p_IObjectReader; return this; }
        public IChoicer Set_p_PostRepeaterMode(bool _p_PostRepeaterMode) { this.p_PostRepeaterMode = _p_PostRepeaterMode; return this; }
        public IChoicer Set_p_IProgressTime(IProgressTime _p_IProgressTime) { this.p_IProgressTime = _p_IProgressTime; return this; }
        //////////////////////////////////////////////////////////
        public IChoicer Do()
        {
            
            this.p_IProgressTime.Set_Start();
            this.Text = this.p_Title;
            do
            {
                int _p_IdChoice = -1;
                this.Updater();
                IList<IUltimateChoice> _p_IListIUC = this.p_IListIUC.Get_InterfaceCopy();
                for (int i = _p_IListIUC.Count - 1; i > -1; i--)
                    if (!_p_IListIUC[i].p_Usable) _p_IListIUC.RemoveAt(i);              

                {
                    this.listBox1.Items.Clear();            
                    foreach (IUltimateChoice _IUltimateChoiceT in _p_IListIUC)
                        {this.listBox1.Items.Add(_IUltimateChoiceT.p_ChoiceName);this.listBox1.SelectedIndex = 0;}
                    while (this.ShowDialog() != System.Windows.Forms.DialogResult.OK) ;
                    _p_IdChoice = this.listBox1.SelectedIndex;
                }

                if ((_p_IdChoice >= _p_IListIUC.Count) || (_p_IdChoice <= -1))
                    {//Проверка на выбранность индекса и генерацция исключения если что
                        (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed)).WriteLine((new Component.StackTracer()).Get_STSS());
                        throw new ArgumentException("Eror-" + (new StackTracer()).Get_STSS() + "\nЩас индека за пределами будет", (new StackTracer()).Get_STSS());
                    }
                this.p_Resalt_UltimateChoice = _p_IListIUC[_p_IdChoice].Get_InterfaceCopy();
                this.p_Resalt_UltimateChoice.Do().Get_Resalt();
                this.Updater();                
            }while(this.p_Resalt_UltimateChoice.p_PostRepeater && this.p_PostRepeaterMode);
            this.p_IProgressTime.Set_Stop();
            return this;
        }
        public IChoicer Updater()
        {
            foreach (IUltimateChoice _IUltimateChoice in this.p_IListIUC)
            {
                _IUltimateChoice.p_Updater(_IUltimateChoice);//Обновление всех пунктов меню
                _IUltimateChoice.p_ObjectSender = this.Set((IChoicer _this) => { ; });
            }
            return this;
        }
        //////////////////////////////////////////////////////////////////////////////
        public object Get_Resalt()
        {
            if (!this.p_IProgressTime.p_CalcIsLocked) this.Do();
            return this.p_Resalt_object;
        }
        public IChoicer Get_InterfaseCopy()
        {
            return ((IChoicer)Activator.CreateInstance(this.GetType()))
                .Set_p_IProgressTime(this.p_IProgressTime.Get_InterfaceCopy())
                .Set_p_IObjectReader(this.p_IObjectReader.Get_InterfaceCopy())
                .Set_p_PostRepeaterMode(this.p_PostRepeaterMode)
                .Set_p_Title(this.p_Title)
                .Set_p_IListIUC(this.p_IListIUC.Get_InterfaceCopy())
                .Set((IChoicer _this) =>
                {
                    _this.p_Resalt_UltimateChoice = this.p_Resalt_UltimateChoice.Get_InterfaceCopy();
                })
                ;
        }
        public IChoicer Get_InterfaseNewCreateInstance() { return ((IChoicer)Activator.CreateInstance(this.GetType())); }
        //////////////////////////////////////////////////////////////////////////////
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e){}
        private void IChoice_WinForm_Load(object sender, EventArgs e){}
        //////////////////////////////////////////////////////////
        public static void Test()
        {
            (new Component.Consoller_Shabloner(ConsoleColor.Cyan, ConsoleColor.DarkRed))
                .WriteLine((new Component.StackTracer()).Get_STSS());
            string _str = "";
            (new Choice_WinForm())
                .Set_p_Title("Тестовый выбор между да, нет и сомневаюсь")
                .Set_p_IListIUC((new IUltimateChoice[] {
                    (new UltimateChoice()).Set_p_ChoiceName("нет").Set_p_Action((IUltimateChoice _this)=>{_str ="нет"; Console.WriteLine("_str ="+_str);})
                    ,(new UltimateChoice()).Set_p_ChoiceName("сомневаюсь").Set_p_Action((IUltimateChoice _this)=>{_str ="сомневаюсь";Console.WriteLine("_str ="+_str);})
                    ,(new UltimateChoice()).Set_p_ChoiceName("да").Set_p_Action((IUltimateChoice _this)=>{_str ="да";Console.WriteLine("_str ="+_str);})
                    ,(new UltimateChoice()).Set_p_ChoiceName("Пора завязывать с меню").Set_p_Action((IUltimateChoice _this)=>{_str ="Пора завязывать с меню";Console.WriteLine("_str ="+_str);}).Set_p_PostRepeater(false)
                }).ToList<IUltimateChoice>())
            .Do().Get_Resalt()
                
            ;
            Console.WriteLine(_str);
        }
        //////////////////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}