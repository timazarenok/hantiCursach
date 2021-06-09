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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hatni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetEvents();
        }
        private void SetEvents()
        {
            DataTable dt = SqlDB.Select("select * from Events");
            List<EventItem> tables = new List<EventItem>();
            foreach (DataRow dr in dt.Rows)
            {
                tables.Add(new EventItem { Name = dr["name"].ToString(), Date = dr["date"].ToString() });
            }
            Events.ItemsSource = tables;
        }

        private void Events_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            sender = Events.SelectedItem;
            EventItem ev = (EventItem)sender;

            AddBronWindow window = new AddBronWindow(ev);
            window.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text.Length > 0)
            {
                if (SqlDB.Command($"insert into Reviews values ({SqlDB.UserID}, '{Text.Text}')"))
                {
                    MessageBox.Show("Успешно отправлен");
                }
            }
            else
            {
                MessageBox.Show("Введите отзыв");
            }
        }

        private void MyTables_Click(object sender, RoutedEventArgs e)
        {
            MyBronWindow window = new MyBronWindow();
            window.Show();
        }

        private void Reviews_Click(object sender, RoutedEventArgs e)
        {
            UsersReviews window = new UsersReviews();
            window.Show();
        }
    }
}
