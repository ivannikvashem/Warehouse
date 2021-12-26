using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Warehouse.View.Order.MakeOrder;

namespace Warehouse.ViewModel.Order
{
    using Microsoft.VisualBasic;
    using Model;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Runtime.CompilerServices;
    using System.Windows.Documents;

    public class OrderViewModel : INotifyPropertyChanged
    {
        Warehouse.ApplicationContext db;
        RelayCommand makeOrderCommand;

        IEnumerable<OrderList>  orderLists;
        IEnumerable<UserLoginPass> userLoginPasses;
        IEnumerable<Client> clients;


        //class IsChecked
        //{

        //}
        //ProductList IsChecked = new ProductList();

        //public List<IsChecked> isCheckeds = new List<IsChecked>();

        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (isChecked == value) return;
                {
                    isChecked = value;
                    OnPropertyChanged("IsChecked");
                }
            }
        }




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
            db = new Warehouse.ApplicationContext();
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
                            OrderList orderList = new OrderList()
                            {
                                ClientID = db.Clients.First(cl => cl.Name == makeOrderWindow.ClientCmbBx.SelectedValue.ToString()).ClientID,
                                ManagerID = 2,
                                OrderDate = DateTime.Today,
                            };


                            //OrderList orderList = makeOrderWindow.OrderList;
                            //orderList.TotalPrice = 0;

                            db.OrderLists.Add(orderList);

                            foreach (ProductList content in db.ProductLists)
                            {
                                //content.IsChecked.
                                if (content.IsChecked == true && content.Amount > 0)
                                {
                                    OrderContent content1 = new OrderContent()
                                    {
                                        ProductListID = content.ProductListID,
                                        OrderListID = orderList.OrderListID,
                                        ProductAmount = 2,
                                    };
                                    db.OrderContents.Add(content1);
                                }
                            }
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
