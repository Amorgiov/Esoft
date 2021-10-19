using Esoft.Pages;
using Esoft.Pages.ClientPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Esoft
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.MainFrame = MainFrame;
            Navigation.ButtonFrame = ButtonFrame;
            Main.ResizeMode = ResizeMode.NoResize;
            Main.WindowStyle = WindowStyle.ToolWindow;
        }

        private void Client(object sender, RoutedEventArgs e)
        {
            ButtonFrame.Navigate(new ClientPage());
        }

        private void Realtor(object sender, RoutedEventArgs e)
        {
            ButtonFrame.Navigate(new RealtorPage());
        }

        private void RheProperty(object sender, RoutedEventArgs e)
        {
            ButtonFrame.Navigate(new ThePropertyPage());
        }

        private void Sentence(object sender, RoutedEventArgs e)
        {
            ButtonFrame.Navigate(new SentencePage());
        }

        private void Needs(object sender, RoutedEventArgs e)
        {
            ButtonFrame.Navigate(new NeedsPage());
        }

        private void Deal_Click(object sender, RoutedEventArgs e)
        {
            ButtonFrame.Navigate(new DealPage());
        }
    }
}
