using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Client_Programme
{
    internal class Program
    {
        private const int bufferSize = 1024;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the server IP address:");
            string serverIpAddressString = Console.ReadLine();

            IPAddress serverIpAddress;
            while (!IPAddress.TryParse(serverIpAddressString, out serverIpAddress))
            {
                Console.WriteLine("Invalid server IP address. Please enter a valid IP address:");
                serverIpAddressString = Console.ReadLine();
            }

            Console.WriteLine("Enter the server port:");
            string portString = Console.ReadLine();

            int port;
            while (!int.TryParse(portString, out port) || port < 0 || port > 65535)
            {
                Console.WriteLine("Invalid port. Please enter a valid port number (0-65535):");
                portString = Console.ReadLine();
            }

            try
            {
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    clientSocket.Connect(new IPEndPoint(serverIpAddress, port));
                    Console.WriteLine($"Connected to the server {serverIpAddress}:{port}");

                    // Отправка и прием сообщений в асинхронном режиме
                    _ = Task.Run(() => ReceiveMessages(clientSocket));

                    while (true)
                    {
                        Console.Write("Enter a message (type 'bye' to exit): ");
                        string message = Console.ReadLine();

                        byte[] data = Encoding.ASCII.GetBytes(message);
                        clientSocket.Send(data);

                        if (message.ToLower() == "bye")
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }

        static async Task ReceiveMessages(Socket clientSocket)
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[bufferSize];
                    int bytesRead = clientSocket.Receive(buffer);

                    if (bytesRead == 0)
                    {
                        Console.WriteLine("Server disconnected.");
                        break;
                    }

                    string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received from the server: {receivedMessage}");
                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    Console.WriteLine("Socket is disposed.");
                }
                else
                {
                    Console.WriteLine($"Error receiving messages: {ex.Message}");
                }
            }
        }
    }
}