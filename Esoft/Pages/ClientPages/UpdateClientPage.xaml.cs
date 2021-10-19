    using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.ClientPages
{
    /// <summary>
    /// Логика взаимодействия для UpdateClientPage.xaml
    /// </summary>
    public partial class UpdateClientPage : Page
    {
        private esoftContext _dataBase;

        public UpdateClientPage()
        {
            InitializeComponent();

            _dataBase = new esoftContext();
            DgridClients.ItemsSource = _dataBase.Clients.ToList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new CreateClientPage((sender as Button).DataContext as Clients));
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var clients = DgridClients.SelectedItems.Cast<Clients>().ToList();

            foreach(var user in clients)
            {
                if (user.ClientState == true)
                {
                    MessageBox.Show("Нельзя удалить клиента связанного с потребностью или предложением");
                    return;
                }
            }

            if (MessageBox.Show($"Вы точно хотите удалить слеующие {clients.Count()} элементов?",
                $" Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _dataBase.Clients.RemoveRange(clients);
                    await _dataBase.SaveChangesAsync();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось выполнить удаление");
                    throw;
                }
            }
        }
    }
}
