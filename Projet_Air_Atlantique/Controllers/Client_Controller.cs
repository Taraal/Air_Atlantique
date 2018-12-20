using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Air_Atlantique.DAL;

namespace Projet_Air_Atlantique.Controllers
{
    class Client_Controller
    {

        private int Id { get; set; }
        private string Nom { get; set; }
        private string Prenom { get; set; }
        private string Adresse { get; set; }
        private string Telephone { get; set; }
        private string Mail { get; set; }
        private int Points { get; set; }

        public int IdProperty
        {
            get { return Id; }
        }

        public string NomProperty
        {
            get { return Nom; }
            set { Nom = value; }
        }

        public string PrenomProperty
        {
            get { return Prenom; }
            set { Prenom = value; }
        }

        public string AdresseProperty
        {
            get { return Adresse; }
            set { Adresse = value; }
        }

        public string TelephoneProperty
        {
            get { return Telephone; }
            set { Telephone = value; }
        }

        public string MailProperty
        {
            get { return Mail; }
            set { Mail = value; }
        }

        public int PointsProperty
        {
            get { return Points; }
            set { Points = value; }
        }

        public Client_Controller() { }

        public Client_Controller(int Id, string Nom, string Prenom, string Adresse, string Telephone, string Mail, int Points)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Adresse = Adresse;
            this.Telephone = Telephone;
            this.Mail = Mail;
            this.Points = Points;
        }

        public static void DeleteClient(int IdClient)
        {
            Client_Model.ExistingClients.RemoveAll(v => v.IdProperty == IdClient);
            Client_Model.DeleteClient(IdClient);
        }

    }
}
