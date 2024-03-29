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

namespace Warehouse.View.Storage
{
    using Model;
    /// <summary>
    /// Логика взаимодействия для ChangeProductAmountWindow.xaml
    /// </summary>
    public partial class ChangeProductAmountWindow : Window
    {
        bool restoreIfMove = false;

        public Model.ProductList ProductList { get; private set; }
        public int? OldAmountValue { get; set; }

        public ChangeProductAmountWindow(Model.ProductList productList1, int? oldAmount)
        {
            InitializeComponent();
            ProductList = productList1;
            OldAmountValue = oldAmount;
            this.DataContext = ProductList;
            CheangeAmountUpDown.Minimum = (short?)OldAmountValue;
        }
        private void SaveBtnClick_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void TurnWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
