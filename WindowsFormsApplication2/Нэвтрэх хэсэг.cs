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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        public SqlConnection conn;
        
        public Form1()
        {
            InitializeComponent();
            password.PasswordChar='*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text != string.Empty && password.Text != string.Empty)
            {
                try {
                    int getReturn = 0;
                    string connetionString = null;
                    connetionString = "Data Source=mD\\SQLEXPRESS;Initial Catalog=lab;Integrated Security=True";
                    SqlConnection con = new SqlConnection(connetionString);
                    con.Open();
                    String encrypt;
                    encrypt = Encrypt(password.Text.ToString());
                    string commandString = "SELECT * FROM dbo.employees WHERE iD = '" + username.Text + "' AND Password = '" +password.Text.ToString()+ "'";
                    //string command = "SELECT PASSWORD FROM dbo.employees WHERE iD = '" + username.Text + "'";
                    //String de = Decrypt(command);
                    //MessageBox.Show(de);

                    SqlCommand sqlCmd = new SqlCommand(commandString, con);

                    SqlDataReader read = sqlCmd.ExecuteReader();

                    while (read.Read())
                    {
                        getReturn++;
                    }
                    if (getReturn == 1)
                    {
                        Нүүр nvvr = new Нүүр(username.Text.ToString());
                        this.Hide();
                        nvvr.ShowDialog();
                        password.Text = "";
                    }
                    con.Close();
                    //if (password.Text.Equals(de))
                    //{
                    //    Нүүр nvvr = new Нүүр(username.Text.ToString());
                    //    this.Hide();
                    //    nvvr.ShowDialog();
                    //    password.Text = "";
                    //}
                }
                catch (Exception a) {
                    MessageBox.Show(a.ToString());
                }
            }
            else
            {
                MessageBox.Show("   Ta iD болон нууц үгээ оруулна уу !!!");
                password.Text = "";
                username.Text = "";
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
    }
}
