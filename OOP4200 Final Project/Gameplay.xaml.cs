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
        BitmapImage CARDBACK = new BitmapImage(new Uri("/Images/CardBack.png", UriKind.Relative));
        BitmapImage RandomCard = new BitmapImage(new Uri("/Images/2_of_clubs.png", UriKind.Relative));//placeholder until class logic
        BitmapImage displayCard = new BitmapImage();
        //these public variables get values in setupgame.xaml.cs
        public int numPlayers;
        int turnsPerRound;
        public int player1StartAmount, player2StartAmount, player3StartAmount, player4StartAmount;

        int turnCounter = 0;
        int roundCounter = 0;
        int raised;
        int highBet = 10;
        //if player has folded, bool = true
        bool p1Fold, p2Fold, p3Fold, p4Fold;
        bool hasRaised = false;
        bool starting = true;
        Deck deck = new Deck();
        Player player1 = new Player();
        Player player2 = new Player();
        Player player3 = new Player();
        Player player4 = new Player();
        Player dealer = new Player();

        /// <summary>
        /// Initializes game and gives images proper values
        /// </summary>
        public Gameplay()
        {
            InitializeComponent();
            DealerCard1.Source = CARDBACK;
            DealerCard2.Source = CARDBACK;
            DealerCard3.Source = CARDBACK;
            DealerCard4.Source = CARDBACK;
            DealerCard5.Source = CARDBACK;
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            //moves on with the round

            //When bot logic finishes, turn counter will go up by 1
            //unless there was a raise, which will reset the turn counter
            //once turn counter hits 4, the dealer revieals the next cards
            //after all rounds, all cards are displayed and the winner
            //gets the pot, and will be stated who won in the announcements

            lbxAnnoucements.Items.Clear();
            if (DealerCard1.Source == CARDBACK)
            {
                Start();
                //First deal. will give everyone their cards
            }
            else if (roundCounter == 1)
            {
                Action();
                //check to see if the bots can go or not due to turn order
                if (turnCounter < turnsPerRound)
                    RandomActionPlayer2();
                if (turnCounter < turnsPerRound)
                    if (stpBot2Panel.IsVisible) {RandomActionPlayer3();}
                if (turnCounter < turnsPerRound)
                    if (stpBot3Panel.IsVisible) { RandomActionPlayer4();}

                //Checks if user is allowed to check or call (cannot do either at 1 time)
                if (hasRaised){rbCall.IsEnabled = true; rbCheck.IsEnabled = false;}
                else {rbCall.IsEnabled = false; rbCheck.IsEnabled = true;}                

                btnContinue.IsEnabled = false;
                //if all turns are counter, round counter goes up and the game continues
                if (turnCounter >= turnsPerRound){
                    roundCounter++;
                    turnCounter = 0;
                    DealerCard4.Source = Card.CardImage(dealer.playerHand[3]);
                    lbxAnnoucements.Items.Add("Dealer: Card 4 revealed");
                }

            }
            else if (roundCounter == 2)
            {
                Action();
                //check to see if the bots can go or not due to turn order
                if (turnCounter < turnsPerRound)
                    RandomActionPlayer2();
                if (turnCounter < turnsPerRound)
                    if (stpBot2Panel.IsVisible) { RandomActionPlayer3(); }
                if (turnCounter < turnsPerRound)
                    if (stpBot3Panel.IsVisible) { RandomActionPlayer4(); }

                //Checks if user is allowed to check or call (cannot do either at 1 time)
                if (hasRaised) { rbCall.IsEnabled = true; rbCheck.IsEnabled = false; }
                else { rbCall.IsEnabled = false; rbCheck.IsEnabled = true; }

                btnContinue.IsEnabled = false;
                if (turnCounter >= turnsPerRound)
                {
                    roundCounter++;
                    turnCounter = 0;
                    DealerCard5.Source = Card.CardImage(dealer.playerHand[4]);
                    lbxAnnoucements.Items.Add("Dealer: Card 5 revealed");
                }
            }
            else if (roundCounter >= 3)
            {
                Action();
                //check to see if the bots can go or not due to turn order
                if (turnCounter < turnsPerRound)
                    RandomActionPlayer2();
                if (turnCounter < turnsPerRound)
                    if (stpBot2Panel.IsVisible) { RandomActionPlayer3(); }
                if (turnCounter < turnsPerRound)
                    if (stpBot3Panel.IsVisible) { RandomActionPlayer4(); }

                //Checks if user is allowed to check or call (cannot do either at 1 time)
                if (hasRaised) { rbCall.IsEnabled = true; rbCheck.IsEnabled = false; }
                else { rbCall.IsEnabled = false; rbCheck.IsEnabled = true; }

                btnContinue.IsEnabled = false;
                if (turnCounter >= turnsPerRound)
                {
                    CheckWinner();
                    /*
                    Bot1Card1.Source = Card.CardImage(player2.playerHand[0]);
                    Bot1Card2.Source = Card.CardImage(player2.playerHand[1]);
                    Bot2Card1.Source = Card.CardImage(player3.playerHand[0]);
                    Bot2Card2.Source = Card.CardImage(player3.playerHand[1]);
                    Bot3Card1.Source = Card.CardImage(player4.playerHand[0]);
                    Bot3Card2.Source = Card.CardImage(player4.playerHand[1]);

                    lbxAnnoucements.Items.Add("Bot1: [Result Here]");
                    lbxAnnoucements.Items.Add("Bot2: [Result Here]");
                    lbxAnnoucements.Items.Add("Bot3: [Result Here]");
                    lbxAnnoucements.Items.Add("User: [Result Here]");
                    lbxAnnoucements.Items.Add("[winner]: Wins this round, winning " + tbxPot.Text);

                    rbCheck.IsEnabled = false;
                    rbFold.IsEnabled = false;
                    rbRaise.IsEnabled = false;
                    rbCall.IsEnabled = false;
                    btnContinue.IsEnabled = true;

                    roundCounter = 0;
                    turnCounter = 0;
                    */
                }
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

                highBet = 10;
                raised = 0;

                lbxAnnoucements.Items.Add("Dealer: Game Reset");
            }

            if (p1Fold)
            {
                Fold();
            }

            tbxRaise.IsEnabled = false;
            rbCall.IsChecked = false;
            rbFold.IsChecked = false;
            rbRaise.IsChecked = false;
            rbCheck.IsChecked = false;
            tbxRaise.Clear();

            tbxUserBet.Text = player1.playerAmntBet.ToString();
            tbxBot1Bet.Text = player2.playerAmntBet.ToString();
            tbxBot2Bet.Text = player3.playerAmntBet.ToString();
            tbxBot3Bet.Text = player4.playerAmntBet.ToString();

            tbxUserAmount.Text = player1.playerAmntMoney.ToString();
            tbxBot1Amount.Text = player2.playerAmntMoney.ToString();
            tbxBot2Amount.Text = player3.playerAmntMoney.ToString();
            tbxBot3Amount.Text = player4.playerAmntMoney.ToString();

            dealer.playerAmntBet = player1.playerAmntBet + player2.playerAmntBet + player3.playerAmntBet + player4.playerAmntBet;
            tbxPot.Text = dealer.playerAmntBet.ToString();

        }

        /// <summary>
        /// Will pull up the rankings info screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRanking_Click(object sender, RoutedEventArgs e)
        {
            Rankings ranking = new Rankings();
            ranking.Visibility = Visibility.Visible;
        }

        #region Radio Button Logic
        private void actionChecked(object sender, RoutedEventArgs e)
        {
            //Only works if gameplay is active
            tbxRaise.Clear();
            if (roundCounter != 0)
            {
                ActionChecker();
            }
        }

        /// <summary>
        /// Simple validation to keep raise number only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxRaise_TextChanged(object sender, TextChangedEventArgs e)
        {            
            //validates for int and the high bet
            if (int.TryParse(tbxRaise.Text, out raised))
            {
                if (raised < 10)
                    btnContinue.IsEnabled = false;                
                else if (raised < (highBet - player1.playerAmntBet))
                    btnContinue.IsEnabled = false;
                else
                    btnContinue.IsEnabled = true;                               
            }
            else if (tbxRaise.Text == "")
                btnContinue.IsEnabled = false;            
            else
            {
                tbxRaise.Clear();
                MessageBox.Show("ERROR - Raise has to be numerical");
                btnContinue.IsEnabled = false;
            }

        }
        
        /// <summary>
        /// checks to see what actions are currently available
        /// </summary>
        private void ActionChecker()
        {
            tbxRaise.IsEnabled = false;
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
        #endregion

        /// <summary>
        /// Method that runs when the game starts/resets
        /// initalized values for players and the dealer, then displays card
        /// </summary>
        public void Start()
        {
            deck.Reset();
            deck.Shuffle();
            // Create the player object for the human player
            player1.playerHand = deck.DrawCards(2);
            player1.playerAmntBet = 0;

            // Bot 1 is enabled by default, create their Player object
            player2.playerHand = deck.DrawCards(2);
            player2.playerAmntBet = 0;            

            // If bot 2 is enabled create their Player object
            if (stpBot2Panel.IsVisible)
            {
                player3.playerHand = deck.DrawCards(2);
                player3.playerAmntBet = 0;
                if (starting) {player3.playerAmntMoney = player3StartAmount;}
            }
            // If bot 3 is enabled create their Player object
            if (stpBot3Panel.IsVisible)
            {
                player4.playerHand = deck.DrawCards(2);                
                player4.playerAmntBet = 0;
                if (starting) {player4.playerAmntMoney = player4StartAmount;}
            }

            //if the game is starting for the first time, give starting money
            if (starting)
            {
                player1.playerAmntMoney = player1StartAmount;
                player2.playerAmntMoney = player2StartAmount;
                starting = false;
            }

            //reset turn per round and folded players
            turnsPerRound = numPlayers;
            p1Fold = false;
            p2Fold = false;
            p3Fold = false;
            p4Fold = false;

            // Give the dealer their five cards
            dealer.playerHand = deck.DrawCards(5);

            //displays cards
            DealerCard1.Source = Card.CardImage(dealer.playerHand[0]);
            DealerCard2.Source = Card.CardImage(dealer.playerHand[1]);
            DealerCard3.Source = Card.CardImage(dealer.playerHand[2]);

            UserCard1.Source = Card.CardImage(player1.playerHand[0]);
            UserCard2.Source = Card.CardImage(player1.playerHand[1]);

            lbxAnnoucements.Items.Clear();
            lbxAnnoucements.Items.Add("Dealer: Cards Delt");

            btnContinue.IsEnabled = false;
            roundCounter++;

            rbRaise.IsEnabled = true;
            rbFold.IsEnabled = true;
            rbCheck.IsEnabled = true;


        }

        #region User & Bot actions and logic

        /// <summary>
        /// Action logic for the user
        /// </summary>
        public void Action()
        {
            String message;
            //Call raise function
            if (rbRaise.IsChecked == true)
            {
                turnCounter = 1;
                hasRaised = true;
                message = Raise(player1, raised);
                if (raised > highBet) { highBet = raised; }
                lbxAnnoucements.Items.Add("User: " + message);
            }
            //call checked function
            else if (rbCheck.IsChecked == true)
            {
                turnCounter++;
                Check(player1);
                lbxAnnoucements.Items.Add("User: Checked");
            }
            //call raise function, only raise whats needed
            else if (rbCall.IsChecked == true)
            {
                turnCounter++;
                message = Raise(player1, highBet - player1.playerAmntBet);
                if (turnCounter >= turnsPerRound)
                {
                    hasRaised = false;
                }
                lbxAnnoucements.Items.Add("User: Called: " + message);
            }
            //quit the game for the rest of the round
            else if (rbFold.IsChecked == true)
            {
                p1Fold = true;
                lbxAnnoucements.Items.Add("User: Folded");
            }

        }

        /// <summary>
        /// Random action decider for Player 2 (Bot 1)
        /// </summary>
        public void RandomActionPlayer2()
        {
            String message;
            // Create a random number generator
            Random randomselector = new Random();
            int choice;
            int botRaise;
            // Draw a number from 1 through 3
            choice = randomselector.Next(1, 4);
            // Decide on what the opponent does based on what number was generated above
            // only let bot play if they havent folded
            if (!p2Fold)
            {
                if (choice == 1)
                {
                    //calls
                    if (hasRaised)
                    {
                        turnCounter++;
                        message = Raise(player2, highBet - player2.playerAmntBet);
                        if (turnCounter >= turnsPerRound)
                        {
                            hasRaised = false;
                        }
                        lbxAnnoucements.Items.Add("Bot 1: Called: " + message);
                    }
                    //checked
                    else
                    {
                        turnCounter++;
                        Check(player2);
                        lbxAnnoucements.Items.Add("Bot 1: Checked");
                    }
                }
                //raise
                else if (choice == 2)
                {
                    //if a raise has happened, bot is not allowed to bet less than the raise
                    //TODO better bot validation for bets
                    if (hasRaised)
                    {
                        turnCounter = 1;
                        hasRaised = true;
                        botRaise = randomselector.Next(highBet, highBet + 200);
                        message = Raise(player2, botRaise);
                        if (player2.playerAmntBet > highBet) { highBet = player2.playerAmntBet; }
                        lbxAnnoucements.Items.Add("Bot 1: " + message);
                    }
                    else
                    {
                        turnCounter = 1;
                        hasRaised = true;
                        botRaise = randomselector.Next(20, 300);
                        message = Raise(player2, botRaise);
                        if (player2.playerAmntBet > highBet) { highBet = player2.playerAmntBet; }
                        lbxAnnoucements.Items.Add("Bot 1: " + message);
                    }
                }
                //fold
                else if (choice == 3)
                {
                    turnCounter++;
                    if (turnCounter >= turnsPerRound)
                    {
                        hasRaised = false;
                    }
                    p2Fold = true;
                    lbxAnnoucements.Items.Add("Bot 1: Folded");
                }
            }
            else
            {
                turnCounter++;
                if (turnCounter >= turnsPerRound)
                {
                    hasRaised = false;
                }
                lbxAnnoucements.Items.Add("Bot 1: Folded");
            }
        }

        /// <summary>
        /// Random action decider for Player 3 (Bot 2)
        /// </summary>
        public void RandomActionPlayer3()
        {            
            String message;
            // Create a random number generator
            Random randomselector = new Random();
            int choice;
            int botRaise;
            // Draw a number from 1 through 3
            choice = randomselector.Next(1, 4);
            // Decide on what the opponent does based on what number was generated above
            // only let bot play if they havent folded
            if (!p3Fold)
            {
                if (choice == 1)
                {
                    if (hasRaised)
                    {
                        turnCounter++;
                        message = Raise(player3, highBet - player3.playerAmntBet);
                        if (turnCounter >= turnsPerRound)
                        {
                            hasRaised = false;
                        }
                        lbxAnnoucements.Items.Add("Bot 2: Called: " + message);
                    }
                    else
                    {
                        turnCounter++;
                        Check(player3);
                        lbxAnnoucements.Items.Add("Bot 2: Checked");
                    }
                }
                else if (choice == 2)
                {
                    if (hasRaised)
                    {
                        turnCounter = 1;
                        hasRaised = true;
                        botRaise = randomselector.Next(highBet, highBet + 200);
                        message = Raise(player3, botRaise);
                        if (player3.playerAmntBet > highBet) { highBet = player3.playerAmntBet; }
                        lbxAnnoucements.Items.Add("Bot 2: " + message);
                    }
                    else
                    {
                        turnCounter = 1;
                        hasRaised = true;
                        botRaise = randomselector.Next(20, 300);
                        message = Raise(player3, botRaise);
                        if (player3.playerAmntBet > highBet) { highBet = player3.playerAmntBet; }
                        lbxAnnoucements.Items.Add("Bot 2: " + message);
                    }
                }
                else if (choice == 3)
                {
                    turnCounter++;
                    if (turnCounter >= turnsPerRound)
                    {
                        hasRaised = false;
                    }
                    p3Fold = true;
                    lbxAnnoucements.Items.Add("Bot 2: Folded");
                }
            }
            else
            {
                turnCounter++;
                if (turnCounter >= turnsPerRound)
                {
                    hasRaised = false;
                }
                lbxAnnoucements.Items.Add("Bot 2: Folded");
            }
        }

        /// <summary>
        /// Random action decider for Player 4 (Bot 3)
        /// </summary>
        public void RandomActionPlayer4()
        {
            String message;
            // Create a random number generator
            Random randomselector = new Random();
            int choice;
            int botRaise;            
            // Draw a number from 1 through 3
            choice = randomselector.Next(1, 4);
            // Decide on what the opponent does based on what number was generated above
            //only let bot play if they havent folded
            if (!p4Fold)
            {
                if (choice == 1)
                {
                    if (hasRaised)
                    {
                        turnCounter++;
                        message = Raise(player4, highBet - player4.playerAmntBet);
                        if (turnCounter >= turnsPerRound)
                        {
                            hasRaised = false;
                        }
                        lbxAnnoucements.Items.Add("Bot 3: Called: " + message);
                    }
                    else
                    {
                        turnCounter++;
                        Check(player4);
                        lbxAnnoucements.Items.Add("Bot 3: Checked");
                    }
                }
                else if (choice == 2)
                {
                    if (hasRaised)
                    {
                        turnCounter = 1;
                        hasRaised = true;
                        botRaise = randomselector.Next(highBet, highBet + 200);
                        message = Raise(player4, botRaise);
                        if (player4.playerAmntBet > highBet) { highBet = player4.playerAmntBet; }
                        lbxAnnoucements.Items.Add("Bot 3: " + message);
                    }
                    else
                    {
                        turnCounter = 1;
                        hasRaised = true;
                        botRaise = randomselector.Next(20, 300);
                        message = Raise(player4, botRaise);
                        if (player4.playerAmntBet > highBet) { highBet = player4.playerAmntBet; }
                        lbxAnnoucements.Items.Add("Bot 3: " + message);
                    }
                }
                else if (choice == 3)
                {
                    turnCounter++;
                    if (turnCounter >= turnsPerRound)
                    {
                        hasRaised = false;
                    }
                    p4Fold = true;
                    lbxAnnoucements.Items.Add("Bot 3: Folded");
                }
            }
            else
            {
                turnCounter++;
                if (turnCounter >= turnsPerRound)
                {
                    hasRaised = false;
                }
                lbxAnnoucements.Items.Add("Bot 3: Folded");
            }
        }


        /// <summary>
        /// Raises the pot and takes the money out of what the player has (if they have the money to bet)
        /// </summary>
        /// <param name="player"></param>
        /// <param name="raised"></param>
        /// <returns></returns>
        private String Raise(Player player, int raised)
        {
            String message = "";
            if (player.playerAmntMoney < raised)
            {
                raised = player.playerAmntMoney;
                player.playerAmntMoney = 0;
                message = "All In!";
            } 
            else 
            {
                player.playerAmntMoney -= raised;
                message = "Bet $" + raised.ToString();
            }
            player.playerAmntBet += raised;
            
            return message;
        }

        /// <summary>
        /// checks if a bet has been made. if not, makes a $10 bet
        /// </summary>
        /// <param name="player"></param>
        private void Check(Player player)
        {
            if (player.playerAmntBet == 0)
            {
                Raise(player, 10);
            }
        }

        /// <summary>
        /// Logic for when the user folds, allowing the bots to finish the game instantly
        /// </summary>
        public void Fold()
        {
            //takes user out of turn order and loops bots turns
            turnsPerRound--;
            while (roundCounter != 3)
            {
                // Chooses random actions for each bot
                if (turnCounter < turnsPerRound)
                    RandomActionPlayer2();
                if (turnCounter < turnsPerRound)
                    if (stpBot2Panel.IsVisible) { RandomActionPlayer3(); }
                if (turnCounter < turnsPerRound)
                    if (stpBot3Panel.IsVisible) { RandomActionPlayer4(); }

                if (turnCounter >= turnsPerRound)
                {
                    roundCounter++;
                    turnCounter = 0;
                    // Calculate the pot value 
                    dealer.playerAmntBet = player1.playerAmntBet + player2.playerAmntBet + player3.playerAmntBet + player4.playerAmntBet;
                    tbxPot.Text = dealer.playerAmntBet.ToString();
                }
            }
            CheckWinner();
            
        }
        /// <summary>
        /// Logic for the end of the round to check who has the best hand
        /// </summary>
        public void CheckWinner()
        {
            // Create the default rankings for each player.
            CardRankings player1Ranking = new CardRankings();
            CardRankings player2Ranking = new CardRankings();
            CardRankings player3Ranking = new CardRankings();
            CardRankings player4Ranking = new CardRankings();



            // Creates the rankings for each player using the CardRankings parameterized constructor,
            // which takes in the player hand and the dealer hand. 
            if (!p1Fold)
            {
                player1Ranking = new CardRankings(player1.playerHand, dealer.playerHand);
            }
                
            if (!p2Fold)
            {
                player2Ranking = new CardRankings(player2.playerHand, dealer.playerHand);
            }
                

            // Adds the other 2 bots if they are enabled.
            if (stpBot2Panel.IsVisible)
            {
                if (!p3Fold)
                {
                    player3Ranking = new CardRankings(player3.playerHand, dealer.playerHand);
                }
                
            }
            if (stpBot3Panel.IsVisible)
            {
                if (!p4Fold)
                {
                    player4Ranking = new CardRankings(player4.playerHand, dealer.playerHand);
                }
                
                
            }

            // Variables used to show winner and determine winner.
            // Default winner is the User, it will be overwritten if the other players have better hands 
            // than the player. 
            int winnerValue = (int)player1Ranking.cardRank;
            CardRankings winnerHandValue = player1Ranking;
            string winnerHand = player1Ranking.cardRank.ToString();
            string winner = "User";

            // Checks if the 1st bot has a cardRank higher than the players. Each ranking has an integer value 
            // assigned to it, Royal flush is 10, high cards is 1. 
            if ((int)player2Ranking.cardRank >= winnerValue)
            {
                // Checks if the second bot's hand value is greater than the players. 
                // This is used to determine the winner if there was a tie, ex. both players have a two pair. 
                if ((((player2Ranking.GetPlayerHandValue() > winnerHandValue.GetPlayerHandValue()) && ((int)player2Ranking.cardRank == winnerValue))) || (int)player2Ranking.cardRank > winnerValue)
                {
                    // Sets the winner variables to bot 1's values. 
                    winnerValue = (int)player2Ranking.cardRank;
                    winnerHand = player2Ranking.cardRank.ToString();
                    winner = "Bot 1";
                }

            }
            if (stpBot2Panel.IsVisible)
            {
                if ((int)player3Ranking.cardRank >= winnerValue)
                {
                    if ((((player3Ranking.GetPlayerHandValue() > winnerHandValue.GetPlayerHandValue()) && ((int)player3Ranking.cardRank == winnerValue))) || (int)player3Ranking.cardRank > winnerValue)
                    {
                        winnerValue = (int)player3Ranking.cardRank;
                        winnerHand = player3Ranking.cardRank.ToString();
                        winner = "Bot 2";
                    }
                }
            }
            if (stpBot3Panel.IsVisible)
            {
                if ((int)player4Ranking.cardRank >= winnerValue)
                {
                    if ((((player4Ranking.GetPlayerHandValue() > winnerHandValue.GetPlayerHandValue()) && ((int)player4Ranking.cardRank == winnerValue))) || (int)player4Ranking.cardRank > winnerValue)
                    {
                        winnerValue = (int)player4Ranking.cardRank;
                        winnerHand = player4Ranking.cardRank.ToString();
                        winner = "Bot 3";
                    }
                }
            }



            // display all cards and results, reset variables so new game can start
            DealerCard4.Source = Card.CardImage(dealer.playerHand[3]);
            DealerCard5.Source = Card.CardImage(dealer.playerHand[4]);
            Bot1Card1.Source = Card.CardImage(player2.playerHand[0]);
            Bot1Card2.Source = Card.CardImage(player2.playerHand[1]);
            Bot2Card1.Source = Card.CardImage(player3.playerHand[0]);
            Bot2Card2.Source = Card.CardImage(player3.playerHand[1]);
            Bot3Card1.Source = Card.CardImage(player4.playerHand[0]);
            Bot3Card2.Source = Card.CardImage(player4.playerHand[1]);

            lbxAnnoucements.Items.Add("Hand Values: " + player1Ranking.GetPlayerHandValue() + " " + player2Ranking.GetPlayerHandValue() + " " + player3Ranking.GetPlayerHandValue() + " " + player4Ranking.GetPlayerHandValue());
            lbxAnnoucements.Items.Add("Bot1: " + player2Ranking.cardRank);
            lbxAnnoucements.Items.Add("Bot2: " + player3Ranking.cardRank);
            lbxAnnoucements.Items.Add("Bot3: " + player4Ranking.cardRank);
            lbxAnnoucements.Items.Add("User: " + player1Ranking.cardRank);
            lbxAnnoucements.Items.Add(winner + ": Wins this round, winning " + dealer.playerAmntBet);
            // Pay the winner
            PayoutPot(winner, dealer.playerAmntBet);

            rbCheck.IsEnabled = false;
            rbFold.IsEnabled = false;
            rbRaise.IsEnabled = false;
            rbCall.IsEnabled = false;
            btnContinue.IsEnabled = true;

            roundCounter = 0;
            turnCounter = 0;
            p1Fold = false;
        }

        /// <summary>
        /// Function to pay the winner of the round with the amount of money in the pot
        /// </summary>
        /// <param name="winner"></param>
        /// <param name="potAmnt"></param>
        public void PayoutPot(String winner, int potAmnt)
        {
            // Check who won the round
            if (winner == "User")
            {
                // Add the current pot amount to the winners money amount variable
                player1.playerAmntMoney += potAmnt;
                // Display the winners new amount of money
                tbxUserAmount.Text = player1.playerAmntMoney.ToString();
            }
            if (winner == "Bot 2")
            {
                player2.playerAmntMoney += potAmnt;
                tbxBot1Amount.Text = player2.playerAmntMoney.ToString();
            }
            if (winner == "Bot 3")
            {
                player3.playerAmntMoney += potAmnt;
                tbxBot2Amount.Text = player3.playerAmntMoney.ToString();
            }
            if (winner == "Bot 4")
            {
                player4.playerAmntMoney += potAmnt;
                tbxBot3Amount.Text = player4.playerAmntMoney.ToString();
            }
        }


        #endregion

    }
}
