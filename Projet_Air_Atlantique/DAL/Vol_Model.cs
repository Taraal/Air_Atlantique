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
        static public string GetHeader(Vol_Controller vol)
        {
            string header = vol.ADepartProperty.Id + " - " + vol.AArriveeProperty.Id + "  " + vol.DateProperty;

            return header;
        }

        public static void GetVols(List<Vol_Controller> list)
        {
            BddSQL.InitConnexion();
            MySqlCommand cmd = BddSQL.connexion.CreateCommand();
            cmd.CommandText = "SELECT * from vols";
            BddSQL.connexion.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(dr);
            dr.Close();
            foreach(DataRow row in table.Rows)
            {
                Vol_Controller v = new Vol_Controller(Convert.ToInt32(row["idvol"]), Avion_Model.CheckExistsThenAdd(Convert.ToInt32(row["avion"])), Aeroport_Model.CheckExistsThenAdd(row["adepart"].ToString()), Aeroport_Model.CheckExistsThenAdd(row["aarrivee"].ToString()), row["date"].ToString(), row["heuredepart"].ToString(), row["heurearrivee"].ToString());
                v.HeaderProperty = GetHeader(v);
                list.Add(v);
            }

            dr.Close();
            BddSQL.Closeconnection();

        }

        static public Dictionary<string, int> GetInfosInt(int Id)
        {
            BddSQL.connexion.Close();
            MySqlCommand cmd = BddSQL.connexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM vols WHERE idvol = @idvol";
            cmd.Parameters.Add("@idvol", MySqlDbType.Int32).Value = Id;
            BddSQL.connexion.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            Dictionary<string, int> dict = new Dictionary<string, int>();
            while (dr.Read())
            {
                dict["idvol"] = Id;
                dict["idavion"] = dr.GetInt32("avion");
            }

            return dict;

        }

        static public Dictionary<string, string> GetInfosString(int Id)
        {
            BddSQL.connexion.Close();
            MySqlCommand cmd = BddSQL.connexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM vols WHERE idvol = @idvol";
            cmd.Parameters.Add("@idvol", MySqlDbType.Int32).Value = Id;
            BddSQL.connexion.Open();

            MySqlDataReader dr = cmd.ExecuteReader();

            Dictionary<string, string> dict = new Dictionary<string, string>();
            while (dr.Read())
            {
                dict["adepart"] = dr.GetString("adepart");
                dict["aarrivee"] = dr.GetString("aarrivee");
                dict["date"] = dr.GetString("date");
                dict["heurearrivee"] = dr.GetString("heurearrivee");
                dict["heuredepart"] = dr.GetString("heuredepart");
            }

            return dict;

        }

    }
}
