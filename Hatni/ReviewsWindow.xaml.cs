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
using Excel = Microsoft.Office.Interop.Excel;

namespace Hatni
{
    /// <summary>
    /// Interaction logic for ReviewsWindow.xaml
    /// </summary>
    public partial class ReviewsWindow : Window
    {
        public ReviewsWindow()
        {
            InitializeComponent();
            SetReviews();
        }
        private void SetReviews()
        {
            DataTable dt = SqlDB.Select("select email, [text] from Reviews join Users on Reviews.user_id = Users.id");
            List<ReviewItem> tables = new List<ReviewItem>();
            foreach (DataRow dr in dt.Rows)
            {
                tables.Add(new ReviewItem { Email = dr["email"].ToString(), Text = dr["text"].ToString() });
            }
            Table.ItemsSource = tables;
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application ExcelApp = new Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 15;

            ExcelApp.Cells[1, 1] = "Email";
            ExcelApp.Cells[1, 2] = "Отзыв";

            var list = Table.Items.OfType<ReviewItem>().ToList();

            for (int j = 0; j < list.Count; j++)
            {
                ExcelApp.Cells[j + 2, 1] = list[j].Email;
                ExcelApp.Cells[j + 2, 2] = list[j].Text;
            }
            ExcelApp.Visible = true;
        }
    }
}
