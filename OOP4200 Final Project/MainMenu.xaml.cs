#region USINGS
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
#endregion

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

        #region EVENT HANDLERS
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
            MessageBox.Show("Gameplay\n\n" +
                "The Deal\n" +
                "Each player is dealt two cards. The dealer spreads five cards, three at once, then another and then another that can be used by all players to amke their best possible five-card hand.\n\n" +
                "The Play\n" +
                "Each player is dealt two private cards (known as hole cards) that belong to them alone. Five community cards are dealt face-up to form the board. All playres in the game use these shared community cards in conjunction with their own hole cards to each make their best posisble five-cards poker hand." +
                "In Hold 'em, the available actions are fold, check, call, or raise. Exactly which options are available depends on the action taken by the player. If nobody has made a bet, the plaer may either check or bet. If a player makes a bet, the others can call, raise, or fold. To call is to match the amount the previous player has bet. To raise is to bid how much they want ranging from 1 to 100." +
                "\nIf there is more than one remaining player when the final betting round is complete, the last person to bet or raise shows their cards. The player with the best five-card poker hand wins the pot. In the event of identical hands, the pot will be divided between the players with the best hands. After the pot has been awarded, another round begins and the play proceeds clockwise." +
                "\nReference: Bicycle: How to Play App, retrieved on March 18, 2022");
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

        
        #endregion
    }
}
