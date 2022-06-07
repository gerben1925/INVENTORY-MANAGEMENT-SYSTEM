using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mYFirstApp.MyClass;

namespace mYFirstApp
{
    public partial class Users : Form
    {
        DbConnection dbconn = new DbConnection();
        public int? ID;
        public Users()
        {
            InitializeComponent();
        }
        public void clearField()
        {
            textBox1.Clear();
            textBox2.Clear();

        }
        public void fetchData()
        {
            dbconn.fetchDatagrid("SELECT * FROM tbl_user ORDER BY id ASC", dataGridView1);
        }


        private void Users_Load(object sender, EventArgs e)
        {
            dbconn.fetch_Combo("SELECT * FROM tbl_user_lvl ORDER BY id ASC", comboBox1);
            fetchData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var datetoday = DateTime.Today;
            dbconn.executeQuery("INSERT INTO tbl_user(username,password,user_lvl,date_created)VALUES('"+ textBox1.Text +"','"+ textBox2.Text +"','"+ this.comboBox1.SelectedValue.ToString() +"','" + datetoday + "') ");
            if (dbconn.addToDb == true)
            MessageBox.Show("SUCCESSFULLY ADDED!");
            clearField();
                
            
            fetchData();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //textBox1.Text = comboBox1.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dbconn.fetchDatagrid("SELECT * FROM tbl_user WHERE username LIKE'%"+textBox3.Text+"%'  ",dataGridView1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
