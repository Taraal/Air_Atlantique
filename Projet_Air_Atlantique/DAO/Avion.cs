using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projet_Air_Atlantique
{
    class Avion
    {
        private int Id { get; set; }
        private Modele Modele { get; set; }

        public Modele ModeleProperty
        {
            get { return Modele; }
            set { Modele = value; }
        }

        public Avion() { }

        public Avion(int Id, Modele modele)
        {
            this.Id = Id;
            this.Modele = modele;

        }
    }
}
