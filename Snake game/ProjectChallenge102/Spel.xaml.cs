using ProjectChallenge102.Klasses;
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
using System.Windows.Threading;
using System.IO;


namespace ProjectChallenge102
{


    // Basis spel
    // Author: Lien Peeters
    // Date: 08/04/2015
    public partial class Spel : Window
    {

        // Bron voor de elipse class: https://msdn.microsoft.com/en-us/library/system.windows.shapes.ellipse%28v=vs.110%29.aspx
        // Bron voor de canvas class: https://msdn.microsoft.com/en-us/library/System.Windows.Controls.Canvas%28v=vs.110%29.aspx
        // In de mainwindow horen de timers en eventhandlers te zitten
        private DispatcherTimer bewegen = new DispatcherTimer();
        private DispatcherTimer gewonnen = new DispatcherTimer();
        bool spelerActief = false;
        bool playerWon = false;
        int wonCheck = 0;

        // Variable voor het aantal punten
        int aantalPunten;

        // Variable voor de tijd (50 seconden)
        int countdown = 50;

        // Objecten van eigen klasses aanmaken 
        ComputerSpeler computer = new ComputerSpeler(); // Als dit niet zichtbaar is > using spel.klasses
        MensSpeler speler;
        SpelEntiteit instance = new SpelEntiteit();
        End eindvormen = new End();
        SpelEntiteit entiteit = new SpelEntiteit();

        // Instantie aanmaken voor meldingen
        public Exception Melding = new Exception();

        // Klasse initialiseren
        public Gebruiker user2;






        // Constructor
        public Spel(Gebruiker user)
        {
            // Form initialiseren
            InitializeComponent();

            // Form correct plaatsen
            this.Left = 20;
            this.Top = 20;

            user2 = user;

            // Aantal punten invullen
            LBLPunten.Content = Convert.ToInt32(user.Punten);
            user.Punten = Convert.ToInt32(LBLPunten.Content);

            // Computer cirkels aanmaken
            for (int i = 0; i < computer.aantalCirkels; i++)
            {
                computer.draw(i);

                spelVeld.Children.Add(computer.cirkelLijst[i]);
                eindvormen.endExists[i] = false;
            }

            bewegen.Tick += bewegen_Tick;
            bewegen.Interval = TimeSpan.FromMilliseconds(30);
            bewegen.Start();
        }




        // Author: Lien Peeters
        // Date: 08/04/2015
        // Start click event toegevoegd
        private void Button_ClickSpelerVierkant(object sender, RoutedEventArgs e)
        {
            if (spelerActief == false)
            {
                // Aantal punten invullen
                aantalPunten = Convert.ToInt32(user2.Punten);
                speler = new MensSpeler(aantalPunten);

                for (int i = 0; i < speler.aantalVierkant; i++)
                {
                    speler.draw(i);
                    spelVeld.Children.Add(speler.vierkantLijst[i]);
                }
                spelerActief = true;
                entiteit.draw();
                spelVeld.Children.Add(entiteit.vakje[0]);

                gewonnen.Tick += gewonnen_Tick;
                gewonnen.Interval = TimeSpan.FromSeconds(1);
                gewonnen.Start();

                // Muziek starten
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Geluiden\Song.wav");
                player.Play();

                // Punten resetten
                user2.Punten = 0;

                // Knoppen regelen
                CMDBegin.Visibility = Visibility.Collapsed;
                CMDUp.Visibility = Visibility.Visible;
                CMDDown.Visibility = Visibility.Visible;
                CMDLeft.Visibility = Visibility.Visible;
                CMDRight.Visibility = Visibility.Visible;

            }
        }








        // Author: Lien Peeters
        // Date: 03/05/2015
        // Knoppen om te bewegen
        private void arrowUpButton_Click(object sender, RoutedEventArgs e)
        {
            entiteit.moveUp();
        }
        private void arrowDownButton_Click(object sender, RoutedEventArgs e)
        {
            entiteit.moveDown();
        }
        private void arrowLeftButton_Click(object sender, RoutedEventArgs e)
        {
            entiteit.moveLeft();
        }
        private void arrowRightButton_Click(object sender, RoutedEventArgs e)
        {
            entiteit.moveRight();
        }


