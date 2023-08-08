using NewNewProject.Managers;
using NewNewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        private int _id;
        public UpdatePage(int id, string lastname, Profesion lastdes)
        {
            InitializeComponent();
            _id = id;
            last_name.Content = lastname;
            last_discription.Content = lastdes;
            add_txt.Text = lastname;
            description_combo.SelectedIndex = (int)(Profesion)lastdes;
        }

        private async void update_btn_Click(object sender, RoutedEventArgs e)
        {
            update_delay.Visibility = Visibility.Visible;
            await Task.Delay(1000);
            update_delay.Visibility=Visibility.Hidden;

            var shopName = add_txt.Text;
            int description = (int)description_combo.SelectedItem;

            var query = new ShopSqlQuerys();

            if (shopName.Length == 0) { MessageBox.Show("Fill places"); return; }

            try
            {
                query.UpdateShop(_id, shopName, description);
                NavigationService.Navigate(new Experement(_id, true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var sources = new List<Enum>()
            { Profesion.Natural, Profesion.HouseholdUtensils, Profesion.Clothes, Profesion.Technical, Profesion.Food, Profesion.Medicine};
            description_combo.ItemsSource = sources;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
