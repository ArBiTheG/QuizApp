using QuizApp.View.Entity;
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
    public partial class QuestionForm : Form, IQuestionView
    {
        public IMainView ParentView { get; set; }
        public bool CanPrevQuestion 
        {
            get => throw new NotImplementedException();
            set => prevButton.Visible = value;
        }
        public bool CanNextQuestion 
        {
            get => throw new NotImplementedException();
            set
            {
                if (value)
                {
                    nextButton.ForeColor = Color.Black;
                    nextButton.Text = "Следующий вопрос";
                }
                else
                {
                    nextButton.ForeColor = Color.Maroon;
                    nextButton.Text = "Завершить тестирование";
                }
            }
        }
        public int CurrentQuestion 
        { 
            get => throw new NotImplementedException();
            set => numberLabel.Text = "Вопрос №" + (value+1);
        }
        public string Description 
        {
            get => throw new NotImplementedException();
            set => descriptionTextBox.Text = value;
        }
        public string Timer { 
            get => throw new NotImplementedException();
            set => timerLabel.Text = value;
        }

        private static QuestionForm instance;

        public QuestionForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public event EventHandler LoadQuiz;
        public event EventHandler FinishQuiz;
        public event EventHandler PrevQuestion;
        public event EventHandler NextQuestion;
        public event EventHandler<Guid> SelectAnswer;

        private void InitializeEvents()
        {
            Load += delegate { LoadQuiz?.Invoke(this, EventArgs.Empty); };
            finishButton.Click += delegate { FinishQuiz?.Invoke(this, EventArgs.Empty); };
            nextButton.Click += delegate { NextQuestion?.Invoke(this, EventArgs.Empty); };
            prevButton.Click += delegate { PrevQuestion?.Invoke(this, EventArgs.Empty); };
        }

        public static QuestionForm GetInstance(MainForm parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new QuestionForm();
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

        public void AddAnswers(IAnswerView[] answersView)
        {
            answersPanel.SuspendLayout();
            answersPanel.Controls.Clear();
            foreach (IAnswerView answer in answersView)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Text = answer.Content;
                radioButton.Checked = answer.Checked;
                radioButton.CheckedChanged += delegate { if (radioButton.Checked) SelectAnswer?.Invoke(this, answer.Guid); };
                radioButton.Dock = DockStyle.Top;
                answersPanel.Controls.Add(radioButton);
            }
            answersPanel.ResumeLayout();
        }
    }
}
