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
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Cassia;

namespace login_logoff
{
    public partial class Form1 : Form
    {
        //рдп или нет
        public string is_rdp;
        //имя пользователя
        public string username;
        //изменение даты
        public bool date_changed;
        //показывать подробности
        public bool showPodrobn;
        //показывать предыдущие подробности
        public bool showPodrobnPrev;
        //показывать все события
        public bool showAll;
        //показывать график
        public bool GraphShow;
        //форма закрыта
        public static bool closed;
        //не опоздал
        public int not_late;
        //время на работе
        public int full_time;
        //время за компьютером
        public int total_records;
        //минимальная дата
        public string mindate;
        //максимальная дата
        public string maxdate;        
        public DataSet send;
        //высота панели для графика
        public int panel_height;
        //полученный тип запроса
        public int k;
        //мастштаб
        public double scale;


        public Form1()
        {
            InitializeComponent();
            scale = 1;
            this.graphic.MouseWheel += new MouseEventHandler(graphic_MouseWheel);
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Size.Width, Screen.PrimaryScreen.WorkingArea.Size.Height);
            //this.MaximumSize =new Size(867, Screen.PrimaryScreen.WorkingArea.Size.Height);
            GraphShow = true;         
            //MaximizeBox = false;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            SimpleEncryption decrypt = new SimpleEncryption("password");
            if (!checkPodrobn.Checked) showPodrobn = false;
            if (!checkBox2.Checked) showAll = false;
            this.userstats.Visible = false;
                if (date_changed == false)                                
            {
                if (logon_class.Properties.Settings.Default.encrypted.Equals("1"))
                {
                    if (decrypt.Decrypt(logon_class.Properties.Settings.Default.default_time).Equals("month"))
                        startdate.Value = new DateTime(startdate.Value.Year, startdate.Value.Month, 1);
                    else if (decrypt.Decrypt(logon_class.Properties.Settings.Default.default_time).Equals("week"))
                        startdate.Value = DateTime.Now.Date.AddDays(-6);
                    else if (decrypt.Decrypt(logon_class.Properties.Settings.Default.default_time).Equals("day"))
                        startdate.Value = DateTime.Now.Date;
                }
                else
                {
                    if (logon_class.Properties.Settings.Default.default_time.Equals("month"))
                        startdate.Value = new DateTime(startdate.Value.Year, startdate.Value.Month, 1);
                    else if (logon_class.Properties.Settings.Default.default_time.Equals("week"))
                        startdate.Value = DateTime.Now.Date.AddDays(-6);
                    else if (logon_class.Properties.Settings.Default.default_time.Equals("day"))
                        startdate.Value = DateTime.Now.Date;
                }
            }
            int i;
            k = 0;
            string begin = startdate.ToString();
            string end = enddate.ToString();

            if (is_rdp == null) is_rdp = "0";
            //if (username == null) username = "DBUserLoginUsers.surname";
            if (username == null) username = "'%'";
            //заполняем список пользователей           
            if (comboBox1.Items.Count < 1)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("все пользователи");
                i = 0;
                while (spisok_polzovateley().Length > i)
                {
                    comboBox1.Items.Add(spisok_polzovateley()[i].ToString());
                    i++;
                }
            }

