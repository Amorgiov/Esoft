using System;
using System.Windows;

namespace Esoft.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateCoord.xaml
    /// </summary>
    public partial class CreateCoord : Window
    {
        private esoftContext _dataBase;

        public CreateCoord()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
        }

        int longi;
        int lati;
        private async void BtnAddCoord_Click(object sender, RoutedEventArgs e)
        {
            var longitude = Longitude.Text.Trim();
            var latitude = Latitude.Text.Trim();
                
            if (!int.TryParse(longitude, out longi) ||
                !int.TryParse(latitude, out lati)) 
            {
                MessageBox.Show("Долгота и широта...числа вроде как не?");
            }
            

            if(longi > 180 || longi < -180)
            {
                MessageBox.Show("Долгота имеет диапазон от -180 до 180");
                return;
            }
            if(lati > 90 || lati < -90)
            {
                MessageBox.Show("Долгота имеет диапазон от -90 до 90");
                return;
            }

            if (String.IsNullOrEmpty(longitude) &&
                String.IsNullOrEmpty(latitude))
            {
                return;
            }
            await _dataBase.Coordinates.AddAsync(new Coordinates { Longitude = longi, Latitude = lati });
            await _dataBase.SaveChangesAsync();
            createCoord.Close();
        }
    }
}
