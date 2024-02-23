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
    public partial class Form1 : Form
    {

        Jeu J;
        private string nomPrenom;
        public string NomPrenom
        {
            get { return nomPrenom; }
        }

        private string difficulte;
        public string Difficulte
        {
            get { return difficulte; }
        }

        public Form1()
        {
            InitializeComponent();
            comboBox_difficulte.Items.Add("Facile");
            comboBox_difficulte.Items.Add("Moyen");
            comboBox_difficulte.Items.Add("Difficile");
            comboBox_difficulte.Items.Add("Enfer");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_afficher_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            string error = "";

            if (txt_nom.Text == "" || txt_prenom.Text == "" || comboBox_difficulte.SelectedIndex == -1)
            {
               
                if (txt_nom.Text == "")
                {
                    error += "Aucun nom n'est rentré. ";
                }

                if (txt_prenom.Text == "")
                {
                    error += "Aucun prenom n'est rentré. ";
                }

                if (comboBox_difficulte.SelectedIndex == -1)
                {
                    error += "Aucune difficulté n'a été saisie.";
                }

            
                    MessageBox.Show(error, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    string nomComplet = txt_prenom.Text + " " + txt_nom.Text;
                    nomPrenom = nomComplet;
                    difficulte = comboBox_difficulte.Text;
                    (System.Windows.Forms.Application.OpenForms["Menu"] as menu).demarrerJeu(nomComplet, comboBox_difficulte.Text);
                }
        }

        private void txt_afficher_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Convert.ToString(comboBox_difficulte.SelectedItem) == "Enfer")
            {
                this.BackColor = Color.Red;
                lbl_difficulte.Font = new Font(lbl_difficulte.Font, FontStyle.Bold);
                lbl_prenom.Font = new Font(lbl_prenom.Font, FontStyle.Bold);
                lbl_nom.Font = new Font(lbl_nom.Font, FontStyle.Bold);
            }

            if (Convert.ToString(comboBox_difficulte.SelectedItem) != "Enfer")
            {
                this.BackColor = Color.FromArgb(153, 180, 209);
                lbl_difficulte.Font = new Font(lbl_difficulte.Font, FontStyle.Regular);
                lbl_prenom.Font = new Font(lbl_prenom.Font, FontStyle.Regular);
                lbl_nom.Font = new Font(lbl_nom.Font, FontStyle.Regular);
            }

        }

        private void txt_nom_TextChanged(object sender, EventArgs e)
        {

        }

        public void fermerForm()
        {
            this.Hide();
            J.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
