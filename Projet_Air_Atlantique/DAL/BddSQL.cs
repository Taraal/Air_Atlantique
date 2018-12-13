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
        public static MySqlConnection connexion;

        public static void InitConnexion()
        {
            string connectionString = "SERVER=" + Env.server + "; DATABASE=" + Env.database +"; UID=" + Env.uid + "; PASSWORD=" + Env.password;
            if (connexion == null)
            {
                connexion = new MySqlConnection(connectionString);
            }
        }

        public static void Closeconnection()
        {
            connexion.Close();
        }
    }
}
