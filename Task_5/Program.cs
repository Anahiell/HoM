using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Task_5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // read from file
            List<int> numbers = ReadNumbersFromFile("Task_5.txt");

            // count factorial
            List<int> factorials = new List<int>();

            await Task.Run(() =>
            {
                Parallel.ForEach(numbers, number =>
                {
                    int factorial = CalculateFactorial(number);
                    factorials.Add(factorial);
                });
            });

            
            Console.WriteLine("Factorials:");
            foreach (var factorial in factorials)
            {
                Console.WriteLine(factorial);
            }

            Console.ReadKey();
        }

        static List<int> ReadNumbersFromFile(string filePath)
        {
            List<int> numbers = new List<int>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (int.TryParse(line, out int number))
                    {
                        numbers.Add(number);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return numbers;
        }

        static int CalculateFactorial(int n)
        {
            return ParallelEnumerable.Range(1, n).Aggregate(1, (acc, i) => acc * i);
        }
    }

}

