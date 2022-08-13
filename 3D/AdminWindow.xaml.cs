using System.Windows;

namespace _3D
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            products_DtaGrid.ItemsSource = DataBase.GetItemList();
        }
        private void edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (products_DtaGrid.SelectedItem == null) return;

            Printer printer = products_DtaGrid.SelectedItem as Printer;

            EditPrinters editPrinters = new EditPrinters(printer);
            editPrinters.Show();

            products_DtaGrid.ItemsSource = DataBase.GetItemList();
        }

        private void delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (products_DtaGrid.SelectedItem == null) return;

            Printer printer = products_DtaGrid.SelectedItem as Printer;

            DataBase.DeletePrinter(printer.P_id);

            products_DtaGrid.ItemsSource = DataBase.GetItemList();
        }

        private void add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddPrinters addPrinters = new AddPrinters();
            addPrinters.Show();
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            products_DtaGrid.ItemsSource = DataBase.GetItemList();
        }

        private void update_Button_Click(object sender, RoutedEventArgs e)
        {
            products_DtaGrid.ItemsSource = DataBase.GetItemList();
        }
    }
}
