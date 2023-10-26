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

namespace ProjectChallenge102
{

    public partial class MainWindow : Window
    {

        // Instantie aanmaken voor meldingen
        public Exception Melding = new Exception();

        // Het pad invullen
        string pad = Environment.CurrentDirectory + @"\Tekstbestanden\Accounts.txt";

        // Globale variable voor het testen van de gebruikersnaam
        bool bestaand = false;

        // Variable voor het melden indien de gebruikersnaam niet gevonden is
        bool gevonden = false;




        // Date: 30/03/2015 18:18
        // Author: Gregory Hermans
        public MainWindow()
        {
            // Formulier initialiseren
            InitializeComponent();

            // Formulier centreren
            this.Left = 800-262;
            this.Top = 450-175;
        }







        // Date: 30/03/2015 18:18
        // Author: Gregory Hermans & Lien Peeters
        private void CMDLogin_Click(object sender, RoutedEventArgs e)
        {
            // Variable aanmaken
            string line;
            bool ingelogd = false;

            // Bestand inlezen
            System.IO.StreamReader file = new System.IO.StreamReader(pad);

            // Regel per regel inlezen, de loop zal alleen "/" inlezen
            while ((line = file.ReadLine()) != null)
            {


                // Gebruikersnaam in variable plaatsen
                string gebruikersnaam = file.ReadLine();
                // Wachtwoord in variable plaatsen
                string wachtwoord = file.ReadLine();

                // Checken als gebruikersnaam juist is
                if (TXTGebruikersnaam.Text.Equals(gebruikersnaam))
                {
                    // Checken als het bijhorende wachtwoord klopt
                    if (TXTWachtwoord.Password.Equals(wachtwoord))
                    {
                        // Indien met ingelogd geraakt is
                        ingelogd = true;
                        Melding.berichtOK("Succesvol ingelogd!", "Melding");

                        // Keuze Venster openen
                        // Instantie aanmaken voor gebruikers
                        Gebruiker user = new Gebruiker();
                        user.GetSetGebruikersnaam = TXTGebruikersnaam.Text;
                        Keuze Keuze = new Keuze(user);
                        Keuze.Show();
                        this.Close();
                    }
                }

            }

            // Kijken als de gebruiker ingelogd is
            if (ingelogd == false)
            {
                // Indien men niet ingelogd geraakt is
                Melding.berichtWaars("Verkeerde gegevens", "Fout!");
            }

            // Sluiten van het bestand
            file.Close();
        }




        // Date: 30/03/2015 17:23
        // Author: Lien Peeters
        private void CMDSluiten_Click(object sender, RoutedEventArgs e)
        {
            // Sluiten van het venster
            Environment.Exit(0);
        }





        // Date: 05/04/2015 12:54
        // Author: Gregory Hermans
        private void CMDWachtwoordVergeten_Click(object sender, RoutedEventArgs e)
        {
            // Gebruikersnaam opvragen
            string gbrnaam = inputBox("Geef de gebruikersnaam in.", "Melding");

            // Bestand openen
            System.IO.StreamReader file = new System.IO.StreamReader(pad);

            // Gebruikersnaam per gebruikesnaam controleren
            while ((file.ReadLine()) != null)
            {
                // De variable resetten
                gevonden = false;

                // Wachtwoord en scheidingsteken opvangen (deze moeten niet getest worden)
                string gebruikersnaam = file.ReadLine();
                string ww = file.ReadLine();

                if (gebruikersnaam.Equals(gbrnaam))
                {
                    // De variable invullen dat de gebruiker gevonde is
                    gevonden = true;

                    // Het bijhorende wachtwoord van de ingegeven gebruikersnaam tonen
                    Melding.berichtOK("Het bijhorende wachtwoord is: " + ww, "Melding");

                }  // Sluit if-statement

               

            } // Sluit while-statement

                // Melden dat de opgegeven gebruikersnaam niet bestaat
                if (gevonden == false)
                {
                    // Melden dat de gebruikersnaam niet bestaat
                    Melding.berichtWaars("De opgegeven gebruikersnaam bestaat niet!", "Fout");

                } // Sluit if-statement


        } // Sluit CMDWachtwoordVergeten_Click event







        // Date: 31/03/2015 18:38
        // Author: Gregory Hermans
        private void CMDRegistreer_Click(object sender, RoutedEventArgs e)
        {
            // Controleren als de gebruikersnaam al bestaat
            ControleerGebruikersnaam();

            if (bestaand == true)
            {
                Melding.berichtWaars("Deze gebruikersnaam bestaat al.", "Fout!");
            }
            else
            {
                // Indien de gebruikersnaam niet bestaat, het account aanmaken
                AccountAanmaken();
            }
        }







        // Date: 31/03/2015 8:13
        // Author: Gregory Hermans
        public void AccountAanmaken()
        {
            // Bestand openen
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pad, true))
            {
                // Testen als de wachtwoorden overeenkomen
                string wachtwoordBev = inputBox("Bevestig het wachtwoord", "Bevestigen");
                if (TXTWachtwoord.Password.Equals(wachtwoordBev))
                {
                    // De nieuwe gegevens toevoegen aan het tekstbestand
                    file.WriteLine("/");
                    file.WriteLine(TXTGebruikersnaam.Text);
                    file.WriteLine(TXTWachtwoord.Password);
                    file.Close();
                    Melding.berichtOK("Gegevens opgeslagen." + Environment.NewLine + "Herstart het programma om te kunnen inloggen.", "Melding");
                }
                else
                {
                    // Indien de wachtwoorden niet overeen komen
                    file.Close();
                    Melding.berichtWaars("Wachtwoorden komen niet overeen!", "Fout!");
                }
            }
        }






        // Date: 31/03/2015 8:13
        // Author: Gregory Hermans
        public void ControleerGebruikersnaam()
        {
            // Bestand openen
            System.IO.StreamReader file = new System.IO.StreamReader(pad);
            // Variable aanmaken
            string gebruikersnaam;

            // Gebruikersnaam per gebruikesnaam controleren
            while ((gebruikersnaam = file.ReadLine()) != null)
            {

                // Wachtwoord en scheidingsteken opvangen (deze moeten niet getest worden)
                file.ReadLine();
                file.ReadLine();

                // Testen als de gebruikersnaam al bestaat
                if (gebruikersnaam.Equals(TXTGebruikersnaam.Text))
                {
                    bestaand = true;
                }
            }
            // Bestand sluiten
            file.Close();
        }





        // Date: 31/03/2015 8:13
        // Author: Gregory Hermans
        // Methode voor het vragen van info
        public string inputBox(string vraag, string titel)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(vraag, titel);
            return input;
        }





    } // Sluit Class
} // Sluit Namespace