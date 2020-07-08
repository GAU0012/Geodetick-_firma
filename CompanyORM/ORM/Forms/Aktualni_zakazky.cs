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
    public partial class Aktualni_zakazky : Form
    {
        public Aktualni_zakazky()
        {
            InitializeComponent();
            Form_load();
        }

        Collection<Zakazka> zakazka;
        string stav;
        private void Form_load()
        {
            zakazka = ShowZakazka.Select_Aktualni();
            foreach (Zakazka z in zakazka)
            {
                string[] r = { z.Idzak.ToString(), z.Lokalita_idlok.Katastralni_uzemi.ToString(), z.Typ_zakazky_idtyp.Jmeno_zakazky.ToString(),
                    z.Lokalita_idlok.Mesto_idmes.Nazev_mesta.ToString(), z.Cena.ToString(),z.Casova_narocnost.ToString()};
                listView1.Items.Add(new ListViewItem(r));
            }
            comboBox1.Items.Add("volna");
            comboBox1.Items.Add("dokoncena");
            comboBox1.Items.Add("probihajici");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Aktuální_geodeti aktualni = new Aktuální_geodeti();
            this.Hide();
            aktualni.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_Programu menu = new Menu_Programu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            stav = comboBox1.SelectedItem.ToString();
            Collection<Zakazka> zak = ShowZakazka.Select_Aktualni_dle_stavu(stav);

            foreach (var z in zak)
            {
                string[] s = { z.Idzak.ToString() ,z.Datum.ToString(), z.Typ_zakazky_idtyp.Jmeno_zakazky.ToString(), z.Lokalita_idlok.Mesto_idmes.Nazev_mesta.ToString(),
                z.Cena.ToString(), z.Casova_narocnost.ToString() };
                listView1.Items.Add(new ListViewItem(s));
            }
        }


        //Funkce 5.5 vyběr zakázky (Beru) fuguje pomoci dvojkliknuti na vybraný zaznam
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string stav2 = comboBox1.SelectedItem.ToString();
                if(stav2 == "volna")
                {
                    ListViewItem item = listView1.SelectedItems[0];
                    int IdZakazky = Int32.Parse(item.SubItems[0].Text);
                    ShowZakazka.Update(IdZakazky);
                    MessageBox.Show("Zakázka byla vybrána");
                }
            }
               
        }

    }
}
