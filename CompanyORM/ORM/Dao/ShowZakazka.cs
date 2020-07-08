using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace CompanyORM.ORM.Dao
{
    
    public class ShowZakazka
    {
        public static String SQL_SELECT_Deail = "SELECT idZak, datum, objednavatel_idobj, lokalita_idlok, typ_zakazky_idtyp, cena, casova_narocnost, geodet_idGeo, stav FROM Zakazka where idZak = @idZak";
        public static String SQL_SELECT = "SELECT idZak, datum, objednavatel_idobj, lokalita_idlok, typ_zakazky_idtyp, cena, casova_narocnost, geodet_idGeo, stav FROM Zakazka ORDER BY datum";
        public static String SQL_SELECT_STAV = "SELECT idZak, datum, objednavatel_idobj, lokalita_idlok, typ_zakazky_idtyp, cena, casova_narocnost, geodet_idGeo, stav FROM Zakazka WHERE stav=@Stav ORDER BY datum";
        public static String SQL_UPDATE = "UPDATE zakazka SET stav='probihajici' WHERE idZak=@p_zakazka";
        public static String SQL_GEODET = "SELECT  g.idGeo, g.jmeno_geodeta ,g.prijmeni_geodeta, g.ulice_cislo, g.email, g.mesto_idmes, g.plat, g.dokoncene_zakazky FROM Geodet g WHERE g.idGeo IN (SELECT Geodet_idGeo FROM Zakazka where stav='probihajici')";
        public static String SQL_MAZANI = "DELETE FROM zakazka WHERE datum <= @oldDate and stav = 'dokoncena'";
        public static String SQL_UPDATE_TYP_ZAKAZKA = "UPDATE typ_zakazky SET pocet_typu = pocet_typu + 1 WHERE idTyp in (SELECT typ_zakazky_idTyp FROM zakazka WHERE datum <= @oldDate AND stav = 'dokoncena')";
        public static String SQL_UPDATE_GEODET = "UPDATE geodet SET dokoncene_zakazky = dokoncene_zakazky + 1 WHERE idGeo in (SELECT geodet_idGeo FROM zakazka WHERE datum <= @oldDate AND stav = 'dokoncena')";
        public static String SQL_UPDATE_Pracovnici = "UPDATE geodet SET plat=plat*1.03 WHERE idGeo IN (SELECT geodet_idGeo FROM zakazka WHERE MONTH(datum)= @currDate and stav='dokoncena')";
        public static String SQL_POCET_NEJ_PRACOVNIKU = "SELECT * FROM zakazka WHERE cena>10000 and MONTH(datum)= @currDate and stav='dokoncena'";
        public static String SQL_UPDATE_NEJ_PRACOVNIK = "UPDATE geodet SET plat = plat * 1.06 WHERE idGEO IN (SELECT geodet_idGeo FROM zakazka WHERE cena > 10000 and MONTH(datum) = @currDate and stav = 'dokoncena')";
        public static String SQL_Cena = "Select idZak, datum, objednavatel_idobj, lokalita_idlok, typ_zakazky_idtyp, cena, casova_narocnost, geodet_idGeo, stav, idLok FROM zakazka where idZak = 1";
        public static String SQL_Delete = "DELETE FROM zakazka WHERE idZak = @idZak";
        public static String SQL_INSERT = "INSERT INTO zakazka (idZak, datum, objednavatel_idObj, lokalita_idLok, typ_zakazky_idTyp, cena, casova_narocnost, geodet_idGeo, stav) " +
            "VALUES (@idZak, @datum, @objednavatel_idObj, @lokalita_idLok, @typ_zakazky_idTyp, @cena, @casova_narocnost, @geodet_idGeo, @stav)";
        public static String SQL_SMAZANI_HISTORIE_ZAKAZEK = "DELETE FROM historie_zakazek WHERE zakazka_idZak IN (SELECT idZak FROM zakazka WHERE datum <= @oldDate and stav = 'dokoncena')";



        //5.1
        public static int Insert(int idZak, DateTime datum , int objednavatel_idObj, int lokalita , int typ,int cena, int casova_narocnostnet, int geodet, string stav, Database pDb = null)
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
            command.Parameters.AddWithValue("@idZak", idZak);
            command.Parameters.AddWithValue("@datum", DateTime.Now);
            command.Parameters.AddWithValue("@objednavatel_idObj", objednavatel_idObj);
            command.Parameters.AddWithValue("@lokalita_idLok", lokalita);
            command.Parameters.AddWithValue("@typ_zakazky_idTyp", typ);
            command.Parameters.AddWithValue("@cena  ", cena);
            command.Parameters.AddWithValue("@casova_narocnost", casova_narocnostnet);
            command.Parameters.AddWithValue("@geodet_idGeo", geodet);
            command.Parameters.AddWithValue("@stav", stav);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        //5.3
        public static Collection<Zakazka> Select_Aktualni(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT);

            SqlDataReader reader = db.Select(command);
            Collection<Zakazka> Zakazky = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Zakazky;

        }


        //5.4
        public static Collection<Zakazka> Select_Aktualni_dle_stavu (string stav, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_STAV);
            command.Parameters.AddWithValue("@Stav", stav);
            SqlDataReader reader = db.Select(command);

            Collection<Zakazka> Zakazky = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Zakazky;
        }


        //5.5
        public static Collection<Geodet> Select_geodet(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_GEODET);
            SqlDataReader reader = db.Select(command);
            
            Collection<Geodet> Geodeti = ShowGeodet.Read_geo(reader);

            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return Geodeti;
        }
        // 5.6
        public static int Update(int idzak, Database pDb = null)
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
            command.Parameters.AddWithValue("@p_zakazka", idzak);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        //5.7
        public static void Smazani(Database pDb = null)
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

            try
            {
                db.BeginTransaction();
                SqlCommand command2 = db.CreateCommand(SQL_UPDATE_TYP_ZAKAZKA);
                command2.Parameters.AddWithValue("@oldDate", DateTime.Now.AddYears(-1));
                db.ExecuteNonQuery(command2);

                SqlCommand command3 = db.CreateCommand(SQL_UPDATE_GEODET);
                command3.Parameters.AddWithValue("@oldDate", DateTime.Now.AddYears(-1));
                db.ExecuteNonQuery(command3);

                SqlCommand command4 = db.CreateCommand(SQL_SMAZANI_HISTORIE_ZAKAZEK);
                command4.Parameters.AddWithValue("@oldDate", DateTime.Now.AddYears(-1));
                db.ExecuteNonQuery(command4);

                SqlCommand command = db.CreateCommand(SQL_MAZANI);
                command.Parameters.AddWithValue("@oldDate", DateTime.Now.AddYears(-1));
                db.ExecuteNonQuery(command);

                db.EndTransaction();
            }
            
           catch (Exception e)
            {
                db.Rollback();
                Console.WriteLine("Chyba, rusim transakci");
                Console.WriteLine(e.Message);
            } 
            

            if (pDb == null)
            {
                db.Close();
            }

        }
        //5.8
        public static Zakazka Detail_zakazky(int idZak ,Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_Deail);
            command.Parameters.AddWithValue("@idZak", idZak);
            SqlDataReader reader = db.Select(command);
         

            Zakazka Zakazka = Read_one(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return Zakazka;
        }

        //5.9
        public static void Nejpracovnici(Database pDb = null)
        {
            int mesic = DateTime.Now.Month;

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

            SqlCommand command = db.CreateCommand(SQL_UPDATE_Pracovnici);
            command.Parameters.AddWithValue("@currDate", mesic);
            db.ExecuteNonQuery(command);

            SqlCommand command3 = db.CreateCommand(SQL_UPDATE_NEJ_PRACOVNIK);
            command3.Parameters.AddWithValue("@currDate", mesic);
            db.ExecuteNonQuery(command3);

     
            if (pDb == null)
            {
                db.Close();
            }
           

        }
            
        //5.10
        public static int Delete (int idZak, Database pDb = null)
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

            ShowHistorieZakazek.Delete(idZak);

            SqlCommand command = db.CreateCommand(SQL_Delete);
            command.Parameters.AddWithValue("@idZak", idZak);
            int ret = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }


        public static Collection<Zakazka> Read(SqlDataReader reader)
        {
            Collection<Zakazka> zakazky = new Collection<Zakazka>();

            while (reader.Read())
            {
                Zakazka zakazka = new Zakazka();
                int i = -1;
                zakazka.Idzak = reader.GetInt32(++i);
                zakazka.Datum = reader.GetDateTime(++i);
                zakazka.Objednavatel_idobj = ShowObjednavatel.Detail_objednavatele(reader.GetInt32(++i));
                zakazka.Lokalita_idlok = ShowLokalita.Select(reader.GetInt32(++i));
                zakazka.Typ_zakazky_idtyp = ShowTypZakazek.Detail_typu_zakazky(reader.GetInt32(++i));
                zakazka.Cena = reader.GetInt32(++i);
                zakazka.Casova_narocnost = reader.GetInt32(++i);
                zakazka.Geodet_idgeo = ShowGeodet.Detail_geodeta(reader.GetInt32(++i));
                zakazka.Stav = reader.GetString(++i);

                zakazky.Add(zakazka);
            }
            return zakazky;
        }


        public static Zakazka Read_one(SqlDataReader reader)
        {
            Zakazka zakazka = new Zakazka();

            while (reader.Read())
            {
                int i = -1;
                zakazka.Idzak = reader.GetInt32(++i);
                zakazka.Datum = reader.GetDateTime(++i);
                zakazka.Objednavatel_idobj = ShowObjednavatel.Detail_objednavatele(reader.GetInt32(++i));
                zakazka.Lokalita_idlok = ShowLokalita.Select(reader.GetInt32(++i));
                zakazka.Typ_zakazky_idtyp = ShowTypZakazek.Detail_typu_zakazky(reader.GetInt32(++i));
                zakazka.Cena = reader.GetInt32(++i);
                zakazka.Casova_narocnost = reader.GetInt32(++i);
                zakazka.Geodet_idgeo = ShowGeodet.Detail_geodeta(reader.GetInt32(++i));
                zakazka.Stav = reader.GetString(++i);
            }
            return zakazka;
        }

    }
}


