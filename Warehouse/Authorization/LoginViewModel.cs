using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Warehouse.Authorization
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private ICommand _clickCommand;


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
