using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using turistickiXML.DAL;
using turistickiXML.Bussines;
using System.Xml;

namespace turistickiXML
{
    public partial class Form1 : Form
    {
        Grad grad = new Grad();
       
        public Form1()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            string filePath = Application.StartupPath + "\\XML\\proba.xml";
            ds.ReadXml(filePath);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Grad";
            //dataGridView1.CaptionText = dataGridView1.DataMember;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void loadData(int PostanskiBr)
        {
            grad = GradList.GetGrad(PostanskiBr);
            if (grad != null)
            {
                this.textBox1.Text = grad.PostanskiBr.ToString();
                this.textBox2.Text = grad.Ime;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadData(Convert.ToInt32(dataGridView1[this.dataGridView1.CurrentRow.Index,0]));
        }


    }
}
