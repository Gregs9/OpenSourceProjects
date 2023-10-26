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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;

namespace ProjectChallenge102
{




    public partial class Keuze : Window
    {

        // Klasse initialiseren
        public Gebruiker user2;

        // Date: 25/04/2015
        // Author: Gregory Hermans
        public Keuze(Gebruiker user)
        {
            InitializeComponent();
            // Automatisch eerste opties selecteren
            LSBOnderwerp.SelectedIndex = 0;
            LSBMoeilijkheid.SelectedIndex = 0;
            user2 = user;
            // Naam van de gebruiker invullen
            LBLWelkom.Content = "Welkom, " + user.GetSetGebruikersnaam;
        }




        // Date: 25/04/2015
        // Author: Gregory Hermans
        private void CMDSluiten_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Weet je zeker dat je wilt afsluiten?", "Melding", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Keuze Venster openen
                MainWindow MainWindow = new MainWindow();
                MainWindow.Show();

                // Sluiten van dit venster
                this.Close();
            }

        }






        // Date: 25/04/2015
        // Author: Gregory Hermans
        private void CMDStartVragen_Click(object sender, RoutedEventArgs e)
        {
            
            // Vragen Venster openen
            Vragen Vragen = new Vragen(user2);
            Vragen.Show();

            this.Close();

            //Bron: Presentatie .Net
            // Invullen van het gekozen onderwerp op het vragen formulier
            ListBoxItem onderwerp = (ListBoxItem)LSBOnderwerp.Items[LSBOnderwerp.SelectedIndex];
            Vragen.LBLOnderwerp.Content = Convert.ToString(onderwerp.Content);

            // Invullen van de gekozen moeilijkheid op het vragen formulier
            ListBoxItem moeilijkheid = (ListBoxItem)LSBMoeilijkheid.Items[LSBMoeilijkheid.SelectedIndex];
            Vragen.LBLMoeilijkheid.Content = Convert.ToString(moeilijkheid.Content);

        }





        // Date: 25/04/2015
        // Author: Gregory Hermans
        private void CMDStartSpel_Click(object sender, RoutedEventArgs e)
        {
            // Spel venster openen
            Spel Spel = new Spel(user2);
            Spel.Show();

            this.Close();
        }





        // Date: 25/04/2015
        // Author: Gregory Hermans
        private void CMDVragenBewerken_Click(object sender, RoutedEventArgs e)
        {
            // VragenBewerken venster openen
            VragenBewerken VragenBewerken = new VragenBewerken(user2);
            VragenBewerken.Show();
        }




    }// Sluit Classe
}// Sluit Namespace
