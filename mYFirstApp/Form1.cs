
using mYFirstApp.MyClass;
using System;
using System.Data.SqlClient;
using System.Data;
namespace mYFirstApp

{
    public partial class Form1 : Form
    {
        DbConnection con = new DbConnection();
        public string? query;
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           
            dashboardForm dform = new dashboardForm();
            query = "SELECT* FROM tbl_user WHERE username='"+ textBox1.Text +"' AND password = '"+ textBox2.Text +"' ";
            con.fetchLogin(query,  dform );
            if (con.formHide ==true)
            {
                this.Hide();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}