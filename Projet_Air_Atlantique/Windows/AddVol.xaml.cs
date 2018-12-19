using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projet_Air_Atlantique.DAL;
using Xceed.Wpf.Toolkit;
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
            DateTimePicker dtp = new DateTimePicker();
            DateTime dt = DateTime.Now;
        }

        private void AddNewVol(object sender, RoutedEventArgs e)
        {


        }


    }
}
