using MauiAppApi.Pages;

namespace MauiAppApi
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void DovizKurlariButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DovizKurlari());
        }

        private void HavaDurumuButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HavaDurumu());
        }
    }
}
