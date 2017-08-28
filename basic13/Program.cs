using System;

namespace basic13
{
    class Program
    {
        // print all numbers from 1 to 255
        public static void print1To255()
        {
            for(int i=1;i<256;i++)
            {
                Console.WriteLine(i);
            }
        }

        // print all odd numbers between 1 and 255
        public static void printOddsTo255()
        {
            for(int i=1;i<256;i+=2)
            {
                Console.WriteLine(i);
            }
        }

        // print all numbers from 0 to 255 along with a running sum
        public static void printIntsWithSum()
        {
            int sum = 0;
            for(int i=0;i<256;i++)
            {
                sum += i;
                Console.WriteLine("Integer is: {0} and the current sum is {1}", i, sum);
            }
        }

        // given an array of integers, iterate and print its values
        public static void iterateArray(int[] arr)
        {
            foreach(int num in arr)
            {
                Console.WriteLine(num);
            }
        }

        // given an array of integers, print the max value in it
        public static void printMax(int[] arr)
        {
            int max = arr[0];
            int len = arr.Length;
            for(int i=1;i<len;i++)
            {
                if(arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine("Max value is {0}", max);
        }

        // given an array of integers, print the average of its values
        public static void printAverage(int[] arr)
        {
            double sum = 0;
            int len = arr.Length;
            for(int i=0;i<len;i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("The average of values is {0}", sum/len);
        }

        // create an array with all odd numbers from 1 to 255
        public static int[] arrayOdd()
        {
            int[] oddArray = new int[128];
            int num = 1;
            for(int i=0;i<128;i++)
            {
                oddArray[i] = num;
                num +=2;
            }
            return oddArray;
        }

        // given an array and a value y, return the number of values greater than y
        public static int greaterThanY(int[] arr, int y)
        {
            int counter = 0;
            int len = arr.Length;
            for(int i=0;i<len;i++)
            {
                if(arr[i] > y)
                {
                    counter++;
                }
            }
            return counter;
        }
        // given an array of integers, return the array with its values squared
        public static int[] squareArray(int[] arr)
        {
            int len = arr.Length;
            for(int i=0;i<len;i++)
            {
                arr[i] *= arr[i];
            }
            return arr;
        }

        // given an array of integers, replace any negative numbers with 0
        public static int[] zeroNegs(int[] arr)
        {
            int len = arr.Length;
            for(int i=0;i<len;i++)
            {
                if(arr[i] < 0)
                {
                    arr[i] = 0;
                }
            }
            return arr;
        }

        // given an array of integers, print the max and min values plus the average
        public static void minMaxAverage(int[] arr)
        {
            double sum = arr[0];
            int max = arr[0];
            int min = arr[0];
            int len = arr.Length;
            for(int i=1;i<len;i++)
            {
                sum += arr[i];
                if(arr[i] > max)
                {
                    max = arr[i];
                }
                if(arr[i] < min)
                {
                    min = arr[i];
                }
            }
            Console.WriteLine("Min is {0}, Max is {1}, and Average is {2}",min, max, sum/len);
        }

        // given an array of integers, shift its values left by one replacing the last with 0
        public static int[] shiftArray(int[] arr)
        {
            int len = arr.Length;
            for(int i=0;i<len-1;i++)
            {
                arr[i] = arr[i+1];
            }
            arr[len-1] = 0;
            return arr;
        }

        // given an array of integers, return an array with the negative numbers replace with a string
        public static object[] negativesToString(int[] arr)
        {
            int len = arr.Length;
            object[] noNegatives = new object[len];
            for(int i=0;i<len;i++)
            {
                if(arr[i] < 0)
                {
                    noNegatives[i] = "Negative";
                }
                else 
                {
                    noNegatives[i] = arr[i];
                }
            }
            return noNegatives;
        }
        static void Main(string[] args)
        {
            print1To255();
            printOddsTo255();
            printIntsWithSum();
            int[] testArr = new int[5]{8,3,-4,9,1};
            iterateArray(testArr);
            printMax(testArr);
            printAverage(testArr);
            int[] odds = arrayOdd();
            foreach(int val in odds)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine(greaterThanY(testArr, 4));
            int[] squared = squareArray(testArr);
            foreach(int val in squared)
            {
                Console.WriteLine(val);
            }
            int[] zeroed = zeroNegs(testArr);
            foreach(int val in zeroed)
            {
                Console.WriteLine(val);
            }
            minMaxAverage(testArr);
            int[] shifted = shiftArray(testArr);
            foreach(int val in shifted)
            {
                Console.WriteLine(val);
            }
            object[] stringed = negativesToString(testArr);
            for(int i=0;i<stringed.Length;i++)
            {
                Console.WriteLine(stringed[i]);
            }
        }
    }
}
