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
    class Client_Model
    {

        public static List<Client_Controller> ExistingClients = new List<Client_Controller>() { };

        public static void GetExistingClients()
        {
            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "SELECT * FROM clients";
                using (MySqlDataReader dr = command.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        if (!ExistingClients.Any(vol => vol.IdProperty == dr.GetInt32("idclients"))){
                            ExistingClients.Add(new Client_Controller(dr.GetInt32("idclients"), dr.GetString("nom"), dr.GetString("prenom"), dr.GetString("adresse"), dr.GetString("telephone"), dr.GetString("mail"), dr.GetInt32("points")));
                        }
                    }
                }
            }
        }


        public static void AddNewClient(Client_Controller client)
        {
            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "INSERT INTO clients (idclients, nom, prenom, adresse, telephone, mail, points) " +
                    "VALUES (NULL, @nom, @prenom, @adresse, @telephone, @mail, 0)";
                command.Parameters.AddWithValue("@nom", client.NomProperty);
                command.Parameters.AddWithValue("@prenom", client.PrenomProperty);
                command.Parameters.AddWithValue("@adresse", client.AdresseProperty);
                command.Parameters.AddWithValue("@telephone", client.TelephoneProperty);
                command.Parameters.AddWithValue("@mail", client.MailProperty);

                command.ExecuteNonQuery();
            }
        }

        public static void DeleteClient(int IdClient)
        {
            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "DELETE FROM clients WHERE idclients = @idclient";
                command.Parameters.AddWithValue("@idclient", IdClient);

                command.ExecuteNonQuery();
            }
        }

        public static void UpdateClient(int IdClient, string nom, string prenom, string adresse, string telephone, int points)
        {
            using (MySqlConnection c = BddSQL.InitConnexion())
            {
                MySqlCommand command = c.CreateCommand();
                command.CommandText = "UPDATE clients SET nom=@nom, prenom=@prenom, adresse=@adresse, telephone=@telephone, points=@points WHERE idclients=@idclient";
                command.Parameters.AddWithValue("@nom", nom);
                command.Parameters.AddWithValue("@prenom", prenom);
                command.Parameters.AddWithValue("@adresse", adresse);
                command.Parameters.AddWithValue("@telephone", telephone);
                command.Parameters.AddWithValue("@points", points);
                command.Parameters.AddWithValue("@idclient",IdClient);

                command.ExecuteNonQuery();
            }

        }

    }
}
