using Esoft.Pages.NeedsPages.Objects;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для NeedsPage.xaml
    /// </summary>
    public partial class NeedsPage : Page
    {
        public NeedsPage()
        {
            InitializeComponent();
        }

        private void AddNedd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new AddHouseNeedPage());
        }

        private void UpdateNeeds_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new UpdateNeedsPage());
        }
    }
}
