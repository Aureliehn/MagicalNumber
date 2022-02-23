using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace number.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Play : ContentPage
    {
        const int NB_MAGIQUE_MIN = 1;
        const int NB_MAGIQUE_MAX = 10;
        int nombreMagique = 0;
        public Play()
        {
            InitializeComponent();
            nombreMagique = new Random().Next(NB_MAGIQUE_MIN, NB_MAGIQUE_MAX);
            MinMaxLabel.Text = "Entre " + NB_MAGIQUE_MIN + " et " + NB_MAGIQUE_MAX;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NumberEntry.Text))
            {
                DisplayAlert("Il faut lire les consignes...", "Vous devez mettre un nombre entre " + NB_MAGIQUE_MIN + " et " + NB_MAGIQUE_MAX, "ok");
                return;
            };
            int nombreUtilisateur = 0;
            try
            {
                nombreUtilisateur = Int32.Parse(NumberEntry.Text);
            }
            catch (Exception)
            {
                DisplayAlert("oups", "Vous devez rentrer UNIQUEMENT des chiffres", "ok");
                return;
            }
            if ((nombreUtilisateur < NB_MAGIQUE_MIN) || (nombreUtilisateur > NB_MAGIQUE_MAX))
            {
                DisplayAlert("Il faut lire les consignes...", "Vous devez mettre un nombre entre " + NB_MAGIQUE_MIN + " et " + NB_MAGIQUE_MAX, "ok");
                return;
            }
            if (nombreMagique > nombreUtilisateur)
            {
                DisplayAlert("oups", "le nombre à trouver est supérieur à " + nombreUtilisateur, "ok");
                return;
            }
            if (nombreMagique < nombreUtilisateur)
            {
                DisplayAlert("oups", "le nombre à trouver est inférieur à " + nombreUtilisateur, "ok");
                return;
            }
            if (nombreMagique == nombreUtilisateur)
            {
                FindNumber();
                return;
            }
        }
        private async Task FindNumber()
        {
            await DisplayAlert("BRAVO!", "Vous avez gagné", "ok");
            await this.Navigation.PopAsync();
        }
    }
}