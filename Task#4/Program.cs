using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static AutoResetEvent generateDone = new AutoResetEvent(false);
        static AutoResetEvent processDone = new AutoResetEvent(false);

        static void Main()
        {
            Thread generateThread = new Thread(GenerateAndSaveNumbers);
            Thread processThread = new Thread(ProcessNumbers);
            Thread reportThread = new Thread(GenerateReport);

            generateThread.Start();
            generateThread.Join(); // Дождаться завершения генерации чисел

            processThread.Start();
            processThread.Join(); // Дождаться завершения обработки чисел

            reportThread.Start();
            reportThread.Join(); // Дождаться завершения создания отчета
        }

        static void GenerateAndSaveNumbers()
        {
            Random random = new Random();
            using (var writer = new StreamWriter("numbers.txt"))
            {
                for (int i = 0; i < 10; i++)
                {
                    int num = random.Next(1, 101);
                    writer.WriteLine(num);
                }
            }
            generateDone.Set(); // Сигнализировать о завершении генерации чисел
        }

        static void ProcessNumbers()
        {
            generateDone.WaitOne(); // Ждать сигнала о завершении генерации чисел
            List<int> primes = new List<int>();
            using (var reader = new StreamReader("numbers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int num = int.Parse(line);
                    if (IsPrime(num))
                    {
                        primes.Add(num);
                    }
                }
            }
            using (var writer = new StreamWriter("primes.txt"))
            {
                foreach (int prime in primes)
                {
                    writer.WriteLine(prime);
                }
            }
            processDone.Set(); // Сигнализировать о завершении обработки чисел
        }

        static void GenerateReport()
        {
            processDone.WaitOne(); // Ждать сигнала о завершении обработки чисел

            int numbersCount = File.ReadLines("numbers.txt").Count();
            int primesCount = File.ReadLines("primes.txt").Count();
            long numbersFileSize = new FileInfo("numbers.txt").Length;
            long primesFileSize = new FileInfo("primes.txt").Length;

            using (var reportWriter = new StreamWriter("report.txt"))
            {
                reportWriter.WriteLine($"Numbers file contains {numbersCount} numbers.");
                reportWriter.WriteLine($"Primes file contains {primesCount} primes.");
                reportWriter.WriteLine($"Numbers file size: {numbersFileSize} bytes.");
                reportWriter.WriteLine($"Primes file size: {primesFileSize} bytes.");

                reportWriter.WriteLine("Numbers content:");
                reportWriter.WriteLine(File.ReadAllText("numbers.txt"));
                reportWriter.WriteLine("Primes content:");
                reportWriter.WriteLine(File.ReadAllText("primes.txt"));
            }
        }

     

    static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num <= 3) return true;
            if (num % 2 == 0 || num % 3 == 0) return false;
            for (int i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
