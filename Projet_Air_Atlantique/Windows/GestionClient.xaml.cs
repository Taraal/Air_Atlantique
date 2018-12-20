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
using Projet_Air_Atlantique.Controllers;
using Projet_Air_Atlantique.DAL;

namespace Projet_Air_Atlantique.Windows
{
    /// <summary>
    /// Interaction logic for GestionClient.xaml
    /// </summary>
    public partial class GestionClient : Window
    {
        public GestionClient(int Id)
        {
            InitializeComponent();
            Client_Controller client = Client_Model.ExistingClients.Find(c => c.IdProperty == Id);

            this.Title = Id.ToString();

            Nom.Text = client.NomProperty;
            Prenom.Text = client.PrenomProperty;
            Adresse.Text = client.AdresseProperty;
            Telephone.Text = client.TelephoneProperty;
            Points.Text = client.PointsProperty.ToString();


        }

        private void DeleteClient(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Confirmer la suppression de ce vol ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Client_Controller.DeleteClient(Convert.ToInt32(this.Title));


                MainWindow m = new MainWindow();
                m.Activate();
                m.Show();

                this.Close();
            }
        }

        //private void UpdateClient(object sender, RoutedEventArgs e)
        //{
        //    System.Windows.Controls.Button but = sender as System.Windows.Controls.Button;



        //    ModifVol p = new ModifVol(Convert.ToInt32(((System.Windows.Controls.Button)sender).Tag));

        //    p.Show();


        //}
    }
}
