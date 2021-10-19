using Esoft.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.ThePropertyPages.ListPageForUpdate
{
    /// <summary>
    /// Логика взаимодействия для ApartUpdatePage.xaml
    /// </summary>
    public partial class ApartUpdatePage : Page
    {
        private esoftContext _dataBase;

        public ApartUpdatePage()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            DGApart.ItemsSource = _dataBase.Apartments.ToList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateApartInfoWindow _updateApartInfo = new UpdateApartInfoWindow((sender as Button).DataContext as Apartments);
            _updateApartInfo.ResizeMode = ResizeMode.NoResize;
            _updateApartInfo.WindowStyle = WindowStyle.ToolWindow;
            _updateApartInfo.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var objects = DGApart.SelectedItems.Cast<Apartments>().ToList();

            foreach(var item in objects)
            {
                if(item.State == true)
                {
                    MessageBox.Show("Нельзя удалить объект недвижимости связанный с потребностью или предложением");
                    return;
                }
            }
                

            if (MessageBox.Show($"Вы точно хотите удалить слеующие {objects.Count()} элементов?",
                $" Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _dataBase.Apartments.RemoveRange(objects);
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
