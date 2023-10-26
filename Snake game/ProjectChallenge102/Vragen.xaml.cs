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
using System.Collections.Generic;

namespace ProjectChallenge102
{

    public partial class Vragen : Window
    {
        // Instantie aanmaken voor meldingen
        private Exception Melding = new Exception();

        // Pad is afhankelijk van welk onderwerp
        string pad; 
        
        // Variable antwoord aanmaken
        string antwoord = "";

        // Variable voor de vraag in te plaatsen
        String lijn2;

        // Variable voor de score
        int juist = 0;

        // Variable voor het controleren van de eind stap
        bool check = false;

        int vraagNummer = 0;

        // Array om reeds gevraagde vagen in bij te houden
        int[] reedsGesteldeVragen = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        // Bron: http://stackoverflow.com/questions/5410430/wpf-timer-like-c-sharp-timer
        // Timer aanmaken
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        // Klasse initialiseren
        public Gebruiker user3;





        // Date: 08/04/2015 17:00
        // Author: Hendrik Bijnens & Gregory Hermans
        public Vragen(Gebruiker user2)
        {
            // Formulier initialiseren
            InitializeComponent();
            user3 = user2;

            // Formulier centreren
            this.Left = 800 - 262;
            this.Top = 450 - 175;
        }





        // Date: 08/04/2015 17:00
        // Author: Hendrik Bijnens
        private void CMDBevestig_Click(object sender, RoutedEventArgs e)
        {
            // Deze knop onzichtbaar maken en volgende zichtbaar maken
            CMDBevestig.Visibility = Visibility.Collapsed;
            CMDVolgende.Visibility = Visibility.Visible;

            // Timer stoppen
            dispatcherTimer.Stop();

            // Als het antwoord juist is
            if (antwoord == TXTAntwoord.Text)
            {
                antwoordJuist();
            }
            // Als het antwoord fout is
            else
            {
                antwoordFout();
            }// Sluit if-statement

        }// Sluit CMDBevestig_Click event






        // Date: 08/04/2015 17:00
        // Author: Hendrik Bijnens
        private void CMDVolgende_Click(object sender, RoutedEventArgs e)
        {
            // Deze knop onzichtbaar maken en volgende zichtbaar maken
            CMDBevestig.Visibility = Visibility.Visible;
            CMDVolgende.Visibility = Visibility.Collapsed;

            // Vraagnummer invullen
            LBLVraagAantal.Content = "Vraag " + ++vraagNummer + "/10";

            // Juiste antwoord resetten
            LBLJuisteAntwoord.Content = "";

            // Tijd Resetten
            PGBTijd.Value = 75;
            dispatcherTimer.Start();

             // Reset TXTAntwoord
            TXTAntwoord.Background = Brushes.White;
            TXTAntwoord.Text = "";

            // Bepaal grootte van het tekstbestand
            int aantalLijnen = bepaalLijnen();

            // Kies een willekeurig nummer dat de vraag & antwoord voorstelt
            int vraagLijn = geneerWillekeurigeLijn(aantalLijnen);

            try
            {

                // Vraag & antwoord bepalen
                StreamReader inputStream2 = File.OpenText(pad);

                for (int i = 1; i < vraagLijn + 1; i++)
                {

                    lijn2 = inputStream2.ReadLine();

                    if (i == vraagLijn - 1)
                    {
                        LBLVraag.Content = lijn2;
                    }
                    else if (i == vraagLijn)
                    {
                        antwoord = lijn2;
                    }// Sluit if-statement
                }// Sluit for lus

                inputStream2.Close();

            }
            catch
            {
                Melding.berichtWaars("De vragen kunnen niet worden ingelezen!","Fout");
            }
            // Timer starten
            dispatcherTimer.Start();

        }// Sluit CMDVolgende_Click event




