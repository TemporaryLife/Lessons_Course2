using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp1
{
    
    
    public struct PointStructDouble
    {

        public double X;
        public double Y;
    }
    public class PointClassFloat
    {
        public float X;
        public float Y;
    }
    public struct PointStructFloat
    {
        public float X;
        public float Y;
    }
    public class TheEasiestBenchmark
    {



        public float DistanceClassFloat(PointClassFloat x, PointClassFloat y)

        {
            float X = y.X - x.X;
            float Y = y.Y - x.Y;
            return (float)Math.Sqrt((X * X) + (Y * Y));
        }

        


        
        public float DistanceStructFloat(PointStructFloat x, PointStructFloat y)

        {
            float X = y.X - x.X;
            float Y = y.Y - x.Y;
            return (float)Math.Sqrt((X * X) + (Y * Y));
        }

        
        public double DistanceStructDouble(PointStructDouble x, PointStructDouble y)

        {
            double X = y.X - x.X;
            double Y = y.Y - x.Y;
            return Math.Sqrt((X * X) + (Y * Y));
        }

        
        public float NoSQRT_DistanceStructFloat(PointStructFloat x, PointStructFloat y)

        {
            float X = y.X - x.X;
            float Y = y.Y - x.Y;
            return (X * X) + (Y * Y);
        }

        [Benchmark]
        public void a()
        {
            DistanceClassFloat(new PointClassFloat { X = double_array, Y = 2 }, new PointClassFloat { X = 2, Y = 1 });
        }
        [Benchmark]
        public void b()
        {
            DistanceStructFloat(new PointStructFloat { X = 3, Y = 2 }, new PointStructFloat { X = 2, Y = 1 });
        }

    }




    class Program
    {
        public static List<double> double_array=new List<double>();
        public static List<float> float_array=new List<float>();
        static void Main(string[] args)
        {
            int size = 20;
            var rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                double_array.Add((double)rnd.Next(100));
                float_array.Add((float)rnd.Next(100));
            }
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }


        

    }
 
}
