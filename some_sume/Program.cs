using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace some_sume
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: some_sume.exe <num1> <num2> <operation>");
                Console.ReadLine();
                return;
            }
            int num1 = int.Parse(args[0]);
            int num2 = int.Parse(args[1]);
            char operation = char.Parse(args[2]);

            if (operation == '+')
            {
                Console.WriteLine($"{num1} {operation} {num2} = {num1 + num2}");
            }
            else
            {
                Console.WriteLine($"{num1} {operation} {num2} = {num1 - num2}");
            }
            Console.ReadLine();
        }
    }
}
