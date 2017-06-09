using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login_logoff
{
    public partial class UsersForm : Form
    {
        long count;
        string[,] writes;
        TextBox[,] txtbox;
        DateTimePicker[,] timebox;
        CheckBox[] delete;
        CheckBox[] updatelate;


        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            int culumn_count = 7;
            Form1 mainform = new Form1();
            string sql = "";
            SqlConnection myConnection = new SqlConnection(Program.sqlstring);
            SqlDataReader myReader = null;
            myConnection.Open();
            sql = "select * from DbUserLoginUsers order by surname; ";
            SqlCommand write = new SqlCommand(sql, myConnection);
            myReader = write.ExecuteReader();
            count = 0;
            Label[] label_name = new Label[9];
            for (int i = 0; i < culumn_count; i++)
            {                
                label_name[i] = new Label();
                switch (i)
                {
                    case 0:
                        {
                            label_name[i].Text = "Фамилия";
                            break;
                        }
                    case 1:
                        {
                            label_name[i].Text = "Имя";
                            break;
                        }
                    case 2:
                        {
                            label_name[i].Text = "Отчество";
                            break;
                        }
                    case 3:
                        {
                            label_name[i].Text = "Начало";
                            break;
                        }
                    case 4:
                        {
                            label_name[i].Text = "Окончание";
                            break;
                        }
                    case 5:
                        {
                            label_name[i].Text = "Пользователь";
                            break;
                        }
                    case 6:
                        {
                            label_name[i].Text = "Компьютер";
                            break;
                        }
                }
                label_name[i].TextAlign = ContentAlignment.MiddleCenter;
                label_name[i].Name = "label" + i + "_" + count;
                label_name[i].Location = new Point(30 + i * 92, 10);
                label_name[i].Size = new Size(90, 20);
                label_name[i].Visible = true;
                this.Controls.Add(label_name[i]);
            }
            while (myReader.Read())
            {
                count++;    
            }
            myConnection.Close();
            myConnection.Open();
            myReader = write.ExecuteReader();
            timebox = new DateTimePicker[culumn_count, count + 1];
            txtbox = new TextBox[culumn_count, count + 1];
            writes = new string[culumn_count, count + 1];
            int n = 0;
            while (myReader.Read())
            {
                for (int i = 0; i < culumn_count; i++)

                {
                    writes[i,n] = myReader[i].ToString();
                    if (i == 3 || i == 4)
                    {
                        writes[i,n] = myReader[i].ToString();                    
                        timebox[i, n] = new DateTimePicker();
                        timebox[i, n].Name = n+" "+i;
                        timebox[i, n].Text = myReader[i].ToString();
                        timebox[i, n].Location = new Point(label_name[i].Location.X, (label_name[i].Location.Y+20) * (n+1));
                        timebox[i, n].Size = new Size(90, 20);
                        timebox[i, n].ShowUpDown = true;
                        timebox[i, n].Visible = true;
                        timebox[i, n].Format = DateTimePickerFormat.Time;
                        this.Controls.Add(timebox[i, n]);
                    }
                    else
                    {
                        writes[i, n] = myReader[i].ToString();
                        txtbox[i, n] = new TextBox();
                        txtbox[i, n].Name = n + " " + i;
                        txtbox[i, n].Text = myReader[i].ToString();
                        txtbox[i, n].Location = new Point(label_name[i].Location.X, (label_name[i].Location.Y + 20) * (n + 1));
                        txtbox[i, n].Size = new Size(90, 20);
                        txtbox[i, n].Visible = true;
                        this.Controls.Add(txtbox[i, n]);
                    }
                }
                n++;
            }
            for (int i = 0; i < culumn_count; i++)
            {
                if (i == 3 || i == 4)
                {

                    timebox[i,n] = new DateTimePicker();
                    timebox[i, n].Name = n + " " + i;
                    if (i == 3)
                    {
                        writes[i, n] = "10:00:00";
                        timebox[i, n].Text = "10:00:00";
                    }
                    else
                    {
                        writes[i, n] = "19:00:00";
                        timebox[i, n].Text = "19:00:00";
                    }
                    timebox[i, n].Location = new Point(label_name[i].Location.X, (label_name[i].Location.Y + 20) * (n + 1));
                    timebox[i, n].Size = new Size(90, 20);
                    timebox[i, n].Visible = true;
                    timebox[i, n].ShowUpDown = true;
                    timebox[i, n].Format = DateTimePickerFormat.Time;
                    this.Controls.Add(timebox[i, n]);
                }
                else
                {
                    writes[i, n] = "";
                    txtbox[i, n] = new TextBox();
                    txtbox[i, n].Name = n + " " + i;
                    txtbox[i, n].Text = "";
                    txtbox[i, n].Location = new Point(label_name[i].Location.X, (label_name[i].Location.Y + 20) * (n + 1));
                    txtbox[i, n].Size = new Size(90, 20);
                    txtbox[i, n].Visible = true;
                    this.Controls.Add(txtbox[i, n]);
                }
            }
            delete = new CheckBox[n + 1];
            updatelate = new CheckBox[n + 1];
            ToolTip tooltip1 = new ToolTip();
            for (int i=0;i<count+1;i++)
            {
                updatelate[i] = new CheckBox();
                delete[i] = new CheckBox();                
                tooltip1.SetToolTip(delete[i], "Удалить пользователя");
                tooltip1.SetToolTip(updatelate[i], "Обновить опоздания для отмеченных пользователей");
                delete[i].Location= new Point(txtbox[culumn_count-1,0].Location.X+100, txtbox[0,i].Location.Y);
                updatelate[i].Location = new Point(delete[i].Location.X+20, txtbox[0, i].Location.Y);                
                if (i == count)
                {
                    updatelate[i].Visible = false;
                    delete[i].Visible = false;
                }
                Controls.Add(updatelate[i]);
                Controls.Add(delete[i]);                
            }
            this.SendButton.Location = new Point(updatelate[0].Location.X + 20, updatelate[0].Location.Y);
            this.Size = new Size(SendButton.Location.X + SendButton.Size.Width + 40, 640);


            
           

        }

        private void delete_help(object sender, MouseEventArgs e)
        {
            ToolTip tooltip1 = new ToolTip();
            tooltip1.Show("Удалить пользователя", this.SendButton);
            
        }

        private void UsersForm_Closed(object sender, FormClosedEventArgs e)
        {
            Form1 mainform = new Form1();
            mainform.Show();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            SettingsForm adduserform1 = new SettingsForm();
            adduserform1.Show();
            Hide();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            
            int n = 0;
            string sql = "";
            while (n<writes.GetLength(1))
            {
                if (delete[n].Checked)
                {
                    sql += "exec deleteuser @username = '" + txtbox[0, n].Text + "', @usersurname = '" + txtbox[5, n].Text + "'; ";                    
                    n++;
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (i != 3 && i != 4)
                        {

                            if (writes[i, n].Equals(txtbox[i, n].Text))
                            {

                            }
                            else
                            {
                                if ((txtbox[0, n].Text.Equals("")) || (txtbox[5, n].Text.Equals("")))
                                {
                                    MessageBox.Show("Фамилия либо имя пользователя не могут быть пустыми, заполните их");
                                    for (int k = 0; k < 7; k++)
                                    {
                                        if (txtbox[k, n] != null) txtbox[k, n].BackColor = Color.Red;
                                    }
                                    break;
                                }
                                else if (n != (writes.GetLength(1) - 1))
                                {
                                    sql += (sqlupdateusers(n));
                                    break;
                                }
                                else
                                {
                                    sql += (sqlinsertusers(n));
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (writes[i, n].Equals(timebox[i, n].Text)) { }
                            else
                            {
                                if ((txtbox[0, n].Text.Equals("")) || (txtbox[5, n].Text.Equals("")))
                                {
                                    MessageBox.Show("Фамилия либо имя пользователя не могут быть пустыми, заполните их");
                                    for (int k = 0; k < 6; k++)
                                    {
                                        if (txtbox[k, n] != null) txtbox[k, n].BackColor = Color.Red;
                                    }
                                    break;
                                }
                                else if (n != (writes.GetLength(1) - 1))
                                {                                    
                                    sql+=(sqlupdateusers(n));                                  
                                    break;
                                }
                                else
                                {
                                    sql += (sqlinsertusers(n));
                                    break;
                                }
                            }                            
                        }
                    }
                    if (updatelate[n].Checked)
                    {
                        sql += "exec updatelates @username='" + txtbox[5, n].Text + "'; ";
                        sql += "exec WorkTimeUpdate @username='" + txtbox[5, n].Text + "'; ";                        
                    }
                    n++;
                }
            }
            execsql(sql);
            this.writes = null;
            this.txtbox = null;
            this.timebox = null;
            this.Controls.OfType<TextBox>().ToList().ForEach(t => this.Controls.Remove(t));
            this.Controls.OfType<DateTimePicker>().ToList().ForEach(t => this.Controls.Remove(t));
            this.Controls.OfType<CheckBox>().ToList().ForEach(t => this.Controls.Remove(t));
            UsersForm_Load(sender, e);
        }
        public string sqlupdateusers(int n)
        {
            string sql;
            sql = "exec UpdateDBUserLoginUsers @surname='" + txtbox[0, n].Text + "', @name='" + txtbox[1, n].Text + "', ";
            sql += "@secondname ='" + txtbox[2, n].Text + "', @workstart='" + timebox[3, n].Text + "', ";
            sql += "@workend ='" + timebox[4, n].Text + "', @username1='" + txtbox[5, n].Text + "', @computername='"+ txtbox[6,n].Text+"', ";
            sql += "@oldsurname = '"+writes[0,n]+ "', @oldusername='" + writes[5, n] + "'; ";
            return sql;
        }
        public string sqlinsertusers(int n)
        {
            string sql;
            sql = "exec InsertDBUserLoginUsers @surname='" + txtbox[0, n].Text + "', @name='" + txtbox[1, n].Text + "', ";
            sql += "@secondname ='" + txtbox[2, n].Text + "', @workstart='" + timebox[3, n].Text + "', ";
            sql += "@workend ='" + timebox[4, n].Text + "', @username1='" + txtbox[5, n].Text + "', @computername='" + txtbox[6, n].Text + "'; ";
            return sql;
        }
        public void execsql (string sql)
        {
            Form1 mainform = new Form1();
            SqlConnection myConnection = new SqlConnection(Program.sqlstring);
            
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                myCommand.CommandTimeout = 0;
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.ToString());

                myConnection.Close();
            }
        }

        private void UpdateIsLate_Click(object sender, EventArgs e)
        {

        }
    }
}
  

