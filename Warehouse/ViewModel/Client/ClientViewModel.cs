using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Warehouse.View.Client;

namespace Warehouse.ViewModel.Client
{
    using Model;
    public class ClientViewModel : INotifyPropertyChanged
    {
        Warehouse.ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand1;
        RelayCommand deleteCommand1;

        IEnumerable<Client> clients;

        public IEnumerable<Client> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }

        public ClientViewModel()
        {
            db = new Warehouse.ApplicationContext();

            Clients = db.Clients.Local.ToBindingList();
            db.Clients.ToList();

        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        AddUpdateClientWindow updateClient = new AddUpdateClientWindow(new Client());
                        if (updateClient.ShowDialog() == true)
                        {
                            try
                            {
                                //Category category = productWindow.Category;
                                Client client = updateClient.Client;
                                db.Clients.Add(client);
                                db.SaveChanges();
                            }
                            catch
                            {

                            }
                        }
                    }));
            }
        }

        public RelayCommand EditCommand1
        {
            get
            {
                return editCommand1 ??
                    (editCommand1 = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Client client = selectedItem as Client;

                        Client client1 = new Client()
                        {
                            ClientID = client.ClientID,
                            Name = client.Name,
                            Phone = client.Phone,
                            Address = client.Address,
                        };
                        AddUpdateClientWindow updateClient = new AddUpdateClientWindow(client1);

                        if (updateClient.ShowDialog() == true)
                        {
                            client = db.Clients.Find(updateClient.Client.ClientID);
                            if (client != null)
                            {
                                client.Name = updateClient.Client.Name;
                                client.Phone = updateClient.Client.Phone;
                                client.Address = updateClient.Client.Address;


                                db.Entry(client).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }));
            }
        }

        public RelayCommand DeleteCommand1
        {
            get
            {
                return deleteCommand1 ??
                  (deleteCommand1 = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Client client = selectedItem as Client;
                      MessageBoxResult Result = MessageBox.Show("u sure?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                      if (Result == MessageBoxResult.Yes)
                      {
                          db.Clients.Remove(client);
                          db.SaveChanges();
                      }
                      if (Result == MessageBoxResult.No) { }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
