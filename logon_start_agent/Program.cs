using System;

using System.Diagnostics;

using System.IO;
using System.Reflection;
using System.Windows.Forms;



namespace logon_start_agent

{

    class logon_start_agent

    {

        static void Main(string[] args)

        {
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String strFullPathToMyFile = Path.Combine(appdata+"\\logon", "logon_agent.exe");
            try
            {
                Process.Start(strFullPathToMyFile);
            }
            catch (Exception e)
            {
               //MessageBox.Show(strFullPathToMyFile+"\n\n\n"+e.ToString());
            }
            Application.Exit();        

        }

    }

}
