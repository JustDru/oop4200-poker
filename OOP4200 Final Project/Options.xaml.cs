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

namespace OOP4200_Final_Project
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : UserControl
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Accept_CLick(object sender, RoutedEventArgs e)
        {
           
        }

        private void Options_Cancel_Click(object sender, RoutedEventArgs e)
        {
            //MainMenu.Show_Menu();
            //Control menu = new MainMenu();
            //this.Content = menu;
            MainMenu menu1 = new MainMenu();
            MainMenu.Show_Menu();
        }
    }
}
