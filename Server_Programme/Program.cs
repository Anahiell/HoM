using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Programme
{
    internal class Program
    {
        // Используем словарь для хранения информации о клиентах
        private static ConcurrentDictionary<string, Socket> clients = new ConcurrentDictionary<string, Socket>();

        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t!!!THIS IS SERVER!!!");

            IPAddress ip = IPAddress.Parse(args[0]);
            int port = int.Parse(args[1]);

            IPEndPoint endP = new IPEndPoint(ip, port);
            Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endP);
            socket.Listen(10);
            Console.WriteLine($"!Сервер запущен на {endP}!");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Socket clientSocket = await socket.AcceptAsync();
                string clientInfo = $"{((IPEndPoint)clientSocket.RemoteEndPoint).Address}:{((IPEndPoint)clientSocket.RemoteEndPoint).Port}";

                if (clients.TryAdd(clientInfo, clientSocket))
                {
                    Console.WriteLine($"Подключен клиент {clientInfo}");
                    _ = Task.Run(() => HandleClientAsync(clientSocket, clientInfo));
                }
                else
                {
                    Console.WriteLine($"Ошибка добавления клиента {clientInfo}");
                    clientSocket.Close();
                }
            }
        }

        static async Task HandleClientAsync(Socket clientSocket, string clientInfo)
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await clientSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

                    if (bytesRead == 0)
                        break;

                    string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Получено сообщение от {clientInfo}: {receivedMessage}");

                    if (receivedMessage.ToLower() == "bye")
                    {
                        Console.WriteLine($"Соединение с {clientInfo} завершено.");
                        clients.TryRemove(clientInfo, out _);
                        clientSocket.Shutdown(SocketShutdown.Both);
                        clientSocket.Close();
                        break;
                    }

                    Console.Write($"Отправить ответ клиенту {clientInfo}: ");
                    string responseMessage = Console.ReadLine();
                    byte[] responseBytes = Encoding.ASCII.GetBytes(responseMessage);
                    await clientSocket.SendAsync(new ArraySegment<byte>(responseBytes), SocketFlags.None);

                    if (responseMessage.ToLower() == "bye")
                    {
                        Console.WriteLine($"Соединение с {clientInfo} завершено.");
                        clients.TryRemove(clientInfo, out _);
                        clientSocket.Shutdown(SocketShutdown.Both);
                        clientSocket.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обработки клиента {clientInfo}: {ex.Message}");
            }
        }
    }
}