using System;
using System.Windows;

namespace Esoft.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateAddress.xaml
    /// </summary>
    public partial class CreateAddress : Window
    {
        private esoftContext _dataBase;
        public CreateAddress()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
        }

        private async void BtnAddAddress_Click(object sender, RoutedEventArgs e)
        {
            var city = City.Text.Trim();
            var street = Street.Text.Trim();
            var houseN = HouseNumber.Text.Trim();
            var AprN = ApartmentNumber.Text.Trim();

            if (String.IsNullOrEmpty(city) &&
                String.IsNullOrEmpty(street) &&
                String.IsNullOrEmpty(houseN) &&
                String.IsNullOrEmpty(AprN))
            {
                return;
            }
            await _dataBase.Addresses.AddAsync(new Addresses { City = city, Street = street, HouseNumber = houseN, ApartmentNumber = AprN });
            await _dataBase.SaveChangesAsync();
            createAddress.Close();
        }
    }
}
