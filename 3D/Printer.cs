using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _3D
{
    public class Printer : INotifyPropertyChanged
    {
        private int p_id;
        private int m_id;
        private int c_id;
        private String printerTitle = "";
        private int printerWidth;
        private int printerLength;
        private int printerHeight;
        private int printerPrice;
        private int printerProductivity;
        private int pa_width;
        private int pa_length;
        private int pa_height;
        private int extruders_quantity;

        public Printer(int p_id, String printerTitle, int printerWidth, int printerLength, int printerHeight, int printerPrice, int printerProductivity, int pa_width, int pa_length, int pa_height, int extruders_quantity, int m_id, int c_id)
        {
            this.p_id = p_id;
            this.printerTitle = printerTitle;
            this.printerWidth = printerWidth;
            this.printerLength = printerLength;
            this.printerHeight = printerHeight;
            this.printerPrice = printerPrice;
            this.printerProductivity = printerProductivity;
            this.pa_width = pa_width;
            this.pa_length = pa_length;
            this.pa_height = pa_height;
            this.extruders_quantity = extruders_quantity;
            this.m_id = m_id;
            this.c_id = c_id;
        }
        public int P_id
        {
            get { return p_id; }
            set { p_id = value; }
        }
        public int M_id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public int C_id
        {
            get { return c_id; }
            set { c_id = value; }
        }
        public String PrinterTitle
        {
            get { return printerTitle; }
            set { printerTitle = value; OnPropertyChanged("Title"); }
        }
        public int PrinterWidth
        {
            get { return printerWidth; }
            set { printerWidth = value; OnPropertyChanged("Width"); }
        }
        public int PrinterLength
        {
            get { return printerLength; }
            set { printerLength = value; OnPropertyChanged("Length"); }
        }
        public int PrinterHeight
        {
            get { return printerHeight; }
            set { printerHeight = value; OnPropertyChanged("Height"); }
        }
        public int PrinterPrice
        {
            get { return printerPrice; }
            set { printerPrice = value; OnPropertyChanged("Price"); }
        }
        public int PrinterProductivity
        {
            get { return printerProductivity; }
            set { printerProductivity = value; OnPropertyChanged("Productivity"); }
        }
        public int Pa_width
        {
            get { return pa_width; }
            set { pa_width = value; OnPropertyChanged("PA Width"); }
        }
        public int Pa_height
        {
            get { return pa_height; }
            set { pa_height = value; OnPropertyChanged("PA Height"); }
        }
        public int Pa_length
        {
            get { return pa_length; }
            set { pa_length = value; OnPropertyChanged("PA Length"); }
        }
        public int Extruders_quantity
        {
            get { return extruders_quantity; }
            set { extruders_quantity = value; OnPropertyChanged("Extruders quantity"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
