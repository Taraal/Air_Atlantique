using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projet_Air_Atlantique
{
    class BddSQL
    {
        public MySqlConnection connexion;

        public BddSQL()
        {
            this.InitConnexion();
        }

        public void InitConnexion()
        {
            string connectionString = "SERVER=" + Env.server + "; DATABASE=" + Env.database +"; UID=" + Env.uid + "; PASSWORD=" + Env.password;
            this.connexion = new MySqlConnection(connectionString);
        }

        public void Closeconnection()
        {
            this.connexion.Close();
        }
    }
}
