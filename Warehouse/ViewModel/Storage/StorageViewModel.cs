using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warehouse.Model;
using Warehouse.ViewModel;
using Warehouse.View.Storage.Dictionary;

namespace Warehouse.ViewModel.Storage
{
    public class StorageViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;

        IEnumerable<Product> products;
        //IEnumerable<Category> categories;

        public IEnumerable<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }

        //public IEnumerable<Category> Categories
        //{
        //    get { return categories; }
        //    set
        //    {
        //        categories = value;
        //        OnPropertyChanged("Categories");
        //    }
        //}



        public StorageViewModel()
        {
            db = new ApplicationContext();

            Products = db.Products.Local.ToBindingList();
            db.Categories.ToList();
            db.Products.ToList();
            //Categories = db.Categories.Local.ToBindingList();
        }



        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        AddProductToDictionaryWindow productWindow = new AddProductToDictionaryWindow(new Product());
                        if (productWindow.ShowDialog() == true)
                        {
                            //Category category = productWindow.Category;
                            Product product = productWindow.Product;
                            product.CategoryId = db.Categories.First(c => c.Name == productWindow.CategoryCmbBx.SelectedValue.ToString()).CategoryID;

                            db.Products.Add(product);

                            //int Amnt =productWindow.

                            ProductList list = new ProductList()
                            {
                                ProductID = product.ProductID,
                                Amount = 0,
                            };
                            db.ProductLists.Add(list);

                            db.SaveChanges();
                        }
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
                        Product product = selectedItem as Product;

                        Product product1 = new Product()
                        {
                            ProductID = product.ProductID,
                            Title = product.Title,
                            Description = product.Description,
                            UnitOfMeasurement = product.UnitOfMeasurement,
                            PriceForUnit = product.PriceForUnit,
                            CategoryId = product.CategoryId,
                            //Categories = db.Categories.First(c => c.CategoryID == product.CategoryId)
                        };
                        AddProductToDictionaryWindow phoneWindow = new AddProductToDictionaryWindow(product1);

                        if (phoneWindow.ShowDialog() == true)
                        {
                            product = db.Products.First(p => p.ProductID == phoneWindow.Product.ProductID);
                            if (product != null)
                            {
                                product.Title = phoneWindow.Product.Title;
                                product.Description = phoneWindow.Product.Description;
                                product.UnitOfMeasurement = phoneWindow.Product.UnitOfMeasurement;
                                product.PriceForUnit = phoneWindow.Product.PriceForUnit;

                                product.CategoryId = db.Categories.First(c => c.Name == phoneWindow.CategoryCmbBx.SelectedValue.ToString()).CategoryID;

                                db.Entry(product).State = EntityState.Modified;
                                
                            }
                        }
                        db.SaveChanges();
                    }));
            }
        }


        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Product product = selectedItem as Product;
                      MessageBoxResult Result = MessageBox.Show("u sure?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                      if (Result == MessageBoxResult.Yes)
                      {
                          db.Products.Remove(product);
                          db.SaveChanges();
                      }
                      if (Result == MessageBoxResult.No)
                      {

                      }

                 
                  }));
            }
        }

        private string searchResults;

        public string SearchResults
        {
            get { return searchResults; }
            set { searchResults = value; OnPropertyChanged(nameof(SearchResults)); }
        }

        public RelayCommand SearchCommand => new RelayCommand((i) =>
        {
            if (string.IsNullOrEmpty(SearchResults))
            {
                Products = db.Products.ToList();
            }
            else
            {
                var found = SearchResults.ToString().Trim();
                Products = db.Products.Where(x => x.Title.Contains(found) || x.Categories.Name.Contains(found)).ToList();
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
