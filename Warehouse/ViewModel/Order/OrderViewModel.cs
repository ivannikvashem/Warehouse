using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Warehouse.View.Order.MakeOrder;

namespace Warehouse.ViewModel.Order
{
    using System.Windows.Interactivity;
    using Microsoft.VisualBasic;
    using Model;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Runtime.CompilerServices;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Controls;
    using Warehouse.View.Order.ListOrder;
    using System.Windows.Controls.Primitives;
    using System.Windows;

    public class OrderViewModel : INotifyPropertyChanged
    {
        Warehouse.ApplicationContext db;
        RelayCommand makeOrderCommand;
        RelayCommand isItemChecked;
        RelayCommand isItemUnChecked;
        RelayCommand showOrderInfoCommand;

        IEnumerable<OrderList> orderLists;
        IEnumerable<UserLoginPass> userLoginPasses;
        IEnumerable<Client> clients;
        IEnumerable<ProductList> productLists;
        private string searchResults;

        public decimal? totalValueOfItems { get; set; } = 0;
        public int? OldAmount { get; set; }
        //public int? currentAmount1 { get; set; } = 0;

        public List<object> CheckedItemsList = new List<object>();

        public ObservableCollection<object> SelectedItems = new ObservableCollection<object> { };

        public string SearchResults
        {
            get { return searchResults; }
            set { searchResults = value; OnPropertyChanged(nameof(SearchResults)); }
        }



