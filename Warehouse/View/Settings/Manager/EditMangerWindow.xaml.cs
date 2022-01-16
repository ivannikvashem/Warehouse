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
using Warehouse.Model;

namespace Warehouse.View.Settings.Manager
{
    using Model;
    public partial class EditMangerWindow : Window
    {
        ApplicationContext context = new ApplicationContext();
        bool restoreIfMove = false;
        public UserLoginPass UserLoginPass { get; internal set; }
        public UserRoleDictionary UserRoleDictionary  { get; internal set; }
        public EditMangerWindow(Model.UserLoginPass userLoginPass)
        {
            InitializeComponent();
            ComboBxItemsLoad();
            UserLoginPass = userLoginPass;
            DataContext = UserLoginPass;
            if (userLoginPass.UserName != null)
            {
                RoleCmbBx.SelectedValue = context.UserRoleDictionaries.First(c => c.UserRoleID == userLoginPass.UserRoleId).RoleName;
            }
        }

        private void ComboBxItemsLoad()
        {
            foreach (UserRoleDictionary role in context.UserRoleDictionaries)
            {
                RoleCmbBx.Items.Add(role.RoleName);
            }
        }

        private void SaveBtnClick_Click(object sender, RoutedEventArgs e)
        {
            if (UsrNameTxtBx.Text.Length == 0) {MessageBox.Show("Введите имя пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return;}
            else if (LoginTxtBx.Text.Length == 0) { MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            else if (PasswordTxtBx.Password.Length == 0) { MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            else if (RoleCmbBx.SelectedIndex == -1 ) { MessageBox.Show("Выберите роль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            else { this.DialogResult = true; }
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
