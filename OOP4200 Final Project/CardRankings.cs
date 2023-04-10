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

        // This is the list of cards that have matched the criteria of one of the 
        // card combinations. 
        private List<Card> cardSet = new List<Card>();


        // This variable is used to store the integer value of a players hand, used to compare 
        // player hands with one another to determine the winner. 
        private int playerHandValue;

        // Getters
        private List<Card> GetCardSet() { return this.cardSet; }
        private int GetPlayerHandValue() { return this.playerHandValue; }
        // Setters
        private void SetCardSet(List<Card> cards) { this.cardSet = cards; }
        private void SetPlayerHandValue(int value) { this.playerHandValue = value; }


        /* TO-DO List        
        Checks:
        Royal Flush - Done
        Straight Flush - Done
        Four of a kind - Done
        Full House - Done
        Flush - Done
        Straight - Done
        Three of a kind - Done
        Two Pair - Done
        One Pair - Done
        High Card - Done

        
        */

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

        // Not finished
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="playerCards"></param>
        /// <param name="dealerCards"></param>
        public CardRankings(List<Card> playerCards, List<Card> dealerCards)
        {
            allCards = CombineCards(playerCards, dealerCards);

            // Will make this more efficient when its all working. 
            allCards = SortCardsAscending(allCards);
            List<Card> allCardsFirst = new List<Card>();
            allCardsFirst.Add(allCards[0]);
            allCardsFirst.Add(allCards[1]);
            allCardsFirst.Add(allCards[2]);
            allCardsFirst.Add(allCards[3]);
            allCardsFirst.Add(allCards[4]);

            List<Card> allCardsMiddle = new List<Card>();
            allCardsMiddle.Add(allCards[1]);
            allCardsMiddle.Add(allCards[2]);
            allCardsMiddle.Add(allCards[3]);
            allCardsMiddle.Add(allCards[4]);
            allCardsMiddle.Add(allCards[5]);

            List<Card> allCardsLast = new List<Card>();
            allCardsLast.Add(allCards[2]);
            allCardsLast.Add(allCards[3]);
            allCardsLast.Add(allCards[4]);
            allCardsLast.Add(allCards[5]);
            allCardsLast.Add(allCards[6]);

            List<List<Card>> allCardsList = new List<List<Card>>();
            allCardsList.Add(allCardsFirst);
            allCardsList.Add(allCardsMiddle);
            allCardsList.Add(allCardsLast);

            for (int i = 0; i <= 3; i++)
            {

            }



        }
        #endregion

        #region Methods

        // Can be better organized
        /// <summary>
        /// Checks the players cards and the dealers card to see if there is a royal flush
        /// </summary>
        /// <param name="playerCards"></param>
        /// <param name="dealerCards"></param>
        /// <returns></returns>
        private bool CheckRoyalFlush(List<Card> cards)
        {
            // Boolean to determine if the player has a royal flush.
            bool success = false;
            
            List<Card> royalFlushCards = new List<Card>();
            

            bool aceCard = false;
            bool kingCard = false;
            bool queenCard = false;
            bool jackCard = false;
            bool tenCard = false;
            foreach(Card card in cards)
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
                SetCardSet(royalFlushCards);
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

            // Used if there is a straight flush. 
            List<Card> straightFlushCards = new List<Card>();
            for (int i = 0; i <= 3; i++)
            {
                if (CheckAllCardsSuit_StraightFlush(cards, i))
                {
                    if ((int)allCards[i].cardValue + 1 == (int)allCards[i + 1].cardValue &&
                        (int)allCards[i + 1].cardValue + 1 == (int)allCards[i + 2].cardValue &&
                        (int)allCards[i + 2].cardValue + 1 == (int)allCards[i + 3].cardValue &&
                        (int)allCards[i + 3].cardValue + 1 == (int)allCards[i + 4].cardValue)
                    {
                        // The current 5 cards have matching suits and they are a straight.
                        // Now those 5 cards will be added to the straightFlushCards list so that
                        // it can be set as the cardSet.
                        for (int ii = i; ii <= i+4; i++)
                        {
                            
                            straightFlushCards.Add(allCards[ii]);
                        }
                        SetCardSet(straightFlushCards);
                        SetPlayerHandValue(AddCardValues(straightFlushCards));
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
            // for loop above. The CheckAllCardsSuit method only takes a list of cards and checks them, it
            // assumes that the list of cards is already only 5 cards in length. Since there are 7 cards that
            // need to be checked, this method will check the first 5 cards, then the middle 5, then the last 5.
            bool CheckAllCardsSuit_StraightFlush(List<Card> cards, int index)
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

        
        
        /// <summary>
        /// This method will check the list of cards to see if there is a four of a kind, three of a kind
        /// or one pair. Returns 4 if there was a four of a kind, 3 for three of a kind, 2 for one pair, and 0 if none. 
        /// </summary>
        /// <returns></returns>
        private int CheckCardPairs(List<Card> cards)
        {
            cards = SortCardsAscending(cards);
            int numSameCards = 0;
            for (int i = 0; i <= cards.Count; i++)
            {
                if (cards[i].cardValue == cards[i + 1].cardValue)
                {
                    numSameCards++;
                }
            }

            // Checks if there was a four of a kind
            if (numSameCards == 4)
            {
                SetCardSet(cards);
                SetPlayerHandValue(AddCardValues(cards));
                return 4;
            }
            
            // Checks if there was a three of a kind
            else if (numSameCards == 3)
            {
                SetCardSet(cards);
                SetPlayerHandValue(AddCardValues(cards));
                return 3;
            }

            // Checks if there was a one pair
            else if (numSameCards == 2)
            {
                SetCardSet(cards);
                SetPlayerHandValue(AddCardValues(cards));
                return 2;
            }

            // No pairs were found.
            else
            {
                return 0;
            }
            
        }

        
        /// <summary>
        /// Checks for a full house.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool CheckFullHouse(List<Card> cards)
        {
            cards = SortCardsAscending(cards);

            // Checks if the first 2 cards have the same value
            if (cards[0].cardValue == cards[1].cardValue)
            {

                // Checks if the last 3 cards have the same value
                if (cards[2].cardValue == cards[3].cardValue &&
                    cards[3].cardValue == cards[4].cardValue) 
                {

                    // Player has a full house.

                    // Sets the cardSet and the playerHandValue
                    SetCardSet(cards);
                    SetPlayerHandValue(AddCardValues(cards));
                    return true;

                }
            }


                return false;
        }


        /// <summary>
        /// Checks if the list of cards is a flush.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool CheckFlush (List<Card> cards)
        {
            if (CheckAllCardsSuit(cards)){
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the list of cards is a straight.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool CheckStraight (List<Card> cards)
        {
            cards = SortCardsAscending(cards);
            if ((int)allCards[0].cardValue + 1 == (int)allCards[1].cardValue &&
                        (int)allCards[1].cardValue + 1 == (int)allCards[2].cardValue &&
                        (int)allCards[2].cardValue + 1 == (int)allCards[3].cardValue &&
                        (int)allCards[3].cardValue + 1 == (int)allCards[4].cardValue)
            {
                // The current 5 cards have matching suits and they are a straight.
                // Now those 5 cards will be added to the straightFlushCards list so that
                // it can be set as the cardSet.
                
                SetCardSet(cards);
                SetPlayerHandValue(AddCardValues(cards));
                return true;
            }


            return false;
        }

        /// <summary>
        /// Checks if the list of cars contains a two pair.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool CheckTwoPair (List<Card> cards)
        {
            cards = SortCardsAscending(cards);
            int pairCounter = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].cardValue == cards[i + 1].cardValue)
                {
                    pairCounter++;
                } 
            }

            if (pairCounter == 2)
            {
                // Two pair was found.
                SetCardSet(cards);
                SetPlayerHandValue(AddCardValues(cards));
            }
            return false;
        }


        /// <summary>
        /// Since the default card combination is a high card, all this method does is sets the cardSet
        /// and adds the card values together.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool CheckHighCard (List<Card> cards)
        {
            cards = SortCardsAscending(cards);
            SetCardSet(cards);
            SetPlayerHandValue(AddCardValues(cards));
            return true;
        }
       
        /// <summary>
        /// Sorts the cards list in ascending order by their card value. Uses LINQ to sort.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private List<Card> SortCardsAscending(List<Card> cards)
        {        
            // (int) card.cardValue;
            cards.OrderBy(Card => (int)Card.cardValue);

            return cards;
            
        }

        /// <summary>
        /// Adds the card values together from the list of cards. Used to determine the ranking of the same card combinations.
        /// For example, if two people have a full house, the program needs to determine which full house is better than the other. 
        /// So this method will combine the number values of the list of cards and return them, which will later be used to compare
        /// the card values of those two players. Assumes its being passed a list of 5 cards.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private int AddCardValues (List<Card> cards)
        {
            int cardValues = 0;

            foreach (Card card in cards)
            {
                cardValue += (int)card.cardValue;
            }
            return cardValues;
        }
        
        /// <summary>
        /// Checks the suits of the cards, returns true if all the cards in the list are the same. 
        /// Assumes it's being passed a list of 5 cards. 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool CheckAllCardsSuit (List<Card> cards)
        {           
            
            // Checks if all the cards match
            if (Card.SameSuit(cards[0], cards[1]) &&
                Card.SameSuit(cards[1], cards[2]) &&
                Card.SameSuit(cards[2], cards[3]) &&
                Card.SameSuit(cards[3], cards[4]))
            {
                return true;
            }
            else
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
