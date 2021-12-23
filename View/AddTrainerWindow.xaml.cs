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
    /// Логика взаимодействия для AddTrainerWindow.xaml
    /// </summary>
    public partial class AddTrainerWindow : Window
    {
        public ObservableCollection<SexTable> AllSex { get; set; }

        public Trainers newTrainer;
        public AddTrainerWindow()
        {
            InitializeComponent();
            
            AllSex = Connection.Gym.SexTable.ToObservableColletion();
            DataContext = this;
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            try
            {


                if (NameTextBox.Text == "" || SurnameTextBox.Text == "" || PatronymicTextBox.Text == "")
                {
                    MessageBox.Show("Пожалуйста заполните все поля!", "Ошибка..", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    newTrainer = new Trainers
                    {
                        Name = NameTextBox.Text,
                        Surname = SurnameTextBox.Text,
                        Patronymic = PatronymicTextBox.Text,
                        DateOfBirth = BirthdayTextBox.Value.Value,
                        Sex = comboBoxSex.SelectedIndex + 1,
                        CoachingExperience = Convert.ToDouble(CoachingExperienceTextBox.Text),
                        ParticularQualities = ParicularQualitiesTextBox.Text


                    };


                    Connection.Gym.Trainers.Add(newTrainer);
                    Connection.Gym.SaveChanges();
                    Close();

                }

            }
            catch
            {
                MessageBox.Show("Пожалуйста заполните поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                //foreach (var entityError in ex.EntityValidationErrors)
                //{
                //    foreach (var validationError in entityError.ValidationErrors)
                //    {
                //        //errorLabel.Content += validationError.ErrorMessage + "\n";
                //    }
                //}
            }
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю ".IndexOf(e.Text) < 0;
        }

        private void SurnameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю ".IndexOf(e.Text) < 0;
        }

        private void PatronymicTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю ".IndexOf(e.Text) < 0;
        }

        private void CoachingExperienceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789.,".IndexOf(e.Text) < 0;
        }

        private void ParicularQualitiesTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю0123456789#№,/. ".IndexOf(e.Text) < 0;
        }
    }
}
