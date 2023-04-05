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
        string[] suits = {"♥","♦", "♣", "♠"};

        int[] ranks = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        //11 is Jack, 12 is queen, 13 is King and 14 is Ace

        string selectedsuit = "";
        int selectedrank;

        public Gameplay()
        {
            InitializeComponent();
        }



        public void Start()
        {
            Random rand = new Random();
            selectedsuit = suits[rand.Next(0, suits.Length)];
            selectedrank = ranks[rand.Next(0, ranks.Length)];

            Take2Cards(selectedsuit, selectedrank);
            for (int i = 0; i <= 4; i++)
            {
                Call();
                Thread.Sleep(3000);
            }
            
        }

        public void Raise()
        {
            tbxRaise.IsEnabled = true;
        }

        public void Take2Cards(string suit, int rank)
        {
            Card P1Cards = new Card();
        }

        public void Bet()
        {

        }

        public void Call()
        {
            if (turn == 1)
            {
                rbCall.IsEnabled = false;
                rbFold.IsEnabled = false;
                rbRaise.IsEnabled = false;
                rbCheck.IsEnabled = false;
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
        }

        public void deal3()
        {

        }

        BitmapImage CARDBACK = new BitmapImage(new Uri("CardBack.png", UriKind.Relative));
        BitmapImage RandomCard = new BitmapImage(new Uri("2_of_clubs.png", UriKind.Relative));//placeholder until class logic
        int TurnCounter = 0;
        int RoundCounter = 0;
        private void ReturnMM(object sender, RoutedEventArgs e)
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

            if(turn == 1)
            {
                if(rbCall.IsChecked == true || rbCheck.IsChecked == true || rbRaise.IsChecked == true || rbFold.IsChecked == true)
                {

                }
                else
                {
                    MessageBox.Show("Please select an option");
                }
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
    }
}
