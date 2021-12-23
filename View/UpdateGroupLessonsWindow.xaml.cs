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
    /// Логика взаимодействия для UpdateGroupLessonsWindow.xaml
    /// </summary>
    public partial class UpdateGroupLessonsWindow : Window
    {
        private GroupLessons originalGroupLessons;
        public GroupLessons CurrentGroupLessons { get; set; }
        public List<Trainers> Trainers { get; set; }
        public UpdateGroupLessonsWindow(GroupLessons selected)
        {
            InitializeComponent();
            originalGroupLessons = selected;
            Trainers = Connection.Gym.Trainers.ToList();
           
            CurrentGroupLessons = new GroupLessons
            {

               LessonName = originalGroupLessons.LessonName,
               Trainers  = originalGroupLessons.Trainers,

                GroupLessons_Id = -1
            };
            DataContext = this;
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameTextBox.Text == "")
                {
                    MessageBox.Show("Пожалуйста заполните все поля!", "Ошибка..", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {

                    originalGroupLessons.LessonName = CurrentGroupLessons.LessonName;
                    originalGroupLessons.Trainers = TrainersCombobox.SelectedItem as Trainers;
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

        private void CloseButton(object sender, RoutedEventArgs e)
        {

        }

        private void NameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
