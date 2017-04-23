using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace MyMediaLibrary2
{
    public sealed partial class BookViewPage : Page
    {
        private ObservableCollection<Book> books;
        private StorageFile bookfile;
        public BookViewPage()
        {
            this.InitializeComponent();
            ReadFile();
            // Used example from FriendsApp to try to make this work. Didn't help.
            BookList.ItemsSource = books;
        }
        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<Book>)
            {
                books = (ObservableCollection<Book>)e.Parameter;
            }
        }*/
        private async void ReadFile()
        {
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                Stream stream = await storageFolder.OpenStreamForReadAsync("Bookses.txt");
                DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<Book>));
                books = (ObservableCollection<Book>)serializer.ReadObject(stream);
            }
            catch (Exception ex)
            {
                books = new ObservableCollection<Book>();
                Debug.WriteLine("Following exception has happend (writing): " + ex.ToString());
            }
        }

        // Next two are basically straigth from FriendsApp. Idea was to first make them work and then modify in my own way
        // But it didn't work. No idea why.
       /* private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookList.SelectedIndex != -1)
            {
                UpdateBook(BookList.SelectedIndex);
            }
        }*/
        /*private void UpdateBook(int index)
        {
            Book book = books.ElementAt(index);
            BookNameTextBlock.Text = book.BookName;
            AuthorTextBlock.Text = book.Author;
            PagesTextBlock.Text = Convert.ToString(book.Pages);
            RatingTextBlock.Text = Convert.ToString(book.Rating);
            InfoTextBlock.Text = book.Info;
        }*/
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // get root frame (which show pages)
            Frame rootFrame = Window.Current.Content as Frame;
            // did we get it correctly
            if (rootFrame == null) return;
            // navigate back if possible
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }
    }
}
