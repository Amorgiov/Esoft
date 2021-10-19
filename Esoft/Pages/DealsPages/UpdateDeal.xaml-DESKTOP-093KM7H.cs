using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.DealsPages
{
    /// <summary>
    /// Логика взаимодействия для UpdateDeal.xaml
    /// </summary>
    public partial class UpdateDeal : Page
    {
        private esoftContext _dataBase;
        public UpdateDeal()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            DgridSent.ItemsSource = _dataBase.Deal.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var deals = DgridSent.SelectedItems.Cast<Deal>().ToList();

            foreach(var item in deals)
            {
                var SentenceId = _dataBase.Sentence.FirstOrDefault(p => p.Id == item.SentenceId).State = false;
                var NeedsId = _dataBase.Needs.FirstOrDefault(p => p.Id == item.NeedsId).State = false;
            }

            if (MessageBox.Show($"Вы точно хотите удалить слеующие {deals.Count()} элементов?",
                $" Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _dataBase.Deal.RemoveRange(deals);
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
            Navigation.MainFrame.Navigate(new CreateDealPage((sender as Button).DataContext as Deal));
        }
    }
}
