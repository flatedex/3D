using System;
using System.Windows;

namespace _3D
{
    /// <summary>
    /// Interaction logic for AddPrinters.xaml
    /// </summary>
    public partial class AddPrinters : Window
    {
        public Printer printer { get; set; }
        public AddPrinters()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            printer.P_id = Convert.ToInt32(TitleBox.Text.ToString());
            printer.PrinterTitle = TitleBox.Text.ToString();
            printer.PrinterWidth = Convert.ToInt32(WidthBox.Text.ToString());
            printer.PrinterLength = Convert.ToInt32(LengthBox.Text.ToString());
            printer.PrinterHeight = Convert.ToInt32(HeightBox.Text.ToString());
            printer.PrinterPrice = Convert.ToInt32(PriceBox.Text.ToString());
            printer.PrinterProductivity = Convert.ToInt32(ProductivityBox.Text.ToString());
            printer.Pa_width = Convert.ToInt32(PAWidthBox.Text.ToString());
            printer.Pa_length = Convert.ToInt32(PALengthBox.Text.ToString());
            printer.Pa_height = Convert.ToInt32(PAHeightBox.Text.ToString());
            DataBase.AddPrinter(printer);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
