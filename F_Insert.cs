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

namespace Kursovaya
{
    public partial class F_Insert : Form
    {
        string strSQL;
        SqlConnectionStringBuilder bldr;
        SqlConnection cn;
        public F_Insert()
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
                        combo_FinProduct_ID.Items.Insert(i, rdr1["FinProduct_ID"]);
                    }
                    rdr1.Close();

                    //заполнение списка Manufacturer ID
                    
                    strSQL = "SELECT Manufacturer_ID FROM Manufacturers_Information";
                    cmd = new SqlCommand(strSQL, cn);
                    rdr1 = cmd.ExecuteReader();
                    i = 0;
                    while (rdr1.Read())
                    {
                        comboBox_Manufacturer_ID.Items.Insert(i, rdr1["Manufacturer_ID"]);
                    }
                    rdr1.Close();
                    //заполнение списка Parts_ID
                    
                    strSQL = "SELECT Parts_ID FROM Parts_Information";
                    cmd = new SqlCommand(strSQL, cn);
                    rdr1 = cmd.ExecuteReader();
                    i = 0;
                    while (rdr1.Read())
                    {
                        comboParts_ID.Items.Insert(i, rdr1["Parts_ID"]);
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

        public void End_Form()
        {
            F_Insert f2 = new F_Insert();
            f2.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    cn.Open();
                    strSQL = "INSERT INTO Order_Information VALUES ("+Convert.ToInt32(boxOrder_ID.Text)+"," +"Convert(Smalldatetime,'" + dateTimePicker_Date.Value.ToString() + "'),'" + boxFull_Name.Text+ "'," +Convert.ToInt32(combo_FinProduct_ID.SelectedItem) + ")"; 
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    if (cmd.ExecuteNonQuery() == 1)
                        MessageBox.Show("Запись успешно добавлена!");
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
                End_Form();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    cn.Open();
                    strSQL = "INSERT INTO Manufacturers_Information VALUES (" + Convert.ToInt32(box_Manufacturer_ID.Text) + ",'" + box_Company_Name.Text + "','" + boxContact_Adress.Text + "')";
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    if (cmd.ExecuteNonQuery() == 1)
                        MessageBox.Show("Запись успешно добавлена!");
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
                End_Form();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    cn.Open();
                    strSQL = "INSERT INTO Parts_Information VALUES (" + Convert.ToInt32(boxParts_ID.Text) + "," + Convert.ToInt32(comboBox_Manufacturer_ID.SelectedItem) + ",'" + boxPrice.Text + "','" + boxType.Text + "')";
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    if (cmd.ExecuteNonQuery() == 1)
                        MessageBox.Show("Запись успешно добавлена!");
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
                End_Form();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    cn.Open();
                    strSQL = "INSERT INTO Product_Information VALUES (" + Convert.ToInt32(comboParts_ID.SelectedItem) + ",'" + boxProduct_Name.Text + "'," + Convert.ToInt32(boxPrice02.Text) + "," + Convert.ToInt32(boxFinProduct_ID.Text) + ")";
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    if (cmd.ExecuteNonQuery() == 1)
                        MessageBox.Show("Запись успешно добавлена!");
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
                End_Form();
            }
        }
    }
}
