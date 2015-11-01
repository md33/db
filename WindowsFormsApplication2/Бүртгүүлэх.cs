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
 
        public Бүртгүүлэх(String name)
        {
            InitializeComponent();
            this.name = name;
            Aname.Hide();
            Aname.Text = name;
            password1.PasswordChar = '*';
            password.PasswordChar ='*';


           
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
                    string connetionString = null;
                    connetionString = "Data Source=MD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
                   // connetionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                    SqlConnection con = new SqlConnection(connetionString);
                    SqlCommand cmd = new SqlCommand();

                    //string myQuery = "INSERT INTO dbo.Employees (Name, DoB, Gender, Address, AddedBy, AddedDate) VALUES(@Name, @DoB, @Gender, @Address, @AddedBy, @AddedDate)";
                    string myQuery = "dbo.InsertNewEmployees";
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
                    String encrypt;
                    encrypt = Encrypt(password.Text.ToString());
                    cmd.Parameters["@password"].Value = encrypt;          
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

                            id.Text = "";                            
                            dob.Text = DateTime.Now.Date.ToShortDateString();
                            lname.Text = "";
                            fname.Text = "";
                            gender.Text = "";
                            age.Text = "";
                            password.Text = "";
                     

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
                }
            }
            else
            {
                MessageBox.Show("Та бүх мэдээлэлээ үнэн зөв бөглөнө үү !!!");
            }
        }
        String Encrypt(String encrypt)
        {
            String EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encrypt);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encrypt;
        }
        String Decrypt(String decrypt)
        {
            String EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(decrypt);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    decrypt = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return decrypt;
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
