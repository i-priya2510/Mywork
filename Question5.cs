using System;
using System.Collections.Generic;
using System.Text;

namespace Test3
{
    class Question5
    {
        public Question5()
        {
            int count = 0;
            do
            {
                Console.WriteLine("Please enter the username");
                string user = Console.ReadLine();
                Console.WriteLine("Please enter the password");
                string pass = Console.ReadLine();
                if (string.Compare(user, "Admin") == 0 && string.Compare(pass, "admin") == 0)
                {
                    Console.WriteLine("Welcome");
                    count = 5;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Try again..");
                    count++;
                }
            } while (count < 3);
            if (count > 3)
                Console.WriteLine("Sorry you have already tried 3 times");
        }
    }
}
