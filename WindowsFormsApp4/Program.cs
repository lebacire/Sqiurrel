using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<AppLogger> logger = new List<AppLogger>();

            logger = SqliteDBLocal.LoadAppLogs();

            AppLogger log = new AppLogger();
            log.module = "Main";
            log.message = "Testing Dapper";
            log.function = "Insert Log";
            log.type = 1;
            log.date_created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            SqliteDBLocal.InsertLogs(log);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


    }
}
