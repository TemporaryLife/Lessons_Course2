using System;

namespace HW2_Task2
{
    class Program
    {
        public class TestCase
        {
            public int[] inputArray { get; set; }
            public int searchValue { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            if (searchValue<=0)
            {
                throw new ArgumentException("Searching Value should be positive");
            }

            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        static void Test(TestCase testCase)
        {
            try
            {
                var actual = BinarySearch(testCase.inputArray, testCase.searchValue);
                if (actual==testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");

                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }

            }
            catch (Exception e)
            {
                if (testCase.ExpectedException != null && e.GetType() == testCase.ExpectedException.GetType())
                {
                    Console.WriteLine("Valid Test");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
        static void Main(string[] args)
        {
            var Test1 = new TestCase
            {
                inputArray = new int[] { 1, 3, 5, 7, 5, 9, 10 },
                searchValue = 5,
                Expected = 2,
                ExpectedException = null

            };
            var Test2 = new TestCase
            {
                inputArray = new int[] { 1, 3, 5, 7, 5, 9, 10 },
                searchValue = 11,
                Expected = -1,
                ExpectedException = null

            };
            var Test3 = new TestCase
            {
                inputArray = new int[] { 1, 3, 5, 7, 5, 9, 10 },
                searchValue = 3,
                Expected = 5,
                ExpectedException = null

            };
            var Test4 = new TestCase
            {
                inputArray = new int[] { 1, 3, 5, 7, 5, 9, 10 },
                searchValue = -1,
                Expected = -1,
                ExpectedException = new ArgumentException()

            };

            Test(Test1);
            Test(Test2);
            Test(Test3);
            Test(Test4);
        }
    }
}
