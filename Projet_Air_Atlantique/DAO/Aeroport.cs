using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Projet_Air_Atlantique
{
    class Aeroport
    {
        private string Id { get; set; }
        private string Nom { get; set; }

        public string NomProperty
        {
            get { return Nom; }
            set { Nom = value; }
        }

        public Aeroport() { }

            public Aeroport(string Id, string Nom)
            {
                this.Id = Id;
                this.Nom = Nom;
            }
        }



    }

