using System;

namespace ConsoleApplication
{
    public class Deck
    {
        public object[] cards = new object[52];

        public Deck()
        {
            this.Reset();
        }

        public Card Deal()
        {
            Card dealtCard = this.cards[0] as Card;
            if(dealtCard == null)
            {
                this.Reset();
                this.Shuffle();
                dealtCard = this.cards[0] as Card;
            }
            int len = this.cards.Length;
            for(int i=0;i<len-1;i++)
            {
                this.cards[i] = this.cards[i+1];
            }
            this.cards[len-1] = null;
            return dealtCard;
        }

        public void Reset()
        {
            object[] faces = new object[13]{"Ace",2,3,4,5,6,7,8,9,10,"Jack","Queen","King"};
            string[] suits = new string[4]{"Clubs","Spades","Hearts","Diamonds"};
            int cardNumber = 0;
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<13;j++)
                {
                    this.cards[cardNumber] = new Card(faces[j], suits[i]);
                    cardNumber++;
                }
            }
        }

        public void Shuffle(int numTimesToShuffle = 100)
        {
            Random rand = new Random();
            Card temp;
            int i = 0;
            while(i<numTimesToShuffle){
                int shuffle1 = rand.Next(52);
                int shuffle2 = rand.Next(52);
                temp = this.cards[shuffle1] as Card;
                this.cards[shuffle1] = this.cards[shuffle2];
                this.cards[shuffle2] = temp;
                i++;
            }
        }
    }
}