using Esoft.Pages.DealsPages;
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
