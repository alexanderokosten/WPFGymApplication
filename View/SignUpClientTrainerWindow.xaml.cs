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
    /// Логика взаимодействия для SignUpClientTrainerWindow.xaml
    /// </summary>
    public partial class SignUpClientTrainerWindow : Window
    {
        public List<Trainers> Trainers { get; set; }
      
        public Clients Client;
        public SignUpClientTrainerWindow(Clients selected)
        {
            InitializeComponent();
            Client = selected;
            Trainers = Connection.Gym.Trainers.ToList();
            Name.Content = "Имя: " + Client.Name;
            Lastname.Content = "Фамилия: " + Client.Surname;
            Patronimyc.Content = "Отчество: " + Client.Patronymic;
          
            DataContext = this;
        }

        private void NumberOfWorkouts_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            ClientTrainer clientTrainer = new ClientTrainer();
            clientTrainer.Client_Id =Client.Client_Id;
            clientTrainer.Trainer_Id = TrainersCombobox.SelectedIndex + 1;
            clientTrainer.NumberOfWorkouts = Convert.ToInt32(NumberOfWorkoutsTextBox.Text);
            Connection.Gym.ClientTrainer.Add(clientTrainer);
            Connection.Gym.SaveChanges();
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
