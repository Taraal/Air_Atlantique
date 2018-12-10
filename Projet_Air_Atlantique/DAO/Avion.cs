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
            MySqlDataReader dr = DAL.Avion_Model.GetInfos(Id);

            while (dr.Read())
            {
                this.Id = dr.GetInt32("idavion");
                this.Modele = new Modele(dr.GetInt32("modele"));
            }
        }
    }
}
