using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projet_Air_Atlantique.Controllers;

namespace Projet_Air_Atlantique.DAL
{
    class Avion_Model
    {
        public static List<Avion_Controller> ExistingAvions = new List<Avion_Controller>()
        {

        };

        public static List<Avion_Controller> GetExistingAvions()
        {

            return ExistingAvions;
        }

        public static Avion_Controller CheckExistsThenAdd(int IdAvion)
        {
            if (ExistingAvions != null)
            {
                bool exists = ExistingAvions.Any(a => a.IdProperty == IdAvion);
                if (exists)
                {
                    return ExistingAvions.Find(a => a.IdProperty == IdAvion);
                }
                else
                {
                    Avion_Controller avion = new Avion_Controller(IdAvion);
                    ExistingAvions.Add(avion);

                    return avion;
                }
            }
            else
            {
                Avion_Controller avion = new Avion_Controller(IdAvion);
                ExistingAvions.Add(avion);

                return avion;
            }
        }


        static public Dictionary<string, int> GetInfos(int Id)
        {
            MySqlCommand cmd = BddSQL.connexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM avions WHERE idavion = @idavion";
            cmd.Parameters.Add("@idavion", MySqlDbType.Int32).Value = Id;
            if(BddSQL.connexion.State == System.Data.ConnectionState.Closed)
            {
                BddSQL.connexion.Open();
            }
            

            MySqlDataReader dr = cmd.ExecuteReader();

            Dictionary<string, int> dict = new Dictionary<string, int>();
            while (dr.Read())
            {
                dict["idavion"] = Id;
                dict["idmodele"] = dr.GetInt32("modele");
            }
            return dict;
        }
    }
}
