using System;

namespace ConsoleApplication
{
    public class Human
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(string name){
            this.name = name;
        }

        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            this.name = name;
            this.strength = strength;
            this.intelligence = intelligence;
            this.dexterity = dexterity;
            this.health = health;
        }

        public void Attack(object target)
        {
            if(target is Human)
            {
                Human attacked = target as Human;
                attacked.health -= 5 * this.strength;
            }
        }

        public void DisplayInfo()
        {
            string info = this.name + "'s strength: " + this.strength + " intelligence: " + this.intelligence + " dexterity: " + this.dexterity + " health: " + this.health;
            Console.WriteLine(info);
        }
    }
}