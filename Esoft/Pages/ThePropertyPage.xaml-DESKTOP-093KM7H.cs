using Esoft.Pages.ThePropertyPages;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для ThePropertyPage.xaml
    /// </summary>
    public partial class ThePropertyPage : Page
    {
        public ThePropertyPage()
        {
            InitializeComponent();
        }

        private void UpdateRealtor(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new UpdateThePropertyPage());
        }

        private void AddRealtor(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new AddThePropertyPage());
        }
    }
}
