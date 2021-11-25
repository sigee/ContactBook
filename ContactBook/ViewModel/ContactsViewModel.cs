using System.Windows.Input;
using ContactBook.Utility;

namespace ContactBook.ViewModel
{
    public class ContactsViewModel : ObservableObject
    {
        public ICommand DeleteCommand { get; private set; }

        public ContactsViewModel()
        {
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
