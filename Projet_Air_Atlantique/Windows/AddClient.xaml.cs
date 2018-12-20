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
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();



        }



        private void AddNewClient(object sender, RoutedEventArgs e)
        {

            if (System.Windows.Forms.MessageBox.Show("Confirmer l'enregistrement de ce client ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {

                
                Client_Controller client = new Client_Controller(Client_Model.ExistingClients.Count, Nom.Text, Prenom.Text, Adresse.Text, Telephone.Text, Mail.Text, 0);
                Client_Model.AddNewClient(client);

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
