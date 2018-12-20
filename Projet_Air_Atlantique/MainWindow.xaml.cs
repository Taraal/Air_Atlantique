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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using Projet_Air_Atlantique.DAL;
using Projet_Air_Atlantique.Controllers;



namespace Projet_Air_Atlantique
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Vol_Controller control_vol = new Vol_Controller();

        public MainWindow()
        {
            InitializeComponent();
            Aeroport_Model.GetExistingAeroports();
            Avion_Model.GetExistingAvions();
            Vol_Model.GetExistingVols();
            Client_Model.GetExistingClients();
            DataContext = this;
            Title = "AIR ATLANTIQUE";
            
            Flights.ItemsSource = Vol_Model.ExistingVols;

            Clients.ItemsSource = Client_Model.ExistingClients;

            //MessageBox.Show(vols[0].DateProperty);
        }

        private void DetailsClick(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;

            Windows.DetailVol p = new Windows.DetailVol(Convert.ToInt32(((Button)sender).Tag));

            p.Show();
            this.Close();
        }

        private void AddNewVol(object sender, RoutedEventArgs e)
        {

            Windows.AddVol p = new Windows.AddVol();


            p.Show();

            this.Close();
        }

        private void DetailsClientClick(object sender, RoutedEventArgs e)
        {
            Windows.GestionClient gc = new Windows.GestionClient(Convert.ToInt32(((Button)sender).Tag));

            gc.Show();
            this.Close();

        }

        private void AddNewClient(object sender, RoutedEventArgs e)
        {

            Windows.AddClient p = new Windows.AddClient();

            p.Show();
            this.Close();

        }

    }
    

}
