using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace logon_server_service
{
    public partial class logon_server_service : ServiceBase
    {
        string connection;
        int check_t;
        public logon_server_service()
        {
            InitializeComponent();
            string logName;
            if (EventLog.SourceExists("check_logon_service"))
            {
                logName = EventLog.LogNameFromSourceName("check_logon_service", ".");
                if (logName != "check_logon_service_app")
                {
                    EventLog.DeleteEventSource("check_logon_service");
                    EventLog.Delete(logName);
                }
            }
            if (!System.Diagnostics.EventLog.SourceExists("check_logon_service"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "check_logon_service", "check_logon_service_app");
            }
            eventLog1.Log = "check_logon_service_app";
            eventLog1.Source = "check_logon_service";


        }

        protected override void OnStart(string[] args)
        {
            try
            {
                get_settings();
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("В службе произошла критическая ошибка:\n" + ex.ToString(), EventLogEntryType.Error);
                this.Stop();
                return;
            }

            try
            {
                string sql = "print 1;";
                sql_execute(sql);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("В службе произошла критическая ошибка:\n" + ex.ToString(), EventLogEntryType.Error);
                this.Stop();
                return;
            }
            eventLog1.WriteEntry("service app started");
            Timer wait = new Timer(check_t);
            wait.Elapsed += new System.Timers.ElapsedEventHandler(wait_elapsed);
            wait.Start();

        }

        protected override void OnStop()
        {
            try
            {
                eventLog1.WriteEntry("service app stoped");
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("В службе произошла ошибка:\n" + ex.ToString(), EventLogEntryType.Error);
            }
        }

        public void wait_elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            write_to_sql();            
        }

        public void write_to_sql()
        {
            try
            {
                string sql = "";
                string[] computers = spisok_polzovateley();
                if (computers.Length > 0 && computers[0] != null)
                {
                    for (int i = 0; i < computers.Length; i++)
                    {
                        string[] splited = new string[2];
                        splited = computers[i].Split(';');
                        sql += "exec insert_into_dbuserlogin @username='" + splited[0] + "', ";
                        sql += "@computername ='" + splited[1] + "', @type='logoff', @is_rdp=0, @first=0; ";
                    }
                    sql_execute(sql);
                    eventLog1.WriteEntry("служба выполнила запрос:\n"+sql);
                }                
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("В службе произошла не критическая ошибка:\n" + ex.ToString(), EventLogEntryType.Warning);
            }


        }

        public void get_settings()
        {
            string check_time = "";
            SimpleEncryption decrypt = new SimpleEncryption("password");
            if (logon_class.Properties.Settings.Default.encrypted.Equals("1"))
            {
                connection = decrypt.Decrypt(logon_class.Properties.Settings.Default.db) + decrypt.Decrypt(logon_class.Properties.Settings.Default.catalog) + decrypt.Decrypt(logon_class.Properties.Settings.Default.security) + decrypt.Decrypt(logon_class.Properties.Settings.Default.user) + decrypt.Decrypt(logon_class.Properties.Settings.Default.password);
                check_time = decrypt.Decrypt(logon_class.Properties.Settings.Default.default_service_time);
                check_t = Convert.ToInt32(TimeSpan.Parse(check_time).TotalSeconds) * 1000;

            }
            else
            {
                connection = logon_class.Properties.Settings.Default.db + logon_class.Properties.Settings.Default.catalog + logon_class.Properties.Settings.Default.security + logon_class.Properties.Settings.Default.user + logon_class.Properties.Settings.Default.password;
                check_time = logon_class.Properties.Settings.Default.default_service_time;
                check_t = Convert.ToInt32(TimeSpan.Parse(check_time).TotalSeconds) * 1000;
            }
        }

        public string[] spisok_polzovateley()
        {
            string[] users = new string[1];
            try
            {
                string sql = "select * from DbUserLoginCheckLogin; ";
                SqlDataReader users_list = sqlcommand(sql);
                int i = 0;
                while (users_list.Read())
                {
                    bool not_available = ChekComp(users_list[1].ToString());
                    if (not_available)
                    {
                        Array.Resize(ref users, (i + 1));
                        users[i] = users_list[0].ToString() + ";" + users_list[1].ToString();
                        i++;
                    }
                }
                if (users.Length > 0 && users[0] != null)
                {
                    for (i = 0; i < 60; i++)
                    {
                        for (int k = 0; k < users.Length; k++)
                        {
                            string[] splited = new string[2];
                            splited = users[k].Split(';');
                            bool not_available = ChekComp(splited[1].ToString());
                            if (!not_available)
                            {
                                users = RemoveAt(users, k);
                            }
                        }
                        if (users.Length > 0)
                        {
                            System.Threading.Thread.Sleep(2000);
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("В службе произошла не критическая ошибка:\n" + ex.ToString(), EventLogEntryType.Warning);
                return null;
            }
        }

        public string[] RemoveAt(string[] source, int index)
        {
            string[] dest = new string[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }

        public bool ChekComp(string comp)
        {
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;

                PingReply reply = pingSender.Send(comp, timeout, buffer, options);


                if (reply.Status != IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
               // eventLog1.WriteEntry("В службе произошла не критическая ошибка:\n" + ex.ToString(), EventLogEntryType.Warning);
                return false;
            }
        }

        public SqlDataReader sqlcommand(string sql)
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataReader command;
            return command = sc.ExecuteReader();
        }

        public void sql_execute(string sql)
        {
            SqlConnection myConnection = new SqlConnection(connection);
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand(sql, myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

    }
}
