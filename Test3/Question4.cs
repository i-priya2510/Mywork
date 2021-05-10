using System;
using System.Collections.Generic;
using System.Text;

namespace Test3
{
    class Question4
    {
        public Question4()
        {
            List<int> numbers = new List<int>();
            int number = 0;
            Console.WriteLine("Please enter a numbers. Enter a zero to quite");
            do
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number > 0)
                    numbers.Add(number);
            } while (number != 0);
            Console.WriteLine("The numbers after sorting are:");
            if (numbers != null)
                numbers.Sort();
            else
                Console.WriteLine("The collection is empty");
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