        // Date: 10/04/2015 17:00
        // Author: Hendrik Bijnens
        private void CMDStart_Click(object sender, RoutedEventArgs e)
        {

            // Pad van de vraagkeuze bepalen
            string onderwerp = LBLOnderwerp.Content.ToString();
            string moeilijkheid = LBLMoeilijkheid.Content.ToString();

            // Vraag nummer invullen
            LBLVraagAantal.Content = "Vraag 1/10";
            vraagNummer = 1;

            // Onderwerp Bepalen
            switch (onderwerp)
            {

                case "Kennis":
                    switch (moeilijkheid)
                    {
                        case "Makkelijk":
                            pad = Environment.CurrentDirectory + @"\Tekstbestanden\KennisMakkelijk.txt";
                            LBLMoeilijkheid.Foreground = System.Windows.Media.Brushes.Green;
                            break;
                        case "Gemiddeld":
                            pad = Environment.CurrentDirectory + @"\Tekstbestanden\KennisGemiddeld.txt";
                            LBLMoeilijkheid.Foreground = System.Windows.Media.Brushes.Yellow;
                            break;
                        case "Moeilijk":
                            pad = Environment.CurrentDirectory + @"\Tekstbestanden\KennisMoeilijk.txt";
                            LBLMoeilijkheid.Foreground = System.Windows.Media.Brushes.Red;
                            break;
                    }
                    break;
                case "Taal":
                    switch (moeilijkheid)
                    {
                        case "Makkelijk":
                            pad = Environment.CurrentDirectory + @"\Tekstbestanden\TaalMakkelijk.txt";
                            LBLMoeilijkheid.Foreground = System.Windows.Media.Brushes.Green;
                            break;
                        case "Gemiddeld":
                            pad = Environment.CurrentDirectory + @"\Tekstbestanden\TaalGemiddeld.txt";
                            LBLMoeilijkheid.Foreground = System.Windows.Media.Brushes.Yellow;
                            break;
                        case "Moeilijk":
                            pad = Environment.CurrentDirectory + @"\Tekstbestanden\TaalMoeilijk.txt";
                            LBLMoeilijkheid.Foreground = System.Windows.Media.Brushes.Red;
                            break;
                    }
                    break;
                case "Wiskunde":
                    switch (moeilijkheid)
                    {
                        case "Makkelijk":
                            pad = Environment.CurrentDirectory + @"\Tekstbestanden\WiskundeMakkelijk.txt";
                            LBLMoeilijkheid.Foreground = System.Windows.Media.Brushes.Green;
                            break;
                        case "Gemiddeld":
                            pad = Environment.CurrentDirectory + @"\Tekstbestanden\WiskundeGemiddeld.txt";
                            LBLMoeilijkheid.Foreground = System.Windows.Media.Brushes.Yellow;
                            break;
                        case "Moeilijk":
                            pad = Environment.CurrentDirectory + @"\Tekstbestanden\WiskundeMoeilijk.txt";
                            LBLMoeilijkheid.Foreground = System.Windows.Media.Brushes.Red;
                            LBLWiskundeTip.Visibility = Visibility.Visible;
                            break;
                            
                    }
                    break;
            }// Sluit Switch

            // Huidige gebruiker invullen in de textbox voor de leerkracht
            TXTFouteVragen.Text = "Gebruiker: " + user3.GetSetGebruikersnaam + Environment.NewLine + "Deze vragen had deze gebruiker fout:" + Environment.NewLine;

            // Bevestig en volgende knoppen tonen
            CMDBevestig.Visibility = Visibility.Visible;
            CMDVolgende.Visibility = Visibility.Visible;
            CMDStart.Visibility = Visibility.Collapsed;
            CMDInfo.Visibility = Visibility.Collapsed;

            // Reset TXTAntwoord achtergrond
            TXTAntwoord.Background = Brushes.White;
            TXTAntwoord.Text = "";

            // Bepaal grootte van het tekstbestand
            int aantalLijnen = bepaalLijnen();

            //Kies een willekeurig nummer dat de vraag & antwoord voorstelt
            int vraagLijn = geneerWillekeurigeLijn(aantalLijnen);

            try
            {

                // Vraag & antwoord bepalen vanuit de tekstbestanden
                StreamReader inputStream2 = File.OpenText(pad);

                for (int i = 1; i < vraagLijn + 1; i++)
                {

                    String lijn2 = inputStream2.ReadLine();

                    if (i == vraagLijn - 1)
                    {
                        LBLVraag.Content = lijn2;
                    }
                    else if (i == vraagLijn)
                    {
                        antwoord = lijn2;
                    }// Sluit if-statement
                }// Sluit for lus

            // Bestandslezer sluiten
            inputStream2.Close();

            }
            catch
            {
                Melding.berichtWaars("De vragen kunnen niet ingelezen worden!","Fout");
            }


            // Vraag 1 invullen
            LBLVraagAantal.Content = "Vraag 1/10";

            // Timer starten
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 400); // 400 Milliseconden
            dispatcherTimer.Start();


        }// Sluit CMDStart_Click event




