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
    public partial class Өөрчлөх : Form
    {
        SqlConnection con;
    
        String Fname, Lname, Age, Gender, DOB ,ID ,name;
      
        public Өөрчлөх(String name)
        {
            InitializeComponent();
            this.name = name;
            data();
            
            


        }

        private void тусламжToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandText = @"C:\Users\md\Documents\User.chm";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        void data()
        {
            string connetionString = null;
            connetionString = "Data Source=MD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
            //connetionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            con = new SqlConnection(connetionString);
            string myQuery = "SELECT * FROM dbo.Employees";
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Нүүр nvvr = new Нүүр(name);
            this.Hide();
            nvvr.ShowDialog();
        }

        private void Өөрчлөх_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DB.Text = dataGridView1[1, e.RowIndex].FormattedValue.ToString();
                DOB = dataGridView1[1, e.RowIndex].FormattedValue.ToString();
                

                textBox2.Text = dataGridView1[2, e.RowIndex].FormattedValue.ToString();
                Lname = dataGridView1[2, e.RowIndex].FormattedValue.ToString();

                textBox3.Text = dataGridView1[3, e.RowIndex].FormattedValue.ToString();
                Fname = dataGridView1[3, e.RowIndex].FormattedValue.ToString();

                 Gender = dataGridView1[4, e.RowIndex].FormattedValue.ToString().Trim();
                comboBox1.Text = dataGridView1[4, e.RowIndex].FormattedValue.ToString().Trim();
                if (Gender == "Male")
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }
                textBox4.Text = dataGridView1[5, e.RowIndex].FormattedValue.ToString();
                Age = dataGridView1[5, e.RowIndex].FormattedValue.ToString();
                textBox1.Text = dataGridView1[0, e.RowIndex].FormattedValue.ToString();
                ID = dataGridView1[0, e.RowIndex].FormattedValue.ToString();

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("1'" + Lname + "'", textBox2.Text.ToString());
            //MessageBox.Show("2'" + Fname + "'", textBox3.Text.ToString());
            //MessageBox.Show("3'" + Age + "'", textBox4.Text.ToString());
            //MessageBox.Show("4'" + Gender + "'", comboBox1.Text.ToString());

            if (Lname.Equals(textBox2.Text) && Fname.Equals(textBox3.Text) && Age.Equals(textBox4.Text) && Gender.Equals(comboBox1.Text))
                    {
                    MessageBox.Show("Өөрчлөлт хийгдээгүй байна");
                }
                    else {


                int affectedRows = 0;
                string connetionString = null;
                connetionString = "Data Source=MD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
                // connetionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                SqlConnection con = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand();

                //string myQuery = "INSERT INTO dbo.Employees (Name, DoB, Gender, Address, AddedBy, AddedDate) VALUES(@Name, @DoB, @Gender, @Address, @AddedBy, @AddedDate)";
                string myQuery = "dbo.UpdateEmployees";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = myQuery;
                cmd.Parameters.Add("@id", SqlDbType.NChar);
                cmd.Parameters.Add("@dob", SqlDbType.Date);
                cmd.Parameters.Add("@lname", SqlDbType.NChar);
                cmd.Parameters.Add("@fname", SqlDbType.NChar);
                cmd.Parameters.Add("@gender", SqlDbType.NChar);
                cmd.Parameters.Add("@age", SqlDbType.Int);

                cmd.Parameters["@id"].Value = textBox1.Text;
                cmd.Parameters["@dob"].Value = DB.Value;
                cmd.Parameters["@lname"].Value = textBox2.Text;
                cmd.Parameters["@fname"].Value = textBox3.Text;
                cmd.Parameters["@gender"].Value = comboBox1.Text;
                cmd.Parameters["@age"].Value = Int32.Parse(textBox4.Text);

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
                        cmd.Dispose();
                        con.Close();
                        data();
                    }
                    else if (affectedRows == 1)
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
            }
          
        }
    }
}