        public IEnumerable<ProductList> ProductLists
        {
            get     { return productLists; }
            set
            {
                productLists = value;
                OnPropertyChanged("OrderLists");
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
            db = new ApplicationContext();

            int User = (int)Application.Current.Properties["CurrentUser"];
            if ((int)ApplicationContext.Status == 1)
            {
                OrderLists = db.OrderLists.Local.ToBindingList();
            }
            else
            {
                OrderLists = db.OrderLists.Local.ToBindingList().Where(c => c.ManagerID == User);

                //OrderLists = db.OrderLists.Local.ToBindingList().Where(c => c.ManagerID == (int)ApplicationContext.Status);
            }
            ProductLists = db.ProductLists.Local.ToBindingList().Where(x => x.Amount > 0);
            db.UserLoginPasses.ToList();
            db.OrderLists.ToList();
            db.ProductLists.ToList();
        }

        private bool _IsChecked = false;
        public bool IsChecked
        {
            get => _IsChecked;
            set
            {
                _IsChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }

        }


        public RelayCommand IsItemChecked
        {
            get
            {
                return isItemChecked ??
                    (isItemChecked = new RelayCommand((selectedItem) =>
                    {
                        //LoginWindow makeOrderWindow = new LoginWindow();
                        //makeOrderWindow.Show();
                        if (selectedItem == null) return;
                        if (selectedItem != null)
                        {
                            ProductList product = (ProductList)selectedItem;
                            CheckedItemsList.Add(selectedItem);
                        }
                        IsChecked = true;
                    }));
            }
        }

        public RelayCommand IsItemUnChecked
        {
            get
            {
                return isItemUnChecked ??
                    (isItemUnChecked = new RelayCommand((selectedItem) =>
                    {
                        //LoginWindow makeOrderWindow = new LoginWindow();
                        //makeOrderWindow.Show();
                        if (selectedItem == null) return;
                        if (selectedItem != null)
                        {
                            ProductList product = (ProductList)selectedItem;
                            CheckedItemsList.Remove(selectedItem);
                        }
                        IsChecked = false;
                    }));
            }
        }



        public RelayCommand MakeOrderCommand
        {
            get
            {
                return makeOrderCommand ??
                    (makeOrderCommand = new RelayCommand((selectedItem) =>
                    {
                        View.Order.MakeOrder.OrderInfoWindow makeOrderWindow = new View.Order.MakeOrder.OrderInfoWindow(new OrderList(), OldAmount);
                        makeOrderWindow.Owner = Application.Current.MainWindow;
                        if (makeOrderWindow.ShowDialog() == true)
                        {
                            if (makeOrderWindow.ClientCmbBx.SelectedItem != null)
                            {
                                OrderList orderList = new OrderList()
                                {
                                    ClientID = db.Clients.First(cl => cl.Name == makeOrderWindow.ClientCmbBx.SelectedValue.ToString()).ClientID,
                                    ManagerID = (int)ApplicationContext.Status,
                                    OrderDate = DateTime.Now,
                                    TotalValue = totalValueOfItems,
                                };
                                db.OrderLists.Add(orderList);

                                if (makeOrderWindow.CheckedItemsList != null)
                                {
                                    foreach (var content in makeOrderWindow.CheckedItemsList)
                                    {
                                        OrderContent contentToAdd = new OrderContent()
                                        {
                                            ProductListID = content.ProductListID,
                                            OrderListID = orderList.OrderListID,
                                            ProductAmount = content.CurrentAmount,
                                            TotalAmount = content.CurrentAmount * content.Product.PriceForUnit,
                                            PriceForUnit = content.Product.PriceForUnit
                                            
                                        };
                                        ProductList prdctLstAmount = new ProductList(){};
                                        prdctLstAmount = db.ProductLists.Find(contentToAdd.ProductListID);
                                        if (prdctLstAmount != null)
                                        {
                                            prdctLstAmount.Amount -= content.CurrentAmount;
                                        }
                                        db.Entry(prdctLstAmount).State = EntityState.Modified;
                                        db.OrderContents.Add(contentToAdd);
                                        totalValueOfItems = orderList.TotalValue += contentToAdd.TotalAmount;
                                    }
                                }
                                else { return; }
                            }
                            else { return; }
                            
                        }
                        db.SaveChanges();
                        totalValueOfItems = 0;
                    }));
            }
        }

        public RelayCommand SearchCommand => new RelayCommand((i) =>
        {
            if (string.IsNullOrEmpty(SearchResults))
            {
                OrderLists = db.OrderLists.ToList();
            }
            else
            {
                //int found2 = Convert.ToInt32(SearchResults.Trim());
                var found = SearchResults.ToString().Trim();
                OrderLists = db.OrderLists.Where(x => x.Client.Name.Contains(found) || x.OrderListID.ToString().Contains(found) ||  x.OrderDate.Value.ToString().Contains(found) || x.UserLoginPass.UserName.Contains(found)).ToList();
            }
        });

        public RelayCommand OpenSearchBox => new RelayCommand((i) =>
        {
            if (i == null) return;

            ToggleButton toggleButton = i as ToggleButton;

            if (toggleButton.IsChecked == true)
            {
                toggleButton.IsChecked = false;
                //toggleButton = null;
                return;
            }
            else if (toggleButton.IsChecked == false)
            {
                toggleButton.IsChecked = true;
                toggleButton.Focus();
                return;
            }

        });

        public RelayCommand ShowOrderInfoCommand
        {
            get
            {
                return showOrderInfoCommand ??
                    (showOrderInfoCommand = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        OrderList orderlsts = selectedItem as OrderList;
                        
                        OrderList orderList = new OrderList()
                        {
                            OrderListID = orderlsts.OrderListID,
                            Client = orderlsts.Client,
                            UserLoginPass = orderlsts.UserLoginPass,
                            OrderDate = orderlsts.OrderDate,
                            OrderContent = orderlsts.OrderContent,
                            TotalValue = orderlsts.TotalValue,
                        };
                        OrderInfoWindow orderInfoWindow = new OrderInfoWindow(orderList);
                        orderInfoWindow.Owner = Application.Current.MainWindow;
                        if (orderInfoWindow.ShowDialog() == true)
                        {
                            orderInfoWindow.Close();
                        };

                        //if (orderInfoWindow.ShowDialog() == true)
                        //{
                        //    if (orderInfoWindow.ClientCmbBx.SelectedItem != null)
                        //    {
                        //        OrderList orderList = new OrderList()
                        //        {
                        //            ClientID = db.Clients.First(cl => cl.Name == orderInfoWindow.ClientCmbBx.SelectedValue.ToString()).ClientID,
                        //            ManagerID = (int)ApplicationContext.Status,
                        //            OrderDate = DateTime.Today,
                        //        };
                        //        db.OrderLists.Add(orderList);


                        //        if (orderInfoWindow.CheckedItemsList != null)
                        //        {
                        //            foreach (var content in orderInfoWindow.CheckedItemsList)
                        //            {
                        //                OrderContent contentToAdd = new OrderContent()
                        //                {
                        //                    ProductListID = content.ProductListID,
                        //                    OrderListID = orderList.OrderListID,
                        //                    ProductAmount = content.Amount,
                        //                };
                        //                db.OrderContents.Add(contentToAdd);
                        //            }
                        //        }
                        //        else { return; }
                        //    }
                        //    else { return; }
                        //}
                        //db.SaveChanges();

                    }));
            }
        }


        public static ObservableCollection<ProductList> GetProductList()
        {
            ApplicationContext context = new ApplicationContext();
            return new ObservableCollection<ProductList>(context.ProductLists.Select(p => p).ToList<ProductList>());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

//ProductList productList = selectedItem as ProductList;

//ProductList productList1 = new ProductList()
//{
//    ProductListID = productList.ProductListID,
//    Amount = productList.Amount,
//};
//ChangeProductAmountWindow updateProductList = new ChangeProductAmountWindow(productList);

//if (updateProductList.ShowDialog() == true)
//{
//    productList = db.ProductLists.Find(updateProductList.ProductList.ProductListID);
//    if (productList != null)
//    {
//        productList.Amount = updateProductList.ProductList.Amount;

//        db.Entry(productList).State = EntityState.Modified;
//        db.SaveChanges();
//    }
//}