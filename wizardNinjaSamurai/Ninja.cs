using System;

namespace ConsoleApplication
{

    public class Ninja : Human
    {

        public Ninja(string name) : base(name)
        {
            this.dexterity = 175;
        }

        public void Steal(object target)
        {
            if(target is Human)
            {
                Human victim = target as Human;
                victim.health -= 10;
                this.health += 10;
            }
        }

        public void GetAway()
        {
            this.health -= 15;
        }

    }

}