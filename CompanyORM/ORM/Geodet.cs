using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyORM.ORM
{
    public class Geodet
    {
        public int Idgeo { get; set; }
        public string Jmeno_geodeta { get; set; }
        public string Prijmeni_geodeta { get; set; }
        public string Ulice_cislo { get; set; }
        public string Email { get; set; }
        public  Mesto  Mesto_idmes { get; set; }
        public int Plat { get; set; }
        public int Dokoncene_zakazky { get; set; }

    }
}
