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
using Warehouse.ViewModel.Order;

namespace Warehouse.View.Order.MakeOrder
{
    using Model;
    /// <summary>
    /// Логика взаимодействия для MakeOrderWindow.xaml
    /// </summary>
    public partial class OrderInfoWindow : Window
    {
        public List<ProductList> CheckedItemsList = new List<ProductList>();


        public OrderList OrderList { get;private set; }
        Warehouse.ApplicationContext context = new Warehouse.ApplicationContext();
        public List<ProductList> ProductLists { get; set; }
        public List<ProductList> ProductList1 = new List<ProductList>();
        bool restoreIfMove = false;


        public OrderInfoWindow(OrderList orderList, int? oldAmount)
        {
            InitializeComponent();
            //CheckedItemsList = null;
            OrderList = orderList;
            //this.DataContext = orderList;
            ComboBxItemsLoad();



            ProductList1 = context.ProductLists.ToList();
            ProductLists = context.ProductLists.ToList();
            ProductListGrid.ItemsSource = ProductList1.Where(x => x.Amount > 0);

            //foreach (ProductList productList in ProductList1)
            //{
            //    productList.Amount = 0;
            //}
        }

        private void MakeOrderBtn_Click(object sender, RoutedEventArgs e) { this.DialogResult = true; }

        private void ComboBxItemsLoad()
        {
            foreach (Client client in context.Clients)
            {
                ClientCmbBx.Items.Add(client.Name);
            }
        }


        private void TurnBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // Метод реализующий перетаскивание окна
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                restoreIfMove = true;
            }

            DragMove();
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(7);
                this.ResizeMode = ResizeMode.CanResize;
            }
            else
            {
                this.BorderThickness = new System.Windows.Thickness(0);
                this.ResizeMode = ResizeMode.CanResize;
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            restoreIfMove = false;
        }

        private void SelectedItem_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            var item = cb.DataContext;
            ProductListGrid.SelectedItem = item;
            if ((bool)!cb.IsChecked)
            {
                CheckedItemsList.Remove((ProductList)item);
            }
            else if (CheckedItemsList.Contains(item)) { return; }
            else if (item != null)
            {
                CheckedItemsList.Add((ProductList)item);
            }
        }

        private void EditAmount_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
