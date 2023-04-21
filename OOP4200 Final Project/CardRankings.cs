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
        // List used to store the cards of the player and the dealer. 
        private List<Card> allCards = new List<Card>();

        // This is the list of cards that have matched the criteria of one of the 
        // card combinations. 
        private List<Card> cardSet = new List<Card>();


        // This variable is used to store the integer value of a players hand, used to compare 
        // player hands with one another to determine the winner. 
        private int playerHandValue;

        // Getters
        /// <summary>
        /// Get the card set
        /// </summary>
        /// <returns>A list of cards</returns>
        public List<Card> GetCardSet() { return this.cardSet; }
        /// <summary>
        /// Get the value of the players hand
        /// </summary>
        /// <returns></returns>
        public int GetPlayerHandValue() { return this.playerHandValue; }
        // Setters
        /// <summary>
        /// Set the value of the players card set
        /// </summary>
        /// <param name="cards"></param>
        private void SetCardSet(List<Card> cards) { this.cardSet = cards; }
        /// <summary>
        /// Set the value of the players hand
        /// </summary>
        /// <param name="value"></param>
        private void SetPlayerHandValue(int value) { this.playerHandValue = value; }

        #region Enums
        // Enum for rankings
        public enum Rankings
        {
            
            RoyalFlush = 10,
            StraightFlush = 9,
            FourOfAKind = 8,
            FullHouse = 7,
            Flush = 6,
            ThreeOfAKind = 5,
            Straight = 4,
            TwoPair = 3,
            OnePair = 2,
            HighCard = 1,
            Folded = 0
        }

        public Rankings cardRank { get; set; }


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
            // Combines the player cards with the dealer cards.
            allCards = CombineCards(playerCards, dealerCards);

            // Sorts the cards in ascending order based off their card values. 
            allCards = SortCardsAscending(allCards);

            // Each of these functions checks for their respective card combination. 
            // They are called in order from lowest value to highest value, since each function
            // will be replacing the playerHandValues and the cardRank value we need to call the
            // highed calue combinations last. 
            CheckHighCard(allCards);
            CheckTwoPair(allCards);
            CheckStraight(allCards);
            CheckFlush(allCards);
            CheckCardPairs(allCards);
            CheckFullHouse(allCards);
            CheckStraightFlush(allCards);
            CheckRoyalFlush(allCards);
            this.SetPlayerHandValue(AddCardValues());
            

        }
        #endregion

        #region Methods

        
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
                SetCardSet(royalFlushCards);
                this.cardRank = Rankings.RoyalFlush;
                success = true;
            }

            return success;
        }

        /// <summary>
        /// Checks if the cards create a straight flush.  Returns true if there is a straight flush, false if not.
        /// </summary>
        /// <returns></returns>
        private bool CheckStraightFlush(List<Card> cards)
        {
            List<Card> straightFlushCards = new List<Card>();

            // Loops a max of 3 times, this is because within the sorted list of 7 cards, there is only 3 places that
            // a straight can be found. It can be found in the first 5 cards, the middle 5 cards, or the last 5 cards. 
            // The if statement within the loop will check if the card at index of 'i' is one card value less than the 
            // next card in the 5. This is the reason that the for loop cannot loop more than 3 times, the last card checked
            // is i + 4, meaning it will be checking outside the list of 7 if i is greater than 3. 
            for (int i = 0; i < (cards.Count() - 4); i++)
            {
                if ((int)cards[i].cardValue + 1 == (int)cards[i + 1].cardValue &&
                    (int)cards[i + 1].cardValue + 1 == (int)cards[i + 2].cardValue &&
                    (int)cards[i + 2].cardValue + 1 == (int)cards[i + 3].cardValue &&
                    (int)cards[i + 3].cardValue + 1 == (int)cards[i + 4].cardValue)
                {
                    // 5 cards were found to be a straight, now those cards are added to the straightFlushCards list to be 
                    // checked if their suits match. 
                    straightFlushCards.Add(cards[i]);
                    straightFlushCards.Add(cards[i + 1]);
                    straightFlushCards.Add(cards[i + 2]);
                    straightFlushCards.Add(cards[i + 3]);
                    straightFlushCards.Add(cards[i + 4]);

                    // If the suits match then it sets the cardSet and the cardRank. 
                    if (CheckAllCardsSuit(straightFlushCards))
                    {
                        SetCardSet(straightFlushCards);
                        this.cardRank = Rankings.StraightFlush;
                        return true;
                    }

                    // Returns false if the cards were not same suit. 
                    else
                    {
                        return false;
                    }
                }

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
            for (int i = 0; i < (cards.Count() - 1); i++)
            {
                if (cards[i].cardValue == cards[i + 1].cardValue)
                {
                    numSameCards++;

                    // 2 cards that matched were found, now this checks if the second card matches the next card.
                    // Mainly used to stop the code from thinking there is a three of a kind when there is a two pair. 
                    // A two pair without this if statement, would cause numSameCards to go to 2, which would execute the
                    // three of a kind was found if statement below. 
                    if ((i + 2) < cards.Count())
                    {
                        if (cards[i + 1].cardValue != cards[i + 2].cardValue)
                        {
                            break;
                        }
                    }
                        
                    
                    
                }
            }

            // Checks if there was a four of a kind
            if (numSameCards == 3)
            {
                // Checks if the card rank is less than a FourOfAKind and then sets the cardRank if it is. 
                // This needs to be checked because this function is run after other card combination checks
                // that may have a higher card combination value, like a flush. 
                if ((int)this.cardRank < (int)Rankings.FourOfAKind)
                {
                    SetCardSet(cards);
                    this.cardRank = Rankings.FourOfAKind;
                }
                
                return 4;
            }
            
            // Checks if there was a three of a kind
            else if (numSameCards == 2)
            {
                if ((int)this.cardRank < (int)Rankings.ThreeOfAKind)
                {
                    SetCardSet(cards);
                    this.cardRank = Rankings.ThreeOfAKind;
                }
                
                return 3;
            }

            // Checks if there was a one pair
            else if (numSameCards == 1)
            {
                if ((int)this.cardRank < (int)Rankings.OnePair)
                {
                    SetCardSet(cards);
                    this.cardRank = Rankings.OnePair;
                }
               
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
            // Uses LINQ to group cards by their card values
            var fullHouseCards = cards.GroupBy(card => card.cardValue);

            bool threeOfAKind = false;
            bool pair = false;

            // Loops through each card in the grouped list and uses the LINQ Count() function to 
            // check for a three of a kind, and a two pair. 
            foreach (var card in fullHouseCards)
            {
                if (card.Count() == 3)
                {
                    threeOfAKind = true;
                }
                else if (card.Count() == 2)
                {
                    pair = true;
                }
            }

            // If there was a three of a kind and a pair found.
            if (threeOfAKind && pair) 
            {
                SetCardSet(cards);
                this.cardRank = Rankings.FullHouse;
                return true;

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
                this.cardRank = Rankings.Flush;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the list of cards is a straight. Calls the IsStraight function. 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool CheckStraight (List<Card> cards)
        {
            cards = SortCardsAscending(cards);
            if (IsStraight(cards))
            {
                // The 5 cards are a straight
                
                SetCardSet(cards);
                this.cardRank = Rankings.Straight;
                return true;
            }


            return false;
        }

        /// <summary>
        /// Checks if the list of cards contains a straight.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool IsStraight (List<Card> cards)
        {
            

            // For loop to loop through the list of cards and find out if there is a straight or not. 
            // This will loop a max of 3 times, because the straight can only appear in three possible spots in the list.
            // It can appear as the first 5 cards, the middle 5 cards, or the last 5 cards. 
            for (int i = 0; i < (cards.Count() - 4); i++)
            {
                if ((int)cards[i].cardValue + 1 == (int)cards[i + 1].cardValue &&
                    (int)cards[i + 1].cardValue + 1 == (int)cards[i + 2].cardValue &&
                    (int)cards[i + 2].cardValue + 1 == (int)cards[i + 3].cardValue &&
                    (int)cards[i + 3].cardValue + 1 == (int)cards[i + 4].cardValue)
                {
                    return true;
                }
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
            for (int i = 0; i < (cards.Count() - 1); i++)
            {
                if (cards[i].cardValue == cards[i + 1].cardValue)
                {
                    i++;
                    pairCounter++;
                } 
            }

            if (pairCounter == 2)
            {
                // Two pair was found.
                SetCardSet(cards);
                this.cardRank = Rankings.TwoPair;
                return true;
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
            this.cardRank = Rankings.HighCard;
            return true;
        }
       
        /// <summary>
        /// Sorts the cards list in ascending order by their card value. Uses LINQ to sort.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public List<Card> SortCardsAscending(List<Card> cards)
        {
            // (int) card.cardValue;
            // Uses LINQ's OrderBy function to order the list by the card values. 
            List<Card> sortedCards = cards.OrderBy(Card => (int)Card.cardValue).ToList<Card>();

            return sortedCards;
            
        }

        /// <summary>
        /// Adds the card values together from the list of cards. Used to determine the ranking of the same card combinations.
        /// For example, if two people have a full house, the program needs to determine which full house is better than the other. 
        /// So this method will combine the number values of the list of cards and return them, which will later be used to compare
        /// the card values of those two players. 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private int AddCardValues ()
        {
            int cardValues = 0;

            foreach (Card card in allCards)
            {
                cardValues += (int)card.cardValue;
            }
            return cardValues;

        }
        
        /// <summary>
        /// Checks the suits of the cards, returns true if there was 5 or more cards of the same suit. 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private bool CheckAllCardsSuit (List<Card> cards)
        {
            // Variables to hold the number of each suit
            int hearts = 0;
            int diamonds = 0;
            int clubs = 0;
            int spades = 0;

            // Loop through each card in the list and check the cards suit, increment the corresponding
            // suit counter based on the current cards suit. 
            foreach (Card card in cards)
            {
                if (card.cardSuit == Suit.Hearts)
                {
                    hearts++;
                }
                if (card.cardSuit == Suit.Diamonds)
                {
                    diamonds++;
                }
                if (card.cardSuit == Suit.Clubs)
                {
                    clubs++;
                }
                if (card.cardSuit == Suit.Spades)
                {
                    spades++;
                }

            }

            // If any of the suit counters are greater than or equal to 5, then a flush was found, so 
            // now return true. 
            if (hearts >= 5 || diamonds >= 5 || clubs >= 5 || spades >= 5) 
            {
                return true;            
            }

            return false;

           
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

        /// <summary>
        /// Just a helper function to help debugging a players hand.
        /// </summary>
        /// <param name="playerNum"></param>
        /// <returns></returns>
        public int DumpHandValue(int playerNum)
        {
            int hand = 0;

            foreach (Card card in allCards)
            {
                hand += (int)card.cardValue;    
            }
           
            return hand;
        }

        #endregion
    }
}
