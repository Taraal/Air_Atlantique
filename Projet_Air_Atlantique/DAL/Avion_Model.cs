using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projet_Air_Atlantique.DAL
{
    class Avion_Model
    {
        public static List<Avion> ExistingAvions = new List<Avion>()
        {

        };

        public static List<Avion> GetExistingAvions()
        {

            return ExistingAvions;
        }

        public static Avion CheckExistsThenAdd(int IdAvion)
        {
            if (ExistingAvions != null)
            {
                bool exists = ExistingAvions.Any(a => a.Id == IdAvion);
                if (exists)
                {
                    return ExistingAvions.Find(a => a.Id == IdAvion);
                }
                else
                {
                    Avion avion = new Avion(IdAvion);
                    ExistingAvions.Add(avion);

                    return avion;
                }
            }
            else
            {
                Avion avion = new Avion(IdAvion);
                ExistingAvions.Add(avion);

                return avion;
            }
        }


        static public MySqlDataReader GetInfos(int Id)
        {
            BddSQL db = new BddSQL();

            MySqlCommand cmd = db.connexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM avions WHERE idavion = @idavion";
            cmd.Parameters.Add("@idavion", MySqlDbType.Int32).Value = Id;
            db.connexion.Open();

            return cmd.ExecuteReader();


        }

    }
}
