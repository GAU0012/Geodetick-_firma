using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyORM.ORM
{
    public class Objednavatel
    {
        public int Idobj { get; set; }
        public string Jmeno_objednavatele { get; set; }
        public string Ulice_cislo { get; set; }
        public string Bankovni_spojeni { get; set; }
        public int? Ico { get; set; }
        public int? Dic { get; set; }
        public  Mesto Mesto_idmes { get; set; }
    }
}
