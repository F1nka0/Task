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
        Good TopGood = ((MainWindow)mwref).Goods.OrderByDescending(it => it.PriceForKilo).ToList().First();
        public ResultWindow()
        {
            InitializeComponent();
            double sum = 0;
            if (TopGood==null) { return; }
            while (TopGood.Amount>0&& sum + TopGood.Weight<= 1000 ) {
                sum += TopGood.Weight;
                Result.Text += "Название - "+ TopGood.Name + ", цена - " + TopGood.Cost + ", вес - " + TopGood.Weight+"\n";
                TopGood.Amount--;
                if (1000-sum < TopGood.Weight) {
                    return;
                }
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            TopGood = ((MainWindow)mwref).Goods.OrderByDescending(it => it.PriceForKilo).ToList().First();
        }
    }
}
