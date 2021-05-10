using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test3
{
    class Question7
    {
        public static List<int> numbers = new List<int>();
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public Question7()
        {
            int num, count = 0, sum=0, rev=0;
            var input = Console.ReadLine();
            var line = Reverse(input);
            var numbers = line.Split(" ");
            foreach (var number in numbers)
            {
                int numb;
                if (Int32.TryParse(number, out numb))
                {
                    Console.WriteLine(numb);
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        sum = numbers[i][j] + numbers[i][j];
                        if (sum > 10)
                        {
                            num = sum;
                            sum = 0;
                            while (num != 0)
                            {
                                rev = num % 10;
                                sum = sum + rev;
                                num = num / 10;
                            }
                        }
                        count = count + sum;
                    }
                    else
                        count = count + numbers[i][j];
                }
            }
            //Console.WriteLine("The count is:" + count);
            if (count % 10 == 0)
                Console.WriteLine("Valid card!!");
            else
                Console.WriteLine("Invalid card!!");           
        }
    }
}
