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

namespace ProjectChallenge102
{

    public partial class InfoSpel : Window
    {
        public InfoSpel()
        {
            InitializeComponent();
        }

        // Date: 06/05/2015
        // Author: Gregory Hermans
        private void CMDOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
