using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Warehouse.ViewModel.Login;
using Warehouse.Model;
using System.Runtime.CompilerServices;

namespace Warehouse.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _viewModel;

        ApplicationContext db = new ApplicationContext();

        IEnumerable<UserLoginPass> userLoginPasses;

        public IEnumerable<UserLoginPass> UserLoginPasses
        {
            get { return userLoginPasses; }
            set
            {
                userLoginPasses = value;
                OnPropertyChanged("UserLoginPasses");
            }
        }

        public LoginCommand(LoginViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            if (CanExecute(true)) { }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Username) && !string.IsNullOrEmpty(_viewModel.Password);
        }


        //public async Task Login()
        //{
        //    var user = db.UserLoginPasses.FirstOrDefault(x => x.UserLogin == _viewModel.Username && x.UserPassword == _viewModel.Password);
        //    if (user != null)
        //    {
        //        ApplicationContext.Status = (ApplicationContext.UserStatus)user.UserRoleId;
        //        //MessageBox.Show($"{ApplicationContext.Status}");
        //        MainWindow main = new MainWindow();
        //        main.Show();

        //    }
        //    if (user == null)
        //    {
        //        MessageBox.Show($"Неправильный логин или пароль", "Вход",
        //        MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}


        public void Execute(object parameter)
        {
            try
            {
                var currentUser =  db.UserLoginPasses.FirstOrDefault(x => x.UserLogin == _viewModel.Username && x.UserPassword == _viewModel.Password);
                if (currentUser != null)
                {
                    ApplicationContext.Status = (ApplicationContext.UserStatus)currentUser.UserRoleId;
                    MainWindow main = new MainWindow();
                    main.Show();
                    Application.Current.MainWindow.Close();
                }
                if (currentUser == null) { MessageBox.Show($"Неправильный логин или пароль", "Вход", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch { MessageBox.Show($"База данных не отвечает попробуйте позже", "Вход", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
