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

namespace GymApp.View
{
    using Model;
    using System.Collections.ObjectModel;
    using Extensions;
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ObservableCollection<Clients> AllClients { get; set; }
        public ClientPage()
        {
            InitializeComponent();
            AllClients = Connection.Gym.Clients.ToObservableColletion();
            DataContext = this;
        }
        public void UpdateDataContext()
        {
            DataContext = null;
            DataContext = this;
        }

        private void UpdateClient(object sender, RoutedEventArgs e)
        {
            var button1 = sender as Button;
            var selected = button1.Tag as Clients;
            if (selected != null)
            {
                UpdateClientWindow updateClientWindow = new UpdateClientWindow(selected);
                updateClientWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
         
        }

        private void SignUpClientTrainer(object sender, RoutedEventArgs e)
        {
            var button1 = sender as Button;
            var selected = button1.Tag as Clients;
            if (selected != null && selected.SubscriptionEndTime > DateTime.Now)
            {
                SignUpClientTrainerWindow signUpClientTrainerWindow = new SignUpClientTrainerWindow(selected);
                signUpClientTrainerWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Запись клиента невозможна. Возможно у него кончился срок абонемента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void DeleteClient(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var client = button.Tag as Clients;

            try
            {

                Connection.Gym.Clients.Remove(client);
                AllClients.Remove(client);

                Connection.Gym.SaveChanges();
                UpdateDataContext();

            }
            catch
            {
                MessageBox.Show("При сохранение базы произошла ошибка, проверьте, что на групповое занятие пользователь не записан или не записан к тренеру", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                var clientEntry = Connection.Gym.Entry<Clients>(client);
                clientEntry.Reload();

                AllClients = Connection.Gym.Clients.ToObservableColletion();

                UpdateDataContext();
            }
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            
            AddClientWindow addClientWindow = new AddClientWindow();
         
            addClientWindow.ShowDialog();
        }

        private void searchTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
         
        }

        private void SurnameCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SurnameCombobox.SelectedIndex == 0)
            {
                AllClients = AllClients.OrderByDescending(s => s.Surname).ToObservableColletion();
                UpdateDataContext();
            }
            else if (SurnameCombobox.SelectedIndex == 1)
            {
                AllClients = AllClients.OrderBy(s => s.Surname).ToObservableColletion();
                UpdateDataContext();
            }
        }

     

        private void SearchTextbox(object sender, TextChangedEventArgs e)
        {
            string[] FIO = searchTextBox.Text.Split();

            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                AllClients = Connection.Gym.Clients.ToObservableColletion();
                UpdateDataContext();
            }
            if (FIO.Length == 1)
            {
                AllClients = Connection.Gym.Clients.Where(x => x.Name.Contains(searchTextBox.Text) || x.Surname.Contains(searchTextBox.Text) || x.Patronymic.Contains(searchTextBox.Text)).ToObservableColletion();
                UpdateDataContext();
            }
            else if (FIO.Length == 2)
            {
                string lastName = FIO[0];
                string firstName = FIO[1];
                AllClients = Connection.Gym.Clients.Where(x => x.Name.Contains(lastName) && x.Surname.Contains(firstName)).ToObservableColletion();
                UpdateDataContext();
            }
            else if (FIO.Length == 3)
            {
                string lastName = FIO[0];
                string firstName = FIO[1];
                string patronymic = FIO[2];
                AllClients = Connection.Gym.Clients.Where(x => x.Name.Contains(lastName) && x.Surname.Contains(firstName) && x.Patronymic.Contains(patronymic)).ToObservableColletion();
                UpdateDataContext();
            }
        }
    }
}
