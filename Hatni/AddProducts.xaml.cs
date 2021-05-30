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
    /// Interaction logic for AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Window
    {
        public AddProducts()
        {
            InitializeComponent();
            SetTable();
        }
        private void SetTable()
        {
            DataTable dt = SqlDB.Select("select * from Products");
            List<Product> products = new List<Product>();
            foreach(DataRow dr in dt.Rows)
            {
                products.Add(new Product
                {
                    ID = dr["id"].ToString(),
                    Name = dr["name"].ToString(),
                    Price = dr["price"].ToString()
                });
            }
            Table.ItemsSource = products;
        }
        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9,.]+");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(Name.Text.Length > 0 && Price.Text.Length > 0)
            {
                if (SqlDB.Command($"insert into Products values ('{Name.Text}', {Price.Text})"))
                {
                    MessageBox.Show("Добавлено");
                    SetTable();
                }
            }
            else
            {
                MessageBox.Show("Введите все данные");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ID.Text.Length > 0)
            {
                if (SqlDB.Command($"delete from Products where id = {ID.Text}"))
                {
                    MessageBox.Show("Удалено");
                    SetTable();
                }
            }
            else
            {
                MessageBox.Show("Введите ID");
            }
        }
    }
}
