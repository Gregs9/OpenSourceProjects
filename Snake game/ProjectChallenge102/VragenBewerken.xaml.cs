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
using System.IO;
using Microsoft.Win32;

namespace ProjectChallenge102
{


    public partial class VragenBewerken : Window
    {
        // Klasse initialiseren
        public Gebruiker user;

        // Instantie van Exception klasse aanmaken
        public Exception melding = new Exception();

        // Date: 25/04/2015 13:36
        // Author: Gregory Hermans
        public VragenBewerken(Gebruiker user)
        {
            // Form initialiseren
            InitializeComponent();
        }



        // Date: 25/04/2015 13:36
        // Author: Gregory Hermans
        // Openen van het bestand
        private void CMDOpen_Click(object sender, RoutedEventArgs e)
        {
            // Browse venster openen
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // De directory met de tekstbestanden invullen en openen
            string startdir = Environment.CurrentDirectory + @"\Tekstbestanden";
            openFileDialog.InitialDirectory = startdir;

            // Alleen .txt bestanden tonen
            openFileDialog.Filter = "Image Files|*.TXT;" +"|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {    
                // Het geselecteerde tekstbestand openen in de textbox
                TXTPad.Text = (openFileDialog.FileName);
                TXTBestand.Text = File.ReadAllText(TXTPad.Text);
            }
            else
            {
                // Melden dat er geen bestand geselecteerd is
                melding.berichtWaars("Geen bestand geselecteerd!", "Waarschuwing");
            } // Einde if-statement


        } // Einde CMDOpen_Click event



        // Date: 25/04/2015 13:36
        // Author: Gregory Hermans
        // Opslaan van het bewerkte bestand
        private void CMDOpslaan_Click(object sender, RoutedEventArgs e)
        {
            // Nieuwe aanpassingen overschrijven
            System.IO.File.WriteAllText(TXTPad.Text, TXTBestand.Text);

            // Melden dat het opgeslagen is
            melding.berichtOK("Veranderingen opgeslagen!", "Melding");

        } // Einde CMDOpslaan_Click event



        // Date: 25/04/2015 13:36
        // Author: Gregory Hermans
        // Sluiten van het huidige venster
        private void CMDSluiten_Click(object sender, RoutedEventArgs e)
        {
            // Checken als de gebruiker zeker wilt afsluiten
            if (MessageBox.Show("Weet je zeker dat je wilt afsluiten?", "Melding", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Sluiten van dit venster
                this.Close();
            } // Einde if-statement
        } // Sluit CMDSluiten_Click event



    } // Sluit Klasse
} // Sluit Namespace
