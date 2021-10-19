using System.Windows;

namespace Esoft.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateHouseInfoWindow.xaml
    /// </summary>
    public partial class UpdateHouseInfoWindow : Window
    {
        private esoftContext _dataBase;
        private Houses _currentModel = new Houses();

        public UpdateHouseInfoWindow(Houses model)
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
