namespace Warehouse.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("OrderContent")]
    public partial class OrderContent
    {
        [Key]
        public int ContentID { get; set; }

        private int? productListID;
        public int? ProductListID
        {
            get { return productListID; }
            set
            {
                productListID = value;
                OnPropertyChanged("ProductListID");
            }
        }

        private int? productAmount;
        public int? ProductAmount
        {
            get { return productAmount; }
            set
            {
                productAmount = value;
                OnPropertyChanged("ProductAmount");
            }
        }

        private int? orderListID;
        [Column("OrderID")]
        public int? OrderListID
        {
            get { return orderListID; }
            set
            {
                orderListID = value;
                OnPropertyChanged("OrderListID");
            }
        }

        [Column(TypeName = "money")]
        private decimal? totalAmount;
        public decimal? TotalAmount
        {
            get { return totalAmount; }
            set
            {
                totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }


        [Column("OrderID")]
        public virtual OrderList OrderListsID { get; set; }

        public virtual ProductList ProductList { get; set; }


        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
