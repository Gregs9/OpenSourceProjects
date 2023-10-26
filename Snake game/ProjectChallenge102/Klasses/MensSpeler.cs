using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ProjectChallenge102.Klasses
{


    // Klasse voor de vormen van de speler
    // Author: Lien Peeters
    // Date: 10/04/2015
    class MensSpeler : IGameLogic
    {

        // Generator
        Random genereer = new Random();

        // Variabelen
        double xCoord;
        double xCoordNew;
        double yCoord;
        double yCoordNew;

        // Lijsten
        public int aantalVierkant = 0; //Moet vanuit de gebruiker klasse komen
        public Rectangle[] vierkantLijst;
        public int[] richtingLijstXVierk;
        public int[] richtingLijstYVierk;


        // Constructor
        public MensSpeler(int aantal)
        { 

            aantalVierkant = aantal;
            vierkantLijst = new Rectangle[aantalVierkant]; //lijsten verder geïnitialiseerd
            richtingLijstXVierk = new int[aantalVierkant];
            richtingLijstYVierk = new int[aantalVierkant];

        }




        // Author: Lien Peeters
        // Date: 15/04/2015
        // Draw methode toegevoegd
        public void draw(int plaats)
        {
            //vierkant maken
            Rectangle vierkant = new Rectangle();
            vierkant.Stroke = System.Windows.Media.Brushes.Blue;
            vierkant.Fill = System.Windows.Media.Brushes.Blue;
            vierkant.Width = 10;
            vierkant.Height = 10;

            //positie genereren
            double positieTop = genereer.Next(582);
            double positieLinks = genereer.Next(874);
            Canvas.SetTop(vierkant, positieTop);
            Canvas.SetLeft(vierkant, positieLinks);

            //aan array toevoegen
            vierkantLijst[plaats] = vierkant;

            //aan canvas toevoegen > gebeurd in mainwindow

            //richting
            int richtingX = genereer.Next(0, 2) - 1;
            if (richtingX == 0)
            {
                richtingX = 1;
            }
            richtingLijstXVierk[plaats] = richtingX;

            int richtingY = genereer.Next(0, 2) - 1;
            if (richtingY == 0)
            {
                richtingY = 1;
            }
            richtingLijstYVierk[plaats] = richtingY;



        }



        // Author: Lien Peeters
        // Date: 21/04/2015
        // Move methode en wallcheck methode toegevoegd
        public void move()
        {
            for (int i = 0; i < vierkantLijst.Length; i++)
            {

                //verplaatsen volgens reeds ingestelde richting
                xCoord = Canvas.GetLeft(vierkantLijst[i]);
                xCoordNew = xCoord + richtingLijstXVierk[i];

                yCoord = Canvas.GetTop(vierkantLijst[i]);
                yCoordNew = yCoord + richtingLijstYVierk[i];

                //checken of het tegen de muur botst
                wallCheck(i);

                //nieuwe coordinaat doorgeven
                Canvas.SetLeft(vierkantLijst[i], xCoordNew);
                Canvas.SetTop(vierkantLijst[i], yCoordNew);
            }
        }


        public void wallCheck(int i)
        {
            //checken of de vorm niet tegen de rand botst
            if (xCoordNew == 0 || xCoordNew <= 0)
            {
                richtingLijstXVierk[i] = 1;
            }
            else if (xCoordNew == 874 || xCoordNew >= 874)
            {
                richtingLijstXVierk[i] = -1;
            }

            if (yCoordNew == 0 || yCoordNew <= 0)
            {
                richtingLijstYVierk[i] = 1;
            }
            else if (yCoordNew == 582 || yCoordNew >= 582)
            {
                richtingLijstYVierk[i] = -1;
            }
        }
    }
}
