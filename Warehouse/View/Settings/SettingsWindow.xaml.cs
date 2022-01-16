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
using Warehouse.View.Settings.Category;
using Warehouse.View.Settings.Manager;
using Warehouse.View.Storage.Dictionary;

namespace Warehouse.View.Settings
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        bool restoreIfMove = false;

        public SettingsWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new CategoryList());
        }


        private void GoToCategory_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CategoryList());
        }

        private void GoToManager_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManagerList());
        }

        private void GoToDictionary_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainDictionaryList());
        }

        private void TurnWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void GoToPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack == true)
            {
                MainFrame.GoBack();
            }
        }

        private void GoToNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoForward == true)
            {
                MainFrame.GoForward();
            }
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
