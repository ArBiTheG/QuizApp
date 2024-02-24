using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp.View
{
    public partial class ResultForm : Form, IResultView
    {
        public IMainView ParentView { get; set; }
        public string Guid
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public string Title 
        { 
            get => throw new NotImplementedException(); 
            set => quizTitleTextBox.Text = value; 
        }
        public string Description
        {
            get => throw new NotImplementedException();
            set => quizDescrTextBox.Text = value;
        }
        public string Message
        {
            get => throw new NotImplementedException();
            set => messageTextBox.Text = value;
        }
        public string Author
        {
            get => throw new NotImplementedException();
            set => authorTextBox.Text = value;
        }
        public string Grade
        {
            get => throw new NotImplementedException();
            set => gradeTextBox.Text = value;
        }
        public string GradeDescr
        {
            get => throw new NotImplementedException();
            set => gradeDescrTextBox.Text = value;
        }
        public string MaxScore
        {
            get => throw new NotImplementedException();
            set => maxScoreTextBox.Text = value;
        }
        public string Score
        {
            get => throw new NotImplementedException();
            set => scoreTextBox.Text = value;
        }
        public string MaxQuestions
        {
            get => throw new NotImplementedException();
            set => maxQuestionsTextBox.Text = value;
        }
        public string RightQuestions
        {
            get => throw new NotImplementedException();
            set => rightQuestionsTextBox.Text = value;
        }
        public string TimeStarted
        {
            get => throw new NotImplementedException();
            set => timeStartedTextBox.Text = value;
        }
        public string TimeFinihed
        {
            get => throw new NotImplementedException();
            set => timeFinishedTextBox.Text = value;
        }
        public string TimePassed
        {
            get => throw new NotImplementedException();
            set => timePassedTextBox.Text = value;
        }

        private static ResultForm instance;

        public event EventHandler LoadResult;

        public ResultForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            Load += delegate { LoadResult?.Invoke(this, EventArgs.Empty); };
        }

        public static ResultForm GetInstance(MainForm parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ResultForm();
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
