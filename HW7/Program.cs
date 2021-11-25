using System;
using System.Collections.Generic;
using System.Linq;

namespace Geekbrains
{
   class Program
   {
       const int N = 5;
       const int M = 5;

        static int[,] ToFillArray(int M, int N)    //Начальное заполнение массива
        {
            var rnd = new Random();
            int[,] result_array = new int[M, N];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    var a=rnd.Next(0, 5);
                    if (a!=0) a=1;
                    result_array[i, j] = a;
                    Console.Write(result_array[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
            return result_array;

        }

        static int[,] ToFindPaths(int M, int N, int[,] input_array)
        {
            bool flag = true;
            var result_array = input_array;

            for (int i = 0; i < M; i++)
            {

                if (result_array[0, i] == 0) flag = false;
                result_array[0, i] = Convert.ToInt32(flag);

            }

            flag = true;

            for (int j = 0; j < N; j++)
            {
                if (result_array[j, 0] == 0) flag = false;            
                result_array[j, 0] = Convert.ToInt32(flag);
            }

            for (int i = 1; i < M; i++)
            {
                for (int j = 1; j < N; j++)
                {

                    if (input_array[i, j] != 0)
                    {
                        result_array[i, j] = result_array[i - 1, j] + result_array[i, j - 1];
                    }
                }
            }

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    Console.Write(result_array[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
            return result_array;
        }

        static void Main(string[] args)
        {

            var a = ToFillArray(M, N);
            Console.WriteLine("\n\n\n\n");
            ToFindPaths(M, N, a);
        }
    }
}

