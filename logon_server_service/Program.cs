using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logon_server_service
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main(string[] args)
        {
            if ((args.Length > 0) && (args[0].Equals("/setup")))
            {
                  if (check_admin_rights.IsUserAdministrator())
                      Application.Run(new Setup());
                  else
                      MessageBox.Show("Для изменения настроек запустите программу от имени администратора");
                //Application.Run(new Setup());
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new logon_server_service()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
