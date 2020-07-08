using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyORM.ORM
{
    public class Historie_zakazek
    {
        public int Idhis { get; set; }
        public DateTime Datumod { get; set; }
        public DateTime Datumdo { get; set; }
        public Zakazka Zakazka_idzak { get; set; }
        public Typ_zakazky Typ_zakazky_idtyp { get; set; }
    }
}
