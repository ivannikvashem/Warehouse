using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warehouse.View.Storage;

namespace Warehouse.ViewModel.Storage
{
    using Model;
    public class StorageListViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand1;
        RelayCommand deleteCommand;

        IEnumerable<ProductList>  productLists;

        public IEnumerable<ProductList> ProductLists
        {
            get { return productLists; }
            set
            {
                productLists = value;
                OnPropertyChanged("ProductLists");
            }
        }


        public StorageListViewModel()
        {
            db = new ApplicationContext();
            ProductLists = db.ProductLists.Local.ToBindingList();
            db.ProductLists.ToList();
        }

        public RelayCommand EditCommand1
        {
            get
            {
                return editCommand1 ??
                    (editCommand1 = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        ProductList productList = selectedItem as ProductList;

                        ProductList productList1 = new ProductList()
                        {
                            ProductListID = productList.ProductListID,
                            Amount = productList.Amount,
                        };
                        ChangeProductAmountWindow updateProductList = new ChangeProductAmountWindow(productList);

                        if (updateProductList.ShowDialog() == true)
                        {
                            productList = db.ProductLists.Find(updateProductList.ProductList.ProductListID);
                            if (productList != null)
                            {
                                productList.Amount = updateProductList.ProductList.Amount;


                                db.Entry(productList).State = EntityState.Modified;
                                db.SaveChanges();
                            }
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
