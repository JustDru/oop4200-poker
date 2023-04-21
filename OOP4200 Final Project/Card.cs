using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
            Ace = 1
        }
        #endregion
        // Second set of Enumerators
        public static class Enums
        {
            public enum Suit
            {
                Clubs = 1,
                Diamonds = 2,
                Hearts = 3,
                Spades = 4
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
                Ace = 1
            }
        }

        #region Properties
        // Accessors and Mutators for the cardSuit and cardValue
        public Suit cardSuit { get; set; }
        public Value cardValue { get; set; }
        #endregion


        #region Method


        public List<Card> cards { get; set; }

        /// <summary>
        /// Default constructor for the Card class
        /// </summary>
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
        //

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
        /// Takes a card and returns the refernce to the image of the card in a string
        /// </summary>
        /// <param name="aCard"></param>
        /// <returns></returns>
        public static BitmapImage CardImage(Card aCard)
        {
            string cardPicRef = "";
            
            // Assign the images for all 2 cards
            if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Two)
            { cardPicRef = "/Images/2_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Two)
            { cardPicRef = "/Images/2_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Two)
            { cardPicRef = "/Images/2_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Two)
            { cardPicRef = "/Images/2_of_spades.png"; }
            // Assign the images for all 3 cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Three)
            { cardPicRef = "/Images/3_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Three)
            { cardPicRef = "/Images/3_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Three)
            { cardPicRef = "/Images/3_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Three)
            { cardPicRef = "/Images/3_of_spades.png"; }
            // Assign the images for all 4 cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Four)
            { cardPicRef = "/Images/4_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Four)
            { cardPicRef = "/Images/4_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Four)
            { cardPicRef = "/Images/4_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Four)
            { cardPicRef = "/Images/4_of_spades.png"; }
            // Assign the images for all 5 cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Five)
            { cardPicRef = "/Images/5_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Five)
            { cardPicRef = "/Images/5_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Five)
            { cardPicRef = "/Images/5_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Five)
            { cardPicRef = "/Images/5_of_spades.png"; }
            // Assign the images for all 6 cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Six)
            { cardPicRef = "/Images/6_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Six)
            { cardPicRef = "/Images/6_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Six)
            { cardPicRef = "/Images/6_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Six)
            { cardPicRef = "/Images/6_of_spades.png"; }
            // Assign the images for all 7 cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Seven)
            { cardPicRef = "/Images/7_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Seven)
            { cardPicRef = "/Images/7_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Seven)
            { cardPicRef = "/Images/7_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Seven)
            { cardPicRef = "/Images/7_of_spades.png"; }
            // Assign the images for all 8 cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Eight)
            { cardPicRef = "/Images/8_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Eight)
            { cardPicRef = "/Images/8_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Eight)
            { cardPicRef = "/Images/8_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Eight)
            { cardPicRef = "/Images/8_of_spades.png"; }
            // Assign the images for all 9 cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Nine)
            { cardPicRef = "/Images/9_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Nine)
            { cardPicRef = "/Images/9_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Nine)
            { cardPicRef = "/Images/9_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Nine)
            { cardPicRef = "/Images/9_of_spades.png"; }
            // Assign the images for all 10 cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Ten)
            { cardPicRef = "/Images/10_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Ten)
            { cardPicRef = "/Images/10_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Ten)
            { cardPicRef = "/Images/10_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Ten)
            { cardPicRef = "/Images/10_of_spades.png"; }
            // Assign the images for all Jack cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Jack)
            { cardPicRef = "/Images/jack_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Jack)
            { cardPicRef = "/Images/jack_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Jack)
            { cardPicRef = "/Images/jack_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Jack)
            { cardPicRef = "/Images/jack_of_spades.png"; }
            // Assign the images for all Queen cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Queen)
            { cardPicRef = "/Images/queen_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Queen)
            { cardPicRef = "/Images/queen_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Queen)
            { cardPicRef = "/Images/queen_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Queen)
            { cardPicRef = "/Images/queen_of_spades.png"; }
            // Assign the images for all King cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.King)
            { cardPicRef = "/Images/king_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.King)
            { cardPicRef = "/Images/king_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.King)
            { cardPicRef = "/Images/king_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.King)
            { cardPicRef = "/Images/king_of_spades.png"; }
            // Assign the images for all Ace cards
            else if (aCard.cardSuit == Suit.Clubs && aCard.cardValue == Value.Ace)
            { cardPicRef = "/Images/ace_of_clubs.png"; }
            else if (aCard.cardSuit == Suit.Diamonds && aCard.cardValue == Value.Ace)
            { cardPicRef = "/Images/ace_of_diamonds.png"; }
            else if (aCard.cardSuit == Suit.Hearts && aCard.cardValue == Value.Ace)
            { cardPicRef = "/Images/ace_of_hearts.png"; }
            else if (aCard.cardSuit == Suit.Spades && aCard.cardValue == Value.Ace)
            { cardPicRef = "/Images/ace_of_spades.png"; }

            BitmapImage cardImage = new BitmapImage(new Uri(cardPicRef, UriKind.Relative));
            return cardImage;
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
