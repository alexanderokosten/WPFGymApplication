using GymApp.Extensions;
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
    /// Логика взаимодействия для SignUpForGroupLessonsWindow.xaml
    /// </summary>
    public partial class SignUpForGroupLessonsWindow : Window
    {
        public List<Clients> AllClients { get; set; }

        public GroupLessons GroupLessons;
        public SignUpForGroupLessonsWindow(GroupLessons selected)
        {
            InitializeComponent();
            GroupLessons = selected;
            AllClients = Connection.Gym.Clients.ToList();
            Name.Content = "Название: " + GroupLessons.LessonName;
           
            DataContext = this;
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            
            SignUpForGroupLessons signUpForGroupLessons = new SignUpForGroupLessons();
            signUpForGroupLessons.GroupLessons_Id = GroupLessons.GroupLessons_Id;
            signUpForGroupLessons.Client_Id = (int)ClientsCombobox.SelectedValue;
            signUpForGroupLessons.DateStart = StartTextBox.Value.Value;
            signUpForGroupLessons.DateEnd = EndTextBox.Value.Value;
            Connection.Gym.SignUpForGroupLessons.Add(signUpForGroupLessons);
            Connection.Gym.SaveChanges();
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {

        }

        private void StartTextBox_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            EndTextBox.Value = StartTextBox.Value.Value.AddHours(1);
        }
    }
}
