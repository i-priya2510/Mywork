using System;
using System.Collections.Generic;
using System.Text;

namespace Test3
{
    class Question3
    {
        public Question3()
        {
            List<int> numbers = new List<int>();
            int number = 0, count;
            Console.WriteLine("Please enter a numbers. Enter a negative number to quite(example -1)");
            do
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number >= 0)
                    numbers.Add(number);
            } while (number > 0);
            Console.WriteLine("The repeating numbers are:");
            for(int i=0;i<numbers.Count;i++)
            {
                count = 0;
                for(int j=i;j<numbers.Count;j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                    }
                }
                if (count > 1)
                    Console.WriteLine(numbers[i]);
            }
        }
    }
}
