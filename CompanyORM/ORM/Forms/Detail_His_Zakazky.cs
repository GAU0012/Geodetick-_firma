using CompanyORM.ORM.Dao;
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
    public partial class Detail_His_Zakazky : Form
    {
        public Detail_His_Zakazky(int a)
        {
            InitializeComponent();
            load(a);
        }

        private void load(int zakazka)
        {
            Historie_zakazek h = ShowHistorieZakazek.Select(zakazka);
           
            string[] r = { h.Idhis.ToString(), h.Datumod.ToString(), h.Datumdo.ToString(), h.Typ_zakazky_idtyp.Jmeno_zakazky.ToString(), h.Zakazka_idzak.Objednavatel_idobj.Jmeno_objednavatele.ToString(),
                     h.Zakazka_idzak.Geodet_idgeo.Jmeno_geodeta.ToString() + " " + h.Zakazka_idzak.Geodet_idgeo.Prijmeni_geodeta.ToString(),  h.Zakazka_idzak.Cena.ToString() };

            listView1.Items.Add(new ListViewItem(r));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
