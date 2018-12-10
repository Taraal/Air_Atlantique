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

        public static List<Vol> GetVols()
        {

            BddSQL db = new BddSQL();
            db.InitConnexion();
            MySqlCommand cmd = db.connexion.CreateCommand();
            cmd.CommandText = "SELECT * from vols";
            db.connexion.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            List<Vol> vols = new List<Vol>();

            while (dr.Read())
            {
                vols.Add(new Vol(dr.GetInt32("idvol")));
            }

            return vols;
        }

        static public MySqlDataReader GetInfos(string Id)
        {
            BddSQL db = new BddSQL();

            MySqlCommand cmd = db.connexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM aeroports WHERE idaeroport = @idaeroport";
            cmd.Parameters.Add("@idaeroport", MySqlDbType.String).Value = Id;
            db.connexion.Open();

            return cmd.ExecuteReader();


        }



        public Aeroport_Model()
        {

        }
    }
}
