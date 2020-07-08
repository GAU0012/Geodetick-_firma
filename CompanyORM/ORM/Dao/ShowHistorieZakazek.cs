using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyORM.ORM.Dao
{
    public class ShowHistorieZakazek
    {
        public static String SQL_SELECT = "SELECT idhis, datumOd, datumDo, zakazka_idzak, typ_zakazky_idtyp FROM historie_zakazek where idHis = @idHis";
        public static String SQL_INSERT = " INSERT INTO historie_zakazek values (@idHis ,@p_startDay, @date, @p_zakazka, @p_typ_zakazky)";
        public static String SQL_UPDATE_ZAKAZKA = "UPDATE zakazka SET stav = 'dokoncena' where idZak = @p_zakazka";
        public static String SQL_UPDATE_LOKALITA = "Update lokalita Set pocet_zakazek = pocet_zakazek + 1 Where idLok IN (SELECT lokalita_idLok FROM zakazka where idZak = @p_zakazka)";
        public static String SQL_UPDATE_TRZBA = "UPDATE lokalita SET trzba = trzba + (SELECT cena FROM zakazka WHERE idZak= @p_zakazka) WHERE idlok in (Select lokalita_idLok FROM zakazka where idZak = @p_zakazka)";
        public static String SQL_UPDATE_LOKALITA_CENA = "UPDATE lokalita SET trzba = trzba + $Aktualni_trzba WHERE idZak = @p_zakazka";
        public static String SQL_SETRIDIT_VYDELEK = "SELECT h.idhis, h.datumOd, h.datumDo, h.zakazka_idzak, h.typ_zakazky_idtyp FROM historie_zakazek h Join zakazka z ON z.idZak = h.zakazka_idZak Where h.datumOd > @datumOd and h.datumDo < @DatumDo Order by z.cena DESC";
        public static String SQL_SETRIDIT_CASOVA_NAROCNOST = "SELECT  h.idhis, h.datumOd, h.datumDo, h.zakazka_idzak, h.typ_zakazky_idtyp FROM historie_zakazek h Join zakazka z ON z.idZak = h.zakazka_idZak Where h.datumOd > @datumOd and h.datumDo < @DatumDo Order by z.casova_narocnost DESC";
        public static String SQL_SETRIDIT = "SELECT h.idhis, h.datumOd, h.datumDo, h.zakazka_idzak, h.typ_zakazky_idtyp FROM historie_zakazek h Join zakazka z ON z.idZak = h.zakazka_idZak Where h.datumOd > @datumOd and h.datumDo < @DatumDo";
        public static String SQL_CELKOVA_CENA = "Select sum(z.cena) FROM zakazka z Join historie_zakazek h on h.zakazka_idzak = z.idZak where h.datumOd > @datumOd and h.datumDo < @datumDo ";
        public static String SQL_PLAT_NEJ_GEODET = "UPDATE geodet SET plat = plat * 1.25 WHERE idGeo in " +
            " ( SELECT z.geodet_idGeo FROM historie_zakazek h JOIN zakazka z on z.idZak = h.zakazka_idZak WHERE YEAR(h.datumDo) = YEAR(GETDATE()) - 1 " +
            "GROUP BY z.geodet_idGeo, z.casova_narocnost having z.casova_narocnost = ( SELECT max(tab.pocet) FROM ( SELECT z.geodet_idGeo, count(z.casova_narocnost) as pocet FROM historie_zakazek h JOIN zakazka z ON z.idZak = h.zakazka_idZak WHERE YEAR(h.datumDo) = YEAR(GETDATE()) - 1 GROUP BY z.geodet_idGeo)tab))";
        public static String SQL_DELETE = "DELETE FROM historie_zakazek WHERE zakazka_idzak = @idZak";
        public static String SQL_MAX = "SELECT MAX(idHis) + 1 from historie_zakazek";
        




        //6.1
        public static void Insert(DateTime p_startDay, DateTime p_end, int p_zakazka, int p_typ_zakazky, Database pDb = null)
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

            SqlCommand command5 = db.CreateCommand(SQL_MAX);
            int Max_Id = (int)command5.ExecuteScalar();

            try
            {
                db.BeginTransaction();
                SqlCommand command = db.CreateCommand(SQL_INSERT);
                command.Parameters.AddWithValue("@idHis", Max_Id);
                command.Parameters.AddWithValue("@p_startDay", p_startDay);
                command.Parameters.AddWithValue("@date", p_end);
                command.Parameters.AddWithValue("@p_zakazka", p_zakazka);
                command.Parameters.AddWithValue("@p_typ_zakazky", p_typ_zakazky);
                int ret = db.ExecuteNonQuery(command);

                Console.WriteLine(ret.ToString());
               
                SqlCommand command2 = db.CreateCommand(SQL_UPDATE_ZAKAZKA);
                command2.Parameters.AddWithValue("@p_zakazka", p_zakazka);
                int ret2 = db.ExecuteNonQuery(command2);

                SqlCommand command3 = db.CreateCommand(SQL_UPDATE_LOKALITA);
                command3.Parameters.AddWithValue("@p_zakazka", p_zakazka);
                db.ExecuteNonQuery(command3);

                
                SqlCommand command4 = db.CreateCommand(SQL_UPDATE_TRZBA);
                command4.Parameters.AddWithValue("@p_zakazka", p_zakazka);
                db.ExecuteNonQuery(command4);

                db.EndTransaction();
                
            }

            catch (Exception e)
            {
                
                db.Rollback();
                Console.WriteLine("Insert se nepovedl");
                Console.WriteLine(e.Message);
            }

            if (pDb == null)
            {
                db.Close();
            }

        }

        //6.2
        public static Historie_zakazek Select(int idHis, Database pDb = null)
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
            command.Parameters.AddWithValue("@idHis", idHis);
            SqlDataReader reader = db.Select(command);

            Historie_zakazek Historie_zakazky = Read_historie_one(reader);

            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return Historie_zakazky;
        }


        //6.3
        public static Collection<Historie_zakazek> Setrid (DateTime datumOd, DateTime datumDo, string setrideni)
        {
            if (setrideni == "max.vydelek")
                {
                Database db = new Database();
                db.Connect();
                SqlCommand command = db.CreateCommand(SQL_SETRIDIT_VYDELEK);
                command.Parameters.AddWithValue("@datumOd", datumOd);
                command.Parameters.AddWithValue("@datumDo", datumDo);
             

                SqlDataReader reader = db.Select(command);
                Collection<Historie_zakazek> Zakazky = Read_historie(reader);
                reader.Close();
                db.Close();
                return Zakazky;

            }
            else if (setrideni == "casova_narocnost")
                {
                Database db = new Database();
                db.Connect();
                SqlCommand command2 = db.CreateCommand(SQL_SETRIDIT_CASOVA_NAROCNOST);
                command2.Parameters.AddWithValue("@datumOd", datumOd);
                command2.Parameters.AddWithValue("@datumDo", datumDo);
                db.ExecuteNonQuery(command2);

                SqlDataReader reader = db.Select(command2);
                Collection<Historie_zakazek> Zakazky = Read_historie(reader);
                reader.Close();
                db.Close();
                return Zakazky;

            }
            else
                {
                Database db = new Database();
                db.Connect();
                SqlCommand command3 = db.CreateCommand(SQL_SETRIDIT);
                command3.Parameters.AddWithValue("@datumOd", datumOd);
                command3.Parameters.AddWithValue("@datumDo", datumDo);
                db.ExecuteNonQuery(command3);

                SqlDataReader reader = db.Select(command3);
                Collection<Historie_zakazek> Zakazky = Read_historie(reader);
                reader.Close();
                db.Close();
                return Zakazky;
            }
        }
        
        
       
         //6.4
        public static int Celkova_cena(DateTime datumOd, DateTime datumDo, Database pDb = null)
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
            SqlCommand command2 = db.CreateCommand(SQL_CELKOVA_CENA);
            command2.Parameters.AddWithValue("@datumOd", datumOd);
            command2.Parameters.AddWithValue("@datumDo", datumDo);

            int result = 0;
            try
            {
                result = (int)command2.ExecuteScalar();
            }
            catch
            {
                return 0;
            }
            if (pDb == null)
            {
                db.Close();
            }

            return result;
        }
        
        //6.5
        public static int Zvyseni_platu (Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_PLAT_NEJ_GEODET);
            int status = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }
            return status;
        }

        public static int Delete(int idZak, Database pDb = null)
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
            command.Parameters.AddWithValue("@idZak", idZak);
            int status = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }
            return status;

        }


        public static Collection<Historie_zakazek>  Read_historie (SqlDataReader reader)
        {
            Collection<Historie_zakazek> zakazky = new Collection<Historie_zakazek>();
            //Collection<Zakazka> zak = ShowZakazka.Select_Aktualni();


            while (reader.Read())
            {     
                Historie_zakazek historie = new Historie_zakazek();
                int i = -1;
                historie.Idhis = reader.GetInt32(++i);
                historie.Datumod = reader.GetDateTime(++i);
                historie.Datumdo = reader.GetDateTime(++i);
                historie.Zakazka_idzak = ShowZakazka.Detail_zakazky(reader.GetInt32(++i));
                historie.Typ_zakazky_idtyp = ShowTypZakazek.Detail_typu_zakazky(reader.GetInt32(++i));

                zakazky.Add(historie);
               
            }
            return zakazky;
        }

        public static Historie_zakazek Read_historie_one(SqlDataReader reader)
        {
            Historie_zakazek historie = new Historie_zakazek();

            while (reader.Read())
            {
                
                int i = -1;
                historie.Idhis = reader.GetInt32(++i);
                historie.Datumod = reader.GetDateTime(++i);
                historie.Datumdo = reader.GetDateTime(++i);
                historie.Zakazka_idzak = ShowZakazka.Detail_zakazky(reader.GetInt32(++i));
                historie.Typ_zakazky_idtyp = ShowTypZakazek.Detail_typu_zakazky(reader.GetInt32(++i));

            }
            return historie;
        }


        
    }
}
