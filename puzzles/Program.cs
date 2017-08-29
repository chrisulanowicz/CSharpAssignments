using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {

        // Create a function that returns an array of 10 random integers between 5-25
        // Print the min and max as well as sum of values before returning array
        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] randomArray = new int[10];
            int max = 4;
            int min = 26;
            int sum = 0;
            for(int i=0;i<10;i++)
            {
                int temp = rand.Next(5,26);
                randomArray[i] = temp;
                if(temp > max)
                {
                    max = temp;
                }
                if(temp < min)
                {
                    min = temp;
                }
                sum += temp;
            }
            Console.WriteLine("Min: {0}, Max: {1}, Sum: {2}", min, max, sum);
            return randomArray;
        }

        // Create a function that simulates a coin toss and return a string with the result
        public static string TossCoin()
        {
            Random rand = new Random();
            Console.WriteLine("Tossing a coin");
            int flip = rand.Next(2);
            string result = flip==0 ? "heads" : "tails";
            Console.WriteLine("It's " + result);
            return result;
        }

        // Create a function that calls above TossCoin a given number of times and return a double that reflects the head/tail ratio
        public static double MultipleCoinToss(int num)
        {
            double heads = 0;
            string result;
            for(int i=0;i<num;i++)
            {
                result = TossCoin();
                if(result == "heads")
                {
                    heads++;
                }
            }
            return heads/num;
        }

        // Create a function that returns an array of strings
        // then shuffle the array and print the new order
        // finally return the array with only strings longer than 5 characters
        public static List<string> Cars()
        {
            Random rand = new Random();
            string[] cars = new string[8]{"Dart", "Omni", "Challenger", "Charger", "Durango", "Ram", "Super Bee", "Avenger"};
            string temp;
            for(int i=0;i<cars.Length;i++)
            {
                int shuffle = rand.Next(5);
                temp = cars[i];
                cars[i] = cars[shuffle];
                cars[shuffle] = temp;
            }
            
            // Since we have to iterate the array to display the values, we may as well grab the longer strings at the same time
            List<string> longCarNames = new List<string>();
            for(int idx = 0;idx<8;idx++)
            {
                Console.WriteLine(cars[idx]);
                if(cars[idx].Length>5)
                {
                    longCarNames.Add(cars[idx]);
                }
            }
            return longCarNames;
        }
        static void Main(string[] args)
        {
            int[] testArr = RandomArray();
            TossCoin();
            Console.WriteLine(MultipleCoinToss(10));
            List<string> vehicles = Cars();
            foreach(string vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
