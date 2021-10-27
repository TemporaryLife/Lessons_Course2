using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-----------------------ATTENTION--------------- Задание 2 - сложность функции равна   O(N^3+2)
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());
            int d = 0, i = 2;
            while (i<n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;

            }

            if (d == 0)
            {
                Console.WriteLine("Простое");
            }
            else
            {
                Console.WriteLine("Не простое");
            }    
        
        }
    }
}
