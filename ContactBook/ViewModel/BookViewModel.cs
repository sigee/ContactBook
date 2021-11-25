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

        public BookViewModel()
        {
            ContactsViewModel = new ContactsViewModel();
        }
    }
}
