using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {
     
        public SqlConnection con;
        String connetionString = null;

        Key key;

        public Form1()
        {
            InitializeComponent();
            password.PasswordChar='*';
            key = new Key();
            connetionString = "Data Source=mD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True;connection timeout=5";
             con = new SqlConnection(connetionString);
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            if (username.Text != string.Empty && password.Text != string.Empty)
            {
                                                    
                 
                SqlDataAdapter check = new SqlDataAdapter("SELECT COUNT(*) FROM dbo.employees WHERE iD='" + username.Text + "'", con);
                DataTable dt1 = new DataTable();

                check.Fill(dt1);



                if (Int32.Parse(dt1.Rows[0][0].ToString()) != 0)
                {
                    string sql = "SELECT type FROM sys.server_principals WHERE name = '" + username.Text + "';";
                    //SqlCommand cmnd1 = new SqlCommand(sql, con);                    
                    SqlDataAdapter type = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable(); //this is creating a virtual table  
                    type.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "S")
                    {
                        int a = login();
                        if (a == 0)
                        {
                            MessageBox.Show("Таны нэр эсвэл нууц үг буруу байна !!!");
                        }
                        else
                        {
                            Нүүр nvvr = new Нүүр(username.Text.ToString());
                            this.Hide();
                            nvvr.ShowDialog();
                            password.Text = "";
                        }

                    }
                    con.Close();
                }
                else
                    MessageBox.Show("Таны нэр эсвэл нууц үг буруу байна !!!");
            
            }
           

            else
            {
                MessageBox.Show("   Ta iD болон нууц үгээ оруулна уу !!!");
                password.Text = "";
                username.Text = "";
            }
        }        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void h_nemeh_Click(object sender, EventArgs e)
        {
        
            
        }

        private void erh_hynah_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void тусламжToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandText = @"C:\Users\md\Documents\User.chm";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        public int login() {
         
            String hash;
            hash = key.MD5Hash(password.Text.ToString());
          

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM dbo.employees WHERE iD='" + username.Text + "' and Password = '" + hash + "' ", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);



            if (Int32.Parse(dt.Rows[0][0].ToString()) != 0)
        
                {

                    return 1;
                }
                else
                    return 0;
              


        }
    }
}
