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

namespace QuizApp.View
{
    public partial class MainForm : Form, IMainView
    {
        public IView ParentView
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public IPrepareView PrepareView { get; set; }
        public string AppStatus {
            get => toolStripStatusLabel.Text;
            set => toolStripStatusLabel.Text = value;
        }

        public event EventHandler AppLoad;
        public event EventHandler AppExit;
        public event EventHandler AppAbout;

        public MainForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            Load += delegate { AppLoad?.Invoke(this, EventArgs.Empty); };
            quitToolStripMenuItem.Click += delegate { AppExit?.Invoke(this, EventArgs.Empty); };
            aboutToolStripMenuItem.Click += delegate { AppAbout?.Invoke(this, EventArgs.Empty); };
        }
    }
}
