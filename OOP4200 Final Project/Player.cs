using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4200_Final_Project
{
    internal class Player
    {
        Deck deck = new Deck();
        #region Constructors
        /// <summary>
        /// Constructor for the Player 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hand"></param>
        /// <param name="startingMoney"></param>
        public Player(List<Card> hand, int startingMoney, int bet)
        {
            playerHand = hand;
            playerAmntMoney = startingMoney;
            playerAmntBet = bet;
        }
        public Player()
        {
            playerHand = deck.DrawCards(2);
            playerAmntMoney = 0;
            playerAmntBet = 0;
        }

        #endregion

        #region Properties
        public List<Card> playerHand { get; set; }
        //Card(s) the player is delt
        public int playerAmntMoney { get; set; }
        // Amount of money that the player has access to for bets
        public int playerAmntBet { get; set; }
        // Amount of money that the player is betting with

        #endregion


    }
}