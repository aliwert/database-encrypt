using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace encrypt_database
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-LRMEISB\SQLEXPRESS; Initial Catalog=Encrypt; Integrated Security=True");
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            byte[] nameArr = ASCIIEncoding.ASCII.GetBytes(name);
            string encryptName = Convert.ToBase64String(nameArr);
            label6.Text = encryptName;
        }
    }
}
