namespace login_logoff
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dbUserLoginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.UsersButton = new System.Windows.Forms.Button();
            this.startdate = new System.Windows.Forms.DateTimePicker();
            this.enddate = new System.Windows.Forms.DateTimePicker();
            this.supportmvcDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UpdateBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SettingsBut = new System.Windows.Forms.Button();
            this.userstats = new System.Windows.Forms.Label();
            this.checkPodrobn = new System.Windows.Forms.CheckBox();
            this.graphshow = new System.Windows.Forms.Button();
            this.graphic = new System.Windows.Forms.Panel();
            this.scale_plus = new System.Windows.Forms.Button();
            this.scale_minus = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbUserLoginBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supportmvcDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dbUserLoginBindingSource
            // 
            this.dbUserLoginBindingSource.DataMember = "DbUserLogin";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(641, 79);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(146, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Учитывать RDP сессии";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(641, 147);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "все пользователи";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(641, 100);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(156, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Показывать все события";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // UsersButton
            // 
            this.UsersButton.Location = new System.Drawing.Point(641, 175);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(197, 23);
            this.UsersButton.TabIndex = 10;
            this.UsersButton.Text = "Пользователи";
            this.UsersButton.UseVisualStyleBackColor = true;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            // 
            // startdate
            // 
            this.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startdate.Location = new System.Drawing.Point(641, 53);
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(88, 20);
            this.startdate.TabIndex = 11;
            this.startdate.ValueChanged += new System.EventHandler(this.startdate_ValueChanged);
            // 
            // enddate
            // 
            this.enddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.enddate.Location = new System.Drawing.Point(753, 53);
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(88, 20);
            this.enddate.TabIndex = 12;
            this.enddate.ValueChanged += new System.EventHandler(this.enddate_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(622, 492);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.order_changed);
            // 
            // UpdateBut
            // 
            this.UpdateBut.Location = new System.Drawing.Point(641, 205);
            this.UpdateBut.Name = "UpdateBut";
            this.UpdateBut.Size = new System.Drawing.Size(197, 23);
            this.UpdateBut.TabIndex = 15;
            this.UpdateBut.Text = "Обновить";
            this.UpdateBut.UseVisualStyleBackColor = true;
            this.UpdateBut.Click += new System.EventHandler(this.UpdateBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(645, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Дата начала";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(761, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Дата конца";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(735, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "-";
            // 
            // SettingsBut
            // 
            this.SettingsBut.Location = new System.Drawing.Point(641, 234);
            this.SettingsBut.Name = "SettingsBut";
            this.SettingsBut.Size = new System.Drawing.Size(197, 23);
            this.SettingsBut.TabIndex = 19;
            this.SettingsBut.Text = "Настройки";
            this.SettingsBut.UseVisualStyleBackColor = true;
            this.SettingsBut.Click += new System.EventHandler(this.SettingsBut_Click);
            // 
            // userstats
            // 
            this.userstats.AutoSize = true;
            this.userstats.Location = new System.Drawing.Point(641, 240);
            this.userstats.Name = "userstats";
            this.userstats.Size = new System.Drawing.Size(0, 13);
            this.userstats.TabIndex = 20;
            // 
            // checkPodrobn
            // 
            this.checkPodrobn.AutoSize = true;
            this.checkPodrobn.Location = new System.Drawing.Point(641, 123);
            this.checkPodrobn.Name = "checkPodrobn";
            this.checkPodrobn.Size = new System.Drawing.Size(157, 17);
            this.checkPodrobn.TabIndex = 21;
            this.checkPodrobn.Text = "Показывать подробности";
            this.checkPodrobn.UseVisualStyleBackColor = true;
            this.checkPodrobn.CheckedChanged += new System.EventHandler(this.checkPodrobn_CheckedChanged);
            this.checkPodrobn.Click += new System.EventHandler(this.checkPodrobn_Click);
            // 
            // graphshow
            // 
            this.graphshow.Location = new System.Drawing.Point(641, 263);
            this.graphshow.Name = "graphshow";
            this.graphshow.Size = new System.Drawing.Size(197, 23);
            this.graphshow.TabIndex = 22;
            this.graphshow.Text = "Показать в виде графика";
            this.graphshow.UseVisualStyleBackColor = true;
            this.graphshow.Click += new System.EventHandler(this.graphshow_Click);
            // 
            // graphic
            // 
            this.graphic.BackColor = System.Drawing.SystemColors.Window;
            this.graphic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphic.Location = new System.Drawing.Point(13, 18);
            this.graphic.Name = "graphic";
            this.graphic.Size = new System.Drawing.Size(600, 477);
            this.graphic.TabIndex = 23;
            this.graphic.Visible = false;
            this.graphic.Paint += new System.Windows.Forms.PaintEventHandler(this.graphic_Paint_1);
            // 
            // scale_plus
            // 
            this.scale_plus.Location = new System.Drawing.Point(645, 12);
            this.scale_plus.Name = "scale_plus";
            this.scale_plus.Size = new System.Drawing.Size(24, 23);
            this.scale_plus.TabIndex = 0;
            this.scale_plus.Text = "+";
            this.scale_plus.UseVisualStyleBackColor = true;
            this.scale_plus.Click += new System.EventHandler(this.scale_plus_Click);
            // 
            // scale_minus
            // 
            this.scale_minus.Location = new System.Drawing.Point(675, 12);
            this.scale_minus.Name = "scale_minus";
            this.scale_minus.Size = new System.Drawing.Size(24, 23);
            this.scale_minus.TabIndex = 1;
            this.scale_minus.Text = "-";
            this.scale_minus.UseVisualStyleBackColor = true;
            this.scale_minus.Click += new System.EventHandler(this.scale_minus_Click);
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(642, 292);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(196, 23);
            this.about.TabIndex = 24;
            this.about.Text = "О программе";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 522);
            this.Controls.Add(this.about);
            this.Controls.Add(this.scale_minus);
            this.Controls.Add(this.scale_plus);
            this.Controls.Add(this.graphic);
            this.Controls.Add(this.graphshow);
            this.Controls.Add(this.checkPodrobn);
            this.Controls.Add(this.userstats);
            this.Controls.Add(this.SettingsBut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpdateBut);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.enddate);
            this.Controls.Add(this.startdate);
            this.Controls.Add(this.UsersButton);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(867, 5000);
            this.MinimumSize = new System.Drawing.Size(867, 561);
            this.Name = "Form1";
            this.Text = "Logon-Logoff";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dbUserLoginBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supportmvcDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.BindingSource dbUserLoginBindingSource;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button UsersButton;
        private System.Windows.Forms.DateTimePicker startdate;
        private System.Windows.Forms.DateTimePicker enddate;
        private System.Windows.Forms.BindingSource supportmvcDataSetBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button UpdateBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SettingsBut;
        private System.Windows.Forms.Label userstats;
        private System.Windows.Forms.CheckBox checkPodrobn;
        private System.Windows.Forms.Button graphshow;
        private System.Windows.Forms.Panel graphic;
        private System.Windows.Forms.Button scale_minus;
        private System.Windows.Forms.Button scale_plus;
        private System.Windows.Forms.Button about;
    }
}

