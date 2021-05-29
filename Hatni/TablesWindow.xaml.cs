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
    /// Interaction logic for TablesWindow.xaml
    /// </summary>
    public partial class TablesWindow : Window
    {
        public TablesWindow()
        {
            InitializeComponent();
            SetTables();
        }
        private void SetTables()
        {
            DataTable dt = SqlDB.Select("select * from Tables");
            List<TableItem> tables = new List<TableItem>();
            foreach(DataRow dr in dt.Rows)
            {
                tables.Add(new TableItem { Number = dr["number"].ToString(), Amount = dr["amount"].ToString() });
            }
            Table.ItemsSource = tables;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(SqlDB.Command($"insert into Tables values ({Number.Text}, {Amount.Text})"))
            {
                MessageBox.Show("Успешно добавлен");
                SetTables();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.Command($"delete from Tables where [number] = {Number.Text}"))
            {
                MessageBox.Show("Успешно удален");
                SetTables();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
