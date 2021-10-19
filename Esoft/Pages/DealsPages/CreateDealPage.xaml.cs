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

namespace Esoft.Pages.DealsPages
{
    /// <summary>
    /// Логика взаимодействия для CreateDealPage.xaml
    /// </summary>
    public partial class CreateDealPage : Page
    {
        private esoftContext _dataBase = new esoftContext();

        public Sentence SentenceId { get; set; }
        public Needs NeedId { get; set; }

        private Deal _correctModel;

        public CreateDealPage(Deal deal = null)
        {
            InitializeComponent();
            CBSentence.ItemsSource = _dataBase.Sentence.ToList().Where(p => p.State == false);
            CBNeeds.ItemsSource = _dataBase.Needs.ToList().Where(p => p.State == false);

            if (deal != null)
                _correctModel = deal;
            DataContext = _correctModel;
        }

        private async void CreateDeal_Click(object sender, RoutedEventArgs e)
        {
            await _dataBase.Deal.AddAsync(new Deal { 
                Sentence = SentenceId,
                Needs = NeedId
            });
            await _dataBase.SaveChangesAsync();
        }

        private void SaveDeal_Click(object sender, RoutedEventArgs e)
        {
            _dataBase.Update(DataContext);
        }

        private void CBSentence_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (Sentence)CBSentence.SelectedItem;
            SentenceId = _dataBase.Sentence.FirstOrDefault(p => p.Id == id.Id);
            SentenceId.State = true;
        }

        private void CBNeeds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (Needs)CBNeeds.SelectedItem;
            NeedId = _dataBase.Needs.FirstOrDefault(p => p.Id == id.Id);
            NeedId.State = true;
        }
    }
}
