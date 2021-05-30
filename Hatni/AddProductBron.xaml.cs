using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hatni
{
    /// <summary>
    /// Interaction logic for AddProductBron.xaml
    /// </summary>
    public partial class AddProductBron : Window
    {
        public AddProductBron()
        {
            InitializeComponent();
            SetData();
        }
        private void SetData()
        {
            DataTable dt = SqlDB.Select($"select * from Products");
            List<string> products = new List<string>();
            foreach(DataRow dr in dt.Rows)
            {
                products.Add(dr["name"].ToString());
            }
            Products.ItemsSource = products;
            dt = SqlDB.Select($"select Bron.id, Tables.number from Bron " +
                "join Tables on Bron.table_id = Tables.id " +
                $"where user_id = {SqlDB.UserID}");
            List<string> numbers = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                numbers.Add(dr["number"].ToString());
            }
            Numbers.ItemsSource = numbers;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int bron_id = SqlDB.GetId($"select Bron.id, Tables.number from Bron " +
                $"join Tables on Bron.table_id = Tables.id " +
                $"where user_id = {SqlDB.UserID} and Tables.number = {Numbers.SelectedItem}");
            int product_id = SqlDB.GetId($"select * from Products where name='{Products.SelectedItem}'");
            if(product_id > 0 && bron_id > 0)
            {
                if (SqlDB.Command($"insert into Bron_Products values ({bron_id}, {product_id})"))
                {
                    MessageBox.Show("Блюдо добавлено");
                    UpdateProducts();
                }
            }
        }
        private void UpdateProducts()
        {
            int bron_id = SqlDB.GetId($"select Bron.id, Tables.number from Bron " +
                $"join Tables on Bron.table_id = Tables.id " +
                $"where user_id = {SqlDB.UserID} and Tables.number = {Numbers.SelectedItem}");
            DataTable dt = SqlDB.Select($"select Bron_Products.id, Products.name, Products.price from Bron_Products " +
                $"join Products on Bron_Products.product_id = Products.id " +
                $"where bron_id ={ bron_id}");
            List<Product> products = new List<Product>();
            foreach (DataRow dr in dt.Rows)
            {
                products.Add(new Product
                {
                    ID = dr["id"].ToString(),
                    Name = dr["name"].ToString(),
                    Price = dr["price"].ToString()
                }); ;
            }
            Table.ItemsSource = products;
        }

        private void Numbers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void ID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(ID.Text.Length > 0)
            {
                if (SqlDB.Command($"delete from Bron_Products where id = {ID.Text}"))
                {
                    MessageBox.Show("Блюдо удалено");
                    UpdateProducts();
                }
            }
            else
            {
                MessageBox.Show("Введите ID");
            }
        }
    }
}
