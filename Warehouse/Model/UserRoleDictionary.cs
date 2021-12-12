namespace Warehouse.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRoleDictionary")]
    public partial class UserRoleDictionary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserRoleDictionary()
        {
            UserLoginPass = new HashSet<UserLoginPass>();
        }

        [Key]
        public int UserRoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLoginPass> UserLoginPass { get; set; }
    }
}
