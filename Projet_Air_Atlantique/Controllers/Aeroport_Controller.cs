using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Projet_Air_Atlantique.Controllers
{
    class Aeroport_Controller : INotifyPropertyChanged
    {
        private string Id { get; set; }
        private string Nom { get; set; }

        public string IdProperty
        {
            get { return Id; }
        }


        public string NomProperty
        {
            get { return Nom; }
            set { Nom = value; }
        }

        public Aeroport_Controller() { }

        public Aeroport_Controller(string Id, string Nom)
        {
            this.Id = Id;
            this.Nom = Nom;
        }

        public Aeroport_Controller(string Id)
        {
            this.Id = Id;
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }

}
