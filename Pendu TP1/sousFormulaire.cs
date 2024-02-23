using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendu_TP1
{
    internal class sousFormulaire
    {
        public Panel PanelSousFormlaire;
        public Form activeForm = null;

        public sousFormulaire(Panel panelenvoit)
        {
            PanelSousFormlaire = panelenvoit;
        }

        public void openChildForm(Form formEnfant)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = formEnfant;
            formEnfant.TopLevel = false;
            formEnfant.FormBorderStyle = FormBorderStyle.None;
            formEnfant.Dock = DockStyle.Fill;
            PanelSousFormlaire.Controls.Add(formEnfant);
            PanelSousFormlaire.Tag = formEnfant;
            formEnfant.BringToFront();
            formEnfant.Show();
        }

        public void closeActiveForm()
        {
            activeForm.Close();
        }

    }
}
