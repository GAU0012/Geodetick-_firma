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
using CompanyORM.ORM;
using CompanyORM;
using CompanyORM.ORM.Forms;

namespace CompanyORM.Forms
{
    public partial class Historie_zakazek_Form : Form
    {


        public Historie_zakazek_Form()
        {
            InitializeComponent();
            Form_load();
        }

        string setrid = "PodleID";
        private void Form_load()
        {
            
            Collection<Historie_zakazek> His1 = ShowHistorieZakazek.Setrid(DateTime.Now.AddDays(-1200).Date, DateTime.Now.AddDays(1).Date, setrid);
            foreach (Historie_zakazek h in His1)
            {
                string[] r = { h.Idhis.ToString(), h.Datumod.ToString(), h.Datumdo.ToString(), h.Typ_zakazky_idtyp.Jmeno_zakazky.ToString(),
                    h.Zakazka_idzak.Objednavatel_idobj.Jmeno_objednavatele.ToString() };
                listView1.Items.Add(new ListViewItem(r));

            }
            
            comboBox1.Items.Add("max.vydelek");
            comboBox1.Items.Add("casova_narocnost");
            comboBox1.Items.Add("PodleID");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            listView1.Items.Clear();
            
            try
            {
                setrid = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Nebyl zvoleny způsob setřídění. Setřídim podle Id.");
            }

            Collection<Historie_zakazek> His2 = ShowHistorieZakazek.Setrid(dateTimePicker1.Value, dateTimePicker2.Value, setrid);
            foreach (var h  in His2)
            {
                string[] ra = { h.Idhis.ToString(), h.Datumod.ToString(), h.Datumdo.ToString(), h.Typ_zakazky_idtyp.Jmeno_zakazky.ToString(),
                    h.Zakazka_idzak.Objednavatel_idobj.Jmeno_objednavatele.ToString()};
                listView1.Items.Add(new ListViewItem(ra));    
            }
            listView1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int cena = ShowHistorieZakazek.Celkova_cena(dateTimePicker1.Value, dateTimePicker2.Value);

            MessageBox.Show(cena.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Insert_His_Zaznam main = new Insert_His_Zaznam();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_Programu menu = new Menu_Programu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        //Dvojkliknuti na ID vybrané položky zobrazí detail záznamu (funkce 6.2)
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if( listView1.SelectedItems.Count > 0 )
            {
                ListViewItem item = listView1.SelectedItems[0];
                int b = Int32.Parse(item.SubItems[0].Text);

                Historie_zakazek h = ShowHistorieZakazek.Select(b);
                Detail_His_Zakazky form = new Detail_His_Zakazky(b);
                form.Show();
            }
        }
    }
}
