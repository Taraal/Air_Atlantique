using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Projet_Air_Atlantique
{
    class Modele
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public Modele(int Id)
        {

            MySqlDataReader dr = DAL.Modele_Model.GetInfos(Id);

            while (dr.Read())
            {
                this.Label = dr.GetString("label");
            }


        }


    }

    
}
