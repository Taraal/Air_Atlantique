using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Air_Atlantique.Controllers
{
    class Avion_Controller
    {
        private int Id;
        private Modele_Controller Modele;
        private bool Maintenance;
        private bool EnVol;


        public int IdProperty
        {
            get { return Id; ; }
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

        public Modele_Controller ModeleProperty
        {
            get { return Modele; }
            set { Modele = value; }
        }

        public Avion_Controller() { }

        public Avion_Controller(int Id, Modele_Controller modele, bool maintenance, bool envol)
        {
            this.Id = Id;
            this.Modele = modele;
            Maintenance = maintenance;
            EnVol = envol;
        }

        public Avion_Controller(int Id)
        {
            this.Id = Id;
            Maintenance = false;
            EnVol = false;
        }
    }
}
