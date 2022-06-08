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
    public partial class dashboardForm : Form
    {
        DbConnection dbcon = new DbConnection();
        public string? user;
        public dashboardForm()
        {
            InitializeComponent();
        }

      
        private void dashboardForm_Load(object sender, EventArgs e)
        {
            label1.Text  = dbcon.username;
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users user_form = new Users();
            user_form.ShowDialog();
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brand fbrand = new Brand();
            fbrand.ShowDialog();
        }
    }
}
