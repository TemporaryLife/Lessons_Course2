using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {

        public class Testing
        {
            public int N;
            public int ExpectedValue;
            public Exception ExpectedException;
        }

        static void Main(string[] args)
        {
            var TestCase1 = new Testing()
            {
                N = 7,
                ExpectedValue = 8,
                ExpectedException = null

            };

            var TestCase2 = new Testing()
            {
                N = -1,
                ExpectedValue = 3,
                ExpectedException = new ArgumentException()

            };

            var TestCase3 = new Testing()
            {
                N = 10,
                ExpectedValue = 34,
                ExpectedException = null

            };
            var TestCase4 = new Testing()
            {
                N = 10,
                ExpectedValue = 42,
                ExpectedException = null

            };

            var TestCase5 = new Testing()
            {
                N = 5,
                ExpectedValue = 11,
                ExpectedException = new ArgumentException()

            };


            TestFibo(TestCase1);
            TestFibo(TestCase2);
            TestFibo(TestCase3);
            TestFibo(TestCase4);
            TestFibo(TestCase5);
            Console.ReadLine();
        }

        static long Fibo_Recursion(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Number should be more than 0");

            }

            if (n == 1)
            {
                return 0;
            }
            else if (n == 2)
            {
                return 1;
            }
            else
            {
                return (Fibo_Recursion(n - 1) + Fibo_Recursion(n - 2));
            }
        }

        static int Fibo_Cycle(int n)
        {
            int result = 1;
            int first_number = 0;
            int second_number = 1;
            if (n <= 0)
            {
                throw new ArgumentException();
            }
            if (n==1)
            {
                return 0;
            }
            else if (n == 2)
            {
                return 1;
            }
            else
            {
                for (int i = 2; i < n; i++)
                {

                    result = first_number + second_number;
                    first_number = second_number;
                    second_number = result;
                }

                return second_number;
            }
        }
        static void TestFibo(Testing TestCase)
        {
            try
            {
                
                var actual_value = Fibo_Cycle(TestCase.N);
                if (actual_value == TestCase.ExpectedValue)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine(("INVALID TEST"));
                }

            }
            catch (ArgumentException ex)
            {
                if (ex.GetType() == TestCase.ExpectedException.GetType()&& TestCase.ExpectedException!=null)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine(("INVALID TEST"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid test");
            }
        }
    }
}
