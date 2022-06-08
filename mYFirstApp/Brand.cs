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
    public partial class Brand : Form
    {
        DbConnection config = new DbConnection();
        public int brandstatus;
        public string? ID;
        public Brand()
        {
            InitializeComponent();
        }
        public void fetchData()
        {
            config.fetchDatagrid("SELECT * FROM tbl_brand ORDER BY brandid ASC",dataGridView1);
        }
        private void Brand_Load(object sender, EventArgs e)
        {
            fetchData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                var dateToday = DateTime.Today;
                config.executeQuery("INSERT INTO tbl_brand(brand_name,brand_status,date_created)VALUES('" + textBox1.Text + "','" + brandstatus + "','" + dateToday + "') ");
                MessageBox.Show("SUCCESSFULLY ADDED!");
                textBox1.Clear();
                fetchData();
            }
            else
            {
                MessageBox.Show("NO RECORD's TO BE ADDED ", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ACTIVE")
            {
                brandstatus = 1;
            }
            else 
            {
                brandstatus = 0;
            }
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text !="")
            { 
            config.executeQuery("UPDATE tbl_brand SET brand_name= '"+textBox1.Text+"',brand_status= '"+ brandstatus +"' WHERE brandid='"+ ID +"' ");
            MessageBox.Show("SUCCESSFULLY UPDATED!");
            fetchData();
            }
            else 
            {
                MessageBox.Show("NO RECORD TO BE UPDATE","MESSAGE",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int bstatus = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            if (bstatus == 1)
            {
                comboBox1.Text = "ACTIVE";
                brandstatus = 1;
            }
            else
            {
                comboBox1.Text = "INACTIVE";
                brandstatus = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (DialogResult.Yes == MessageBox.Show("ARE YOU SURE WANT TO DELETE THIS RECORD? ", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    config.executeQuery("DELECT * FROM tbl_brand WHERE brandid='" + ID + "' ");
                    fetchData();
                }
            }
            else 
            {
                MessageBox.Show("NO RECORD TO BE DELETED!");
            }
        }        
    }
}
