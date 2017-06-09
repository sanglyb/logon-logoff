namespace logon_agent
{
    partial class Setup
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
            this.security = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.catalog = new System.Windows.Forms.TextBox();
            this.db = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.default_time_picker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // security
            // 
            this.security.FormattingEnabled = true;
            this.security.Items.AddRange(new object[] {
            "true",
            "false"});
            this.security.Location = new System.Drawing.Point(126, 63);
            this.security.Name = "security";
            this.security.Size = new System.Drawing.Size(375, 21);
            this.security.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Пользователь";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Безопасность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "База данных";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Сервер";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(198, 143);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(303, 23);
            this.save.TabIndex = 19;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click_1);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(126, 116);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(375, 20);
            this.password.TabIndex = 18;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(126, 90);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(375, 20);
            this.user.TabIndex = 17;
            // 
            // catalog
            // 
            this.catalog.Location = new System.Drawing.Point(126, 38);
            this.catalog.Name = "catalog";
            this.catalog.Size = new System.Drawing.Size(375, 20);
            this.catalog.TabIndex = 16;
            // 
            // db
            // 
            this.db.Location = new System.Drawing.Point(126, 12);
            this.db.Name = "db";
            this.db.Size = new System.Drawing.Size(375, 20);
            this.db.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Время бездействия";
            // 
            // default_time_picker
            // 
            this.default_time_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.default_time_picker.Location = new System.Drawing.Point(126, 143);
            this.default_time_picker.Name = "default_time_picker";
            this.default_time_picker.ShowUpDown = true;
            this.default_time_picker.Size = new System.Drawing.Size(68, 20);
            this.default_time_picker.TabIndex = 29;
            this.default_time_picker.Value = new System.DateTime(2016, 6, 1, 0, 0, 5, 0);
            this.default_time_picker.ValueChanged += new System.EventHandler(this.default_time_picker_ValueChanged);
            // 
            // Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 178);
            this.Controls.Add(this.default_time_picker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.security);
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
            this.Name = "Setup";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.Setup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox security;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox catalog;
        private System.Windows.Forms.TextBox db;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker default_time_picker;
    }
}