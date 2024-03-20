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
    /// Логика взаимодействия для Employeer_page.xaml
    /// </summary>
    public partial class Employeer_page : Page
    {
        Empl4TableAdapter employeers = new Empl4TableAdapter();
        PostsTableAdapter posts = new PostsTableAdapter();
        public Employeer_page()
        {
            InitializeComponent();
            Reload();

            empl_id_filter.ItemsSource = employeers.GetData();
            empl_name_filter.ItemsSource = employeers.GetData();
            empl_surname_filter.ItemsSource = employeers.GetData();
            empl_midlename_filter.ItemsSource = employeers.GetData();
            empl_post_filter.ItemsSource = posts.GetData();

            empl_id_filter.DisplayMemberPath = "employeer_id";
            empl_name_filter.DisplayMemberPath = "employeer_name";
            empl_surname_filter.DisplayMemberPath = "employeer_surname";
            empl_midlename_filter.DisplayMemberPath = "employeer_middlename";
            empl_post_filter.DisplayMemberPath = "post_name";

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
            table_grid.ItemsSource = employeers.GetData();
            done_but.IsEnabled = false;
            InterDIS();
        }

        private void done_but_Click(object sender, RoutedEventArgs e)
        {
            done_but.IsEnabled = false;
            if (empl_id_filter.Visibility == Visibility.Visible)
            {
                table_grid.ItemsSource = employeers.EmplFilter(
                empl_id_filter.SelectedItem as DataRowView != null ? (int)(empl_id_filter.SelectedItem as DataRowView)[0] : -1,
                empl_name_filter.SelectedItem as DataRowView != null ? (empl_name_filter.SelectedItem as DataRowView)[1].ToString() : " ",
                empl_surname_filter.SelectedItem as DataRowView != null ? (empl_surname_filter.SelectedItem as DataRowView)[2].ToString() : " ",
                empl_midlename_filter.SelectedItem as DataRowView != null ? (empl_midlename_filter.SelectedItem as DataRowView)[3].ToString() : " ",
                empl_post_filter.SelectedItem as DataRowView != null ? (empl_post_filter.SelectedItem as DataRowView)[1].ToString() : " "
                );
            }
            else
            {
                table_grid.ItemsSource = employeers.EmplSearch(
                    empl_id.Text 
                    );
            }

            InterDIS();
        }

        void Reload()
        {
            table_grid.ItemsSource = employeers.GetData();
        }

        void InterEN(bool filter)
        {
            it.Visibility = Visibility.Visible;
            nt.Visibility = Visibility.Visible;
            st.Visibility = Visibility.Visible;
            mt.Visibility = Visibility.Visible;
            pt.Visibility = Visibility.Visible;
            if (filter)
            {
                empl_id_filter.Visibility = Visibility.Visible;
                empl_name_filter.Visibility = Visibility.Visible;
                empl_surname_filter.Visibility = Visibility.Visible;
                empl_midlename_filter.Visibility = Visibility.Visible;
                empl_post_filter.Visibility = Visibility.Visible;
            }
            else
            {
                empl_id.Visibility = Visibility.Visible;
            }
        }

        void InterDIS()
        {
            empl_id.Text = "";

            empl_id_filter.SelectedIndex = -1;
            empl_name_filter.SelectedIndex = -1;
            empl_surname_filter.SelectedIndex = -1;
            empl_midlename_filter.SelectedIndex = -1;
            empl_post_filter.SelectedIndex = -1;

            empl_id.Visibility = Visibility.Hidden;

            empl_id_filter.Visibility = Visibility.Hidden;
            empl_name_filter.Visibility = Visibility.Hidden;
            empl_surname_filter.Visibility = Visibility.Hidden;
            empl_midlename_filter.Visibility = Visibility.Hidden;
            empl_post_filter.Visibility = Visibility.Hidden;

            it.Visibility = Visibility.Hidden;
            nt.Visibility = Visibility.Hidden;
            st.Visibility = Visibility.Hidden;
            mt.Visibility = Visibility.Hidden;
            pt.Visibility = Visibility.Hidden;
        }


    }
}
