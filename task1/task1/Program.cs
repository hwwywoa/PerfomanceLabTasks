using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrLenght;
            int interval;
            int firstElement;
            string result = null;

            arrLenght = Int32.Parse(args[0]);
            interval = Int32.Parse(args[1]);
            int difference = arrLenght - interval;

            int[] array = new int[arrLenght];
            int[] tempArray = new int[interval];

            int j = 1;
            for (int i = 0; i < arrLenght; i++)
            {
                array[i] = j;
                j++;
            }

            firstElement = array[0];

            for (int i = 0; i < interval; i++)
            {
                tempArray[i] = array[i];
            }

            result += tempArray[0].ToString();

            while (firstElement != tempArray[tempArray.Length - 1])
            {
                Array.Copy(array, array.GetUpperBound(0) - difference, array, array.GetLowerBound(0), difference + 1);

                Array.Copy(tempArray, tempArray.GetLowerBound(0), array, array.GetLowerBound(0) + difference + 1, interval - 1);

                for (int i = 0; i < interval; i++)
                {
                    tempArray[i] = array[i];
                }

                result += tempArray[0].ToString();
            }

            Console.WriteLine(result);
        }
    }
}
