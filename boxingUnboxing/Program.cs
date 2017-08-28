using System;
using System.Collections.Generic;

namespace boxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an empty List of type object
            List<object> hodgePodge = new List<object>();

            // Add some ints, bools, strings
            hodgePodge.Add(7);
            hodgePodge.Add(22);
            hodgePodge.Add(-1);
            hodgePodge.Add(true);
            hodgePodge.Add("a string");

            // Now iterate through the list and print the values
            foreach(var item in hodgePodge)
            {
                Console.WriteLine(item);
            }

            // Now add up the integers and display the sum
            int sum = 0;
            foreach(var item in hodgePodge)
            {
                if(item is int)
                {
                    sum += (int)item;
                }
            }
            Console.WriteLine("The sum is {0}", sum);
        }
    }
}
