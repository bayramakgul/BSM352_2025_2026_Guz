using BusinessLayer;

using EntityLayer;

namespace MauiRehberApp.Views;

public partial class ContactView : ContentPage
{
	bool UpdateMode;
    public Kisi Kisi { get; set; }
	public ContactView(Kisi kisi)
	{
		InitializeComponent();
		if(kisi != null)
		{
			Kisi = kisi;
			UpdateMode = true;
		}
		else
		{
			Kisi = new Kisi();
			UpdateMode = false;
        }

		this.BindingContext = Kisi;
    }


    private void SaveClicked(object sender, EventArgs e)
    {
		bool sonuc = false;
		string mesaj = string.Empty;

        if (UpdateMode)
			sonuc = BL.Guncelle(Kisi, out  mesaj);
        else
			sonuc = BL.Ekle(Kisi, out  mesaj);

		if (sonuc)
		{
			DisplayAlertAsync("BAÞARILI", "Ýþlem baþarýlý", "OK");
			Navigation.PopModalAsync();
		}
		else
		{
			DisplayAlertAsync("HATA", mesaj, "OK");
		}
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void AddImage(object sender, EventArgs e)
    {
		var res = await DisplayActionSheetAsync("Resim Ekle", "Ýptal", null, "Kamera", "Galeri");
		if(res != null)
		{
			if(res.Equals("Kamera"))
			{
				//kamera açýlacak
				if (MediaPicker.IsCaptureSupported)
				{
					var im = await MediaPicker.Default.CapturePhotoAsync();
					if (im != null)
						Kisi.Resim = im.FullPath;
                }
				else
				{
					DisplayAlertAsync("HATA", "Cihazýnýz kamera desteklemiyor", "OK");
                }
            }
			else if(res.Equals("Galeri"))
			{
				//galeri açýlacak
				var im = await MediaPicker.Default.PickPhotoAsync();
				if(im != null)
					Kisi.Resim = im.FullPath;
            }
		}
    }
}