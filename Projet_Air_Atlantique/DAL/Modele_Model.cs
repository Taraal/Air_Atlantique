using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projet_Air_Atlantique.Controllers;

namespace Projet_Air_Atlantique.DAL
{
    class Modele_Model
    {
        public static List<Modele_Controller> ExistingModeles = new List<Modele_Controller>()
        {

        };

        public static List<Modele_Controller> GetExistingModeles()
        {

            return ExistingModeles;
        }

        public static Modele_Controller CheckExistsThenAdd(int IdModele)
        {
            if (ExistingModeles != null)
            {
                bool exists = ExistingModeles.Any(a => a.IdProperty == IdModele);
                if (exists)
                {
                    return ExistingModeles.Find(a => a.IdProperty == IdModele);
                }
                else
                {
                    Modele_Controller model = new Modele_Controller(IdModele);
                    ExistingModeles.Add(model);

                    return model;
                }
            }
            else
            {
                Modele_Controller model = new Modele_Controller(IdModele);
                ExistingModeles.Add(model);

                return model;
            }
        }


        static public MySqlDataReader GetInfos(int Id)
        {
            MySqlCommand cmd = BddSQL.connexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM modeles WHERE idmodele = @idmodele";
            cmd.Parameters.Add("@idmodele", MySqlDbType.Int32).Value = Id;
            if(BddSQL.connexion.State == System.Data.ConnectionState.Closed)
            {
                BddSQL.connexion.Open();
            }


            return cmd.ExecuteReader();


        }

    }
}
