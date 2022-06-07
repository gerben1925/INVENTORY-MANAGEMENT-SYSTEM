using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace mYFirstApp.MyClass
{
    public class DbConnection
    {
        private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=gerben;Integrated Security=True");
        private SqlCommand? cmd;
        private SqlDataAdapter? sqladaptor;
        public DataTable? dt;
        public string? username, pass;
        public int logcount=0;
        public bool formHide = false, addToDb =false;
       

        // store data to datagridview
        public void fetchDatagrid(string query,DataGridView dtgrid)
        {
            try 
            {
                
                if(con.State !=ConnectionState.Open)
                {
                    con.Open();
                }
                cmd = new SqlCommand(query,con);
                sqladaptor =  new SqlDataAdapter(cmd);
                dt = new DataTable();
                sqladaptor.Fill(dt);
                dtgrid.DataSource = dt;
                fetch_to_datagridview(dtgrid);
                dtgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                con.Close();
          
            }
        }
        //fill data to datagriview
        private void fetch_to_datagridview(DataGridView dtgrid) 
        {
            dtgrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        public void fetchLogin(string query,Form form2)
        {
            try 
            {
                if(con.State !=ConnectionState.Open)
                {
                    con.Open();
                }
                cmd = new SqlCommand(query,con);
                sqladaptor = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sqladaptor.Fill(dt);
                if(dt.Rows.Count >  0 )
                {
                    username = dt.Rows[0][1].ToString();
                    pass = dt.Rows[0][1].ToString();
                    formHide = true;
                    form2.Show();
                    
                  
                }
                else 
                {
                    logcount++;
                    MessageBox.Show("INVALID USERNAME AND PASSWORD!","MESSAGE");
                    if(logcount ==3)
                    {
                        MessageBox.Show("You Have Reached Login Attept. The System will Now terminated");
                        Environment.Exit(0);
                    }

                }
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
             
            }
        }
        public void fetch_Combo(string query, ComboBox cbo)
        {
            try
            {
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                cmd = new SqlCommand(query,con);
                sqladaptor = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sqladaptor.Fill(dt);
                cbo.DataSource = dt;
                cbo.DisplayMember = dt.Columns[1].ColumnName;
                cbo.ValueMember = dt.Columns[0].ColumnName;
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
               
            }
        }

        public void executeQuery(string query)
        {
            try
            {
                if(con.State !=ConnectionState.Open)
                {
                    con.Open();
                }
                addToDb = true;
                cmd = new SqlCommand(query,con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
       

    }
}