            k = 0;
            string sql = "";
            //диапазон дат            
            mindate = startdate.Value.ToString("yyyy-MM-dd");
            maxdate = enddate.Value.ToString("yyyy-MM-dd");
            //вывод всех
            try
            {
                DataSet ds = new DataSet();
                if (checkBox2.Checked)
                {
                    sql = "exec showall @mindate='" + mindate + "', @maxdate='" + maxdate + "', @is_rdp=" + is_rdp + ", @username=" + username + "";
                    k = 0;
                    ds = dsfill(sql, ds);                    
                }

                else if (showPodrobn)
                {
                    //вывод с РДП
                    if (checkBox1.Checked)
                    {
                        sql = "exec showrdp @mindate='" + mindate + "', @maxdate='" + maxdate + "', @username=" + username + "";
                        k = 1;
                        ds = dsfill(sql, ds);
                    }
                    //вывод мин
                    else
                    {
                        sql = "exec showmin @mindate='" + mindate + "', @maxdate='" + maxdate + "', @username=" + username + "";
                        k = 1;
                        ds = dsfill(sql, ds);


                    }
                }
                //не подробный вывод
                else
                {
                    //sql = ("select userdatetime from dbuserloginmin where username='glybin' and cast(userdatetime as date)='31.05.2016'");
                    sql = "ShowMinNePodrobno @is_rdp="+ is_rdp + ", @mindate='"+mindate+"', @maxdate='"+maxdate+"';";
                    ds = dsfill(sql, ds);
                    k = 2;
                }



                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = ds;                
                dataGridView1.DataMember = "table";
             


                //форматирование datagridview
                if (k == 0)
                {

                    this.dataGridView1.Columns[3].DefaultCellStyle.Format = @"hh\:mm\:ss";
                    RowsColor(5);
                }
                if (k == 1)
                {
                    this.dataGridView1.Columns[2].DefaultCellStyle.Format = @"hh\:mm\:ss";
                    this.dataGridView1.Columns[3].DefaultCellStyle.Format = @"hh\:mm\:ss";
                    this.dataGridView1.Columns[4].Visible = false;
                    RowsColor(4);
                }
                if (k==2)
                {                    
                    dataGridView1.AutoGenerateColumns = true;
                    add_columns();
                    dataGridView1.Columns["times"].Visible = false;
                    dataGridView1.Columns["surname"].Visible = false;
                   // dataGridView1.Columns[3].Visible = false;
                  
                }
            
                //информация о пользователе
                if (!username.Equals("'%'"))
                {
                    this.userstats.Visible = true;
                    string show = "За выбранный промежуток времени \n";
                    show += "Время на работе - " + sum_time(mindate, maxdate, username, is_rdp)[1] + "\n";
                    show += "Время за компьютером - " + sum_time(mindate, maxdate, username, is_rdp)[0] + "\n";
                    show += "Раз опоздал/раньше ушел - " + sum_time(mindate, maxdate, username, is_rdp)[2] + "\n";
                    show += "Раз недоработал - " + sum_time(mindate, maxdate, username, is_rdp)[3] + "\n";
                    this.userstats.Text = show;
                }
                resize_elements();
                send = ds;
                this.graphic.Refresh();
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }

        }        
        //заполнение и добавление колонок при не подробном выводе
        public void add_columns()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.HeaderCell.Value = row.Cells["surname"].Value;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns[0].Visible = false;
                dataGridView1.RowHeadersWidth = dataGridView1.Columns[0].Width + 30;
            }
            DateTime date1 = startdate.Value;
            DateTime date2 = enddate.Value;
            int j = 0;
            while (date1.Date <= date2.Date)
            {     
                           
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                string column_name = date1.Date.ToString("dd/MM/yyyy");
                if (date1.DayOfWeek == DayOfWeek.Saturday || date1.DayOfWeek == DayOfWeek.Sunday)
                    column.DefaultCellStyle.BackColor = Color.PowderBlue;
                column.HeaderCell.Value = column_name;
                column.Name = column.HeaderCell.Value.ToString();
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns.Add(column);                
                j++;
                date1 = date1.AddDays(1);
            }

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                string[] parse_days = new string[j];
                string[] parse_values = new string[6];
                string times = "times";

                    parse_days = row.Cells[times].Value.ToString().Split(';');
                //if (parse_days != null)
                {
                    date1 = startdate.Value;
                    date2 = enddate.Value;
                    bool is_late = false;
                    bool full_time_work = false;
                    for (int k = 1; k < parse_days.Length; k++)
                    {
                        parse_values = parse_days[k - 1].Split(',');
                        DateTime columndate = Convert.ToDateTime(parse_values[0]);
                        string culumnheaderdate = columndate.Date.ToString("dd/MM/yyyy");
                        row.Cells[culumnheaderdate].Value = parse_values[1] + " - " + parse_values[2];
                        if (columndate.DayOfWeek != DayOfWeek.Saturday && columndate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (parse_values[3].Equals("0"))
                            {
                                row.Cells[culumnheaderdate].Style.BackColor = Color.GreenYellow;
                            }
                            else if (Convert.ToInt32(parse_values[5]) >= 32400)
                            {
                                row.Cells[culumnheaderdate].Style.BackColor = Color.Yellow;
                            }

                            if (!parse_values[3].Equals("0"))
                            {
                                is_late = true;
                            }
                            if (Convert.ToInt32(parse_values[5]) < 32400)
                            {
                                full_time_work = true;
                            }
                        }                      
                            date1 = date1.Date.AddDays(1);
                    }
                    if (is_late==false)
                    {
                        dataGridView1.EnableHeadersVisualStyles = false;
                        row.HeaderCell.Style.BackColor = Color.GreenYellow;
                    }
                    else if (full_time_work==false)
                    {
                        dataGridView1.EnableHeadersVisualStyles = false;
                        row.HeaderCell.Style.BackColor = Color.Yellow;
                    }
                }
            }                
            }
        //выполнение sql команды
        public DataSet dsfill(string sql, DataSet ds)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Program.sqlstring);            
            adapter.Fill(ds);            
            return ds;
        }
        //изменение ширины
        public void resize_elements()
        {
            int width = 0;          
            if (showPodrobn || showAll)
            {
                this.dataGridView1.RowHeadersVisible = false;
                width += 41;
            }
            else
            {
                this.dataGridView1.RowHeadersVisible = true;
                width += dataGridView1.RowHeadersWidth;
            }

                foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Visible)                    
                width += col.Width;                
            }


            /* if (showPodrobn || showAll)
                 dataGridView1.Width = width-18;
             else dataGridView1.Width = width;
             if (width > 641 || width < 625)
             {
                 width = 625;
                 dataGridView1.Width = width;
             }*/

            width = this.Width - 52 - UsersButton.Width;            
            dataGridView1.Width = width;
            this.dataGridView1.Height = this.Height - 72;
            this.label1.Location = new Point(dataGridView1.Location.X+dataGridView1.Width+10, dataGridView1.Location.Y+70);            
            this.startdate.Location = new Point(label1.Location.X, label1.Location.Y+label1.Height+5);            
            this.label3.Location = new Point(startdate.Location.X + startdate.Width + 5, startdate.Location.Y );
            this.enddate.Location = new Point(label3.Location.X+label3.Width+5, startdate.Location.Y);
            this.label2.Location = new Point(enddate.Location.X, label1.Location.Y);
            this.checkBox1.Location = new Point(startdate.Location.X, startdate.Location.Y+startdate.Height+5);
            /* if (showPodrobn)
             {
                 this.checkBox2.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y + checkBox1.Height + 5);
                 this.checkBox2.Visible = false;
                 this.checkPodrobn.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y + checkBox1.Height + 5);
                 this.checkPodrobn.Visible = true;
             }*/
            if (showAll)
            {

                this.graphic.Location = dataGridView1.Location;
                p_height();
                this.graphic.Height = dataGridView1.Height;
                this.graphic.Width = dataGridView1.Width - 10;
                this.graphic.AutoScroll = true;                
                this.graphic.AutoScrollMinSize = new Size(Convert.ToInt32(graphic.Width*scale) - 20, panel_height);
                this.graphic.Refresh();
                this.graphic.Visible = true;
                this.scale_plus.Location = new Point(graphic.Location.X + graphic.Width + 10, graphic.Location.Y);
                if (GraphShow)
                {
                    this.scale_minus.Location = new Point(scale_plus.Location.X, scale_plus.Location.Y + scale_minus.Height + 5);
                    this.scale_plus.Visible = true;
                    this.scale_minus.Visible = true;
                    this.graphic.Visible = true;
                    this.dataGridView1.Visible = false;
                    this.graphshow.Text = "Показать в виде данных";
                }
                else
                {
                    this.scale_minus.Location = new Point(scale_plus.Location.X, scale_plus.Location.Y + scale_minus.Height + 5);
                    this.scale_plus.Visible = false;
                    this.scale_minus.Visible = false;
                    this.graphic.Visible = false;
                    this.dataGridView1.Visible = true;
                    this.graphshow.Text = "Показать в виде графика";
                }
                
                this.checkBox2.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y + checkBox1.Height + 5);
                this.checkBox2.Visible = true;
                this.checkPodrobn.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y + checkBox1.Height + 5);
                this.checkPodrobn.Visible = false;
            }
            else if (showPodrobn && (comboBox1.SelectedItem!=null&&((comboBox1.SelectedItem.ToString().Equals("все пользователи")==false))))
            {
                this.scale_plus.Visible = false;
                this.scale_minus.Visible = false;
                this.graphic.Visible = false;
                this.dataGridView1.Visible = true;
                this.checkBox2.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y + checkBox1.Height + 5);
                this.checkBox2.Visible = true;
                this.checkPodrobn.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y + checkBox1.Height + 5);
                this.checkPodrobn.Visible = false;
            }
            else
            {
                this.scale_plus.Visible = false;
                this.scale_minus.Visible = false;
                this.graphic.Visible = false;
                this.dataGridView1.Visible = true;
                this.checkBox2.Location = new Point(checkBox1.Location.X, checkBox1.Location.Y + checkBox1.Height + 5);
                this.checkBox2.Visible = true;
                this.checkPodrobn.Location = new Point(checkBox2.Location.X, checkBox2.Location.Y + checkBox2.Height + 5);
                this.checkPodrobn.Visible = true;
            }
            this.comboBox1.Location = new Point(checkPodrobn.Location.X, checkPodrobn.Location.Y + checkPodrobn.Height + 5);
            
            this.UsersButton.Location = new Point(comboBox1.Location.X,comboBox1.Location.Y+comboBox1.Height+5);
            
            this.UpdateBut.Location = new Point(UsersButton.Location.X, UsersButton.Location.Y + UsersButton.Height + 5);
            
            this.SettingsBut.Location = new Point(UpdateBut.Location.X, UpdateBut.Location.Y + UpdateBut.Height + 5);

           if (checkBox2.Checked == true)
            {
                graphshow.Visible = true;
                graphshow.Width = SettingsBut.Width;
                graphshow.Location = new Point(SettingsBut.Location.X, SettingsBut.Location.Y + SettingsBut.Height + 5);
            }
            else
            {
                graphshow.Visible = false;
                graphshow.Width = SettingsBut.Width;
                graphshow.Location = SettingsBut.Location;
            }
            this.about.Location = new Point(graphshow.Location.X, graphshow.Location.Y + graphshow.Height + 5);
            this.userstats.Location = new Point(about.Location.X, about.Location.Y + about.Height + 5);

        }
        //закрашивание строк
        public void RowsColor(int n)
        {
            int i = 0;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {                
                if (i < this.dataGridView1.Rows.Count)
                {
                    string[] splited = new string[3];
                    splited = (row.Cells[5].Value.ToString()).Split(':');
                    int hour = 8;
                    try
                    {
                        hour = Convert.ToInt32(splited[0]);                        
                    }
                    catch
                    {
                        
                    }                    
                    
                    if ((!Convert.ToBoolean(row.Cells[n].Value))&&(k==1))
                    {
                       row.DefaultCellStyle.BackColor = Color.GreenYellow;                        
                    }
                    else if ((hour>=9) && (k == 1))
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;                        
                    }
                    else if ((Convert.ToBoolean(row.Cells[n].Value)) && (k == 0))
                    {
                        row.Cells[n].Style.BackColor = Color.GreenYellow;
                       // row.DefaultCellStyle.BackColor = Color.GreenYellow;                        
                    }

                    if ((row.Cells[4].Value.ToString().Equals("logon"))&&(k==0))
                    {
                        row.DefaultCellStyle.BackColor = Color.PowderBlue;                       
                    }
                    else if ((row.Cells[4].Value.ToString().Equals("logoff")) && (k == 0))
                    {
                        row.DefaultCellStyle.BackColor = Color.Pink;                        
                    }

                    if (k == 1)
                    {
                        DateTime date = Convert.ToDateTime(row.Cells["дата"].Value.ToString());
                        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            row.DefaultCellStyle.BackColor = Color.PowderBlue;
                    }
                }
               if (i < this.dataGridView1.Rows.Count)
                {
                    if ((!Convert.ToBoolean(row.Cells[n].Value)) && (k == 1))
                    {
                        
                    }
                    else if ((Convert.ToBoolean(row.Cells[n].Value)) && (k == 0))
                    {
                        
                    }
                }
                i++;
            }
        }       

        T[,] ResizeArray<T>(T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }
        //вывод статистики
        public string[] sum_time(string mindate, string maxdate, string username, string is_rdp)
        {
            string[] result = new string[4];
            if (is_rdp.Equals("'%'")) is_rdp = "1";
            string sql = "exec realdatemin_sum ";
            sql += "@surname = "+username+", ";
            sql += "@mindate = '"+mindate+"', ";
            sql += "@enddate = '"+maxdate+"', ";
            sql += "@rdp = "+is_rdp+"";
            SqlDataReader command = sqlcommand(sql);
            while (command.Read())
            {
                result[0] = command[0].ToString();
                result[1] = command[1].ToString();
                result[2] = command[2].ToString();
                result[3] = command[3].ToString();
            }
            return result;        
        }
        //выполнение sql команды
        public SqlDataReader sqlcommand(string sql)
        {
            SqlConnection conn = new SqlConnection(Program.sqlstring);
            conn.Open();
            SqlCommand sc = new SqlCommand(sql, conn);
            SqlDataReader command;
            return command = sc.ExecuteReader();
        }
        //получение списка пользователей
        public string[] spisok_polzovateley()
        {
                string[] users = new string[1] {""};
                try
                {
                string sql = "select distinct surname from DbUserLoginUsers";
 
                    SqlDataReader users_list = sqlcommand(sql);                    
                    int i = 0;
                    while (users_list.Read())
                    {
                        Array.Resize(ref users, (i + 1));
                        users[i] = users_list[0].ToString();
                        i++;
                    }
                    return users;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
            
        }
        //изменение выделения показа с RDP
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            is_rdp="0";
            if (checkBox1.Checked) is_rdp = "'%'";
            else is_rdp = "0";
            
            this.Form1_Load(sender, e);

        }
        //изменение выбранного пользователя
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            username = "DBUserLoginUsers.surname";
            if (comboBox1.SelectedItem.ToString() == "все пользователи")
            {
                username = "'%'";
                if (showPodrobnPrev)
                    this.checkPodrobn.Checked = true;
                else
                    this.checkPodrobn.Checked = false;
            }
            else
            {
                username = "'" + comboBox1.SelectedItem.ToString() + "'";
                this.checkPodrobn.Checked = true;
            }            
            this.Form1_Load(sender, e);
            
        }
        //изменение выделения показа всех событий
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                showAll = true;
            else showAll = false;            
            this.Form1_Load(sender, e);
        }
        //клик по кнопке пользователи
        private void UsersButton_Click(object sender, EventArgs e)
        {
            Hide();
            UsersForm usersform1 = new UsersForm();
            usersform1.Show();

        }
        //закрытие формы
        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            closed = true;
            Application.Exit();
        }
        //изменение начальной даты
        private void startdate_ValueChanged(object sender, EventArgs e)
        {
            date_changed = true;
            if (startdate.Value > enddate.Value) enddate.Value= startdate.Value;
            this.Form1_Load(sender, e);
        }
        //изменение конечной даты
        private void enddate_ValueChanged(object sender, EventArgs e)
        {
            if (startdate.Value > enddate.Value) startdate.Value = enddate.Value;
            this.Form1_Load(sender, e);
        }
        //нажатие кноки обновить
        private void UpdateBut_Click(object sender, EventArgs e)
        {
            this.Form1_Load(sender, e);
        }
        //изменение сортировки в DataGridView
        private void order_changed(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (k == 1)
            {
                this.dataGridView1.Columns[4].Visible = false;
                RowsColor(4);
            }
            if (k == 0)
            {
               RowsColor(5);
            }
        }
        //нажатие на кнопку настройки
        
        private void SettingsBut_Click(object sender, EventArgs e)
        {

            if (check_admin_rights.IsUserAdministrator())
            {
                this.Hide();
                SettingsForm f2 = new SettingsForm();
                f2.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Для изменения настроек запустите программу от имени администратора");
            
        }
        //изменение размера формы
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            resize_elements();
        }
        //изменение выделения показывать подробности
        private void checkPodrobn_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkPodrobn.Checked)
                showPodrobn = false;
            else showPodrobn = true;
            this.Form1_Load(sender, e);
        }
        //нажатие на показать подробности
        private void checkPodrobn_Click(object sender, EventArgs e)
        {
            graphic.Visible = false;
            if (!checkPodrobn.Checked)
                showPodrobnPrev = false;
            else showPodrobnPrev = true;
        }
        //нажатие на кнопку показать в виде графика/данных
        private void graphshow_Click(object sender, EventArgs e)
        {
            if (graphshow.Text.Equals("Показать в виде графика"))
            {
                GraphShow = true;
                graphshow.Text = "Показать в виде данных";
                dataGridView1.Visible = false;
                graphic.Visible = true;
                scale_minus.Visible = true;
                scale_plus.Visible = true;
            }
            else
            {
                GraphShow = false;
                graphshow.Text = "Показать в виде графика";
                dataGridView1.Visible = true;
                graphic.Visible = false;
                scale_minus.Visible = false;
                scale_plus.Visible = false;
            }

           /* Form graphics = new graph(this.send);

            graphics.Width = this.Width;
            graphics.Height = this.Height;
            graphics.Show();*/
        }
        //отрисовка графика
        private void graphic_Paint_1(object sender, PaintEventArgs e)
        {
            if (graphic.Visible)
            {
                e.Graphics.TranslateTransform(graphic.AutoScrollPosition.X, graphic.AutoScrollPosition.Y);
                Pen pen = new Pen(Color.Black, 1);
                
                TimeSpan logon = new TimeSpan(0, 0, 0);
                TimeSpan logoff = new TimeSpan(0, 0, 0);
                int logon_seconds = 0;
                int logoff_seconds = 0;
                int width = graphic.AutoScrollMinSize.Width - 60;                
                int y = 1;
                if (width < 140)
                    width = 140;
                Rectangle bgrect = new Rectangle(80, 20 * (y + 1) * 2, (width - 45) - (width - 45) % 24, 20);                
                double sec = (Convert.ToDouble(bgrect.Width) / 86400);
                bool date_label_aded = false;

                int time_width = Convert.ToInt32((3600 * sec));
                DateTime date;
                string prevcomp = "";
                string currcomp = "";
                string nextcomp = "";
                string prevtype = "";
                string currtype = "";
                string nexttype = "";
                int logon_count = 0;
                for (int i = dataGridView1.Rows.Count -1; i >= 0; i--)
                {
                    if (i>0&&dataGridView1.Rows[i-1].Cells["Компьютер"].Value!=null)
                    {
                        nextcomp = dataGridView1.Rows[i-1].Cells["Компьютер"].Value.ToString();
                        nexttype = dataGridView1.Rows[i-1].Cells["Логон/Логофф"].Value.ToString();
                    }
                    else
                    {
                        nextcomp = nexttype = "";
                    }
                    if (i == dataGridView1.Rows.Count - 1)
                    {
                        logon_count = 0;
                        y++;
                        string surname = dataGridView1.Rows[i].Cells["фамилия"].Value.ToString();
                        Font drawFont = new Font("Arial", 14);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);
                        StringFormat drawFormat = new StringFormat();
                        date = Convert.ToDateTime(dataGridView1.Rows[i].Cells["дата"].Value.ToString());
                        bgrect = new Rectangle(80, 20 * y * 2, (width - 45) - (width - 45) % 24, 20);
                        LinearGradientBrush br = new LinearGradientBrush(new Point(bgrect.X, bgrect.Y), new Point(bgrect.X, bgrect.Y + bgrect.Height), Color.Red, Color.Pink);
                        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            br.LinearColors = new Color[] { Color.Blue, Color.PowderBlue };
                        else
                            br.LinearColors =new Color[] { Color.Red, Color.Pink };
                        e.Graphics.FillRectangle(br, bgrect);
                        e.Graphics.DrawRectangle(pen, bgrect);
                        e.Graphics.DrawString(surname, drawFont, drawBrush, bgrect.X + bgrect.Width / 2, bgrect.Y - 2 * bgrect.Height, new StringFormat());
                    }
                    if (i != dataGridView1.Rows.Count - 1)
                    {
                        if (!dataGridView1.Rows[i].Cells["фамилия"].Value.ToString().Equals(dataGridView1.Rows[i + 1].Cells["фамилия"].Value.ToString()))
                        {
                            logon_count = 0;
                            prevtype = prevcomp = "";
                        }
                        if (!dataGridView1.Rows[i].Cells["дата"].Value.ToString().Equals(dataGridView1.Rows[i + 1].Cells["дата"].Value.ToString()) || !dataGridView1.Rows[i].Cells["фамилия"].Value.ToString().Equals(dataGridView1.Rows[i + 1].Cells["фамилия"].Value.ToString()))
                        {
                            logon_count = 0;
                            prevtype = prevcomp = "";
                        }
                    }
                    if (dataGridView1.Rows[i].Cells["время"].Value != null)
                    {
                        currtype = dataGridView1.Rows[i].Cells["Логон/Логофф"].Value.ToString();
                        currcomp = dataGridView1.Rows[i].Cells["Компьютер"].Value.ToString();
                        if ((dataGridView1.Rows[i].Cells["Логон/Логофф"].Value.Equals("logon")))
                        {
                            if (!(prevtype.Equals(currtype) && prevcomp.Equals(currcomp)))
                                
                            {
                                if (logon_count < 0)
                                    logon_count = 0;
                                if (logon_count == 0)
                                    logon = TimeSpan.Parse(dataGridView1.Rows[i].Cells["время"].Value.ToString());
                                logon_count++;
                            }
                        }

                        if ((dataGridView1.Rows[i].Cells["Логон/Логофф"].Value.Equals("logoff")) && logon_count > 0)
                        {
                            if (!(nexttype.Equals(currtype) && nextcomp.Equals(currcomp)))
                            {
                                logon_count--;
                                if (logon_count == 0)
                                    logoff = TimeSpan.Parse(dataGridView1.Rows[i].Cells["время"].Value.ToString());
                            }
                        }
                    }
                    if ((dataGridView1.Rows[i].Cells["Логон/Логофф"].Value.Equals("logoff")) && logon_count == 0)
                    {                        
                        logon_seconds = Convert.ToInt32((logon.TotalSeconds) * sec) + bgrect.X;
                        logoff_seconds = Convert.ToInt32((logoff.TotalSeconds - logon.TotalSeconds) * sec);
                        Rectangle front = new Rectangle(logon_seconds, bgrect.Height * y * 2, logoff_seconds, bgrect.Height);
                        LinearGradientBrush br = new LinearGradientBrush(new Point(front.X, front.Y), new Point(front.X, front.Y + front.Height), Color.GreenYellow, Color.Green);
                        e.Graphics.FillRectangle(br, front);
                        e.Graphics.DrawRectangle(pen, front);

                    }
                    if (!date_label_aded)
                    {
                        Rectangle bgrect1 = new Rectangle(bgrect.X, bgrect.Height * y * 2, bgrect.Width, bgrect.Height);
                        date = Convert.ToDateTime(dataGridView1.Rows[i].Cells["дата"].Value.ToString());
                        string drawString = date.Date.ToString("dd/MM/yyyy");
                        Font drawFont = new Font("Arial", 8);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);
                        StringFormat drawFormat = new StringFormat();
                        e.Graphics.DrawString(drawString, drawFont, drawBrush, bgrect.Height, bgrect.Height * y * 2 + 2, new StringFormat());
                        for (int i1 = 0; i1 < 24; i1++)
                        {
                            e.Graphics.DrawRectangle(pen, i1 * time_width + +bgrect.X, bgrect1.Y - bgrect1.Height, time_width, bgrect.Height);
                            string drawString1 = Convert.ToString(i1);
                            Font drawFont1 = new Font("Arial", 8);
                            SolidBrush drawBrush1 = new SolidBrush(Color.Black);
                            StringFormat drawFormat1 = new StringFormat();
                            e.Graphics.DrawString(drawString1, drawFont1, drawBrush1, i1 * time_width + bgrect.X, bgrect1.Y - bgrect1.Height, drawFormat1);

                        }
                        date_label_aded = true;
                    }

                    if (i != dataGridView1.Rows.Count - 1)
                    {
                        if (!dataGridView1.Rows[i].Cells["фамилия"].Value.ToString().Equals(dataGridView1.Rows[i + 1].Cells["фамилия"].Value.ToString()))
                        {
                            y++;
                            string surname = dataGridView1.Rows[i].Cells["фамилия"].Value.ToString();
                            Font drawFont = new Font("Arial", 14);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);
                            StringFormat drawFormat = new StringFormat();
                            e.Graphics.DrawString(surname, drawFont, drawBrush, bgrect.X + bgrect.Width / 2, bgrect.Height * y * 2, new StringFormat());
                        }

                        if (!dataGridView1.Rows[i].Cells["дата"].Value.ToString().Equals(dataGridView1.Rows[i + 1].Cells["дата"].Value.ToString()) || !dataGridView1.Rows[i].Cells["фамилия"].Value.ToString().Equals(dataGridView1.Rows[i + 1].Cells["фамилия"].Value.ToString()))
                        {
                            y++;
                            date = Convert.ToDateTime(dataGridView1.Rows[i].Cells["дата"].Value.ToString());                         
                            Rectangle bgrect1 = new Rectangle(bgrect.X, bgrect.Height * y * 2, bgrect.Width, bgrect.Height);
                            LinearGradientBrush br = new LinearGradientBrush(new Point(bgrect.X, bgrect.Y), new Point(bgrect.X, bgrect.Y + bgrect.Height), Color.Pink, Color.Red);
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                                br.LinearColors = new Color[] { Color.Blue, Color.PowderBlue };
                            else
                                br.LinearColors = new Color[] { Color.Red, Color.Pink };
                            e.Graphics.FillRectangle(br, bgrect1);
                            e.Graphics.DrawRectangle(pen, bgrect1);                            
                            Rectangle time_rect = new Rectangle(bgrect.X, bgrect.Height * y * 2, bgrect.Width, bgrect.Height);
                            e.Graphics.FillRectangle(br, time_rect);
                            e.Graphics.DrawRectangle(pen, time_rect);
                            date_label_aded = false;
                        }
                    }
                    if (dataGridView1.Rows[i].Cells["Компьютер"].Value != null)
                    {
                        prevcomp = dataGridView1.Rows[i].Cells["Компьютер"].Value.ToString();
                        prevtype = dataGridView1.Rows[i].Cells["Логон/Логофф"].Value.ToString();
                    }
                    else
                    {
                        prevcomp = prevtype = "";
                    }
                }
                pen.Dispose();                
                e.Graphics.Dispose();
                this.Invalidate();
            }
        }
        //задание высоты панели для графика
        public void p_height()
        {
            string curname = "";
            string prevname = "";
            string curdate = "";
            string prevdate = "";
            panel_height = 40;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["дата"].Value != null)
                {
                    curname = row.Cells["фамилия"].Value.ToString();
                    curdate = row.Cells["дата"].Value.ToString();
                    if (!curdate.Equals(prevdate) || !curname.Equals(prevname))
                        panel_height += 40;
                    if (!curname.Equals(prevname))
                        panel_height += 40;
                    prevdate = row.Cells["дата"].Value.ToString();
                    prevname = row.Cells["фамилия"].Value.ToString();
                }

            }
            if (panel_height < this.dataGridView1.Height) panel_height = this.dataGridView1.Height;
        }
        //нажатие на кнопку увеличить масштаб
        private void scale_plus_Click(object sender, EventArgs e)
        {
            scale+=0.2;
            resize_elements();
        }
        //нажатие на кнопку уменьшить масштаб
        private void scale_minus_Click(object sender, EventArgs e)
        {
            if (scale > 0.8)
            {
                scale -= 0.2;
                resize_elements();
            }
        }        
        //изменение масштаба графика колесом мышки
        private void graphic_MouseWheel(object sender, MouseEventArgs e)
        {   
            if (ModifierKeys == Keys.Control && e.Delta>0)
            {                
                scale += 0.2;
                resize_elements();
                
            }
            if (ModifierKeys==Keys.Control && e.Delta<0)
            {
                if (scale > 0.8)
                {
                    scale -= 0.2;
                    resize_elements();
                }
            }            
        }

        private void about_Click(object sender, EventArgs e)
        {
            about_form about_f = new about_form();
            about_f.Show();
        }
    }
}
