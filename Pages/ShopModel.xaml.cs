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
    /// Логика взаимодействия для ShopModel.xaml
    /// </summary>
    public partial class ShopModel : UserControl
    {
        public ShopModel()
        {
            InitializeComponent();
        }

        public object labelcha0
        {
            get
            {
                return id.Content;
            }
            set
            {
                id.Content = value;
            }
        }

        public object labelcha1
        {
            get
            {
                return label_name.Content;
            }
            set
            {
                label_name.Content = value;
            }
        }

        public object labelcha2
        {
            get
            {
                return label_description.Content;
            }
            set
            {
                label_description.Content = value;
            }
        }


        private void delete_button(object sender, RoutedEventArgs e)
        {
            var hh = id.Content;

            var query = new ShopSqlQuerys();

            query.DeleteShop((int)hh);
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            //var hh = id.Content;
            //var link = new UpdateWindow((int)hh);
            //link.Show();
        }
    }
}
