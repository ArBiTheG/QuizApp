using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuizApp.View
{
    public partial class PrepareForm : Form, IPrepareView
    {
        public IView ParentView { get; set; }
        public string Guid {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public string Title 
        { 
            get => throw new NotImplementedException(); 
            set => titleLabel.Text = value; 
        }
        public string Description 
        { 
            get => throw new NotImplementedException(); 
            set => descriptionTextBox.Text = value; 
        }
        public string Author 
        { 
            get => throw new NotImplementedException(); 
            set => authorLabel.Text = "Автор: " + value; 
        }
        public string MaxQuestions 
        { 
            get => throw new NotImplementedException(); 
            set => countLabel.Text = "Всего вопросов: " + value;
        }
        public string Timer
        {
            get => throw new NotImplementedException();
            set => timerLabel.Text = "Ограничение по времени: " + value;
        }

        private static PrepareForm instance;

        public PrepareForm()
        {
            InitializeComponent();
            InitializeEvents();
        }
        // Решение проблемы с морганием MDI Формы
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;

            }
        }

        public event EventHandler PrepareQuiz;
        public event EventHandler StartQuiz;

        private void InitializeEvents()
        {
            Load += delegate { PrepareQuiz?.Invoke(this, EventArgs.Empty); };
            startButton.Click += delegate { StartQuiz?.Invoke(this, EventArgs.Empty); };
        }

        public static PrepareForm GetInstance(MainForm parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PrepareForm();
                instance.ParentView = parentContainer;
                instance.MdiParent = parentContainer;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
    }
}
