using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP4200_Final_Project
{
    internal class Deck : Card
    {
        #region Constructors
        /// <summary>
        /// Default constructor for Deck - Calls the Reset method
        /// </summary>
        public Deck()
        {
            Reset();
        }
        #endregion

        #region Properties
        // List of cards inside the deck (Should be all 52 to start)
        public List<Card> Cards { get; set; }
        #endregion


        #region Methods

        /// <summary>
        /// Method to reset the deck by adding all cards back in
        /// </summary>
        public void Reset()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                                    .Select(c => new Card()
                                    {
                                        cardSuit = (Suit)s,
                                        cardValue = (Value)c
                                    }
                                            )
                            )
                   .ToList();
        }

        /// <summary>
        /// Method to shuffle the deck (Modify the order of the cards)
        /// </summary>
        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        /// <summary>
        /// Method to take one card from the deck
        /// </summary>
        /// <returns></returns>
        public Card DrawCard()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);
            return card;
        }

        /// <summary>
        /// Method to take multiple cards from the deck
        /// </summary>
        /// <param name="numCards"></param>
        /// <returns></returns>
        public List<Card> DrawCards(int numCards)
        {
            var cards = Cards.Take(numCards);
            var takeCards = cards as List<Card> ?? cards.ToList();
            Cards.RemoveAll(takeCards.Contains);
            
            return takeCards;
        }

        /// <summary>
        /// Method to sort the deck in descending order from suit and value 
        /// </summary>
        /// <param name="listOfCards"></param>
        /// <returns></returns>
        public List<Card> Sort(List<Card> listOfCards)
        {
            List<Card> sorted = listOfCards.GroupBy(s => s.cardSuit).
                OrderByDescending(c => c.Count()).SelectMany(g => g.OrderByDescending(c => c.cardValue)).
                ToList();

            return sorted;
        }


        #endregion

    }
}
