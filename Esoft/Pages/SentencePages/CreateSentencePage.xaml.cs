using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Esoft.Pages.SentencePages
{
    /// <summary>
    /// Логика взаимодействия для CreateSentencePage.xaml
    /// </summary>
    public partial class CreateSentencePage : Page
    {
        private Sentence _currentModel = new Sentence();
        private esoftContext _dataBase = new esoftContext();

        public Clients ClientObj { get; set; }
        public object PropertyObj { get; set; }
        public Realtors RealtorObj { get; set; }

        public CreateSentencePage(Sentence sentence = null)
        {
            InitializeComponent();
            CBClient.ItemsSource = _dataBase.Clients.ToList().Where(p => p.ClientState == false);
            CBRealtor.ItemsSource = _dataBase.Realtors.ToList().Where(p => p.ClientState == false);

            if (sentence != null)
                _currentModel = sentence;

            DataContext = _currentModel;
        }

        private async void BtnCreateSentence_Click(object sender, RoutedEventArgs e)
        {
            var Cost = CostOfObject.Text.Trim();
            int.TryParse(Cost, out int num);

            if (typeOfProperty.SelectedIndex == 0)
                await _dataBase.Sentence.AddAsync(
                    new Sentence 
                    { 
                        Client = ClientObj,
                        Realtor = RealtorObj,
                        Cost = num, TypeOfProperty = "Дом",
                        House = (Houses)PropertyObj
                    });

            if (typeOfProperty.SelectedIndex == 1)
                await _dataBase.Sentence.AddAsync(
                    new Sentence 
                    {
                        Client = ClientObj,
                        Realtor = RealtorObj,
                        Cost = num,
                        TypeOfProperty = "Квартира",
                        Apart = (Apartments)PropertyObj
                    });

            if (typeOfProperty.SelectedIndex == 2)
                await _dataBase.Sentence.AddAsync(
                    new Sentence 
                    {
                        Client = ClientObj,
                        Realtor = RealtorObj,
                        Cost = num,
                        TypeOfProperty = "Земельный участок",
                        Plot = (LandPlots)PropertyObj
                    });

            await _dataBase.SaveChangesAsync();
        }

        private void CBClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (Clients)CBClient.SelectedItem;
            ClientObj = _dataBase.Clients.FirstOrDefault(p => p.Id == id.Id);
            if (ClientObj != null)
                ClientObj.ClientState = true;
        }

        private void CBRealtor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (Realtors)CBRealtor.SelectedItem;
            RealtorObj = _dataBase.Realtors.FirstOrDefault(p => p.Id == id.Id);
            if (RealtorObj != null)
                RealtorObj.ClientState = true;
        }

        private async void BtnUpdateSentence_Click(object sender, RoutedEventArgs e)
        {
            _dataBase.Sentence.Update((Sentence)DataContext);
            await _dataBase.SaveChangesAsync();
        }

        private void CBPropertyObj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBPropertyObj.SelectedIndex == 0)
            {
                var objH = (Houses)CBPropertyObj.SelectedItem;
                var id = _dataBase.Houses.FirstOrDefault(p => p.Id == objH.Id);
                id.State = true;
                PropertyObj = id;
            }

            if (CBPropertyObj.SelectedIndex == 1)
            {
                var objP = (Apartments)CBPropertyObj.SelectedItem;
                var id = _dataBase.Apartments.FirstOrDefault(p => p.Id == objP.Id);
                id.State = true;
                PropertyObj = id;
            }

            if (CBPropertyObj.SelectedIndex == 2)
            {
                var objL = (LandPlots)CBPropertyObj.SelectedItem;
                var id = _dataBase.LandPlots.FirstOrDefault(p => p.Id == objL.Id);
                id.State = true;
                PropertyObj = id;
            }
        }

        private void typeOfProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeOfProperty.SelectedIndex == 0)
                CBPropertyObj.ItemsSource = _dataBase.Houses.ToList().Where(p => p.State == false);

            if (typeOfProperty.SelectedIndex == 1)
                CBPropertyObj.ItemsSource = _dataBase.Apartments.ToList().Where(p => p.State == false);

            if (typeOfProperty.SelectedIndex == 2)
                CBPropertyObj.ItemsSource = _dataBase.LandPlots.ToList().Where(p => p.State == false);
        }
    }
}
