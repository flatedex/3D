using System;
using System.Windows;

namespace _3D
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        string messageBoxText = "Ошибка данных";
        public AddUser()
        {
            InitializeComponent();
        }
        private void addUser_Button_Click(object sender, RoutedEventArgs e)
        {
            string password = userPassword_TextBox.Text;
            string login = userLogin_TextBox.Text;
            string role = role_TextBox.Text;
            int roleNum;
            if ((string.IsNullOrEmpty(login)) || (string.IsNullOrEmpty(password)) || (string.IsNullOrEmpty(role)))
            {
                MessageBox.Show(messageBoxText, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    roleNum = Convert.ToInt32(role);
                }
                catch (Exception)
                {
                    MessageBox.Show(messageBoxText, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DataBase.AddUser(login, password, Convert.ToInt32(roleNum));
            }
        }
    }
}
