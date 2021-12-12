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

namespace Warehouse.View.Storage
{
    using Model;
    /// <summary>
    /// Логика взаимодействия для ChangeProductAmountWindow.xaml
    /// </summary>
    public partial class ChangeProductAmountWindow : Window
    {
        public Warehouse.Model.ProductList ProductList { get; private set; }


        public ChangeProductAmountWindow(Warehouse.Model.ProductList productList)
        {
            InitializeComponent();
            ProductList = productList;
            this.DataContext = ProductList;
        }
        private void SaveBtnClick_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
