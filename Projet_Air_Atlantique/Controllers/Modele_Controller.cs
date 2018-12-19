using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Projet_Air_Atlantique.Controllers
{
    class Modele_Controller : INotifyPropertyChanged
    {

        private int Id { get; set; }
        private string Label { get; set; }

        public int IdProperty
        {
            get { return Id; }
        }

        public string LabelProperty
        {
            get { return Label; }
            set { Label = value; }
        }

        public Modele_Controller() { }

        public Modele_Controller(int Id, string Label)
        {
            this.Id = Id;
            this.Label = Label;

        }

        public Modele_Controller(int Id)
        {
            this.Id = Id;
            this.Label = "default";
        }

        public Modele_Controller(string label)
        {
            this.Label = label;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
