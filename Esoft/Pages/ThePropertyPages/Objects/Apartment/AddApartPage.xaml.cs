using Esoft.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.ThePropertyPages.Objects.Apartment
{
    /// <summary>
    /// Логика взаимодействия для AddApartPage.xaml
    /// </summary>
    public partial class AddApartPage : Page
    {
        private esoftContext _dataBase;
        public Addresses adressId { get; set; }
        public Coordinates coordId { get; set; }

        public AddApartPage()
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
            int.TryParse(roomCount.Text.Trim(), out int _roomA);
            int.TryParse(floor.Text.Trim(), out int _floorN);
            int.TryParse(square.Text.Trim(), out int _squareA);

            await _dataBase.Apartments.AddAsync(new Apartments { Floor = _floorN, RoomCount = _roomA, Square = _squareA, Address = adressId, Coord = coordId });
            await _dataBase.SaveChangesAsync();
        }
    }
}
