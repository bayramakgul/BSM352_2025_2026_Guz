
using BusinessLayer;
using EntityLayer;
using MauiRehberApp.ViewModel;
using MauiRehberApp.Views;


namespace MauiRehberApp
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;

        public MainPage()
        {
            viewModel = new MainViewModel(ShowErrorMessage);
            InitializeComponent();
            BindingContext = viewModel;
        }
        private void Filtrele(object sender, EventArgs e)
        {
            viewModel.Filtrele(FilterText.Text);
        }
        private void EkleToolbarItem_Clicked(object sender, EventArgs e)
        {
            ContactView contactView = new ContactView(null);
            Navigation.PushModalAsync(contactView);
        }

        private void DuzenleToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (viewModel.YeniKisi != null)
            {
                ContactView contactView = new ContactView(viewModel.YeniKisi);
                Navigation.PushModalAsync(contactView);
            }
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.YeniKisi = (Kisi)e.CurrentSelection.FirstOrDefault();
        }

        async void ShowErrorMessage(string message)
        {
           await DisplayAlertAsync("HATA", message, "OK");
        }

        private async void SilToolbarItem_Clicked(object sender, EventArgs e)
        {
            var kisi = viewModel.YeniKisi;
            if (kisi != null)
            {
                string message = string.Empty;
                var ok = await DisplayAlertAsync("Silme İşlemi", $"{kisi.Ad} {kisi.Soyad} silinsin mi?", 
                    "Evet", "Hayır");
                if (ok)
                {
                    var res = BL.Sil(kisi.Id, out message);
                    if (res)
                    {
                        await DisplayAlertAsync("BAŞARILI", "Silindi", "OK");
                    }
                    else
                    {
                        await DisplayAlertAsync("HATA", message, "OK");
                    }
                }
            }
        }


    }
}
