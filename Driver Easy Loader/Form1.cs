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
            string LoaderPath = @"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy\License.dat";
            if (File.Exists(LoaderPath))
            {
                variables.isloaderinstalled = true;
            }
            string licensepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Easeware\DriverEasy\License.dat";
            if (File.Exists(licensepath))
            {
                variables.islicenseinstalled = true;
            }
            label1.Text = "Version: " + Application.ProductVersion.ToString();
            if (variables.isadmin)
            {
                label2.Text = "Running as admin: Yes";
                button1.Visible = false;
            }
            else 
            {
                label2.Text = "Running as admin: No";
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                checkBox1.Enabled = false;
            }
            if (variables.islicenseinstalled)
            {
                label3.Text = "License installed: Yes";
            }
            else
            {
                label3.Text = "License installed: No";
            }
            if (variables.isloaderinstalled)
            {
                label4.Text = "Loader installed: Yes";
            }
            else
            {
                label4.Text = "Loader installed: No";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Some settings require admin privileges. To enable them, restart the program as administrator","Why are some settings unavailable?");
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
            if (radioButton1.Checked)
            {
                try
                {
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Easeware\DriverEasy\License.dat")) //delete existing license
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Easeware\DriverEasy\License.dat");
                    }
                    File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Easeware\DriverEasy\License.dat",Resources.License);
                }
                catch
                {
                    MessageBox.Show("Can't patch Driver Easy. Make sure that Driver Easy is installed and closed","Driver Easy Loader",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            else if (radioButton2.Checked)
            {
                try
                {
                    if (!Directory.Exists(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy"))
                    {
                        Directory.CreateDirectory(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy");
                    }
                    if (File.Exists(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy\License.dat"))
                    {
                        File.Delete(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy\License.dat");
                    }
                    File.WriteAllBytes(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy\License.dat", Resources.License);
                }
                catch
                {
                    MessageBox.Show("Can't patch Driver Easy. Make sure that Driver Easy is installed and closed", "Driver Easy Loader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (radioButton3.Checked)
            {
                try
                {
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Easeware\DriverEasy\License.dat")) //delete existing license
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Easeware\DriverEasy\License.dat");
                    }
                    File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Easeware\DriverEasy\License.dat", Resources.License);
                    if (!Directory.Exists(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy"))
                    {
                        Directory.CreateDirectory(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy");
                    }
                    if (File.Exists(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy\License.dat"))
                    {
                        File.Delete(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy\License.dat");
                    }
                    File.WriteAllBytes(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy\License.dat", Resources.License);
                }
                catch
                {
                    MessageBox.Show("Can't patch Driver Easy. Make sure that Driver Easy is installed and closed", "Driver Easy Loader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Patch successful!","Driver Easy Loader by Vichingo455",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Easeware\DriverEasy\License.dat")) //delete existing license
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Easeware\DriverEasy\License.dat");
                }
                if (Directory.Exists(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy"))
                {
                    Directory.Delete(@"C:\Users\Default\AppData\Roaming\Easeware\DriverEasy");
                }
            }
            catch
            {
                MessageBox.Show("Can't uninstall the loader. Was it installed in the past? Is Driver Easy Installed and Closed?","Driver Easy Loader by Vichingo455",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Loader uninstalled successfully","Driver Easy Loader by Vichingo455",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Environment.Exit(0);
        }
    }
}
