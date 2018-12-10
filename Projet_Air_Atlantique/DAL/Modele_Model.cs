using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projet_Air_Atlantique.DAL
{
    class Modele_Model
    {
        public static List<Modele> ExistingModeles = new List<Modele>()
        {

        };

        public static List<Modele> GetExistingModeles()
        {

            return ExistingModeles;
        }

        public static Modele CheckExistsThenAdd(int IdModele)
        {
            if (ExistingModeles != null)
            {
                bool exists = ExistingModeles.Any(a => a.Id == IdModele);
                if (exists)
                {
                    return ExistingModeles.Find(a => a.Id == IdModele);
                }
                else
                {
                    Modele model = new Modele(IdModele);
                    ExistingModeles.Add(model);

                    return model;
                }
            }
            else
            {
                Modele model = new Modele(IdModele);
                ExistingModeles.Add(model);

                return model;
            }
        }


        static public MySqlDataReader GetInfos(int Id)
        {
            BddSQL db = new BddSQL();

            MySqlCommand cmd = db.connexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM modeles WHERE idmodele = @idmodele";
            cmd.Parameters.Add("@idmodele", MySqlDbType.Int32).Value = Id;
            db.connexion.Open();

            return cmd.ExecuteReader();


        }

    }
}
