using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potock_HMW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("We are like deamons!!! Choese one (1-4) ");
            int x = int.Parse(Console.ReadLine());
            while (x != 0)
            {
                switch (x)
                {
                    case 1:
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "C:\\Users\\user\\source\\repos\\Potock_HMW\\Task#1\\bin\\Debug\\Task#1.exe";
                            Console.WriteLine("Starting Task_1...");
                            process.Start();
                            process.WaitForExit();
                            Console.WriteLine("Task_1 has finished.");
                            break;
                        }
                    case 2:
                        {
                            Process process1 = new Process();
                            process1.StartInfo.FileName = "C:\\Users\\user\\source\\repos\\Potock_HMW\\Task#1\\bin\\Debug\\Task#1.exe";
                            Console.WriteLine("Starting Task_2...");
                            process1.Start();
                            process1.WaitForExit();
                            Console.WriteLine("Task_2 has finished.");
                            break;
                        }
                    case 3:
                        {
                            Process process2 = new Process();
                            process2.StartInfo.FileName = "C:\\Users\\user\\source\\repos\\Potock_HMW\\Taskk#3\\bin\\Debug\\Taskk#3.exe";
                            Console.WriteLine("Starting Task_3...");
                            process2.Start();
                            process2.WaitForExit();
                            Console.WriteLine("Task_3 has finished.");
                            break;
                        }
                    case 4:
                        {
                            Process process3 = new Process();
                            process3.StartInfo.FileName = "C:\\Users\\user\\source\\repos\\Potock_HMW\\Task#4\\bin\\Debug\\Task#4.exe";
                            Console.WriteLine("Starting Task_4...");
                            process3.Start();
                            process3.WaitForExit();
                            Console.WriteLine("Task_4 has finished.");
                            break;
                        }
                    default:
                        break;
                }
                Console.WriteLine("Chouse:");
                x = int.Parse(Console.ReadLine());
            }
        }
    }
}
