using System.Collections.ObjectModel;
using System.Windows.Input;
using ContactBook.Model;
using ContactBook.Utility;

namespace ContactBook.ViewModel
{
    public class ContactsViewModel : ObservableObject
    {
        public ICommand DeleteCommand { get; private set; }

        public ObservableCollection<Contact> Contacts { get; private set; }

        public ContactsViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            Contacts.Add(new Contact(){Name="Teszt Elek"});
            Contacts.Add(new Contact(){Name="Teszt Elek 2"});
            Contacts.Add(new Contact(){Name="Teszt Elek 3"});
            DeleteCommand = new RelayCommand(Delete, CanDelete);
        }

        private bool CanDelete()
        {
            return false;
        }

        private void Delete()
        {
        }
    }
}
