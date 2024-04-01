using Newtonsoft.Json.Linq;
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
using static System.Net.Mime.MediaTypeNames;

namespace QuizApp.View
{
    public partial class QuestionForm : Form, IQuestionView
    {
        private static QuestionForm instance;

        private IAnswerView[] _answers;

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

        public IView ParentView { get; set; }
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
            set => numberLabel.Text = "Вопрос №" + value;
        }
        public string Description 
        {
            get => throw new NotImplementedException();
            set => descriptionTextBox.Text = value;
        }

        public IAnswerView[] Answers { 
            get => _answers;
        }

        public event EventHandler LoadQuiz;
        public event EventHandler FinishQuiz;
        public event EventHandler PrevQuestion;
        public event EventHandler NextQuestion;
        public event EventHandler<Guid> SelectAnswer;

        public QuestionForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

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
        public void SetDisplayTimer(int time, bool reverse = false)
        {
            timerLabel.Text = (!reverse) ?
                "Прошло: " + TimeSpan.FromSeconds(time).ToString("hh\\:mm\\:ss") :
                "Осталось: " + TimeSpan.FromSeconds(time).ToString("hh\\:mm\\:ss");
        }

        public void CreateAnswerRadioButtons(IAnswerView[] answersView)
        {
            _answers = answersView;

            answersPanel.SuspendLayout();
            answersPanel.Controls.Clear();
            foreach (IAnswerView answer in answersView)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Tag = answer;
                radioButton.Text = answer.Content;
                radioButton.Checked = answer.Checked;
                radioButton.CheckedChanged += RadioButton_CheckedChanged;
                radioButton.Dock = DockStyle.Top;
                answersPanel.Controls.Add(radioButton);
            }
            answersPanel.ResumeLayout();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            IAnswerView answerView = (IAnswerView)radioButton.Tag;
            answerView.Checked = radioButton.Checked;
        }
    }
}
