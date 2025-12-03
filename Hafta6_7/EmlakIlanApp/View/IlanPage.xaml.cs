using EmlakIlanApp.Model;

using System.Collections.ObjectModel;

namespace EmlakIlanApp.View;

public partial class IlanPage : ContentPage
{
	ObservableCollection<Emlak> Ilanlar;
    public IlanPage()
	{
		InitializeComponent();
        Ilanlar = DataGenerator.RandomEmlakUret(50);
        lstIlanlar.ItemsSource = Ilanlar;

    }

    private void lstIlanlar_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void TelButtonClicked(object sender, EventArgs e)
    {
        if (lstIlanlar.SelectedItem == null)
            return;

        var emlak = lstIlanlar.SelectedItem as Emlak;
        DisplayAlert("Telefon", emlak.Telefon, "OK", "Cancel");

    }

    private void EmailButtonClicked(object sender, EventArgs e)
    {
        if (lstIlanlar.SelectedItem == null)
            return;

        var emlak = lstIlanlar.SelectedItem as Emlak;
        //DisplayAlert("E-Mail", emlak.Email, "OK", "Cancel");

        DisplayActionSheet("Ýletiþim Kanalý", "Cancel", "OK", 
            "E-Mail: "+ emlak.Email, 
            "Telefon: " + emlak.Telefon,
            "Seslen :)");

    }

    private void EditButtonClicked(object sender, EventArgs e)
    {
        if (lstIlanlar.SelectedItem == null)
            return;

        var emlak = lstIlanlar.SelectedItem as Emlak;
        var page = new IlanDetailsPage(emlak);
        Navigation.PushAsync(page);

    }
}