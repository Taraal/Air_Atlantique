using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Projet_Air_Atlantique
{
    class Vol
    {
        public int Id { get; set; }
        public Avion Avion { get; set; }
        public Aeroport ADepart { get; set; }
        public Aeroport AArrivee { get; set; }
        public string Date { get; set; }
        public string HeureArrivee { get; set; }
        public string HeureDepart { get; set; }
        public string Header { get; set; }



        public Vol(int Id)
        {
            MySqlDataReader dr = DAL.Vol_Model.GetInfos(Id);

            while (dr.Read())
            {
                this.Avion = DAL.Avion_Model.CheckExistsThenAdd(dr.GetInt32("avion"));
                this.ADepart = DAL.Aeroport_Model.CheckExistsThenAdd(dr.GetString("adepart"));
                this.AArrivee = DAL.Aeroport_Model.CheckExistsThenAdd(dr.GetString("aarrivee"));
                this.Date = dr.GetString("date");
                this.HeureDepart = dr.GetString("heuredepart");
                this.HeureArrivee = dr.GetString("heurearrivee");
            }
            this.Header = DAL.Vol_Model.GetHeader(this);

        }
    }
}
