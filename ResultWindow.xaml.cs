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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        static Window mwref = Application.Current.MainWindow;
        List<Good> goods = ((MainWindow)mwref).Goods.OrderByDescending(it => it.PriceForKilo).ToList();
        public ResultWindow()
        {
            InitializeComponent();
            double sum = 0;
            Good cur = goods.First();
            while (goods.Count>0&& sum + goods.First().Weight <= 1000) {
                cur = goods.First();
                sum += cur.Weight;
                Result.Text += "Название - "+cur.Name + ", цена - " + cur.Cost + ", вес - " + cur.Weight+"\n";
                cur.Amount--;
                if (cur.Amount<=0) { goods.RemoveAt(0); }
                if (1000-sum < cur.Weight) {
                    goods.RemoveAt(0);
                }
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            goods = ((MainWindow)mwref).Goods.OrderByDescending(it => it.PriceForKilo).ToList();
        }
    }
}
