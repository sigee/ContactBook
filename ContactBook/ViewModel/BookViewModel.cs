using System.Windows.Input;
using ContactBook.Utility;

namespace ContactBook.ViewModel
{
    public class BookViewModel : ObservableObject
    {
        private ContactsViewModel _contactsViewModel;
        public ContactsViewModel ContactsViewModel
        {
            get { return _contactsViewModel; }
            set { OnPropertyChanged(ref _contactsViewModel, value); }
        }

        public ICommand LoadFavoritesCommand { get; private set; }
        public ICommand LoadContactsCommand { get; private set; }

        public BookViewModel()
        {
            ContactsViewModel = new ContactsViewModel();
            LoadFavoritesCommand = new RelayCommand(LoadFavorites);
            LoadContactsCommand = new RelayCommand(LoadContacts);
        }

        private void LoadFavorites()
        {
            ContactsViewModel.LoadFavorites();
        }
        private void LoadContacts()
        {
            ContactsViewModel.LoadContacts();
        }
    }
}
