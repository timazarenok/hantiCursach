using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Hatni
{
    /// <summary>
    /// Interaction logic for MyBronWindow.xaml
    /// </summary>
    public partial class MyBronWindow : Window
    {
        public MyBronWindow()
        {
            InitializeComponent();
            SetTable();
        }
        private void SetTable()
        {
            DataTable dt = SqlDB.Select($"select Bron.id, Tables.number, Events.name, time from Bron " +
                $"join Tables on Bron.table_id = Tables.id " +
                $"join Events on Bron.event_id = Events.id where user_id = {SqlDB.UserID}");
            List<BronItem> brons = new List<BronItem>();
            foreach(DataRow dr in dt.Rows)
            {
                brons.Add(new BronItem
                {
                    ID = dr["id"].ToString(),
                    Number = dr["number"].ToString(),
                    Name = dr["name"].ToString(),
                    Time = dr["name"].ToString()
                });
            }
            Table.ItemsSource = brons;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ID.Text.Length > 0)
            {
                if (SqlDB.Command($"delete from Bron where id = {ID.Text}")) 
                {
                    MessageBox.Show("Бронь отменена");
                    SetTable();
                }
            }
            else
            {
                MessageBox.Show("Введите ID");
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductBron window = new AddProductBron();
            window.Show();
        }
    }
}
