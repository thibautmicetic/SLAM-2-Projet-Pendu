using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendu_TP1.Controllers
{
    internal class Difficulte
    {
        private DataTable dtListeDifficultes;
        private connexion conn;

        public DataTable GetListeDifficulte()
        {
            //Instencier l’objet dtListeMots de type DataTable
            dtListeDifficultes = new DataTable();

            //Instencier l’objet conn de type Connection
            conn = new connexion();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT IDDIFFICULTE AS ID, LABELDIFFICULTE AS LABEL FROM difficulte;", conn.connection))
                {
                    conn.connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dtListeDifficultes.Load(reader);

                    DataRow workRow = dtListeDifficultes.NewRow();
                    workRow[0] = -1;
                    workRow[1] = "";
                    dtListeDifficultes.Rows.InsertAt(workRow, 0);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Erreur 3", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, true);
            }
            return dtListeDifficultes;
        }

    }
}
