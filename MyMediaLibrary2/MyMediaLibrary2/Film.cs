using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace MyMediaLibrary2
{
    class Film : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string filmname;
        private string actor;
        private int length;
        private int rating;
        private string info;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string FilmName
        {
            get { return filmname; }
            set
            {
                filmname = value;
                RaisePropertyChanged();
            }
        }
        public string Actor
        {
            get { return actor; }
            set
            {
                actor = value;
                RaisePropertyChanged();
            }
        }
        public int Length
        {
            get { return length; }
            set
            {
                length = value;
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
