using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: YourApp.exe <file_path> <search_word>");
                Console.ReadLine();
                return;
            }

            string filePath = args[0];
            string searchWord = args[1];
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл '{filePath}' отсуцтвует.\n");
                return;
            }

            int wordCount = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    wordCount += CountWordOccurrences(line, searchWord);
                }
            }
        }

        static int CountWordOccurrences(string text, string word)
        {
            int wordCount = 0;
            int index = 0;
            while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                wordCount++;
                index += word.Length;
            }
            return wordCount;
        }
    }
}
