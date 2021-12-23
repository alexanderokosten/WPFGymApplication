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
    /// Логика взаимодействия для editNumberOfWorkoutsWindow.xaml
    /// </summary>
    public partial class editNumberOfWorkoutsWindow : Window
    {
        private ClientTrainer originalClientTrainer;
        public ClientTrainer CurrentClientTrainer { get; set; }
      
        public editNumberOfWorkoutsWindow(ClientTrainer selected)
        {
            InitializeComponent();
            originalClientTrainer = selected;

            CurrentClientTrainer = new ClientTrainer
            {

                NumberOfWorkouts = originalClientTrainer.NumberOfWorkouts
            };

            DataContext = this;
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NumberOfWorkouts.Text == "")
                {
                    MessageBox.Show("Пожалуйста заполните все поля!", "Ошибка..", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    originalClientTrainer.NumberOfWorkouts = CurrentClientTrainer.NumberOfWorkouts;
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
            this.Close();
        }

        private void Title_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }
    }
}
