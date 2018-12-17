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
        //public MySqlConnection connexion;

        public static MySqlConnection InitConnexion()
        {
            MySqlConnection connexion = null;
            MySqlConnectionStringBuilder cstring = new MySqlConnectionStringBuilder
            {
                Server = Env.server,
                Database = Env.database,
                UserID = Env.uid,
                Password = Env.password,
                Pooling = true
            };
            string connectionString = "SERVER=" + Env.server + "; DATABASE=" + Env.database +"; UID=" + Env.uid + "; PASSWORD=" + Env.password + "; MultipleActiveResultSets=true";
            if (connexion == null)
            {
                connexion = new MySqlConnection(cstring.ToString());
            }
            connexion.Open();
            return connexion;
        }
    }
}
