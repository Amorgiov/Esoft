using System.Windows;

namespace Esoft.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdatePlotInfoWindow.xaml
    /// </summary>
    public partial class UpdatePlotInfoWindow : Window
    {
        private esoftContext _dataBase;
        private LandPlots _currentModel = new LandPlots();

        public UpdatePlotInfoWindow(LandPlots model)
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            if (model != null)
                _currentModel = model;
            
            DataContext = _currentModel;
        }

        private async void UpdateHouseInfo_Click(object sender, RoutedEventArgs e)
        {
            _dataBase.Update(DataContext);
            await _dataBase.SaveChangesAsync();
        }
    }
}
