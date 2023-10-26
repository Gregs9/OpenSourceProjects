using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ProjectChallenge102.Klasses
{

   
    // Author: Lien Peeters
    // Date: 02/05/2015
    // Klasse met een vierkantje dat de speler kan besturen toegevoegd
    class SpelEntiteit
    {
        // Variabelen
        double xCoord;
        double xCoordNew;
        double yCoord;
        double yCoordNew;

        // List > om op te kunnen roepen
        public Rectangle[] vakje;

        // Constructor
        public SpelEntiteit()
        {
            vakje = new Rectangle[1];
        }

        public void draw()
        {
            //vierkant maken
            Rectangle vierkant = new Rectangle();
            vierkant.Stroke = System.Windows.Media.Brushes.Blue;
            vierkant.Fill = System.Windows.Media.Brushes.Blue;
            vierkant.Width = 10;
            vierkant.Height = 10;

            //positie genereren
            double positieTop = 341;
            double positieLinks = 473;
            Canvas.SetTop(vierkant, positieTop);
            Canvas.SetLeft(vierkant, positieLinks);

            vakje[0] = vierkant;

        }

        public void moveUp()
        {
            yCoord = Canvas.GetTop(vakje[0]);
            yCoordNew = yCoord - 10;

            wallCheck();

            Canvas.SetTop(vakje[0], yCoordNew);
        }

        public void moveDown()
        {
            yCoord = Canvas.GetTop(vakje[0]);
            yCoordNew = yCoord + 10;

            wallCheck();

            Canvas.SetTop(vakje[0], yCoordNew);
        }

        public void moveLeft()
        {
            xCoord = Canvas.GetLeft(vakje[0]);
            xCoordNew = xCoord - 10;

            wallCheck();

            Canvas.SetLeft(vakje[0], xCoordNew);
        }

        public void moveRight()
        {
            xCoord = Canvas.GetLeft(vakje[0]);
            xCoordNew = xCoord + 10;

            wallCheck();

            Canvas.SetLeft(vakje[0], xCoordNew);
        }

        public void wallCheck()
        {
            //checken of de vorm niet tegen de rand botst
            if (xCoordNew == 0 || xCoordNew <= 0)
            {
                xCoordNew = xCoord;
            }
            else if (xCoordNew == 874 || xCoordNew >= 874)
            {
                xCoordNew = xCoord;
            }

            if (yCoordNew == 0 || yCoordNew <= 0)
            {
                yCoordNew = yCoord;
            }
            else if (yCoordNew == 582 || yCoordNew >= 582)
            {
                yCoordNew = yCoord;
            }
        }

    }
}
