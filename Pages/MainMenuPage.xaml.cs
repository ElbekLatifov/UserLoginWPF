using NewNewProject.Managers;
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

namespace NewNewProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        private int eye_counter = 0;
        private string password_change = string.Empty;

        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage.NavigationService.Navigate(new RegistrationPage());    
        }

        private void enter_btn_Click(object sender, RoutedEventArgs e)
        {
            var username = register_txt.Text;
            var password = parol_txt.Password;
            var invisiblepassword = parol_tx.Text;

            if (username.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Enter your login and password");
                return;
            }

            var qury = new UserSqlQuerys();

            if (qury.CheckUser(username))
            {
                try
                {
                    var user = qury.GetUser(username);
                    var page = new RegistrationPage();
                    var hash = page.GenerateHash(password);
                    var invisiblehash = page.GenerateHash(invisiblepassword);

                    if (hash == user.Password || invisiblehash == user.Password)
                    {
                        if ((bool)checkMe.IsChecked!)
                        {
                            Properties.Settings.Default.Password = password;
                            Properties.Settings.Default.Owner = username;
                            Properties.Settings.Default.RememberMe = true;
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Name = username;
                        }
                        else
                        {
                            Properties.Settings.Default.Name = username;
                        }
                        MainPage.NavigationService.Navigate(new WorkerPage());
                    }
                    else
                    {
                        MessageBox.Show("Invalid password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (eye_counter == 2)
            {
                eye_counter = 0;
            }
            if (eye_counter == 0)
            {
                parol_tx.Visibility = Visibility.Visible;
                parol_txt.Visibility = Visibility.Hidden;
                eye.Source =
                    new BitmapImage(new Uri("/Pages/eye close.png", UriKind.Relative));
                eye_counter = 1;
            }
            else if (eye_counter == 1)
            {
                parol_tx.Visibility = Visibility.Hidden;
                parol_txt.Visibility = Visibility.Visible;
                eye.Source =
                    new BitmapImage(new Uri("/Pages/eye open.png", UriKind.Relative));
                eye_counter = 2;
            }
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                register_txt.Text = Properties.Settings.Default.Owner;
                parol_txt.Password = Properties.Settings.Default.Password;
            }
        }

        private void parol_tx_TextChanged(object sender, TextChangedEventArgs e)
        {
            parol_txt.Password = parol_tx.Text;
        }

        private void parol_txt_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(!parol_txt.IsVisible)
            {
                parol_tx.Text = parol_txt.Password;
            }
        }
    }
}
