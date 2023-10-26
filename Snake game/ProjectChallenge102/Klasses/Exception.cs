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


    // Date: 25/04/2015
    // Author: Gregory Hermans
    // Hier komen alle meldingen in te staan
    public class Exception
    {

        private bool meldingGegeven;

        // Constructor
        public Exception() {}



        // Date: 25/04/2015
        // Author: Gregory Hermans
        public bool berichtOK(string titel, string context) {
            MessageBox.Show(titel, context, MessageBoxButton.OK, MessageBoxImage.Information);
            meldingGegeven = true;
            return meldingGegeven;
        }




        // Date: 25/04/2015
        // Author: Gregory Hermans
        public bool berichtWaars(string titel, string context)
        {
            MessageBox.Show(titel, context, MessageBoxButton.OK, MessageBoxImage.Error);
            meldingGegeven = true;
            return meldingGegeven;
        }





    }
}
