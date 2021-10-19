using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.RealtorPages
{
    /// <summary>
    /// Логика взаимодействия для UpdateRealtorPage.xaml
    /// </summary>
    public partial class UpdateRealtorPage : Page
    {
        private esoftContext _dataBase;

        public UpdateRealtorPage()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            DgridClients.ItemsSource = _dataBase.Realtors.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var realtors = DgridClients.SelectedItems.Cast<Realtors>().ToList();

            foreach (var realtor in realtors)
            {
                if (realtor.ClientState == true)
                {
                    MessageBox.Show("Нельзя удалить клиента связанного с потребностью или предложением");
                    return;
                }
            }

            if (MessageBox.Show($"Вы точно хотите удалить слеующие {realtors.Count()} элементов?",
                $" Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _dataBase.Realtors.RemoveRange(realtors);
                    _dataBase.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось выполнить удаление");
                    throw;
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new CreateRealtorPage((sender as Button).DataContext as Realtors));
        }
    }
}
