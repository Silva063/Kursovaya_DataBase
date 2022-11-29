using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursovaya
{
    public partial class F_Request : Form
    {
        SqlConnectionStringBuilder bldr;
        SqlConnection cn;
        string strSQL;
        public F_Request()
        {
            InitializeComponent();

            bldr = new SqlConnectionStringBuilder();
            bldr.DataSource = @"DESKTOP-KLDMK1E\SQLEXPRESS";
            bldr.IntegratedSecurity = true;
            bldr.AttachDBFilename = @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DATA\Kursovaya_Ratushniy.mdf";

            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    cn.Open();
                    //заполнение списка comboBox_FinProduct_ID

                    strSQL = "SELECT FinProduct_ID FROM Product_Information";
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    SqlDataReader rdr1 = cmd.ExecuteReader();
                    int i = 0;
                    while (rdr1.Read())
                    {
                        combo_FinProduct_ID_R.Items.Insert(i, rdr1["FinProduct_ID"]);
                    }
                    rdr1.Close();

                    //заполнение списка Manufacturer ID

                    strSQL = "SELECT Manufacturer_ID FROM Manufacturers_Information";
                    cmd = new SqlCommand(strSQL, cn);
                    rdr1 = cmd.ExecuteReader();
                    i = 0;
                    while (rdr1.Read())
                    {
                        comboBox_Manufacturer_ID_R.Items.Insert(i, rdr1["Manufacturer_ID"]);
                    }
                    rdr1.Close();
                    //заполнение списка Parts_ID

                    strSQL = "SELECT Parts_ID FROM Parts_Information";
                    cmd = new SqlCommand(strSQL, cn);
                    rdr1 = cmd.ExecuteReader();
                    i = 0;
                    while (rdr1.Read())
                    {
                        comboParts_ID_R.Items.Insert(i, rdr1["Parts_ID"]);
                    }
                    rdr1.Close();
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            strSQL = "SELECT * FROM Order_Information WHERE Date = Convert(Smalldatetime,'"+ textBox1.Text +"')";
            
            
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    DataTable t = new DataTable();
                    t.Load(rdr);
                    dataGridView1.DataSource = t.DefaultView;

                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            strSQL = "SELECT * FROM Manufacturers_Information WHERE Manufacturer_ID=" + Convert.ToInt32(comboBox_Manufacturer_ID_R.SelectedItem);
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    DataTable t = new DataTable();
                    t.Load(rdr);
                    dataGridView1.DataSource = t.DefaultView;

                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            strSQL = "SELECT * FROM Product_Information WHERE FinProduct_ID=" + Convert.ToInt32(combo_FinProduct_ID_R.SelectedItem);
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    DataTable t = new DataTable();
                    t.Load(rdr);
                    dataGridView1.DataSource = t.DefaultView;

                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            strSQL = "SELECT * FROM Parts_Information WHERE Parts_ID=" + Convert.ToInt32(comboParts_ID_R.SelectedItem);
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    DataTable t = new DataTable();
                    t.Load(rdr);
                    dataGridView1.DataSource = t.DefaultView;

                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
