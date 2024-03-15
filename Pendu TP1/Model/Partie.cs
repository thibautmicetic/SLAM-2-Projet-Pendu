using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendu_TP1.Model
{
    public class Partie
    {
        public Int32 nbEssais;
        public String motaafficher;
        public String motatrouver;
        private bool partieEnCours = true;
        public bool PartieEnCours
        {
            get { return partieEnCours; }
        }

        public void changerIMG(PictureBox pb_pendu)
        {
            switch(nbEssais)
            {
                case 0:
                    pb_pendu.Image = Properties.Resources.C1;
                    break;

                case 1:
                    pb_pendu.Image = Properties.Resources.C2;
                    break;

                case 2:
                    pb_pendu.Image = Properties.Resources.C3;
                    break;

                case 3:
                    pb_pendu.Image = Properties.Resources.C4;
                    break;

                case 4:
                    pb_pendu.Image = Properties.Resources.C5;
                    break;

                case 5:
                    pb_pendu.Image = Properties.Resources.C6;
                    break;

                case 6:
                    pb_pendu.Image = Properties.Resources.C7;
                    break;

                case 7:
                    pb_pendu.Image = Properties.Resources.C8;
                    break;

                case 8:
                    pb_pendu.Image = Properties.Resources.C9;
                    break;

                default:
                    pb_pendu.Image = Properties.Resources.C1;
                    break;
            }
        }

        public void verifier(string lettretape, TextBox txt_afficher)
        {
            char[] cArray = motatrouver.ToCharArray();
            char[] motaff = motaafficher.ToCharArray();

            motaafficher = "";
            bool goodCaracter = false;

            for (int i = 0; i < cArray.Length; i++)
            {
                if (cArray[i] == Convert.ToChar(lettretape))
                {
                    motaafficher += lettretape;
                    goodCaracter = true;
                }
                else 
                {
                    motaafficher += motaff[i];
                }
            }

            if (!goodCaracter)
            {
                nbEssaisChanger();
            }

            txt_afficher.Text = motaafficher;
        }

        public void genererMotAfficher()
        {
            string motaff = "";

            for(int i = 0; i < motatrouver.Length; i++)
            {
                motaff += '_';
            }            

            motaafficher = motaff;
        }

        public void choisirMotATrouver(List<String> listeATrouver)
        {
            Random aleatoire = new Random();
            int nbAleatoire = aleatoire.Next(listeATrouver.Count);
            motatrouver = listeATrouver[nbAleatoire].ToUpper();
        }

        public void verifierVictoire(Form formulaireJeuActif, TextBox txt_motAafficher, TextBox txt_timer, List<string> listeMotaTrouver, PictureBox pbpendu)
        {
            DialogResult msg = new DialogResult();
            if(nbEssais > 7)
            {
                partieEnCours = false;
                msg = MessageBox.Show("Vous avez perdu !! \r\nTemps écoulé :" + txt_timer.Text + "\r\nVous deviez trouver le mot: " + motatrouver + "\r\nVoulez vous faire une autre partie ??", "You loose", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            if (txt_motAafficher.Text == motatrouver && nbEssais < 9)
            {
                partieEnCours = false;
                msg = MessageBox.Show("Vous avez gagné !! \r\nTemps écoulé : " + txt_timer.Text + "\r\nVoulez vous faire une autre partie ??", "You loose", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            if (msg == DialogResult.Yes)
            {
                remiseAZero(formulaireJeuActif, txt_motAafficher, listeMotaTrouver, pbpendu);
                string nomPrenom = (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).NomPrenom;
                string difficulte = (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).Difficulte;
                (System.Windows.Forms.Application.OpenForms["menu"] as menu).demarrerJeu(nomPrenom, difficulte);
                formulaireJeuActif.Hide();
            }

            if(msg == DialogResult.No)
            {
                (System.Windows.Forms.Application.OpenForms["menu"] as menu).closeChildForm();
                formulaireJeuActif.Hide();
            }
        }

        public void remiseAZero(Form formulaireJeuActif, TextBox txt_motAafficher, List<String> listeMotaTrouver, PictureBox pb_pendu)
        {
            //Mettre à vide les attribut motaafficher et motatrouver
            motaafficher = "";
            motatrouver = "";

            //Mettre le nombre d’essais à 1
            nbEssais = 1;

            //Choisir un nouveau mot à trouver
            choisirMotATrouver(listeMotaTrouver);

            //Générer un nouveau mot à afficher
            txt_motAafficher.Text = motaafficher;

            foreach (Control c in formulaireJeuActif.Controls)
            {
                if (c.GetType() == typeof(Button))
                    c.Enabled = true;
            }

            nbEssais = 0;

        }
        private void nbEssaisChanger()
        {
            nbEssais++;
        }

    }
}
