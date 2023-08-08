using Google.Protobuf.WellKnownTypes;
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
using Enum = System.Enum;

namespace NewNewProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShopsPage.xaml
    /// </summary>
    public partial class ShopsPage : Page
    {
        private bool _showShops;
        private bool _myShops;
        public ShopsPage(
            bool allShops = false, 
            bool myShops = false)
        {
            InitializeComponent();
            _showShops = allShops;
            _myShops = myShops;
            Page_Loaded();
        }

        private void Page_Loaded()
        {
            if (_myShops)
            {
                var query = new ShopSqlQuerys();
                var owner = Properties.Settings.Default.Name;
                List<ShopModel> shopModels = new List<ShopModel>();

                var shops = query.MyShops(owner);

                foreach (var shop in shops)
                {
                    ShopModel shopModel = new ShopModel();

                    shopModel.Width = 530;
                    shopModel.Height = 50;
                    shopModel.labelcha0 = shop.Id;
                    shopModel.labelcha1 = shop.Title;
                    shopModel.labelcha2 = shop.Description;
                    shopModels.Add(shopModel);
                }

                shoplists.ItemsSource = shopModels;
            }
            if(_showShops)
            {
                var query = new ShopSqlQuerys();
                var owner = Properties.Settings.Default.Name;
                List<ShopModel> shopModels = new List<ShopModel>();

                var shops = query.GetShops();

                foreach (var shop in shops)
                {
                    ShopModel shopModel = new ShopModel();

                    shopModel.Width = 530;
                    shopModel.Height = 50;
                    shopModel.labelcha0 = shop.Id;
                    shopModel.labelcha1 = shop.Title;
                    shopModel.labelcha2 = shop.Description;
                    shopModels.Add(shopModel);
                }

                shoplists.ItemsSource = shopModels;
            }
        }

        private void shoplists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = shoplists.SelectedItem as ShopModel;
            var id = (int)selected!.labelcha0;
            NavigationService.Navigate(new Experement(id));
        }

        private void sort_by_description_Selected(object sender, SelectionChangedEventArgs e)
        {
            var _eNum = sort_by_description.SelectedItem;
            List<ShopModel> shopModels = new List<ShopModel>();
            var query = new ShopSqlQuerys();

            var shops = query.SelectResult((int)_eNum);

            foreach (var shop in shops)
            {
                ShopModel shopModel = new ShopModel();

                shopModel.Width = 530;
                shopModel.Height = 50;
                shopModel.labelcha0 = shop.Id;
                shopModel.labelcha1 = shop.Title;
                shopModel.labelcha2 = shop.Description;
                shopModels.Add(shopModel);
            }

            shoplists.ItemsSource = shopModels;
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(search_txt.Text))
            {
                return;
            }
            var shopModels = new List<ShopModel>();
            var query = new ShopSqlQuerys();

            var shops = query.SearchResults(search_txt.Text);

            foreach (var shop in shops)
            {
                ShopModel shopModel = new ShopModel();

                shopModel.Width = 530;
                shopModel.Height = 50;
                shopModel.labelcha0 = shop.Id;
                shopModel.labelcha1 = shop.Title;
                shopModel.labelcha2 = shop.Description;
                shopModels.Add(shopModel);
            }

            shoplists.ItemsSource = shopModels;
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            var sources = new List<Enum>()
            { Profesion.Natural, Profesion.HouseholdUtensils, Profesion.Clothes, Profesion.Technical, Profesion.Food, Profesion.Medicine};
            sort_by_description.ItemsSource = sources;
        }
    }
}
