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
            this.Title = "AIR ATLANTIQUE";
            List<Vol_Controller> vols = new List<Vol_Controller>();
            Vol_Model.GetVols(vols);

            Flights.ItemsSource = vols;
            
        }

        private void DetailsClick(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;

     
            Windows.DetailVol p = new Windows.DetailVol(1);

            p.Show();
        }

    }
    

}
