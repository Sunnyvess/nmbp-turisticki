using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using turistickiXML.Bussines;
using System.Xml;

namespace turistickiXML.Presentation
{
    public partial class VodicForm : Form
    {
        GradList gradlist = new GradList();
        turistickiXML.DAL.XMLData xmldata = new turistickiXML.DAL.XMLData();
        //DataTable grad = new DataTable();
        //DataTable masterList = new DataTable();
        XmlNodeList masterList2;
        string filePath = "..\\..\\XML\\turistickiVodic.xml";
        public VodicForm()
        {
            InitializeComponent();
        }

        private void gradoviComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillMasterList();
        }
        private void VodicForm_Load(object sender, EventArgs e)
        {
            FillGradCB();
            FillMasterList();
        }
        private void FillGradCB()
        {
            DataTable grad = gradlist.GetGradList();
            gradoviComboBox.DataSource = grad;
            gradoviComboBox.DisplayMember = "nazivGrad";
            gradoviComboBox.ValueMember = "pbr";
            gradoviComboBox.SelectedIndex = 0;
            lokacijaComboBox.SelectedIndex = 0;    
        }
        public void FillMasterList()
        {
            masterLista.Items.Clear();
            if (lokacijaComboBox.SelectedItem == null || gradoviComboBox.SelectedItem == null)
                return;
            masterList2 = xmldata.Select(Convert.ToInt32(gradoviComboBox.SelectedValue));

            foreach (XmlNode node in masterList2)
            {
                masterLista.Items.Add(node["naziv"].InnerText);
            }
        }

        private void editBTN_Click(object sender, EventArgs e)
        {

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            
        }

    }
}
