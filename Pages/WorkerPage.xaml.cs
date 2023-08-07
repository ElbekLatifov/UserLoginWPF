using Microsoft.Win32;
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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
        }

        public void read_btn_Click(object sender, RoutedEventArgs e)
        {
            var query = new ShopSqlQuerys();
            var owner = Properties.Settings.Default.Name;
            List<ShopModel> shopModels = new List<ShopModel>();

            var shops = query.GetShops();

            foreach (var shop in shops)
            {
                ShopModel shopModel = new ShopModel(owner == shop.OwnerName);

                shopModel.Width = shoplists.ActualWidth - 10;
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
            List<ShopModel> shopModels = new List<ShopModel>();
            var search = search_txt.Text;

            if (String.IsNullOrEmpty(search))
            {
                return;
            }

            var query = new ShopSqlQuerys();

            var shops = query.SearchResults(search);

            foreach (var shop in shops)
            {
                ShopModel shopModel = new ShopModel();

                shopModel.Width = shoplists.ActualWidth-10;
                shopModel.Height = 50;
                shopModel.labelcha0 = shop.Id;
                shopModel.labelcha1 = shop.Title;
                shopModel.labelcha2 = shop.Description;
                shopModels.Add(shopModel);
            }

            shoplists.ItemsSource = shopModels;
        }

        private void create_btn_Click(object sender, RoutedEventArgs e)
        {
            var createMenu = new CreateControl();
            List<CreateControl> menu = new List<CreateControl>();
            createMenu.Width = shoplists.ActualWidth - 20;
            createMenu.Height = 450;
            createMenu.Margin = new Thickness(0, 0, 0, 0);
            createMenu.Background = shoplists.Background;
            menu.Add(createMenu);
            shoplists.ItemsSource = menu;
        }

        private void sort_by_description_Selected(object sender, RoutedEventArgs e)
        {
            var select = sort_by_description.SelectedItem;

            List<ShopModel> shopModels = new List<ShopModel>();

            var query = new ShopSqlQuerys();

            var shops = query.SelectResult((int)select);

            foreach (var shop in shops)
            {
                ShopModel shopModel = new ShopModel();

                shopModel.Width = shoplists.ActualWidth - 10;
                shopModel.Height = 50;
                shopModel.labelcha0 = shop.Id;
                shopModel.labelcha1 = shop.Title;
                shopModel.labelcha2 = shop.Description;
                shopModels.Add(shopModel);
            }

            shoplists.ItemsSource = shopModels;
        }

        public void ShopsPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            var sources = new List<Enum>()
            { Profesion.Natural, Profesion.HouseholdUtensils, Profesion.Clothes, Profesion.Technical, Profesion.Food, Profesion.Medicine};
            sort_by_description.ItemsSource = sources;
            sort_by_description.Text = "Sort by description";
            read_btn_Click(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.png;*jpg;.bmp";
            openFileDialog.FilterIndex = 1;
            
            if(openFileDialog.ShowDialog() == true) 
            { 
                PersonalImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));   
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void myshops_btn_Click(object sender, RoutedEventArgs e)
        {
            var query = new ShopSqlQuerys();
            var owner = Properties.Settings.Default.Name;
            List<ShopModel> shopModels = new List<ShopModel>();

            var shops = query.MyShops(owner);

            foreach (var shop in shops)
            {
                ShopModel shopModel = new ShopModel(true);

                shopModel.Width = shoplists.ActualWidth - 10;
                shopModel.Height = 50;
                shopModel.labelcha0 = shop.Id;
                shopModel.labelcha1 = shop.Title;
                shopModel.labelcha2 = shop.Description;
                shopModels.Add(shopModel);
            }

            shoplists.ItemsSource = shopModels;
        }
    }
}
