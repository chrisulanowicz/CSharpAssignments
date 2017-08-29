using System;

namespace ConsoleApplication
{
    class Program
    {
        // Using prior Human assignment, create Wizard, Ninja, and Samurai classes that inherit from it for an RPG type game

        static void Main(string[] args)
        {
            Wizard merlin = new Wizard("Merlin");
            Ninja shinobi = new Ninja("Shinobi");
            Samurai nobunaga = new Samurai("Nobunaga");
            merlin.DisplayInfo();
            shinobi.DisplayInfo();
            nobunaga.DisplayInfo();
            merlin.Fireball(nobunaga);
            shinobi.GetAway();
            nobunaga.Attack(merlin);
            shinobi.Steal(merlin);
            merlin.Heal();
            merlin.Fireball(shinobi);
            nobunaga.DeathBlow(shinobi);
            nobunaga.Meditate();
            merlin.DisplayInfo();
            shinobi.DisplayInfo();
            nobunaga.DisplayInfo();
            Samurai masomune = new Samurai("Masomune");
            Samurai.HowMany();
        }
    }
}
