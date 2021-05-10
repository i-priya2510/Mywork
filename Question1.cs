using System;
using System.Collections.Generic;
using System.Text;

namespace Test3
{
    class Question1
    {
        public Question1()
        {
            Console.WriteLine("Enter the numbers: ");
            List<int> numbers = new List<int>();
            for(int i=0;i<10;i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number%7==0)
                    numbers.Add(number);
            }
            Console.WriteLine("The numbers divisble by 7 are :");
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
