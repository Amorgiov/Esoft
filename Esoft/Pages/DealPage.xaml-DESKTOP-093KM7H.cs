using Esoft.Pages.DealsPages;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для DealPage.xaml
    /// </summary>
    public partial class DealPage : Page
    {
        public DealPage()
        {
            InitializeComponent();
        }

        private void AddDeal(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new CreateDealPage());
        }

        private void UpdateDeal(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new UpdateDeal());
        }
    }
}
