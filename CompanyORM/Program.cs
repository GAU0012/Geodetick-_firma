using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using CompanyORM.Forms;
using CompanyORM.ORM;
using CompanyORM.ORM.Dao;
using CompanyORM.ORM.Forms;

namespace CompanyORM
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Database db = new Database();
            //db.Connect();

            
        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu_Programu());
        
          
        /*
        Console.WriteLine("Evidence objednavatelů");
            //1.1
           // ShowObjednavatel.Insert(14, "Stavim s.r.o.", "Ostravská 21", "1413435465/2010", 21313212, 32123212, 3);


            //1.2
            Objednavatel zakaznik = ShowObjednavatel.Detail_objednavatele(7,db);
            
                Console.WriteLine(zakaznik.Idobj + " " + zakaznik.Jmeno_objednavatele + ", Adresa: " + zakaznik.Ulice_cislo + ", Bankovní spojení" + zakaznik.Bankovni_spojeni + ", " +
                    "Ico: " + zakaznik.Ico + ", Dic:" + zakaznik.Dic + "Město: " + zakaznik.Mesto_idmes.Nazev_mesta + " PSC: " + zakaznik.Mesto_idmes.Psc);
            

            //1.3
            //ShowObjednavatel.Update(13, "Antonín dovřák", "Stodolní 32", "2131213242/2010", 23142312, 43212341, 4);

            //1.4
            Collection<Objednavatel> zakaznici2 = ShowObjednavatel.Seznam_zakazniku_dle_jmena("Pocinkuj s.r.o.");
            foreach (Objednavatel o in zakaznici2)
            {
                Console.WriteLine(o.Idobj + " " + o.Jmeno_objednavatele + ", Adresa: " + o.Ulice_cislo + ", Bankovní spojení" + o.Bankovni_spojeni + ", " +
                    "Ico: " + o.Ico + ", Dic:" + o.Dic + "Město: " + o.Mesto_idmes.Nazev_mesta + " PSC: " + o.Mesto_idmes.Psc);
            }
            
            //1.5
            Collection<Objednavatel> zakaznici3 = ShowObjednavatel.Seznam_zakazniku_dle_mesta(2);
            foreach (Objednavatel o in zakaznici3)
            {
                Console.WriteLine(o.Idobj + " " + o.Jmeno_objednavatele + ", Adresa: " + o.Ulice_cislo + ", Bankovní spojení" + o.Bankovni_spojeni + ", " +
                    "Ico: " + o.Ico + ", Dic:" + o.Dic +"Město: " + o.Mesto_idmes.Nazev_mesta + " PSC: " + o.Mesto_idmes.Psc);
            }
            Console.WriteLine("Dokončeno");
            
            Console.WriteLine("Evidence měst");
            //2.1
           // ShowMesto.Insert(15, "Smilovice", 23142);

            //2.2
            Mesto mesta = ShowMesto.Detail_mesta(12);
            Console.WriteLine(mesta.Idmes + " " + mesta.Nazev_mesta + ": " + mesta.Psc);

            //2.3
            Collection<Mesto> mesta2 = ShowMesto.Hledani_mesta_dle_nazvu("Havirov");
            foreach (Mesto m in mesta2)
            {
                Console.WriteLine(m.Idmes + " " + m.Nazev_mesta + ": " + m.Psc);
            }

            Console.WriteLine("Dokončeno");

            Console.WriteLine("Evidence geodetů");
            //3.1
          // ShowGeodet.Insert(5, "Adam", "Novák", "Šadový 12", "adamNov@gmail.com", 3, 31000, 2);

            //3.2
          // ShowGeodet.Update(3, "Michal", "Utikal", "Svobody 13", "michalutikal@gmail.com", 4, 36000, 3);

            //3.3
            Geodet geodet = ShowGeodet.Detail_geodeta(3);
            
            Console.WriteLine(geodet.Idgeo + " " + geodet.Jmeno_geodeta + " " + geodet.Prijmeni_geodeta + " " + geodet.Ulice_cislo + " " + geodet.Email + " " +
                geodet.Plat + " " + geodet.Mesto_idmes.Nazev_mesta + " " + geodet.Dokoncene_zakazky);
            
        
            //3.4
            Collection<Geodet> geodeti2 = ShowGeodet.Seznam_geodetu_dle_jmena("Michal");
            foreach (Geodet g in geodeti2)
            {
                Console.WriteLine(g.Idgeo + " " + g.Jmeno_geodeta + " " + g.Prijmeni_geodeta + " " + g.Ulice_cislo);
            }

            //3.5
            Collection<Geodet> geodeti3 = ShowGeodet.Seznam_geodetu_podle_mesta(4);
            foreach (Geodet g in geodeti3)
            {
                Console.WriteLine(g.Idgeo + " " + g.Jmeno_geodeta + " " + g.Prijmeni_geodeta );
            }

            //3.6
            Collection<Geodet> geodeti4 = ShowGeodet.Seznam_geodetu_setridenych_dle_platu();
            foreach (Geodet g in geodeti4)
            {
                Console.WriteLine(g.Idgeo + " " + g.Jmeno_geodeta + " " + g.Prijmeni_geodeta + " " + g.Ulice_cislo + " " + g.Email + " " + g.Plat + " " + g.Mesto_idmes.Nazev_mesta);
            }
            Console.WriteLine("Dokončeno");

    

            Console.WriteLine("Evidence typů zakázek ");
            //4.1
            //ShowTypZakazek.Insert(7, "Zaměření kanalizace", 2);

            //4.2
            //ShowTypZakazek.Update(5, "Zaměření lesu", 4);

            //4.3
            Typ_zakazky typ = ShowTypZakazek.Detail_typu_zakazky(2);
            Console.WriteLine(typ.Idtyp + " " + typ.Jmeno_zakazky + " Pocet zakazek: " + typ.Pocet_typu);
            

            //4.4
            Collection<Typ_zakazky> typ2 = ShowTypZakazek.Seznam_Typu_Zakazek_Sestridenych_dle_poctu();
            foreach (Typ_zakazky t in typ2)
            {
                Console.WriteLine(t.Idtyp + " " + t.Jmeno_zakazky + " Pocet zakazek: " + t.Pocet_typu);
            }

            Console.WriteLine("Dokončeno");

            Console.WriteLine("Evidence zakázek");

            //5.1
            //ShowZakazka.Insert(15, DateTime.Now.Date, 3, 9, 5, 10000, 4, 2, "Dokoncena");

            //5.3
            Collection<Zakazka> zak = ShowZakazka.Select_Aktualni();
            foreach (Zakazka z in zak)
            {
                Console.WriteLine("ID_zakazky: " + z.Idzak + " Objednavatel: " + z.Objednavatel_idobj.Jmeno_objednavatele + " Id_Lokality: "  + " Stav_Zakazky: " + z.Stav + " Datum: " + z.Datum);
            }

            //5.4
            Console.WriteLine("Dooncene Zakazky");
            Collection<Zakazka> zak2 = ShowZakazka.Select_Aktualni_dle_stavu("dokoncena");
            foreach (Zakazka z in zak2)
            {
                Console.WriteLine(z.Idzak + " Objednavatel:" + z.Objednavatel_idobj.Jmeno_objednavatele + " Typ Zakazky: " + z.Typ_zakazky_idtyp.Jmeno_zakazky + 
                    "Stav: " + z.Stav);
            }

            //5.5
            Collection<Geodet> geo = ShowZakazka.Select_geodet();
            foreach (Geodet g in geo)
            {
                Console.WriteLine(g.Idgeo + " " + g.Jmeno_geodeta + " " + g.Ulice_cislo + " " + g.Email);
            }

            //5.6
            //ShowZakazka.Update(1);



            //5.7
           // ShowZakazka.Smazani();

            //5.8
            Zakazka zakazka = ShowZakazka.Detail_zakazky(6);
            Console.WriteLine(zakazka.Idzak + "Stav: " + zakazka.Stav);
            //5.9
           // ShowZakazka.Insert(11, DateTime.Now.Date, 3, 4, 2, 11000, 8, 1, "dokoncena");

            //ShowZakazka.Nejpracovnici();

            //5.10
            //ShowZakazka.Delete(1);

            Console.WriteLine("Dokončeno");
            Console.WriteLine("Evidence historie_zakazek");

            Console.WriteLine(DateTime.Now.AddDays(-2).Date.ToString());
            //6.1
            ShowHistorieZakazek.Insert(DateTime.Now.AddDays(-2).Date , 6, 2, db);

            //6.2
            Historie_zakazek His = ShowHistorieZakazek.Select(3);
           
            Console.WriteLine(His.Idhis + " Datum od:"+ His.Datumod + " Datum do: " + His.Datumdo + " " + His.Typ_zakazky_idtyp.Jmeno_zakazky);


            //6.3
            Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");
            Collection<Historie_zakazek> His2 = ShowHistorieZakazek.Setrid(DateTime.Now.AddDays(-3).Date, DateTime.Now.AddDays(2).Date, "max.vydelek");
            foreach (Historie_zakazek h in His2)
            {
                Console.WriteLine(h.Idhis + " Datum od:" + h.Datumod  +" Datum do:  " + h.Datumdo + " " + h.Typ_zakazky_idtyp + " " + h.Zakazka_idzak);
            }
            Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");


            Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");
            Collection<Historie_zakazek> His4 = ShowHistorieZakazek.Setrid(DateTime.Now.AddDays(-3).Date, DateTime.Now.AddDays(2).Date, "nic");
            foreach (Historie_zakazek h in His4)
            {
                Console.WriteLine(h.Idhis + " Datum od:" + h.Datumod + " Datum do:  " + h.Datumdo + " " + h.Typ_zakazky_idtyp.Idtyp + " " + h.Zakazka_idzak.Idzak);
            }
            Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");

            Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");
            Collection<Historie_zakazek> His3 = ShowHistorieZakazek.Setrid(DateTime.Now.AddDays(-3).Date, DateTime.Now.AddDays(2).Date, "casova_narocnost");
            foreach (Historie_zakazek h in His3)
            {
                Console.WriteLine(h.Idhis + " Datum od:" + h.Datumod + " Datum do:  " + h.Datumdo + " " + h.Typ_zakazky_idtyp + " " + h.Zakazka_idzak.Idzak);
            }
            Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////");
            //6.4
            int ceny = ShowHistorieZakazek.Celkova_cena(DateTime.Now.AddDays(-1500).Date, DateTime.Now.AddDays(1200).Date);
            Console.WriteLine(ceny);


            //6.5
           // ShowHistorieZakazek.Zvyseni_platu();

            Console.WriteLine("Dokončeno");

            Console.WriteLine("Evidence lokalit");
            //7.1
           // ShowLokalita.Insert(11, "Ostravska 12", "Dolni Zukov", 2, 4, 10000);



            //7.2
            Collection<Lokalita> lok = ShowLokalita.Nejcastejsi_lokality();
            foreach (Lokalita l in lok)
            {
                Console.WriteLine(l.Idlok + " " + l.Katastralni_uzemi +" Mesto:" + l.Mesto_idmes.Nazev_mesta + " PSC" + l.Mesto_idmes.Psc);
            }

            //7.3
            Collection<Lokalita> lok2 = ShowLokalita.Nejvydelecnejsi_lokality();
            foreach (Lokalita l in lok2)
            {
                Console.WriteLine(l.Idlok + " " + l.Katastralni_uzemi + " Mesto:" + l.Mesto_idmes.Nazev_mesta + " PSC" + l.Mesto_idmes.Psc);
            }
            Console.WriteLine("Dokončeno");

            //7.4
            Lokalita lok3 = ShowLokalita.Select(3);
            
            Console.WriteLine(lok3.Idlok + " " + lok3.Katastralni_uzemi + "  Mesto:" + lok3.Mesto_idmes.Nazev_mesta + " PSC" + lok3.Mesto_idmes.Psc);
            

            //7.5
            Collection<Lokalita> lok4 = ShowLokalita.Select_dle_katastru("Sosna");
            foreach (Lokalita l in lok4)
            {
                Console.WriteLine(l.Idlok + " " + l.Katastralni_uzemi + " "  + " Mesto:" + l.Mesto_idmes.Nazev_mesta + " PSC" + l.Mesto_idmes.Psc);
            }


            //7.6
           // ShowLokalita.Update(3, "Šadový 324", "Karvina", 3, 5, 16000);

            Console.WriteLine("Dokončeno");
            Console.ReadKey();

            db.Close();
            */
        }
    }
}
