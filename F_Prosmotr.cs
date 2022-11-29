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
    public partial class F_Prosmotr : Form
    {
        SqlConnectionStringBuilder bldr;
        SqlConnection cn;
        public F_Prosmotr()
        {
            InitializeComponent();

            bldr = new SqlConnectionStringBuilder();
            bldr.DataSource = @"DESKTOP-KLDMK1E\SQLEXPRESS";
            bldr.IntegratedSecurity = true;
            bldr.AttachDBFilename = @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DATA\Kursovaya_Ratushniy.mdf";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameTable = "";
            string strSQL;
            switch (comboBox1.SelectedIndex)
            {
                case 0: nameTable = "Order_Information"; break;             //информацияо заказах
                case 1: nameTable = "Manufacturers_Information"; break;     // о производителях
                case 2: nameTable = "Parts_Information"; break;             //о комплектующих
                case 3: nameTable = "Product_Information"; break;           //о производимой продукции
            }
            strSQL = "SELECT * FROM " + nameTable;
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
