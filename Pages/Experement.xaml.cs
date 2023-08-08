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
    /// Логика взаимодействия для Experement.xaml
    /// </summary>
    public partial class Experement : Page
    {
        private int _id;
        public Experement(int id, bool isOwner = false)
        {
            InitializeComponent();
            _id = id;
            Load(id);
            CheckOwner(isOwner);
        }

        private void CheckOwner(bool  isOwner)
        {
            if (!isOwner)
            {
                delete_btn.Visibility = Visibility.Hidden;
                update_btn.Visibility= Visibility.Hidden;
            }
        }

        private void Load(int id)
        {
            var query = new ShopSqlQuerys();
            var shops = query.GetShops();
            var shop = shops.Where(p=>p.Id == id).First();
            shopName_lbl.Content = shop.Title;
            description_lbl.Content = shop.Description;
        }

        private void back_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ShopsPage(allShops: true));
        }

        private void delete_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var query = new ShopSqlQuerys();

            query.DeleteShop(_id);
            NavigationService.Navigate(new ShopsPage(allShops: true));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lastName = shopName_lbl.Content;
            var lastDes = description_lbl.Content;
            NavigationService.Navigate(new UpdatePage(_id, lastName.ToString(), (Profesion)lastDes));
        }
    }
}
