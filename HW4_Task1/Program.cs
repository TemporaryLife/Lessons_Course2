using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HW4_Task1
{
    
    class Program
    {

        static void Main(string[] args)
        {



            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);


        }

    }

    public class Test
    {
       public  HashSet<string> hs = new HashSet<string>();
        static Random rnd = new Random();
        static int length = rnd.Next(10000, 20000);
        public string[] arr = new string[length];

        static char GenerateChar(Random rnd)
        {
            return (char)rnd.Next('A', 'Z' + 1);
        }

        static string GenerateString(Random rnd, int length)
        {
            char[] letters = new char[length];
            for (int i = 0; i < length; i++)
            {
                letters[i] = GenerateChar(rnd);
            }

            return new string(letters);
        }
        public Test()
        {
            for (int i = 0; i < length; i++)
            {
                arr[i] = GenerateString(rnd, rnd.Next(1, 10));
                hs.Add(arr[i]);
            }
        }
    }

    public class BenchClass
    {

        public static Test h = new Test();
        public BenchClass()
        {
            h = new Test();
        }


        public bool IsEqArr(string[] source_array, string FindingString)
        {
            return source_array.Contains(FindingString);

        }

        public bool IsEqHS(HashSet<string> source_HS, string FindingString)
        {
            return source_HS.Contains(FindingString);

        }

        [Params("ABC", "CDE", "EFG")]
        public string arg;
        [Benchmark]
        public void Meth1()
        {
            IsEqArr(h.arr, arg);
        }

        [Benchmark]
        public void Meth2()
        {
            IsEqHS(h.hs, arg);
        }
    }
}
