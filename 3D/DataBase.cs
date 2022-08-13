using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows;

namespace _3D
{
    internal class DataBase
    {
        private static string host = "localhost";
        private static string port = "3306";
        private static string username = "root";
        private static string password = "8876";
        private static string database = "practice_db";


        public static MySqlConnection Connect()
        {
            string connectionParams = $"Server={host};Database={database};port={port};User Id={username};password={password}";
            return new MySqlConnection(connectionParams);
        }
        public static void AddPrinter(Printer printer)
        {
            using (MySqlConnection connection = DataBase.Connect())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                String query = $"INSERT INTO printer (title, width, length, height, price, productivity, pa_width, pa_length, pa_height, extruders_quantity, m_id, c_id)" +
                $" VALUES ({printer.PrinterTitle},{printer.PrinterWidth},{printer.PrinterLength},{printer.PrinterHeight}," +
                $"{printer.PrinterPrice},{printer.PrinterProductivity},{printer.Pa_width},{printer.Pa_length},{printer.Pa_height}," +
                $" {printer.M_id},{printer.C_id});";
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }
        public static void DeletePrinter(int id)
        {
            using (MySqlConnection connection = DataBase.Connect())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                string query = $"DELETE FROM printer WHERE p_id = '{id}';";
                command.CommandText = query;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
        public static void EditPrinter(int id, string title, int width, int length, int height, int price, int productivity, int pa_width, int pa_length, int pa_height, int extruders_quantity)
        {
            using (MySqlConnection connection = DataBase.Connect())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                string query = $"UPDATE printer SET title = '{title}', width = '{width}', length = '{length}', height = '{height}'," +
                    $" price = '{price}', productivity = '{productivity}', pa_width = '{pa_width}', pa_length = '{pa_length}', pa_height = '{pa_height}', " +
                    $"extruders_quantity = '{extruders_quantity}' WHERE p_id = '{id}';";
                command.CommandText = query;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
        public static void AddUser(string login, string password, int role)
        {
            if (role > 0 && role < 3)
            {
                using (MySqlConnection connection = DataBase.Connect())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand();
                    string query = $"INSERT INTO `user` (login, password, r_id) VALUES ({login}, {password}, {role});";
                    command.CommandText = query;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Ошибка в выборе роли", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static List<Printer> GetItemList()
        {
            List<Printer> printers = new List<Printer>();
            using (MySqlConnection connection = DataBase.Connect())
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                string query = "SELECT * FROM `printer`;";
                command.CommandText = query;
                command.Connection = connection;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Printer printer = new Printer(Convert.ToInt32(reader["p_id"].ToString()), reader["title"].ToString(), Convert.ToInt32(reader["width"].ToString()),
                                Convert.ToInt32(reader["length"].ToString()), Convert.ToInt32(reader["height"]), Convert.ToInt32(reader["price"]),
                                Convert.ToInt32(reader["productivity"]), Convert.ToInt32(reader["pa_width"]), Convert.ToInt32(reader["pa_length"]),
                                Convert.ToInt32(reader["pa_height"]), Convert.ToInt32(reader["extruders_quantity"]), Convert.ToInt32(reader["m_id"]),
                                Convert.ToInt32(reader["c_id"]));
                            printers.Add(printer);
                        }
                    }
                }
            }
            return printers;
        }
        public static List<Printer> SearchByString(String itemStr)
        {
            List<Printer> searched = new List<Printer>();
            using (MySqlConnection connection = DataBase.Connect())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                string query = $"SELECT * FROM printer where match(title) against('{itemStr}' in natural language mode);";
                command.CommandText = query;
                command.Connection = connection;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Printer printer = new Printer(Convert.ToInt32(reader["p_id"].ToString()), reader["title"].ToString(),
                                Convert.ToInt32(reader["width"].ToString()), Convert.ToInt32(reader["length"].ToString()),
                                Convert.ToInt32(reader["height"]), Convert.ToInt32(reader["price"]),
                                Convert.ToInt32(reader["productivity"]), Convert.ToInt32(reader["pa_width"]), Convert.ToInt32(reader["pa_length"]),
                                Convert.ToInt32(reader["pa_height"]), Convert.ToInt32(reader["extruders_quantity"]), Convert.ToInt32(reader["m_id"]),
                                Convert.ToInt32(reader["c_id"]));
                            searched.Add(printer);
                        }
                    }
                }
            }

            return searched;
        }
        public static List<Printer> SearchByFilters(string manufacturer, string category, string material, string widthLower, string widthHigher, string lengthLower, string lengthHigher,
            string heightLower, string heightHigher, string priceLower, string priceHigher, string productivityLower,
            string productivityHigher, string pa_widthLower, string pa_widthHigher, string pa_lengthLower, string pa_lengthHigher,
            string pa_heightLower, string pa_heightHigher,
            //int widthLower, int widthHigher, int lengthLower, int lengthHigher,
            //int heightLower, int heightHigher, int priceLower, int priceHigher, int productivityLower,
            //int productivityHigher, int pa_widthLower, int pa_widthHigher, int pa_lengthLower, int pa_lengthHigher,
            //int pa_heightLower, int pa_heightHigher,
            int extrudersCount)
        {
            //string queryManufacturer = $".title like \"{manufacturer}\"";
            //string queryCategory = $".title like \"{category}\"";
            //string queryMaterial = $".type like \"{material}\";";
            //string queryFromWidth = $" width > {widthLower}";
            //string queryToWidth = $" and width < {widthHigher}";
            //string queryFromLength = $" and length > {lengthLower}";
            //string queryToLength = $" and length < {lengthHigher}";
            //string queryFromHeight = $" and height > {heightLower}";
            //string queryToHeight = $" and height < {heightHigher}";
            //string queryFromPrice = $" and price > {priceLower}";
            //string queryToPrice = $" and price < {priceHigher}";
            //string queryFromProductivity = $" and productivity > {productivityLower}";
            //string queryToProductivity = $" and productivity < {productivityHigher}";
            //string queryFromPa_Width = $" and pa_width > {pa_widthLower}";
            //string queryToPa_Width = $" and pa_width < {pa_widthHigher}";
            //string queryFromPa_Length = $" and pa_length > {pa_lengthLower}";
            //string queryToPa_Length = $" and pa_length < {pa_lengthHigher}";
            //string queryFromPa_Height = $" and pa_height > {pa_heightLower}";
            //string queryToPa_Height = $" and pa_height < {pa_heightHigher}";


            //string queryOneExtrudor = $" and extruders_quantity like \"{oneExtruder}\"";
            //string queryTwoExtrudors = $" and extruders_quantity like \"{twoExtruders}\";";
            //my


            List<string> list = new List<string>();
            string myQueryFromWidth = "";
            if (widthLower != "")
            {
                myQueryFromWidth = " width > " + widthLower;
                list.Add(myQueryFromWidth);

            }
            string myQueryToWidth = "";
            if (widthHigher != "")
            {
                myQueryToWidth = " width < " + widthHigher;
                list.Add(myQueryToWidth);
            }
            string myQueryFromLength = "";
            if (lengthLower != "")
            {
                myQueryFromLength = " length > " + lengthLower;
                list.Add(myQueryFromLength);
            }
            string myQueryToLength = "";
            if (lengthHigher != "")
            {
                myQueryToLength = " length < " + lengthHigher;
                list.Add(myQueryToLength);
            }
            string myQueryFromHeight = "";
            if (heightLower != "")
            {
                myQueryFromHeight = " height > " + heightLower;
                list.Add(myQueryFromHeight);
            }
            string myQueryToHeight = "";
            if (heightHigher != "")
            {
                myQueryToHeight = " height < " + heightHigher;
                list.Add(myQueryToHeight);
            }
            string myQueryFromPrice = "";
            if (priceLower != "")
            {
                myQueryFromPrice = " price > " + priceLower;
                list.Add(myQueryFromPrice);
            }
            string myQueryToPrice = "";
            if (priceHigher != "")
            {
                myQueryToPrice = " price < " + priceHigher;
                list.Add(myQueryToPrice);
            }
            string myQueryFromProductivity = "";
            if (productivityLower != "")
            {
                myQueryFromProductivity = " productivity > " + productivityLower;
                list.Add(myQueryFromProductivity);
            }
            string myQueryToProductivity = "";
            if (productivityHigher != "")
            {
                myQueryToProductivity = " productivity < " + productivityHigher;
                list.Add(myQueryToProductivity);
            }
            string myQueryFromPa_Width = "";
            if (pa_widthLower != "")
            {
                myQueryFromPa_Width = " pa_width > " + pa_widthLower;
                list.Add(myQueryFromPa_Width);
            }
            string myQueryToPa_Width = "";
            if (pa_widthHigher != "")
            {
                myQueryToPa_Width = " pa_width < " + pa_widthHigher;
                list.Add(myQueryToPa_Width);
            }
            string myQueryFromPa_Length = "";
            if (pa_heightLower != "")
            {
                myQueryFromPa_Length = " pa_length > " + pa_lengthLower;
                list.Add(myQueryFromPa_Length);
            }
            string myQueryToPa_Length = "";
            if (pa_lengthHigher != "")
            {
                myQueryToPa_Length = " pa_length < " + pa_lengthHigher;
                list.Add(myQueryToPa_Length);
            }
            string myQueryFromPa_Height = "";
            if (pa_heightLower != "")
            {
                myQueryFromPa_Height = " pa_height > " + pa_heightLower;
                list.Add(myQueryFromPa_Height);
            }
            string myQueryToPa_Height = "";
            if (pa_heightHigher != "")
            {
                myQueryToPa_Height = " pa_height < " + pa_heightHigher;
                list.Add(myQueryToPa_Height);
            }
            string myQueryManufacturer = "";
            if (manufacturer != "")
            {
                myQueryManufacturer = $" `manufacturer`.title = \"{manufacturer}\"";
                list.Add(myQueryManufacturer);
            }
            string myQueryCategory = "";
            if (category != "")
            {
                myQueryCategory = $" `category`.title = \"{category}\"";
                list.Add(myQueryCategory);
            }
            string myQueryMaterial = "";
            if (material != "")
            {
                myQueryMaterial = $" `material`.type = \"{material}\"";
                list.Add(myQueryMaterial);
            }
            string queryOneExtrudor = "";
            if (extrudersCount != 0)
            {
                queryOneExtrudor = $"  extruders_quantity like \"{extrudersCount}\"";
                list.Add(queryOneExtrudor);
            }
            string partOfQuery = "";
            if (list.Count != 0)
            {
                partOfQuery += "WHERE";
            }
            foreach (string item in list)
            {
                if (item == list[0])
                {
                    partOfQuery += item;
                }
                else
                {
                    partOfQuery += " AND " + item;
                }
            }
            //my
            List<Printer> filteredPrinters = new List<Printer>();

            using (MySqlConnection connection = DataBase.Connect())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                string finalQuery = $"SELECT printer.p_id as p_id, printer.title, width," +
                    $" length, height, price, productivity, pa_width, pa_length, pa_height," +
                    $" extruders_quantity, printer.m_id, printer.c_id FROM `printer` INNER JOIN" +
                    $" `creator` ON `printer`.p_id = `creator`.p_id INNER JOIN `manufacturer` ON" +
                    $" `creator`.mf_id = `manufacturer`.mf_id INNER JOIN `material` ON `printer`.m_id = `material`.m_id" +
                    $" INNER JOIN `category` ON `printer`.c_id = `category`.c_id " + partOfQuery + "; ";

                command.CommandText = finalQuery;
                command.Connection = connection;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Printer printer = new Printer(Convert.ToInt32(reader["p_id"].ToString()), reader["title"].ToString(),
                                Convert.ToInt32(reader["width"].ToString()), Convert.ToInt32(reader["length"].ToString()),
                                Convert.ToInt32(reader["height"]), Convert.ToInt32(reader["price"]),
                                Convert.ToInt32(reader["productivity"]), Convert.ToInt32(reader["pa_width"]), Convert.ToInt32(reader["pa_length"]),
                                Convert.ToInt32(reader["pa_height"]), Convert.ToInt32(reader["extruders_quantity"]), Convert.ToInt32(reader["m_id"]),
                                Convert.ToInt32(reader["c_id"]));
                            filteredPrinters.Add(printer);
                        }
                    }
                }
            }

            return filteredPrinters;
        }
        public static bool AuthorisationDB(string login, string password)
        {
            int? role_id = null;

            using (MySqlConnection connectionOnLogin = DataBase.Connect())
            {
                connectionOnLogin.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connectionOnLogin;
                string query = $"SELECT EXISTS(SELECT login FROM practice_db.user WHERE login like \"{login}\");";
                command.CommandText = query;
                using (MySqlDataReader readerOnLogin = command.ExecuteReader())
                {
                    if (readerOnLogin.HasRows)
                    {
                        // PASS ON LOGIN
                        using (MySqlConnection connectionOnPassword = DataBase.Connect())
                        {
                            connectionOnPassword.Open();
                            command.Connection = connectionOnPassword;
                            query = $"SELECT password FROM practice_db.user WHERE login like \"{login}\";";
                            command.CommandText = query;

                            using (MySqlDataReader readerOnPassword = command.ExecuteReader())
                            {
                                readerOnPassword.Read();
                                if (readerOnPassword["password"].ToString().Equals(password))
                                {
                                    using (MySqlConnection connectionOnRole = DataBase.Connect())
                                    {
                                        connectionOnRole.Open();
                                        // PASS ON PASSWORD
                                        command.Connection = connectionOnRole;
                                        query = $"SELECT r_id FROM practice_db.user WHERE login like \"{login}\";";
                                        command.CommandText = query;
                                        using (MySqlDataReader readerOnRole = command.ExecuteReader())
                                        {
                                            if (readerOnRole.HasRows)
                                            {
                                                while (readerOnRole.Read())
                                                    role_id = Convert.ToInt32(readerOnRole["r_id"].ToString());

                                                if (role_id != null)
                                                {
                                                    if (role_id == 1)
                                                    {
                                                        AdminChoiceWindow acw = new AdminChoiceWindow();
                                                        acw.Show();
                                                        return true;
                                                    }
                                                    else if (role_id == 2)
                                                    {
                                                        UserWindow uw = new UserWindow();
                                                        uw.Show();
                                                        return true;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Darabase error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Darabase error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Darabase error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                                return false;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // GTFO ON PASSWORD
                                    MessageBox.Show("Invalid login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        // GTFO ON LOGIN
                        MessageBox.Show("Invalid login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
        }
    }
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string source) : base("DefaultConnection") { }
        public DbSet<Printer> Printers { get; set; }
    }
}
