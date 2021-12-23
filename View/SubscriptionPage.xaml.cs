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
    /// Логика взаимодействия для SubscriptionPage.xaml
    /// </summary>
    public partial class SubscriptionPage : Page
    {
        public ObservableCollection<Subscription> AllSubscription { get; set; }
        
        public SubscriptionPage()
        {
            InitializeComponent();
            AllSubscription = Connection.Gym.Subscription.ToObservableColletion();
            DataContext = this;
        }
    }
}
