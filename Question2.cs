using System;
using System.Collections.Generic;
using System.Text;

namespace Test3
{
    class Question2
    {
        public Question2()
        {
            int flag;
            Console.WriteLine("Enter Minimum value: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Maximum value: ");
            int max = Convert.ToInt32(Console.ReadLine());
            if (min > max)
                Console.WriteLine("Invalid entry");
            else
            {
                Console.WriteLine("The prime numbers between the numbers {0} and {1} are:", min, max);               
                for(int i=min;i<=max;i++)
                {
                    flag = 0;
                    for (int j=2;j<i;j++)
                    {
                        if(i%j==0)
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                        Console.WriteLine(i);
                }

            }
        }
    }
}
