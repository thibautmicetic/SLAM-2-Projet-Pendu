using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Pendu_TP1.Controllers
{
    internal class Mots
    {
        private DataTable dtListeMots;
        private connexion conn;

        public DataTable GetListeMots()
        {
            //Instencier l’objet dtListeMots de type DataTable
            dtListeMots = new DataTable();

            //Instencier l’objet conn de type Connection
            conn = new connexion();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT IDMOTS, m.LABELMOTS as Mots,m.IDDIFFICULTE, d.LABELDIFFICULTE as Difficulté" +
                    " FROM mots m" +
                    " INNER JOIN difficulte d ON m.IDDIFFICULTE = d.IDDIFFICULTE;", conn.connection))
                {
                    conn.connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtListeMots.Load(reader);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Erreur 3", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true);
            }
            return dtListeMots;
        }

        public void GetListMotsDifficult(DataView List, int param2)
        {

        }

    }
}
