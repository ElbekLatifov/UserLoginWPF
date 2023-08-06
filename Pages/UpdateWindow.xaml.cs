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
using System.Windows.Shapes;

namespace NewNewProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private int _id;
        public UpdateWindow(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            var shopName = add_txt.Text;
            int description = (int)description_combo.SelectedItem;

            var query = new ShopSqlQuerys();

            if (shopName.Length == 0) { MessageBox.Show("Fill places"); return; }

            try
            {
                query.UpdateShop(_id, shopName, description);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var sources = new List<Enum>()
            { Profesion.Natural, Profesion.HouseholdUtensils, Profesion.Clothes, Profesion.Technical, Profesion.Food, Profesion.Medicine};
            description_combo.ItemsSource = sources;
        }
    }
}
