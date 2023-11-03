using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Taskk_3
{
    class Program
    {
        static Mutex mutex = new Mutex();
        static ManualResetEvent firstDone = new ManualResetEvent(false);
        static ManualResetEvent secondDone = new ManualResetEvent(false);

        static void Main()
        {
            Thread generateThread = new Thread(GenerateAndSaveNumbers);
            Thread processThread1 = new Thread(ProcessNumbers);
            Thread processThread2 = new Thread(ProcessNumbersEndingWithSeven);

            generateThread.Start();
            processThread1.Start();
            processThread2.Start();

            generateThread.Join();
            processThread1.Join();
            processThread2.Join();
        }

        static void GenerateAndSaveNumbers()
        {
            Random random = new Random();
            mutex.WaitOne();
            using (StreamWriter writer = new StreamWriter("numbers.txt"))
            {
                for (int i = 0; i < 10; i++)
                {
                    int num = random.Next(1, 101);
                    writer.WriteLine(num);
                }
            }
            mutex.ReleaseMutex();
            firstDone.Set(); //end 1thread
        }

        static void ProcessNumbers()
        {
            firstDone.WaitOne(); // waiting
            List<int> primes = new List<int>();
            mutex.WaitOne();
            using (StreamReader reader = new StreamReader("numbers.txt"))
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
            using (StreamWriter writer = new StreamWriter("primes.txt"))
            {
                foreach (int prime in primes)
                {
                    writer.WriteLine(prime);
                }
            }
            mutex.ReleaseMutex();
            secondDone.Set(); // second thread finish
        }

        static void ProcessNumbersEndingWithSeven()
        {
            secondDone.WaitOne(); // waiting second thread
            List<int> primesEndingWithSeven = new List<int>();
            mutex.WaitOne();
            using (StreamReader reader = new StreamReader("primes.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int num = int.Parse(line);
                    if (num % 10 == 7)
                    {
                        primesEndingWithSeven.Add(num);
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter("primesWith7.txt"))
            {
                foreach (int prime in primesEndingWithSeven)
                {
                    writer.WriteLine(prime);
                }
            }
            mutex.ReleaseMutex();
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
