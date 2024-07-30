﻿using System;
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
        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLDATA", connect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            byte[] nameArr = ASCIIEncoding.ASCII.GetBytes(name);
            string encryptName = Convert.ToBase64String(nameArr);


            string surname = txtSurname.Text;
            byte[] surnameArr = ASCIIEncoding.ASCII.GetBytes(surname);
            string encryptSurname = Convert.ToBase64String(surnameArr);

            string mail = txtMail.Text;
            byte[] mailArr = ASCIIEncoding.ASCII.GetBytes(mail);
            string encryptMail = Convert.ToBase64String(mailArr);

            string password = txtPassword.Text;
            byte[] passwordArr = ASCIIEncoding.ASCII.GetBytes(password);
            string encryptPassword = Convert.ToBase64String(passwordArr);

            string accountNo = txtAccNo.Text;
            byte[] accountNoArr = ASCIIEncoding.ASCII.GetBytes(accountNo);
            string encryptAccountNo = Convert.ToBase64String(accountNoArr);

            connect.Open();
            SqlCommand command = new SqlCommand("insert into TBLDATA (NAME,SURNAME,MAIL,PASSWORD,ACCOUNTNO) values (@p1, @p2,@p3,@p4,@p5)", connect);
            command.Parameters.AddWithValue("@p1", encryptName);
            command.Parameters.AddWithValue("@p2", encryptSurname);
            command.Parameters.AddWithValue("@p3", encryptMail);
            command.Parameters.AddWithValue("@p4", encryptPassword);
            command.Parameters.AddWithValue("@p5", encryptAccountNo);
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Datas added");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list();
        }
    }
}
