using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        
        private static object fileLock = new object();
        private static ManualResetEvent numbersGenerated = new ManualResetEvent(false);

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Thread generatorThread = new Thread(GenerateAndSaveNumbers);
            Thread sumThread = new Thread(CalculateSum);
            Thread productThread = new Thread(Mult);

            generatorThread.Start();

            
            generatorThread.Join();

            sumThread.Start();
            productThread.Start();

            //  потоки CalculateSum и Mult ждут numbersGenerated.
            sumThread.Join();
            productThread.Join();
        }

        static void GenerateAndSaveNumbers()
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter("numbers.txt"))
            {
                for (int i = 0; i < 10; i++)
                {
                    int num1 = random.Next(1, 101);
                    int num2 = random.Next(1, 101);
                    writer.WriteLine($"{num1} {num2}");
                }
            }

            //закончили
            numbersGenerated.Set();
        }

        static void CalculateSum()
        {
            numbersGenerated.WaitOne(); // wait

            List<int> sum = new List<int>();
            using (StreamReader reader = new StreamReader("numbers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] numbers = line.Split(' ');
                    int num1 = int.Parse(numbers[0]);
                    int num2 = int.Parse(numbers[1]);
                    sum.Add(num1 + num2);
                }
            }

            using (StreamWriter writer = new StreamWriter("sum.txt"))
            {
                int d = 1;
                foreach (int s in sum)
                {
                    writer.WriteLine($"Sum {d}: {s}");
                    d++;
                }
            }
        }

        static void Mult()
        {
            numbersGenerated.WaitOne(); // waiting

            List<int> multis = new List<int>();
            using (StreamReader reader = new StreamReader("numbers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] numbers = line.Split(' ');
                    int num1 = int.Parse(numbers[0]);
                    int num2 = int.Parse(numbers[1]);
                    multis.Add(num1 * num2);
                }
            }

            using (StreamWriter writer = new StreamWriter("product.txt"))
            {
                int i = 1;
                foreach (int m in multis)
                {
                    writer.WriteLine($"Mult {i}: {m}");
                    i++;
                }
            }
        }
    }
}
