using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projet_Air_Atlantique.DAL
{
    class Vol_Model
    {
        static public string GetHeader(Vol vol)
        {
            string header = vol.ADepart.Nom + " - " + vol.AArrivee.Id + "  " + vol.Date;

            return header;
        }

        static public MySqlDataReader GetInfos(int Id)
        {
            BddSQL db = new BddSQL();

            MySqlCommand cmd = db.connexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM vols WHERE idvol = @idvol";
            cmd.Parameters.Add("@idvol", MySqlDbType.Int32).Value = Id;
            db.connexion.Open();
            return cmd.ExecuteReader();
            

        }

    }
}
