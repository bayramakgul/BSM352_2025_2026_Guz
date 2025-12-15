using MauiAppApi.Services;

using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiAppApi.Pages;

public partial class HavaDurumu : ContentPage
{
	ObservableCollection<Sehir> Sehirler;

    ObservableCollection<Sehir> LoadSehirler()
	{
		string openfilepath= Path.Combine(FileSystem.AppDataDirectory, "sehirler.json");
		if (File.Exists(openfilepath))
		{
			var json = File.ReadAllText(openfilepath);
			Sehirler = JsonSerializer.Deserialize<ObservableCollection<Sehir>>(json);
		}
		else
		{
            Sehirler = new ObservableCollection<Sehir>()
			{
				new Sehir { SehirAdi="Ýstanbul"},
				new Sehir { SehirAdi="Ankara"},
				new Sehir { SehirAdi="Ýzmir"},
				new Sehir { SehirAdi="Bursa"},
				new Sehir { SehirAdi="Antalya"},
			};
		}

		return Sehirler;
	}

    public HavaDurumu()
	{
		InitializeComponent();

		lstSehirler.ItemsSource = LoadSehirler();
    }

	private async void AddSehir_Clicked(object sender, EventArgs e)
	{
		var sehir = await DisplayPromptAsync(
			"Þehir Ekle",
			"Lütfen þehir adýný giriniz:",
			"Tamam", "Ýptal",
			placeholder: "Örn: Ýstanbul"
			);

		if (sehir != null)
		{
			Sehirler.Add(new Sehir { SehirAdi = sehir });
		}
	}

    private void Remove_Clicked(object sender, EventArgs e)
    {
		var sehir = (sender as Button).CommandParameter as Sehir;
		Sehirler.Remove(sehir);
    }

    private void Update_Clicked(object sender, EventArgs e)
    {
        var sehir = (sender as Button).CommandParameter as Sehir;
		var ix = Sehirler.IndexOf(sehir);
        Sehirler.Remove(sehir);
		Sehirler.Insert(ix, new Sehir() { SehirAdi = sehir.SehirAdi });
    }

    private void ContentPage_Unloaded(object sender, EventArgs e)
    {
	  string savefilepath = Path.Combine(FileSystem.AppDataDirectory, "sehirler.json");
		var json = JsonSerializer.Serialize(Sehirler);
		File.WriteAllText(savefilepath, json);
    }


}