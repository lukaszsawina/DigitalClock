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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DigitalClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Clock> ClockList;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();

            ClockList = new List<Clock>();
            Clock Warszawa = new Clock();
            Warszawa.City = "Warszawa";
            Warszawa.SetDate();
            Warszawa.SetTime();

            ClockList.Add(Warszawa);

            ClocksList.ItemsSource = ClockList;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var item in ClockList)
            {
                item.SetTime();
            }

            ClocksList.Items.Refresh();
        }
    }
}
