using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Npgsql;


namespace NMBP___OR.Presentation
{
    public partial class SlikaForm : Form
    {
        private int sifra;
        private string type;
        private int indeksSlike = 1;
        private int BrojSlika;
        
        Slika slika = new Slika();
        
        public SlikaForm(string type, int sifra, int brojSlika)
        {
            this.sifra = sifra;
            this.type = type;
            this.BrojSlika = brojSlika;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
       
        
        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);
        private void SlikaForm_Load(object sender, EventArgs e)
        {
            if (slika.getBrojSlika(type , sifra) != 0) pictureBox.Image = slika.getSlika(type, indeksSlike, sifra);
        }
        
        /*
        private int getBrojSlika()
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT array_length(slika, 1) AS brojSlika FROM " +type + " where sifra = " + sifra, conn);
            object brojSlika1 = command.ExecuteScalar();
            conn.Close();

            return (brojSlika1 is int) ? (Int32)brojSlika1 : 0;
        }
        
        private Image getSlika(int indeks)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT slika[" + indeks + "].slika FROM bolnica where sifra = " + sifra, conn);
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
        */
        private void nextPictureButton_Click(object sender, EventArgs e)
        {
            int brojSlika = BrojSlika;
            if (brojSlika != 0)
            {
                if (indeksSlike == brojSlika) indeksSlike = 1;
                else indeksSlike++;
                pictureBox.Image = slika.getSlika(type, indeksSlike, sifra);
            }
        }

        private void previousPictureButton_Click(object sender, EventArgs e)
        {
            int brojSlika = BrojSlika;
            if (brojSlika != 0)
            {
                if (indeksSlike == 1) indeksSlike = brojSlika;
                else indeksSlike--;
                pictureBox.Image = slika.getSlika(type, indeksSlike, sifra);
            }
        }/*
        private void nextPictureButton_Click(object sender, EventArgs e)
        {
            if (getBrojSlika() != 0)
            {
                if (indeksSlike == getBrojSlika()) indeksSlike = 1;
                else indeksSlike++;
                pictureBox.Image = getSlika(indeksSlike);
            }
        }

        private void previousPictureButton_Click(object sender, EventArgs e)
        {
            if (getBrojSlika() != 0)
            {
                if (indeksSlike == 1) indeksSlike = getBrojSlika();
                else indeksSlike--;
                pictureBox.Image = getSlika(indeksSlike);
            }
        }
        */
        
    }
}
