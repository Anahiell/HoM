using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
//my lib
using SquareLib;
using TextMangLib;
using UserMangerLib;
using FileWorkerLib;

namespace TestMyLib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region SquareLib
            Console.WriteLine("Test Librari of Square");
            double side = 3;
            double length = 6.1;
            double width = 4.5;
            double baseTriangle = 3.4;
            double heightTriangle = 7.8;

            double squareArea = Square.SquareAr(side);
            double rectangleArea = Square.RectangleAr(width, length);
            double triangleArea = Square.TriangleAr(baseTriangle, heightTriangle);

            Console.WriteLine($"Square Area: {squareArea}");
            Console.WriteLine($"Rectangle Area: {rectangleArea}");
            Console.WriteLine($"Triangle Area: {triangleArea}");
            #endregion
            ////
            Console.WriteLine("=====================================================");
            #region TextLib
            string inputText = "To be, or not to be?";

            bool isPalindrome = TextManip.IsPalin(inputText);
            int sentenceCount = TextManip.CountSentences(inputText);
            string reversedText = TextManip.ReversText(inputText);

            Console.WriteLine($"Is Palindrome: {isPalindrome}");
            Console.WriteLine($"Sentence Count: {sentenceCount}");
            Console.WriteLine($"Reversed Text: {reversedText}");
            #endregion
            ////

            Console.WriteLine("=====================================================");
            #region CheckUserLib
            string name = "25";
            string age = "150";
            string phone = "1234567890";
            string email = "user@example.com";

            Console.WriteLine($"{name} is valid: {Checker.ValidName(name)}");
            Console.WriteLine($"{age}  is valid:  {Checker.ValidName(age)}");
            Console.WriteLine($"{phone}  is valid:  {Checker.ValidName(phone)}");
            Console.WriteLine($"{email}  is valid:  {Checker.ValidName(email)}");
            #endregion
            /////
            Console.WriteLine("=====================================================");
            #region file worker lib
            FileWorker();
            #endregion
            Console.ReadKey();
            some();
        }
        static void FileWorker()
        {
            string sourceFile = "source.txt";
            string sourceDirectory = "sourceDirectory";
            string destinationDirectory = "destinationDirectory";
            string[] fileNamesToDelete = { "file1.txt", "file2.txt", "file3.txt" };
            string fileMask = "*.txt";
            string wordToSearch = "Content";

            try
            {
                FileWorkerLib.FileManager.CreateFiles(sourceFile, sourceDirectory, fileNamesToDelete);

                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                // copy
                FileWorkerLib.FileManager.CopyFile(sourceFile, destinationDirectory + "\\destinationFile.txt");
                FileWorkerLib.FileManager.CopyDirectory(sourceDirectory, destinationDirectory);

                // delete file
                FileWorkerLib.FileManager.DeleteFile(destinationDirectory + "\\destinationFile.txt");
                FileWorkerLib.FileManager.DeleteFiles(fileNamesToDelete);

                // deletye by mask
                FileWorkerLib.FileManager.DeleteFilesByMask(destinationDirectory, fileMask);

                // move file
                FileWorkerLib.FileManager.MoveFile(sourceDirectory + "\\file1.txt", destinationDirectory + "\\file1.txt");

                // serch
                FileWorkerLib.FileManager.SearchWordInFile(destinationDirectory + "\\file1.txt", wordToSearch);
                FileWorkerLib.FileManager.SearchWordInDirectory(destinationDirectory, wordToSearch);

                Console.WriteLine("DLL testing completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }


        static void some()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  .... NO! ...                  ... MNO! ...");
            Console.WriteLine("   ..... MNO!! ...................... MNNOO! ...");
            Console.WriteLine(" ..... MMNO! ......................... MNNOO!! .");
            Console.WriteLine(".... MNOONNOO!   MMMMMMMMMMPPPOII!   MNNO!!!! .");
            Console.WriteLine(" ... !O! NNO! MMMMMMMMMMMMMPPPOOOII!! NO! ....");
            Console.WriteLine("    ...... ! MMMMMMMMMMMMMPPPPOOOOIII! ! ...");
            Console.WriteLine("   ........ MMMMMMMMMMMMPPPPPOOOOOOII!! .....");
            Console.WriteLine("   ........ MMMMMOOOOOOPPPPPPPPOOOOMII! ...  ");
            Console.WriteLine("    ....... MMMMM..    OPPMMP    .,OMI! ....");
            Console.WriteLine("     ...... MMMM::   o.,OPMP,.o   ::I!! ...");
            Console.WriteLine("         .... NNM:::.,,OOPM!P,.::::!! ....");
            Console.WriteLine("          .. MMNNNNNOOOOPMO!!IIPPO!!O! .....");
            Console.WriteLine("          ... MMMMMNNNNOO:!!:!!IPPPPOO! .....");
            Console.WriteLine("           .. MMMMMNNOOMMNNIIIPPPOO!! .....");
            Console.WriteLine("          ...... MMMONNMMNNNIIIOO!..........");
            Console.WriteLine("       ....... MN MOMMMNNNIIIIIO! OO ..........");
            Console.WriteLine("    ......... MNO! IiiiiiiiiiiiI OOOO ...........");
            Console.WriteLine("  ...... NNN.MNO! . O!!!!!!!!!O . OONO NO! .......");
            Console.WriteLine("   .... MNNNNNO! ...OOOOOOOOOOO .  MMNNON!........");
            Console.WriteLine("   ...... MNNNNO! .. PPPPPPPPP .. MMNON!........");
            Console.WriteLine("      ...... OO! ................. ON! .......");
            Console.WriteLine("         ................................");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
