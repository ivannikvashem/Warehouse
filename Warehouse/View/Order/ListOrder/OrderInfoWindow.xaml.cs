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

namespace Warehouse.View.Order.ListOrder
{
    using Model;
    public partial class OrderInfoWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public OrderList OrderList1 { get; private set; }
        public UserLoginPass UserLoginPass;
        public List<OrderContent> content = new List<OrderContent>();
        bool restoreIfMove = false;

        public OrderInfoWindow(OrderList orderList)
        {
            InitializeComponent();
            OrderList1 = orderList;
            this.DataContext = OrderList1;
            content.ToList();

            foreach (var item in db.OrderContents)
            {
                if (item.OrderListID.Equals(orderList.OrderListID))
                {
                    content.Add(item);
                }
            }
            StorageGrid.ItemsSource = content;
            //ClientTxtBx.Text = orderList.Client.Name;
            //ClientTxtBx.Text = db.OrderLists.First(x => x.Client.ClientID == orderList.Client.ClientID).Client.Name;
            //StorageGrid.ItemsSource = OrderList1.ToString();
        }
        private void TurnWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void CloseWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if ((ResizeMode == ResizeMode.CanResize) ||
                    (ResizeMode == ResizeMode.CanResizeWithGrip))
                {
                    SwitchState();
                }
            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    restoreIfMove = true;
                }

                DragMove();
            };
        }
        private void SwitchState()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                    {
                        WindowState = WindowState.Maximized;
                        break;
                    }
                case WindowState.Maximized:
                    {
                        WindowState = WindowState.Normal;
                        break;
                    }
            }
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
        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                bool v = this.WindowState == WindowState.Minimized;
            }
        }

        private void PrintCheck_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            bool? PrntResult = printDialog.ShowDialog();
            {
                if (PrntResult == true)
                {
                    printDialog.PrintVisual(CheckInfo, "Чек");
                }
            }
        }
    }
}
