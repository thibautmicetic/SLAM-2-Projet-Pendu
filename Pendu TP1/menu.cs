﻿using Pendu_TP1.Model;
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
    public partial class menu : Form
    {
        sousFormulaire SF;
        public Form activeForm = null;
        
        public menu()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            SF = new sousFormulaire(pnl_SF);
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void demarrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SF.openChildForm(newForm());
        }

        private Form1 newForm()
        {
            return new Form1();
        }

        public void redemarrerJeu()
        {
            SF.openChildForm(newForm());
        }

        private void arreterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                closeChildForm();
        }

        public void demarrerJeu(string nomPrenomJoeur, string difficultePartie)
        {
            openChildForm(new Jeu(nomPrenomJoeur, difficultePartie));
        }

        private void afficherMots()
        {
            openChildForm(new FormMots());
        }

        public void openChildForm(Form formEnfant)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = formEnfant;
            formEnfant.TopLevel = false;
            formEnfant.FormBorderStyle = FormBorderStyle.None;
            formEnfant.Dock = DockStyle.Fill;
            pnl_SF.Controls.Add(formEnfant);
            pnl_SF.Tag = formEnfant;
            formEnfant.BringToFront();
            formEnfant.Show();
        }

        public void closeChildForm()
        {
            activeForm.Close();
            SF.closeActiveForm();
            
        }

        private void afficherLesMotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afficherMots();
        }
    }
}
