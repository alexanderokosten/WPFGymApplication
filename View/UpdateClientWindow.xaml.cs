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
    /// Логика взаимодействия для UpdateClientWindow.xaml
    /// </summary>
    public partial class UpdateClientWindow : Window
    {
        private Clients originalClient;
        public Clients CurrentClient { get; set; }
        public UpdateClientWindow(Clients selected)
        {
            InitializeComponent();
            originalClient = selected;
            NumberOfContract.Content = "Номер договора: " + originalClient.NumberOfContract;
            Subscription.Content = "Абонемент: " + originalClient.Subscription1.SubscriptionName;
            SubscriptionStratDate.Content = "Начало абонемента: " + originalClient.SubscriptionStartTime;
            SubscriptionEndDate.Content = "Конец абонемента: " + originalClient.SubscriptionEndTime;
            CurrentClient = new Clients
            {

                Name = originalClient.Name,
                Surname = originalClient.Surname,
                Patronymic = originalClient.Patronymic,
                
                DateOfBirth = originalClient.DateOfBirth,
                NumberOfContract = originalClient.NumberOfContract,
                Subscription = originalClient.Subscription,
                SubscriptionStartTime = originalClient.SubscriptionStartTime,
                SubscriptionEndTime = originalClient.SubscriptionEndTime,
                Client_Id = -1
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

                    originalClient.Name = CurrentClient.Name;
                    originalClient.Surname = CurrentClient.Surname;
                    originalClient.Patronymic = CurrentClient.Patronymic;

                    originalClient.DateOfBirth = CurrentClient.DateOfBirth;
                    originalClient.NumberOfContract = CurrentClient.NumberOfContract;
                    originalClient.Subscription = CurrentClient.Subscription;
                    originalClient.SubscriptionStartTime = CurrentClient.SubscriptionStartTime;
                    originalClient.SubscriptionEndTime = CurrentClient.SubscriptionEndTime;
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

        private void NameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю ".IndexOf(e.Text) < 0;
        }

        private void PatronymicTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю ".IndexOf(e.Text) < 0;
        }

        private void BirthdayTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789/,.-".IndexOf(e.Text) < 0;
        }

        private void SurnameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю ".IndexOf(e.Text) < 0;
        }
    }
}
