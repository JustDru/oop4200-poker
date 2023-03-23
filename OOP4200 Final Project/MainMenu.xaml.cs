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

        string resolution;
        string windowSize;


        public MainMenu()
        {
            InitializeComponent();
            this.ContentGrid.Visibility = Visibility.Hidden;
            
        }
        public static void Show_Menu()
        {
            //Control menu = new MainMenu();
            //menu.Visibility = Visibility.Visible;
            //System.Windows.Application.Current.Shutdown();
            Window menu = new MainMenu();
            menu.Show();
        }

        private String getResolution()
        {
            return this.resolution;
        }
        private void setResolution(string resolution)
        {
            this.resolution = resolution;
        }
        private string getWindowSize()
        {
            return this.windowSize;
        }
        private void setWindowSize(string windowSize)
        {
            this.windowSize = windowSize;
        }

        public void SetOptions(string resolution, string windowSize)
        {
            setResolution(resolution);
            setWindowSize(windowSize);

        }

      
        private void Play_Click(object sender, RoutedEventArgs e)
        {
           
            this.mainContentControl.Content = new SetUpGame();
            this.ContentGrid.Visibility = Visibility.Visible;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            this.mainContentControl.Content = new Options();
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
            this.OptionsView.Visibility= Visibility.Hidden;


            
            Object selectedItem = cboWindowMode.SelectedItem;
            if (1==2)
            {
                this.Visibility = Visibility.Collapsed;
                this.WindowState = WindowState.Maximized;
                this.WindowStyle = WindowStyle.None;
                this.Visibility = Visibility.Visible;
            }


        }
    }
}
