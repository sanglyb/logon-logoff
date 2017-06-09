using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logon_class
{
    public class get_settings
    {
        public static string get_idle_time()
        {
            string idle_time = "";
            try
            {
                string sql = "exec get_idle_time_for_app;";

                SqlDataReader slq_idle_time = sqlcommand(sql);
                while (slq_idle_time.Read())
                {
                    idle_time = slq_idle_time[0].ToString();
                }
                return idle_time;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return "0:05:00";
            }

        }
        public static SqlDataReader sqlcommand(string sql)
        {
            SqlConnection conn = new SqlConnection(GetSqlString());
            conn.Open();
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataReader command;
            return command = sc.ExecuteReader();
        }
        static public String GetSqlString()
        {
            SimpleEncryption decrypt = new SimpleEncryption("password");
            if (logon_class.Properties.Settings.Default.encrypted.Equals("1"))
            {
                string connection = decrypt.Decrypt(logon_class.Properties.Settings.Default.db) + decrypt.Decrypt(logon_class.Properties.Settings.Default.catalog) + decrypt.Decrypt(logon_class.Properties.Settings.Default.security) + decrypt.Decrypt(logon_class.Properties.Settings.Default.user) + decrypt.Decrypt(logon_class.Properties.Settings.Default.password);
                return connection;
            }
            else
            {
                string connection = logon_class.Properties.Settings.Default.db + logon_class.Properties.Settings.Default.catalog + logon_class.Properties.Settings.Default.security + logon_class.Properties.Settings.Default.user + logon_class.Properties.Settings.Default.password;
                return connection;
            }
        }
        public static void sql_execute(string sql)
        {           
                SqlConnection myConnection = new SqlConnection(GetSqlString());
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();            
        }
    }
}
