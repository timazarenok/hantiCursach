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
    /// Interaction logic for EventsWindow.xaml
    /// </summary>
    public partial class EventsWindow : Window
    {
        public EventsWindow()
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
            Table.ItemsSource = tables;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.Command($"insert into Events values ('{Name.Text}', '{Date.SelectedDate}')"))
            {
                MessageBox.Show("Успешно добавлен");
                SetEvents();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SqlDB.Command($"delete from Events where [name] = '{Name.Text}'"))
            {
                MessageBox.Show("Успешно удален");
                SetEvents();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }
    }
}
