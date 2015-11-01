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
    public partial class Хасах : Form
    {
        String name;
        SqlConnection con;
        public Хасах(String Name)
        {
            InitializeComponent();
            this.name = Name;
            string connetionString = null;
            connetionString = "Data Source=MD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
            //connetionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
             con = new SqlConnection(connetionString);
            conn();

        }
        void conn() {
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
        private void Хасах_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Нүүр nvvr = new Нүүр(name);
            this.Hide();
            nvvr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Row = dataGridView1.CurrentRow.Index;
            String ID = dataGridView1[0, Row].Value.ToString();
           
            
            int affectedRows = 0;
            string connetionString = null;
            connetionString = "Data Source=MD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
            // connetionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand();

            //string myQuery = "INSERT INTO dbo.Employees (Name, DoB, Gender, Address, AddedBy, AddedDate) VALUES(@Name, @DoB, @Gender, @Address, @AddedBy, @AddedDate)";
            string myQuery = "dbo.deleteEmployee";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = myQuery;
            cmd.Parameters.Add("@id", SqlDbType.NChar);

            cmd.Parameters["@id"].Value = ID;
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
                    MessageBox.Show("Амжилттай устгалаа ");
                  
                

                    cmd.Dispose();
                    con.Close();

                }
                else if (affectedRows != 0)
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
            conn();
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
