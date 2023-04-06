using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OOP4200_Final_Project
{
    internal class CardRankings : Card
    {
        #region Enums
        // Enum for rankings
        public enum Rankings
        {
            RoyalFlush = 1,
            StraightFlush = 2,
            FourOfAKind = 3,
            FullHouse = 4,
            Flush = 5,
            ThreeOfAKind = 6,
            Straight = 7,
            TwoPair = 8,
            OnePair = 9,
            HighCard = 10
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CardRankings()
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Checks the players cards and the dealers card to see if there is a royal flush
        /// </summary>
        /// <param name="playerCards"></param>
        /// <param name="dealerCards"></param>
        /// <returns></returns>
        private bool CheckRoyalFlush(List<Card> playerCards, List<Card> dealerCards)
        {
            // Boolean to determine if the player has a royal flush.
            bool success = false;
            List<Card> allCards = CombineCards(playerCards, dealerCards);
            List<Card> royalFlushCards = new List<Card>();
            bool aceCard = false;
            bool kingCard = false;
            bool queenCard = false;
            bool jackCard = false;
            bool tenCard = false;
            foreach(Card card in allCards)
            {
                if (card.cardValue == Value.Ace)
                {
                    aceCard = true;
                    royalFlushCards.Add(card);
                } 
                else if (card.cardValue == Value.King)
                { 
                    kingCard = true;
                    royalFlushCards.Add(card);
                }
                else if (card.cardValue == Value.Queen)
                {
                    queenCard = true;
                    royalFlushCards.Add(card);
                }
                else if (card.cardValue == Value.Jack)
                {
                    jackCard = true;
                    royalFlushCards.Add(card);
                }
                else if (card.cardValue == Value.Ten)
                {
                    tenCard = true;
                    royalFlushCards.Add(card);
                }
            }
            if (aceCard && kingCard && queenCard && jackCard && tenCard && CheckAllCardsSuit(royalFlushCards))
            {
                success = true;
            }

            return success;
        }

        // Might need editting
        /// <summary>
        /// Checks the suits of the cards, returns true if all the cards int the list are the same. 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool CheckAllCardsSuit (List<Card> cards)
        {
            int sameSuiteCounter = 0;
            foreach (Card card in cards)
            {
                for(int i = 0; i < cards.Count; i++)
                {
                    if (Card.SameSuit(card, cards[i]))
                    {
                        sameSuiteCounter++;
                    }
                }
            }
            if (sameSuiteCounter == 5)
            {
                return true;
            } else
            {
                return false;
            }
           
        }


        /// <summary>
        /// Combines the two lists of cards
        /// </summary>
        /// <param name="playerCards"></param>
        /// <param name="dealerCards"></param>
        /// <returns></returns>
        private List<Card> CombineCards (List<Card> playerCards, List<Card> dealerCards)
        {
            List<Card> allCards = new List<Card>();

            foreach (Card card in playerCards)
            {
                allCards.Add(card);
                
            }
            foreach (Card card in dealerCards)
            {
                allCards.Add(card);
               
            }
            return allCards;
        }
        #endregion
    }
}
