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



        private void Main_Click(object sender, RoutedEventArgs e)
        {
            Setup.Visibility = Visibility.Hidden;

            MainMenu mainMenu = new MainMenu();
            mainMenu.MainMenuView.Visibility = Visibility.Visible;

            mainMenu.lblTitle.Visibility = Visibility.Visible;
            mainMenu.Play.Visibility = Visibility.Visible;
            mainMenu.Help.Visibility = Visibility.Visible;
            mainMenu.Exit.Visibility = Visibility.Visible;

            mainMenu.ContentGrid.Visibility = Visibility.Visible;
            mainMenu.OptionsView.Visibility = Visibility.Visible;

        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (P1Bet.Text == "" || !int.TryParse(P1Bet.Text, out int mybet1) || P2AI.Text == "" || P2Bet.Text == "" || !int.TryParse(P2Bet.Text, out int mybet2) ||P3Bet.Text == "" || !int.TryParse(P3Bet.Text, out int mybet3) || P4Bet.Text == "" || !int.TryParse(P4Bet.Text, out int mybet4))
            {
                ErrorMessages.Clear();
                if(P1Bet.Text == "")
                {
                    ErrorMessages.AppendText("Player 1 needs to make a bet!");
                }
                else if (!int.TryParse(P1Bet.Text, out mybet1))
                {
                    ErrorMessages.AppendText("Bet cannot be a string!");
                }                
                
                if(P2Bet.Text == "")
                {
                    ErrorMessages.AppendText("\nPlayer 2 needs to make a bet!");
                }
                else if (!int.TryParse(P2Bet.Text, out mybet2))
                {
                    ErrorMessages.AppendText("\nBet cannot be a string!");
                }                
                
                if (P2AI.Text == "")
                {
                    ErrorMessages.AppendText("\nSelect a difficulty for Player 2!");
                }
                
                if(P3Bet.Text == "")
                {
                    ErrorMessages.AppendText("\nPlayer 3 needs to make a bet!");
                }
                else if (!int.TryParse(P3Bet.Text, out mybet3))
                {
                    ErrorMessages.AppendText("\nBet cannot be a string!");
                }

                if (P3AI.Text == "")
                {
                    ErrorMessages.AppendText("\nSelect a difficulty for Player 3!");
                }

                if (P4Bet.Text == "")
                {
                    ErrorMessages.AppendText("\nPlayer 4 needs to make a bet!");
                }
                else if (!int.TryParse(P4Bet.Text, out mybet4))
                {
                    ErrorMessages.AppendText("\nBet cannot be a string!");
                }

                if (P4AI.Text == "")
                {
                    ErrorMessages.AppendText("\nSelect a difficulty for Player 4!");
                }
            }
            else
            {
                Gameplay gameplay = new Gameplay();
                gameplay.Visibility = Visibility.Visible;
                
                //pass the starting amount values to the textbox, then call
                gameplay.tbxUserAmount.Text = mybet1.ToString();
                gameplay.tbxBot1Amount.Text = mybet2.ToString();
                gameplay.tbxBot2Amount.Text = mybet3.ToString();
                gameplay.tbxBot3Amount.Text = mybet4.ToString();
                
                
                
                this.Visibility = Visibility.Hidden;

                //call the Call function
                gameplay.Call();

                
                //newgame.Visibility = Visibility.Visible;
                
                
            }
        }

    }
}
