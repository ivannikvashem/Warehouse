using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.ViewModel.Category
{
    using Model;
    using System.Data.Entity;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using Warehouse.View.Settings.Category;

    public class CategoryViewModel : INotifyPropertyChanged
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;


        IEnumerable<Category> categories;

        public IEnumerable<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

        public CategoryViewModel()
        {
            db = new ApplicationContext();
            Categories = db.Categories.Local.ToBindingList();
            db.Categories.ToList();
            
        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        ChangeCategoryNameWindow updateCategory = new ChangeCategoryNameWindow(new Category());
                        updateCategory.Owner = Application.Current.MainWindow;
                        if (updateCategory.ShowDialog() == true)
                        {
                            try
                            {
                                Category category = updateCategory.Category;
                                db.Categories.Add(category);
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
                        Category category = selectedItem as Category;

                        Category category1 = new Category()
                        {
                            CategoryID = category.CategoryID,
                            Name = category.Name,
                        };
                        ChangeCategoryNameWindow updateCategory = new ChangeCategoryNameWindow(category1);
                        updateCategory.Owner = Application.Current.MainWindow;

                        if (updateCategory.ShowDialog() == true)
                        {
                            category = db.Categories.Find(updateCategory.Category.CategoryID);
                            if (category != null)
                            {
                                category.Name = updateCategory.Category.Name;

                                db.Entry(category).State = EntityState.Modified;
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
