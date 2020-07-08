using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyORM.ORM.Dao
{
    class ShowTypZakazek
    {

        public static String SQL_INSERT = "INSERT INTO typ_zakazky (Idtyp, Jmeno_zakazky, Pocet_typu) VALUES (@IdTyp, @Jmeno_zakazky, @Pocet_typu)";
        public static String SQL_UPDATE = "UPDATE typ_zakazky SET Jmeno_zakazky = @Jmeno_zakazky, Pocet_typu = @Pocet_typu where idTyp = @idTyp ";
        public static String SQL_DETAIL = "SELECT Idtyp, Jmeno_zakazky, Pocet_typu FROM typ_zakazky WHERE idTyp = @idTyp ";
        public static String SQL_SELECT_BY_AMOUNT = "SELECT idTyp, jmeno_zakazky, pocet_typu FROM typ_zakazky ORDER BY pocet_typu DESC";
        public static String SQL_UPDATE_TYP_ZAKAZKA = "UPDATE typ_zakazky SET pocet_typu = pocet_typu + 1 WHERE idTyp in (SELECT typ_zakazky_idTyp FROM zakazka WHERE datum <= @oldDate AND stav = 'dokoncena')";



        public static int Insert(int idTyp, string jmeno_zakazky, int Pocet_typu, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdTyp", idTyp);
            command.Parameters.AddWithValue("@Jmeno_zakazky", jmeno_zakazky);
            command.Parameters.AddWithValue("@Pocet_typu", Pocet_typu);
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(int idTyp, string Jmeno_zakazky, int Pocet_typu, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            command.Parameters.AddWithValue("@Jmeno_zakazky", Jmeno_zakazky);
            command.Parameters.AddWithValue("@Pocet_typu", Pocet_typu);
            command.Parameters.AddWithValue("@idTyp", idTyp);
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }

        public static Typ_zakazky Detail_typu_zakazky(int idTyp, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_DETAIL);
            command.Parameters.AddWithValue("@idTyp", idTyp);
            SqlDataReader reader = db.Select(command);

            Typ_zakazky typy = Read_One(reader);
            reader.Close();
            
            if (pDb == null)
            {
                db.Close();
            }
            
            return typy;
        }

         public static Collection<Typ_zakazky> Seznam_Typu_Zakazek_Sestridenych_dle_poctu ( Database pDb = null)
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

            Console.WriteLine("Setřiděné zakázky dle počtu: ");
            SqlCommand command = db.CreateCommand(SQL_SELECT_BY_AMOUNT);
            SqlDataReader reader = db.Select(command);

            Collection<Typ_zakazky> typy = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return typy;
        }


        private static Collection<Typ_zakazky> Read(SqlDataReader reader)
        {
            Collection<Typ_zakazky> typy_zakazek = new Collection<Typ_zakazky>();

            while (reader.Read())
            {
                Typ_zakazky Typ = new Typ_zakazky();
                int i = -1;
                Typ.Idtyp = reader.GetInt32(++i);
                Typ.Jmeno_zakazky = reader.GetString(++i);
                Typ.Pocet_typu = reader.GetInt32(++i);
                typy_zakazek.Add(Typ);
            }
            return typy_zakazek;
        }


        private static Typ_zakazky Read_One(SqlDataReader reader)
        {
            Typ_zakazky typy_zakazek = new Typ_zakazky();

            while (reader.Read())
            {
                
                int i = -1;
                typy_zakazek.Idtyp = reader.GetInt32(++i);
                typy_zakazek.Jmeno_zakazky = reader.GetString(++i);
                typy_zakazek.Pocet_typu = reader.GetInt32(++i);
                
            }
            return typy_zakazek;
        }

    }



}

