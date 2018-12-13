using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Projet_Air_Atlantique
{
    class Aeroport
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Label { get; set; }
        

        public Aeroport(string Id)
        {
            MySqlDataReader dr = DAL.Aeroport_Model.GetInfos(Id);

            while (dr.Read())
            {
                this.Id = dr.GetString("idaeroport");
                this.Nom= dr.GetString("nom");
                
            }
            BddSQL.connexion.Close();
        }



    }

    

}
