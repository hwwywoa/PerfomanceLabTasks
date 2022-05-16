using System;
using System.IO;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumOfNums = 0;
            int result = 0;

            string[] nums = File.ReadAllLines(args[0]);

            //находим число для приведения
            foreach (string num in nums)
            {
                sumOfNums += Int32.Parse(num);
            }

            int numToCast = sumOfNums / nums.Length;

            //кнвертация массива string в int

            int[] intNums = new int[nums.Length];

            int i = 0;

            foreach (string num in nums)
            {
                intNums[i] = Int32.Parse(num);

                i++;
            }

            int j = 0;

            foreach (int num in intNums)
            {
                while (intNums[j] != numToCast)
                {
                    if (intNums[j] < numToCast)
                    {
                        intNums[j]++;
                        result++;
                    }
                    else if (intNums[j] > numToCast)
                    {
                        intNums[j]--;
                        result++;
                    }
                }
                j++;
            }
            Console.WriteLine(result);
        }
    }
}
