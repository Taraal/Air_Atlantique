﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Projet_Air_Atlantique
{
    class Vol
    {
        private int Id { get; set; }
        private Avion Avion { get; set; }
        private Aeroport ADepart { get; set; }
        private Aeroport AArrivee { get; set; }
        private string Date { get; set; }
        private string HeureArrivee { get; set; }
        private string HeureDepart { get; set; }
        private string Header { get; set; }

        public Avion AvionProperty
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

        public Aeroport ADepartProperty
        {
            get { return ADepart; }
            set { ADepart = value; }
        }

        public Aeroport AArriveeProperty
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

        public Vol(int Id, Avion avion, Aeroport ADepart,
            Aeroport AArivee, string Date,
            string HeureDepart, string HeureArrivee)
        {

            this.Id = Id;
            this.Avion = avion;
            this.ADepart = ADepart;
            this.AArrivee = AArrivee;
            this.Date = Date;
            this.HeureDepart = HeureDepart;
            this.HeureArrivee = HeureArrivee;

        }
    }
}
