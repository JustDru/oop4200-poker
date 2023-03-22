using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4200_Final_Project
{
    internal class Card
    {
        // Enumerators
        // Give values to each card suit
        public enum Suit
        {
            Club = 1,
            Diamond = 2,
            Heart = 3,
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


        // Properties
        public Suit cardSuit { get; set; }
        public Value cardValue { get; set; }


        /// <summary>
        /// Checks if two cards passed in are equal to eachother
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
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
        



    }
}
