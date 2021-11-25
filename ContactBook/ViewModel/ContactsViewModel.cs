using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ContactBook.Model;
using ContactBook.Utility;

namespace ContactBook.ViewModel
{
    public class ContactsViewModel : ObservableObject
    {
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand AddCommand { get; private set; }

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
            LoadContacts();
            DeleteCommand = new RelayCommand(Delete, CanDelete);
            EditCommand = new RelayCommand(Edit, CanEdit);
            AddCommand = new RelayCommand(Add);
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

        private void Add()
        {
            var newContact = new Contact
            {
                Name = "N/A",
                PhoneNumbers = new string[2],
                Emails = new string[2],
                Locations = new string[2]
            };

            Contacts.Add(newContact);
            SelectedContact = newContact;
        }

        public void LoadContacts()
        {
            Contacts.Clear();
            Contacts.Add(new Contact(){Name="Teszt Elek", PhoneNumbers = new[]{"06-20-123-45-67", "06-30-123-45-67"}, Emails = new string[2], Locations = new string[2], IsFavorite = true});
            Contacts.Add(new Contact(){Name="Teszt Elek 2", PhoneNumbers = new[]{"06-70-123-45-67", "06-20-123-45-67"}});
            Contacts.Add(new Contact(){Name="Teszt Elek 3"});
        }

        public void LoadFavorites()
        {
            LoadContacts();
            List<Contact> tmp = Contacts.ToList();
            Contacts.Clear();
            foreach (var c in tmp.Where(c => c.IsFavorite))
            {
                Contacts.Add(c);
            }
        }
    }
}
