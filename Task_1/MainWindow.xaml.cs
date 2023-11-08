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
        private void RichTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Проверяем, есть ли текст, который является водяным знаком
            if (placeholderText.Text == "Введите текст здесь...")
            {
                // Очищаем RichTextBox
                richTextBoxWithPlaceholder.Document.Blocks.Clear();
            }
        }

        private void RichTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Проверяем, пуст ли RichTextBox
            if (!richTextBoxWithPlaceholder.Document.Blocks.OfType<Paragraph>().Any(p => p.Inlines.Any()))
            {
                // Вставляем водяной знак
                FlowDocument document = new FlowDocument();
                Paragraph paragraph = new Paragraph();
                Run run = new Run("Введите текст здесь...")
                {
                    Foreground = Brushes.Gray,
                    FontStyle = FontStyles.Italic
                };
                paragraph.Inlines.Add(run);
                document.Blocks.Add(paragraph);
                richTextBoxWithPlaceholder.Document = document;
            }
        }
    }
}
