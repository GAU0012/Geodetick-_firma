using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CompanyORM.ORM.Dao
{
    class ShowLokalita
    {
        public static String SQL_INSERT = "INSERT INTO lokalita (idLok, ulice_cislo, katastralni_uzemi, mesto_idMes, pocet_zakazek, trzba) " +
                                            "VALUES (@idLok, @ulice_cislo, @katastralni_uzemi, @meto_idMes, @pocet_zakazek, @trzba)";
        public static String SQL_NEJCASTEJSI_LOKALITY = "SELECT idLok, ulice_cislo, katastralni_uzemi, mesto_idMes, pocet_zakazek, trzba FROM Lokalita Order by pocet_zakazek";
        public static String SQL_NEJVYDELECNEJSI_LOKALITY = "SELECT idLok, ulice_cislo, katastralni_uzemi, mesto_idMes, pocet_zakazek, trzba FROM Lokalita Order by trzba DESC";
        public static String SQL_SELECT_detail = "SELECT idLok, ulice_cislo, katastralni_uzemi, mesto_idMes, pocet_zakazek, trzba FROM lokalita where idLok = @idLok";
        public static String SQL_DELETE = "DELETE FROM lokalita WHERE idLok = @idLok";
        public static String SQL_SELECT_DLE_KATASTRU = "Select idLok, ulice_cislo, katastralni_uzemi, mesto_idMes, pocet_zakazek, trzba from lokalita where katastralni_uzemi = @katastr";
        public static String SQL_Update = "UPDATE lokalita SET  ulice_cislo = @ulice_cislo, katastralni_uzemi = @katastralni_uzemi, mesto_idmes = @mesto_idmes, " +
            "pocet_zakazek = @pocet_zakazek, trzba = @trzba where idlok = @idlok";

         
        //7.1
        public static int Insert (int idLok, string ulice_cislo, string katastralni_uzemi,int mesto, int pocet_zakazek, int trzba, Database pDb = null)
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
            command.Parameters.AddWithValue("@idLok", idLok);
            command.Parameters.AddWithValue("@ulice_cislo", ulice_cislo);
            command.Parameters.AddWithValue("@katastralni_uzemi", katastralni_uzemi);
            command.Parameters.AddWithValue("@meto_idMes", mesto);
            command.Parameters.AddWithValue("@pocet_zakazek", pocet_zakazek);
            command.Parameters.AddWithValue("@trzba", trzba);
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }
        
        //7.2
        public static Collection<Lokalita> Nejcastejsi_lokality (Database pDb = null)
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

            Console.WriteLine("Nejčastější lokality: ");
            SqlCommand command = db.CreateCommand(SQL_NEJCASTEJSI_LOKALITY);
            SqlDataReader reader = db.Select(command);

            Collection<Lokalita> lokality = Read_lokalita(reader);

            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return lokality;
        }

        //7.3
        public static Collection<Lokalita> Nejvydelecnejsi_lokality(Database pDb = null)
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
            Console.WriteLine("Nejvzdělečnější lokality: ");
            SqlCommand command = db.CreateCommand(SQL_NEJVYDELECNEJSI_LOKALITY);
            SqlDataReader reader = db.Select(command);

            Collection<Lokalita> lokality = Read_lokalita(reader);

            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return lokality;
        }

        //7.4
        public static Lokalita Select (int idLok, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_detail);
            command.Parameters.AddWithValue("@idLok", idLok);
            SqlDataReader reader = db.Select(command);

            Lokalita lokalita = Read_lokalita_one(reader);

            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return lokalita;
        }

        public static Collection<Lokalita> Select_dle_katastru (string katastr, Database pDb = null)
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
            Console.WriteLine("Lokalita v vybranem katastru:  ");
            SqlCommand command = db.CreateCommand(SQL_SELECT_DLE_KATASTRU);
            command.Parameters.AddWithValue("@katastr", katastr);
            SqlDataReader reader = db.Select(command);

            Collection<Lokalita> lokality = Read_lokalita(reader);

            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return lokality;
        }



        private static int DELETE (int idLok, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_DELETE);
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(int idlok, string ulice_cislo, string katastralni_uzemi, int idmes, int pocet, int trzba, Database pDb = null)
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
            command.Parameters.AddWithValue("@idlok", idlok);
            command.Parameters.AddWithValue("@ulice_cislo", ulice_cislo);
            command.Parameters.AddWithValue("@katastralni_uzemi", katastralni_uzemi);
            command.Parameters.AddWithValue("@mesto_idmes", idmes);
            command.Parameters.AddWithValue("@pocet_zakazek", pocet);
            command.Parameters.AddWithValue("@trzba", trzba);
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }

            return ret;

        }


        private static Collection<Lokalita> Read_lokalita(SqlDataReader reader)
        {
            Collection<Lokalita> lokality = new Collection<Lokalita>();

            while (reader.Read())
            {
                Lokalita lokalita = new Lokalita();
                int i = -1;
                lokalita.Idlok = reader.GetInt32(++i);
                lokalita.Ulice_cislo = reader.GetString(++i);
                lokalita.Katastralni_uzemi = reader.GetString(++i);
                lokalita.Mesto_idmes = ShowMesto.Detail_mesta(++i);
                lokalita.Pocet_zakazek = reader.GetInt32(++i);
                lokalita.Trzba = reader.GetInt32(++i);

                lokality.Add(lokalita);
            }
            return lokality;
        }

        private static Lokalita Read_lokalita_one(SqlDataReader reader)
        {
            Lokalita lokalita = new Lokalita();

            while (reader.Read())
            {
                int i = -1;
                lokalita.Idlok = reader.GetInt32(++i);
                lokalita.Ulice_cislo = reader.GetString(++i);
                lokalita.Katastralni_uzemi = reader.GetString(++i);
                lokalita.Mesto_idmes = ShowMesto.Detail_mesta(reader.GetInt32(++i));
                lokalita.Pocet_zakazek = reader.GetInt32(++i);
                lokalita.Trzba = reader.GetInt32(++i);
            }
            return lokalita;
        }
    }




                

   
}
