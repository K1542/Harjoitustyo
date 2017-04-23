using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace MyMediaLibrary2
{
    public sealed partial class FilmPage : Page
    {
        public FilmPage()
        {
            this.InitializeComponent();
        }
        private void FilmAddPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FilmAddPage));
        }

        private void FilmViewPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FilmViewPage));
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
    }
}
