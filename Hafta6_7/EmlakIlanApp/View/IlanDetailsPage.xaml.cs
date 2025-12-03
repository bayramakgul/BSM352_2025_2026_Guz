using EmlakIlanApp.Model;

namespace EmlakIlanApp.View;

public partial class IlanDetailsPage : ContentPage
{
	Emlak emlak;
	public IlanDetailsPage(Emlak _emlak)
	{
		InitializeComponent();
		emlak = _emlak;
		BindingContext = emlak;

        lstKonumlar.ItemsSource = DataGenerator.Konumlar;
		lstResimler.ItemsSource = emlak.ResimLinkleri;
    }
}