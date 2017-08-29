namespace ConsoleApplication
{
    public class Card
    {
        public string rank;
        public string suit;
        public int value;

        public Card(object rank, string suit)
        {
            this.suit = suit;
            if(rank is int)
            {
                int temp = (int) rank;
                this.rank = temp.ToString();
                this.value = temp;
            }
            else
            {
                string face = rank as string;
                this.rank = face;
                this.value = face=="Ace" ? 11 : 10;
            }
        }

    }
}