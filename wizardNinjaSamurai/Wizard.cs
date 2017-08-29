using System;

namespace ConsoleApplication
{

    public class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            this.health = 50;
            this.intelligence = 25;
        }

        public void Heal()
        {
            this.health += 10 * this.intelligence;
        }

        public void Fireball(object target)
        {
            Random rand = new Random();
            if(target is Human)
            {
                Human enemy = target as Human;
                enemy.health -= rand.Next(20,51);
            }
        }

    }

}