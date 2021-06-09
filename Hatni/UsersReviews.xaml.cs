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
    /// Логика взаимодействия для UsersReviews.xaml
    /// </summary>
    public partial class UsersReviews : Window
    {
        public UsersReviews()
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
            Reviews.ItemsSource = tables;
        }
    }
}
