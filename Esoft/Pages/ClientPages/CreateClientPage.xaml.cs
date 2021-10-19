using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static Esoft.Validation;

namespace Esoft.Pages.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для CreateClientPage.xaml
    /// </summary>


    public partial class CreateClientPage : Page
    {
        private esoftContext _dataBase;
        private Clients _currentClient = new Clients();

        //Конструктор для обновления данных
        public CreateClientPage(Clients client = null)
        {
            InitializeComponent();

            _dataBase = new esoftContext();

            if (client != null)
                _currentClient = client;
            
            DataContext = _currentClient;
        }

        private async void AddClient(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            var fam = Fam.Text.Trim();
            var name = Name.Text.Trim();
            var otch = Otch.Text.Trim();
            var phone = Phone.Text.Trim();
            var emale = Eml.Text.Trim();

            //Проверка на NULL и валидация ФИО
            if ((!String.IsNullOrEmpty(fam) && !Regex.IsMatch(fam, UserPattern))||
                (!String.IsNullOrEmpty(name)) && !Regex.IsMatch(name, UserPattern)||
                (!String.IsNullOrEmpty(otch) && !Regex.IsMatch(otch, UserPattern)))
            {
                    errors.AppendLine("Неправильный формат 'ФИО'");
            }

            //Валидация Phone
            if (!String.IsNullOrEmpty(phone))
            {
                if (!Regex.IsMatch(phone, PhonePattern))
                    errors.AppendLine("Формат телефона неправильный");
            }

            //Проверка на NULL телефона и почты
            if (String.IsNullOrEmpty(phone) && String.IsNullOrEmpty(emale))
                errors.AppendLine("Одно из полей (телефон/почта) должно быть указано");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            await _dataBase.Clients.AddAsync(new Clients { SurName = fam, Name = name, Patronymic = otch, PhoneNumber = phone, Email = emale });
            await _dataBase.SaveChangesAsync();
        }

        private async void UpdateClient(object sender, RoutedEventArgs e)
        {
            _dataBase.Update(DataContext);
            await _dataBase.SaveChangesAsync();
        }
    }
}
