namespace Warehouse.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Warehouse.Authorization;

    [Table("UserLoginPass")]
    public partial class UserLoginPass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserLoginPass()
        {
            OrderList = new HashSet<OrderList>();
        }

        [Key]
        [Column("UserID")]
        public int ManagerId { get; set; }


        private string userName;
        private string userLogin;
        private string userPassword;
        private int userRole;

        private ICommand _clickCommand;

        [StringLength(50)]
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        [StringLength(50)]
        public string UserLogin
        {
            get { return userLogin; }
            set
            {
                userLogin = value;
                OnPropertyChanged("UserLogin");
            }
        }

        [StringLength(50)]
        public string UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged("UserPassword");
            }
        }

        [Column("UserRole")]
        public int UserRoleId
        {
            get { return userRole; }
            set
            {
                userRole = value;
                OnPropertyChanged("UserRole");
            }
        }
        //public int UserRole { get; set; }


       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderList> OrderList { get; set; }

        [Column("UserRole")]
        public virtual UserRoleDictionary UserRoleDictionary { get; set; }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
