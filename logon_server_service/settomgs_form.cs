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
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

namespace logon_server_service
{
    public partial class Setup : Form
    {
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
            check_service_state getstate = new check_service_state();
            string cur_service_state=getstate.get_state("logon_server_service");
            if (cur_service_state.Equals("Running") || cur_service_state.Equals("Starting"))
            {
                service_install_but.Text = "Удалить сервис";
                service_control_but.Text = "Остановить сервис";
                service_control_but.Enabled = true;                
            }
            else if (cur_service_state.Equals("Not found"))
            {
                service_install_but.Text = "Установить сервис";
                service_control_but.Enabled = false;
            }
            else
            {
                service_install_but.Text = "Удалить сервис";
                service_control_but.Text = "Запустить сервис";
                service_control_but.Enabled = true;
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
                default_time_picker.Text = decrypt.Decrypt(logon_class.Properties.Settings.Default.default_service_time);
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
                default_time_picker.Text = logon_class.Properties.Settings.Default.default_service_time;

            }
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
                logon_class.Properties.Settings.Default.default_service_time = encrypt.Encrypt(default_time_picker.Text);
                logon_class.Properties.Settings.Default.encrypted = "1";
                logon_class.Properties.Settings.Default.Save();
                //logon_server_service.Service1.log_write("В настройки logon_V2 внесли изменения", EventLogEntryType.Warning);
                this.Setup_Load(sender, e);
            }
            catch (Exception ex)
            {
                //logon_server_service.Program.log_write("В программе logon_V2 произошла ошибка при внесении изменений в настройки \n" + ex.ToString() + "", EventLogEntryType.Error);
                MessageBox.Show("Не удается подключиться к базе данных, проверьте параметры");
            }
        }

        private void default_time_picker_ValueChanged(object sender, EventArgs e)
        {
            /*if (TimeSpan.Parse(default_time_picker.Text)<TimeSpan.Parse("00:01:12"))
            {
                default_time_picker.Text = "00:01:12";
            }*/
        }

        private void service_install_but_Click(object sender, EventArgs e)
        {
            try
            {
                if (service_install_but.Text.Equals("Установить сервис"))
                {
                    ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                }
                else
                {
                    ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка, попробуйте запустить программу от имени администратора\n" + ex.ToString());
            }
            Setup_Load(sender, e);
        }

        private void service_control_but_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController service = new ServiceController("logon_server_service");
                if (service_control_but.Text.Equals("Запустить сервис"))
                {
                    service.Start();
                    //System.Threading.Thread.Sleep(2000);

                }
                else
                {
                    service.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка, попробуйте запустить программу от имени администратора\n" + ex.ToString());
            }
            Setup_Load(sender, e);
        }
    }
}
