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
using System.Windows.Shapes;

namespace OOP4200_Final_Project
{
    /// <summary>
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : Window
    {
        public Gameplay()
        {
            InitializeComponent();
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
    }
}
