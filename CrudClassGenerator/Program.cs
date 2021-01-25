using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace CrudClassGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //To catch exceptions in Main thread
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //To catch exceptions in other threads
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        static void HandleException(Exception pEx)
        {
            string errMsg = string.Format("{0}\r\n\r\n{1}", pEx.Message, pEx.InnerException);

            System.Diagnostics.EventLog.WriteEntry("Application", errMsg, EventLogEntryType.Error, 1111);
            MessageBox.Show(errMsg, pEx.TargetSite.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
