using Esoft.Pages.ThePropertyPages.ListPageForUpdate;
using System.Windows.Controls;

namespace Esoft.Pages.ThePropertyPages
{
    /// <summary>
    /// Логика взаимодействия для UpdateThePropertyPage.xaml
    /// </summary>
    public partial class UpdateThePropertyPage : Page
    {
        public UpdateThePropertyPage()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CBObjects.SelectedIndex == 0)
            {
                ListFrame.Navigate(new HouseUpdatePage());
            }
            if (CBObjects.SelectedIndex == 1)
            {
                ListFrame.Navigate(new ApartUpdatePage());
            }
            if (CBObjects.SelectedIndex == 2)
            {
                ListFrame.Navigate(new PlotUpdatePage());
            }
        }
    }
}
