namespace logon_server_service
{
    partial class ProjectInstaller
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.logon_server_service_instraller = new System.ServiceProcess.ServiceProcessInstaller();
            this.logon_server_service_installer = new System.ServiceProcess.ServiceInstaller();
            // 
            // logon_server_service_instraller
            // 
            this.logon_server_service_instraller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.logon_server_service_instraller.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.logon_server_service_installer});
            this.logon_server_service_instraller.Password = null;
            this.logon_server_service_instraller.Username = null;
            // 
            // logon_server_service_installer
            // 
            this.logon_server_service_installer.Description = "logon_server_service";
            this.logon_server_service_installer.DisplayName = "logon_server_service";
            this.logon_server_service_installer.ServiceName = "logon_server_service";
            this.logon_server_service_installer.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.logon_server_service_instraller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller logon_server_service_instraller;
        private System.ServiceProcess.ServiceInstaller logon_server_service_installer;
    }
}