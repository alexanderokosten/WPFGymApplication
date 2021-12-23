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
    /// Логика взаимодействия для AddGroupLessonsWindow.xaml
    /// </summary>
    public partial class AddGroupLessonsWindow : Window
    {
        public List<Trainers> Trainers { get; set; }
        public AddGroupLessonsWindow()
        {
            InitializeComponent();
            Trainers = Connection.Gym.Trainers.ToList();
            DataContext = this;
        }

        private void NameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю0123456789() ".IndexOf(e.Text) < 0;

        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            GroupLessons groupLessons = new GroupLessons();
            groupLessons.LessonName = LessonNameTextBox.Text;
            groupLessons.Trainer_Id = TrainersCombobox.SelectedIndex + 1;
            Connection.Gym.GroupLessons.Add(groupLessons);
            Connection.Gym.SaveChanges();
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
