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
        public event EventHandler BackQuestion;
        public event EventHandler NextQuestion;

        public string QuizGuid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string QuizTitle 
        { 
            get => titleQuizLabel.Text;
            set => titleQuizLabel.Text = value; 
        }
        public string QuizDescription
        {
            get => descrQuizLabel.Text;
            set => descrQuizLabel.Text = value;
        }
        public string QuizAuthor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string QuestionDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MainForm()
        {
            InitializeComponent();
            MainTabControl.TabPages.Clear();
            InitializeEvent();
        }
        public void InitializeEvent()
        {
            Load += delegate { PrepareQuiz?.Invoke(this, EventArgs.Empty); };
            startQuizButton.Click += delegate { StartQuiz?.Invoke(this, EventArgs.Empty); };
            finishQuizButton.Click += delegate { FinishQuiz?.Invoke(this, EventArgs.Empty); };
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
    }
}
