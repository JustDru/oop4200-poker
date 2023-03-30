using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4200_Final_Project
{

    public class Card
    {
        #region Enumerators
        // Give values to each card suit
        public enum Suit
        {
            Clubs = 1,
            Diamonds = 2,
            Hearts = 3,
            Spades = 4
        }

        // Gives values to each face card 
        public enum Value
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }
        #endregion
        public static class Enums
        {
            public enum Suit
            {
                Heart = 1,
                Diamond = 2,
                Club = 3,
                Spade = 4
            }
            
            public enum Rank
            {
                Two = 2,
                Three = 3,
                Four = 4,
                Five = 5,
                Six = 6,
                Seven = 7,
                Eight = 8,
                Nine = 9,
                Ten = 10,
                Jack = 11,
                Queen = 12,
                King = 13,
                Ace = 14
            }
        }

        #region Properties
        public Suit cardSuit { get; set; }
        public Value cardValue { get; set; }
        #endregion


        #region Method

        /// <summary>
        /// Checks if two cards passed in are equal to eachother
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        /// 

        public List<Card> cards { get; set; }

        public Card()
        {
            
        }

        public static bool operator ==(Card op1, Card op2)
        {
            return (op1.cardSuit == op2.cardSuit && op1.cardValue == op2.cardValue);
        }

        /// <summary>
        /// Checks if two cards passed in are not equal to eachother
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator !=(Card op1, Card op2)
        {
            return (op1.cardSuit != op2.cardSuit || op1.cardValue != op2.cardValue);
        }

        public override string ToString()
        {
            return cardValue + " of " + cardSuit;
        }

        #endregion
    }
}
