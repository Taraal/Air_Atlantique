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
using Projet_Air_Atlantique.Controllers;
using Projet_Air_Atlantique.DAL;

namespace Projet_Air_Atlantique.Windows
{
    /// <summary>
    /// Interaction logic for ModifClient.xaml
    /// </summary>
    public partial class ModifClient : Window
    {
        public ModifClient(int Id)
        {
            InitializeComponent();
            Client_Controller client = Client_Model.ExistingClients.Find(c => c.IdProperty == Id);

            this.Title = Id.ToString();

            Nom.Text = client.NomProperty;
            Prenom.Text = client.PrenomProperty;
            Adresse.Text = client.AdresseProperty;
            Telephone.Text = client.TelephoneProperty;
            Points.Text = client.PointsProperty.ToString();

            Back.Tag = Id;
        }


        public void UpdateClient(object sender, RoutedEventArgs e) { 


            
        }


        public void Retour(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button but = sender as System.Windows.Controls.Button;

            
            GestionClient g = new GestionClient(Convert.ToInt32(((System.Windows.Controls.Button)sender).Tag));
            g.Activate();
            g.Show();

            this.Close();
        }



    }
}
