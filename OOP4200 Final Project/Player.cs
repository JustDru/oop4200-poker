using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4200_Final_Project
{
    internal class Player
    {

        #region Constructors
        /// <summary>
        /// Constructor for the Player 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hand"></param>
        /// <param name="startingMoney"></param>
        public Player(String name, List<Card> hand, int startingMoney)
        {
            playerName = name;
            playerHand = hand;
            playerAmntMoney = startingMoney;
        }

        #endregion

        #region Properties
        public string playerName { get; set; }
        public List<Card> playerHand { get; set; }
        // Amount of money that the player has access to for bets
        public int playerAmntMoney { get; set; }
        // Amount of money that the player is betting with
        public int playerBet { get; set; }


        #endregion


    }
}