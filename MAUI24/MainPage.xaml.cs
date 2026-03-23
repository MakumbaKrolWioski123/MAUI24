namespace MAUI24
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnZapiszClicked(object? sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "notatka.txt");
            string tresc = ZapiszEntry.Text;

            await File.WriteAllTextAsync(sciezka, tresc);
            await DisplayAlert("Zapisano", "Notatka została zapisana.", "OK");
        }

        private async void OnOdczytajClicked(object? sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "notatka.txt");
            if (File.Exists(sciezka))
            {
                string tresc = await File.ReadAllTextAsync(sciezka);
                NotatkaLabel.Text = tresc;
            }
            else
            {
                NotatkaLabel.Text = "Brak zapisanej notatki.";
            }
        }
    }
}
