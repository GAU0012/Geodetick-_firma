using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyORM.ORM.Dao;

namespace CompanyORM.ORM
{


    public class Zakazka
    {
        public int Idzak { get; set; }
        public DateTime Datum { get; set; }
        public Objednavatel Objednavatel_idobj { get; set; }
        public Lokalita Lokalita_idlok { get; set; }
        public Typ_zakazky Typ_zakazky_idtyp { get; set; }
        public int Cena { get; set; }
        public int Casova_narocnost { get; set; }
        public Geodet Geodet_idgeo { get; set; }
        public string Stav { get; set; }
    }

    
}
    