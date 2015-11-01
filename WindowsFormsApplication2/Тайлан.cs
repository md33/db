using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Тайлан : Form
    {
        private object webBrowser1;

        public Тайлан( )
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Нүүр nvvr = new Нүүр("");
            this.Hide();
            nvvr.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void тусламжToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string commandText = @"C:\Users\md\Documents\User.chm";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();

        }
    }
}
