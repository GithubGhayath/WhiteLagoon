using System;
using System.Collections.Generic;
using System.Text;

namespace WhiteLagoon.Application
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GetAllEvenNumberIn10Range(n => n % 2 == 0);
        }

        public static void GetAllEvenNumberIn10Range(Func<int, bool> IsEven)
        {
            for (int i = 0; i <= 10; i++) 
            {
                if(IsEven(i))
                    Console.WriteLine(i);
            }
        }
    }
}
