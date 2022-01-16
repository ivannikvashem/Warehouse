using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.ViewModel.Manager
{
    using Model;
    using System.Data.Entity;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using Warehouse.View.Settings.Manager;

    public class ManagerViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;


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

        public ManagerViewModel()
        {
            db = new ApplicationContext();
            UserLoginPasses = db.UserLoginPasses.Local.ToBindingList();
            db.UserLoginPasses.ToList();

        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        EditMangerWindow addManger = new EditMangerWindow(new UserLoginPass());
                        addManger.Owner = Application.Current.MainWindow;
                        if (addManger.ShowDialog() == true)
                        {
                            UserLoginPass userLoginPass = addManger.UserLoginPass;
                            userLoginPass.UserRoleId = db.UserRoleDictionaries.First(x => x.RoleName == addManger.RoleCmbBx.SelectedValue.ToString()).UserRoleID;

                            foreach (var item in db.UserLoginPasses.ToList())
                            {
                                if (item.UserLogin == userLoginPass.UserLogin)
                                {
                                    MessageBox.Show("Пользователь с таким логином уже существует","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                            }

                            db.UserLoginPasses.Add(userLoginPass);
                        }
                        db.SaveChanges();
                    }));
            }
        }

        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        UserLoginPass userpass = selectedItem as UserLoginPass;

                        UserLoginPass userpass1 = new UserLoginPass()
                        {
                            ManagerId = userpass.ManagerId,
                            UserName = userpass.UserName,
                            UserLogin = userpass.UserLogin,
                            UserPassword = userpass.UserPassword,
                            UserRoleId = userpass.UserRoleId,
                        };
                        EditMangerWindow updateManager = new EditMangerWindow(userpass1);
                        updateManager.Owner = Application.Current.MainWindow;

                        if (updateManager.ShowDialog() == true)
                        {
                            userpass = db.UserLoginPasses.First(x => x.ManagerId == updateManager.UserLoginPass.ManagerId);
                            if (userpass != null)
                            {
                                userpass.UserName = updateManager.UserLoginPass.UserName;
                                userpass.UserLogin = updateManager.UserLoginPass.UserLogin;
                                userpass.UserPassword = updateManager.UserLoginPass.UserPassword;
                                userpass.UserRoleId = db.UserRoleDictionaries.First(c => c.RoleName == updateManager.RoleCmbBx.SelectedValue.ToString()).UserRoleID;

                                //userpass.UserRoleId = updateManager.UserRoleDictionary.RoleName;

                                db.Entry(userpass).State = EntityState.Modified;
                            }
                        }
                        db.SaveChanges();
                    }));
            }
        }


        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
