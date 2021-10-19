using System.Windows;

namespace Esoft.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateApartInfoWindow.xaml
    /// </summary>
    public partial class UpdateApartInfoWindow : Window
    {
        private esoftContext _dataBase;
        private Apartments _currentModel = new Apartments();

        public UpdateApartInfoWindow(Apartments model)
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            if (model != null)
                _currentModel = model;
            
            DataContext = _currentModel;
        }

        private async void UpdateApartInfo_Click(object sender, RoutedEventArgs e)
        {
            _dataBase.Update(DataContext);
            await _dataBase.SaveChangesAsync();
        }
    }
}
