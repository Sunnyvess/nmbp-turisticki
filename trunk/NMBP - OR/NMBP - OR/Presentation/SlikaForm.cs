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


namespace NMBP___OR.Presentation {
    public partial class SlikaForm : Form {
        static string connString = DatabaseManager.connString;
        NpgsqlConnection conn = new NpgsqlConnection (connString);

        private int sifra;
        private string type;
        private int indeksSlike = 1;
        private int BrojSlika;
        List<byte[]> slike;
        int zastavica = 0;
        Slika slika = new Slika ();

        public SlikaForm (string type, int sifra, int brojSlika) {
            zastavica = 0;
            this.sifra = sifra;
            this.type = type;
            this.BrojSlika = brojSlika;
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public SlikaForm (List<byte[]> slike, int brojSlika) {
            zastavica = 1;
            this.slike = slike;
            this.BrojSlika = brojSlika;
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SlikaForm_Load (object sender, EventArgs e) {
            if (zastavica == 0) {
                if (slika.getBrojSlika (type, sifra) != 0) pictureBox.Image = slika.getSlika (type, indeksSlike, sifra);
            }
            else {
                if (slike.Count != 0) pictureBox.Image = slika.pretvoriSlika (slike[0]);
            }

        }

        private void nextPictureButton_Click (object sender, EventArgs e) {
            int brojSlika = BrojSlika;
            if (brojSlika != 0) {
                if (indeksSlike == brojSlika) indeksSlike = 1;
                else indeksSlike++;
                if (zastavica == 0)
                    pictureBox.Image = slika.getSlika (type, indeksSlike, sifra);
                else
                    pictureBox.Image = slika.pretvoriSlika (slike[indeksSlike - 1]);
            }
        }
        private void previousPictureButton_Click (object sender, EventArgs e) {
            int brojSlika = BrojSlika;
            if (brojSlika != 0) {
                if (indeksSlike == 1) indeksSlike = brojSlika;
                else indeksSlike--;
                if (zastavica == 0)
                    pictureBox.Image = slika.getSlika (type, indeksSlike, sifra);
                else
                    pictureBox.Image = slika.pretvoriSlika (slike[indeksSlike - 1]);
            }
        }
    }
}
