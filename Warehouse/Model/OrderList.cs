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
        public OrderList()
        {
            OrderContent = new HashSet<OrderContent>();
        }


        [Key]
        [Column ("OrderListID")]
        public int OrderListID { get; set; }

        //public decimal? totalPrice { get; set; }

        //[Column("ManagerID")]
        public int managerID;

        public int clientID;

        //[Column("OrderContentID")]
        //public int? OrderContentID { get; set; }

        public DateTime orderDate;

        [Column("ClientID")]
        public int ClientId
        {
            get { return clientID; }
            set
            {
                clientID = value;
                OnPropertyChanged("ClientID");
            }
        }

        //[Column(TypeName = "money")]
        //[Column("TotalPrice")]
        //public decimal? TotalPrice
        //{
        //    get { return totalPrice; }
        //    set
        //    {
        //        totalPrice = value;
        //        OnPropertyChanged("TotalPrice");
        //    }
        //}

        [Column("ManagerID")]
        public int ManagerId
        {
            get { return managerID; }
            set
            {
                managerID = value;
                OnPropertyChanged("ManagerID");
            }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set
            {
                orderDate = value;
                OnPropertyChanged("OrderDate");
            }
        }

        [Column("ClientID")]
        public virtual Client Client { get; set; }

        //[Column("OrderContentID")]
        //public virtual OrderContent OrderContent { get; set; }

        [Column("ManagerID")]
        public virtual UserLoginPass UserLoginPasses { get; set; }

        public virtual ICollection<OrderContent> OrderContent { get; set; }


        private List<UserLoginPass> userLogins;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
