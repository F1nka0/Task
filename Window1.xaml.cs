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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Window mwref = Application.Current.MainWindow;
        public Window1()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            double Cost=0;
            double Mass = 0;//вводить дробные значения в texbox-ы через запятую, а не точку
            int Quantity = 0;
            if (double.TryParse(Price.Text, out Cost) && double.TryParse(Weight.Text, out Mass) && int.TryParse(Amount.Text, out Quantity)&& ProdName.Text!="Название"&&Cost>0&&Mass>0&&Quantity>0)
            {
                if (((MainWindow)mwref).Goods.FirstOrDefault(it=>it.Name== ProdName.Text) is null) {
                    ((MainWindow)mwref).Goods.Add(new Good(ProdName.Text, Cost, Mass, Quantity));
                    ((MainWindow)mwref).ListHolder.Items.Add(ProdName.Text);
                    ErrorMessage.Content = ""; 
                }
            }
            else {
                ErrorMessage.Content = "Введите допустимые значения";
                return;
            }
        }
    }
}
