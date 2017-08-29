using System;

namespace ConsoleApplication
{

    public class Samurai : Human
    {
        public static int numberSamurai = 0;

        public static void HowMany()
        {
            Console.WriteLine("There are {0} Samurai", numberSamurai);
        }

        public Samurai(string name) : base(name)
        {
            this.health = 200;
            numberSamurai++;
        }

        public void DeathBlow(object target)
        {
            if(target is Human)
            {
                Human enemy = target as Human;
                enemy.health = enemy.health<50 ? 0 : enemy.health-50;
            }
        }

        public void Meditate()
        {
            this.health = 200;
        }

    }

}