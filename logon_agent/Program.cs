using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;

namespace logon_agent
{

    class Program
    {
        public static string username, computername, sqlstring;
        public static byte first;

        public static void log_write(string message, EventLogEntryType type)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {

                if (type == EventLogEntryType.Error)
                {
                    eventLog.Source = "Application Error";
                    eventLog.WriteEntry(message, type, 1000, 1);
                }
                else
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(message, type, 100, 1);
                }
            }
        }
       
static void Main(string[] args)
        {            
            sqlstring = GetSqlString();
            if ((args.Length>0)&&(args[0].Equals("/setup")))
            {

                log_write("Программа logon_agent запущена в режиме настройки", EventLogEntryType.Warning);
                Application.Run(new Setup());

            }
            else
                {
                try
                {
                    log_write("Программа logon_agent запущена", EventLogEntryType.Information);
                    string type = "logon";
                    System.Threading.Thread.Sleep(10000);
                    username = Environment.UserName;
                    computername = Environment.MachineName;
                    first = 1;                 
                    string sql = "exec insert_into_dbuserlogin @username='" + username + "', ";
                    sql += "@computername ='" + computername + "', @type='" + type + "', @is_rdp=" + rdp_check() + ", @first="+first+";";
                    sql_execute(sql);                    
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    timer timer = new timer();
                    timer.Visible = false;
                    Application.Run(timer);                    
                }
                catch (Exception ex)
                {
                    log_write("В программе logon_agent произошла ошибка \n"+ex.ToString()+"", EventLogEntryType.Error);
                }
            }
        }


        public static void sql_execute(string sql)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(sqlstring);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                log_write("В программе logon_agent произошла ошибка \n" + ex.ToString() + "", EventLogEntryType.Error);
            }
        }
        public static byte rdp_check()
        {
            if (SystemInformation.TerminalServerSession)
                return 1;
            return 0;
        }

        static public String GetSqlString()
        {
            try
            {
                string sqlstring=logon_class.get_settings.GetSqlString();
                return sqlstring;
            }
            catch (Exception ex)
            {
                log_write("В программе logon_agent произошла ошибка \n" + ex.ToString() + "", EventLogEntryType.Error);
                Application.Exit();
                return "";
            }
        }
    }
}
