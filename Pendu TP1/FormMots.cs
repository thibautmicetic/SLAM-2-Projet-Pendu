using Pendu_TP1.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendu_TP1
{
    public partial class FormMots : Form
    {
        private Mots dt_mot;
        private Difficulte dt_difficulte;
        private DataView dv;
        
        public FormMots()
        {
            InitializeComponent();
            initDifficulte();
        }

        private void initDifficulte()
        {
            dt_difficulte = new Difficulte();
            difficultyComboBox.DataSource = dt_difficulte.GetListeDifficulte();
            difficultyComboBox.DisplayMember = "LABEL";
            difficultyComboBox.ValueMember = "ID";
        }

        private void FormMots_Load(object sender, EventArgs e)
        {
            dt_mot = new Mots();
            dv = new DataView(dt_mot.GetListeMots());
            dgv_Mots.DataSource = dv;
            //Cacher les colonnes qui ne servent à rien pour l’utilisateur
            dgv_Mots.Columns["IDMOTS"].Visible = false;
            //Gérer la largeur des colonnes
            dgv_Mots.Columns["Mots"].Width = 190;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
