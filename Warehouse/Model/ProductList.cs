namespace Warehouse.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductList")]
    public partial class ProductList : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductList()
        {
            OrderContent = new HashSet<OrderContent>();
        }

        public int ProductListID { get; set; }

        public int? productID;
        [Column("ProductID")]
        public int? ProductID
        {
            get { return productID; }
            set
            {
                productID = value;
                OnPropertyChanged("ProductID");
            }
        }

        public int? amount;
        public int? Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public int? currentAmount = 0;
        public int? CurrentAmount
        {
            get { return currentAmount; }
            set { currentAmount = value; OnPropertyChanged("CurrentAmount"); }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderContent> OrderContent { get; set; }

        public virtual Product Product { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
