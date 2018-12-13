using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace Projet_Air_Atlantique.DAL
{
    class Aeroport_Model
    {

        public static List<Aeroport> ExistingAeroports = new List<Aeroport>()
        {

        };

        public static List<Aeroport> GetExistingAeroports()
        {

            return ExistingAeroports;
        }

        public static Aeroport CheckExistsThenAdd(string IdAeroport)
        {
            if (ExistingAeroports != null)
            {
                bool exists = ExistingAeroports.Any(a => a.Id == IdAeroport);
                if (exists)
                {
                    return ExistingAeroports.Find(a => a.Id == IdAeroport);
                }
                else
                {
                    Aeroport aero = new Aeroport(IdAeroport);
                    ExistingAeroports.Add(aero);

                    return aero;
                }
            }
            else
            {
                Aeroport aero = new Aeroport(IdAeroport);
                ExistingAeroports.Add(aero);

                return aero;
            }
        }
        

        static public MySqlDataReader GetInfos(string Id)
        {
            MySqlCommand cmd = BddSQL.connexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM aeroports WHERE idaeroport = @idaeroport";
            cmd.Parameters.Add("@idaeroport", MySqlDbType.String).Value = Id;
            BddSQL.connexion.Open();

            return cmd.ExecuteReader();
            
        }



        public Aeroport_Model()
        {

        }
    }
}
