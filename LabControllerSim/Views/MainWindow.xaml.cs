using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Windows;


namespace LabControllerSim.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(!IsRunAsAdministrator())
            {
                Process p = new Process();
                p.StartInfo.FileName = $"{Directory.GetCurrentDirectory()}\\LabControllerSim.exe";
                p.StartInfo.Arguments = "";
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.Verb = "runas";
                try
                {
                    p.Start();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Aplikacja musi być uruchomiona z uprawnieniami administratora");
                }
                Application.Current.Shutdown();
            }

         /*   if (!IsRunAsAdministrator())
            {
                var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);

                // The following properties run the new process as administrator
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";

                // Start the new process
                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception)
                {
                    // The user did not allow the application to run as administrator
                    MessageBox.Show("Sorry, this application must be run as Administrator.");
                }

                // Shut down the current process
                Application.Current.Shutdown();
            }*/
        }



        private bool IsRunAsAdministrator()
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);

            return wp.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}

