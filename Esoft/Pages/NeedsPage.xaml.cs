using Esoft.Pages.NeedsPages;
using Esoft.Pages.NeedsPages.Objects;
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
