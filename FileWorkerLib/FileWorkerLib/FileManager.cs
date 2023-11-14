
namespace FileWorkerLib
{
    public class FileManager
    {
        public static void CopyFile(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath, true);
        }

        public static void CopyDirectory(string sourceDirectory, string destinationDirectory)
        {
            foreach (string dirPath in Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourceDirectory, destinationDirectory));
            }

            foreach (string newPath in Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourceDirectory, destinationDirectory), true);
            }
        }

        public static void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public static void DeleteFiles(string[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                File.Delete(fileName);
            }
        }

        public static void DeleteFilesByMask(string directoryPath, string fileMask)
        {
            var files = Directory.GetFiles(directoryPath, fileMask);
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }

        public static void MoveFile(string sourcePath, string destinationPath)
        {
            File.Move(sourcePath, destinationPath);
        }

        public static void SearchWordInFile(string filePath, string searchWord)
        {
            if (filePath != null)
            {
                string content = File.ReadAllText(filePath);
                bool wordFound = content.Contains(searchWord);

                string reportFilePath = Path.Combine(Path.GetDirectoryName(filePath) ?? string.Empty, "SearchReport.txt");
                File.WriteAllText(reportFilePath, $"Search word '{searchWord}' in file '{filePath}': {wordFound}");
            }
        }

        public static void SearchWordInDirectory(string directoryPath, string searchWord)
        {
            if (directoryPath != null)
            {
                var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    SearchWordInFile(file, searchWord);
                }

                string reportFilePath = Path.Combine(directoryPath, "SearchReport.txt");
                File.WriteAllText(reportFilePath, $"Search word '{searchWord}' in directory '{directoryPath}': Done");
            }
        }
        public static void CreateFiles(string sourceFile, string sourceDirectory, string[] fileNamesToDelete)
        {
            try
            {
                // Create files and directories
                using (StreamWriter sourceFileWriter = new StreamWriter(sourceFile))
                {
                    sourceFileWriter.Write("Content of source file.");
                }

                // Create the source directory if it doesn't exist
                Directory.CreateDirectory(sourceDirectory);

                using (StreamWriter file1Writer = new StreamWriter(Path.Combine(sourceDirectory, "file1.txt")))
                using (StreamWriter file2Writer = new StreamWriter(Path.Combine(sourceDirectory, "file2.txt")))
                using (StreamWriter file3Writer = new StreamWriter(Path.Combine(sourceDirectory, "file3.txt")))
                {
                    file1Writer.Write("Content of file1.");
                    file2Writer.Write("Content of file2.");
                    file3Writer.Write("Content of file3.");
                }

                Console.WriteLine("Files and directories created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}