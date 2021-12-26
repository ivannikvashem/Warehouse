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

namespace Warehouse
{
    using Model;
    using Authorization;
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public List<UserLoginPass>  userLoginPasses { get; set; }
        bool restoreIfMove = false;
        public LoginWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            //Connection.model = new Model.Model1();
            //userLoginPasses = Connection.model.UserLoginPass.ToList();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //bool? ValidationCode = false;

            //string Login = LoginTxtBx.Text;
            //string Password = PasswordBx.Password;

            //if (userLoginPasses.F(Login.))
            //{
            //    if (userLoginPasses.UserPassword.Contains(Password))
            //    {
           // LoginStatus.LoggedIn;
                    MainWindow taskWindow = new MainWindow();
                    taskWindow.Show();
                    this.Close();
            //    }
            //}

            //if (ValidationCode == true)
            //{
            //    LoginConnection.Status =  UserType.Admin;

            //}

            //MainWindow taskWindow = new MainWindow();
            //taskWindow.Show();
            //this.Close();
        }




        // Метод реализующий сворачивание окна
        private void TurnBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else if (Result == MessageBoxResult.No)
            {

            }
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
    }
}
