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
    using System.Collections.ObjectModel;
    using System.Windows.Controls.Primitives;

    public class StorageListViewModel : INotifyPropertyChanged
    {
        Warehouse.ApplicationContext db;
        //RelayCommand addCommand;
        RelayCommand editCommand;
        //RelayCommand deleteCommand;
        //RelayCommand searchCommand;
        private string searchResults;

        IEnumerable<ProductList> productLists;

        public IEnumerable<ProductList> ProductLists
        {
            get { return productLists; }
            set
            {
                productLists = value;
                OnPropertyChanged("ProductLists");
            }
        }

        public string SearchResults
        {
            get { return searchResults; }
            set { searchResults = value; OnPropertyChanged("SearchResults"); }
        }

        public StorageListViewModel()
        {
            db = new Warehouse.ApplicationContext();
            ProductLists = db.ProductLists.Local.ToBindingList();
            db.ProductLists.ToList();
        }

        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand((selectedItem) =>
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


        public RelayCommand SearchCommand => new RelayCommand((i) =>
        {
            if (string.IsNullOrEmpty(SearchResults))
            {
                ProductLists = db.ProductLists.ToList();
            }
            else
            {
                var found = SearchResults.ToString().Trim();
                ProductLists = db.ProductLists.Where(x => x.Product.Title.Contains(found) || x.Product.Categories.Name.Contains(found)).ToList();
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
