using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyORM.ORM
{
    public class Lokalita
    {
        public int Idlok { get; set; }
        public string Ulice_cislo { get; set; }
        public string Katastralni_uzemi { get; set; }
        public Mesto Mesto_idmes { get; set; }
        public int Pocet_zakazek { get; set; }
        public int Trzba { get; set; }
    }
}
