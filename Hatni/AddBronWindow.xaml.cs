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
    /// Interaction logic for AddBronWindow.xaml
    /// </summary>
    public partial class AddBronWindow : Window
    {
        public EventItem Ev { get; set; }
        public AddBronWindow(EventItem ev)
        {
            InitializeComponent();
            Ev = ev;
            LabelBron.Content += ev.Name;
            SetTables();
        }
        private void SetTables()
        {
            int event_id = SqlDB.GetId($"select * from Events where name='{Ev.Name}'");
            DataTable dt = SqlDB.Select($"SELECT * FROM Tables WHERE NOT EXISTS (SELECT * FROM Bron WHERE Bron.table_id = Tables.id and Bron.event_id != {event_id});");
            List<string> tables = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                tables.Add(dr["number"].ToString());
            }
            Table.ItemsSource = tables;
        }
        private void Telephone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,+]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TimeBron_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("/d{0,2}:/d{0,2}");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(Telephone.Text.Length > 0 && TimeBron.Text.Length > 0)
            {
                int table_id = SqlDB.GetId($"select * from Tables where number={Table.SelectedItem}"); ;
                int event_id = SqlDB.GetId($"select * from Events where name='{Ev.Name}'");
                if(SqlDB.Command($"insert into Bron values({table_id},{SqlDB.UserID},{event_id}, '{Telephone.Text}', '{TimeBron.Text}')"))
                {
                    MessageBox.Show("Бронь утверждена");
                }
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }
    }
}
