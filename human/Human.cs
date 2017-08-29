// Create a Human class with the attributes: name, strength, intelligence, dexterity and health
// Give a default value of 3 for strength, intelligence, dexterity and 100 for health
// Create a constructor that accepts a name
// Also create a constructor that accepts all 5 attributes
// Create a method to attack
// Allow attach method to accept any object but on work on a Human type

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
    }
}