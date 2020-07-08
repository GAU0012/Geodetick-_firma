using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyORM.ORM.Dao
{
   public class ShowMesto
    {
        public static String SQL_INSERT = "INSERT INTO mesto (idMes, nazev_mesta, psc) VALUES (@idMes, @nazev_mesta, @psc)";
        public static string SQL_Detail = "Select idmes, nazev_mesta, psc from mesto where idmes=@idmes";
        public static String SQL_FIND_BY_NAME = "SELECT idMes, nazev_mesta, psc FROM mesto WHERE nazev_mesta = @nazev ";

        public static int Insert(int idMes, string nazev_mesta, int psc, Database pDb = null)
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
            command.Parameters.AddWithValue("@idMes", idMes);
            command.Parameters.AddWithValue("@nazev_mesta", nazev_mesta);
            command.Parameters.AddWithValue("@psc", psc);
           
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Mesto Detail_mesta(int idMes, Database pDb = null)
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
            command.Parameters.AddWithValue("@idmes", idMes);
            SqlDataReader reader = db.Select(command);


            Mesto mesta = Read_jedno(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return mesta;
        }

        public static Collection<Mesto> Hledani_mesta_dle_nazvu (string nazev, Database pDb = null)
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
            command.Parameters.AddWithValue("@nazev", nazev);
            SqlDataReader reader = db.Select(command);

            Collection<Mesto> mesto = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return mesto;
        }


        private static Collection<Mesto> Read(SqlDataReader reader)
        {
            Collection<Mesto> mesta = new Collection<Mesto>();
            while (reader.Read())
            {
                Mesto mesto = new Mesto();
                int i = -1;
                mesto.Idmes = reader.GetInt32(++i);
                mesto.Nazev_mesta = reader.GetString(++i);
                mesto.Psc = reader.GetInt32(++i);
                mesta.Add(mesto);
            }
            return mesta;
        }
        private static Mesto Read_jedno(SqlDataReader reader)
        {
            Mesto mesto = new Mesto();
            while (reader.Read())
            {
                
                int i = -1;
                mesto.Idmes = reader.GetInt32(++i);
                mesto.Nazev_mesta = reader.GetString(++i);
                mesto.Psc = reader.GetInt32(++i);
                
            }
            return mesto;
        }

    }
}
