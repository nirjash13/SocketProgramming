using System;
using System.Windows.Forms;

namespace ExamServer
{
    using Common;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //TO insert questions into db on start up
            StudentManager.SaveQuestionsIntoDatabaseFromFile();

            Application.Run(new ServerInterface());
        }
    }
}