        // Date: 04/05/2015 15:07
        // Author: Gregory Hermans
        private void CMDInfo_Click(object sender, RoutedEventArgs e)
        {
            // Info formulier openen
            Info info = new Info();
            info.Show();
        } // Einde CMDInfo_Click event




        // Date: 25/04/2015 15:38
        // Author: Gregory Hermans & Hendrik Bijnens
        private void CMDSluiten_Click(object sender, RoutedEventArgs e)
        {
            // Venster sluiten en keuze venster openen
            Keuze Keuze = new Keuze(user3);
            Keuze.Show();
            Keuze.LBLPunten.Content = user3.Punten;
            this.Close();

            // Ervoor zorgen dat het info venster ook mee sluit indien dit nog open staat
            Info info = new Info();
            info.Close();
        }




        // Date: 25/04/2015 12:26
        // Author: Gregory Hermans
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // De progressbar verminderen met 1
            PGBTijd.Value = PGBTijd.Value - 1;

            // Indien de waarde 0 of kleiner is, is de tijd om
            if (PGBTijd.Value <= 0)
            {
                // Knoppen regelen
                CMDBevestig.Visibility = Visibility.Collapsed;
                CMDVolgende.Visibility = Visibility.Visible;

                // Timer stoppen
                dispatcherTimer.Stop();

                // Melden dat de tijd om is
                Melding.berichtWaars("Tijd om!", "Melding");

                // Waarde van de progressbar resetten
                PGBTijd.Value = 75;
                

                // Als de tijd verloopt, word het antwoord fout geteld.
                antwoordFout();

            }
        } 




        // Date: 08/04/2015 17:00
        // Author: Hendrik Bijnens
        private int bepaalLijnen()
        {
            // Aantal lijnen van de TextAlignment file bepalen
            int aantalLijnen = 0;

            StreamReader inputStream1 = File.OpenText(pad);
            String lijn1 = inputStream1.ReadLine();

            while (lijn1 != null)
            {
                aantalLijnen += 1;
                lijn1 = inputStream1.ReadLine();

            } // Sluit while lus
            inputStream1.Close();
            return aantalLijnen;
        }





        // Date: 08/04/2015 17:00
        // Author: Hendrik Bijnens
        private int geneerWillekeurigeLijn(int aantalLijnen)
        {
            // Willekeurige vraag kiezen
            Random r = new Random();
            int vraagNr = r.Next(0, aantalLijnen / 3);
            int vraagLijn = vraagNr * 3;


            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            Boolean vraagIsNieuw = false;

            // Elke keer er een vraag genereerd word die in deze sessie reeds gesteld is zal er een nieuwe gegenereerd worden.
            while (vraagIsNieuw == false)
            {

                vraagIsNieuw = true;
               
                // Controlleren of de gegenereerde vraaglocatie reeds gekozen was.
                for (int i = 0; i < 10; i++)
                {

                    // Indien de vraag reeds gesteld was, vraagIsNieuw op false zetten
                    if (reedsGesteldeVragen[i] == vraagLijn)
                    {

                        vraagIsNieuw = false;

                    } // sluit If controle op vraagnummer

                } //sluit for

                // Indien er een vraag gevonden was die reeds gesteld was, een nieuwe vraaglocatie genereren en deze opnieuw controlleren met de tabel.
                if (vraagIsNieuw == false)
                {

                        // Nieuw willekeurige vraag kiezen
                        r = new Random();
                        vraagNr = r.Next(0, aantalLijnen / 3);
                        vraagLijn = vraagNr * 3;

                }


            } //sluit while

            // Een nieuwe vraag aan de controletabel toevoeggen:
            Boolean vraagToegevoegd = false;

            // De tabel doorlopen en de vraag op de eerste beschikbare plaats (= -1) toevoegen.
            for (int i = 0; i < 10; i++)
            {

                // Kijken of de vraag reeds aan de tabel was toegevoegd.
                if (vraagToegevoegd == false)
                {

                    // Kijken of de huidige plaats in de tabel beschikbaar is.
                    if (reedsGesteldeVragen[i] == -1)
                    {

                        reedsGesteldeVragen[i] = vraagLijn; 

                        vraagToegevoegd = true;

                    } // eide If controle beschikbare plaats.

                } // end If controle vraag toegevoegd.


            } // end For statment


            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            return vraagLijn;

        }





        // Date: 25/04/2015 12:38
        // Author: Gregory Hermans
        private void antwoordJuist()
        {
            // Achtergrond groen maken (juist)
            TXTAntwoord.Background = Brushes.Green;
            juist++;

            // Geluid afspelen
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Geluiden\RightAnswer.wav");
            player.Play();

            // Timer stoppen
            dispatcherTimer.Stop();

            if (vraagNummer == 10)
            {
                einde();
            }// Sluit if-statement
        }




        // Date: 25/04/2015 12:38
        // Author: Gregory Hermans
        private void antwoordFout()
        {
            // Achtergrond rood maken (fout)
            TXTAntwoord.Background = Brushes.Red;

            // Juiste antwoord invullen
            LBLJuisteAntwoord.Content = "Het juiste antwoord: " + antwoord;

            // Geluid afspelen
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Geluiden\WrongAnswer.wav");
            player.Play();

            // De foute vraag + antwoord plaatsen in de textbox
            TXTFouteVragen.Text = TXTFouteVragen.Text + Environment.NewLine + LBLVraag.Content + Environment.NewLine + TXTAntwoord.Text + Environment.NewLine;

            // Timer stoppen
            dispatcherTimer.Stop();

            if (vraagNummer == 10)
            {
                einde();
            }// Sluit if-statement
        }




        // Date: 25/04/2015 12:38
        // Author: Gregory Hermans & Hendrik Bijnens
        private void einde()
        {
            // Indien dit al afgelopen is (ter bescherm indien de timer afloopt en de knop tegelijk worden ingedrukt)
            if (check==false){

                // Knoppen verbergen
                CMDVolgende.Visibility = Visibility.Collapsed;
                CMDBevestig.Visibility = Visibility.Collapsed;
                CMDSluiten.Visibility = Visibility.Visible;
                CMDInfo.Visibility = Visibility.Visible;
                LBLWiskundeTip.Visibility = Visibility.Collapsed;

                // Totale score invullen
                TXTFouteVragen.Text = TXTFouteVragen.Text + Environment.NewLine + Environment.NewLine + "Totale score: " + juist + "/10";

                // Juiste antwoord resetten
                LBLJuisteAntwoord.Content = "";

                // Timer stoppen
                dispatcherTimer.Stop();

                // Punten van de gebruiker verhogen
                user3.verhoogPunt(juist);

                try
                {

                    // De gegevens verzamelen en oplslaan in een bestand voor de leerkracht
                    string pad = Environment.CurrentDirectory + @"\Verslagen\" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + " " + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + "-" + System.DateTime.Now.Second + " " + user3.GetSetGebruikersnaam + " Verslag.txt";
                    StreamWriter outputStream = File.CreateText(pad);
                    outputStream.Close();
                    System.IO.File.WriteAllText(pad, TXTFouteVragen.Text);
                }
                catch
                {
                    Melding.berichtWaars("Het verslag kon niet worden opgeslagen!","Fout");
                }
                check = true;
        }
        }



        } // Sluit Klasse
    } // Sluit Namespace