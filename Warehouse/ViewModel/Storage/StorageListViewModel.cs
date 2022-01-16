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
    using Warehouse.View.Storage.ProductList;

    public class StorageListViewModel : INotifyPropertyChanged
    {
        Warehouse.ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        //RelayCommand deleteCommand;
        //RelayCommand searchCommand;
        public List<Category> Category1 { get; set; } = new List<Category>();
        public int? OldAmount { get; set; }
        private string searchResults;
        private Category sortResults;

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

        //IEnumerable<Category> categories;

        //public IEnumerable<Category> Categories
        //{
        //    get { return categories; }
        //    set
        //    {
        //        categories = value;
        //        OnPropertyChanged("Categories");
        //    }
        //}
        public Category SortResults
        {
            get { return sortResults; }
            set { sortResults = value; OnPropertyChanged(nameof(SortResults)); }
        }

        public string SearchResults
        {
            get { return searchResults; }
            set { searchResults = value; OnPropertyChanged(nameof(SearchResults)); }
        }

        public StorageListViewModel()
        {
            db = new Warehouse.ApplicationContext();
            ProductLists = db.ProductLists.Local.ToBindingList();
            //Categories = db.Categories.Local.ToBindingList(); 
            db.ProductLists.ToList();
            db.Categories.ToList();
        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        AddProductFromDictionary addProductFromDict = new AddProductFromDictionary(new ProductList());
                        addProductFromDict.Owner = Application.Current.MainWindow;
                        if (addProductFromDict.ShowDialog() == true)
                        {
                            try
                            {
                                ////Category category = productWindow.Category;
                                //Client client = addProductFromDict.Client;
                                //db.Clients.Add(client);
                            }
                            catch
                            {

                            }
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
                        ProductList productList = selectedItem as ProductList;

                        ProductList productList1 = new ProductList()
                        {
                            ProductListID = productList.ProductListID,
                            Amount = productList.Amount,
                        };

                        OldAmount = productList1.Amount;
                        ChangeProductAmountWindow updateProductList = new ChangeProductAmountWindow(productList1, OldAmount);
                        updateProductList.Owner = Application.Current.MainWindow;

                        if (updateProductList.ShowDialog() == true)
                        {
                            productList = db.ProductLists.Find(updateProductList.ProductList.ProductListID);
                            if (productList != null)
                            {
                                //productList.Amount = updateProductList.ProductList.
                                productList.Amount = updateProductList.ProductList.Amount;                                
                            }
                        }
                        db.Entry(productList).State = EntityState.Modified;
                        db.SaveChanges();
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
                ProductLists = db.ProductLists.Where(x => x.Product.Title.Contains(found) || x.Product.Categories.Name.Contains(found) || x.Product.UnitOfMeasurement.Contains(found)).ToList();
            }
        });

        public RelayCommand SortCommand => new RelayCommand((i) =>
        {
            //var found = SortResults;
            ProductLists = db.ProductLists.Where(x => x.Product.Categories.Name == SortResults.Name);
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
