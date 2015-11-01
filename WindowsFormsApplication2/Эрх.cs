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
    public partial class Эрх : Form
    {
        SqlConnection con;
        String name,b;
        
        public int id;
        public Эрх(String Name)
        {
            InitializeComponent();
            this.name = Name;
            String connetionString = "Data Source=MD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
            con = new SqlConnection(connetionString);
            try
            {
                con.Open();
                String sql = "Select * from dbo.Employees";
                SqlCommand cmnd = new SqlCommand(sql, con);
                SqlDataReader reader = cmnd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Нүүр nvvr = new Нүүр(name);
            this.Hide();
            nvvr.ShowDialog();
        }

        private void Эрх_Load(object sender, EventArgs e)
        {

        }
  
        void uncheck()
        {
            select.Checked = false;
            update.Checked = false;
            delete.Checked = false;
            insert.Checked = false;

        }

        private void change(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {

                uncheck();
                string u_name = comboBox1.SelectedItem.ToString();
           
                try
                {

                    string sql1 = "select principal_id from sys.database_principals where name = '" + u_name + "';";
                    con.Open();

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
                                insert.Checked = true;
                                break;
                            case "UP":
                                update.Checked = true;
                                break;
                            case "DL":
                                delete.Checked = true;
                                break;
                            case "SL":
                                select.Checked = true;
                                break;
                            default:
                                break;
                        }
                    }
                    reader1.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                MessageBox.Show(comboBox1.SelectedItem.ToString());
                string sql;

                if (insert.Checked == true)
                    sql = "USE lab ; GRANT INSERT ON lab.dbo.Employees TO " + comboBox1.SelectedItem.ToString() + ";";
                else
                    sql = "USE lab ;REVOKE INSERT ON lab.dbo.Employees TO '" + comboBox1.SelectedItem.ToString() + "';";

                if (select.Checked == true)
                    sql += "USE lab ;GRANT SELECT ON lab.dbo.Employees TO " + comboBox1.SelectedItem.ToString() + ";";
                else
                    sql += "USE lab ;REVOKE SELECT ON lab.dbo.Employees TO " + comboBox1.SelectedItem.ToString() + ";";

                if (update.Checked == true)
                    sql += "USE lab ;GRANT UPDATE ON lab.dbo.Employees TO " + comboBox1.SelectedItem.ToString() + ";";
                else
                    sql += "USE lab ;REVOKE UPDATE ON lab.dbo.Employees TO " + comboBox1.SelectedItem.ToString() + ";";

                if (delete.Checked == true)
                    sql += "USE lab ;GRANT DELETE ON lab.dbo.Employees TO " + comboBox1.SelectedItem.ToString() + ";";
                else
                    sql += "USE lab ;REVOKE DELETE ON lab.dbo.Employees TO " + comboBox1.SelectedItem.ToString() + ";";
                try
                {
                    con.Open();
                    SqlCommand cmnd = new SqlCommand(sql, con);
                    cmnd.ExecuteReader();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(sql);
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Амжилттай боллоо");
                comboBox1.SelectedIndex = -1;
                uncheck();
            }
            else
            {
                MessageBox.Show(" Та хэрэглэгчээ сонгоно уу ???!!") ;
            }
           
        }

        
      
    }
}
