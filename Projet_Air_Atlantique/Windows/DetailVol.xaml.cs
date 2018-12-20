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
    /// Logique d'interaction pour DetailVol.xaml
    /// </summary>
    public partial class DetailVol : Window
    {
        public DetailVol(int Id)
        {
            InitializeComponent();

            Vol_Controller vol = Vol_Model.ExistingVols.Find(v => v.IdProperty == Id);
            //Dictionary<string, string> dicString = Vol_Model.GetInfosString(Id);
            //Dictionary<string, int> dicInt = Vol_Model.GetInfosInt(Id);

            //Vol_Controller vol = new Vol_Controller(dicInt["idvol"], Avion_Model.CheckExistsThenAdd(dicInt["idavion"]),
            //    Aeroport_Model.CheckExistsThenAdd(dicString["adepart"]),
            //    Aeroport_Model.CheckExistsThenAdd(dicString["aarrivee"]),
            //    dicString["date"].ToString(),
            //    dicString["heuredepart"].ToString(),
            //    dicString["heurearrivee"].ToString());
            //Console.WriteLine(dicString["adepart"]);
            this.Title = Id.ToString() ;

            ADepart.Text = vol.ADepartProperty.NomProperty;
            AArrivee.Text = vol.AArriveeProperty.NomProperty;
            HeureArrivee.Text = vol.HeureArriveeProperty;
            HeureDepart.Text = vol.HeureDepartProperty;
            Date.Text = vol.DateProperty;
            Avion.Text = vol.AvionProperty.ModeleProperty.LabelProperty;
            VolNum.Text = vol.IdProperty.ToString();

            this.DataContext = this;
            Modif.Tag = Id;
        }

        private void DeleteVol(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Confirmer la suppression de ce vol ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Vol_Controller.DeleteVol(Convert.ToInt32(this.Title));

                System.Windows.MessageBox.Show("Vol supprimé avec succès");
                this.Close();
            }
        }

        private void UpdateVol(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button but = sender as System.Windows.Controls.Button;

            

            ModifVol p = new ModifVol(Convert.ToInt32(((System.Windows.Controls.Button)sender).Tag));

            p.Show();

        }

    }
}
