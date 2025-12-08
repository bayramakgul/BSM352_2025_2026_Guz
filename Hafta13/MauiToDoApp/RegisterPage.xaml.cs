using MauiToDoApp.Services;

namespace MauiToDoApp;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private void OnGotoLoginPageButtonClicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void CancelButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string message = "";
        // Kaydetme metodu:
        var res = await FirebaseServices.Register(UsernameEntry.Text, EmailEntry.Text, PasswordEntry.Text, ref message);
        if (res == true)
        {
            await DisplayAlertAsync("Kayýt baþarýlý", "Hesabýnýz oluþturuldu.", "Tamam");
        }
        else
        {
            await DisplayAlertAsync("Kayýt baþarýsýz", message, "Tamam");
        }
    }
}