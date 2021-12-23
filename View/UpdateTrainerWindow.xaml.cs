using GymApp.Model;
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
using System.Windows.Shapes;

namespace GymApp.View
{
    /// <summary>
    /// Логика взаимодействия для UpdateTrainerWindow.xaml
    /// </summary>
    public partial class UpdateTrainerWindow : Window
    {
        private Trainers originalTrainer;
        public Trainers CurrentTrainer { get; set; }
        public UpdateTrainerWindow(Trainers selected)
        {
            
            InitializeComponent();
            originalTrainer = selected;
            CurrentTrainer = new Trainers
            {

                Name = originalTrainer.Name,
                Surname = originalTrainer.Surname,
                Patronymic = originalTrainer.Patronymic,

                DateOfBirth = originalTrainer.DateOfBirth,
                CoachingExperience = originalTrainer.CoachingExperience,
                ParticularQualities = originalTrainer.ParticularQualities,
              
                Trainer_Id = -1
            };
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

                    originalTrainer.Name = CurrentTrainer.Name;
                    originalTrainer.Surname = CurrentTrainer.Surname;
                    originalTrainer.Patronymic = CurrentTrainer.Patronymic;

                    originalTrainer.DateOfBirth = CurrentTrainer.DateOfBirth;
                    originalTrainer.CoachingExperience = CurrentTrainer.CoachingExperience;
                    originalTrainer.ParticularQualities = CurrentTrainer.ParticularQualities;
                    Connection.Gym.SaveChanges();
                    MessageBox.Show("Изменение сохранено!", "Ура!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void BirthdayTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789-,./".IndexOf(e.Text) < 0;
        }

        private void CoachingExperienceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789,.".IndexOf(e.Text) < 0;
        }

        private void PalicularQualitiesTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю/(),. ".IndexOf(e.Text) < 0;
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
