using Newtonsoft.Json.Linq;
using QuizApp.Model.Data.Entity;
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

        private string _answerText = string.Empty;
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
                    nextButton.BackColor = Color.FromArgb(215, 223, 255);
                    nextButton.FlatAppearance.BorderColor = Color.FromArgb(119, 127, 159);
                    nextButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(167, 175, 207);
                    nextButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(191, 199, 231);
                    nextButton.ForeColor = Color.Black;
                    nextButton.Text = "Следующий вопрос";
                }
                else
                {
                    nextButton.BackColor = Color.FromArgb(255, 223, 223);
                    nextButton.FlatAppearance.BorderColor = Color.FromArgb(159, 127, 127);
                    nextButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(207, 175, 175);
                    nextButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(231, 199, 199);
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

        public string AnswerText
        {
            get => _answerText;
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

            answersLabel.Text = "Выберите один вариант ответа:";
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

        public void CreateAnswerCheckBoxes(IAnswerView[] answersView)
        {
            _answers = answersView;

            answersLabel.Text = "Выберите несколько вариантов ответа:";
            answersPanel.SuspendLayout();
            answersPanel.Controls.Clear();
            foreach (IAnswerView answer in answersView)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Tag = answer;
                checkBox.Text = answer.Content;
                checkBox.Checked = answer.Checked;
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                checkBox.Dock = DockStyle.Top;
                answersPanel.Controls.Add(checkBox);
            }
            answersPanel.ResumeLayout();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            IAnswerView answerView = (IAnswerView)checkBox.Tag;
            answerView.Checked = checkBox.Checked;
        }
        public void CreateAnswerTextBox(string answerText)
        {
            answersLabel.Text = "Напишите ответ:";
            _answerText = answerText;
            answersPanel.SuspendLayout();
            answersPanel.Controls.Clear();

            TextBox textBox = new TextBox();
            textBox.Text = answerText;
            textBox.TextChanged += TextBox_TextChanged; ;
            textBox.Dock = DockStyle.Top;
            answersPanel.Controls.Add(textBox);

            answersPanel.ResumeLayout();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            _answerText = textBox.Text;
        }
    }
}
