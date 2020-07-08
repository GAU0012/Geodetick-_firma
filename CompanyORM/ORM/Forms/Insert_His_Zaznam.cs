using CompanyORM.Forms;
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
    public partial class Insert_His_Zaznam : Form
    {
        public Insert_His_Zaznam()
        {
            InitializeComponent();
            load();
        }


   
        Collection<Zakazka> zakazka;
        public void load()
        {
            
            zakazka = ShowZakazka.Select_Aktualni_dle_stavu("probihajici");
            foreach (Zakazka z in zakazka)
            {
                string[] r = { z.Idzak.ToString(), z.Datum.ToString() ,z.Lokalita_idlok.Katastralni_uzemi.ToString(), z.Objednavatel_idobj.Jmeno_objednavatele.ToString(),
                z.Typ_zakazky_idtyp.Jmeno_zakazky.ToString(), z.Typ_zakazky_idtyp.Idtyp.ToString() ,z.Cena.ToString()};
                listView1.Items.Add(new ListViewItem(r));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                int ZakId = Int32.Parse(item.SubItems[0].Text);
                DateTime datumOd = DateTime.Parse(item.SubItems[1].Text);
                int TypId = Int32.Parse(item.SubItems[5].Text);

                ShowHistorieZakazek.Insert(datumOd, dateTimePicker1.Value, ZakId, TypId);
                MessageBox.Show("Zakazka byla vložena");
                listView1.Items.Clear();
                load();
            }
            else
            {
                MessageBox.Show("Vyberte zakázku");
            }
           
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Historie_zakazek_Form HisFor = new Historie_zakazek_Form();
            this.Hide();
            HisFor.ShowDialog();
            this.Close();
        }

      
    }
}