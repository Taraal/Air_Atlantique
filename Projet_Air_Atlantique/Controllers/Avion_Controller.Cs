using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Air_Atlantique.Controllers
{
    class Avion_Controller
    {
        private int Id { get; set; }
        private Modele_Controller Modele { get; set; }


        public int IdProperty
        {
            get { return Id; ; }
        }

        public Modele_Controller ModeleProperty
        {
            get { return Modele; }
            set { Modele = value; }
        }

        public Avion_Controller() { }

        public Avion_Controller(int Id, Modele_Controller modele)
        {
            this.Id = Id;
            this.Modele = modele;
        }

        public Avion_Controller(int Id)
        {
            this.Id = Id;
        }
    }
}
