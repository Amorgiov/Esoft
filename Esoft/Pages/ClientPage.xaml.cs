using Esoft.Pages.ClientPages;
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
using System.Windows.Shapes;

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
