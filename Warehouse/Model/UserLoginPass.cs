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
        public int UserID { get; set; }


        private string userName;
        private string userLogin;
        private string userPassword;
        private string userRole;

        private ICommand _clickCommand;

        [StringLength(50)]
        private string UserName
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
                userRole = value;
                OnPropertyChanged("UserPassword");
            }
        }

        public int? UserRole { get; set; }

        //public ICommand ClickCommand
        //{
        //    get
        //    {
        //        if (_clickCommand == null)
        //        {
        //            _clickCommand = new RelayCommand(new Action<object>(ValidateClient));
        //        }
        //        return _clickCommand;
        //    }
        //    set
        //    {
        //        _clickCommand = value;
        //        OnPropertyChanged("ClickCommand");

        //    }
        //}

       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderList> OrderList { get; set; }

        public virtual UserRoleDictionary UserRoleDictionary { get; set; }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
