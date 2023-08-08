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
    /// Логика взаимодействия для Experement.xaml
    /// </summary>
    public partial class Experement : Page
    {
        private int _id;
        public Experement(int id)
        {
            InitializeComponent();
            _id = id;
            Load(id);
        }

        private void Load(int id)
        {
            var query = new ShopSqlQuerys();
            var shops = query.GetShops();
            var shop = shops.Where(p=>p.Id == id).First();
            shopName_lbl.Content = shop.Title;
        }

        private void back_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ShopsPage(allShops: true));
        }

        private void delete_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var query = new ShopSqlQuerys();

            query.DeleteShop(_id);
            NavigationService.Navigate(new ShopsPage(myShops: true));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new UpdatePage(_id));
        }
    }
}
