using System.Collections.ObjectModel;
using System.Windows.Input;
using ContactBook.Model;
using ContactBook.Utility;

namespace ContactBook.ViewModel
{
    public class ContactsViewModel : ObservableObject
    {
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public ObservableCollection<Contact> Contacts { get; private set; }

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                OnPropertyChanged(ref _selectedContact, value);
                IsEditMode = false;
            }
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                OnPropertyChanged(ref _isEditMode, value);
                OnPropertyChanged("IsDisplayMode");
            }
        }
        public bool IsDisplayMode
        {
            get { return !_isEditMode; }
        }


        public ContactsViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            Contacts.Add(new Contact(){Name="Teszt Elek"});
            Contacts.Add(new Contact(){Name="Teszt Elek 2"});
            Contacts.Add(new Contact(){Name="Teszt Elek 3"});
            DeleteCommand = new RelayCommand(Delete, CanDelete);
            EditCommand = new RelayCommand(Edit, CanEdit);
        }

        private bool CanDelete()
        {
            return SelectedContact != null;
        }

        private void Delete()
        {
            Contacts.Remove(SelectedContact);
        }

        private bool CanEdit()
        {
            if (SelectedContact == null)
                return false;

            return !IsEditMode;
        }

        private void Edit()
        {
            IsEditMode = true;
        }
    }
}
