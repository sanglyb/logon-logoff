using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;



namespace login_logoff
{
    
    static class Program
    {
        public static string sqlstring;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if ((args.Length > 0) && (args[0].Equals("/setup")))
            {                                
                Application.Run(new SettingsForm());
            }
            else
            {
                sqlstring = GetSqlString();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    // savedsettings.read_settings();
                    Form1 f1 = new Form1();
                    SqlDataAdapter adapter = new SqlDataAdapter("print '1'", sqlstring);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    Application.Run(new Form1());
                }
                catch
                {
                    //savedsettings.write_settings();  
                    if (check_admin_rights.IsUserAdministrator())
                        Application.Run(new SettingsForm());
                    else
                        MessageBox.Show("Не удается подключиться к базе данных, для того что бы изменить настройки программы запустите программу от имени администратора");
                }
            }
            
        }
        public static String GetSqlString()
        {
            try
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
            catch
            {
                return "";
            }
        }
    }
}
