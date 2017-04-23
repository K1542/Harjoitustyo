using System;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
namespace MyMediaLibrary2
{
    public sealed partial class FilmAddPage : Page
    {
        private Film film;
        private ObservableCollection<Film> films;
        private StorageFile filmfile;
        public FilmAddPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<Book>)
            {
                films = (ObservableCollection<Film>)e.Parameter;
            }
            base.OnNavigatedTo(e);
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile filmfile = await storageFolder.CreateFileAsync("Films.txt", CreationCollisionOption.OpenIfExists);
            film = new Film();
            film.FilmName = FilmName.Text;
            film.Actor = Actor.Text;
            film.Info = InfoBox.Text;
            // Change string from textblock to int
            int num;
            num = Convert.ToInt32(FilmLength.Text);
            num = int.Parse(FilmLength.Text);
            num = film.Length;
            film.Length = num;
            
            // Stream commented out because it didn't work. The data doesn't save correctly to dat.file
            /*Stream stream = await filmfile.OpenStreamForWriteAsync();
            DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<Book>));
            serializer.WriteObject(stream, films);
            await stream.FlushAsync();
            stream.Dispose();*/

            // Change string from ComboBox to int for saving
            int ratingNum;
            bool parseOK = Int32.TryParse(ComboBox.SelectedItemProperty.ToString(), out ratingNum);
            film.Rating = ratingNum;

            // Write data from textboxes one entry at a time to a text file, and add newline after each one
            // Have to do it this way because it's the only way I can print anything at all to a file. No idea why, though.
            await FileIO.AppendTextAsync(filmfile, FilmName.Text + Environment.NewLine);
            await FileIO.AppendTextAsync(filmfile, Actor.Text + Environment.NewLine);
            await FileIO.AppendTextAsync(filmfile, FilmLength.Text + Environment.NewLine);
            await FileIO.AppendTextAsync(filmfile, InfoBox.Text + Environment.NewLine);
            //await FileIO.AppendTextAsync(filmfile, ratingNum + Environment.NewLine);
            // Print to show that file has been saved
            FilmsSaved.Text = ("Film saved succesfully");
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
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
            // Clears all input data so user doesn't have to manually delete everything, in case they want to
            // add multiple titles at once.
            FilmName.Text = String.Empty;
            Actor.Text = String.Empty;
            InfoBox.Text = String.Empty;
            FilmLength.Text = String.Empty;
            Rating.SelectedItem = null;
        }
    }
}
