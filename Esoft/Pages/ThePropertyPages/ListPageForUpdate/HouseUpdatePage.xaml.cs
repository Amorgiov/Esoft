using Esoft.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.ThePropertyPages.ListPageForUpdate
{
    /// <summary>
    /// Логика взаимодействия для HouseUpdatePage.xaml
    /// </summary>
    public partial class HouseUpdatePage : Page
    {
        private esoftContext _dataBase;

        public HouseUpdatePage()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            DGHouse.ItemsSource = _dataBase.Houses.ToList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateHouseInfoWindow _updateHouseInfo = new UpdateHouseInfoWindow((sender as Button).DataContext as Houses);
            _updateHouseInfo.ResizeMode = ResizeMode.NoResize;
            _updateHouseInfo.WindowStyle = WindowStyle.ToolWindow;
            _updateHouseInfo.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var objects = DGHouse.SelectedItems.Cast<Houses>().ToList();

            foreach (var item in objects)
            {
                if (item.State == true)
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
                    _dataBase.Houses.RemoveRange(objects);
                    _dataBase.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось выполнить удаление");
                    return;
                }
            }
        }
    }
}
