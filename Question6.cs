using System;
using System.Collections.Generic;
using System.Text;

namespace Test3
{
    class Question6
    {
        public Question6()
        {
            String[] w = new string[5] { "kite", "four", "neat", "play", "goal" };

            //for (int i=0;i<4;i++)
            //Console.WriteLine(words[0][0]);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4;)
                {
                    int cow = 0;
                    int bull = 0;
                    Console.WriteLine("Enter the Guess: ");
                    string s = Console.ReadLine();
                    char[] c = s.ToCharArray();
                    for (int k = 0; k < 3;)
                    {
                        if (c[k] == w[i][k]) cow = cow + 1;
                        else if (c[k] == w[i][0] || c[k] == w[i][1] || c[k] == w[i][2] || c[k] == w[i][3]) bull = bull + 1;
                        else k++;

                    }

                    Console.WriteLine("cows-" + cow + " bulls-" + bull);

                    if (cow == 4 && bull == 0)
                    {
                        Console.WriteLine("You win!!!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Try again");
                        j++;
                    }
                }
                Console.WriteLine("You Lost");
            }

        }
    }
}
