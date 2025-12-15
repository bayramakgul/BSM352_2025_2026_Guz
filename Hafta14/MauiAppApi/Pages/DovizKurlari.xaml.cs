using MauiAppApi.Services;

namespace MauiAppApi.Pages;

public partial class DovizKurlari : ContentPage
{
	public DovizKurlari()
	{
		InitializeComponent();

		var data = KurServisi.KurlariYukle("https://www.tcmb.gov.tr/kurlar/today.xml");

		KurlarList.ItemsSource = data.kurlar;
		lblDate.Text = $"Döviz Kurlarý Sayfasý Tarih: {data.tarih}";
    }
}