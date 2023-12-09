using QuizApp.Presenter;
using QuizApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMainView mainView = new MainForm();
            IMainPresenter mainPresenter = new MainPresenter(mainView);
            ApplicationContext context = new ApplicationContext();
            context.MainForm = (MainForm)mainView;
            Application.Run(context);
        }
    }
}