        // Author: Gregory Hermans
        // Date: 07/05/2015 9:17
        // Ervoor zorgen dat men het ook kan bewegen met de pijltjestoetsen
        // Bron: http://stackoverflow.com/questions/1646998/up-down-left-and-right-arrow-keys-do-not-trigger-keydown-event
        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Up)
                {
                    entiteit.moveUp();
                }
                else if (e.Key == Key.Down)
                {
                    entiteit.moveDown();
                }
                else if (e.Key == Key.Left)
                {
                    entiteit.moveLeft();
                }
                else if (e.Key == Key.Right)
                {
                    entiteit.moveRight();
                }
            }
            catch
            {
                Melding.berichtOK("Start het spel om te beginnen met spelen!","Melding");
            }
        }






        // Author: Gregory Hermans
        // Date: 03/05/2015
        // Knop voor het afsluiten
        private void CMDStop_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Weet je zeker dat je wilt afsluiten?", "Melding", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Info venster sluiten indien het nog geopend is
                InfoSpel infoSpel = new InfoSpel();
                infoSpel.Close();

                // Keuze venster openen
                Keuze keuze = new Keuze(user2);
                keuze.Show();

                // Punten updaten
                keuze.LBLPunten.Content = user2.Punten;

                // Huidig venster sluiten
                this.Close();

                // Muziek stoppen
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Geluiden\Song.wav");
                player.Stop();
            }
            
        }






        // Author: Gregory Hermans
        // Date: 06/05/2015
        // Info tonen over het spel
        private void CMDInfo_Click(object sender, RoutedEventArgs e)
        {
            // Info venster tonen
            InfoSpel infoSpel = new InfoSpel();
            infoSpel.Show();
        }



        // Author: Lien Peeters
        // Date: 22/04/2015
        void bewegen_Tick(object sender, EventArgs e)
        {
            computer.move();
            if (spelerActief == true)
            {
                speler.move();
                positionCheck();
            }
        }



        // Author: Lien Peeters
        // Date: 22/04/2015
        // Methode om te checken of de vormen botsen aangemaakt
        public void positionCheck()
        {
            for (int i = 0; i < speler.aantalVierkant; i++)
            {
                double xCoord = Canvas.GetLeft(speler.vierkantLijst[i]);
                double yCoord = Canvas.GetTop(speler.vierkantLijst[i]);


                for (int j = 0; j < computer.aantalCirkels; j++)
                {

                    double xCoordDif = xCoord - Canvas.GetLeft(computer.cirkelLijst[j]);
                    double yCoordDif = yCoord - Canvas.GetTop(computer.cirkelLijst[j]);
                    if (((xCoordDif > -7 && xCoordDif <= 0) && (yCoordDif > -7 && yCoordDif <= 0) && eindvormen.endExists[j] == false) || ((xCoordDif < 7 && xCoordDif >= 0) && (yCoordDif < 7 && yCoordDif >= 0) && eindvormen.endExists[j] == false))
                    {
                        eindvormen.draw(xCoord, yCoord, j);
                        spelVeld.Children.Add(eindvormen.endLijst[j]);

                        eindvormen.endExists[j] = true;
                        computer.cirkelLijst[j].Visibility = System.Windows.Visibility.Collapsed;

                    }

                }
            }

            double xCoordEntiteit = Canvas.GetLeft(entiteit.vakje[0]);
            double yCoordEntiteit = Canvas.GetTop(entiteit.vakje[0]);
            for (int j = 0; j < computer.aantalCirkels; j++)
            {

                double xCoordDif = xCoordEntiteit - Canvas.GetLeft(computer.cirkelLijst[j]);
                double yCoordDif = yCoordEntiteit - Canvas.GetTop(computer.cirkelLijst[j]);
                if (((xCoordDif > -7 && xCoordDif <= 0) && (yCoordDif > -7 && yCoordDif <= 0) && eindvormen.endExists[j] == false) || ((xCoordDif < 7 && xCoordDif >= 0) && (yCoordDif < 7 && yCoordDif >= 0) && eindvormen.endExists[j] == false))
                {

                    eindvormen.draw(xCoordEntiteit, yCoordEntiteit, j);
                    spelVeld.Children.Add(eindvormen.endLijst[j]);

                    eindvormen.endExists[j] = true;
                    computer.cirkelLijst[j].Visibility = System.Windows.Visibility.Collapsed;
                }
            }

        }



        
        // Author: Lien Peeters
        // Date: 06/05/2015
        // Methoden die gebruikt worden bij het winnen van het spel uitgewerkt
        public void playerWonCheck()
        {
            wonCheck = 0;
            for (int i = 0; i < computer.aantalCirkels; i++)
            {
                if (eindvormen.endExists[i] == true)
                {
                    wonCheck += 1;
                }
            }
            if (wonCheck == computer.aantalCirkels)
            {
                // Muziek stoppen
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Geluiden\Song.wav");
                player.Stop();

                // Geluid afspelen
                // Bron: http://stackoverflow.com/questions/3502311/how-to-play-a-sound-in-c-net
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Geluiden\Victory.wav");
                player2.Play();

                // Score invullen
                LBLScore.Content = Convert.ToString((aantalPunten * 50) + (countdown * 100));
                LBLScore.Visibility = Visibility.Visible;
                LBLScoreTitel.Visibility = Visibility.Visible;

                // Label tonen dat men gewonnen heeft
                LBLWon.Visibility = System.Windows.Visibility.Visible;

                playerWon = true;
                gewonnen.Stop();

                // Highscore vergelijken
                try
                {
                    string pad = Environment.CurrentDirectory + @"\Tekstbestanden\Highscore.txt";
                    StreamReader inputStream = File.OpenText(pad);
                    String score = inputStream.ReadLine();
                    inputStream.Close();

                    if (Convert.ToInt32(score) < Convert.ToInt32(LBLScore.Content))
                    {
                        // Tonen dat men een highscore gehaald heeft
                        LBLHighscore.Visibility = Visibility.Visible;

                        // Nieuwe score overschrijven
                        System.IO.File.WriteAllText(pad, Convert.ToString(LBLScore.Content));
                    }
                }
                catch
                {
                    Melding.berichtWaars("Kan de highscore niet opslaan!","Fout");
                }
            }


        }





        // Author: Lien Peeters
        // Date: 22/04/2015
        private void gewonnen_Tick(object sender, EventArgs e)
        {
            countdown -= 1;
            resterendeTijd.Content = countdown;
            playerWonCheck();
            if ((countdown == 0) && (playerWon == false))
            {
                // Melden dat het spel gedaan is
                Melding.berichtOK("Je hebt verloren! Probeer volgende keer beter te doen.","Jammer :(");

                // Info venster sluiten indien het nog geopend is
                InfoSpel infoSpel = new InfoSpel();
                infoSpel.Close();

                // Keuze venster openen
                Keuze keuze = new Keuze(user2);
                keuze.Show();

                // Huidig venster sluiten
                this.Close();

                // Muziek stoppen
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + @"\Geluiden\Song.wav");
                player.Stop();
            }


        }





    } // Sluit klasse
} // Sluit namespace
