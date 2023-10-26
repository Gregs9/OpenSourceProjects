using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ProjectChallenge102.Klasses
{
    // Klasse voor de vormen van computer
    // Author: Lien Peeters
    // Date: 10/04/2015
    public class ComputerSpeler : IGameLogic
    {



        //generator
        Random genereer = new Random();
        



        //variabelen
        double xCoord;
        double xCoordNew;
        double yCoord;
        double yCoordNew;

        public int positieTop;
        public int positieLinks;

        // Lijsten (=vars die uit mainwindow kwamen)
        public int aantalCirkels = 0;
        public Ellipse[] cirkelLijst;
        public int[] richtingLijstXCirkel;
        public int[] richtingLijstYCirkel;





        // Constructor
        public ComputerSpeler()
        { //Wanneer een nieuwe computerspeler gemaakt wordt, worden de lijsten geïnitialiseerd


            int aantal = genereer.Next(15, 26); //26 zit er niet meer bij
            aantalCirkels = aantal;
            cirkelLijst = new Ellipse[aantalCirkels];
            richtingLijstXCirkel = new int[aantalCirkels];
            richtingLijstYCirkel = new int[aantalCirkels];

        }




        // Draw methode toegevoegd
        // Author: Lien Peeters
        // Date: 15/04/2015
        public void draw(int plaats)
        {


            //cirkel maken
            Ellipse cirkel = new Ellipse();
            cirkel.Stroke = System.Windows.Media.Brushes.Red;
            cirkel.Fill = System.Windows.Media.Brushes.Red;
            cirkel.Width = 10;
            cirkel.Height = 10;

            //positie genereren
            positieTop = genereer.Next(582);
            positieLinks = genereer.Next(874);
            Canvas.SetTop(cirkel, positieTop);
            Canvas.SetLeft(cirkel, positieLinks);

            //aan array toevoegen
            cirkelLijst[plaats] = cirkel;

            //aan canvas toevoegen > gebeurd in mainwindow

            //richting bepalen
            int richtingX = genereer.Next(0, 2) - 1;
            if (richtingX == 0)
            {
                richtingX = 1;
            }

            richtingLijstXCirkel[plaats] = richtingX;

            int richtingY = genereer.Next(0, 2) - 1;
            if (richtingY == 0)
            {
                richtingY = 1;
            }
            richtingLijstYCirkel[plaats] = richtingY;






        }





        // Move methode en wallcheck methode toegevoegd
        // Author: Lien Peeters
        // Date: 21/04/2015
        public void move()
        {
            for (int i = 0; i < cirkelLijst.Length; i++)
            {

                //verplaatsen volgens reeds ingestelde richting
                xCoord = Canvas.GetLeft(cirkelLijst[i]);
                xCoordNew = xCoord + richtingLijstXCirkel[i];

                yCoord = Canvas.GetTop(cirkelLijst[i]);
                yCoordNew = yCoord + richtingLijstYCirkel[i];

                //kijken of het niet tegen de muur botst
                wallCheck(i);

                //nieuwe plaats op canvas geven
                Canvas.SetLeft(cirkelLijst[i], xCoordNew);
                Canvas.SetTop(cirkelLijst[i], yCoordNew);
            }
        }



        public void wallCheck(int i)
        {
            //checken of de vorm niet tegen de rand botst
            if (xCoordNew == 0 || xCoordNew <= 0)
            {
                richtingLijstXCirkel[i] = 1;
            }
            else if (xCoordNew == 874 || xCoordNew >= 874)
            {
                richtingLijstXCirkel[i] = -1;
            }

            if (yCoordNew == 0 || yCoordNew <= 0)
            {
                richtingLijstYCirkel[i] = 1;
            }
            else if (yCoordNew == 582 || yCoordNew >= 582)
            {
                richtingLijstYCirkel[i] = -1;
            }
        }


    }
}
