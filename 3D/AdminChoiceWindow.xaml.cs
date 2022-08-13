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

namespace _3D
{
    /// <summary>
    /// Логика взаимодействия для AdminChoiceWindow.xaml
    /// </summary>
    public partial class AdminChoiceWindow : Window
    {
        public AdminChoiceWindow()
        {
            InitializeComponent();
        }

        private void addUsers_Button_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
            Close();
        }

        private void workAdminPrinter_Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}
