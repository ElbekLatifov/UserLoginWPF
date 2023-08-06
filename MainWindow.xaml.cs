using NewNewProject.Pages;
using System;
using System.Windows;
using System.Windows.Threading;

namespace NewNewProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int second = 0;
        private int hour = 0;
        private int minut = 0;
        public MainWindow()
        {
            InitializeComponent();
            mainframe.Navigate(new MainMenuPage());
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval += TimeSpan.FromSeconds(1);
            timer.Tick += DateShower;
            timer.Start();
            hour_lbl.Content = 0;
            minut_lbl.Content = 0;
            second_lbl.Content = 0;
        }

        private void DateShower(object sender, EventArgs e)
        {
            second++;
            if(second == 60)
            {
                second = 0;
                minut++;
            }
            if(minut == 60)
            {
                minut = 0;
                hour ++;
            }
            hour_lbl.Content = hour;
            minut_lbl.Content = minut;
            second_lbl.Content = second;
        }

        private void Page1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
