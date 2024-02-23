using Pendu_TP1.Model;
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
    public partial class Jeu : Form
    {
        Partie P;
        List<string> listeMotaTrouver;
        Timer timer;
        int timerPartie;
        public Jeu(string nomPrenomJoueur, string difficultePartie)
        {
            init();
            txt_nom_prenom.Text = nomPrenomJoueur;
            txt_difficulte.Text = difficultePartie;
        }

        private void init()
        {
            InitializeComponent();
            P = new Partie();
            initParams();
            initTime();
        }

        private void initParams()
        {
            listeMotaTrouver = new List<string> { "Francophile", "Chlorophylle", "Conspirateur", "Qualification", "Attraction", "Cornemuse", "Tourisme", "Diapason", "Brouhaha" };
            P.choisirMotATrouver(listeMotaTrouver);
            P.genererMotAfficher();
            nom_pendu.Text = P.motaafficher;
        }

        private void initTime()
        {
            gestionTimer(txt_timer);
            dureeCout.Value = 10;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            P.verifier(((Button)sender).Text.ToString(), nom_pendu);
            dureeCout.Value = 10;
            P.changerIMG(pb_pendu);
            ((Button)sender).Enabled = false;
            P.verifierVictoire(this, nom_pendu, txt_timer, listeMotaTrouver, pb_pendu);
        }

        public void gestionTimer(TextBox txt_timer)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) => Timer_Tick(sender, e, txt_timer);

            timer.Start();
        }

        public void Timer_Tick(object sender, EventArgs e, TextBox txt_timer)
        {
            if (P.PartieEnCours)
            {
                timerPartie++;
                txt_timer.Text = timerPartie.ToString() + "sec";
                dureeCout.Increment(-1);
                setDureeCount(dureeCout.Value);

                if (P.nbEssais > 7)
                {
                    P.verifierVictoire(this, nom_pendu, txt_timer, listeMotaTrouver, pb_pendu);
                    timer.Stop();
                    txt_timer.Text = timerPartie.ToString() + "sec";
                }
            }

            else
            {
                timer.Stop();
                txt_timer.Text = timerPartie.ToString() + "sec";
            }
        }

        private void setDureeCount(int timer)
        {
            if(timer == 0)
            {
                P.nbEssais++;
                P.changerIMG(pb_pendu);
                dureeCout.Value = 10;
            }
        }

        public Partie newGame()
        {
            return new Partie();
        }
        private void Jeu_Load(object sender, EventArgs e)
        {
            
        }

        private void boite_img_Click(object sender, EventArgs e)
        {

        }

        private void nom_pendu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_nom_prenom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
