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

namespace Esoft.Pages.NeedsPages.Objects
{
    /// <summary>
    /// Логика взаимодействия для AddHouseNeedPage.xaml
    /// </summary>
    public partial class AddHouseNeedPage : Page
    {
        private Needs _currentModel = new Needs();
        private esoftContext _dataBase = new esoftContext();

        public Clients ClientObj { get; set; }
        public Addresses AdressObj { get; set; }
        public Realtors RealtorObj { get; set; }

        public AddHouseNeedPage(Needs needs = null)
        {
            InitializeComponent();
            CBClient.ItemsSource = _dataBase.Clients.ToList().Where(p => p.ClientState == false);
            CBRealtor.ItemsSource = _dataBase.Realtors.ToList().Where(p => p.ClientState == false); ;
            CBAdress.ItemsSource = _dataBase.Addresses.ToList();

            if (needs != null)
                _currentModel = needs;

            DataContext = _currentModel;
        }

        //Выборка клиента
        private void CBClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (Clients)CBClient.SelectedItem;
            ClientObj = _dataBase.Clients.FirstOrDefault(p => p.Id == id.Id);
            if (ClientObj != null)
                ClientObj.ClientState = true;
        }
        //Выборка реелтора
        private void CBRealtor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (Realtors)CBRealtor.SelectedItem;
            RealtorObj = _dataBase.Realtors.FirstOrDefault(p => p.Id == id.Id);
            if (RealtorObj != null)
                RealtorObj.ClientState = true;
        }
        //Выборка адреса
        private void CBAdress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (Addresses)CBAdress.SelectedItem;
            AdressObj = _dataBase.Addresses.FirstOrDefault(p => p.Id == id.Id);
        }

        //Добавление новой потребности
        private async void BtnCreateSentence_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(minPrice.Text.Trim(), out int _minPrice);
            int.TryParse(maxPrice.Text.Trim(), out int _maxPrice);
            int.TryParse(minSquare.Text.Trim(), out int _minSquare);
            int.TryParse(maxSquare.Text.Trim(), out int _maxSquare);
            int.TryParse(minCountFloor.Text.Trim(), out int _minCountFloor);
            int.TryParse(maxCountFloor.Text.Trim(), out int _maxCountFloor);
            int.TryParse(minCountRoom.Text.Trim(), out int _minCountRoom);
            int.TryParse(maxCountRoom.Text.Trim(), out int _maxCountRoom);

            if (CBProperty.SelectedIndex == 0)
            {
                await _dataBase.Needs.AddAsync(new Needs
                {
                    Client = ClientObj,
                    Realtor = RealtorObj,
                    Adress = AdressObj,
                    TypeOfProperty = "Дом",
                    MinPrice = _minPrice,
                    MaxPrice = _maxPrice,
                    MinSquare = _minSquare,
                    MaxSquare = _maxSquare,
                    MinCountFloor = _minCountFloor,
                    MaxCountFloor = _maxCountFloor,
                    MinCountRoom = _minCountRoom,
                    MaxCountRoom = _maxCountRoom
                });
                
                await _dataBase.SaveChangesAsync();

            }
            if (CBProperty.SelectedIndex == 1)
            {
                await _dataBase.Needs.AddAsync(new Needs
                {
                    Client = ClientObj,
                    Realtor = RealtorObj,
                    Adress = AdressObj,
                    TypeOfProperty = "Квартира",
                    MinPrice = _minPrice,
                    MaxPrice = _maxPrice,
                    MinSquare = _minSquare,
                    MaxSquare = _maxSquare,
                    MinCountFloor = _minCountFloor,
                    MaxCountFloor = _maxCountFloor,
                    MinCountRoom = _minCountRoom,
                    MaxCountRoom = _maxCountRoom
                });
                await _dataBase.SaveChangesAsync();
            }
            if (CBProperty.SelectedIndex == 2)
            {
                await _dataBase.Needs.AddAsync(new Needs
                {
                    Client = ClientObj,
                    Realtor = RealtorObj,
                    Adress = AdressObj,
                    TypeOfProperty = "Земля",
                    MinPrice = _minPrice,
                    MaxPrice = _maxPrice,
                    MinSquare = _minSquare,
                    MaxSquare = _maxSquare
                });
                await _dataBase.SaveChangesAsync();
            }
        }

        //Обновление данных
        private async void BtnUpdateSentence_Click(object sender, RoutedEventArgs e)
        {
            _dataBase.Needs.Update((Needs)DataContext);
            await _dataBase.SaveChangesAsync();
        }

        private void CBProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
