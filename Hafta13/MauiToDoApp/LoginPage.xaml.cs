using MauiToDoApp.Services;

namespace MauiToDoApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string message = "";
        var res = await FirebaseServices.Login(EmailEntry.Text, PasswordEntry.Text, ref message);
        if(res)
        {
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            await DisplayAlertAsync("Login Failed", message, "OK");
        }
    }

    private  void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new RegisterPage());
    }
}