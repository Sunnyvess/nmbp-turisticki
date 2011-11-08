using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;

namespace NMBP___OR {
    static class DatabaseManager {
        public static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";
        static NpgsqlConnection connection = new NpgsqlConnection (connString);
        static DataSet lokacijaDataSet = new DataSet ();
        static DataSet gradDataSet = new DataSet ();
        static NpgsqlDataAdapter adapter = new NpgsqlDataAdapter ();
        static NpgsqlCommand command;

        public static DataTable GradTable () {
            string sqlString = "SELECT * FROM grad";
            command = new NpgsqlCommand (sqlString, connection);
            gradDataSet.Reset ();
            adapter.SelectCommand = command;
            adapter.Fill (gradDataSet);
            return gradDataSet.Tables[0];
        }
        public static DataTable LokacijaTable (string tipLokacije, string adresa) {
            string sqlString = "SELECT naziv, sifra FROM " + tipLokacije + " WHERE (adresa).grad = @adresa";
            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.Clear ();
            command.Parameters.AddWithValue ("@adresa", adresa);
            adapter = new NpgsqlDataAdapter ();

            lokacijaDataSet.Reset ();
            adapter.SelectCommand = command;
            adapter.Fill (lokacijaDataSet);
            return lokacijaDataSet.Tables[0];
        }

        public static void DeleteLocation (string tipLokacije, int sifra) {
            string sqlString = "DELETE FROM " + tipLokacije + " WHERE sifra = @sifra";

            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.Clear ();

            command.Parameters.AddWithValue ("@sifra", sifra);
            connection.Open ();
            command.ExecuteNonQuery ();
            connection.Close ();
        }
        private static void ExecuteCommand () {
            connection.Open ();
            command.ExecuteNonQuery ();
            connection.Close ();
        }

        #region Bolnica

        public static void BolnicaInsert (string naziv, string opis, string radnoVrijeme, bool dezurstvo, string adresa,
            object slika1, string slika1Naziv, object slika2, string slika2Naziv, object slika3, string slika3Naziv) {

            string sqlString = "INSERT INTO bolnica (naziv, opis, radnoVrijeme, dezurstvo, adresa, slika[1], slika[2], slika[3]) VALUES " +
                        "(@naziv, @opis, @radnoVrijeme, @dezurstvo, @adresa, (@slika1Naziv, @slika1Byte), (@slika2Naziv, @slika2Byte), (@slika3Naziv, @slika3Byte))";

            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.AddWithValue ("@naziv", naziv);
            command.Parameters.AddWithValue ("@opis", opis);

            command.Parameters.AddWithValue ("@adresa", adresa);
            command.Parameters.AddWithValue ("@slika1Naziv", slika1Naziv);
            command.Parameters.AddWithValue ("@slika1Byte", slika1);
            command.Parameters.AddWithValue ("@slika2Naziv", slika2Naziv);
            command.Parameters.AddWithValue ("@slika2Byte", slika2);
            command.Parameters.AddWithValue ("@slika3Naziv", slika3Naziv);
            command.Parameters.AddWithValue ("@slika3Byte", slika3);
            command.Parameters.AddWithValue ("@radnoVrijeme", radnoVrijeme);
            command.Parameters.AddWithValue ("@dezurstvo", dezurstvo);

            ExecuteCommand ();
        }
        public static void BolnicaEdit (int sifra, string naziv, string opis, string radnoVrijeme, bool dezurstvo, string adresa,
            object slika1, string slika1Naziv, object slika2, string slika2Naziv, object slika3, string slika3Naziv) {

            string sqlString = "UPDATE bolnica SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, " +
                    "dezurstvo = @dezurstvo, adresa = @adresa, slika[1]=(@slika1Naziv, @slika1Byte), slika[2]=(@slika2Naziv, @slika2Byte), " +
                    "slika[3]=(@slika3Naziv, @slika3Byte) WHERE sifra = @sifra";

            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.AddWithValue ("@naziv", naziv);
            command.Parameters.AddWithValue ("@opis", opis);
            command.Parameters.AddWithValue ("@adresa", adresa);
            command.Parameters.AddWithValue ("@slika1Naziv", slika1Naziv);
            command.Parameters.AddWithValue ("@slika1Byte", slika1);
            command.Parameters.AddWithValue ("@slika2Naziv", slika2Naziv);
            command.Parameters.AddWithValue ("@slika2Byte", slika2);
            command.Parameters.AddWithValue ("@slika3Naziv", slika3Naziv);
            command.Parameters.AddWithValue ("@slika3Byte", slika3);
            command.Parameters.AddWithValue ("@radnoVrijeme", radnoVrijeme);
            command.Parameters.AddWithValue ("@dezurstvo", dezurstvo);
            command.Parameters.AddWithValue ("@sifra", sifra);

            ExecuteCommand ();
        }

