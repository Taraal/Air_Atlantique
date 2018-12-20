using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projet_Air_Atlantique.Controllers;

namespace Projet_Air_Atlantique.DAL
{
    class Vol_Model
    {
        public static List<Vol_Controller> ExistingVols = new List<Vol_Controller>() { };

        static public string GetHeader(Vol_Controller vol)
        {
            string header = vol.ADepartProperty.IdProperty + " - " + vol.AArriveeProperty.IdProperty + "  " + vol.DateProperty;

            return header;
        }

        public static void AddNewVol(Avion_Controller Avion, Aeroport_Controller AD, Aeroport_Controller AA, string Date, string HD, string HA)
        {
            int IdAvion = Avion.IdProperty;
            string IdAD = AD.IdProperty;
            string IdAA = AA.IdProperty;
            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "INSERT INTO vols (idvol, avion, adepart, aarrivee, heuredepart, heurearrivee, date) " +
                    "VALUES (NULL, @idAvion, @IdAD, @IdAA, @HD, @HA, @Date)";
                command.Parameters.AddWithValue("@idAvion", IdAvion);
                command.Parameters.AddWithValue("@IdAD", IdAD);
                command.Parameters.AddWithValue("@IdAA", IdAA);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@HD", HD);
                command.Parameters.AddWithValue("@HA", HA);

                command.ExecuteNonQuery();
            }
        }

        public static void UpdateVol(int IdVol, Avion_Controller Avion, Aeroport_Controller AD, Aeroport_Controller AA, string Date, string HD, string HA)
        {
            IdVol = 1;
            int IdAvion = Avion.IdProperty;
            string IdAD = AD.IdProperty;
            string IdAA = AA.IdProperty;
            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "UPDATE vols SET avion=@idavion, adepart=@IdAD, aarrivee=@IdAA, heuredepart=@HD, heurearrivee=@HA, date=@Date WHERE idvol=@idvol";
                command.Parameters.AddWithValue("@idAvion", IdAvion);
                command.Parameters.AddWithValue("@IdAD", IdAD);
                command.Parameters.AddWithValue("@IdAA", IdAA);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@HD", HD);
                command.Parameters.AddWithValue("@HA", HA);
                command.Parameters.AddWithValue("@idvol", IdVol);

                command.ExecuteNonQuery();
            }

        }

        public static void DeleteVol(int IdVol)
        {
            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "DELETE FROM vols WHERE idvol = @idvol";
                command.Parameters.AddWithValue("@idvol", IdVol);

                command.ExecuteNonQuery();
            }
        }


        public static void GetExistingVols()
        {

            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "SELECT * FROM vols";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(dr);
                    foreach (DataRow row in table.Rows)
                    {
                        Vol_Controller v = new Vol_Controller(Convert.ToInt32(row["idvol"]), Avion_Model.CheckExistsThenAdd(Convert.ToInt32(row["avion"])), Aeroport_Model.CheckExistsThenAdd(row["adepart"].ToString()), Aeroport_Model.CheckExistsThenAdd(row["aarrivee"].ToString()), row["date"].ToString(), row["heuredepart"].ToString(), row["heurearrivee"].ToString());
                        v.HeaderProperty = GetHeader(v);
                        ExistingVols.Add(v);
                    }
                }
            }


        }

        static public Dictionary<string, int> GetInfosInt(int Id)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "SELECT * FROM vols WHERE idvol = @idvol";
                command.Parameters.Add("@idvol", MySqlDbType.Int32).Value = Id;
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dict["idvol"] = Id;
                        dict["idavion"] = dr.GetInt32("avion");
                    }
                }
            }

            return dict;

        }

        static public Dictionary<string, string> GetInfosString(int Id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "SELECT * FROM vols";
                using (MySqlDataReader dr = command.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        dict["adepart"] = dr.GetString("adepart");
                        dict["aarrivee"] = dr.GetString("aarrivee");
                        dict["date"] = dr.GetString("date");
                        dict["heurearrivee"] = dr.GetString("heurearrivee");
                        dict["heuredepart"] = dr.GetString("heuredepart");
                    }
                }
            }


            return dict;

        }

    }
}
