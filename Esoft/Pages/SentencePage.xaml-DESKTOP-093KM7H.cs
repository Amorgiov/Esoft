using Esoft.Pages.SentencePages;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для SentencePage.xaml
    /// </summary>
    public partial class SentencePage : Page
    {
        public SentencePage()
        {
            InitializeComponent();
        }

        private void AddRealtor(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new CreateSentencePage());
        }

        private void UpdateRealtor(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new UpdateSentencePage());
        }
    }
}
