using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Driver_Easy_Loader;
using System.Reflection;
using System.Diagnostics;
using Driver_Easy_Loader.Properties;

namespace Driver_Easy_Loader
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Easeware\DriverEasy\License.dat"))
            {
                label2.Text = "Driver Easy Status: Licensed";
            }
            else
            {
                label2.Text = "Driver Easy Status: Free Version";
            }
            label1.Text = "Version: " + Application.ProductVersion;
        }

        private void button1_Click(object sender, EventArgs e)
        { 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) //user choice: Kill Driver Easy automatically, may require admin privileges
            {
                foreach (var process in Process.GetProcessesByName("DriverEasy"))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                        MessageBox.Show("Can't kill Driver Easy. Patching aborted","Driver Easy Loader by Vichingo455",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Make sure to quit Driver Easy, then hit OK to start patching","Driver Easy Loader by Vichingo455",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            try
            {
                string[] dirs = Directory.GetDirectories(@"C:\Users", "*", SearchOption.TopDirectoryOnly);
                foreach (string dir in dirs)
                {
                    if (Directory.Exists(dir + @"\AppData\Roaming\Easeware\DriverEasy"))
                    {
                        if (File.Exists(dir + @"\AppData\Roaming\Easeware\DriverEasy\License.dat"))
                        {
                            File.Delete(dir + @"\AppData\Roaming\Easeware\DriverEasy\License.dat");
                        }
                        File.WriteAllBytes(dir + @"\AppData\Roaming\Easeware\DriverEasy\License.dat", Resources.License);
                    }
                }
                File.Copy("C:\\Windows\\System32\\Drivers\\etc\\Hosts", "C:\\Windows\\System32\\Drivers\\etc\\Hosts.backup",true);
                File.AppendAllText("C:\\Windows\\System32\\Drivers\\etc\\Hosts", Environment.NewLine + "127.0.0.1 app.drivereasy.com");
                File.AppendAllText("C:\\Windows\\System32\\Drivers\\etc\\Hosts", Environment.NewLine + "127.0.0.1 cdn.drivereasy.com");
            }
            catch
            {
                MessageBox.Show("An error occured, please report it as issue on GitHub.", "Driver Easy Loader by Useful Stuffs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Patch successful!","Driver Easy Loader by Useful Stuffs",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) //user choice: Kill Driver Easy automatically, may require admin privileges
            {
                foreach (var process in Process.GetProcessesByName("DriverEasy"))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                        MessageBox.Show("Can't kill Driver Easy. Patching aborted", "Driver Easy Loader by Vichingo455", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Make sure to quit Driver Easy, then hit OK to start patching", "Driver Easy Loader by Vichingo455", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                string[] dirs = Directory.GetDirectories(@"C:\Users", "*", SearchOption.TopDirectoryOnly);
                foreach (string dir in dirs)
                {
                    if (Directory.Exists(dir + @"\AppData\Roaming\Easeware\DriverEasy"))
                    {
                        if (File.Exists(dir + @"\AppData\Roaming\Easeware\DriverEasy\License.dat"))
                        {
                            File.Delete(dir + @"\AppData\Roaming\Easeware\DriverEasy\License.dat");
                        }
                    }
                }
                File.Copy("C:\\Windows\\System32\\Drivers\\etc\\Hosts", "C:\\Windows\\System32\\Drivers\\etc\\Hosts.old");
                File.Copy("C:\\Windows\\System32\\Drivers\\etc\\Hosts.backup", "C:\\Windows\\System32\\Drivers\\etc\\Hosts", true);
                File.Delete("C:\\Windows\\System32\\Drivers\\etc\\Hosts.backup");
            }
            catch
            {
                MessageBox.Show("An error occured, please report it as issue on GitHub.", "Driver Easy Loader by Useful Stuffs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Loader uninstalled successfully","Driver Easy Loader by Useful Stuffs",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Environment.Exit(0);
        }
    }
}
