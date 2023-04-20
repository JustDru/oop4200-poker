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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SetUpGame : UserControl
    {
        public SetUpGame()
        {

            InitializeComponent();

            

        }
        public int p1StartAmt;
        public int p2StartAmt;
        public int p3StartAmt;
        public int p4StartAmt;

        


        private void Main_Click(object sender, RoutedEventArgs e)
        {
            Setup.Visibility = Visibility.Hidden;
            Window mainMenuWindow = Window.GetWindow(this);
            if (mainMenuWindow is MainMenu mainMenu)
            {
                mainMenu.OpenMenu();
            }


        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            p1StartAmt = 0;
            p2StartAmt = 0;
            p3StartAmt = 0;
            p4StartAmt = 0;
        ErrorMessages.Clear();

            #region Validation
            if (P1Bet.Text == "" || !int.TryParse(P1Bet.Text, out p1StartAmt))
            {
                ErrorMessages.AppendText("User Amount is Invalid.");
            }
            if (P2Bet.Text == "" || !int.TryParse(P2Bet.Text, out p2StartAmt))
            {
                ErrorMessages.AppendText("\nBot 1 Amount is Invalid.");
            }
            //only checks if bot 2 is playing
            if (P3Active.Text == "Playing")
            {
                if (P3Bet.Text == "" || !int.TryParse(P3Bet.Text, out p3StartAmt))
                {
                    ErrorMessages.AppendText("\nBot 2 Amount is Invalid.");
                }
            }
            //only checks if bot 3 is playing
            if (P4Active.Text == "Playing")
            {
                if (P4Bet.Text == "" || !int.TryParse(P4Bet.Text, out p4StartAmt))
                {
                    ErrorMessages.AppendText("\nBot 3 Amount is Invalid.");
                }
            }
            #endregion

            if (ErrorMessages.Text == "")
            {
                Gameplay gameplay = new Gameplay();
                gameplay.Visibility = Visibility.Visible;

                //start turns at 2, add one if values for bots get passed
                gameplay.numPlayers = 2;
                
                //pass the starting amount values to the textbox, then call
                gameplay.tbxUserAmount.Text = p1StartAmt.ToString();
                gameplay.tbxBot1Amount.Text = p2StartAmt.ToString();
                gameplay.player1StartAmount = p1StartAmt;
                gameplay.player2StartAmount = p2StartAmt;

                //checks to see if the textbox is enabled - only sends value if they are!
                if (P3Bet.IsEnabled == true)
                { 
                    gameplay.tbxBot2Amount.Text = p3StartAmt.ToString();
                    gameplay.player3StartAmount = p3StartAmt;
                    gameplay.numPlayers++;
                }
                else { gameplay.stpBot2Panel.Visibility = Visibility.Hidden; }
                if (P4Bet.IsEnabled == true) 
                { 
                    gameplay.tbxBot3Amount.Text = p4StartAmt.ToString();
                    gameplay.player4StartAmount = p4StartAmt;
                    gameplay.numPlayers++;
                }
                else { gameplay.stpBot3Panel.Visibility = Visibility.Hidden; }

                Window mainMenuWindow = Window.GetWindow(this);
                if (mainMenuWindow is MainMenu mainMenu)
                {
                    Window parentWindow = Window.GetWindow(this);
                    parentWindow.Close();

                }
                


                //call the Call function



                //newgame.Visibility = Visibility.Visible;


            }

        }

        #region Select Logic
        /// <summary>
        /// Event of changing selection for Player 3 Activity.
        /// When changed, it will enable/disable the other comboboxes/textboxes assosiated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P3Active_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (P3Active.SelectedItem == cbiP3Playing)
            {
                P3AI.IsEnabled = true;
                P3AI.Text = "Easy";
                P3Bet.IsEnabled = true;
                P3Bet.Text = "1000";
            }
            else
            {
                P3AI.IsEnabled = false;
                P3AI.Text = "";
                P3Bet.IsEnabled = false;
                P3Bet.Clear();
            }

        }
        /// <summary>
        /// Event of changing selection for Player 4 Activity.
        /// When changed, it will enable/disable the other comboboxes/textboxes assosiated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P4Active_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (P4Active.SelectedItem == cbiP4Playing)
            {
                P4AI.IsEnabled = true;
                P4AI.Text = "Easy";
                P4Bet.IsEnabled = true;
                P4Bet.Text = "1000";
            }
            else
            {
                P4AI.IsEnabled = false;
                P4AI.Text = "";
                P4Bet.IsEnabled = false;
                P4Bet.Clear();
            }
        }
        #endregion

    }
}
