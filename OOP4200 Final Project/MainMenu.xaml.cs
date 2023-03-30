using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {



        public MainMenu()
        {
            InitializeComponent();
            this.ContentGrid.Visibility = Visibility.Hidden;
            
        }
      
        private void Play_Click(object sender, RoutedEventArgs e)
        {
           
            this.mainContentControl.Content = new SetUpGame();
            this.ContentGrid.Visibility = Visibility.Visible;

            //MyCard1.Visibility = Visibility.Visible;
            //MyCard2.Visibility = Visibility.Visible;
            /*
            P2Card1.Visibility = Visibility.Visible;
            P2Card2.Visibility = Visibility.Visible;
            P3Card1.Visibility = Visibility.Visible;
            P3Card2.Visibility = Visibility.Visible;
            P4Card1.Visibility = Visibility.Visible;
            P4Card2.Visibility = Visibility.Visible;*/
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help win2 = new Help();
            win2.Show();
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
           
            this.ContentGrid.Visibility = Visibility.Visible;
            this.OptionsView.Visibility = Visibility.Visible;

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Options_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.ContentGrid.Visibility = Visibility.Hidden;
            this.OptionsView.Visibility = Visibility.Hidden;
        }
        
        private void Options_Accept_Click(object sender, RoutedEventArgs e)
        {
            this.ContentGrid.Visibility = Visibility.Hidden;
            this.OptionsView.Visibility = Visibility.Hidden;

            
            int selectedIndex = cboWindowMode.SelectedIndex;
            // Fullscreen
            if (selectedIndex == 0)
            {
                this.Visibility = Visibility.Collapsed;
                this.WindowState = WindowState.Maximized;
                this.WindowStyle = WindowStyle.None;
                this.Visibility = Visibility.Visible;
            
            // Windowed Fullscreen
            } else if (selectedIndex == 1)
            {
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.ThreeDBorderWindow;
                this.WindowState = WindowState.Maximized;
                this.Visibility = Visibility.Visible;
            }

            // Windowed
            else
            {
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.ThreeDBorderWindow;
                this.Visibility = Visibility.Visible;
            }

        }
    }
}
