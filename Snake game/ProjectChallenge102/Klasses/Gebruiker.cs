using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChallenge102
{


    // Date: 25/04/2015
    // Author: Gregory Hermans
    public class Gebruiker
    {
        String gebruikersnaam;
        int punten = 0;


        // Constructor
        public Gebruiker() {}


        // Properties
        public string GetSetGebruikersnaam
        {
            get { return gebruikersnaam; }
            set { gebruikersnaam = value; }
        }


        public int Punten
        {
            get { return punten; }
            set { punten = value; }
        }

        // Methodes
        public void verhoogPunt(int aantalP)
        {
            punten += aantalP;
        }


    }
}
