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
    /// Логика взаимодействия для GroupLessonsPage.xaml
    /// </summary>
    public partial class GroupLessonsPage : Page
    {
        public ObservableCollection<GroupLessons> AllLessons{ get; set; }
        public GroupLessonsPage()
        {
            InitializeComponent();
            AllLessons = Connection.Gym.GroupLessons.ToObservableColletion();
            DataContext = this;
        }

        private void DeleteClient(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var client = button.Tag as GroupLessons;

            try
            {

                Connection.Gym.GroupLessons.Remove(client);
                AllLessons.Remove(client);

                Connection.Gym.SaveChanges();
                UpdateDataContext();

            }
            catch
            {
                MessageBox.Show("При сохранение базы произошла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                var clientEntry = Connection.Gym.Entry<GroupLessons>(client);
                clientEntry.Reload();

                AllLessons = Connection.Gym.GroupLessons.ToObservableColletion();

                UpdateDataContext();
            }
        }
        public void UpdateDataContext()
        {
            DataContext = null;
            DataContext = this;
        }

        private void UpdateClient(object sender, RoutedEventArgs e)
        {
            var button1 = sender as Button;
            var selected = button1.Tag as GroupLessons;
            if (selected != null)
            {
                UpdateGroupLessonsWindow updateGroupLessonsWindow = new UpdateGroupLessonsWindow(selected);
                updateGroupLessonsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            AddGroupLessonsWindow addGroupLessonsWindow = new AddGroupLessonsWindow();
            addGroupLessonsWindow.ShowDialog();
        }

        private void SearchPhoneTextBox(object sender, TextChangedEventArgs e)
        {

        }

        private void SurnameCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SurnameCombobox.SelectedIndex == 0)
            {
                 AllLessons= AllLessons.OrderByDescending(s => s.LessonName).ToObservableColletion();
                UpdateDataContext();
            }
            else if (SurnameCombobox.SelectedIndex == 1)
            {
                AllLessons = AllLessons.OrderBy(s => s.LessonName).ToObservableColletion();
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
                AllLessons = Connection.Gym.GroupLessons.ToObservableColletion();
                UpdateDataContext();
            }
            if (FIO.Length == 1)
            {
                AllLessons = Connection.Gym.GroupLessons.Where(x => x.LessonName.Contains(searchTextBox.Text)).ToObservableColletion();
                UpdateDataContext();
            }
        }

        private void addClientForGroupLessons(object sender, RoutedEventArgs e)
        {
            var button1 = sender as Button;
            var selected = button1.Tag as GroupLessons;
            if (selected != null)
            {
                var signUpForGroupLessonsWindow = new SignUpForGroupLessonsWindow(selected);
                signUpForGroupLessonsWindow.ShowDialog();
            }
        }

        private void listForGroupLessons(object sender, RoutedEventArgs e)
        {
            var button1 = sender as Button;
            var selected = button1.Tag as GroupLessons;
            if (selected != null)
            {
                var lessonsClientWindow = new LessonsClientWindow(selected);
                lessonsClientWindow.ShowDialog();
            }

           
        }
    }
}
