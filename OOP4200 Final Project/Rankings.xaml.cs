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

namespace OOP4200_Final_Project
{
    /// <summary>
    /// Interaction logic for Rankings.xaml
    /// </summary>
    public partial class Rankings : Window
    {
        public Rankings()
        {
            InitializeComponent();
        }

        private void Website_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.888poker.ca/how-to-play-poker/hands/");
        }
    }
}
