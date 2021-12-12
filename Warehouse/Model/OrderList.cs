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
        public int OrderListID { get; set; }

        public decimal? totalPrice { get; set; }

        //[Column("ManagerID")]
        public int ManagerID { get; set; }

        public int? ClientID { get; set; }

        public int? OrderContentID { get; set; }


        [Column(TypeName = "money")]
        public decimal? TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        //[Column("ManagerID")]
        //public int ManagerID
        //{
        //    get { return managerID; }
        //    set
        //    {
        //        managerID = value;
        //        OnPropertyChanged("ManagerID");
        //    }
        //}

        public virtual Client Client { get; set; }

        public virtual OrderContent OrderContent { get; set; }

        //[Column("ManagerID")]
        public virtual UserLoginPass UserLoginPass { get; set; }

        private List<UserLoginPass> userLogins;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
