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
    // Date: 22/04/2015
    // Klasse toegevoegd om te tonen dat vierkantje en cirkel gebotst zijn
    class End
    {



        // Lijsten
        public Rectangle[] endLijst = new Rectangle[25];
        public int[] endLijstX = new int[25];
        public int[] endLijstY = new int[25];
        public bool[] endExists = new bool[25];


        // Constructor
        public End()
        {
            Rectangle[] endLijst = new Rectangle[25];
            endLijstX = new int[25];
            endLijstY = new int[25];
            endExists = new bool[25];

        }



        public void draw(double xPos, double yPos, int plaats)
        {
            // Vierkant maken
            Rectangle end = new Rectangle();
            end.Stroke = System.Windows.Media.Brushes.Gray;
            end.Fill = System.Windows.Media.Brushes.Gray;
            end.Width = 10;
            end.Height = 10;

            // Positie bepalen
            double positieTop = yPos;
            double positieLinks = xPos;
            Canvas.SetTop(end, positieTop);
            Canvas.SetLeft(end, positieLinks);

            // Aan array toevoegen
            endLijst[plaats] = end;


        }

    }
}
