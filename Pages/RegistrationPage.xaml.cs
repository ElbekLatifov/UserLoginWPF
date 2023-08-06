using NewNewProject.Managers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;

namespace NewNewProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private int eye_counter = 0;
        private int eye_counter2 = 0;
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage.NavigationService.Navigate(new MainMenuPage());
        }

        private void reg_btn_Click(object sender, RoutedEventArgs e)
        {
            var username = login_txt.Text;
            var password = pass.Password;
            var confirm_password = con_pass.Password;

            var query = new UserSqlQuerys();

            if (username.Length == 0 || (password.Length == 0 && pass2.Text.Length == 0) || (confirm_password.Length == 0 && con_pass2.Text.Length == 0))
            {
                MessageBox.Show("fill in the required fields");
                return;
            }

            if (query.CheckUser(username))
            {
                MessageBox.Show("User already exist");
                return;
            }

            if (!IsValidPassword(password))
            {
                valid_lbl.Content = "Minimum 8 characters, at least one uppercase letter, one lowercase letter and one number";
                return;
            }

            if ((password != confirm_password) || (pass2.Text != con_pass2.Text) || (password != con_pass2.Text) || (pass2.Text != con_pass.Password))
            {
                MessageBox.Show("Password not same");
                return;
            }
            var hash = GenerateHash(password);
            query.CreateUser(username, hash);
            MessageBox.Show("Succesfull");
        }

        public string GenerateHash(string password)
        {
            var hasher = new SHA256Managed();
            var unhashed = System.Text.Encoding.Unicode.GetBytes(password);
            var hashed = hasher.ComputeHash(unhashed);

            var hashedPassword = Convert.ToBase64String(hashed);
            return hashedPassword;
        }

        private bool IsValidPassword(string password)
        {
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
            if (string.IsNullOrWhiteSpace(password))
                return false;
            var result = Regex.Match(password, pattern);

            if (result.Success)
            {
                return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage.NavigationService.Navigate(new MainMenuPage());
        }

        private void pass_name_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (eye_counter == 2)
            {
                eye_counter = 0;
            }
            if (eye_counter == 0)
            {
                pass2.Visibility = Visibility.Visible;
                pass.Visibility = Visibility.Hidden;
                pass2.Text = pass.Password;
                pass_name.Source =
                    new BitmapImage(new Uri("/Pages/eye close.png", UriKind.Relative));
                eye_counter = 1;
            }
            else if (eye_counter == 1)
            {
                pass2.Visibility = Visibility.Hidden;
                pass.Visibility = Visibility.Visible;
                pass.Password = pass2.Text;
                pass_name.Source =
                    new BitmapImage(new Uri("/Pages/eye open.png", UriKind.Relative));
                eye_counter = 2;
            }
        }

        private void conpassname_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (eye_counter2 == 2)
            {
                eye_counter2 = 0;
            }
            if (eye_counter2 == 0)
            {
                con_pass2.Visibility = Visibility.Visible;
                con_pass.Visibility = Visibility.Hidden;
                con_pass2.Text = con_pass.Password;
                conpassname.Source =
                    new BitmapImage(new Uri("/Pages/eye close.png", UriKind.Relative));
                eye_counter2 = 1;
            }
            else if (eye_counter2 == 1)
            {
                con_pass2.Visibility = Visibility.Hidden;
                con_pass.Visibility = Visibility.Visible;
                con_pass.Password = con_pass2.Text;
                conpassname.Source =
                    new BitmapImage(new Uri("/Pages/eye open.png", UriKind.Relative));
                eye_counter2 = 2;
            }
        }
    }
}
