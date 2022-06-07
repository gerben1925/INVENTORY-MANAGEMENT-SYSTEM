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
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            dbconn.fetch_Combo("SELECT * FROM tbl_user_lvl ORDER BY id ASC", comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
