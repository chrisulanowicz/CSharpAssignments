using System;

namespace ConsoleApplication
{
    class Program
    {
        // Construct a Deck, Card and Player class that can be used as a foundation to a card game
        static void Main(string[] args)
        {
            Deck blue = new Deck();
            blue.Shuffle();
            foreach(Card card in blue.cards)
            {
                Console.WriteLine(card.rank + " of " + card.suit);
            }
            Card dealtCard = blue.Deal();
            Console.WriteLine("You were dealt a " + dealtCard.rank + " of " + dealtCard.suit);
            dealtCard = blue.Deal();
            Console.WriteLine("You were dealt a " + dealtCard.rank + " of " + dealtCard.suit);
            blue.Reset();
            blue.Shuffle();
            Player dave = new Player("dave");
            Player john = new Player("john");
            dave.Draw(blue);
            john.Draw(blue);
            dave.Draw(blue);
            john.Draw(blue);
            Console.WriteLine(dave.hand);
            foreach(Card card in dave.hand)
            {
                Console.WriteLine(card.rank + " of " + card.suit);
            }
            foreach(Card card in john.hand)
            {
                Console.WriteLine(card.rank + " of " + card.suit);
            }
            dave.Discard(1);
            foreach(Card card in dave.hand)
            {
                Console.WriteLine(card.rank + " of " + card.suit);
            }
        }
    }
}
