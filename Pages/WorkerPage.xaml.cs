using Microsoft.Win32;
using NewNewProject.Managers;
using NewNewProject.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

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
            Salom.Navigate(new ShopsPage(allShops: true));
        }

        private void create_btn_Click(object sender, RoutedEventArgs e)
        {
            Salom.Navigate(new CreatePage());
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
            NavigationService.Navigate(new MainMenuPage());
        }

        private void myshops_btn_Click(object sender, RoutedEventArgs e)
        {
            Salom.Navigate(new ShopsPage(myShops : true));
        }
    }
}
