using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HMW_task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chouse task:");
            Console.WriteLine("1 - task 1,2,3\n2 - task 4\n3 - HMW about Fibonacci ");
            int var=Int32.Parse(Console.ReadLine());
            switch (var)
            {
                case 1:
                    {
                        int num1 = 1;
                        int num2 = 2;
                        char sign = '+';
                        string[] arguments = new string[] { num1.ToString(), num2.ToString(), sign.ToString() };
                        Process process = new Process();
                        process.StartInfo = new ProcessStartInfo(@"C:\Users\user\source\repos\HMW_task#1\some_sume\bin\Debug\some_sume.exe");
                        process.StartInfo.Arguments = string.Join(" ", arguments); 
                        try
                        {
                            process.Start();
                            process.WaitForExit();
                            int ex = process.ExitCode;
                            Console.WriteLine(ex);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Произошла ошибка: " + ex.Message);
                        }
                        break;
                    }
                case 2:
                    {
                        string filePath = @"C:\Users\user\source\repos\HMW_task#1\Serching\text.txt";
                        string searchWord = "darkness";

                        Process process = new Process();
                        process.StartInfo.FileName = @"C:\Users\user\source\repos\HMW_task#1\Serching\bin\Debug\Serching.exe";
                        process.StartInfo.Arguments = $"\"{filePath}\" \"{searchWord}\"";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.CreateNoWindow = true;

                        process.Start();

                        string output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();

                        Console.WriteLine($"Слово '{searchWord}' в файлк '{filePath}' {output} раз.");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Fibonacci and Prime num:");
                        Process process = new Process();
                        process.StartInfo.FileName = @"C:\Users\user\source\repos\HMW_task#1\Febanche\bin\Debug\Febanche.exe";
                        process.StartInfo.Arguments = "";
                        process.Start();
                        process.WaitForExit();
                        
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
