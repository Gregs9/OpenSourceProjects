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

// Date: 04/05/2015
// Author: Gregory Hermans
namespace ProjectChallenge102
{

    public partial class Info : Window
    {


        public Info()
        {
            // Form initialiseren
            InitializeComponent();
        }


        // Date: 04/05/2015
        // Author: Gregory Hermans
        private void CMDOK_Click(object sender, RoutedEventArgs e)
        {
            // Venster sluiten
            this.Close();
        }
    }
}
