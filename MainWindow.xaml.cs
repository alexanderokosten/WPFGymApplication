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


namespace GymApp
{
    using Extensions;
    using Model;
    using System.Collections.ObjectModel;
    using View;
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Clients> AllClients { get; set; }
        public MainWindow()
        {
            InitializeComponent();
          
            Connection.Gym = new GymAppModel();
            AllClients = Connection.Gym.Clients.ToObservableColletion();
        }

        private void GoToClientPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientPage());
            label1.Content = "";
        }

        private void GoToTrainerPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TrainerPage());
            label1.Content = "";

        }

        private void GoToGroupLessonsPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GroupLessonsPage());
            label1.Content = "";
        }

        private void GoToSubscriptionPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SubscriptionPage());
            label1.Content = "";
        }
        //Create document method  

       
    }
}
