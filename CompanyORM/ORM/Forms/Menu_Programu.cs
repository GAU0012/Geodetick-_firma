using CompanyORM.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyORM.ORM.Forms
{
    public partial class Menu_Programu : Form
    {
        public Menu_Programu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Historie_zakazek_Form his = new Historie_zakazek_Form();
            this.Hide();
            his.ShowDialog();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Aktualni_zakazky zak = new Aktualni_zakazky();
            this.Hide();
            zak.ShowDialog();
            this.Close();
        }
    }
}
