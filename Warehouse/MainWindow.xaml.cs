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
using Warehouse.View.Storage;
using Warehouse.View.Client;
using Warehouse.View.Order.ListOrder;
using Warehouse.View.Storage.ProductList;
using Warehouse.View.Storage.Dictionary;
using Warehouse.View.Settings;


namespace Warehouse
{
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        bool restoreIfMove = false;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainProductList());
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            DataContext = ApplicationContext.Status;
            //var CurrentUserName = db.UserLoginPasses.Where(x => x.ManagerId == (int)ApplicationContext.Status);
            //UserNameTxtBlck.Text = ApplicationContext.Status.ToString();
            //if (ApplicationContext.Status.ToString() == "Администратор") { GoToStorageDictionary.Visibility = Visibility.Visible; }
            //else { GoToStorageDictionary.Visibility = Visibility.Collapsed; }

        }

        private void GoToStorageBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainProductList());
        }

        private void GoToClientBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientListPage());
        }

        private void GoToOrderBtn_Click(object sender, RoutedEventArgs e)
        {
             MainFrame.Navigate(new OrderListPage());
        }

        private void GoToStorageDictionary_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainDictionaryList());
        }

        private void GoToSettings_Click(object sender, RoutedEventArgs e)
        {

            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Owner = this;
            settingsWindow.ShowDialog();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Вы действительно хотите завершить сеанс пользователя?", "Блокировка", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                LoginWindow login = new LoginWindow();
                Application.Current.MainWindow = login;
                Application.Current.MainWindow.Show();
                this.Close();
            }
            else if (Result == MessageBoxResult.No) { }
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

        private void Menu_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tgl_Btn.IsChecked == true)
            {
                tt_Storage.Visibility = Visibility.Collapsed;
                tt_Clients.Visibility = Visibility.Collapsed;
                tt_Orders.Visibility = Visibility.Collapsed;
                //tt_Upcoming.Visibility = Visibility.Collapsed;
                tt_Settings.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_Storage.Visibility = Visibility.Visible;
                tt_Clients.Visibility = Visibility.Visible;
                tt_Orders.Visibility = Visibility.Visible;
                //tt_Upcoming.Visibility = Visibility.Visible;
                tt_Settings.Visibility= Visibility.Visible;
            }
        }
        private void MainFrame_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //SearchBtn.IsChecked = false;
            Tgl_Btn.IsChecked = false;
        }
        private void TopBorder_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //SearchBtn.IsChecked = false;
            Tgl_Btn.IsChecked = false;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
                //Application.Current.Shutdown();
            }
            else if (Result == MessageBoxResult.No)
            {

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

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (Tgl_Btn.IsChecked == true)
                {
                    Tgl_Btn.IsChecked = false;
                    return;
                }
                else if (Tgl_Btn.IsChecked == false)
                {
                    Tgl_Btn.IsChecked = true;
                    return;
                }
            }

            if (e.Key == Key.Left && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (MainFrame.CanGoBack == true)
                {
                    MainFrame.GoBack();
                }
            }
            if (e.Key == Key.Right && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (MainFrame.CanGoForward == true)
                {
                    MainFrame.GoForward();
                }
            }

            

            if (e.Key == Key.F1 && Keyboard.Modifiers == ModifierKeys.Control)
            {
                Window window = new LoginWindow();
                window.Show();
                this.Close();
                return;
            }

            if (e.Key == Key.System && e.SystemKey == Key.F4)
            {
                e.Handled = true;
            }
        }

        private void Tgl_Btn_Checked(object sender, RoutedEventArgs e)
        {
            Logo.Opacity = 0.3;
        }
        private void Tgl_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            Logo.Opacity = 1;
        }
    }
}
