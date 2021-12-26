using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Warehouse.View.Storage.Dictionary
{
    using Model;
    using Storage;
    /// <summary>
    /// Логика взаимодействия для AddProductToDictionaryWindow.xaml
    /// </summary>
    public partial class AddProductToDictionaryWindow : Window
    {
        List<Category> categories { get; set; }
        public Category category { get; set; }
        public Product Product { get; private set; }
        public Category Category { get; internal set; }

        bool restoreIfMove = false;

        Warehouse.ApplicationContext context = new Warehouse.ApplicationContext();

        public AddProductToDictionaryWindow(Product product)
        {
            InitializeComponent();
            Product = product;
            this.DataContext = Product;
            ComboBxItemsLoad();
            if (product.Title != null)
            {
                CategoryCmbBx.SelectedValue = context.Categories.First(c => c.CategoryID == product.CategoryId).Name;
            }

        }
        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }


        private void ComboBxItemsLoad()
        {
            foreach (Category category in context.Categories)
            {
                CategoryCmbBx.Items.Add(category.Name);
            }
        }

        private void TurnBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // Метод реализующий перетаскивание окна
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                restoreIfMove = true;
            }

            DragMove();
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(7);
                this.ResizeMode = ResizeMode.CanResize;
            }
            else
            {
                this.BorderThickness = new System.Windows.Thickness(0);
                this.ResizeMode = ResizeMode.CanResize;
            }
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            restoreIfMove = false;
        }
    }
}
