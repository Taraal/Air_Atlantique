using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projet_Air_Atlantique.DAL;
using Projet_Air_Atlantique.Controllers;

namespace Projet_Air_Atlantique.Windows
{
    /// <summary>
    /// Interaction logic for ModifVol.xaml
    /// </summary>
    public partial class ModifVol : Window
    {
        public ModifVol(int Id)
        {
            InitializeComponent();
            Aeroport_Model.GetExistingAeroports();
            Vol_Controller vol = Vol_Model.ExistingVols.Find(v => v.IdProperty == Id);
            List<Avion_Controller> myList = Avion_Model.ExistingAvions.Where(x => x.MaintenanceProperty == false && x.EnVolProperty == false).ToList();

            ADepart.ItemsSource = Aeroport_Model.ExistingAeroports;
            ADepart.Text = Aeroport_Model.ExistingAeroports.Find(a => a.IdProperty == vol.ADepartProperty.IdProperty).NomProperty;
            ADepart.SelectedIndex = Aeroport_Model.ExistingAeroports.FindIndex(a => a.IdProperty == vol.ADepartProperty.IdProperty);
            

            AArrivee.ItemsSource = Aeroport_Model.ExistingAeroports;
            AArrivee.Text = Aeroport_Model.ExistingAeroports.Find(a => a.IdProperty == vol.AArriveeProperty.IdProperty).NomProperty;
            AArrivee.SelectedIndex = Aeroport_Model.ExistingAeroports.FindIndex(a => a.IdProperty == vol.AArriveeProperty.IdProperty);
            

            Avion.ItemsSource = myList;
            Avion.Text = Avion_Model.ExistingAvions.Find(av => av.IdProperty == vol.AvionProperty.IdProperty).ModeleProperty.LabelProperty;
            Avion.SelectedIndex = Avion_Model.ExistingAvions.FindIndex(av => av.IdProperty == vol.AvionProperty.IdProperty);
            

            HDepart.Value = DateTime.Parse(vol.HeureDepartProperty);

            HArrivee.Value = DateTime.Parse(vol.HeureArriveeProperty);
            Date.SelectedDate = DateTime.Parse(vol.DateProperty);

            System.Windows.Forms.DateTimePicker dtp = new System.Windows.Forms.DateTimePicker();
            DateTime dt = DateTime.Now;
            this.Title = Id.ToString();
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Annuler", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void ModifierVol(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Confirmer la modification de ce vol ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                int IdVol = Convert.ToInt32(this.Title);
                Aeroport_Controller AB = (Aeroport_Controller)ADepart.SelectedItem;
                Aeroport_Controller AC = (Aeroport_Controller)AArrivee.SelectedItem;

                //Aeroport_Controller AD = Aeroport_Model.ExistingAeroports[ADepart.SelectedIndex];
                //Aeroport_Controller AA = Aeroport_Model.ExistingAeroports[AArrivee.SelectedIndex];
                Avion_Controller avion = Avion_Model.ExistingAvions[Avion.SelectedIndex];
                DateTime? HD = HDepart.Value;
                DateTime? HA = HArrivee.Value;
                string HDString = HD.Value.Hour.ToString() + ":" + HD.Value.Minute.ToString() + ":" + HD.Value.Second.ToString();
                string HAString = HA.Value.Hour.ToString() + ":" + HA.Value.Minute.ToString() + ":" + HA.Value.Second.ToString();
                string DString = Date.SelectedDate.Value.Year.ToString() + "-" + Date.SelectedDate.Value.Month.ToString() + "-" + Date.SelectedDate.Value.Day.ToString();

                Vol_Model.UpdateVol(IdVol, avion, AB, AC, DString, HDString, HAString);
                System.Windows.MessageBox.Show("Vol modifié !");
                this.Close();

            }
        }

    }
}
