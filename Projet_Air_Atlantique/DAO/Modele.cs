﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Projet_Air_Atlantique
{
    class Modele
    {

        private int Id { get; set; }
        private string Label { get; set; }

        public string LabelProperty
        {
            get { return Label; }
            set { Label = value; }
        }

        public Modele() { }

        public Modele(int Id, string Label)
        {
            this.Id = Id;
            this.Label = Label;
        }

        public Modele(int Id)
        {
            this.Id = Id;
        }


    }

    
}
