using Esoft.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.ThePropertyPages.ListPageForUpdate
{
    /// <summary>
    /// Логика взаимодействия для PlotUpdatePage.xaml
    /// </summary>
    public partial class PlotUpdatePage : Page
    {
        private esoftContext _dataBase;

        public PlotUpdatePage()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            DGPlot.ItemsSource = _dataBase.LandPlots.ToList();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdatePlotInfoWindow _updateHouseInfo = new UpdatePlotInfoWindow((sender as Button).DataContext as LandPlots);
            _updateHouseInfo.ResizeMode = ResizeMode.NoResize;
            _updateHouseInfo.WindowStyle = WindowStyle.ToolWindow;
            _updateHouseInfo.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var objects = DGPlot.SelectedItems.Cast<LandPlots>().ToList();

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
                    _dataBase.LandPlots.RemoveRange(objects);
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
