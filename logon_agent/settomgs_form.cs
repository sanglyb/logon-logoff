using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace logon_agent
{
    public partial class Setup : Form
    {
        private string idle_time;
        public Setup()
        {
            InitializeComponent();


        }

        private void Setup_FormClosing(object sender, FormClosingEventArgs e)
        {
                Application.Exit();
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            try
            {
                idle_time = logon_class.get_settings.get_idle_time();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при получении времени простоя: \n" + ex.ToString());
                idle_time = "05:00:00";
            }

            SimpleEncryption decrypt = new SimpleEncryption("password");
            string[] splited = new string[3];
            if (logon_class.Properties.Settings.Default.encrypted.Equals("1"))
            {

                splited = (decrypt.Decrypt(logon_class.Properties.Settings.Default.db)).Split('=', ';');
                db.Text = splited[1];
                splited = (decrypt.Decrypt(logon_class.Properties.Settings.Default.catalog)).Split('=', ';');
                catalog.Text = splited[1];
                splited = (decrypt.Decrypt(logon_class.Properties.Settings.Default.security)).Split('=', ';');
                security.SelectedItem = splited[1];
                security.Text = splited[1];
                splited = decrypt.Decrypt(logon_class.Properties.Settings.Default.user).Split('=', ';');
                user.Text = splited[1];
                splited = decrypt.Decrypt((logon_class.Properties.Settings.Default.password)).Split('=', ';');
                password.Text = splited[1];                
            }
            else
            {
                splited = (logon_class.Properties.Settings.Default.db).Split('=', ';');
                db.Text = splited[1];
                splited = (logon_class.Properties.Settings.Default.catalog).Split('=', ';');
                catalog.Text = splited[1];
                splited = (logon_class.Properties.Settings.Default.security).Split('=', ';');
                security.SelectedItem = splited[1];
                security.Text = splited[1];
                splited = (logon_class.Properties.Settings.Default.user).Split('=', ';');
                user.Text = splited[1];
                splited = (logon_class.Properties.Settings.Default.password).Split('=', ';');
                password.Text = splited[1];
                

            }
            default_time_picker.Text = idle_time;
        }




        /*{





            save.Height = default_time_picker.Height;
            string[] splited = new string[3];
            splited = (logon_class.Properties.Settings.Default.db).Split('=', ';');
            db.Text = splited[1];
            splited = (logon_class.Properties.Settings.Default.catalog).Split('=', ';');
            catalog.Text = splited[1];
            splited = (logon_class.Properties.Settings.Default.security).Split('=', ';');
            security.SelectedItem = splited[1];
            security.Text = splited[1];
            splited = (logon_class.Properties.Settings.Default.user).Split('=', ';');
            user.Text = splited[1];
            splited = (logon_class.Properties.Settings.Default.password).Split('=', ';');
            password.Text = splited[1];            
            default_time_picker.Text = logon_class.Properties.Settings.Default.default_time;    
        }      */

        private void save_Click_1(object sender, EventArgs e)
        {
            try
            {
                SimpleEncryption encrypt = new SimpleEncryption("password");
                string sql = "Data Source=" + db.Text + ";" + "Initial Catalog=" + catalog.Text + ";" + "Persist Security Info=" + security.SelectedItem.ToString() + ";";
                sql += "User ID=" + user.Text + ";" + "Password=" + password.Text + ";";
                SqlDataAdapter adapter = new SqlDataAdapter("print '1'", sql);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                MessageBox.Show("Изменения сохранены");
                logon_class.Properties.Settings.Default.db = encrypt.Encrypt("Data Source=" + db.Text + ";");
                logon_class.Properties.Settings.Default.catalog = encrypt.Encrypt("Initial Catalog=" + catalog.Text + ";");
                logon_class.Properties.Settings.Default.security = encrypt.Encrypt("Persist Security Info=" + security.Text + ";");
                logon_class.Properties.Settings.Default.user = encrypt.Encrypt("User ID=" + user.Text + ";");
                logon_class.Properties.Settings.Default.password = encrypt.Encrypt("Password=" + password.Text + ";");                
                logon_class.Properties.Settings.Default.encrypted = "1";
                logon_class.Properties.Settings.Default.Save();
                sql = "exec set_idle_time_for_app @idle_time='" + default_time_picker.Text + "';";
                Program.sql_execute(sql);
                Program.log_write("В настройки logon_agent внесли изменения", EventLogEntryType.Warning);
                this.Setup_Load(sender, e);
            }
            catch (Exception ex)
            {
                Program.log_write("В программе logon_agent произошла ошибка при внесении изменений в настройки \n" + ex.ToString() + "", EventLogEntryType.Error);
                MessageBox.Show("Не удается подключиться к базе данных, проверьте параметры");
            }
        }

        private void default_time_picker_ValueChanged(object sender, EventArgs e)
        {
            if (TimeSpan.Parse(default_time_picker.Text)<TimeSpan.Parse("00:01:12"))
            {
                default_time_picker.Text = "00:01:12";
            }
        }
    }
}
