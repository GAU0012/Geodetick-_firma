using CompanyORM.ORM.Dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyORM.ORM.Forms
{
    public partial class Aktuální_geodeti : Form
    {
        public Aktuální_geodeti()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {
            Collection<Geodet> geo = ShowZakazka.Select_geodet();
            foreach (Geodet g in geo)
            {
                string[] r = { g.Idgeo.ToString(), g.Jmeno_geodeta.ToString(), g.Prijmeni_geodeta.ToString(), g.Mesto_idmes.Nazev_mesta.ToString(),
                    g.Ulice_cislo.ToString() ,g.Email.ToString(),g.Dokoncene_zakazky.ToString()  ,g.Plat.ToString() };
                listView1.Items.Add(new ListViewItem(r));

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aktualni_zakazky menu = new Aktualni_zakazky();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }
    }
}
