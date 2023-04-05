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


        /// <summary>
        /// Acts as a secondary == operator, takes in two Cards and checks if they share the same suit
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool SameSuit(Card op1, Card op2)
        {
            return (op1.cardSuit == op2.cardSuit);
        }

        /// <summary>
        /// Acts as a secondary != operator, takes in two Cards and checks if they are different suits
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool DifferentSuit(Card op1, Card op2)
        {
            return (op1.cardSuit != op2.cardSuit);
        }


        /// <summary>
        /// Takes in 2 cards and checks if the values of the two cards are equal to eachother
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator ==(Card op1, Card op2)
        {
            return (op1.cardValue == op2.cardValue);
        }


        /// <summary>
        /// Takes in 2 cards and checks if the values of the two cards are not equal to eachother
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator !=(Card op1, Card op2)
        {
            return (op1.cardValue != op2.cardValue);
        }

        /// <summary>
        /// Takes in 2 cards and checks if Card 1 is less than the value of Card 2
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator <(Card op1, Card op2)
        {
            return (op1.cardValue < op2.cardValue);
        }

        /// <summary>
        /// Takes in 2 Cards and checks if Card 1 is greater than the value of Card 2
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator >(Card op1, Card op2)
        {
            return (op1.cardValue > op2.cardValue);
        }

        /// <summary>
        /// Takes in 2 Cards and checks if Card 1 is less than or equal to the value of Card 2
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator <=(Card op1, Card op2)
        {
            return (op1.cardValue <= op2.cardValue);
        }

        /// <summary>
        /// Takes in two Cards and checks if Card 1 is greater than or equal to the value of Card 2
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator >=(Card op1, Card op2)
        {
            return (op1.cardValue >= op2.cardValue);
        }



        /// <summary>
        /// Override the ToString method for the class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return cardValue + " of " + cardSuit;
        }

        #endregion
    }
}