        #endregion

        #region Muzej

        public static void MuzejInsert (string naziv, string opis, string radnoVrijeme, string adresa, string tipMuzeja,
            object slika1, string slika1Naziv, object slika2, string slika2Naziv, object slika3, string slika3Naziv) {

            string sqlString = "INSERT INTO muzej (naziv, opis, radnoVrijeme, adresa, tipmuzeja, slika[1], slika[2], slika[3]) VALUES " +
                    "(@naziv, @opis, @radnoVrijeme, @adresa, @tipmuzeja, (@slika1Naziv, @slika1Byte), (@slika2Naziv, @slika2Byte), (@slika3Naziv, @slika3Byte))";

            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.AddWithValue ("@naziv", naziv);
            command.Parameters.AddWithValue ("@opis", opis);
            command.Parameters.AddWithValue ("@adresa", adresa);
            command.Parameters.AddWithValue ("@slika1Naziv", slika1Naziv);
            command.Parameters.AddWithValue ("@slika1Byte", (object) slika1);
            command.Parameters.AddWithValue ("@slika2Naziv", slika2Naziv);
            command.Parameters.AddWithValue ("@slika2Byte", (object) slika2);
            command.Parameters.AddWithValue ("@slika3Naziv", slika3Naziv);
            command.Parameters.AddWithValue ("@slika3Byte", (object) slika3);
            command.Parameters.AddWithValue ("@radnoVrijeme", radnoVrijeme);
            command.Parameters.AddWithValue ("@tipmuzeja", tipMuzeja);
            ExecuteCommand ();
        }
        public static void MuzejEdit (int sifra, string naziv, string opis, string radnoVrijeme, string adresa, string tipMuzeja,
            object slika1, string slika1Naziv, object slika2, string slika2Naziv, object slika3, string slika3Naziv) {

            string sqlString = "UPDATE muzej SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, adresa = @adresa, " +
                    "tipmuzeja = @tipmuzeja, slika[1]=(@slika1Naziv, @slika1Byte), slika[2]=(@slika2Naziv, @slika2Byte), slika[3]=(@slika3Naziv, @slika3Byte) WHERE sifra = @sifra";

            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.AddWithValue ("@naziv", naziv);
            command.Parameters.AddWithValue ("@opis", opis);
            command.Parameters.AddWithValue ("@adresa", adresa);
            command.Parameters.AddWithValue ("@slika1Naziv", slika1Naziv);
            command.Parameters.AddWithValue ("@slika1Byte", (object) slika1);
            command.Parameters.AddWithValue ("@slika2Naziv", slika2Naziv);
            command.Parameters.AddWithValue ("@slika2Byte", (object) slika2);
            command.Parameters.AddWithValue ("@slika3Naziv", slika3Naziv);
            command.Parameters.AddWithValue ("@slika3Byte", (object) slika3);
            command.Parameters.AddWithValue ("@radnoVrijeme", radnoVrijeme);
            command.Parameters.AddWithValue ("@tipmuzeja", tipMuzeja);
            command.Parameters.AddWithValue ("@sifra", sifra); 
            ExecuteCommand ();
        }

        #endregion

        #region Park

        public static void ParkInsert (string naziv, string opis, string radnoVrijeme, string adresa, bool otvoren, object slika1, string slika1Naziv, object slika2, string slika2Naziv, object slika3, string slika3Naziv) {
            string sqlString = "INSERT INTO park (naziv, opis, radnoVrijeme, otvoren, adresa, slika[1], slika[2], slika[3]) VALUES " +
                    "(@naziv, @opis, @radnoVrijeme, @otvoren, @adresa, (@slika1Naziv, @slika1Byte), (@slika2Naziv, @slika2Byte), (@slika3Naziv, @slika3Byte))";

            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.AddWithValue ("@naziv", naziv);
            command.Parameters.AddWithValue ("@opis", opis);
            command.Parameters.AddWithValue ("@adresa", adresa);
            command.Parameters.AddWithValue ("@slika1Naziv", slika1Naziv);
            command.Parameters.AddWithValue ("@slika1Byte", slika1);
            command.Parameters.AddWithValue ("@slika2Naziv", slika2Naziv);
            command.Parameters.AddWithValue ("@slika2Byte", slika2);
            command.Parameters.AddWithValue ("@slika3Naziv", slika3Naziv);
            command.Parameters.AddWithValue ("@slika3Byte", slika3);
            command.Parameters.AddWithValue ("@radnoVrijeme", radnoVrijeme);
            command.Parameters.AddWithValue ("@otvoren", otvoren);
            ExecuteCommand ();
        }
        public static void ParkEdit (int sifra, string naziv, string opis, string radnoVrijeme, string adresa, bool otvoren, object slika1, string slika1Naziv, object slika2, string slika2Naziv, object slika3, string slika3Naziv) {
            string sqlString = "UPDATE park SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, otvoren = @otvoren, adresa = @adresa, " +
                    "slika[1]=(@slika1Naziv, @slika1Byte), slika[2]=(@slika2Naziv, @slika2Byte), slika[3]=(@slika3Naziv, @slika3Byte) " +
                    "WHERE sifra = @sifra";

            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.AddWithValue ("@naziv", naziv);
            command.Parameters.AddWithValue ("@opis", opis);
            command.Parameters.AddWithValue ("@adresa", adresa);
            command.Parameters.AddWithValue ("@slika1Naziv", slika1Naziv);
            command.Parameters.AddWithValue ("@slika1Byte", slika1);
            command.Parameters.AddWithValue ("@slika2Naziv", slika2Naziv);
            command.Parameters.AddWithValue ("@slika2Byte", slika2);
            command.Parameters.AddWithValue ("@slika3Naziv", slika3Naziv);
            command.Parameters.AddWithValue ("@slika3Byte", slika3);
            command.Parameters.AddWithValue ("@radnoVrijeme", radnoVrijeme);
            command.Parameters.AddWithValue ("@otvoren", otvoren);
            command.Parameters.AddWithValue ("@sifra", sifra);
            ExecuteCommand ();
        }

