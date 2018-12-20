using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Projet_Air_Atlantique.DAL;
using Projet_Air_Atlantique.Controllers;

namespace Projet_Air_Atlantique.Windows
{
    /// <summary>
    /// Interaction logic for AddVol.xaml
    /// </summary>
    public partial class AddVol : Window
    {
        public AddVol()
        {
            
            InitializeComponent();
            List<Avion_Controller> myList = Avion_Model.ExistingAvions.Where(x => x.MaintenanceProperty == false && x.EnVolProperty == false).ToList();
            ADepart.ItemsSource = Aeroport_Model.ExistingAeroports;
            AArrivee.ItemsSource = Aeroport_Model.ExistingAeroports;
            Avion.ItemsSource = myList;
            System.Windows.Forms.DateTimePicker dtp = new System.Windows.Forms.DateTimePicker();
            DateTime dt = DateTime.Now;
        }

        private void AddNewVol(object sender, RoutedEventArgs e)
        {

            if (System.Windows.Forms.MessageBox.Show("Confirmer l'enregistrement de ce vol ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                Aeroport_Controller AD = Aeroport_Model.ExistingAeroports[ADepart.SelectedIndex];
                Aeroport_Controller AA = Aeroport_Model.ExistingAeroports[AArrivee.SelectedIndex];
                Avion_Controller avion = Avion_Model.ExistingAvions[Avion.SelectedIndex];
                DateTime? HD = HDepart.Value;
                DateTime? HA = HArrivee.Value;
                string HDString = HD.Value.Hour.ToString() + ":" + HD.Value.Minute.ToString() + ":" + HD.Value.Second.ToString();
                string HAString = HA.Value.Hour.ToString() + ":" + HA.Value.Minute.ToString() + ":" + HA.Value.Second.ToString();
                string DString = Date.SelectedDate.Value.Year.ToString() + "-" + Date.SelectedDate.Value.Month.ToString() + "-" + Date.SelectedDate.Value.Day.ToString();
                
                Vol_Model.AddNewVol(avion, AD, AA, DString, HDString, HAString);

                MainWindow m = new MainWindow();
                m.Activate();
                m.Show();


                this.Close();

                    }

        }


        private void Retour(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();

            m.Activate();
            m.Show();

            this.Close();


        }


    }
}
