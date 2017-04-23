using System;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
namespace MyMediaLibrary2
{
    public sealed partial class BookAddPage : Page
    {
        private Book book;
        private ObservableCollection<Book> books;
        public StorageFile bookfile;
        public BookAddPage()
        {
            this.InitializeComponent();
        }
       protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<Book>)
            {
                books = (ObservableCollection<Book>)e.Parameter;
            }
            base.OnNavigatedTo(e);
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Same thing as in FilmAddPage, stream doesn't work.
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile bookfile = await storageFolder.CreateFileAsync("Bookses.txt", CreationCollisionOption.OpenIfExists);
            book = new Book();
            book.BookName = BookName.Text;
            book.Author = Author.Text;
            book.Info = InfoBox.Text;

            // Change string from textblock to int
            int num;
            num = Convert.ToInt32(PageNum.Text);
            num = int.Parse(PageNum.Text);
            num = book.Pages;
            book.Pages = num;

            // Change string from combobox to int for saving
            /*Stream stream = await bookfile.OpenStreamForWriteAsync();
            DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<Book>));
            serializer.WriteObject(stream, books);
            await stream.FlushAsync();
            stream.Dispose();*/
            //await FileIO.AppendTextAsync(bookfile, Convert.ToString(book));

            int ratingNum;
            bool parseOK = Int32.TryParse(ComboBox.SelectedItemProperty.ToString(), out ratingNum);
            book.Rating = ratingNum;
            await FileIO.AppendTextAsync(bookfile, BookName.Text + Environment.NewLine);
            await FileIO.AppendTextAsync(bookfile, Author.Text + Environment.NewLine);
            await FileIO.AppendTextAsync(bookfile, PageNum.Text + Environment.NewLine);
            await FileIO.AppendTextAsync(bookfile, InfoBox.Text + Environment.NewLine);
            //await FileIO.AppendTextAsync(bookfile, ratingNum + Environment.NewLine);
            BooksSaved.Text = ("Book saved succesfully");           
        }
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
        private void NavigateBack()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null) return;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            BookName.Text = String.Empty;
            Author.Text = String.Empty;
            InfoBox.Text = String.Empty;
            PageNum.Text = String.Empty;
            Rating.SelectedItem = null;
        }
    }
}
