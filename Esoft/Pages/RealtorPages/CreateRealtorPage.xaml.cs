using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static Esoft.Validation;

namespace Esoft.Pages.RealtorPages
{
    /// <summary>
    /// Логика взаимодействия для CreateRealtorPage.xaml
    /// </summary>
    public partial class CreateRealtorPage : Page
    {
        private esoftContext _dataBase;
        private Realtors _currentRealtor = new Realtors();

        //Конструктор для обновления данных
        public CreateRealtorPage(Realtors realtor = null)
        {
            InitializeComponent();

            _dataBase = new esoftContext();

            if (realtor != null)
                _currentRealtor = realtor;
            
            DataContext = _currentRealtor;
        }

        private async void AddClient(object sender, RoutedEventArgs e)
        {
            var fam = Fam.Text.Trim();
            var name = Name.Text.Trim();
            var otch = Otch.Text.Trim();
            var share = Share.Text.Trim();

            //Проверка на NULL ФИО
            if (String.IsNullOrEmpty(fam) ||
                String.IsNullOrEmpty(name) ||
                String.IsNullOrEmpty(otch))
            {
                MessageBox.Show("ФИО обязательно к заполнению");
                return;
            }

            //Валидация ФИО
            if (!Regex.IsMatch(fam, UserPattern) ||
                !Regex.IsMatch(name, UserPattern) ||
                !Regex.IsMatch(otch, UserPattern))
            {
                MessageBox.Show("Неправильный формат 'ФИО'");
            }

            if (int.TryParse(share, out int num))
            {
                if (!Regex.IsMatch(share, SharePattern)) 
                {
                    MessageBox.Show("Значение доли от 0 до 100");
                    return;
                }
            }

            await _dataBase.Realtors.AddAsync(new Realtors { SurName = fam, Name = name, Patronymic = otch, Share = num });
            await _dataBase.SaveChangesAsync();
        }

        private async void UpdateClient(object sender, RoutedEventArgs e)
        {
            _dataBase.Update(DataContext);
            await _dataBase.SaveChangesAsync();
        }
    }
}
