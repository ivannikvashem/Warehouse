﻿using System;
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

namespace Warehouse.View.Storage.ProductList
{
    using Model;
    /// <summary>
    /// Логика взаимодействия для AddProductFromDictionary.xaml
    /// </summary>
    public partial class AddProductFromDictionary : Window
    {
        bool restoreIfMove = false;
        ApplicationContext db = new ApplicationContext();
        public List<ProductList> ProductLists { get; set; }
        public List<Product> Products = new List<Product>();

        public List<Product> Products1 = new List<Product>();



        public AddProductFromDictionary(Model.ProductList productList)
        {
            InitializeComponent();
            //ProductLists = productList;
            Products = db.Products.ToList();
            ProductLists = db.ProductLists.ToList();

            ProductListGrid.ItemsSource = Products;

            //ProductListGrid.ItemsSource = Products.Join(ProductLists, x => x.ProductID, t => t.ProductID, (Products, ProductLists) => new
            //{
            //    Products = Products.ProductID,
            //    Products1 = Products.ProductID,
            //    ProductLists = ProductLists.Select(p=> p.ProductList)
            //});

        }

        private void TurnWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        // Метод реализующий перетаскивание окна
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
        // Метод реализующий сворачивание окна
        private void TurnBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void ResizeWindow_Click(object sender, RoutedEventArgs e)
        {
            SwitchState();
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
    }
}
