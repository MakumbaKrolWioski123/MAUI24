using System.Collections.ObjectModel;

namespace MAUI24;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}

    public async void DodajWpisClicked(object? sender, EventArgs e)
    {
        string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
        string tresc = DateTime.Now.ToString("yyyy-MM-dd HH-mm") + " " + WpisEditor.Text;
        await File.WriteAllTextAsync(sciezka, tresc);
        await DisplayAlert("Zapisano", "Notatka zosta³a zapisana.", "OK");
    }

    public class Plik
    {
        public string Nazwa { get; set; }
        public string Rozmiar { get; set; }
    }

    public ObservableCollection<Plik> Pliki { get; set; } = new()
    {
    new Plik { Nazwa = "notatka1.txt", Rozmiar = "12 KB" },
    new Plik { Nazwa = "notatka2.txt", Rozmiar = "2 MB" }
    };
}