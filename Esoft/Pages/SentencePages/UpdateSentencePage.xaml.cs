using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.SentencePages
{
    /// <summary>
    /// Логика взаимодействия для UpdateSentencePage.xaml
    /// </summary>
    public partial class UpdateSentencePage : Page
    {
        private esoftContext _dataBase;
        public UpdateSentencePage()
        {
            InitializeComponent();
            _dataBase = new esoftContext();
            DgridSent.ItemsSource = _dataBase.Sentence.ToList();
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MainFrame.Navigate(new CreateSentencePage((sender as Button).DataContext as Sentence));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sentences = DgridSent.SelectedItems.Cast<Sentence>().ToList();

            foreach (var item in sentences)
            {
                var ClientId = _dataBase.Clients.FirstOrDefault(p => p.Id == item.ClientId);
                ClientId.ClientState = false;
                var RealtorId = _dataBase.Realtors.FirstOrDefault(p => p.Id == item.RealtorId);
                RealtorId.ClientState = false;

                if(item.TypeOfProperty == "Дом")
                {
                    var HouseId = _dataBase.Houses.FirstOrDefault(p => p.Id == item.HouseId);
                    HouseId.State = false;
                }

                if (item.TypeOfProperty == "Квартира")
                {
                    var ApartId = _dataBase.Apartments.FirstOrDefault(p => p.Id == item.ApartId);
                    ApartId.State = false;
                }

                if (item.TypeOfProperty == "Земельный участок")
                {
                    var PlotId = _dataBase.LandPlots.FirstOrDefault(p => p.Id == item.PlotId);
                    PlotId.State = false;
                }

                if(item.State == true)
                {
                    MessageBox.Show("Нельзя удалить предложение связанное со сделкой");
                    return;
                }
            }
            
            

            if (MessageBox.Show($"Вы точно хотите удалить слеующие {sentences.Count()} элементов?",
                $" Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _dataBase.Sentence.RemoveRange(sentences);
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
