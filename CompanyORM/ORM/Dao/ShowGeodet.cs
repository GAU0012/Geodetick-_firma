using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyORM.ORM.Dao
{
   public class ShowGeodet
    {

        public static String SQL_INSERT = "INSERT INTO geodet (idgeo, jmeno_geodeta, prijmeni_geodeta, ulice_cislo, email, mesto_idmes, plat, dokoncene_zakazky) VALUES (@idGeo, @jmeno_geodeta, @prijmeni_geodeta, @ulice_cislo, @email, @mesto_idmes, @plat, @dokoncene_zakazky)";
        public static String SQL_Update = "UPDATE geodet SET jmeno_geodeta = @jmeno_geodeta, prijmeni_geodeta = @prijmeni_geodeta, ulice_cislo = @ulice_cislo, email = @email, mesto_idmes = @mesto_idmes, plat = @plat, dokoncene_zakazky = @dokoncene WHERE idGeo = @idGeo ";
        public static String SQL_DETAIL = "Select idGeo, jmeno_geodeta, prijmeni_geodeta, ulice_cislo, email, mesto_idmes, plat, dokoncene_zakazky FROM geodet WHERE idGeo = @idGeo";
        public static String SQL_FIND_BY_NAME = "Select idGeo, jmeno_geodeta, prijmeni_geodeta, ulice_cislo, email, mesto_idmes, plat, dokoncene_zakazky FROM geodet WHERE jmeno_geodeta = @jmeno";
        public static String SQL_FIND_BY_CITY = "Select idGeo, jmeno_geodeta, prijmeni_geodeta, ulice_cislo, email, mesto_idmes, plat, dokoncene_zakazky FROM geodet WHERE mesto_idMes = @mesto";
        public static String SQL_ORDER_BY_PAY = "Select idGeo, jmeno_geodeta, prijmeni_geodeta, ulice_cislo, email, mesto_idmes, plat, dokoncene_zakazky FROM geodet ORDER BY plat DESC";

        public static int Insert(int idGeo, string jmeno_geodeta, string prijmeni_geodeta, string ulice_cislo, string email, int mesto, int plat, int dkoncene_zakazky, Database pDb = null)
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
            command.Parameters.AddWithValue("@idGeo", idGeo);
            command.Parameters.AddWithValue("@jmeno_geodeta", jmeno_geodeta);
            command.Parameters.AddWithValue("@prijmeni_geodeta", prijmeni_geodeta);
            command.Parameters.AddWithValue("@ulice_cislo", ulice_cislo);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@mesto_idmes", mesto);
            command.Parameters.AddWithValue("@plat", plat);
            command.Parameters.AddWithValue("@dokoncene_zakazky", dkoncene_zakazky);
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update (int idGeo, string jmeno_geodeta, string prijmeni_geodeta, string ulice_cislo, string email, int mesto, int plat, int dkoncene_zakazky, Database pDb = null)
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
            command.Parameters.AddWithValue("@idGeo", idGeo);
            command.Parameters.AddWithValue("@jmeno_geodeta", jmeno_geodeta);
            command.Parameters.AddWithValue("@prijmeni_geodeta", prijmeni_geodeta);
            command.Parameters.AddWithValue("@ulice_cislo", ulice_cislo);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@mesto_idmes", mesto);
            command.Parameters.AddWithValue("@plat", plat);
            command.Parameters.AddWithValue("@dokoncene", dkoncene_zakazky);
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }

            return ret;

        }

        public static Geodet Detail_geodeta (int idGeo, Database pDb = null)
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
            command.Parameters.AddWithValue("@idGeo", idGeo);
            SqlDataReader reader = db.Select(command);


            Geodet geodet = Read_geo_ONE(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return geodet;
        }


        public static Collection<Geodet> Seznam_geodetu_dle_jmena (string jmeno, Database pDb = null)
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

            Collection<Geodet> geodet = Read_geo(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return geodet;
        }

        public static Collection<Geodet> Seznam_geodetu_podle_mesta (int mesto, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_FIND_BY_CITY);
            command.Parameters.AddWithValue("@mesto", mesto);
            SqlDataReader reader = db.Select(command);

            Collection<Geodet> geodet = Read_geo(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return geodet;
        }

        public static Collection<Geodet> Seznam_geodetu_setridenych_dle_platu ( Database pDb = null)
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
     
            SqlCommand command = db.CreateCommand(SQL_ORDER_BY_PAY);
            SqlDataReader reader = db.Select(command);

            Collection<Geodet> geodet = Read_geo(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return geodet;
        }

        
        public static Collection<Geodet> Read_geo(SqlDataReader reader)
        {
            Collection<Geodet> geodeti = new Collection<Geodet>();

            while (reader.Read())
            {
                Geodet geodet = new Geodet();
                int i = -1;
                geodet.Idgeo = reader.GetInt32(++i);
                geodet.Jmeno_geodeta = reader.GetString(++i);
                geodet.Prijmeni_geodeta = reader.GetString(++i);
                geodet.Ulice_cislo = reader.GetString(++i);
                geodet.Email = reader.GetString(++i);
                geodet.Mesto_idmes = ShowMesto.Detail_mesta(reader.GetInt32(++i));
                geodet.Plat = reader.GetInt32(++i);
                geodet.Dokoncene_zakazky = reader.GetInt32(++i);

                geodeti.Add(geodet);
            }
            return geodeti;
        }
        

        public static Geodet Read_geo_ONE(SqlDataReader reader)
        {
           Geodet geodet = new Geodet();

            while (reader.Read())
            {
                int i = -1;
                geodet.Idgeo = reader.GetInt32(++i);
                geodet.Jmeno_geodeta = reader.GetString(++i);
                geodet.Prijmeni_geodeta = reader.GetString(++i);
                geodet.Ulice_cislo = reader.GetString(++i);
                geodet.Email = reader.GetString(++i);
                geodet.Mesto_idmes = ShowMesto.Detail_mesta(reader.GetInt32(++i));
                geodet.Plat = reader.GetInt32(++i);
                geodet.Dokoncene_zakazky = reader.GetInt32(++i);
            }
            return geodet;
        }

    }
}
