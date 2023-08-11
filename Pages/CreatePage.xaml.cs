using NewNewProject.Managers;
using NewNewProject.Models;
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
    /// Логика взаимодействия для CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        public CreatePage()
        {
            InitializeComponent();
        }

        private async void add_btn_Click(object sender, RoutedEventArgs e)
        {
            gif_image.Visibility = Visibility.Visible;
            await Task.Delay(700);
            gif_image.Visibility = Visibility.Hidden;

            var shopName = add_txt.Text;
            int description = (int)description_combo.SelectedItem;

            var query = new ShopSqlQuerys();

            if (shopName.Length == 0) { MessageBox.Show("Fill in the required fields"); return; }
            var owner = Properties.Settings.Default.Name;

            query.CreateShop(shopName, description, owner);

            NavigationService.Navigate(new ShopsPage(allShops: true));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var items = new List<Enum>() { Profesion.Food, Profesion.HouseholdUtensils, Profesion.Clothes, Profesion.Technical, Profesion.Natural, Profesion.Medicine };
            description_combo.ItemsSource = items;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
