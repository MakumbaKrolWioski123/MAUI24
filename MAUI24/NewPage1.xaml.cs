using System.Threading.Tasks;

namespace MAUI24;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
        string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "historia.txt");
        if (File.Exists(sciezka))
        {
            string tresc = File.ReadAllText(sciezka);
            DziennikLabel.Text = tresc;
        }
    }

    private async void DodajWpisClicked(object? sender, EventArgs e)
    {
        string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
        string sciezka2 = Path.Combine(FileSystem.Current.AppDataDirectory, "historia.txt");
        string tresc = DateTime.Now.ToString("yyyy-MM-dd HH-mm") + " " + WpisEditor.Text;

        await File.WriteAllTextAsync(sciezka, tresc);
        await File.AppendAllTextAsync(sciezka2, tresc + Environment.NewLine);

        await DisplayAlert("Zapisano", "Notatka zosta³a zapisana.", "OK");
        DziennikLabel.Text = DziennikLabel.Text+"\n"+tresc;
    }

    private async void WyczyscClicked(object? sender, EventArgs e)
    {
        string potwierdzenie = await DisplayActionSheet("Czy na pewno chcesz wyczyœciæ dziennik?", "Anuluj", "Tak");
        if (potwierdzenie == "Tak")
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
            if (File.Exists(sciezka))
            {
                File.Delete(sciezka);
            }
            DziennikLabel.Text = string.Empty;
        }
    }
}

/*nazwa funkcji:DodajWpisClicked
 * opis funkcji: dodaje wpis do dziennik.txt
 * parametry: object? sender, EventArgs e
 *zwracany typ: brak
 *autor: Ja
*/
/*nazwa funkcji:
 * opis funkcji: 
 * parametry: object? sender, EventArgs e
 *zwracany typ: brak
 *autor: Ja
*/