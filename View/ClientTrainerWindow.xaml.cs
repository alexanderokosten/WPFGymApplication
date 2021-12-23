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
using System.Windows.Shapes;

namespace GymApp.View
{
    /// <summary>
    /// Логика взаимодействия для ClientTrainerWindow.xaml
    /// </summary>
    public partial class ClientTrainerWindow : Window
    {
        public ObservableCollection<ClientTrainer> AllClients { get; set; }
        public ObservableCollection<ClientTrainer> AllGroupLessons { get; set; }
        Trainers trainer;
        public ClientTrainerWindow(Trainers selected)
        {
            InitializeComponent();
            AllGroupLessons = Connection.Gym.ClientTrainer.ToObservableColletion();

            trainer = selected;
            AllClients = Connection.Gym.ClientTrainer.Where(u => u.Trainer_Id == trainer.Trainer_Id).ToObservableColletion();
            DataContext = this;
        }

        private void SearchTextbox(object sender, TextChangedEventArgs e)
        {
            string[] FIO = searchTextBox.Text.Split();

            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                AllClients = Connection.Gym.ClientTrainer.ToObservableColletion();
                UpdateDataContext();
            }
            if (FIO.Length == 1)
            {
                AllClients = Connection.Gym.ClientTrainer.Where(x => x.Clients.Name.Contains(searchTextBox.Text) || x.Clients.Surname.Contains(searchTextBox.Text) || x.Clients.Patronymic.Contains(searchTextBox.Text)).ToObservableColletion();
                UpdateDataContext();
            }
            else if (FIO.Length == 2)
            {
                string lastName = FIO[0];
                string firstName = FIO[1];
                AllClients = Connection.Gym.ClientTrainer.Where(x => x.Clients.Name.Contains(lastName) && x.Clients.Surname.Contains(firstName)).ToObservableColletion();
                UpdateDataContext();
            }
            else if (FIO.Length == 3)
            {
                string lastName = FIO[0];
                string firstName = FIO[1];
                string patronymic = FIO[2];
                AllClients = Connection.Gym.ClientTrainer.Where(x => x.Clients.Name.Contains(lastName) && x.Clients.Surname.Contains(firstName) && x.Clients.Patronymic.Contains(patronymic)).ToObservableColletion();
                UpdateDataContext();
            }
        }

        private void searchTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void SurnameCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SurnameCombobox.SelectedIndex == 0)
            {
                AllClients = AllClients.OrderByDescending(s => s.Clients.Surname).ToObservableColletion();
                UpdateDataContext();
            }
            else if (SurnameCombobox.SelectedIndex == 1)
            {
                AllClients = AllClients.OrderBy(s => s.Clients.Surname).ToObservableColletion();
                UpdateDataContext();
            }
        }

        private void DeleteClient(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var student = button.Tag as ClientTrainer;

            try
            {

                Connection.Gym.ClientTrainer.Remove(student);
                AllClients.Remove(student);

                Connection.Gym.SaveChanges();
                UpdateDataContext();

            }
            catch
            {
                MessageBox.Show("При сохранение базы произошла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                var clientEntry = Connection.Gym.Entry<ClientTrainer>(student);
                clientEntry.Reload();

                AllClients = Connection.Gym.ClientTrainer.ToObservableColletion();

                UpdateDataContext();
            }
        }
        public void UpdateDataContext()
        {
            DataContext = null;
            DataContext = this;
        }

        private void editWorkouts(object sender, RoutedEventArgs e)
        {
            var button1 = sender as Button;
            var selected = button1.Tag as ClientTrainer;
            if (selected != null)
            {
                var editNumberOfWorkoutsWindow = new editNumberOfWorkoutsWindow(selected);
                editNumberOfWorkoutsWindow.ShowDialog();
            }
        }
    }
}
