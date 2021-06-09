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
using Excel = Microsoft.Office.Interop.Excel;

namespace Hatni
{
    /// <summary>
    /// Interaction logic for BronWindow.xaml
    /// </summary>
    public partial class BronWindow : Window
    {
        public BronWindow()
        {
            InitializeComponent();
            SetBrons();
        }

        private void SetBrons()
        {
            DataTable dt = SqlDB.Select("select Bron.id, Users.email, [Tables].number, [Events].[name], [Events].[date], telephone, [time] from Bron" +
                " join[Tables] on Bron.table_id = [Tables].id" +
                " join Users on Bron.[user_id] = Users.id" +
                " join[Events] on Bron.event_id = [Events].id");
            List<BronItem> tables = new List<BronItem>();
            foreach (DataRow dr in dt.Rows)
            {
                tables.Add(new BronItem { 
                    ID = dr["id"].ToString(),
                    Email = dr["email"].ToString(), 
                    Telephone = dr["telephone"].ToString(),
                    Number = dr["number"].ToString(),
                    Name = dr["name"].ToString(),
                    Date = dr["date"].ToString(),
                    Time = dr["time"].ToString()
                });
            }
            Table.ItemsSource = tables;
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application ExcelApp = new Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;

            ExcelApp.Cells[1, 1] = "Email";
            ExcelApp.Cells[1, 2] = "Телефон";
            ExcelApp.Cells[1, 3] = "Номер стола";
            ExcelApp.Cells[1, 4] = "Название мероприятия";
            ExcelApp.Cells[1, 5] = "Дата";
            ExcelApp.Cells[1, 6] = "Время";

            var list = Table.Items.OfType<BronItem>().ToList();

            for (int j = 0; j < list.Count; j++)
            {
                ExcelApp.Cells[j + 2, 1] = list[j].Email;
                ExcelApp.Cells[j + 2, 2] = list[j].Telephone;
                ExcelApp.Cells[j + 2, 3] = list[j].Number;
                ExcelApp.Cells[j + 2, 4] = list[j].Name;
                ExcelApp.Cells[j + 2, 5] = list[j].Date;
                ExcelApp.Cells[j + 2, 6] = list[j].Time;
            }
            ExcelApp.Visible = true;
        }

        private void IdBron_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]+");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(IdBron.Text);
            DataTable dt = SqlDB.Select($"select * from Bron_Products join Products on Products.id = Bron_Products.product_id where bron_id={id}");
            List<Product> products = new List<Product>();
            foreach(DataRow dr in dt.Rows)
            {
                products.Add(new Product { Name = dr["name"].ToString(), Price = dr["price"].ToString() });
            }
            Products.ItemsSource = products;
        }
    }
}
