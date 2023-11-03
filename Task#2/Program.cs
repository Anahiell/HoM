using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main()
        {
            string filePath = "input.txt";

            Thread countThread = new Thread(() => CountAndModify(filePath));
            Thread modifyThread = new Thread(() => ModifyFile(filePath));

            countThread.Start();
            countThread.Join();
            modifyThread.Start();
            modifyThread.Join();
        }

        static void CountAndModify(string filePath)
        {
            int count = 0;
            if(!File.Exists(filePath))
            {
                File.Create(filePath).Close();  
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                count = content.Count(c => c == '!');
            }

            Console.WriteLine($"Number of '!' characters: {count}");
        }

        static void ModifyFile(string filePath)
        {
            string content = File.ReadAllText(filePath);
            content = content.Replace('!', '#');
            File.WriteAllText(filePath, content);
            Console.WriteLine("File modified!");
        }
    }
}