        #endregion

        #region Znamenitost

        public static void ZnamenitostInsert (string naziv, string opis, string radnoVrijeme, string adresa, DateTime datumIzgradnje, string tipZnamenitosti, 
            object slika1, string slika1Naziv, object slika2, string slika2Naziv, object slika3, string slika3Naziv) {
            string sqlString = "INSERT INTO znamenitost (naziv, opis, radnoVrijeme, adresa, datumizgradnje, tipznamenitosti, slika[1], slika[2], slika[3]) VALUES " +
                    "(@naziv, @opis, @radnoVrijeme, @adresa, @datumizgradnje, @tipznamenitosti, (@slika1Naziv, @slika1Byte), (@slika2Naziv, @slika2Byte), (@slika3Naziv, @slika3Byte))";

            
            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.AddWithValue ("@naziv", naziv);
            command.Parameters.AddWithValue ("@opis", opis);
            command.Parameters.AddWithValue ("@adresa", adresa);
            command.Parameters.AddWithValue ("@slika1Naziv", slika1Naziv);
            command.Parameters.AddWithValue ("@slika1Byte", slika1);
            command.Parameters.AddWithValue ("@slika2Naziv", slika2Naziv);
            command.Parameters.AddWithValue ("@slika2Byte", slika2);
            command.Parameters.AddWithValue ("@slika3Naziv", slika3Naziv);
            command.Parameters.AddWithValue ("@slika3Byte", slika3);
            command.Parameters.AddWithValue ("@radnoVrijeme", radnoVrijeme);
            command.Parameters.AddWithValue ("@datumizgradnje", datumIzgradnje.Date);
            command.Parameters.AddWithValue ("@tipznamenitosti", tipZnamenitosti);
            ExecuteCommand ();
        }
        public static void ZnamenitostEdit (int sifra, string naziv, string opis, string radnoVrijeme, string adresa, DateTime datumIzgradnje, string tipZnamenitosti,
            object slika1, string slika1Naziv, object slika2, string slika2Naziv, object slika3, string slika3Naziv) {
                string sqlString = "UPDATE znamenitost SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, adresa = @adresa, " +
                        "datumizgradnje = @datumizgradnje, tipznamenitosti = @tipznamenitosti, slika[1]=(@slika1Naziv, @slika1Byte), slika[2]=(@slika2Naziv, @slika2Byte), slika[3]=(@slika3Naziv, @slika3Byte) WHERE sifra = @sifra";

            
            command = new NpgsqlCommand (sqlString, connection);
            command.Parameters.AddWithValue ("@naziv", naziv);
            command.Parameters.AddWithValue ("@opis", opis);
            command.Parameters.AddWithValue ("@adresa", adresa);
            command.Parameters.AddWithValue ("@slika1Naziv", slika1Naziv);
            command.Parameters.AddWithValue ("@slika1Byte", slika1);
            command.Parameters.AddWithValue ("@slika2Naziv", slika2Naziv);
            command.Parameters.AddWithValue ("@slika2Byte", slika2);
            command.Parameters.AddWithValue ("@slika3Naziv", slika3Naziv);
            command.Parameters.AddWithValue ("@slika3Byte", slika3);
            command.Parameters.AddWithValue ("@radnoVrijeme", radnoVrijeme);
            command.Parameters.AddWithValue ("@datumizgradnje", datumIzgradnje.Date);
            command.Parameters.AddWithValue ("@tipznamenitosti", tipZnamenitosti);
            command.Parameters.AddWithValue ("@sifra", sifra);
            ExecuteCommand ();
        }

        #endregion
    }
}
