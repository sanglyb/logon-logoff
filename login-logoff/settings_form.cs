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
using System.Configuration;

namespace login_logoff
{
    public partial class SettingsForm : Form
    {
        private string idle_time;
        private string wStartTime;
        private string wEndTime;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void adduserform_closed(object sender, FormClosedEventArgs e)
        {


        }
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {                
                
                if (Form1.closed != true)
                {
                    Form1 f1 = new Form1();
                    SqlDataAdapter adapter = new SqlDataAdapter("print '1'", Program.sqlstring);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    this.Hide();
                    e.Cancel = true;
                    Form1 mainform = new Form1();
                    mainform.Show();
                }
                else
                    Application.Exit();
            }
            catch
            {
                Application.Exit();               
            }
            
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string[] idleTime = new string[3];
            try
            {
                idleTime = logon_class.get_settings.get_idle_time();
                idle_time = idleTime[0];
                wStartTime = idleTime[1];
                wEndTime = idleTime[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при получении времени простоя: \n" + ex.ToString());
                idle_time = "00:05:00";
                wStartTime = "09:00:00";
                wEndTime = "18:00:00";
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
                if (decrypt.Decrypt((logon_class.Properties.Settings.Default.default_time)).Equals("month"))
                {
                    date.SelectedItem = "Месяц";
                    date.Text = "Месяц";
                }
                else if (decrypt.Decrypt(logon_class.Properties.Settings.Default.default_time).Equals("week"))
                {
                    date.SelectedItem = "Неделю";
                    date.Text = "Неделю";
                }
                else if (decrypt.Decrypt(logon_class.Properties.Settings.Default.default_time).Equals("day"))
                {
                    date.SelectedItem = "День";
                    date.Text = "День";
                }
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
                if (logon_class.Properties.Settings.Default.default_time.Equals("month"))
                {
                    date.SelectedItem = "Месяц";
                    date.Text = "Месяц";
                }
                else if (logon_class.Properties.Settings.Default.default_time.Equals("week"))
                {
                    date.SelectedItem = "Неделю";
                    date.Text = "Неделю";
                }
                else if (logon_class.Properties.Settings.Default.default_time.Equals("day"))
                {
                    date.SelectedItem = "День";
                    date.Text = "День";
                }
            }
            default_time_picker.Text = idle_time;
            workStartTime.Text = wStartTime;
            workEndTime.Text = wEndTime;
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleEncryption encrypt = new SimpleEncryption("password");

                string sql = "Data Source=" + db.Text + ";" + "Initial Catalog=" + catalog.Text + ";" + "Persist Security Info=" + security.SelectedItem.ToString() + ";";
                sql += "User ID=" + user.Text + ";" + "Password=" + password.Text + ";";
                SqlDataAdapter adapter = new SqlDataAdapter("print '1'", sql);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                logon_class.Properties.Settings.Default.db = encrypt.Encrypt("Data Source=" + db.Text + ";");
                logon_class.Properties.Settings.Default.catalog = encrypt.Encrypt("Initial Catalog=" + catalog.Text + ";");
                logon_class.Properties.Settings.Default.security = encrypt.Encrypt("Persist Security Info=" + security.Text + ";");
                string userstr = "User ID=" + user.Text + ";";
                logon_class.Properties.Settings.Default.user = encrypt.Encrypt(userstr);
                logon_class.Properties.Settings.Default.password = encrypt.Encrypt("Password=" + password.Text + ";");
                if (date.SelectedItem.ToString().Equals("Месяц"))
                    logon_class.Properties.Settings.Default.default_time = encrypt.Encrypt("month");
                else if (date.SelectedItem.ToString().Equals("Неделю"))
                    logon_class.Properties.Settings.Default.default_time = encrypt.Encrypt("week");
                else if (date.SelectedItem.ToString().Equals("День"))
                    logon_class.Properties.Settings.Default.default_time = encrypt.Encrypt("day");
                logon_class.Properties.Settings.Default.encrypted = "1";
                /*
                logon_class.Properties.Settings.Default.db = ("Data Source=" + db.Text + ";");
                logon_class.Properties.Settings.Default.catalog = ("Initial Catalog=" + catalog.Text + ";");
                logon_class.Properties.Settings.Default.security = ("Persist Security Info=" + security.Text + ";");
                string userstr = "User ID=" + user.Text + ";";
                logon_class.Properties.Settings.Default.user = (userstr);
                logon_class.Properties.Settings.Default.password = ("Password=" + password.Text + ";");
                if (date.SelectedItem.ToString().Equals("Месяц"))
                    logon_class.Properties.Settings.Default.default_time = ("month");
                else if (date.SelectedItem.ToString().Equals("Неделю"))
                    logon_class.Properties.Settings.Default.default_time = ("week");
                else if (date.SelectedItem.ToString().Equals("День"))
                    logon_class.Properties.Settings.Default.default_time = ("day");
                logon_class.Properties.Settings.Default.encrypted = "1";*/
                logon_class.Properties.Settings.Default.Save();
                sql = "exec set_idle_time_for_app @idle_time='" + default_time_picker.Text + "', @workStartTime='"+workStartTime.Text+"', @workEndTime='"+workEndTime.Text+"';";
                logon_class.get_settings.sql_execute(sql);
                MessageBox.Show("Изменения сохранены");
                this.SettingsForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удается подключиться к базе данных, проверьте параметры\n" + ex.ToString());
            }
        }

        private void default_time_picker_ValueChanged(object sender, EventArgs e)
        {
            if (TimeSpan.Parse(default_time_picker.Text) < TimeSpan.Parse("00:01:12"))
            {
                default_time_picker.Text = "00:01:12";
            }
        }
    }
}
