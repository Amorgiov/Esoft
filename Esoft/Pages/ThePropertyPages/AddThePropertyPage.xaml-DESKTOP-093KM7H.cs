using Esoft.Pages.ThePropertyPages.Objects.Apartment;
using Esoft.Pages.ThePropertyPages.Objects.House;
using Esoft.Pages.ThePropertyPages.Objects.LandPlot;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.ThePropertyPages
{
    /// <summary>
    /// Логика взаимодействия для AddThePropertyPage.xaml
    /// </summary>
    public partial class AddThePropertyPage : Page
    {
        public AddThePropertyPage()
        {
            InitializeComponent();
        }

        private void BtnHouse_Click(object sender, RoutedEventArgs e)
        {
            objectFrame.Navigate(new AddHousePage());
        }

        private void BtnApart_Click(object sender, RoutedEventArgs e)
        {
            objectFrame.Navigate(new AddApartPage());
        }

        private void BtnPlot_Click(object sender, RoutedEventArgs e)
        {
            objectFrame.Navigate(new AddPlotPage());
        }
    }
}
