using Esoft.Pages.ThePropertyPages.ListPageForUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
