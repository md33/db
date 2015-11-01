using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Нүүр : Form
    {
        public String name;
        public SqlConnection con;
        public int id;
        public Нүүр(String name)
        {
            InitializeComponent();
            this.name = name;
            String connetionString = null;
        
            connetionString = "Data Source=mD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
            con = new SqlConnection(connetionString);
           
         
            check();

        }
        void uncheck() {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        void check() {
            uncheck();
            con.Open();
          
            string sql1 = "select principal_id from sys.database_principals where name = '" + name + "';";
           

            SqlCommand cmnd = new SqlCommand(sql1, con);
            SqlDataReader reader = cmnd.ExecuteReader();
            while (reader.Read())
            {
                id = Int16.Parse(reader[0].ToString());
                //MessageBox.Show(id.ToString());
            }
            reader.Close();
            string sql = "select type from sys.database_permissions WHERE grantee_principal_id = '" + id + "';";
            SqlCommand cmnd1 = new SqlCommand(sql, con);
            SqlDataReader reader1 = cmnd1.ExecuteReader();
            while (reader1.Read())
            {
                string s = reader1[0].ToString();
                s = s.Trim();
                switch (s)
                {
               
                    case "IN":
                        button1.Enabled = true;
                        break;                 
                    case "UP":
                        button3.Enabled = true;
                        break;
                    case "DL":
                        button2.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            String admin = "ADMIN";
            if (admin.Equals(name.ToString()))
            {
                button4.Enabled = true;
            }
            reader1.Close();
            con.Close();
        }
        private void системToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void буцахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandText = @"C:\Users\md\Documents\User.chm";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        private void тусламжToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();

        }

        private void Нүүр_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Бүртгүүлэх bvrt = new Бүртгүүлэх(name);
            this.Hide();
            bvrt.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Эрх erh = new Эрх(name);
            this.Hide();
            erh.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Хасах hasah = new Хасах(name);
            this.Hide();
            hasah.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Тайлан tailan = new Тайлан();
            this.Hide();
            tailan.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Өөрчлөх oorchloh = new Өөрчлөх(name);
            this.Hide();
            oorchloh.ShowDialog();
        }

        private void хэрэглэгчийнМэдээлэлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ӨМэдээлэл news = new ӨМэдээлэл(name);
            news.ShowDialog();
           
        }
    }
}
