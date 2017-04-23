using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyMediaLibrary2
{
    class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string bookname;
        private string author;
        private int pages;
        private int rating;
        private string info;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string BookName
        {
            get { return bookname; }
            set
            {
                bookname = value;
                RaisePropertyChanged();
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                RaisePropertyChanged();
            }
        }
        public int Pages
        {
            get { return pages; }
            set
            {
                pages = value;
                RaisePropertyChanged();
            }
        }
        public int Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                RaisePropertyChanged();
            }
        }
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                RaisePropertyChanged();
            }
        }
    }
}
