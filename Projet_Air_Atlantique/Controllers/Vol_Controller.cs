using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Projet_Air_Atlantique.DAL;


namespace Projet_Air_Atlantique.Controllers
{
    class Vol_Controller : INotifyPropertyChanged
    {
        private int Id;
        private Avion_Controller Avion;
        private Aeroport_Controller ADepart;
        private Aeroport_Controller AArrivee;
        private string Date;
        private string HeureArrivee;
        private string HeureDepart;
        private string Header;

        public int IdProperty
        {
            get { return Id; }
        }


        public Avion_Controller AvionProperty
        {
            get
            {
                return Avion;
            }
            set
            {
                Avion = value;
            }
        }

        public Aeroport_Controller ADepartProperty
        {
            get { return ADepart; }
            set { ADepart = value; }
        }

        public Aeroport_Controller AArriveeProperty
        {
            get { return AArrivee; }
            set { AArrivee = value; }
        }

        public string DateProperty
        {
            get { return Date; }
            set { Date = value; }
        }


        public string HeureArriveeProperty
        {
            get { return HeureArrivee; }
            set { HeureArrivee = value; }
        }

        public string HeureDepartProperty
        {
            get { return HeureDepart; }
            set { HeureDepart = value; }
        }

        public string HeaderProperty
        {
            get { return Header; }
            set { Header = value; }
        }


        public Vol_Controller() { }

        public Vol_Controller(int Id, Avion_Controller avion, Aeroport_Controller ADepart, 
            Aeroport_Controller AArrivee, string Date, 
            string HeureDepart, string HeureArrivee)
        {

            this.Id = Id;
            this.Avion = avion;
            this.ADepart = ADepart;
            this.AArrivee = AArrivee;
            this.Date = Date;
            this.HeureDepart = HeureDepart;
            this.HeureArrivee = HeureArrivee;
            this.Header = Header;
        }

        public static void DeleteVol(int IdVol)
        {
            Vol_Model.ExistingVols.RemoveAll(v => v.IdProperty == IdVol);
            Vol_Model.DeleteVol(IdVol);
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
