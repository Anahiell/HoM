using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HMW_TASKs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("chouse the task:");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1:
                    {
                        string path = @"C:\Users\Monkiell\OneDrive\Рабочий стол\системное прогр\HoM\Task_1\bin\Debug\Task_1.exe";
                        Process task1 = new Process();
                        task1.StartInfo.FileName = path;
                        task1.Start();
                        break;
                    }
                case 2:
                    {

                        break;
                    }
                default:
                    break;
            }
        }
    }
}
