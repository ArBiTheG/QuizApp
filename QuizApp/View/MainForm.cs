using QuizApp.Model.Entity;
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
    public partial class MainForm : Form, IMainView
    {
        public event EventHandler PrepareQuiz;
        public event EventHandler StartQuiz;
        public event EventHandler FinishQuiz;
        public event EventHandler PrevQuestion;
        public event EventHandler NextQuestion;
        public event EventHandler<Guid> SelectAnswer;

        public MainForm()
        {
            InitializeComponent();

            MainTabControl.TabPages.Clear();
            prevQuestionButton.Visible = false;

            InitializeEvent();
        }


        public string QuizGuid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string QuizTitle
        {
            get => throw new NotImplementedException();
            set => titleQuizLabel.Text = value;
        }
        public string QuizDescription
        {
            get => throw new NotImplementedException();
            set => descrQuizLabel.Text = value;
        }
        public string QuizAuthor
        {
            get => throw new NotImplementedException();
            set
            {
                authorQuizLabel.Text = "Автор тестирования: " + value;
            }
        }
        public int QuizMaxQuestions 
        { 
            get => throw new NotImplementedException(); 
            set => maxQuestionsLabel.Text = "Всего вопросов: " + value; 
        }

        public bool CanPrevQuestion
        {
            get => throw new NotImplementedException();
            set => prevQuestionButton.Visible = value;
        }
        public bool CanNextQuestion
        {
            get => throw new NotImplementedException();
            set
            {
                if (value)
                {
                    nextQuestionButton.ForeColor = Color.Black;
                    nextQuestionButton.Text = "Следующий вопрос";
                }
                else
                {
                    nextQuestionButton.ForeColor = Color.Maroon;
                    nextQuestionButton.Text = "Завершить тестирование";
                }
            }
        }
        public int CurrentQuestion
        {
            get => throw new NotImplementedException();
            set => counterQuizLabel.Text = "Вопрос № " + value;
        }
        public string QuestionDescription
        {
            get => throw new NotImplementedException();
            set
            {
                descrQuestionLabel.Text = value;
            }
        }


        public void InitializeEvent()
        {
            Load += delegate { PrepareQuiz?.Invoke(this, EventArgs.Empty); };
            startQuizButton.Click += delegate { StartQuiz?.Invoke(this, EventArgs.Empty); };
            finishQuizButton.Click += delegate { FinishQuiz?.Invoke(this, EventArgs.Empty); };
            prevQuestionButton.Click += delegate { PrevQuestion?.Invoke(this, EventArgs.Empty); };
            nextQuestionButton.Click += delegate { NextQuestion?.Invoke(this, EventArgs.Empty); };
        }

        public void ChangePage(Page page)
        {
            MainTabControl.TabPages.Clear();
            switch (page)
            {
                case Page.Prepare:
                    MainTabControl.TabPages.Add(preparePage);
                    MainTabControl.SelectTab(preparePage);
                    break;
                case Page.Quiz:
                    MainTabControl.TabPages.Add(preparePage);
                    MainTabControl.TabPages.Add(quizPage);
                    MainTabControl.SelectTab(quizPage);
                    break;
                case Page.Result:
                    MainTabControl.TabPages.Add(resultPage);
                    MainTabControl.SelectTab(resultPage);
                    break;
            }
        }

        public void AddAnswers(IAnswerView[] answersView)
        {
            answerPanel.SuspendLayout();
            answerPanel.Controls.Clear();
            foreach (IAnswerView answer in answersView)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Text = answer.Content;
                radioButton.Checked = answer.Checked;
                radioButton.CheckedChanged += delegate { if (radioButton.Checked) SelectAnswer?.Invoke(this, answer.Guid); };
                radioButton.Dock = DockStyle.Top;
                answerPanel.Controls.Add(radioButton);
            }
            answerPanel.ResumeLayout();
        }
    }
}
