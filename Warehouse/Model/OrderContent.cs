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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderContent()
        {
            OrderList = new HashSet<OrderList>();
        }

        public int OrderContentID { get; set; }

        public int? ProductListID { get; set; }

        public int? ProductAmount { get; set; }

        public virtual ProductList ProductList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderList> OrderList { get; set; }
    }
}
