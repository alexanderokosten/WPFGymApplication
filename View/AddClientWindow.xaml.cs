using GymApp.Extensions;
using GymApp.Model;
using Prism.Services.Dialogs;
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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public ObservableCollection<Subscription> AllSubscription { get; set; }
        public ObservableCollection<SexTable> AllSex { get; set; }
        public Clients newClient;
        public AddClientWindow()
        {
            
            InitializeComponent();
           
            AllSex = Connection.Gym.SexTable.ToObservableColletion();
            AllSubscription = Connection.Gym.Subscription.ToObservableColletion();
            
            DataContext = this;
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            try
            {
              

                if (NameTextBox.Text == "" || SurnameTextBox.Text == "" || PatronymicTextBox.Text == "" )
                {
                    MessageBox.Show("Пожалуйста заполните все поля!", "Ошибка..", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    newClient = new Clients
                    {
                        Name = NameTextBox.Text,
                        Surname = SurnameTextBox.Text,
                        Patronymic = PatronymicTextBox.Text,
                        DateOfBirth = BirthdayTextBox.Value.Value,
                        Sex = comboBoxSex.SelectedIndex + 1,
                        NumberOfContract = Convert.ToInt32(NumberOfContractTextBox.Text),
                        Subscription = comboboxSubscription.SelectedIndex+1,
                        SubscriptionStartTime = StartTextBox.Value.Value,
                        SubscriptionEndTime = EndTextBox.Value.Value

                    };


                    Connection.Gym.Clients.Add(newClient);
                    Connection.Gym.SaveChanges();
                    Close();

                }

            }
            catch
            {
                MessageBox.Show("Пожалуйста заполните поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
             
            }
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberOfContract_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void PatronymicTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю ".IndexOf(e.Text) < 0;
        }

        private void SurnameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю ".IndexOf(e.Text) < 0;
        }

        private void NameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю ".IndexOf(e.Text) < 0;
        }

     

        private void StartTextBox_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            EndTextBox.Value = StartTextBox.Value.Value.AddMonths(12);
        }

      

    
        private void CreateDocument(string Name, string Surname, string Patronymic, string NumberOfContractTextBox)
        {
            Subscription subscription = new Subscription();
            subscription.Subscription_Id = comboboxSubscription.SelectedIndex + 1;
            

            var application = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = application.Documents.Add();

            // Set the Range to the first paragraph. 
            Microsoft.Office.Interop.Word.Range rng = document.Paragraphs[1].Range;

            // Change the formatting. To change the font size for a right-to-left language, 
            // such as Arabic or Hebrew, use the Font.SizeBi property instead of Font.Size.
            rng.Font.Size = 14;
            rng.Font.Name = "Arial";
            rng.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

            rng.Select();

            
                Microsoft.Office.Interop.Word.Paragraph userParagraph = document.Paragraphs.Add();
                Microsoft.Office.Interop.Word.Range userRange = userParagraph.Range;

                userRange.Text = $"Я {Name} {Surname} обязуюсь брать на себя ответственность за своё здоровье. Бережно относится к другим посетителям зала. "
                + $"Так же оплачиваю абонемент {comboboxSubscription.Text} в размере {subscription.Summa} рублей.\n\n\n\n\n" + "__________________________ Подпись ";

                //userParagraph.set_Style("Title");
                userRange.InsertParagraphAfter();

                application.Visible = true;

           
           
               

                document.SaveAs2($@"C:\Users\alexa\Desktop\Новое самостоятельное задание\GymApp\Contracts\Договор_{Surname} №{NumberOfContractTextBox}.docx");
                document.SaveAs2($@"C:\Users\alexa\Desktop\Новое самостоятельное задание\GymApp\Contracts\Договор_{Surname}№{NumberOfContractTextBox}.pdf", Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
            

        }

        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int Number = random.Next(0, 100000);
            NumberOfContractTextBox.Text = Number.ToString();
        }

        private void AcceptContract_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Клиент подтвердил покупку абонемента?", "Вопрос", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Отлично! Договор был сохранён и выведен на печать", "Ура!");
                    CreateDocument(NameTextBox.Text, SurnameTextBox.Text, PatronymicTextBox.Text, NumberOfContractTextBox.Text);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "My App");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "My App");
                    break;
            }

                 
        }
    }
}
