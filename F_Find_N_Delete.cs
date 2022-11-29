using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursovaya
{
    public partial class F_Find_N_Delete : Form
    {

        SqlConnectionStringBuilder bldr;
        SqlConnection cn;
        string strSQL;
        int nZac;
        SqlDataAdapter da;
        DataTable t;
        public F_Find_N_Delete()
        {
            InitializeComponent();

            bldr = new SqlConnectionStringBuilder();
            bldr.DataSource = @"DESKTOP-KLDMK1E\SQLEXPRESS";
            bldr.IntegratedSecurity = true;
            bldr.AttachDBFilename = @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DATA\Kursovaya_Ratushniy.mdf";
        }

        public void Clear_Boxes()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();         
        }

        private void button_Find_N_Change_Click(object sender, EventArgs e)
        {
            nZac = Convert.ToInt32(textBox1.Text);

            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            {
                                cn.Open();
                                strSQL = "SELECT * FROM Order_Information WHERE Order_ID=" + nZac;
                                Clear_Boxes();

                                da = new SqlDataAdapter(strSQL, cn);
                                t = new DataTable("Order_Information");
                                da.Fill(t);
                                dataGridView1.DataSource = t;
                                //Отображаем содержимое таблици Order_Information в элементах управления формы
                                textBox1.DataBindings.Add(new Binding("Text", t, "Order_ID"));          label1.Text = "Order ID";  
                                textBox2.DataBindings.Add(new Binding("Text", t, "Full_Name"));         label2.Text = "Full Name";            label2.Visible = true;
                                textBox3.DataBindings.Add(new Binding("Text", t, "FinProduct_ID"));     label3.Text = "FinProduct ID";        label3.Visible = true;
                                
                                dateTimePicker1.DataBindings.Add(new Binding("Value", t, "Date"));  label5.Text = "The date";  label5.Visible = true;

                                textBox2.Visible = true;
                                textBox3.Visible = true;
                                textBox4.Visible = false; label4.Visible = false ;

                                dateTimePicker1.Visible = true; 

                                button_Accept_Changes.Enabled = true;
                                button_Delete.Enabled = true;
                                cn.Close();
                                break;
                            }
                        case 1:
                            {
                                cn.Open();
                                strSQL = "SELECT * FROM Manufacturers_Information WHERE Manufacturer_ID=" + nZac;
                                Clear_Boxes();

                                da = new SqlDataAdapter(strSQL, cn);
                                t = new DataTable("Manufacturers_Information");
                                da.Fill(t);
                                dataGridView1.DataSource = t;
                                //Отображаем содержимое таблици Manufacturers_Information в элементах управления формы
                                textBox1.DataBindings.Add(new Binding("Text", t, "Manufacturer_ID"));        label1.Text = "Manufacturer ID";
                                textBox2.DataBindings.Add(new Binding("Text", t, "Company_name"));           label2.Text = "Company name";            label2.Visible = true;
                                textBox3.DataBindings.Add(new Binding("Text", t, "Сontact_address"));        label3.Text = "Сontact address";         label3.Visible = true;

                                textBox2.Visible = true;
                                textBox3.Visible = true;
                                textBox4.Visible = false; label4.Visible = false;

                                dateTimePicker1.Visible = false; label5.Visible = false;

                                button_Accept_Changes.Enabled = true;
                                button_Delete.Enabled = true;
                                cn.Close();
                                break;
                            }
                        case 2:
                            {
                                cn.Open();
                                strSQL = "SELECT * FROM Parts_Information WHERE Parts_ID=" + nZac;
                                Clear_Boxes();

                                da = new SqlDataAdapter(strSQL, cn);
                                t = new DataTable("Parts_Information");
                                da.Fill(t);
                                dataGridView1.DataSource = t;
                                //Отображаем содержимое таблици Parts_Information в элементах управления формы
                                textBox1.DataBindings.Add(new Binding("Text", t, "Parts_ID"));           label1.Text = "Parts ID";
                                textBox2.DataBindings.Add(new Binding("Text", t, "Manufacturer_ID"));    label2.Text = "Manufacturer ID";  label2.Visible = true;
                                textBox3.DataBindings.Add(new Binding("Text", t, "Price"));              label3.Text = "Price";            label3.Visible = true;
                                textBox4.DataBindings.Add(new Binding("Text", t, "Type"));               label4.Text = "Type";             label4.Visible = true;
                                
                                textBox2.Visible = true;
                                textBox3.Visible = true;
                                textBox4.Visible = true;

                                dateTimePicker1.Visible = false; label5.Visible = false;

                                button_Accept_Changes.Enabled = true;
                                button_Delete.Enabled = true;
                                cn.Close();
                                break;
                            }
                        case 3:
                            {
                                cn.Open();
                                strSQL = "SELECT * FROM Product_Information WHERE FinProduct_ID=" + nZac;
                                Clear_Boxes();

                                da = new SqlDataAdapter(strSQL, cn);
                                t = new DataTable("Product_Information");
                                da.Fill(t);
                                dataGridView1.DataSource = t;
                                //Отображаем содержимое таблици Product_Information в элементах управления формы
                                textBox1.DataBindings.Add(new Binding("Text", t, "FinProduct_ID"));     label1.Text = "FinProduct ID";
                                textBox2.DataBindings.Add(new Binding("Text", t, "Parts_ID"));          label2.Text = "Parts ID";         label2.Visible = true;
                                textBox3.DataBindings.Add(new Binding("Text", t, "Product_Name"));      label3.Text = "Product Name";     label3.Visible = true;
                                textBox4.DataBindings.Add(new Binding("Text", t, "Price"));             label4.Text = "Price";            label4.Visible = true;

                                textBox2.Visible = true;
                                textBox3.Visible = true;
                                textBox4.Visible = true;

                                dateTimePicker1.Visible = false; label5.Visible = false;

                                button_Accept_Changes.Enabled = true;
                                button_Delete.Enabled = true;
                                cn.Close();
                                break;
                            }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void button_Accept_Changes_Click(object sender, EventArgs e)
        {

            int res;
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            {
                                cn.Open();
                                string strUpd = "UPDATE [Order_Information] " + "SET Order_ID=@Order_ID,Date=@Date, Full_Name=@Full_Name,FinProduct_ID=@FinProduct_ID  WHERE Order_ID=@Order_ID";
                                SqlCommand cmdUpd = new SqlCommand(strUpd, cn);
                                //определяем параметры запроса
                                cmdUpd.Parameters.AddWithValue("@Order_ID", Convert.ToInt32(textBox1.Text));
                                cmdUpd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                                cmdUpd.Parameters.AddWithValue("@Full_Name", textBox2.Text);
                                cmdUpd.Parameters.AddWithValue("@FinProduct_ID", Convert.ToInt32(textBox3.Text));
                                //выполняем запрос
                                res = 0;
                                res = cmdUpd.ExecuteNonQuery();
                                if (res == 1)
                                {
                                    MessageBox.Show("Запись успешно отредактирована!");
                                    //Обновляем содержимое dataGridView1
                                    strSQL = "SELECT * FROM Order_Information WHERE Order_ID=" + Convert.ToInt32(textBox1.Text);
                                    da = new SqlDataAdapter(strSQL, cn);
                                    t = new DataTable("Order_Information");
                                    da.Fill(t);
                                    dataGridView1.DataSource = t;
                                }
                                else
                                    MessageBox.Show("Запись не отредактирована!");

                                cn.Close();
                                break;
                            }
                        case 1:
                            {
                                cn.Open();
                                string strUpd = "UPDATE [Manufacturers_Information] " + "SET Manufacturer_ID=@Manufacturer_ID,Company_name=@Company_name, Сontact_address=@Сontact_address WHERE Manufacturer_ID=@Manufacturer_ID";
                                SqlCommand cmdUpd = new SqlCommand(strUpd, cn);
                                //определяем параметры запроса
                                cmdUpd.Parameters.AddWithValue("@Manufacturer_ID", Convert.ToInt32(textBox1.Text));
                                cmdUpd.Parameters.AddWithValue("@Company_name", textBox2.Text);
                                cmdUpd.Parameters.AddWithValue("@Сontact_address", textBox3.Text);
                                //выполняем запрос
                                res = 0;
                                res = cmdUpd.ExecuteNonQuery();
                                if (res == 1)
                                {
                                    MessageBox.Show("Запись успешно отредактирована!");
                                    //Обновляем содержимое dataGridView1
                                    strSQL = "SELECT * FROM Manufacturers_Information WHERE Manufacturer_ID=" + Convert.ToInt32(textBox1.Text);
                                    da = new SqlDataAdapter(strSQL, cn);
                                    t = new DataTable("Manufacturers_Information");
                                    da.Fill(t);
                                    dataGridView1.DataSource = t;
                                }
                                else
                                    MessageBox.Show("Запись не отредактирована!");

                                cn.Close();
                                break;
                            }
                        case 2:
                            {
                                cn.Open();
                                string strUpd = "UPDATE [Parts_Information] " + "SET Parts_ID=@Parts_ID,Manufacturer_ID=@Manufacturer_ID,Price=@Price,Type=@Type WHERE Parts_ID=@Parts_ID";
                                SqlCommand cmdUpd = new SqlCommand(strUpd, cn);
                                //определяем параметры запроса
                                cmdUpd.Parameters.AddWithValue("@Parts_ID", Convert.ToInt32(textBox1.Text));
                                cmdUpd.Parameters.AddWithValue("@Manufacturer_ID", Convert.ToInt32(textBox2.Text));
                                cmdUpd.Parameters.AddWithValue("@Price", Convert.ToInt32(textBox3.Text));
                                cmdUpd.Parameters.AddWithValue("@Type", textBox4.Text);
                                //выполняем запрос
                                res = 0;
                                res = cmdUpd.ExecuteNonQuery();
                                if (res == 1)
                                {
                                    MessageBox.Show("Запись успешно отредактирована!");
                                    //Обновляем содержимое dataGridView1
                                    strSQL = "SELECT * FROM Parts_Information WHERE Parts_ID=" + Convert.ToInt32(textBox1.Text);
                                    da = new SqlDataAdapter(strSQL, cn);
                                    t = new DataTable("Parts_Information");
                                    da.Fill(t);
                                    dataGridView1.DataSource = t;
                                }
                                else
                                    MessageBox.Show("Запись не отредактирована!");

                                cn.Close();
                                break;
                            }
                        case 3:
                            {
                                cn.Open();
                                string strUpd = "UPDATE [Product_Information] " + "SET Parts_ID=@Parts_ID,Product_Name=@Product_Name,Price=@Price, FinProduct_ID=@FinProduct_ID WHERE FinProduct_ID=@FinProduct_ID";
                                SqlCommand cmdUpd = new SqlCommand(strUpd, cn);
                                //определяем параметры запроса
                                cmdUpd.Parameters.AddWithValue("@FinProduct_ID", Convert.ToInt32(textBox1.Text));
                                cmdUpd.Parameters.AddWithValue("@Parts_ID", Convert.ToInt32(textBox2.Text));
                                cmdUpd.Parameters.AddWithValue("@Product_Name", textBox3.Text);
                                cmdUpd.Parameters.AddWithValue("@Price", Convert.ToInt32(textBox4.Text));
                                //выполняем запрос
                                res = 0;
                                res = cmdUpd.ExecuteNonQuery();
                                if (res == 1)
                                {
                                    MessageBox.Show("Запись успешно отредактирована!");
                                    //Обновляем содержимое dataGridView1
                                    strSQL = "SELECT * FROM Product_Information WHERE FinProduct_ID=" + Convert.ToInt32(textBox1.Text);
                                    da = new SqlDataAdapter(strSQL, cn);
                                    t = new DataTable("Product_Information");
                                    da.Fill(t);
                                    dataGridView1.DataSource = t;
                                }
                                else
                                    MessageBox.Show("Запись не отредактирована!");

                                cn.Close();
                                break;
                            }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Update_Boxes(string s1, string s2)
        {
            try
            {
                strSQL = "SELECT * FROM " + s1 + " WHERE " + s2 + "=" + nZac;
                SqlDataAdapter da = new SqlDataAdapter(strSQL, cn);
                DataTable t = new DataTable("");
                da.Fill(t);
                dataGridView1.DataSource = t;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            button_Accept_Changes.Enabled = false;
            textBox1.Text = "";
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            dateTimePicker1.Visible = false;
        }
        private void button_Delete_Click(object sender, EventArgs e)
        {
            int res;
            using (cn = new SqlConnection(bldr.ConnectionString))
            {
                try
                {
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            {
                                cn.Open();
                                string strDel = "DELETE FROM [Order_Information] WHERE Order_ID=@Order_ID";
                                SqlCommand cmdDel = new SqlCommand(strDel, cn);
                                //выполняем запрос
                                cmdDel.Parameters.AddWithValue("Order_ID", Convert.ToInt32(textBox1.Text));
                                res = 0;
                                res = cmdDel.ExecuteNonQuery();
                                if (res == 1)
                                {
                                    MessageBox.Show("Запись успешно удалена!");
                                    Update_Boxes("Order_Information", "Order_ID");
                                }
                                else
                                    MessageBox.Show("Запись не удалена!");

                                cn.Close();
                                break;
                            }
                        case 1:
                            {
                                cn.Open();
                                string strDel = "DELETE FROM [Manufacturers_Information] WHERE Manufacturer_ID=@Manufacturer_ID";
                                SqlCommand cmdDel = new SqlCommand(strDel, cn);
                                //выполняем запрос
                                cmdDel.Parameters.AddWithValue("Manufacturer_ID", Convert.ToInt32(textBox1.Text));
                                res = 0;
                                res = cmdDel.ExecuteNonQuery();
                                if (res == 1)
                                {
                                    MessageBox.Show("Запись успешно удалена!");
                                    Update_Boxes("Manufacturers_Information", "Manufacturer_ID");
                                }
                                else
                                    MessageBox.Show("Запись не удалена!");

                                cn.Close();
                                break;
                            }
                        case 2:
                            {
                                cn.Open();
                                string strDel = "DELETE FROM [Parts_Information] WHERE Parts_ID=@Parts_ID";
                                SqlCommand cmdDel = new SqlCommand(strDel, cn);
                                //выполняем запрос
                                cmdDel.Parameters.AddWithValue("Parts_ID", Convert.ToInt32(textBox1.Text));
                                res = 0;
                                res = cmdDel.ExecuteNonQuery();
                                if (res == 1)
                                {
                                    MessageBox.Show("Запись успешно удалена!");
                                    Update_Boxes("Parts_Information", "Parts_ID");
                                }
                                else
                                    MessageBox.Show("Запись не удалена!");

                                cn.Close();
                                break;
                            }
                        case 3:
                            {
                                cn.Open();
                                string strDel = "DELETE FROM [Product_Information] WHERE FinProduct_ID=@FinProduct_ID";
                                SqlCommand cmdDel = new SqlCommand(strDel, cn);
                                //выполняем запрос
                                cmdDel.Parameters.AddWithValue("FinProduct_ID", Convert.ToInt32(textBox1.Text));
                                res = 0;
                                res = cmdDel.ExecuteNonQuery();
                                if (res == 1)
                                {
                                    MessageBox.Show("Запись успешно удалена!");
                                    Update_Boxes("Product_Information", "FinProduct_ID");
                                }
                                else
                                    MessageBox.Show("Запись не удалена!");

                                cn.Close();
                                break;
                            }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
