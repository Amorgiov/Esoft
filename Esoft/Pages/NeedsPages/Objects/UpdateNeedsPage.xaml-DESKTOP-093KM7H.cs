using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.NeedsPages.Objects
{
    /// <summary>
    /// Логика взаимодействия для UpdateNeedsPage.xaml
    /// </summary>
    public partial class UpdateNeedsPage : Page
    {
        private esoftContext _dataBase;
        public UpdateNeedsPage()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            DgridSent.ItemsSource = _dataBase.Needs.ToList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new AddHouseNeedPage((sender as Button).DataContext as Needs));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var needs = DgridSent.SelectedItems.Cast<Needs>().ToList();

            foreach (var item in needs)
            {
                var ClientId = _dataBase.Clients.FirstOrDefault(p => p.Id == item.ClientId);
                ClientId.ClientState = false;
                var RealtorId = _dataBase.Realtors.FirstOrDefault(p => p.Id == item.RealtorId);
                RealtorId.ClientState = false;

                if (item.State == true)
                {
                    MessageBox.Show("Нельзя удалить потребность связанную со сделкой");
                    return;
                }
            }

            if (MessageBox.Show($"Вы точно хотите удалить слеующие {needs.Count()} элементов?",
                $" Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _dataBase.Needs.RemoveRange(needs);
                    _dataBase.SaveChanges();
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
