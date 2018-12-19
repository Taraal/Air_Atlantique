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
            //DialogResult dr = System.Windows.Forms.MessageBox.Show("Message.", "Title", MessageBoxButtons.YesNoCancel,
            //    MessageBoxIcon.Information);

            if (System.Windows.Forms.MessageBox.Show("Confirmer l'enregistrement de ce vol ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                //int a = Avion.SelectedItem.IdProperty;
                //string b = ADepart.SelectedItem.ToString();
                //string c = AArrivee.SelectedItem.ToString();
                string a = ADepart.Text;
                //Vol_Model.AddNewVol(Avion.SelectedItem, ADepart.SelectedItem.ToString(), AArrivee.SelectedItem.ToString(), Date.ToString(), HDepart.ToString(), HArrivee.ToString());
                    }

        }


    }
}
