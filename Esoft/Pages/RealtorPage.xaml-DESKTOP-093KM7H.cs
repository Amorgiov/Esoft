using Esoft.Pages.RealtorPages;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для RealtorPage.xaml
    /// </summary>
    public partial class RealtorPage : Page
    {
        public RealtorPage()
        {
            InitializeComponent();
        }

        private void AddRealtor(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new CreateRealtorPage());
        }

        private void UpdateRealtor(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new UpdateRealtorPage());
        }
    }
}
