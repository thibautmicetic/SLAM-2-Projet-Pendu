using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Pendu_TP1
{
    internal class connexion
    {
        public MySqlConnection Connection;
        public MySqlConnection connection
        {
            get { return Connection; }
            set { Connection = value; }
        }
        private string server;
        private string database;
        private string login;
        private string password;

        public connexion()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "192.168.10.16";
            database = "micetic_thibaut1_BDD_Pendu";
            login = "micetic_thibaut1";
            password = "P@ssw0rd";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + login + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


    }
}
