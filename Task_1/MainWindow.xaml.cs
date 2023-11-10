using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace Task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        private async void Analizate_Click(object sender, RoutedEventArgs e)
        {
            //  из RichTextBox
            string text = new TextRange(richTextBoxWithPlaceholder.Document.ContentStart, richTextBoxWithPlaceholder.Document.ContentEnd).Text;

            var report = await AnalyzeTextAsync(text);

            // обновляем UI 
            UpdateUI(report);
        }

        private async Task<(int sentenceCount, int characterCount, int wordCount, int questionCount, int exclamationCount)> AnalyzeTextAsync(string text)
        {
            return await Task.Run(() =>
            {
                int sentenceCount = text.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
                int characterCount = text.Length;
                int wordCount = text.Split(new char[] { ' ', '.', '?', '!', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                int questionCount = text.Count(f => f == '?');
                int exclamationCount = text.Count(f => f == '!');

                return (sentenceCount, characterCount, wordCount, questionCount, exclamationCount);
            });
        }

        private void UpdateUI((int sentenceCount, int characterCount, int wordCount, int questionCount, int exclamationCount) report)
        {
            TextBlockSentens.Text = CheckBoxSentens.IsChecked == true ? $"Count Sentens: {report.sentenceCount}" : $"Count Sentens:{string.Empty}";
            TextBlockSimbol.Text = CheckBoxSimbols.IsChecked == true ? $"Count Simbols: {report.characterCount}" : $"Count Simbols: {string.Empty}";
            TextBlockWords.Text = CheckBoxWords.IsChecked == true ? $"Count Words: {report.wordCount}" : $"Count Words: {string.Empty}";
            TextBlockAnsw.Text = CheckBoxAnsw.IsChecked == true ? $"Count Sentens with ?: {report.questionCount}" : $"Count Sentens with ?:{string.Empty}";
            TextBlockQ.Text = CheckBoxQ.IsChecked == true ? $"Count Sentens with !: {report.exclamationCount}" : $"Count Sentens with !:{string.Empty}";
        }
        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = "Report.txt";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(TextBlockSentens.Text);
                    writer.WriteLine(TextBlockSimbol.Text);
                    writer.WriteLine(TextBlockWords.Text);
                    writer.WriteLine(TextBlockAnsw.Text);
                    writer.WriteLine(TextBlockQ.Text);
                }

                MessageBox.Show("File saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
