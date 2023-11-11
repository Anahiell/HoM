using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadNumbersFromFile("Task_6.txt");

            int maxLength = FindMaxLengthOfIncreasingSequence(numbers);

            // Виведення результату
            Console.WriteLine($"Max length grovestep: {maxLength}");

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

        static int FindMaxLengthOfIncreasingSequence(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                return 0;
            }

            int maxLength = numbers.AsParallel().AsOrdered()
                .Select((num, index) => new { num, index })
                .Aggregate(
                    new { length = 1, prevIndex = 0, maxLength = 1 },
                    (acc, current) =>
                    {
                        int currentLength = (current.num > numbers[acc.prevIndex]) ? acc.length + 1 : 1;
                        return new { length = currentLength, prevIndex = current.index, maxLength = Math.Max(acc.maxLength, currentLength) };
                    },
                    result => result.maxLength);

            return maxLength;
        }
    }
}
