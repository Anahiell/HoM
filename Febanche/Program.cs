using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Febanche
{
    internal class Program
    {
        static Thread febThread;
        static Thread pThread;
        static bool stopFeb;
        static bool stopPrime;

        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Запустить генерацию чисел Фибоначчи");
            Console.WriteLine("2 - Запустить генерацию простых чисел");
            Console.WriteLine("3 - Остановить генерацию чисел Фибоначчи");
            Console.WriteLine("4 - Остановить генерацию простых чисел");
            Console.WriteLine("5 - Выйти");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        if (febThread == null || !febThread.IsAlive)
                        {
                            stopFeb = false;
                            febThread = new Thread(StartFThread);
                            febThread.Start();
                        }
                        break;
                    case ConsoleKey.D2:
                        StartPThread();
                        break;
                    case ConsoleKey.D3:
                        StopFThread();
                        break;
                    case ConsoleKey.D4:
                        StopPThread();
                        break;
                    case ConsoleKey.D5:
                        return;
                    default:
                        break;
                }
            }
        }

        static void StartFThread()
        {
            int a = 0, b = 1;
            while (!stopFeb)
            {
                Console.WriteLine($"Fibonacci: {a}");
                int temp = a;
                a = b;
                b = temp + b;
                Thread.Sleep(1000);
            }
        }

        static void StartPThread()
        {
            if (febThread == null || !febThread.IsAlive)
            {
                stopPrime = false;
                pThread = new Thread(() =>
                {
                    int number = 2;
                    while (!stopPrime)
                    {
                        if (IsPrime(number))
                        {
                            Console.WriteLine($"Prime: {number}");
                        }
                        number++;
                        Thread.Sleep(1000);
                    }
                });
                pThread.Start();
            }
        }

        static void StopFThread()
        {
            stopFeb = true;
        }

        static void StopPThread()
        {
            stopPrime = true;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number <= 3)
                return true;
            if (number % 2 == 0 || number % 3 == 0)
                return false;
            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }
            return true;
        }
    }
}
