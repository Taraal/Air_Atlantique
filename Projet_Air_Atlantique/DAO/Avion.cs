using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projet_Air_Atlantique
{
    class Avion
    {
        public int Id { get; set; }
        private Modele Modele { get; set; }

        public Avion(int Id)
        {
            Dictionary<string, int> dr = DAL.Avion_Model.GetInfos(Id);

            this.Id = dr["idavion"];
            this.Modele = new Modele(dr["idmodele"]);
            
            BddSQL.connexion.Close();
        }
    }
}
