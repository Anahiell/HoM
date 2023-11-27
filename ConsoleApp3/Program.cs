using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chose what to start?\n1 - Server\n2 - Client");
            int x = int.Parse(Console.ReadLine());
            while (x != 0)
            {


                switch (x)
                {
                    case 1:
                        {
                            Start_Server();

                            break;
                        }
                    case 2:
                        {
                            Start_Client();
                            break;
                        }
                    default:
                        break;
                }
                Console.WriteLine("Chose what to start?\n1 - Server\n2 - Client");
                x = int.Parse(Console.ReadLine());
            }
        }
        static void Start_Server()
        {
            Console.WriteLine("Enter IP address for the server:");
            string ipAddressString = Console.ReadLine();

            IPAddress ipAddress;
            while (!IPAddress.TryParse(ipAddressString, out ipAddress))
            {
                Console.WriteLine("Invalid IP address. Please enter a valid IP address:");
                ipAddressString = Console.ReadLine();
            }

            Console.WriteLine("Enter port for the server:");
            string portString = Console.ReadLine();

            int port;
            while (!int.TryParse(portString, out port) || port < 0 || port > 65535)
            {
                Console.WriteLine("Invalid port. Please enter a valid port number (0-65535):");
                portString = Console.ReadLine();
            }

            IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Users\user\source\repos\ConsoleApp3\Server_Programme\bin\Debug\Server_programme.exe";
            startInfo.Arguments = $"{ipAddress} {port}"; // Передаем IP-адрес и порт как аргументы
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            Console.WriteLine($"Server started on {endPoint}");
        }
        static void Start_Client()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Users\user\source\repos\ConsoleApp3\Client_Programme\bin\Debug\Client_programme.exe";
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

        }
    }
}
