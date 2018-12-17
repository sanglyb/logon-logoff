namespace login_logoff
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.db = new System.Windows.Forms.TextBox();
            this.catalog = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.security = new System.Windows.Forms.ComboBox();
            this.default_time_picker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.workStartTime = new System.Windows.Forms.DateTimePicker();
            this.workEndTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // db
            // 
            this.db.Location = new System.Drawing.Point(126, 13);
            this.db.Name = "db";
            this.db.Size = new System.Drawing.Size(375, 20);
            this.db.TabIndex = 1;
            // 
            // catalog
            // 
            this.catalog.Location = new System.Drawing.Point(126, 39);
            this.catalog.Name = "catalog";
            this.catalog.Size = new System.Drawing.Size(375, 20);
            this.catalog.TabIndex = 2;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(126, 91);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(375, 20);
            this.user.TabIndex = 4;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(126, 117);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(375, 20);
            this.password.TabIndex = 5;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(200, 171);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(301, 70);
            this.save.TabIndex = 6;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сервер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "База данных";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Безопасность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Пользователь";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Пароль";
            // 
            // date
            // 
            this.date.FormattingEnabled = true;
            this.date.Items.AddRange(new object[] {
            "Месяц",
            "Неделю",
            "День"});
            this.date.Location = new System.Drawing.Point(126, 144);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(375, 21);
            this.date.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Выводить за";
            // 
            // security
            // 
            this.security.FormattingEnabled = true;
            this.security.Items.AddRange(new object[] {
            "true",
            "false"});
            this.security.Location = new System.Drawing.Point(126, 64);
            this.security.Name = "security";
            this.security.Size = new System.Drawing.Size(375, 21);
            this.security.TabIndex = 14;
            // 
            // default_time_picker
            // 
            this.default_time_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.default_time_picker.Location = new System.Drawing.Point(126, 221);
            this.default_time_picker.Name = "default_time_picker";
            this.default_time_picker.ShowUpDown = true;
            this.default_time_picker.Size = new System.Drawing.Size(68, 20);
            this.default_time_picker.TabIndex = 31;
            this.default_time_picker.Value = new System.DateTime(2016, 6, 1, 0, 0, 5, 0);
            this.default_time_picker.ValueChanged += new System.EventHandler(this.default_time_picker_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Время бездействия";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Начало рабочего дня";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Конец рабочего дня";
            // 
            // workStartTime
            // 
            this.workStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.workStartTime.Location = new System.Drawing.Point(126, 171);
            this.workStartTime.Name = "workStartTime";
            this.workStartTime.ShowUpDown = true;
            this.workStartTime.Size = new System.Drawing.Size(68, 20);
            this.workStartTime.TabIndex = 34;
            this.workStartTime.Value = new System.DateTime(2016, 6, 1, 9, 0, 0, 0);
            // 
            // workEndTime
            // 
            this.workEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.workEndTime.Location = new System.Drawing.Point(126, 197);
            this.workEndTime.Name = "workEndTime";
            this.workEndTime.ShowUpDown = true;
            this.workEndTime.Size = new System.Drawing.Size(68, 20);
            this.workEndTime.TabIndex = 35;
            this.workEndTime.Value = new System.DateTime(2016, 6, 1, 18, 0, 0, 0);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 252);
            this.Controls.Add(this.workEndTime);
            this.Controls.Add(this.workStartTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.default_time_picker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.security);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.Controls.Add(this.catalog);
            this.Controls.Add(this.db);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.adduserform_closed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox db;
        private System.Windows.Forms.TextBox catalog;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox security;
        private System.Windows.Forms.DateTimePicker default_time_picker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker workStartTime;
        private System.Windows.Forms.DateTimePicker workEndTime;
    }
}