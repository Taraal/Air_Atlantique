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
        private bool Maintenance { get; set; }
        private bool EnVol { get; set; }

        public Modele ModeleProperty
        {
            get { return Modele; }
            set { Modele = value; }
        }

        public bool MaintenanceProperty
        {
            get { return Maintenance; }
            set { Maintenance = value; }
        }

        public bool EnVolProperty
        {
            get { return EnVol; }
            set { EnVol = value; }
        }

        public Avion() { }

        public Avion(int Id, Modele modele)
        {
            this.Id = Id;
            this.Modele = modele;

        }
    }
}
