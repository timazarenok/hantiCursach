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
using System.Windows.Shapes;

namespace Hatni
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Tables_Click(object sender, RoutedEventArgs e)
        {
            TablesWindow window = new TablesWindow();
            window.Show();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            EventsWindow window = new EventsWindow();
            window.Show();
        }

        private void Reviews_Click(object sender, RoutedEventArgs e)
        {
            ReviewsWindow window = new ReviewsWindow();
            window.Show();
        }

        private void Bron_Click(object sender, RoutedEventArgs e)
        {
            BronWindow window = new BronWindow();
            window.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            AddProducts window = new AddProducts();
            window.Show();
        }
    }
}
