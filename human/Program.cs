using System;

namespace ConsoleApplication
{
    class Program
    {
        // See assignment notes in Human.cs file

        static void Main(string[] args)
        {
            Human dave = new Human("dave");
            Console.WriteLine(dave.name, dave.health);
            Human john = new Human("john",5,5,5,200);
            Console.WriteLine(john.name, john.health);
            john.Attack(dave);
            Console.WriteLine("Dave's health is now " + dave.health);
        }
    }
}
