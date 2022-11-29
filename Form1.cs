using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // запросы
        {
            F_Request f1 = new F_Request();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e) //добавить информацию
        {
            F_Insert f2 = new F_Insert();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e) // удалить информацию
        {
            F_Find_N_Delete f3 = new F_Find_N_Delete();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e) //просмотр информации
        {
            F_Prosmotr f4 = new F_Prosmotr();
            f4.Show();
        }
    }
}
