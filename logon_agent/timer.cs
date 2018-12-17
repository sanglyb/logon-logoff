using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logon_agent
{
    
    public partial class timer : Form
    {        
        public int first;
        public TimeSpan default_time;
        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {            
            if (e.Reason==SessionEndReasons.SystemShutdown)
            { }
            first = 0;
            string type = "logoff";
            string sql = "exec insert_into_dbuserlogin @username='" + Program.username + "', ";
            sql += "@computername ='" + Program.computername + "', @type='" + type + "', @is_rdp=" + Program.rdp_check() + ", @first=0;";            
            timer1.Stop();
            timer2.Stop();
            Program.sql_execute(sql);            
            Program.log_write("Программа logon_agent завершила работу", EventLogEntryType.Information);
            this.Close();
        }
        void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock || e.Reason == SessionSwitchReason.SessionLogoff || e.Reason == SessionSwitchReason.ConsoleDisconnect || e.Reason == SessionSwitchReason.RemoteDisconnect)
            {
                System.Threading.Thread.Sleep(1500);
                first = 0;
                string type = "logoff";
                string sql = "exec insert_into_dbuserlogin @username='" + Program.username + "', ";
                sql += "@computername ='" + Program.computername + "', @type='" + type + "', @is_rdp=" + Program.rdp_check() + ", @first=0;";
                timer1.Stop();
                timer2.Stop();
                Program.sql_execute(sql);
                Program.log_write("Программа logon_agent завершила работу", EventLogEntryType.Information);
                this.Close();
            }
            
        }
        public timer()
        {
            InitializeComponent();
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            SystemEvents.SessionEnding += SystemEvents_SessionEnding;


        }

        public void timer_Load(object sender, EventArgs e)
        {
            Hide();
            //Show();
            first = 1;
            get_time();
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time = new TimeSpan();
            if (first == 1) time = default_time - TimeSpan.Parse("00:01:10.0");
            else time = default_time;
            label1.Text = IdleTime.AsTimeSpan.ToString();
            if (IdleTime.AsTimeSpan > time)
            {
                timer1.Stop();                
                string type = "logoff";
                string sql = "exec insert_into_dbuserlogin @username='" + Program.username + "', ";
                sql += "@computername ='" + Program.computername + "', @type='" + type + "', @is_rdp=" + Program.rdp_check() + ", @first=0;";                
                Program.sql_execute(sql);                
                Program.first = 0;
                timer2.Start();
                return;
            }
            this.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (IdleTime.AsTimeSpan < TimeSpan.Parse("00:00:01"))
            {
                timer2.Stop();
                string type = "logon";
                string sql = "exec insert_into_dbuserlogin @username='" + Program.username + "', ";
                sql += "@computername ='" + Program.computername + "', @type='" + type + "', @is_rdp=" + Program.rdp_check() + ", @first=0;";
                Program.sql_execute(sql);                
                first = 0;
                timer1.Start();
                return;
            }            
        }
        public void get_time()
        {
            default_time = TimeSpan.Parse(logon_class.get_settings.get_idle_time()[0]);
        }
            
    }
}
