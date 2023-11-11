using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // some num
            int number = 12345;

            var factorialTask = Task.Run(() => CalculateFactorial(number));
            var digitCountTask = Task.Run(() => CountDigits(number));
            var digitSumTask = Task.Run(() => SumDigits(number));

            // wait all 
            await Task.WhenAll(factorialTask, digitCountTask, digitSumTask);

           
            Console.WriteLine($"Number: {number}");
            Console.WriteLine($"Factorial: {factorialTask.Result}");
            Console.WriteLine($"Count of cifri: {digitCountTask.Result}");
            Console.WriteLine($"Summ cifri: {digitSumTask.Result}");
            Console.ReadKey();
        }

        static int CalculateFactorial(int n)
        {
            return ParallelEnumerable.Range(1, n).Aggregate(1, (acc, i) => acc * i);
        }

        static int CountDigits(int number)
        {
            return ParallelEnumerable.Range(1, number.ToString().Length).Count();
        }

        static int SumDigits(int number)
        {
            object lockObject = new object();
            int sum = 0;

            Parallel.ForEach(number.ToString(), digit =>
            {
                int digitValue = int.Parse(digit.ToString());

                lock (lockObject)
                {
                    sum += digitValue;
                }
            });

            return sum;
        }
    }
}
