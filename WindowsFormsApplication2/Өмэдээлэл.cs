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
    public partial class ӨМэдээлэл : Form
    {
        SqlConnection con;
        String name, ID, Lname, Fname, Gender, Added, Age, Password ,DOB ,addedBy;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
        }

        public ӨМэдээлэл(String id)
        {
            InitializeComponent();
            dataGridView1.Hide();

            string connetionString = null;
            this.name = id;
            connetionString = "Data Source=MD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
            con = new SqlConnection(connetionString);
            string myQuery = "SELECT * FROM dbo.Employees WHERE iD = '" + name + "'";
            SqlDataAdapter da = new SqlDataAdapter(myQuery, con);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                da.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();

            }
            ID = dataGridView1[0, 0].Value.ToString();

            Lname = dataGridView1[2, 0].Value.ToString();
            Fname = dataGridView1[3, 0].Value.ToString();
            Gender = dataGridView1[4, 0].Value.ToString();
            Age = dataGridView1[5, 0].Value.ToString();
            Added = dataGridView1[6, 0].Value.ToString();
            Password = dataGridView1[8, 0].Value.ToString();
            DOB = dataGridView1[1, 0].Value.ToString();
            addedBy = dataGridView1[7, 0].Value.ToString();
            textBox1.Text = ID;
            textBox2.Text = Lname;
            textBox3.Text = Fname;
            textBox4.Text = Gender;
            textBox5.Text = Age;
            textBox6.Text = Added;
            textBox7.Text = Password;

        }

        private void ӨМэдээлэл_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
         /*    if (ID == textBox1.Text && Lname == textBox2.Text && Fname == textBox3.Text && Gender == textBox4.Text && Age == textBox5.Text && Password == textBox7.Text)
             {
                 return;
             }
             else
             {
                 int affectedRows = 0;
              
                 SqlCommand cmd = new SqlCommand();
                 string myQuery = "dbo.updateEmployee";
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
                 cmd.Parameters["@id"].Value = textBox1.Text;
                 cmd.Parameters["@dob"].Value = DOB;
                 cmd.Parameters["@lname"].Value = textBox2.Text;
                 cmd.Parameters["@fname"].Value = textBox3.Text;
                 cmd.Parameters["@gender"].Value = textBox4.Text;
                 cmd.Parameters["@age"].Value = textBox5.Text;
                 cmd.Parameters["@added"].Value = Added;
                 cmd.Parameters["@addedBy"].Value = addedBy;
                 cmd.Parameters["@password"].Value = textBox7.Text;
                 SqlParameter sqlP = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                 sqlP.Direction = ParameterDirection.ReturnValue;
                 try
                 {
                     cmd.Connection = con;
                     con.Open();
                     cmd.ExecuteNonQuery();
                     affectedRows = (int)cmd.Parameters["@ReturnValue"].Value;
                     if (affectedRows == 0)
                     {
                         MessageBox.Show("Амжилттай хадгалагдлаа");
                         this.Hide();

                         cmd.Dispose();
                         con.Close();

                     }
                     else if (affectedRows == 555)
                     {
                         MessageBox.Show("Хадгалагдсангүй", "Алдаа");
                     }
                     else
                     {

                         cmd.Dispose();
                         con.Close();

                     }

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                     cmd.Dispose();
                     con.Close();

                 }
             }*/
        }
    }
}
