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

        public static void GetExistingAvions()
        {

            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "SELECT * FROM avions";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (!ExistingAvions.Any(avion => avion.IdProperty == dr.GetInt32("idavion")))
                        {
                            ExistingAvions.Add(new Avion_Controller(dr.GetInt32("idavion"), Modele_Model.CheckExistsThenAdd(dr.GetInt32("modele")), dr.GetBoolean("maintenance"), dr.GetBoolean("envol")));
                        }
                    }
                    dr.Close();
                }
            }
            
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
            Dictionary<string, int> dict = new Dictionary<string, int>();
            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "SELECT * FROM avions WHERE idavion = @idavion";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dict["idavion"] = Id;
                        dict["idmodele"] = dr.GetInt32("modele");
                    }
                }
            }
            
            return dict;
        }
    }
}
