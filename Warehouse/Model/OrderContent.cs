namespace Warehouse.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderContent")]
    public partial class OrderContent
    {
        [Key]
        public int ContentID { get; set; }

        public int? ProductListID { get; set; }

        public int? ProductAmount { get; set; }

        [Column("OrderID")]
        public int? OrderListID { get; set; }

        [Column("OrderID")]
        public virtual OrderList OrderListsID { get; set; }

        public virtual ProductList ProductList { get; set; }
    }
}
