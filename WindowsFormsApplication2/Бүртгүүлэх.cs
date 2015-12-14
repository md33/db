using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Бүртгүүлэх : Form
    {
        public String name;
        SqlConnection con;
        Key key;

        public Бүртгүүлэх(String name)
        {
            InitializeComponent();
            this.name = name;
            Aname.Hide();
            Aname.Text = name;
            password1.PasswordChar = '*';
            password.PasswordChar = '*';
            String connetionString = null;
            connetionString = "Data Source=MD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
            con = new SqlConnection(connetionString);
            key = new Key();


        }

        private void butsah_Click(object sender, EventArgs e)
        {

            Нүүр nvvr = new Нүүр(name);
            this.Hide();
            nvvr.ShowDialog();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Бүртгүүлэх_Load(object sender, EventArgs e)
        {

        }

        private void bvrtgvvleh_Click(object sender, EventArgs e)
        {
            if (id.Text != string.Empty && dob.Text != string.Empty && lname.Text != string.Empty && fname.Text != string.Empty && gender.Text != string.Empty && password.Text != string.Empty)
            {


                if (password.Text.Equals(password1.Text))
                {

                    int affectedRows = 0;
                    int error = 0;

                    // connetionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

                    SqlCommand cmd = new SqlCommand();

                    //string myQuery = "INSERT INTO dbo.Employees (Name, DoB, Gender, Address, AddedBy, AddedDate) VALUES(@Name, @DoB, @Gender, @Address, @AddedBy, @AddedDate)";
                    string myQuery = "InsertNewEmployee";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = myQuery;
                    cmd.Parameters.Add("@id", SqlDbType.NChar);
                    cmd.Parameters.Add("@dob", SqlDbType.Date);
                    cmd.Parameters.Add("@lname", SqlDbType.NChar);
                    cmd.Parameters.Add("@fname", SqlDbType.NChar);
                    cmd.Parameters.Add("@gender", SqlDbType.NChar);
                    cmd.Parameters.Add("@age", SqlDbType.Int);
                    cmd.Parameters.Add("@added", SqlDbType.DateTime);
                    cmd.Parameters.Add("@addedBy", SqlDbType.NChar);
                    cmd.Parameters.Add("@password", SqlDbType.NChar);
                    cmd.Parameters["@id"].Value = id.Text;
                    cmd.Parameters["@dob"].Value = dob.Text;
                    cmd.Parameters["@lname"].Value = lname.Text;
                    cmd.Parameters["@fname"].Value = fname.Text;
                    cmd.Parameters["@gender"].Value = gender.Text;
                    cmd.Parameters["@age"].Value = age.Text;
                    cmd.Parameters["@added"].Value = DateTime.Now;
                    cmd.Parameters["@addedBy"].Value = Aname.Text;
                    String hash;
                     hash = key.MD5Hash(password.Text);
                    cmd.Parameters["@password"].Value = hash;
                    SqlParameter sqlP = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                    sqlP.Direction = ParameterDirection.ReturnValue;
                    SqlCommand cmd1 = new SqlCommand();
                    string myQuery1 = "createLogin";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = myQuery1;
                    cmd1.Parameters.Add("@id", SqlDbType.NChar);
                    cmd1.Parameters["@id"].Value = id.Text;
                    SqlParameter sqlP1 = cmd1.Parameters.Add("@ReturnValue", SqlDbType.Int);
                    sqlP1.Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        cmd1.Connection = con;
                        cmd.Connection = con;                   
                        con.Open();
                        
                        cmd.ExecuteNonQuery();                       
                        affectedRows = (int)cmd.Parameters["@ReturnValue"].Value;
                        cmd1.ExecuteNonQuery();
              
                        error = (int)cmd1.Parameters["@ReturnValue"].Value;

                        if (affectedRows == 0 && error ==1)
                        {
                            MessageBox.Show("Амжилттай хадгалагдлаа");

                            id.Text = "";
                            dob.Text = DateTime.Now.Date.ToShortDateString();
                            lname.Text = "";
                            fname.Text = "";
                            gender.Text = "";
                            age.Text = "";
                            password.Text = "";
                            password1.Text = "";

                            con.Close();
                            this.Hide();                            

                        }

                            MessageBox.Show("Хадгалагдсангүй", "Алдаа");
                        
                 

                            cmd.Dispose();
                            con.Close();

                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        cmd.Dispose();
                        con.Close();

                    }
                }
            }
            else
            {
                MessageBox.Show("Та бүх мэдээлэлээ үнэн зөв бөглөнө үү !!!");
            }
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
