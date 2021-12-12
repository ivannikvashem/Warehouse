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

namespace Warehouse.View.Order.MakeOrder
{
    using Model;
    /// <summary>
    /// Логика взаимодействия для MakeOrderWindow.xaml
    /// </summary>
    public partial class MakeOrderWindow : Window
    {
        public OrderList OrderList { get;private set; }

        public MakeOrderWindow(Model.OrderList orderList)
        {
            InitializeComponent();
            OrderList = orderList;
            this.DataContext = orderList;
        }
    }
}
