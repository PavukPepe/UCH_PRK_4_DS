using PRACT_LAB_2_DS.VOD_DSTableAdapters;
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

namespace PRACT_LAB_2_DS
{
    /// <summary>
    /// Логика взаимодействия для Post_page.xaml
    /// </summary>
    public partial class Post_page : Page
    {
        PostsTableAdapter posts = new PostsTableAdapter();
        public Post_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = posts.GetData();
            post_id_filter.ItemsSource = posts.GetData();
            post_name_filter.ItemsSource = posts.GetData();
            post_salary_filter.ItemsSource = posts.GetData();
            post_id_filter.DisplayMemberPath = "post_id";
            post_name_filter.DisplayMemberPath = "post_name";
            post_salary_filter.DisplayMemberPath = "post_salary";

        }

        private void search_but_Click(object sender, RoutedEventArgs e)
        {
            InterDIS();
            InterEN(false);
            done_but.IsEnabled = true;
        }

        private void filter_but_Click(object sender, RoutedEventArgs e)
        {
            InterDIS();
            InterEN(true);
            done_but.IsEnabled = true;
        }

        private void cancel_but_Click(object sender, RoutedEventArgs e)
        {
            table_grid.ItemsSource = posts.GetData(); 
            done_but.IsEnabled = false;
            InterDIS();
        }

        private void done_but_Click(object sender, RoutedEventArgs e)
        {
            done_but.IsEnabled = false;
            if (post_id_filter.Visibility == Visibility.Visible)
            {
                table_grid.ItemsSource = posts.PostsFilter(
                post_id_filter.SelectedItem as DataRowView != null ? (int)(post_id_filter.SelectedItem as DataRowView)[0] : -1,
                post_name_filter.SelectedItem as DataRowView != null ? (post_name_filter.SelectedItem as DataRowView)[1].ToString() : " ",
                post_id_filter.SelectedItem as DataRowView != null ? (float)(post_id_filter.SelectedItem as DataRowView)[2] : -1
                );
            }
            else
            {
                table_grid.ItemsSource = posts.PostsSearch(
                    post_id.Text
                    );
            }
            InterDIS();
        }

        void InterEN(bool filter)
        {
            nt.Visibility = Visibility.Visible;
            st.Visibility = Visibility.Visible;
            it.Visibility = Visibility.Visible;
            if (filter)
            {
                post_id_filter.Visibility = Visibility.Visible;
                post_name_filter.Visibility = Visibility.Visible;  
                post_salary_filter.Visibility = Visibility.Visible;
            }
            else
            {
                post_id.Visibility = Visibility.Visible;
            }      
        }

        void InterDIS()
        {
            post_id.Text = "";

            post_name_filter.SelectedIndex = -1;
            post_salary_filter.SelectedIndex = -1;
            post_id_filter.SelectedIndex = -1;

            post_id.Visibility = Visibility.Hidden;

            post_name_filter.Visibility = Visibility.Hidden;
            post_salary_filter.Visibility = Visibility.Hidden;
            post_id_filter.Visibility = Visibility.Hidden;

            it.Visibility = Visibility.Hidden;
            nt.Visibility = Visibility.Hidden;
            st.Visibility = Visibility.Hidden;
        }


    }
}
