using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Projet_Air_Atlantique.Controllers;


namespace Projet_Air_Atlantique.DAL
{
    class Aeroport_Model 
    {

        public static List<Aeroport_Controller> ExistingAeroports = new List<Aeroport_Controller>()
        {

        };

        public static List<Aeroport_Controller> GetExistingAeroports()
        {

            return ExistingAeroports;
        }

        public static Aeroport_Controller CheckExistsThenAdd(string IdAeroport)
        {
            if (ExistingAeroports != null)
            {
                bool exists = ExistingAeroports.Any(a => a.IdProperty == IdAeroport);
                if (exists)
                {
                    return ExistingAeroports.Find(a => a.IdProperty == IdAeroport);
                }
                else
                {
                    Aeroport_Controller aero = new Aeroport_Controller(IdAeroport);
                    ExistingAeroports.Add(aero);

                    return aero;
                }
            }
            else
            {
                Aeroport_Controller aero = new Aeroport_Controller(IdAeroport);
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
