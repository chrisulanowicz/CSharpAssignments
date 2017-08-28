using System;
using System.Collections.Generic;

namespace collectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Three basic arrays (create and then iterate and display values)
            // create an array to hold integer values 0 through 9
            int[] numbers = new int[10]{0,1,2,3,4,5,6,7,8,9};
            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }

            // create an array with 4 names
            string[] names = new string[4]{"Clark", "Bruce", "Diana", "Barry"};
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            // create an array that alternates between true and false 10 times
            bool[] alternate = new bool[10];
            bool alt1 = true;
            for(int i=0;i<10;i++)
            {
                alternate[i] = alt1 ? true : false;
                alt1 = !alt1;
            }
            foreach(bool result in alternate)
            {
                Console.WriteLine(result);
            }

            // Create a Multiplication Table with Arrays (with values 1-10)
            int[,] multiplicationTable = new int[10,10];
            for(int y=0;y<10;y++)
            {
                for(int x=0;x<10;x++)
                {
                    multiplicationTable[y,x] = (y+1)*(x+1);
                }
            }
            // next display the table
            for(int y=0;y<10;y++)
            {
                string display = "[";
                for(int x=0;x<10;x++)
                {
                    display += multiplicationTable[y,x] + ", ";
                    if(multiplicationTable[y,x] < 10)
                    {
                        display+= " ";
                    }
                }
                display += "]";
                Console.WriteLine(display);
            }

            // Create a List of 5 cars
            List<string> cars = new List<string>();
            cars.Add("Challenger");
            cars.Add("Charger");
            cars.Add("Super Bee");
            cars.Add("Omni");
            cars.Add("Mirada");

            // try a few things with the List
            Console.WriteLine(cars[2]);
            Console.WriteLine(cars.Count);
            cars.RemoveAt(2);
            Console.WriteLine(cars[2]);

            // Create a dictionary using names array above for keys and cars List above for values at random
            Dictionary<string,string> users = new Dictionary<string,string>();
            Random rand = new Random();
            foreach(string name in names)
            {
                users.Add(name, cars[rand.Next(cars.Count)]);
            }

            // display the key value pairs
            foreach(KeyValuePair<string,string> entry in users)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }

            // can also display above using 'var'
            foreach(var entry in users)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }
    }
}
