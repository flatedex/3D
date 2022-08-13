using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;

namespace _3D
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        int extrudersCount = 0;
        public UserWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            products_DataGrid.ItemsSource = DataBase.GetItemList();
            using (MySqlConnection connection = DataBase.Connect())
            {
                connection.Open();
                List<string> manufacturer = new List<string>();
                MySqlCommand command = new MySqlCommand();
                string query = $"SELECT title FROM `manufacturer`;";
                command.CommandText = query;
                command.Connection = connection;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            manufacturer.Add(reader["title"].ToString());
                        }
                    }
                }
                manufact_ComboBox.ItemsSource = manufacturer;
            }
            using (MySqlConnection connection = DataBase.Connect())
            {
                connection.Open();
                List<string> category = new List<string>();
                MySqlCommand command = new MySqlCommand();
                string query = $"SELECT title FROM `category`;";
                command.CommandText = query;
                command.Connection = connection;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            category.Add(reader["title"].ToString());
                        }
                    }
                }
                category_ComboBox.ItemsSource = category;
            }
            using (MySqlConnection connection = DataBase.Connect())
            {
                connection.Open();
                List<string> material = new List<string>();
                MySqlCommand command = new MySqlCommand();
                string query = $"SELECT type FROM `material`;";
                command.CommandText = query;
                command.Connection = connection;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            material.Add(reader["type"].ToString());
                        }
                    }
                }
                material_ComboBox.ItemsSource = material;
            }
        }

        private void search_Button_Click(object sender, RoutedEventArgs e)
        {
            products_DataGrid.ItemsSource = DataBase.SearchByString(search_TextBox.Text.ToString());
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            string fromWidth = widthFrom_TextBox.Text.ToString();
            string toWidth = widthTo_TextBox.Text.ToString();
            string fromHeight = heightFrom_TextBox.Text.ToString();
            string toHeight = heightTo_TextBox.Text.ToString();
            string fromLength = lengthFrom_TextBox.Text.ToString();
            string toLength = lengthTo_TextBox.Text.ToString();
            string fromPrice = priceFrom_TextBox.Text.ToString();
            string toPrice = priceTo_TextBox.Text.ToString();
            string fromProductivity = prodFrom_TextBox.Text.ToString();
            string toProductivity = prodTo_TextBox.Text.ToString();
            string pa_fromWidth = paWidthFrom_TextBox.Text.ToString();
            string pa_toWidth = paWidthTo_TextBox.Text.ToString();
            string pa_fromLength = paLengthFrom_TextBox.Text.ToString();
            string pa_toLength = paLengthTo_TextBox.Text.ToString();
            string pa_fromHeight = paHeightFrom_TextBox.Text.ToString();
            string pa_toHeight = paHeightTo_TextBox.Text.ToString();

            string manufacturer;
            if (manufact_ComboBox.SelectedItem == null)
            {
                manufacturer = "";
            }
            else
            {
                manufacturer = manufact_ComboBox.SelectedItem.ToString();
            }

            string category;
            if (category_ComboBox.SelectedItem == null)
            {
                category = "";
            }
            else
            {
                category = category_ComboBox.SelectedItem.ToString();
            }

            string material;
            if (material_ComboBox.SelectedItem == null)
            {
                material = "";
            }
            else
            {
                material = material_ComboBox.SelectedItem.ToString();
            }

            products_DataGrid.ItemsSource = DataBase.SearchByFilters(manufacturer, category, material,
                fromWidth, toWidth, fromLength, toLength, fromHeight, toHeight, fromPrice, toPrice,
                fromProductivity, toProductivity, pa_fromWidth, pa_toWidth, pa_fromLength, pa_toLength,
                pa_fromHeight, pa_toHeight, extrudersCount);
        }

        private void extr1_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            extrudersCount = 1;
        }

        private void extr2_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            extrudersCount = 2;
        }


    }
}
