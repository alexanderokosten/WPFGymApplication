using GymApp.Extensions;
using GymApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Логика взаимодействия для TrainerPage.xaml
    /// </summary>
    public partial class TrainerPage : Page
    {
        public ObservableCollection<Trainers> AllTrainers { get; set; }
        public TrainerPage()
        {
            InitializeComponent();
            AllTrainers = Connection.Gym.Trainers.ToObservableColletion();
            DataContext = this;
        }

        private void UpdateClient(object sender, RoutedEventArgs e)
        {
            var button1 = sender as Button;
            var selected = button1.Tag as Trainers;
            if (selected != null)
            {
                UpdateTrainerWindow updateTrainerWindow = new UpdateTrainerWindow(selected);
                updateTrainerWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void DeleteClient(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var client = button.Tag as Trainers;

            try
            {

                Connection.Gym.Trainers.Remove(client);
                AllTrainers.Remove(client);

                Connection.Gym.SaveChanges();
                UpdateDataContext();

            }
            catch
            {
                MessageBox.Show("При сохранение базы произошла ошибка, проверьте, что на групповое занятие пользователь не записан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                var clientEntry = Connection.Gym.Entry<Trainers>(client);
                clientEntry.Reload();

                AllTrainers = Connection.Gym.Trainers.ToObservableColletion();

                UpdateDataContext();
            }
        }
        public void UpdateDataContext()
        {
            DataContext = null;
            DataContext = this;
        }
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            AddTrainerWindow addTrainerWindow = new AddTrainerWindow();
         
            addTrainerWindow.ShowDialog();
        }

        private void SearchPhoneTextBox(object sender, TextChangedEventArgs e)
        {

        }

        private void SurnameCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SurnameCombobox.SelectedIndex == 0)
            {
                AllTrainers = AllTrainers.OrderByDescending(s => s.Surname).ToObservableColletion();
                UpdateDataContext();
            }
            else if (SurnameCombobox.SelectedIndex == 1)
            {
                AllTrainers = AllTrainers.OrderBy(s => s.Surname).ToObservableColletion();
                UpdateDataContext();
            }
        }

        private void searchTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void SearchTextbox(object sender, TextChangedEventArgs e)
        {
            string[] FIO = searchTextBox.Text.Split();

            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                AllTrainers = Connection.Gym.Trainers.ToObservableColletion();
                UpdateDataContext();
            }
            if (FIO.Length == 1)
            {
                AllTrainers = Connection.Gym.Trainers.Where(x => x.Name.Contains(searchTextBox.Text) || x.Surname.Contains(searchTextBox.Text) || x.Patronymic.Contains(searchTextBox.Text)).ToObservableColletion();
                UpdateDataContext();
            }
            else if (FIO.Length == 2)
            {
                string lastName = FIO[0];
                string firstName = FIO[1];
                AllTrainers = Connection.Gym.Trainers.Where(x => x.Name.Contains(lastName) && x.Surname.Contains(firstName)).ToObservableColletion();
                UpdateDataContext();
            }
            else if (FIO.Length == 3)
            {
                string lastName = FIO[0];
                string firstName = FIO[1];
                string patronymic = FIO[2];
                AllTrainers = Connection.Gym.Trainers.Where(x => x.Name.Contains(lastName) && x.Surname.Contains(firstName) && x.Patronymic.Contains(patronymic)).ToObservableColletion();
                UpdateDataContext();
            }
        }

        private void listClientsForTrainer(object sender, RoutedEventArgs e)
        {
            var button1 = sender as Button;
            var selected = button1.Tag as Trainers;
            if (selected != null)
            {
                var clientTrainerWindow = new ClientTrainerWindow(selected);
                clientTrainerWindow.ShowDialog();
            }

        }
    }
}
