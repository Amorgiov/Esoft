using Esoft.Pages.ThePropertyPages;
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
