namespace Warehouse.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("OrderList")]
    public partial class OrderList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderList()
        {
            OrderContent = new HashSet<OrderContent>();
        }

        [Key]
        [Column("OrderListID")]
        public int OrderListID { get; set; }

        public int? ClientID { get; set; }

        private int? managerID;
        public int? ManagerID
        {
            get { return managerID; }
            set
            {
                managerID = value;
                OnPropertyChanged("ManagerID");
            }
        }

        private DateTime? orderDate;
        [Column(TypeName = "date")]
        public DateTime? OrderDate
        {
            get { return orderDate; }
            set
            {
                orderDate = value;
                OnPropertyChanged("OrderDate");
            }
        }

        //[Column("ClientID")]
        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderContent> OrderContent { get; set; }

        [Column("ManangerID")]
        public virtual UserLoginPass UserLoginPass { get; set; }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
