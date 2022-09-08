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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Good
    {
        public Good(string Name,double Cost, double Weight, int Amount)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Weight = Weight;
            this.Amount = Amount;
            this.PriceForKilo = Cost / Weight;
        }
        public string Name { get; set; }
        public double PriceForKilo { get; set; }
        public double Cost { get; set; }
        public double Weight { get; set; }
        public int Amount { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public List<Good> Goods = new List<Good>();
        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            Window1 AdderForm = new Window1();
            AdderForm.Owner = this;
            AdderForm.Show();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            ResultWindow rw = new ResultWindow();
            rw.Owner = this;
            rw.Show();
        }
    }
}
