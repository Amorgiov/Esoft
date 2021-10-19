using Esoft.Windows;
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

namespace Esoft.Pages.ThePropertyPages.Objects.LandPlot
{
    /// <summary>
    /// Логика взаимодействия для AddPlotPage.xaml
    /// </summary>
    public partial class AddPlotPage : Page
    {
        private esoftContext _dataBase;
        public Addresses adressId { get; set; }
        public Coordinates coordId { get; set; }

        public AddPlotPage()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            CBAddress.ItemsSource = _dataBase.Addresses.ToList();
            CBCoord.ItemsSource = _dataBase.Coordinates.ToList();
        }

        private void CBAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var adress = (Addresses)CBAddress.SelectedItem;
            adressId = _dataBase.Addresses.FirstOrDefault(p => p.Id == adress.Id);
        }

        private void CBCoord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var coord = (Coordinates)CBCoord.SelectedItem;
            coordId = _dataBase.Coordinates.FirstOrDefault(p => p.Id == coord.Id);
        }

        private void BtnAddressAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateAddress createAddress = new CreateAddress();
            createAddress.Show();
        }

        private void BtnCoordAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateCoord createCoord = new CreateCoord();
            createCoord.Show();
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(Square.Text.Trim(), out int _squareP);
            await _dataBase.LandPlots.AddAsync(new LandPlots { Square = _squareP, Address = adressId, Coord = coordId });
            await _dataBase.SaveChangesAsync();
        }
    }
}
