using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace encrypt_database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string text = txtName.Text;
            byte[] dataArr = ASCIIEncoding.ASCII.GetBytes(text);
            string encryptData= Convert.ToBase64String(dataArr);
            label6.Text=encryptData;
        }
    }
}
