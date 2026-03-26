namespace MAUI24;

public partial class NewPage3 : ContentPage
{
	public NewPage3()
	{
		InitializeComponent();
	}

	private async void EksportClicked(object sender, EventArgs e)
	{
        string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "notatki_eksport.txt");
        string tresc = DateTime.Now.ToString("yyyy-MM-dd HH-mm") + "\n" + NotatkaEditor.Text + "\n";

		await File.WriteAllTextAsync(sciezka, tresc);
        OperacjeLabel.Text = OperacjeLabel.Text + "\n" + DateTime.Now.ToString("yyyy-MM-dd HH-mm")+" Eksport";
    }

	private async void ImportClicked(object sender, EventArgs e)
	{

        var opcjeTekst = new PickOptions

        {

            PickerTitle = "Wybierz plik tekstowy",

            FileTypes = new FilePickerFileType(

  new Dictionary<DevicePlatform, IEnumerable<string>>

  {

   { DevicePlatform.Android, new[] { "text/plain" } },

   { DevicePlatform.iOS, new[] { "public.plain–text" } },

   { DevicePlatform.WinUI, new[] { ".txt" } },

  })

        };
        try
        { 
            var wynik = await FilePicker.Default.PickAsync(opcjeTekst);
            if (wynik != null)
            {
                string nazwaPliku = wynik.FileName;
                string pelnaSciezka = wynik.FullPath;
                await DisplayAlert("Wybrano plik", $"Nazwa: {nazwaPliku}", "OK");
                string tresc = await File.ReadAllTextAsync(pelnaSciezka);
                NotatkaEditor.Text = tresc;
                OperacjeLabel.Text = OperacjeLabel.Text + "\n" + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + " Import";
            }
        }

        catch (Exception ex)
        {

            await DisplayAlert("B³¹d", $"Nie uda³o siê wybraæ pliku: {ex.Message}", "OK");

        }
    }
}

/*
 * nazwa funkcji:EksportClicked
 * opis funkcji:Zapisuje notatke w nastepnej linijce notatki_eksport.txt i dodaje do dziennika date i wykonane zadania
 * parametry: object? sender, EventArgs e
 *zwracany typ: brak
 *autor: Ja
*/


/*nazwa funkcji:ImportClicked
 * opis funkcji:Wybiera plik tekstowy i wyswietla go w notatka editor aby moc go edytowac
 * parametry: object? sender, EventArgs e
 *zwracany typ: brak
 *autor: Ja
*/

