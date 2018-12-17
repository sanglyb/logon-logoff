using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace logon_server_service
{
    class get_settings1
    {
        public string connection;
        public int check_t; 
        public void GetSqlString()
        {
            try
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
            catch
            {
            }
        }
    }
}
