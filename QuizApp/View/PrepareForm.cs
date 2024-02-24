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
        public IMainView ParentView { get; set; }
        public string Guid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => titleLabel.Text; set => titleLabel.Text = value; }
        public string Description { get => descriptionTextBox.Text; set => descriptionTextBox.Text = value; }
        public string Author { get => authorLabel.Text; set => authorLabel.Text = value; }
        public string MaxQuestions { get => countLabel.Text; set => countLabel.Text = value; }

        private static PrepareForm instance;

        public PrepareForm()
        {
            InitializeComponent();
            InitializeEvents();
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
                instance.FormBorderStyle = FormBorderStyle.None;
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
