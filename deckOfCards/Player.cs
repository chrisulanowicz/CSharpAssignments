using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Player
    {
        public string name;
        public List<Card> hand;

        public Player(string name)
        {
            this.name = name;
            this.hand = new List<Card>();
        }

        public Card Draw(Deck cardDeck)
        {
            Card dealtCard = cardDeck.Deal();
            this.hand.Add(dealtCard);
            return dealtCard;
        }

        public Card Discard(int index)
        {
            Card removedCard;
            if(index >= this.hand.Count)
            {
                removedCard = null;
            }
            else
            {
                removedCard = this.hand[index];
                this.hand.RemoveAt(index);
            }
            return removedCard;
        }

    }
}