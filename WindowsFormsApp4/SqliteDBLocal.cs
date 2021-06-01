using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class SqliteDBLocal
    {
        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public static List<AppLogger> LoadAppLogs()
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                var output = con.Query<AppLogger>("select * from app_logger", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void InsertLogs(AppLogger log)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Execute("INSERT INTO app_logger(module, function, type, message, date_created) VALUES(@module, @function, @type, @message, @date_created)", log);
            }
        }

    }

    public class AppLogger
    {
        public string module { get; set; }
        public string function { get; set; }
        public int type { get; set; }
        public string message { get; set; }
        public string date_created { get; set; }
    }
}
