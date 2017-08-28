using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // loop to print all values from 1 to 255 inclusive
            for(int i=1;i<256;i++)
            {
                Console.WriteLine(i);
            }

            // loop to only print values between 1-100 inclusive divisible by 3 or 5 but not both
            for(int i=1;i<101;i++)
            {
                if( (i%3==0) != (i%5==0))
                {
                    Console.WriteLine(i);
                }
            }

            // fizzbuzz numbers from 1 to 100
            for(int i=1;i<101;i++)
            {
                bool three = i%3==0;
                bool five = i%5==0;
                if(three && five)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(three)
                {
                    Console.WriteLine("Fizz");
                }
                else if(five)
                {
                    Console.WriteLine("Buzz");
                }
                else{
                    Console.WriteLine(i);
                }
            }

            // fizzbuzz numbers from 1 to 100 WITHOUT modulus
            int threeA = 0;
            int fiveA = 0;
            for(int i=1;i<101;i++)
            {
                threeA++;
                fiveA++;
                if(threeA == 3 && fiveA == 5)
                {
                    Console.WriteLine("FizzBuzz");
                    threeA = 0;
                    fiveA = 0;
                }
                else if(threeA == 3)
                {
                    Console.WriteLine("Fizz");
                    threeA = 0;
                }
                else if(fiveA == 5)
                {
                    Console.WriteLine("Buzz");
                    fiveA = 0;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

            // fizzbuzz with 10 random numbers
            Random rand = new Random();
            for(int i=0;i<10;i++)
            {
                int temp = rand.Next();
                bool three = temp%3==0;
                bool five = temp%5==0;
                if(three && five)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if(three)
                {
                    Console.WriteLine("Fizz");
                }
                else if(five)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(temp);
                }
            }

        }
    }
}
