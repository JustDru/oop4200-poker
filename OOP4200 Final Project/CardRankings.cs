using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP4200_Final_Project
{
    internal class CardRankings : Card
    {
        private List<Card> allCards = new List<Card>();


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

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="playerCards"></param>
        /// <param name="dealerCards"></param>
        public CardRankings(List<Card> playerCards, List<Card> dealerCards)
        {
            allCards = CombineCards(playerCards, dealerCards);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Checks the players cards and the dealers card to see if there is a royal flush
        /// </summary>
        /// <param name="playerCards"></param>
        /// <param name="dealerCards"></param>
        /// <returns></returns>
        private bool CheckRoyalFlush()
        {
            // Boolean to determine if the player has a royal flush.
            bool success = false;
            
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
                else if (card.cardValue == Value.Ace)
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

        /// <summary>
        /// Checks if the cards create a straight flush. Calls the SortCardsAscending to sort the cards in ascending 
        /// order first. Returns true if there is a straight flush, false if not.
        /// </summary>
        /// <returns></returns>
        private bool CheckStraightFlush()
        {
            // Sorts cards
            allCards = SortCardsAscending(allCards);
            


            // Cards will be sorted so these if statements check if the card + 1 is equal to the next 
            // card in the list. 
            // Checks if the first 5 cards in the 7 are sequential
            List<Card> cards = new List<Card>();            
            for (int i = 0; i <= 3; i++)
            {
                if (CheckAllCardsSuit_StraigtFlush(cards, i))
                {
                    if ((int)allCards[i].cardValue + 1 == (int)allCards[i + 1].cardValue &&
                        (int)allCards[i + 1].cardValue + 1 == (int)allCards[i + 2].cardValue &&
                        (int)allCards[i + 2].cardValue + 1 == (int)allCards[i + 3].cardValue &&
                        (int)allCards[i + 3].cardValue + 1 == (int)allCards[i + 4].cardValue)
                    {
                        // The current 5 cards have matching suits and they are a straight
                        return true;
                    }
                }
                else
                {
                    // Cards did not match
                    return false;
                }
                

            }          
            
            // This method is here to check the current list of cards with a specific index. 
            // Used just to organize code, otherwise there would be a for loop for each index in the 
            // for loop above. 
            bool CheckAllCardsSuit_StraigtFlush(List<Card> cards, int index)
            {
                for (int i = index; i <= (index + 4); i++)
                {
                    cards.Add(allCards[i]);
                    return CheckAllCardsSuit(cards);
                }
                return false;
            }

            return false;
        }


        // Need to complete
        /// <summary>
        /// Checks for a four of a king
        /// </summary>
        /// <returns></returns>
        private bool CheckFourOfAKind()
        {
            return false;
        }


        // Might need editting
        /// <summary>
        /// Sorts the cards list in ascending order by their card value.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private List<Card> SortCardsAscending(List<Card> cards)
        {        
            // (int) card.cardValue;
            cards.OrderBy(Card => Card.cardValue);

            return cards;
            
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
