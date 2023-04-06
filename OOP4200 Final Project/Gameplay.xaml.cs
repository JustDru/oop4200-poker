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
        

        int turn = 1;
        int callamountraise;
        int choice = 0;
        int call;

        bool P1Fold, P2Fold, P3Fold, P4Fold;
        int foldcount;
        Deck deck = new Deck();

        public Gameplay()
        {
            InitializeComponent();
            turn = 1;
        }

        public void Fold()
        {
            tbxAnnouncements.Clear();
            if (turn == 1)
            {
                P1Fold = true;
                tbxAnnouncements.Text = "You folded";
                foldcount++;
            }
            else if (turn == 2)
            {
                P2Fold = true;
                tbxAnnouncements.Text = "Player 2 has folded";
                foldcount++;
            }
            else if (turn == 3)
            {
                P3Fold = true;
                tbxAnnouncements.Text = "Player 3 has folded";
                foldcount++;
            }
            else if (turn == 4)
            {
                P4Fold = true;
                tbxAnnouncements.Text = "Player 4 has folded";
                foldcount++;
            }
            Thread.Sleep(3000);

            if (foldcount == 3 && P1Fold == false)
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
            else if (foldcount == 3 && P2Fold == false)
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
            else if (foldcount == 3 && P3Fold == false)
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
            else if (foldcount == 3 && P4Fold == false)
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
        }

        /// <summary>
        /// Method that runs when the game is started - initalizes all players
        /// </summary>
        public void Start()
        {
            // Create the player object for the human player
            int playerStartAmount = Int32.Parse(tbxUserAmount.Text);
            Player human = new Player("Player", deck.DrawCards(2), playerStartAmount);

            // Bot 1 is enabled by default, create their Player object
            int bot1StartAmount = Int32.Parse(tbxBot1Amount.Text);
            Player bot1 = new Player("bot1", deck.DrawCards(2), bot1StartAmount);

            // If bot 2 is enabled create their Player object
            if(tbxBot2Amount != null)
            {
                int bot2StartAmount = Int32.Parse(tbxBot2Amount.Text);
                Player bot2 = new Player("bot2", deck.DrawCards(2), bot2StartAmount);
            }
            // If bot 3 is enabled create their Player object
            if (tbxBot3Amount != null)
            {
                int bot3StartAmount = Int32.Parse(tbxBot3Amount.Text);
                Player bot3 = new Player("bot3", deck.DrawCards(2), bot3StartAmount);
            }

            turn = 1;
            Continue();


        }

        public void Check()
        {
            tbxAnnouncements.Clear();
            if (turn == 1)
            {
                TurnDisplay.Text = "Turn " + turn;
                tbxAnnouncements.Text = "You checked";
            }
            else
            {
                DisableActions();
                TurnDisplay.Text = "Turn " + turn;
                tbxAnnouncements.Text = "Plaer " + turn + " checked";
            }

            Thread.Sleep(3000);
            Continue();
        }

        public void Continue()
        {
            Random randomselector = new Random();
            int choice;
            if (turn == 1)
            {
                EnableActions();
                if (call == 3)
                {
                    rbCheck.IsEnabled = true;
                    rbCall.IsEnabled = false;
                }
                else
                {
                    rbCall.IsEnabled = true;
                    rbCheck.IsEnabled = false;
                }
                btnContinue.IsEnabled = true;


            }
            else if (turn == 2)
            {
                DisableActions();
                choice = randomselector.Next(1, 3);
                if (turn == 2 && P2Fold == true)
                {
                    turn++;
                }
                else
                {
                    if (choice == 1)
                    {

                        if (call == 3)
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

            }
            else if (turn == 3)
            {
                DisableActions();
                choice = randomselector.Next(1, 3);
                if (turn == 3 && P3Fold == true)
                {
                    turn++;
                }
                else
                {
                    if (choice == 1)
                    {
                        if (call == 3)
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

            }
            else if (turn == 4)
            {
                DisableActions();
                choice = randomselector.Next(1, 3);
                if (turn == 4 && P4Fold == true)
                {
                    turn = 1;
                }
                else
                {
                    if (choice == 1)
                    {
                        if (call == 3)
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

            }
        }

        public void Raise()
        {
            tbxAnnouncements.Clear();
            if (turn == 1)
            {
                tbxRaise.IsEnabled = false;
                if (int.TryParse(tbxUserAmount.Text, out int bet))
                {
                    //now converted to int
                    if(int.TryParse(tbxRaise.Text, out int myraise))
                    {
                        bet = bet - myraise;
                        if (int.TryParse(tbxPot.Text, out int pot))
                        {
                            pot += myraise;
                            tbxPot.Text = pot.ToString();
                        }
                    }

                    tbxUserAmount.Text = bet.ToString();
                    tbxAnnouncements.Text = "You raise $" + myraise;
                }
                turn++;
                TurnDisplay.Text = "Turn " + turn;
            }
            else if (turn == 2)
            {
                Random rand = new Random();
                if (int.TryParse(tbxBot1Amount.Text, out int bet))
                {
                    int P2Bet = rand.Next(1, 200);
                    bet = bet - P2Bet;
                    if (int.TryParse(tbxPot.Text, out int pot))
                    {
                        pot += P2Bet;
                        tbxPot.Text = pot.ToString();
                    }
                    tbxBot1Amount.Text = bet.ToString();
                    tbxAnnouncements.Text = "Player 2 has raised $" + P2Bet;
                }
                turn++;
                TurnDisplay.Text = "Turn " + turn;
            }
            else if (turn == 3)
            {
                Random rand = new Random();
                if (int.TryParse(tbxBot2Amount.Text, out int bet1))
                {
                    int P3Bet = rand.Next(1, 200);
                    bet1 = bet1 - P3Bet;
                    if (int.TryParse(tbxPot.Text, out int pot))
                    {
                        pot += P3Bet;
                        tbxPot.Text = pot.ToString();
                    }
                    tbxBot1Amount.Text = bet1.ToString();
                    tbxAnnouncements.Text = "Player 3 has raised $" + P3Bet;
                }
                turn++;
                TurnDisplay.Text = "Turn " + turn;
            }
            else if (turn == 4)
            {
                Random rand = new Random();
                if (int.TryParse(tbxBot3Amount.Text, out int bet2))
                {
                    int P4Bet = rand.Next(1, 200);
                    bet2 = bet2 - P4Bet;
                    if (int.TryParse(tbxPot.Text, out int pot))
                    {
                        pot += P4Bet;
                        tbxPot.Text = pot.ToString();
                    }
                    tbxBot1Amount.Text = bet2.ToString();
                    tbxAnnouncements.Text = "Player 4 has raised $" + P4Bet;
                }
                turn = 1;
                TurnDisplay.Text = "Turn " + turn;
            }
            call = 1;
            Thread.Sleep(1000);
            Continue();
        }


        public void Bet()
        {

        }

        public void Call()
        {
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
            }
            Continue();
        }


        BitmapImage CARDBACK = new BitmapImage(new Uri("CardBack.png", UriKind.Relative));
        BitmapImage RandomCard = new BitmapImage(new Uri("2_of_clubs.png", UriKind.Relative));//placeholder until class logic
        int TurnCounter = 0;
        int RoundCounter = 0;
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            //TODO redirect to main menu
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
                DisableActions();
                btnContinue.IsEnabled = false;
                Continue();
            }
            else
            {
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



    }
}
