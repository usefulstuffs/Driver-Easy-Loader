using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace Driver_Easy_Loader
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (hasAdministrativeRight)
            {
                variables.isadmin = true;
            }
            Application.Run(new Form1());
        }
    }
}
