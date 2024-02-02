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
        public Jeu()
        {
            InitializeComponent();
            P = new Partie();
            init();
        }

        private void init()
        {
            listeMotaTrouver = new List<string> { "Francophile", "Chlorophylle", "Conspirateur", "Qualification", "Attraction", "Cornemuse", "Tourisme", "Diapason", "Brouhaha" };
            P.choisirMotATrouver(listeMotaTrouver);
            P.genererMotAfficher();
            nom_pendu.Text = P.motaafficher;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            P.verifier(((Button)sender).Text.ToString(), nom_pendu);
            P.changerIMG(pb_pendu);
            ((Button)sender).Enabled = false;
            P.victoire(this, nom_pendu, listeMotaTrouver, pb_pendu);
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
    }
}
