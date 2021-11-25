using ContactBook.Utility;

namespace ContactBook.ViewModel
{
    public class AppViewModel : ObservableObject
    {
        private BookViewModel _bookViewModel;
        public BookViewModel BookViewModel
        {
            get { return _bookViewModel; }
            set { OnPropertyChanged(ref _bookViewModel, value); }
        }

        public AppViewModel()
        {
            BookViewModel = new BookViewModel();
        }
    }
}
