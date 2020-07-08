using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace CompanyORM.ORM.Dao
{
    
    

    class ShowObjednavatel
    {
        public static String SQL_INSERT = "INSERT INTO objednavatel (idObj, jmeno_objednavatele, ulice_cislo, bankovni_spojeni, ico, dic, mesto_idMes) " +
                                           "VALUES (@idObj, @jmeno, @ulice_cislo, @bankovni_spojeni, @ico, @dic, @mesto_idMes)";
        public static String SQL_Detail = "Select idObj, jmeno_objednavatele, ulice_cislo, bankovni_spojeni, ico, dic, mesto_idmes FROM Objednavatel where idObj = @idObj";
        public static String SQL_Update = "Update objednavatel SET jmeno_objednavatele = @jmeno , ulice_cislo = @ulice,  bankovni_spojeni = @banka, ico = @ico, dic = @dic, mesto_idMes = @mesto WHERE idobj = @idObj";
        public static String SQL_FIND_BY_NAME = "Select idObj, jmeno_objednavatele, ulice_cislo, bankovni_spojeni, ico, dic, mesto_idmes FROM Objednavatel WHERE jmeno_objednavatele = @jmeno";
        public static String SQL_FIND_BY_CITY = "Select idObj, jmeno_objednavatele, ulice_cislo, bankovni_spojeni, ico, dic, mesto_idmes FROM Objednavatel where mesto_idmes = @mesto";



        public static int Insert (int idObj, string jmeno_objednavatele, string ulice_cislo, string bankovni_spojeni, int ico, int dic, int mesto, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            command.Parameters.AddWithValue("@idObj", idObj);
            command.Parameters.AddWithValue("@jmeno", jmeno_objednavatele);
            command.Parameters.AddWithValue("@ulice_cislo", ulice_cislo);
            command.Parameters.AddWithValue("@bankovni_spojeni", bankovni_spojeni);
            command.Parameters.AddWithValue("@ico", ico);
            command.Parameters.AddWithValue("@dic", dic);
            command.Parameters.AddWithValue("@mesto_idMes", mesto);

            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Objednavatel Detail_objednavatele(int idObj, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_Detail);
            command.Parameters.AddWithValue("@idObj", idObj);
            SqlDataReader reader = db.Select(command);


            Objednavatel zakaznici = Read_one(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return zakaznici;
        }

       public static int Update (int idObj, string jmeno_objedna, string ulice_cislo, string bankovni_spojeni, int ico, int dic, int mesto, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_Update);
            command.Parameters.AddWithValue("@idObj", idObj);
            command.Parameters.AddWithValue("@jmeno", jmeno_objedna);
            command.Parameters.AddWithValue("@ulice", ulice_cislo);
            command.Parameters.AddWithValue("@banka", bankovni_spojeni);
            command.Parameters.AddWithValue("@ICO", ico);
            command.Parameters.AddWithValue("@DIC", dic);
            command.Parameters.AddWithValue("@mesto", mesto);

            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }

            return ret;

        }

        public static Collection<Objednavatel> Seznam_zakazniku_dle_jmena (string jmeno, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_FIND_BY_NAME);
            command.Parameters.AddWithValue("@jmeno", jmeno);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavatel> zakaznici = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return zakaznici;
        }

        public static Collection<Objednavatel> Seznam_zakazniku_dle_mesta (int mesto, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            Console.WriteLine("idMes:" + mesto);
            SqlCommand command = db.CreateCommand(SQL_FIND_BY_CITY);
            command.Parameters.AddWithValue("@mesto", mesto);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavatel> zakaznici = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return zakaznici;
        }



        private static Collection<Objednavatel> Read (SqlDataReader reader)
        {
            Collection<Objednavatel> zakaznici = new Collection<Objednavatel>();

            while (reader.Read())
            {
                Objednavatel objednavatel = new Objednavatel();
                int i = -1;
                objednavatel.Idobj = reader.GetInt32(++i);
                objednavatel.Jmeno_objednavatele = reader.GetString(++i);
                objednavatel.Ulice_cislo = reader.GetString(++i);
                objednavatel.Bankovni_spojeni = reader.GetString(++i);
                objednavatel.Ico = reader.GetInt32(++i);
                objednavatel.Dic = reader.GetInt32(++i);
                objednavatel.Mesto_idmes = ShowMesto.Detail_mesta(reader.GetInt32(++i));
                zakaznici.Add(objednavatel);
            }
            return zakaznici;
        }

        private static Objednavatel Read_one (SqlDataReader reader)
        {
            Objednavatel zakaznici = new Objednavatel();

            while (reader.Read())
            {
                
                int i = -1;
                zakaznici.Idobj = reader.GetInt32(++i);
                zakaznici.Jmeno_objednavatele = reader.GetString(++i);
                zakaznici.Ulice_cislo = reader.GetString(++i);
                zakaznici.Bankovni_spojeni = reader.GetString(++i);
                zakaznici.Ico = reader.GetInt32(++i);
                zakaznici.Dic = reader.GetInt32(++i);
                zakaznici.Mesto_idmes = ShowMesto.Detail_mesta(reader.GetInt32(++i));
               
            }
            return zakaznici;
        }

    }
}
