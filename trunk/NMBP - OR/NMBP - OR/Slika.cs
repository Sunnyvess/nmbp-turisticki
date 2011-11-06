using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Npgsql;
using System.Windows.Forms;

namespace NMBP___OR
{
    public class Slika
    {

        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);

        public int brojSlika { get; set; }

        public Image image {get; set; }

        public byte[] slika {get;set; }

        public Image pravaslika { get; set; }

        public int getBrojSlika(string type, int sifra)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT array_length(slika, 1) AS brojSlika FROM " + type + " where sifra = " + sifra, conn);
            object brojSlika = command.ExecuteScalar();
            conn.Close();
            
            return (brojSlika is int) ? (Int32)brojSlika-1 : 0;
        }

        public Image getSlika(string type, int indeks, int sifra)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT slika[" + indeks + "].slika FROM " + type + " WHERE sifra = " + sifra, conn);
            object result = command.ExecuteScalar();
            conn.Close();

            Image image;
            if (result is byte[])
            {
                byte[] slika = (byte[])result;
                using (MemoryStream ms = new MemoryStream(slika, 0, slika.Length))
                {
                    ms.Write(slika, 0, slika.Length);
                    image = Image.FromStream(ms, true);
                }

                return image;
            }
            else return null;
        }
        public byte[] getSlikaBytes(string type, int indeks, int sifra)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT slika[" + indeks + "].slika FROM " + type + " WHERE sifra = " + sifra, conn);
            object result = command.ExecuteScalar();
            conn.Close();

            if (result is byte[])
            {
                byte[] slika = (byte[])result;
                return slika;
            }
            else return null;
        }
       
        public Image pretvoriSlika(byte[] slika)
        {
           
            Image pravaslika = null;

            if (slika is byte[])
            {
                using (MemoryStream ms = new MemoryStream(slika, 0, slika.Length))
                {
                    ms.Write(slika, 0, slika.Length);
                    pravaslika = Image.FromStream(ms, true);
                }
            }
            return pravaslika;
            
        }
    }
}
