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
        public IPrepareView PrepareView { get; set; }
        public string AppStatus { get => toolStripStatusLabel.Text; set => toolStripStatusLabel.Text = value; }

        public MainForm()
        {
            InitializeComponent();
            InitializeEvents();
        }
        public event EventHandler AppLoad;

        private void InitializeEvents()
        {
            Load += delegate { AppLoad?.Invoke(this, EventArgs.Empty); };
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox())
            {
                aboutBox.ShowDialog();
            }
        }
    }
}
