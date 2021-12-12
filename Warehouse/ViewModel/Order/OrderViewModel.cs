using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Warehouse.View.Order.MakeOrder;

namespace Warehouse.ViewModel.Order
{
    using Model;
    using System.Data.Entity;
    using System.Runtime.CompilerServices;

    public class OrderViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        RelayCommand makeOrderCommand;

        IEnumerable<OrderList>  orderLists;
        IEnumerable<UserLoginPass> userLoginPasses;
        IEnumerable<Client> clients;

        public IEnumerable<OrderList> OrderLists
        {
            get { return orderLists; }
            set
            {
                orderLists = value;
                OnPropertyChanged("OrderLists");
            }
        }

        public IEnumerable<UserLoginPass> UserLoginPasses
        {
            get { return userLoginPasses; }
            set
            {
                userLoginPasses = value;
                OnPropertyChanged("UserLoginPasses");
            }
        }

        public IEnumerable<Client> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }



        public OrderViewModel()
        {
            db = new ApplicationContext();
            OrderLists = db.OrderLists.Local.ToBindingList();
            db.UserLoginPasses.ToList();
            db.OrderLists.ToList();
            
        }


        public RelayCommand MakeOrderCommand
        {
            get
            {
                return makeOrderCommand ??
                    (makeOrderCommand = new RelayCommand((o) =>
                    {
                        MakeOrderWindow makeOrderWindow = new MakeOrderWindow(new OrderList());
                        if (makeOrderWindow.ShowDialog() == true)
                        {
                            OrderList orderList = makeOrderWindow.OrderList;
                            db.OrderLists.Add(orderList);
                            db.SaveChanges();
                        }
                    }));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
