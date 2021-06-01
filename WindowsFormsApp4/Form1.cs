using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        UpdateManager manager;
        public Form1()
        {
            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            //    MessageBox.Show("Debugger");
            //}
            //else
            //{
            //    MessageBox.Show("not debugger");
            //}
            if (Debugger.IsAttached)
            {
                MessageBox.Show("Debugger");
                // Since there is a debugger attached, assume we are running from the IDE
            }
            else
            {
                MessageBox.Show("not debugger");

                // Assume we aren't running from the IDE
            }
            update();

            InitializeComponent();
        }
        static async void update()
        {
            using (var manager = new UpdateManager(@"https://sentryinstaller20210415161325.azurewebsites.net/squirrel/"))
            {
                await manager.UpdateApp();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("yehey");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("updated");
        }
    }
}
