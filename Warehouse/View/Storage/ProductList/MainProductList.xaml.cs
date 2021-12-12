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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Warehouse.View.Storage.ProductList
{
    using Model;
    using Warehouse.View.Storage;
    using Warehouse.ViewModel.Storage;
    /// <summary>
    /// Логика взаимодействия для MainProductList.xaml
    /// </summary>
    public partial class MainProductList : Page
    {
        public MainProductList()
        {
            InitializeComponent();
            this.DataContext = new StorageListViewModel();

        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (SearchBtn.IsChecked == true)
                {
                    SearchBtn.IsChecked = false;
                    SearchBox.Text = null;
                    return;
                }
                else if (SearchBtn.IsChecked == false)
                {
                    SearchBtn.IsChecked = true;
                    SearchBox.Focus();
                    return;

                }
            }
        }
        private void GoToStorageDictionary_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Storage.Dictionary.MainDictionaryList());
        }
    }
}
