﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        private Boolean inOption = false;
        public Main()
        {
            InitializeComponent();
        }
        #region EVENT HANDLERS
        /// <summary>
        /// Event handler to switch the page to the set up game page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Event handler to show the user the help page when the button is clicked. Shows the user the rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gameplay\n\n" +
                "The Deal\n" +
                "Each player is dealt two cards. The dealer spreads five cards, three at once, then another and then another that can be used by all players to amke their best possible five-card hand.\n\n" +
                "The Play\n" +
                "Each player is dealt two private cards (known as hole cards) that belong to them alone. Five community cards are dealt face-up to form the board. All playres in the game use these shared community cards in conjunction with their own hole cards to each make their best posisble five-cards poker hand." +
                "In Hold 'em, the available actions are fold, check, call, or raise. Exactly which options are available depends on the action taken by the player. If nobody has made a bet, the plaer may either check or bet. If a player makes a bet, the others can call, raise, or fold. To call is to match the amount the previous player has bet. To raise is to bid how much they want ranging from 1 to 100." +
                "\nIf there is more than one remaining player when the final betting round is complete, the last person to bet or raise shows their cards. The player with the best five-card poker hand wins the pot. In the event of identical hands, the pot will be divided between the players with the best hands. After the pot has been awarded, another round begins and the play proceeds clockwise." +
                "\nReference: Bicycle: How to Play App, retrieved on March 18, 2022", "How To Play", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Event handler to switch the page to the options page from the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_Click(object sender, RoutedEventArgs e)
        {

            this.ContentGrid.Visibility = Visibility.Visible;
            this.OptionsView.Visibility = Visibility.Visible;
            inOption = true;
        }

        /// <summary>
        /// Event handler to close the program when the Exit button is pressed on the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// Event handler to send the user to the main menu from the options page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.ContentGrid.Visibility = Visibility.Hidden;
            this.OptionsView.Visibility = Visibility.Hidden;
            inOption = false;
        }

        /// <summary>
        /// Event handler for the accept button in the options page. Sets the window size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_Accept_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            /// mainMenu.OptionAccept();
            this.ContentGrid.Visibility = Visibility.Hidden;
            this.OptionsView.Visibility = Visibility.Hidden;
            inOption = false;

            int selectedIndex = cboWindowMode.SelectedIndex;
            // Fullscreen
            if (selectedIndex == 0)
            {
                this.Visibility = Visibility.Collapsed;
                mainMenu.WindowState = WindowState.Maximized;
                mainMenu.WindowStyle = WindowStyle.None;
                this.Visibility = Visibility.Visible;

                // Windowed Fullscreen
            }
            else if (selectedIndex == 1)
            {
                mainMenu.WindowState = WindowState.Normal;
                mainMenu.WindowStyle = WindowStyle.ThreeDBorderWindow;
                mainMenu.WindowState = WindowState.Maximized;
                this.Visibility = Visibility.Visible;
            }

            // Windowed
            else
            {
                mainMenu.WindowState = WindowState.Normal;
                mainMenu.WindowStyle = WindowStyle.ThreeDBorderWindow;
                this.Visibility = Visibility.Visible;
            }
        }



        #endregion

        /// <summary>
        /// Event handler to load the statistics page and pull all of the data into the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            /// mainMenu.OptionAccept();
            
            this.ContentGrid.Visibility = Visibility.Visible;
            this.StatsView.Visibility = Visibility.Visible;

            try
            {

                //put the connection string in a string
                string connectString = DBAccess.GetConnectionString();
                //create a new connection
                SqlConnection cn = new SqlConnection(connectString);
                //open the connection
                cn.Open();
                //create query
                string selectionQuery = "SELECT * FROM [dbo].[Winner_Logs]";
                //create command, pass the query and connection
                SqlCommand command = new SqlCommand(selectionQuery, cn);
                //declare adapter
                SqlDataAdapter sda = new SqlDataAdapter(command);
                //declare data table
                DataTable dt = new DataTable("Winner_Logs");
                //fill data table with adapter
                sda.Fill(dt);
                //bind sql data table with xaml data table
                playerGrid.ItemsSource = dt.DefaultView;
                //close connection
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Event Handler to return to the main menu when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            this.ContentGrid.Visibility = Visibility.Hidden;
            this.StatsView.Visibility = Visibility.Hidden;
        }
    }
}

