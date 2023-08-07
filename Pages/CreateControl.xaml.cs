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
    /// Логика взаимодействия для CreateControl.xaml
    /// </summary>
    public partial class CreateControl : UserControl
    {
        public CreateControl()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            var shopName = add_txt.Text;
            int description = (int)description_combo.SelectedItem;

            var query = new ShopSqlQuerys();

            if (shopName.Length == 0) { MessageBox.Show("Fill in the required fields"); return; }
            var owner = Properties.Settings.Default.Name;

            query.CreateShop(shopName, description, owner);
            
        }

        private void createModel_Loaded(object sender, RoutedEventArgs e)
        {
            var items = new List<Enum>() { Profesion.Natural, Profesion.HouseholdUtensils, Profesion.Clothes, Profesion.Technical, Profesion.Medicine, Profesion.Food };
            description_combo.ItemsSource = items;
            description_combo.Text = "Description";
        }
    }
}
