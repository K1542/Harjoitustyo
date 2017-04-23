using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMediaLibrary2
{
    public sealed partial class BookPage : Page
    {
        public BookPage()
        {
            this.InitializeComponent();
        }
        private void BookAddPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BookAddPage));
        }
        private void BookViewPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BookViewPage));
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
