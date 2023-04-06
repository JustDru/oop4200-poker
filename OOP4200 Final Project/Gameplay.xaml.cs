using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : Window
    {
        
        // Keep track of whos turn it is
        int turn = 1;
        // Variable to track the ai's random choice
        int choice = 0;
        int call;
        // Smallest number of players is 2
        int numPlayers = 2;

        // Booleans to track which players folded
        bool p1Fold, p2Fold, p3Fold, p4Fold;
        int foldCount;

        // Variable to keep track of the current pot
        int pot = 0;
        // Variable to keep track of the value that someone raised the pot by
        int raisedNum = 0;
        // Boolean flag to track whether somebody raised or not
        bool isRaise = false;

        Deck deck = new Deck();

        public Gameplay()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Method that runs when the game is started - initalizes all players
        /// </summary>
        public void Start()
        {
            // Create the player object for the human player
            int player1StartAmount = Int32.Parse(tbxUserAmount.Text);
            Player player1 = new Player("Player 1", deck.DrawCards(2), player1StartAmount);

            // Bot 1 is enabled by default, create their Player object
            int player2StartAmount = Int32.Parse(tbxBot1Amount.Text);
            Player player2 = new Player("Player 2", deck.DrawCards(2), player2StartAmount);

            // If bot 2 is enabled create their Player object
            if (tbxBot2Amount != null)
            {
                int player3StartAmount = Int32.Parse(tbxBot2Amount.Text);
                Player player3 = new Player("Player 3", deck.DrawCards(2), player3StartAmount);
                numPlayers++;
            }
            // If bot 3 is enabled create their Player object
            if (tbxBot3Amount != null)
            {
                int player4StartAmount = Int32.Parse(tbxBot3Amount.Text);
                Player player4 = new Player("Player 4", deck.DrawCards(2), player4StartAmount);
                numPlayers++;
            }
            // Give the dealer their five cards
            List<Card> dealerCards = deck.DrawCards(5);

            Continue();


        }


        /// <summary>
        /// Function to assign the user as folded and print out a status message
        /// </summary>
        public void Fold()
        {
            if (turn == 1)
            {
                p1Fold = true;
                lbxAnnoucements.Items.Add("You folded");
            }
            else if (turn == 2)
            {
                p2Fold = true;
                lbxAnnoucements.Items.Add("Player 2 has folded");
                
            }
            else if (turn == 3)
            {
                p3Fold = true;
                lbxAnnoucements.Items.Add("Player 3 has folded");
                
            }
            else if (turn == 4)
            {
                p4Fold = true;
                lbxAnnoucements.Items.Add("Player 4 has folded");
               
            }
            Continue();
            /*
            if (foldcount == (numPlayers -1) && P1Fold == false)
            {
                if (int.TryParse(tbxUserAmount.Text, out int record1))
                {
                    if (int.TryParse(tbxPot.Text, out int record2))
                    {
                        record1 += record2;
                        tbxAnnouncements.Text = "You won $" + record2;
                    }
                    tbxUserAmount.Text = record1.ToString();
                    NextRoundbtn.IsEnabled = true;
                }
            }
            else if (foldcount == (numPlayers -1) && P2Fold == false)
            {
                if (int.TryParse(tbxBot1Amount.Text, out int record3))
                {
                    if (int.TryParse(tbxPot.Text, out int record4))
                    {
                        record3 += record4;
                        tbxAnnouncements.Text = "Player 2 has won $" + record4;
                    }
                    tbxBot1Amount.Text = record3.ToString();
                    NextRoundbtn.IsEnabled = true;
                }
            }
            else if (foldcount == (numPlayers - 1) && P3Fold == false)
            {
                if (int.TryParse(tbxBot2Amount.Text, out int record5))
                {
                    if (int.TryParse(tbxPot.Text, out int record6))
                    {
                        record5 += record6;
                        tbxAnnouncements.Text = "Player 3 has won $" + record6;
                    }
                    tbxBot2Amount.Text = record5.ToString();
                }
                NextRoundbtn.IsEnabled = true;
            }
            else if (foldcount == (numPlayers - 1) && P4Fold == false)
            {
                if (int.TryParse(tbxBot3Amount.Text, out int record7))
                {
                    if (int.TryParse(tbxPot.Text, out int record8))
                    {
                        record7 += record8;
                        tbxAnnouncements.Text = "Player 4 has won $" + record8;
                    }
                    tbxBot3Amount.Text = record7.ToString();
                }
                NextRoundbtn.IsEnabled = true;
            }
            turn++;
            TurnDisplay.Text = "Turn " + turn;
            Thread.Sleep(1000);
            Continue();
            */
        }


        /// <summary>
        /// Function that is called when a user presses the Check button to pass their turn
        /// </summary>
        public void Check()
        {
            // Checking is just passing your turn, print out a small message for whoever checks
            if (turn == 1)
            {
               
                if(p1Fold == false)
                {
                    lbxAnnoucements.Items.Add("You checked");
                }
            }
            else if (turn == 2)
            {
                if (p2Fold == false)
                {
                    lbxAnnoucements.Items.Add("Player 2 has checked");
                }

            }
            else if (turn == 3)
            {
                if (p3Fold == false)
                {
                    lbxAnnoucements.Items.Add("Player 3 has checked");
                }
            }
            else if (turn == 4)
            {
                if (p4Fold == false)
                {
                    lbxAnnoucements.Items.Add("Player 4 has checked");
                    
                }
            }
            Continue();
        }

        /// <summary>
        /// Function to run through the turns
        /// </summary>
        public void Continue()
        {// Human players turn 
            if (turn == 1)
            {
                if(p1Fold == false)
                {
                    
                }
                else
                {
                    turn++;
                }
            }
            // Second players turn (will choose a random action)
            if (turn == 2 )
            {
                if (p2Fold == false)
                {
                    RandomActionDecider();
                }
                // If there are more than 2 players, increment the count by 1, else set it back to player 1
                if (turn < numPlayers) { turn++; }
                else { turn = 1; }
            }
            // Third players turn, same as above
            if (turn == 3 && p3Fold == false)
            {
                RandomActionDecider();
                if (turn < numPlayers) { turn++; }
                else { turn = 1; }
            }

            if (turn == 4 && p4Fold == false)
            {
                RandomActionDecider();
                // Set the turn to player 1's turn again
                turn = 1;
            }

        }


        /// <summary>
        /// Function that is called when the Raise button is pressed, takes money from the player who raises
        /// and adds it to the pot using the RaisePot function
        /// </summary>
        public void Raise()
        {
            // Create a random number generator to randomly raise for the ai
            Random randomSelector = new Random();
            int raiseAmount;
            if (turn == 1)
            {
                // Get the amount that the user wants to raise the pot by
                raiseAmount = Convert.ToInt32(tbxRaise.Text.ToString());
                RaisePot("player1", raiseAmount);
            }
            // Ai turns, chooses a random number from 1 to 100 to raise by
            else if (turn == 2)
            {
                raiseAmount = randomSelector.Next(1, 100);
                RaisePot("player2", raiseAmount);
            }
            else if (turn == 3)
            {
                raiseAmount = randomSelector.Next(1, 100);
                RaisePot("player3", raiseAmount);
            }
            else
            {
                raiseAmount = randomSelector.Next(1, 100);
                RaisePot("player4", raiseAmount);
            }
            isRaise = true;
            Continue();
        }

        /// <summary>
        /// Function that matches the current raise 
        /// </summary>
        public void Call()
        {
            if (turn == 1)
            {
                // Print out a message and call the RaisePot function to raise the pot by the call amount
                if (p1Fold == false)
                {
                    lbxAnnoucements.Items.Add("You called");
                    RaisePot("player1", raisedNum);
                }
            }
            else if (turn == 2)
            {
                if (p2Fold == false)
                {
                    lbxAnnoucements.Items.Add("Player 2 has called");
                    RaisePot("player2", raisedNum);
                }

            }
            else if (turn == 3)
            {
                if (p3Fold == false)
                {
                    lbxAnnoucements.Items.Add("Player 3 has called");
                    RaisePot("player3", raisedNum);
                }
            }
            else if (turn == 4)
            {
                if (p4Fold == false)
                {
                    lbxAnnoucements.Items.Add("Player 4 has called");
                    RaisePot("player4", raisedNum);

                }
            }
            Continue();
            /*
            if (turn == 1)
            {
                DisableActions();
                try
                {
                    if (int.TryParse(tbxUserAmount.Text, out int callAmount))
                    {
                        callAmount--;
                        tbxUserAmount.Text = callAmount.ToString();
                        callamountraise++;
                        tbxPot.Text = callamountraise.ToString();
                        callamountraise = callamountraise * 2;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has occurred");
                }
            }
            else if (turn == 2)
            {
                try
                {
                    if (int.TryParse(tbxBot1Amount.Text, out int bot1callAmount))
                    {
                        //deduct how much was the callamountraise
                        bot1callAmount-= callamountraise;

                        //convert to string to return how much is left
                        tbxUserAmount.Text = bot1callAmount.ToString();

                        //add to pot
                        if(int.TryParse(tbxPot.Text, out int addamount))
                        {
                            addamount += callamountraise;
                        }
                        //return the value for display
                        tbxPot.Text = bot1callAmount.ToString();
                    }
                    //
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has occurred");
                }
            }
            else if (turn == 3)
            {
                try
                {
                    if (int.TryParse(tbxBot1Amount.Text, out int bot2callAmount))
                    {
                        bot2callAmount-= callamountraise;
                        tbxUserAmount.Text = bot2callAmount.ToString();
                        if (int.TryParse(tbxPot.Text, out int addamount2))
                        {
                            addamount2 += callamountraise;
                        }
                        tbxPot.Text = bot2callAmount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has occurred");
                }
            }
            else if (turn == 4)
            {
                try
                {
                    if (int.TryParse(tbxBot1Amount.Text, out int bot3callAmount))
                    {
                        bot3callAmount-= callamountraise;
                        tbxUserAmount.Text = bot3callAmount.ToString();
                        if (int.TryParse(tbxPot.Text, out int addamount3))
                        {
                            addamount3 += callamountraise;
                        }
                        tbxPot.Text = bot3callAmount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has occurred");
                }
                turn = 1;
            }
            Continue();
            */
        }


        BitmapImage CARDBACK = new BitmapImage(new Uri("CardBack.png", UriKind.Relative));
        BitmapImage RandomCard = new BitmapImage(new Uri("2_of_clubs.png", UriKind.Relative));//placeholder until class logic
        int TurnCounter = 0;
        int RoundCounter = 0;
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            //moves on with the round

            //When bot logic finishes, turn counter will go up by 1
            //unless there was a raise, which will reset the turn counter
            //once turn counter hits 4, the dealer revieals the next cards
            //after all rounds, all cards are displayed and the winner
            //gets the pot, and will be stated who won in the announcements
            if (turn == 1)
            {
                btnContinue.IsEnabled = true;

                // If nobody raised, you cannot call
                if (isRaise == false)
                {
                    rbCall.IsEnabled = false;
                }
                else 
                { 
                    rbCall.IsEnabled = true; 
                }

                // Call the function based on which radio button is clicked
                if (rbCall.IsChecked == true)
                {
                    Call();
                }
                else if (rbFold.IsChecked == true)
                {
                    Fold();
                }
                else if (rbRaise.IsChecked == true)
                {
                    Raise();
                }
                else if (rbCheck.IsChecked == true)
                {
                    Check();
                }
                else
                {
                    MessageBox.Show("Please select an option");
                }
                turn++;
                Continue();
            }
            /*
            tbxRaise.IsEnabled = false;
            rbCall.IsChecked = false;
            rbFold.IsChecked = false;
            rbRaise.IsChecked = false;
            rbCheck.IsChecked = false;
            tbxRaise.Clear();
            if (DealerCard1.Source == CARDBACK)
            {
                DealerCard1.Source = RandomCard;
                DealerCard2.Source = RandomCard;
                DealerCard3.Source = RandomCard;
                UserCard1.Source = RandomCard;
                UserCard2.Source = RandomCard;

                lbxAnnoucements.Items.Clear();
                lbxAnnoucements.Items.Add("Dealer: Cards Delt");

                btnContinue.IsEnabled = false;
                RoundCounter++;
            }
            else if (DealerCard4.Source == CARDBACK)
            {
                DealerCard4.Source = RandomCard;

                lbxAnnoucements.Items.Add("Dealer: Card 4 revealed");

                btnContinue.IsEnabled = false;
                RoundCounter++;
            }
            else if (DealerCard5.Source == CARDBACK)
            {
                DealerCard5.Source = RandomCard;

                lbxAnnoucements.Items.Add("Dealer: Card 5 revealed");

                btnContinue.IsEnabled = false;
                RoundCounter++;
            }
            else if (RoundCounter >= 3)
            {
                Bot1Card1.Source = RandomCard;
                Bot1Card2.Source = RandomCard;
                Bot2Card1.Source = RandomCard;
                Bot2Card2.Source = RandomCard;
                Bot3Card1.Source = RandomCard;
                Bot3Card2.Source = RandomCard;

                lbxAnnoucements.Items.Add("Bot1: [Result Here]");
                lbxAnnoucements.Items.Add("Bot2: [Result Here]");
                lbxAnnoucements.Items.Add("Bot3: [Result Here]");
                lbxAnnoucements.Items.Add("User: [Result Here]");
                lbxAnnoucements.Items.Add("[winner]: Wins this round, winning [pot here]");

                RoundCounter = 0;
            }
            else
            {
                DealerCard1.Source = CARDBACK;
                DealerCard2.Source = CARDBACK;
                DealerCard3.Source = CARDBACK;
                DealerCard4.Source = CARDBACK;
                DealerCard5.Source = CARDBACK;
                Bot1Card2.Source = CARDBACK;
                Bot2Card1.Source = CARDBACK;
                Bot1Card1.Source = CARDBACK;
                Bot2Card2.Source = CARDBACK;
                Bot3Card1.Source = CARDBACK;
                Bot3Card2.Source = CARDBACK;
                UserCard1.Source = CARDBACK;
                UserCard2.Source = CARDBACK;

                lbxAnnoucements.Items.Add("Dealer: Game Reset");
            }
            */



        }

        private void actionChecked(object sender, RoutedEventArgs e)
        {
            if(rbRaise.IsChecked == true)
            {
                tbxRaise.IsEnabled = true;
            }
            else
            {
                tbxRaise.IsEnabled = false;
            }
            
            //TODO
            if (RoundCounter != 0)
            {
                ActionChecker();
            }

        }

        private void tbxRaise_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rbRaise.IsChecked == true)
            {
                int Raise;
                if (int.TryParse(tbxRaise.Text, out Raise))
                {
                    btnContinue.IsEnabled = true;
                }
                else
                {
                    btnContinue.IsEnabled = false;
                }
            }
            else
            {
                tbxRaise.IsEnabled = false;
            }
        }

        private void ActionChecker()
        {
            if (rbCall.IsChecked == true)
            {
                btnContinue.IsEnabled = true;
            }
            if (rbFold.IsChecked == true)
            {
                btnContinue.IsEnabled = true;
            }
            if (rbRaise.IsChecked == true)
            {
                tbxRaise.IsEnabled = true;
                btnContinue.IsEnabled = false;
            }
            if (rbCheck.IsChecked == true)
            {
                btnContinue.IsEnabled = true;
            }
        }

        private void btnRanking_Click(object sender, RoutedEventArgs e)
        {
            Rankings ranking = new Rankings();
            ranking.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// Function to disable all actions the user can take
        /// </summary>
        private void DisableActions()
        {
            rbFold.IsEnabled = false;
            rbRaise.IsEnabled = false;
            rbCall.IsEnabled = false;
            rbCheck.IsEnabled = false;
        }

        /// <summary>
        /// Function to enable all actions the user can take
        /// </summary>
        private void EnableActions()
        {
            rbFold.IsEnabled = true;
            rbRaise.IsEnabled = true;
            rbCall.IsEnabled = true;
            rbCheck.IsEnabled = true;
        }


        /// <summary>
        /// Function to generate a random number from 1-3 to decide on the opponents play
        /// </summary>
        private void RandomActionDecider()
        {
            // Create a random number generator
            Random randomselector = new Random();
            int choice;
            // Draw a number from 1 through 3
            choice = randomselector.Next(1, 3);
            // Decide on what the opponent does based on what number was generated above
            if (choice == 1)
            {
                if (isRaise == false)
                {
                    Check();
                }
                else
                {
                    Call();                        
                }
            }
            else if (choice == 2)
            {
                Raise();
            }
            else if (choice == 3)
            {
                Fold();
            }
        }


        /// <summary>
        /// Function that accepts a string and an integer. Checks which player is raising and takes their 
        /// raise value. Does all calculations necessary and adds to the total pot.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="raise"></param>
        public void RaisePot(String player, int raise)
        {
            // Get the current values for each player that they can use to raise with
            int player1Amount = Int32.Parse(tbxUserAmount.Text.ToString());
            int player2Amount = Int32.Parse(tbxBot1Amount.Text.ToString());
            int player3Amount;
            if (int.TryParse(tbxBot2Amount.Text, out player3Amount))
            { }
            else { player3Amount = 0; }
            int player4Amount;
            if (int.TryParse(tbxBot2Amount.Text, out player4Amount))
            { }
            else { player4Amount = 0; }

            // Check which player is raising and ensure they have more than 0 dollars
            if (player == "player1" &&  player1Amount > 0)
            {
                // Subtract the raise amount from their total amount
                player1Amount -= raise;
                // Change the players total amount to the updated amount and incraese the pot
                tbxUserAmount.Text = player1Amount.ToString();
                pot += raise;
                tbxPot.Text = pot.ToString();
                raisedNum = raise;
            }
            else if(player == "player2" && player2Amount > 0)
            {
                player2Amount -= raise;
                tbxBot1Amount.Text = player2Amount.ToString();
                pot += raise;
                tbxPot.Text = pot.ToString();
                raisedNum = raise;
            }
            else if (player == "player3" && player3Amount > 0)
            {
                player3Amount -= raise;
                tbxBot2Amount.Text = player3Amount.ToString();
                pot += raise;
                tbxPot.Text = pot.ToString();
                raisedNum = raise;
            }
            else if(player == "player4" && player4Amount > 0)
            {
                player4Amount -= raise;
                tbxBot3Amount.Text = player4Amount.ToString();
                pot += raise;
                tbxPot.Text = pot.ToString();
                raisedNum = raise;
            }
            else
            {
                MessageBox.Show("An error occured!");
            }
        }

        
    }
}
