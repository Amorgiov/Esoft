using Esoft.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Esoft.Pages.ThePropertyPages.Objects.House
{
    /// <summary>
    /// Логика взаимодействия для AddHousePage.xaml
    /// </summary>
    public partial class AddHousePage : Page
    {
        private esoftContext _dataBase;
        public Addresses adressId { get; set; }
        public Coordinates coordId { get; set; }

        public AddHousePage()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            CBAddress.ItemsSource = _dataBase.Addresses.ToList();
            CBCoord.ItemsSource = _dataBase.Coordinates.ToList();
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
            int.TryParse(FloorCount.Text.Trim(), out int _floorCount);
            int.TryParse(RoomCount.Text.Trim(), out int _roomCount);
            int.TryParse(Square.Text.Trim(), out int _square);

            await _dataBase.Houses.AddAsync(new Houses { FloorCount = _floorCount, RoomCount = _roomCount, Square = _square, Adress = adressId, Coord = coordId });
            await _dataBase.SaveChangesAsync();
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
    }
}
