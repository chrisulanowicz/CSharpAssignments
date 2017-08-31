using System;

namespace DachiPet
{

    public class Dachi
    {

        public string Name { get; set; }
        public int Happiness { get; set; }
        public int Fullness { get; set; }
        public int Energy { get; set; }
        public int Meals { get; set; }
        public bool Alive { get; set; }
        public string Status { get; set; }
        public string Emotion { get; set; }

        public Dachi(string name)
        {
            this.Name = name;
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
            Alive = true;
            Status = "Say hello to your new Dachi!";
            Emotion = "happy";
        }

        public void Feed()
        {
            Random rand = new Random();
            int Mood = rand.Next(100);
            if(Meals > 0 && Mood > 25)
            {
                Emotion = "happy";
                Meals -= 1;
                int Fill = rand.Next(5,11);
                Fullness += Fill;
                Status = $"You fed {Name}, fullness increased +{Fill}, meals decreased -1";
            }
            else if(Meals > 0 && Mood < 25)
            {
                Emotion = "sad";
                Meals -= 1;
                Status = $"{Name} is in a bad mood didn't like the meal and is still Hungry";
            }
            else
            {
                Emotion = "sad";
                Status = $"You have no meals left to feed {Name}";
            }
        }

        public void Play()
        {
            Random rand = new Random();
            int Mood = rand.Next(100);
            if(Mood > 25)
            {
                Emotion = "happy";
                int Pleased = rand.Next(5,11);
                Happiness += Pleased;
                Status = $"You played with {Name}, happiness increased +{Pleased}, energy decreased -5";
            }
            else 
            {
                Emotion = "sad";
                Status = $"{Name} isn't in a playing mood, energy decreased -5";
            }
            Energy -= 5;
        }

        public void Work()
        {
            Emotion = "happy";
            Random rand = new Random();
            Energy -= 5;
            int Earned = rand.Next(1,4);
            Meals += Earned;
            Status = $"You and {Name} went to work and burned 5 energy but earned {Earned} meals";
        }

        public void Sleep()
        {
            Emotion = "happy";
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            Status = $"{Name} slept and gained 15 energy, but lost 5 fullness and 5 happiness";
        }

        public void CheckHealth()
        {
            if(Energy < 1 || Fullness < 1 || Happiness < 1)
            {
                Emotion = "happy";
                Alive = false;
                Status = $"{Name} has died :(";
            }
            else if(Energy > 99 && Fullness > 99 && Happiness > 99)
            {
                Status = "You have WON the game!!!!!";
            }
        }

    }
}