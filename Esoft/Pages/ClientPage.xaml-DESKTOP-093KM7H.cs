using Esoft.Pages.ClientPages;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new CreateClientPage());
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new UpdateClientPage());
        }
    }
}
