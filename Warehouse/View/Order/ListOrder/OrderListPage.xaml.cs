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
using Warehouse.ViewModel.Order;

namespace Warehouse.View.Order.ListOrder
{
    /// <summary>
    /// Логика взаимодействия для OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {
        public OrderListPage()
        {
            InitializeComponent();
            this.DataContext = new OrderViewModel();
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e) { if (SearchBtn.IsChecked == false) { SearchBox.Text = null; } }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (SearchBtn.IsChecked == true)
                {
                    SearchBtn.IsChecked = false;
                    SearchBox.Text = null;
                    return;
                }
                else if (SearchBtn.IsChecked == false)
                {
                    SearchBtn.IsChecked = true;
                    SearchBox.Focus();
                    return;

                }
            }
        }
    }
}
