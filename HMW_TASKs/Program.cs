using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace HMW_TASKs
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("chouse the task:");
            int x = int.Parse(Console.ReadLine());
            while (x != 0)
            {
                switch (x)
                {
                    case 1:
                        {
                            //задание 1-2
                            string path = @"C:\Users\Monkiell\OneDrive\Рабочий стол\системное прогр\HoM\Task_1\bin\Debug\Task_1.exe";
                            Process task1 = new Process();
                            task1.StartInfo.FileName = path;
                            task1.Start();
                            task1.WaitForExit();
                            break;
                        }
                    case 2:

                        {

                            string pathToProject3 = @"C:\Users\Monkiell\OneDrive\Рабочий стол\системное прогр\HoM\Task_3\bin\Debug\Task_3.exe";
                            string pathToProject4 = @"C:\Users\Monkiell\OneDrive\Рабочий стол\системное прогр\HoM\Task_4\bin\Debug\Task_4.exe";
                            string pathToProject5 = @"C:\Users\Monkiell\OneDrive\Рабочий стол\системное прогр\HoM\Task_5\bin\Debug\Task_5.exe";
                            string pathToProject6 = @"C:\Users\Monkiell\OneDrive\Рабочий стол\системное прогр\HoM\Task_6\bin\Debug\Task_6.exe";


                            var tasks = new List<Task>
                         {
                             Task.Run(() => { Process.Start(pathToProject3); }),
                            Task.Run(() => { Process.Start(pathToProject4); }),
                            Task.Run(() => { Process.Start(pathToProject5); }),
                             Task.Run(() => { Process.Start(pathToProject6); })
                         };

                            // wait all tasks

                            await Task.WhenAll(tasks);

                            break;
                        }

                    default:
                        break;
                }
                Console.WriteLine("chouse the task:");
                 x = int.Parse(Console.ReadLine());
            }
        }

    }
}
