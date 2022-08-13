using System.Windows;

namespace _3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //UserWindow userWindow = new UserWindow();
            //AdminWindow adminWindow = new AdminWindow();
            //adminWindow.Show();
        }

        private void enter_Button_Click(object sender, RoutedEventArgs e)
        {
            string login = login_TextBox.Text;
            string password = password_PasswordBox.Password.ToString();
            string messageBoxText = "Ошибка данных";
            if ((string.IsNullOrEmpty(login)) || (string.IsNullOrEmpty(password)))
            {
                MessageBox.Show(messageBoxText, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (Authorisation(login, password)) Close();
            }
        }

        private bool Authorisation(string login, string password)
        {
            if (DataBase.AuthorisationDB(login, password)) return true;
            else return false;
        }
    }
}
