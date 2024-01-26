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

            for (int i = 0; i < cArray.Length; i++)
            {
                if (cArray[i] == Convert.ToChar(lettretape))
                {
                    motaafficher += lettretape;
                }
                else
                    motaafficher += motaff[i];
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

    }
}
